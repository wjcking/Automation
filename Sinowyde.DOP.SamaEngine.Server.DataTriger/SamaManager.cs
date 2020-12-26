using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.DB;
using Sinowyde.DOP.SamaEngine.Server.Properties;
using Sinowyde.Log;
using Sinowyde.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Sinowyde.DOP.SamaEngine.Server
{
    /// <summary>
    /// 运行态管理
    /// </summary>
    public class SamaManager
    {
        /// <summary>
        /// 算法组缓存
        /// </summary>
        private DataMemCache<string, PIDBindAlgorithm> idWithAlgorithm = new DataMemCache<string, PIDBindAlgorithm>();
        /// <summary>
        /// 算法页管理
        /// </summary>
        public IList<EngineThread> samaThreads = new List<EngineThread>();
        
        /// <summary>
        /// 数据更新事件
        /// </summary>
        public event EventUpdateRTValue eventUpdateValue = null;

        /// <summary>
        /// 初始化文档
        /// </summary>
        /// <returns></returns>
        public void CreateDocManager()
        {            
            IList<PIDAlgPage> pages = PIDDataLogic.Instance().GetPages();
            if(pages == null)
                return;
            int count = Math.Min(pages.Count, Settings.Default.ThreadCount);
            for (int i = 0; i < count; i++)
            {
                SamaPageRunTime pageRunTime = new SamaPageRunTime();
                pageRunTime.eventUpdateValue += pageRunTime_eventUpdateValue;
                samaThreads.Add(new EngineThread { Page = pageRunTime });
            }
            for (int i = 0; i < pages.Count; i++)
            {
                samaThreads[i%count].Page.AddPIDAlgorithm(pages[i].Content);
            }
            foreach(EngineThread thread in samaThreads)
            {
                foreach (PIDBindAlgorithm alg in thread.Page.algorithms)
                {
                    idWithAlgorithm.Add(alg.Identity, alg);
                }
            }
            StartRunState();
        }

        /// <summary>
        /// 数据发生更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void pageRunTime_eventUpdateValue(object sender, UpdateRTValueArg arg)
        {
            if (eventUpdateValue != null)
                eventUpdateValue(this, arg);
            if (arg.IsBetweenPage || arg.Topic == IOTopic.IOWrite)
            {
                foreach (EngineThread thread in this.samaThreads)
                {
                    thread.AddRTValue(arg.Value);
                }
            }
        }
        /// <summary>
        /// 启动sama
        /// </summary>
        public void StartSama()
        {
            foreach (EngineThread engine in samaThreads)
            {
                engine.Start();
            }
        }
        /// <summary>
        /// 结束引擎
        /// </summary>
        public void StopSama()
        {
            foreach (EngineThread engine in samaThreads)
            {
                engine.Stop();
            }
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="value"></param>
        public void AddRTValue(List<RTValue> values)
        {
            foreach (EngineThread engine in samaThreads)
            {
                engine.AddRTValue(values);
            }
        }

        /// <summary>
        /// 强制数据
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="inputType"></param>
        public void SetAlgValue(PIDCommmandMsg msg)
        {
            PIDBindAlgorithm alg = idWithAlgorithm.Get(msg.Guid);
            if (alg == null)
                return;

            if (msg.ParamType == PIDCommandParamType.Input)
            {
                double value = ConvertUtil.ConvertToDouble(msg.Value);
                if (msg.TakeEffect)
                {
                    double targetValue = value;
                    if (msg.IsBias)
                    {
                        targetValue = value + alg.GetInputVar(msg.Token).Value;
                    }
                    alg.SetInputValue(msg.Token, targetValue, PIDVarInputType.Set);
                }
                else
                {
                    alg.ResetInputType(msg.Token);                    
                }
            }
            else if (msg.ParamType == PIDCommandParamType.Output)
            {
                double value = ConvertUtil.ConvertToDouble(msg.Value);
                if (msg.TakeEffect)
                {
                    double targetValue = value;
                    if (msg.IsBias)
                    {
                        targetValue = value + alg.GetOutputVar(msg.Token).Value;
                    }
                    alg.SetOutputValue(msg.Token, targetValue, PIDVarInputType.Set);
                    //输出强制需要记录入库
                    PIDDataLogic.Instance().InsertAlgRunState(PIDAlgRunState.NewFrom(msg, targetValue.ToString()));
                }
                else
                {
                    //恢复为动态
                    alg.SetOutputInputType(msg.Token, PIDVarInputType.Dynamic);
                    PIDDataLogic.Instance().RemoveAlgRunState(msg.Guid, msg.Token);
                }
            }
            else
            {
                alg.SetParamValue(msg.Token, msg.Value);
            }
        }
        /// <summary>
        /// 跟随数据
        /// </summary>
        /// <param name="msg"></param>
        public void KeepAlgValue(PIDCommmandMsg msg)
        {
            PIDBindAlgorithm alg = idWithAlgorithm.Get(msg.Guid);
            if (alg == null)
                return;

            if (msg.ParamType == PIDCommandParamType.Input)
            {
                if (msg.TakeEffect)
                {
                    double targetValue = alg.GetInputVar(msg.Token).Value;
                    alg.SetInputValue(msg.Token, targetValue, PIDVarInputType.Keep);
                }
                else
                {
                    alg.ResetInputType(msg.Token);
                }
            }
            else if (msg.ParamType == PIDCommandParamType.Output)
            {               
                if (msg.TakeEffect)
                {
                    double targetValue = alg.GetOutputVar(msg.Token).Value;
                    alg.SetOutputValue(msg.Token, targetValue, PIDVarInputType.Keep);
                    //输出保持需要入库
                    PIDDataLogic.Instance().InsertAlgRunState(PIDAlgRunState.NewFrom(msg, targetValue.ToString()));
                }
                else
                {
                    //恢复为动态
                    alg.SetOutputInputType(msg.Token, PIDVarInputType.Dynamic);
                    PIDDataLogic.Instance().RemoveAlgRunState(msg.Guid, msg.Token);
                }
            }
            else
            {
                alg.SetParamValue(msg.Token, msg.Value);
            }
        }        

        /// <summary>
        /// 起效运行状态设置
        /// </summary>
        private void StartRunState()
        {
            IList<PIDAlgRunState> states = PIDDataLogic.Instance().Query<PIDAlgRunState>(null, null, 0, 0);
            PIDVarInputType inputType = PIDVarInputType.Dynamic;
            foreach (PIDAlgRunState msg in states)
            {
                if (msg.CommandType == PIDCommandType.ForceValue)
                    inputType = PIDVarInputType.Set;
                else if (msg.CommandType == PIDCommandType.KeepValue)
                    inputType = PIDVarInputType.Keep;
                else
                    continue;

                PIDBindAlgorithm alg = idWithAlgorithm.Get(msg.Guid);
                if (alg == null)
                    continue;

                double value = ConvertUtil.ConvertToDouble(msg.Value);
                alg.SetOutputValue(msg.Token, value, inputType);
            }
        }
        /// <summary>
        /// 是否开环调试
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isDebug"></param>
        public void SetOfflineDebug(string id, bool isDebug)
        {
            if (idWithAlgorithm.Get(id) != null)
            {
                idWithAlgorithm.Get(id).IsDebug = isDebug;
                if (isDebug)
                {
                    PIDAlgRunState state = new PIDAlgRunState
                    {
                        CommandType = PIDCommandType.OfflineDebug,
                        Guid = id,
                        Value = isDebug.ToString()
                    };
                    PIDDataLogic.Instance().Insert(state);
                }
                else
                {
                    PIDDataLogic.Instance().RemoveOfflineDebug(id);
                }
            }
        }

        public void CloneFrom(SamaManager srcManager)
        {
            if (srcManager == null)
                return;
            ICollection keys = this.idWithAlgorithm.GetKeys();
            if (keys == null || keys.Count == 0)
                return;
            foreach (object key in keys)
            {
                PIDBindAlgorithm srcAlg = srcManager.idWithAlgorithm.Get(key.ToString());
                if (srcAlg != null)
                {
                    this.idWithAlgorithm.Get(key.ToString()).CloneFrom(srcAlg);
                }
            }
        }
    }
}
