using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.IO;
using Sinowyde.DOP.SamaEngine.Server.Properties;
using Sinowyde.Log;
using Sinowyde.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Sinowyde.DOP.SamaEngine.Server
{
    /// <summary>
    /// 数据更新参数
    /// </summary>
    public class UpdateRTValueArg : EventArgs
    {
        /// <summary>
        /// 实时数据值
        /// </summary>
        public RTValue Value
        {
            get;
            set;
        }
        /// <summary>
        /// 主题
        /// </summary>
        public string Topic
        {
            get;
            set;
        }
        /// <summary>
        /// 是否是页间引用变量
        /// </summary>
        public bool IsBetweenPage
        {
            get;
            set;
        }
    }
    /// <summary>
    /// 数据更新事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="arg"></param>
    public delegate void EventUpdateRTValue(object sender, UpdateRTValueArg arg);

    /// <summary>
    /// sama页数据关系
    /// </summary>
    public class SamaPageRunTime
    {
        /// <summary>
        /// 变量与算法的关联关系
        /// </summary>
        private DataMemCache<string, IList<PIDBindAlgorithm>> varWithAlgorithm = 
            new DataMemCache<string, IList<PIDBindAlgorithm>>();
        /// <summary>
        /// 算法组缓存
        /// </summary>
        public IList<PIDBindAlgorithm> algorithms = new List<PIDBindAlgorithm>();
        /// <summary>
        /// 无输入算法块
        /// </summary>
        private IList<PIDBindAlgorithm> noInputAlgoritm = new List<PIDBindAlgorithm>();
        /// <summary>
        /// 数据更新事件
        /// </summary>
        public event EventUpdateRTValue eventUpdateValue = null;
        /// <summary>
        /// 相关变量列表
        /// </summary>
        public IList<string> BindVarList = new List<string>();
        /// <summary>
        /// 触发计算
        /// </summary>
        /// <param name="alg"></param>
        private void TriggerOneAlgorithm(PIDBindAlgorithm alg)
        {
            if (alg.DoCalc()) //推动计算
            {
                if (Settings.Default.DebugLog)
                    LogUtilEx.LogDebug(string.Format("时间--{0}， 页号--{1}， 块号--{2}， ID--{3}", 
                        DateTime.Now, alg.GroupIndex, alg.IndexInGroup, alg.Identity));
                IList<PIDAlgorithmVar> outputs = alg.GetAllOutput(true);
                if (outputs == null)
                    return;

                foreach (PIDAlgorithmVar output in outputs)
                {
                    string number = alg.GetResultVarName(output.Name);
                    if (eventUpdateValue != null)
                    {
                        //如果是调试状态下，不写回数据到ioserver，所有数据都是IOTemp
                        //如果输出变量没有被引用，并且为IOTemp，则应该是页间引用
                        eventUpdateValue(this, new UpdateRTValueArg
                        {
                            Value = new RTValue { VarNumber = number, Timestamp = DateTime.Now, Value = output.Value },
                            Topic = number.StartsWith(BindSourceToken.PrefixBlock) || alg.IsDebug ? IOTopic.IOTemp : IOTopic.IOWrite,
                            IsBetweenPage = (alg is PIDPage) && !(alg as PIDPage).IsInput
                        });
                    }
                    //迭代执行
                    PushSama(new RTValue
                    {
                        VarNumber = number,
                        Timestamp = DateTime.Now,
                        Value = output.Value,
                        Quality = RtValueQuality.good
                    });
                }
            }
        }

        /// <summary>
        /// 触发无输入参数模块计算
        /// </summary>
        public void TrigerNoInputAlgoritm()
        {
            foreach (PIDBindAlgorithm alg in this.noInputAlgoritm)
            {
                TriggerOneAlgorithm(alg);
            }
        }

        /// <summary>
        /// 输入sama条件
        /// </summary>
        public void PushSama(RTValue value)
        {
            IList<PIDBindAlgorithm> algs = varWithAlgorithm.Get(value.VarNumber);
            if (algs == null)
                return;
            foreach (PIDBindAlgorithm alg in algs)
            {
                alg.SetBindParamValue(value.VarNumber, value.Value);
                TriggerOneAlgorithm(alg);
            }
        }

        /// <summary>
        /// 增加一个算法块进行分析
        /// </summary>
        /// <param name="algorithm"></param>
        private void AddOneRelation(PIDBindAlgorithm algorithm)
        {
            IList<string> bindVars = algorithm.GetBindInputNames();
            if (bindVars.Count == 0)
                noInputAlgoritm.Add(algorithm);

            else
            {
                foreach (var varName in bindVars)
                {
                    if (null == varWithAlgorithm.Get(varName))
                        varWithAlgorithm.Add(varName, new List<PIDBindAlgorithm>());

                    if (!varWithAlgorithm.Get(varName).Contains(algorithm))
                        varWithAlgorithm.Get(varName).Add(algorithm);

                    if (!this.BindVarList.Contains(varName))
                        this.BindVarList.Add(varName);
                }
            }
        }

        /// <summary>
        /// 移除一个算法块关系
        /// </summary>
        private void RemoveOneRelation(PIDBindAlgorithm algoritm)
        {
            IList<string> bindVars = algoritm.GetBindInputNames();
            if (bindVars.Count == 0)
            {
                noInputAlgoritm.Remove(algoritm);
            }
            else
            {
                foreach (string varName in bindVars)
                {
                    if (varWithAlgorithm.Get(varName) != null)
                    {
                        varWithAlgorithm.Get(varName).Remove(algoritm);
                    }
                }
            }
        }

        /// <summary>
        /// 从数据库加载所有算法块
        /// </summary>
        public void AddPIDAlgorithm(string content)
        {
            try
            {
                var doc = new XmlDocument();
                doc.CreateXmlDeclaration("1.0", "UTF-8", "");
                doc.LoadXml(content);
                var docNode = doc.SelectSingleNode("/PIDDoc");
                if (null == docNode || null == docNode.ChildNodes || docNode.ChildNodes.Count == 0)
                    return;

                foreach (XmlNode node in docNode.ChildNodes)
                {
                    if (string.Compare(node.Name, "Block") != 0)
                        continue;
                    string assemble = node.Attributes["AlgAssembly"].Value;
                    if (string.IsNullOrEmpty((assemble)))
                        continue;
                    var algType = node.Attributes["AlgType"].Value;
                    var handle = Activator.CreateInstance(assemble, algType);
                    var alg = handle.Unwrap() as PIDBindAlgorithm;

                    alg.Identity = node.Attributes["Identity"].Value;
                    alg.VarParams = node.Attributes["VarParams"].Value;
                    alg.VarInputs = node.Attributes["VarInputs"].Value;
                    alg.VarOutputs = node.Attributes["VarOutputs"].Value;
                    alg.GroupIndex = node.Attributes["GroupIndex"].Value;
                    alg.IndexInGroup = node.Attributes["IndexInGroup"].Value;

                    algorithms.Add(alg);

                    AddOneRelation(alg);
                }
            }
            catch (Exception ex)
            {
                LogUtil.LogFatal("解析sama xml流出现错误", ex);
            }
        }      
    }
}
