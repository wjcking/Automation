using System.Drawing;
using System.Threading;
using Northwoods.Go;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.DTProxy;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.DB;
using Sinowyde.DOP.PIDBlock.GoObjectEx;
using Sinowyde.DOP.PIDBlock.Xml;
using Sinowyde.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Sinowyde.DOP.PIDBlock.Env
{
    public class PIDRunTime
    {
        #region  单例数据库访问对象

        private static PIDRunTime instance = null;
        private static object _lock = new object();
        public static PIDRunTime Instance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new PIDRunTime();
                }
            }
            return instance;
        }

        #endregion

        /// <summary>
        /// 模拟量的数据缓存,一个输出记过可能对应多个输入
        /// </summary>
        private static Dictionary<string, IList<BlockLink>> inputGuidBlockLinks = new Dictionary<string, IList<BlockLink>>();

        /// <summary>
        /// 算法块映射表
        /// </summary>
        private static DataMemCache<string, PIDGeneralBlock> guidGeneralBlock = new DataMemCache<string, PIDGeneralBlock>();

        /// <summary>
        /// 输出文字的缓存
        /// </summary>
        private static Dictionary<string, GoText> goTexts = new Dictionary<string, GoText>();

        private System.Threading.Timer threadTimer = new System.Threading.Timer(Thread_Timer_Method, null, -1, -1);



        private PIDRunTime()
        {

        }

        private static void Refreash()
        {
            if (null == PIDDocManager.Instance().ActiveDoc) return;
            var blocks = PIDDocManager.Instance().ActiveDoc.Blocks;
            foreach (var block in blocks)
            {
                //刷新block的输出
                IList<string> resultList = block.Algorithm.GetAllResultVarName();
                IList<RTValue> realResultValue = RTValueMemCache.Instance().GetValues(resultList);
                foreach (var rtValue in realResultValue)
                {
                    //输出文字
                    block.SetOutputText(rtValue.VarNumber, rtValue.Value);

                    //刷新线条的颜色  数字量,需要改变线的颜色  0 蓝色  1 红色
                    if (inputGuidBlockLinks.ContainsKey(rtValue.VarNumber))
                    {
                        foreach (var value in inputGuidBlockLinks[rtValue.VarNumber])
                        {
                            value.LinkColor = rtValue.Value.Equals(0) ? Color.Blue : Color.Red;
                        }
                    }
                }
            }
        }

        private static void Thread_Timer_Method(object o)
        {
            Refreash();
        }

        /// <summary>
        /// 启动运行
        /// </summary>
        public void StartRun()
        {
            Log.LogUtilEx.LogInfo("====>StartRun开始" + DateTime.Now);
            PIDGeneralBlock.IsRunning = true;
            VisOutputText(true);
            Log.LogUtilEx.LogInfo("====>StartRun--VisOutputText结束" + DateTime.Now);
            UpdateBlockState();
            Log.LogUtilEx.LogInfo("====>StartRun--UpdateBlockState结束" + DateTime.Now);
            threadTimer.Change(0, 500);
            Log.LogUtilEx.LogInfo("====>StartRun结束" + DateTime.Now);
        }

        /// <summary>
        /// 结束运行
        /// </summary>
        public void StopRun()
        {
            Log.LogUtilEx.LogInfo("====>StopRun开始" + DateTime.Now);
            threadTimer.Change(-1, -1);
            VisOutputText(false);
            Log.LogUtilEx.LogInfo("====>StopRun--VisOutputText结束" + DateTime.Now);
            CancleBlockState();
            Log.LogUtilEx.LogInfo("====>StopRun--CancleBlockState结束" + DateTime.Now);
            CancleLinkState();
            Log.LogUtilEx.LogInfo("====>StopRun--CancleLinkState结束" + DateTime.Now);
            PIDGeneralBlock.IsRunning = false;
            Log.LogUtilEx.LogInfo("====>StopRun结束开始" + DateTime.Now);
        }

        //缓存Block
        private void AnalyzeBlock()
        {
            guidGeneralBlock.Clear();
            foreach (var document in PIDDocManager.Instance().Documents)
            {
                var blocks = document.Blocks;
                foreach (var block in blocks)
                {
                    guidGeneralBlock.Add(block.Identity, block);
                }
            }
        }

        //缓存模拟量的BlockLink
        private void AnalyzeBlockLink()
        {
            inputGuidBlockLinks.Clear();
            foreach (var document in PIDDocManager.Instance().Documents)
            {
                var links = document.Links.Where(v => v.LinkStyle.Equals(0));
                foreach (var link in links)
                {
                    var toPort = link.ToPort as GoGeneralNodePort;
                    var algorithmVarTo = toPort.UserObject as PIDAlgorithmVar;
                    if (null != algorithmVarTo)
                    {
                        if (!inputGuidBlockLinks.ContainsKey(algorithmVarTo.BindSource))
                            inputGuidBlockLinks[algorithmVarTo.BindSource] = new List<BlockLink>();

                        inputGuidBlockLinks[algorithmVarTo.BindSource].Add(link);
                    }
                }
            }
        }

        private void UpdateBlockState()
        {
            //保持,强制状态
            var list = PIDDataLogic.Instance().GetAllAlgRunState();
            foreach (var pidAlgRunState in list)
            {
                var block = guidGeneralBlock.Get(pidAlgRunState.Guid);
                if (null == block) continue;

                if (pidAlgRunState.ParamType != PIDCommandParamType.Output)
                    continue;

                switch (pidAlgRunState.CommandType)
                {
                    case PIDCommandType.ForceValue:
                        for (int i = 0; i < block.RightPortsCount; i++)
                        {
                            var port = block.GetRightPort(i);
                            if (pidAlgRunState.Token.EndsWith(port.Name))
                                port.BrushColor = StateColor.Force;
                        }
                        break;
                    case PIDCommandType.KeepValue:
                        for (int i = 0; i < block.RightPortsCount; i++)
                        {
                            var port = block.GetRightPort(i);
                            if (pidAlgRunState.Token.EndsWith(port.Name))
                                port.BrushColor = StateColor.Keep;
                        }
                        break;
                }
            }
        }

        private void CancleBlockState()
        {
            //保持,强制状态
            var list = PIDDataLogic.Instance().GetAllAlgRunState();
            foreach (var pidAlgRunState in list)
            {
                var block = guidGeneralBlock.Get(pidAlgRunState.Guid);
                if (null == block) continue;

                switch (pidAlgRunState.CommandType)
                {
                    case PIDCommandType.ForceValue:
                    case PIDCommandType.KeepValue:
                        for (int i = 0; i < block.RightPortsCount; i++)
                        {
                            var port = block.GetRightPort(i);
                            port.BrushColor = StateColor.Normal;
                        }
                        break;
                }
            }

            ////取消输出
            //ICollection keys = guidGeneralBlock.GetKeys();
            //foreach (var key in keys)
            //{
            //    guidGeneralBlock.Get(key.ToString()).ClearOutputText();
            //}
        }

        private void CancleLinkState()
        {
            foreach (var inputGuidBlockLink in inputGuidBlockLinks)
            {
                foreach (var blockLink in inputGuidBlockLink.Value)
                {
                    blockLink.LinkColor = Color.Black;
                }
            }
        }

        private void CreateOutputText()
        {
            goTexts.Clear();
            foreach (var doc in PIDDocManager.Instance().Documents)
            {
                var blocks = doc.OfType<PIDGeneralBlock>();
                foreach (var block in blocks)
                {
                    var dic = block.CreateOutputText();
                    foreach (var goText in dic)
                    {
                        goTexts.Add(goText.Key, goText.Value);
                    }
                }
            }
        }

        /// <summary>
        /// 显示输出,用于开环调试,在线调试
        /// </summary>
        /// <param name="visibility"></param>
        public void VisOutputText(bool visibility)
        {
            //1
            foreach (var item in goTexts)
            {
                item.Value.Text = visibility ? "null" : string.Empty;
            }

            //2
            //ICollection keys = goTexts.GetKeys();
            //foreach (var key in keys)
            //{
            //    if (visibility)
            //        goTexts.Get(key.ToString()).Text = "null";
            //    else
            //        goTexts.Get(key.ToString()).Text = "";
            //}


            //3
            //ICollection keys = guidGeneralBlock.GetKeys();
            //foreach (var key in keys)
            //{
            //    if (visibility)
            //        guidGeneralBlock.Get(key.ToString()).SetOutputText("null");
            //    else
            //        guidGeneralBlock.Get(key.ToString()).SetOutputText("");
            //}


            //4
            //foreach (var doc in PIDDocManager.Instance().Documents)
            //{
            //    var blocks = doc.OfType<PIDGeneralBlock>();
            //    foreach (var block in blocks)
            //    {
            //        if (visibility)
            //            block.SetOutputText("null");
            //        else
            //            block.SetOutputText("");
            //    }
            //}
        }

        public void CreateMemCache()
        {
            AnalyzeBlock();
            AnalyzeBlockLink();
            CreateOutputText();
        }
    }
}
