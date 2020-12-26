using NHibernate;
using NHibernate.Criterion;
using Sinowyde.DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.Graph.DB
{
    public class GraphDataLogic : DataLogicBase
    {
        #region 变量 && 属性

        /// <summary>
        /// 单例数据库访问对象
        /// </summary>
        private static GraphDataLogic instance = null;

        private static object _lock = new object();

        public static GraphDataLogic Instance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new GraphDataLogic();
                }
            }

            return instance;
        }

        #endregion

        public GraphDataLogic()
            : base(new GraphSessionManager())
        {
        }
        /// <summary>
        ///  得到所有图
        /// </summary>
        /// <returns></returns>
        public IList<GraphPageSummary> GetGraphSummarys()
        {
            return this.Query<GraphPageSummary>(null, null, 0, 0);
        }
        /// <summary>
        ///  得到所有图
        /// </summary>
        /// <returns></returns>
        public IList<GraphPage> GetGraphs()
        {
            return this.Query<GraphPage>(null, null, 0, 0);
        }
        /// <summary>
        /// 得到指定ＩＤ图形文档
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GraphPage GetGraph(long id)
        {
            return this.Get<GraphPage>(id);
        }
        /// <summary>
        /// 查找图形页
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GraphPage GetGraph(string name)
        {
            var conditions = new List<AbstractCriterion>();
            conditions.Add(Restrictions.Eq("Name", name));
            IList<GraphPage> pages = this.Query<GraphPage>(conditions,null, 0, 1);
            if (pages == null || pages.Count == 0)
                return null;
            else
                return pages[0];
        }
        /// <summary>
        /// 获取文档ID
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public long GetIdByName(string name)
        {
            var graph = GetGraph(name);
            if (null != graph)
                return graph.ID;

            return -1L;
        }

        /// <summary>
        /// 新建图元，并返回图元对象
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public GraphPage NewGraph(string name, string description, string content)
        {
            GraphPage graph = new GraphPage
                    {
                        Description = description, 
                        Timestamp=DateTime.Now,
                        Name = name,
                        Content = content
                    };
            this.Insert(graph);
            return graph;
        }

        /// <summary>
        ///修改图元，并返回图元对象
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public void ModifyGraphDescription(long graphID, string description)
        {
            var graph = this.Get<GraphPage>(graphID);
            graph.Description = description;
            this.Update(graph);
        }
        /// <summary>
        /// 修改文档内容
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="content"></param>
        public void ModifyGraphContent(long graphID, string content)
        {
            var graph = this.Get<GraphPage>(graphID);
            graph.Content = content;
            Update(graph);
        }

        /// <summary>
        /// 修改文档内容
        /// </summary>
        /// <param name="groupID"></param>
        /// <param name="content"></param>
        public void ModifyGraphContentWithName(string pageName, string name, string Description)
        {
            long id = GetIdByName(pageName);
            var graph = this.Get<GraphPage>(id);
            graph.Description = Description;
            graph.Name = name;
            Update(graph);
        }

        /// <summary>
        /// 删除图元，数据库设置为级联删除
        /// </summary>
        /// <param name="groupID"></param>
        public void RemoveGraph(long graphID)
        {
            this.Delete<GraphPage>(graphID);
        }

        public void DeleteGraph(string name)
        {
            this.Delete(string.Format("delete from GraphPage where name = {0}", name));
        }

        public void ClearGraph()
        {
            this.Delete(string.Format("delete from GraphPage "));
        }
        /// <summary>
        /// 根据图元名称检索数据是否存在
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool IsExisted(string Name)
        {
            var criterions = new List<AbstractCriterion>();
            criterions.Add(Restrictions.Eq("Name", Name));
            var pointList = Instance().Query<GraphPage>(criterions, null, 0, 1);

            return pointList.Count > 0 ? true : false ;
        }

    }
}
