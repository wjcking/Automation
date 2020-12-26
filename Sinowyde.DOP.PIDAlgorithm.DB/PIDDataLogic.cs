using NHibernate;
using NHibernate.Criterion;
using Sinowyde.DataLogic;
using Sinowyde.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace Sinowyde.DOP.PIDAlgorithm.DB
{
    public class PIDDataLogic : DataLogicBase
    {
        #region 变量 && 属性

        /// <summary>
        /// 单例数据库访问对象
        /// </summary>
        private static PIDDataLogic instance = null;

        private static object _lock = new object();

        public static PIDDataLogic Instance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new PIDDataLogic();
                }
            }

            return instance;
        }

        #endregion

        public PIDDataLogic()
            : base(new PIDSessionManager())
        {
        }

        /// <summary>
        ///  得到所有的组
        /// </summary>
        /// <returns></returns>
        public IList<PIDAlgPage> GetPages()
        {
            return this.Query<PIDAlgPage>(null, null, 0, 0);
        }

        /// <summary>
        ///  得到所有的组的概要系你想
        /// </summary>
        /// <returns></returns>
        public IList<PIDAlgPageSummary> GetPageSummys()
        {
            return this.Query<PIDAlgPageSummary>(null, null, 0, 0);
        }
        /// <summary>
        /// 得到页内所有算法块，供组态调用
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
        public IList<PIDAlgEntity> GetAlgorithmSummarys(long pageID)
        {
            IList<PIDAlgEntity> algEntities = new List<PIDAlgEntity>();
            try
            {
                PIDAlgPage page = this.Get<PIDAlgPage>(pageID);
                if (page == null)
                    return algEntities;
                XmlDocument doc = new XmlDocument();
                doc.CreateXmlDeclaration("1.0", "UTF-8", "");
                //content = "<?xml version=\"1.0\"?>" + content;
                doc.LoadXml(page.Content);
                XmlNode docNode = doc.SelectSingleNode("/PIDDoc");
                if (docNode == null || docNode.ChildNodes == null ||
                    docNode.ChildNodes.Count == 0)
                    return algEntities;
                foreach (XmlNode node in docNode.ChildNodes)
                {
                    if (node.Name.Equals("Block"))
                    {
                        PIDAlgEntity alg = new PIDAlgEntity();
                        alg.AlgType = node.Attributes["AlgType"].Value;
                        alg.BIndex = node.Attributes["IndexInGroup"].Value;
                        alg.Identity = node.Attributes["Identity"].Value;
                        var varOutputs = JsonConvert.DeserializeObject<IList<PIDAlgorithmVarSpec>>(node.Attributes["VarOutputs"].Value);
                        foreach (var output in varOutputs)
                        {
                            alg.Outputs.Add(output.Name);
                        }
                        //var varIntputs = JsonConvert.DeserializeObject<IList<PIDAlgorithmVarSpec>>(node.Attributes["VarInputs"].Value);
                        //foreach (var input in varIntputs)
                        //{
                        //    alg.Inputs.Add(input.Name);
                        //} 
                        //var varParams = JsonConvert.DeserializeObject<IList<PIDAlgorithmParam>>(node.Attributes["VarParams"].Value);
                        //foreach (var param in varParams)
                        //{
                        //    alg.Params.Add(param.Name);
                        //}

                        algEntities.Add(alg);
                    }
                }

                return algEntities;
            }
            catch (Exception ex)
            {
                LogUtil.LogFatal("解析sama xml流出现错误", ex);
                return algEntities;
            }
        }

        /// <summary>
        ///修改组，并返回组索引
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public PIDAlgPage ModifyPageDescription(long pageID, long index, string description)
        {
            var now = DateTime.Now;
            var page = this.Get<PIDAlgPage>(pageID);
            page.GIndex = index;
            page.Description = description;
            page.Timestamp = now.Ticks;
            this.Update(page);
            return page;
        }

        /// <summary>
        /// 修改文档内容
        /// </summary>
        /// <param name="pageID"></param>
        /// <param name="content"></param>
        public PIDAlgPage ModifyPageContent(long pageID, string content)
        {
            var page = this.Get<PIDAlgPage>(pageID);
            page.Content = content;
            Update(page);
            return page;
        }

        /// <summary>
        /// 新建组，并返回组索引
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public PIDAlgPage NewPage(long index, string description)
        {
            var now = DateTime.Now;
            var page = new PIDAlgPage
                {
                    Guid = Guid.NewGuid().ToString("N"),
                    Description = description,
                    Timestamp = now.Ticks,
                    GIndex = index
                };
            Insert(page);
            return page;
        }


        /// <summary>
        /// 并返回组索引
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public long GetNewGIndex()
        {
            long index = 1;
            var last = this.Query<PIDAlgPage>(null, new List<Order> { Order.Desc("GIndex") }, 0, 1);
            if (null != last && last.Count > 0)
                index = last[0].GIndex + 1;

            return index;
        }

        public bool ExistGIndex(long gIndex)
        {
            var criterions = new List<AbstractCriterion>();
            criterions.Add(Restrictions.Eq("GIndex", gIndex));
            var page = this.Query<PIDAlgPage>(criterions, null, 0, 1).FirstOrDefault();
            if (null != page)
                return true;

            return false;
        }

        public long GetIdByGuid(string guid)
        {
            var criterions = new List<AbstractCriterion>();
            criterions.Add(Restrictions.Eq("Guid", guid));
            var page = this.Query<PIDAlgPage>(criterions, null, 0, 1).FirstOrDefault();
            if (null != page)
                return page.ID;

            return -1L;
        }

        /// <summary>
        /// 删除一组算法块，数据库设置为级联删除
        /// </summary>
        /// <param name="pageID"></param>
        public void RemoveOnePage(long pageID)
        {
            this.Delete<PIDAlgPage>(pageID);
        }

        /// <summary>
        /// 删除所有Group
        /// </summary>
        public void ClearPages()
        {
            this.Delete("delete from PIDAlgPage");
        }
        /// <summary>
        /// 删除运行状态信息设置
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="token"></param>
        public void RemoveAlgRunState(string guid, string token)
        {
            this.Delete(string.Format("delete from PIDAlgRunState where GUID='{0}' and Token='{1}'", guid, token));
        }

        public void InsertAlgRunState(PIDAlgRunState state)
        {
            var criterionsVariable = new List<AbstractCriterion>();
            criterionsVariable.Add(Restrictions.Eq("Guid", state.Guid));
            criterionsVariable.Add(Restrictions.Eq("Token", state.Token));
            IList<PIDAlgRunState> states = this.Query<PIDAlgRunState>(criterionsVariable, null, 0, 1);
            if (states != null && states.Count == 1)
            {
                state.ID = states[0].ID;
                this.Update(state);
            }
            else
            {
                this.Insert(state);
            }
        }

        public void ClearAlgRunState()
        {
            this.Delete("delete from PIDAlgRunState");
        }


        public IList<PIDAlgRunState> GetAllAlgRunState()
        {
            return this.Query<PIDAlgRunState>(null, null, 0, 0);
        }

        /// <summary>
        /// 删除运行状态信息设置
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="token"></param>
        public void RemoveOfflineDebug(string guid)
        {
            this.Delete(string.Format("delete from PIDAlgRunState where GUID='{0}' and PIDCommandType='{1}'", guid, PIDCommandType.OfflineDebug));
        }
    }
}
