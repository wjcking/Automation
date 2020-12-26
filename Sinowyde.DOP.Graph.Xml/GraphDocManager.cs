using Sinowyde.DataModel;
using Sinowyde.DOP.Graph.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;
using System.Drawing;
using NHibernate.Criterion;
using System.Collections;
using System.Xml;
using Sinowyde.Zip;

namespace Sinowyde.DOP.Graph.Xml
{
    /// <summary>
    /// 文档集合管理器
    /// </summary>
    public class GraphDocManager
    {
        #region
        /// <summary>
        /// 单例数据库访问对象
        /// </summary>
        private static GraphDocManager instance = null;

        private static object _lock = new object();

        public static GraphDocManager Instance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new GraphDocManager();
                }
            }

            return instance;
        }

        private GraphDocManager()
        {
        }
        #endregion

        /// <summary>
        /// 备份路径
        /// </summary>
        private string BackupPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Sinowyde", "Graph", "BackupPath");

        /// <summary>
        /// 打开过的文档
        /// </summary>
        private IList<GraphDocument> openedDocs = new List<GraphDocument>();       
        /// <summary>
        /// 按照名称顺序返回打开的文档列表
        /// </summary>
        public IList<GraphDocument> OpenDocs
        {
            get
            {
                return openedDocs.OrderBy(v => v.Name).ToList<GraphDocument>();
            }
        }
        /// <summary>
        /// 查找打开的文档
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GraphDocument GetOpenedDoc(string name)
        {
            //缓存查找
            foreach (GraphDocument doc in openedDocs)
            {
                if (doc.Name == name)
                    return doc;
            }
            return null;
        }
        /// <summary>
        /// 获取索引对应文档
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public GraphDocument GetDocument(string name)
        {
            GraphDocument doc = GetOpenedDoc(name);
            if (doc == null)
            {
                //从数据库加载
                GraphPage page = GraphDataLogic.Instance().GetGraph(name);
                if (page != null)
                {
                    doc = new GraphDocument(page);
                    doc.Changed += doc_Changed;
                    openedDocs.Add(doc);
                }
            }
            return doc;
        }

        /// <summary>
        /// 移动已经打开的文档
        /// </summary>
        /// <param name="Name">文档名称</param>
        public void RemoveDocument(string name)
        {
            for (int i = 0; i < openedDocs.Count;i++ )
            {
                if (openedDocs[i].Name == name)
                {
                    openedDocs.RemoveAt(i);
                    break;
                }
            }
        }

        /// <summary>
        /// 文档是否打开
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool DocIsOpen(string name)
        {
            foreach (GraphDocument doc in openedDocs)
            {
                if (doc.Name == name)
                    return true ;
            }
            return false;
        }
        
        /// <summary>
        /// 从数据库加载所有页,建议不要用
        /// </summary>
        public void InitFromDB()
        {
            this.openedDocs.Clear();
            IList<GraphPage> pages = GraphDataLogic.Instance().GetGraphs();
            if (pages != null)
            {
                foreach (GraphPage page in pages)
                {
                    GraphDocument doc = new GraphDocument(page);
                    this.openedDocs.Add(doc);
                    doc.Changed += doc_Changed;                    
                }
            }
        }
        /// <summary>
        /// 文档发生变化，记录下来
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void doc_Changed(object sender, Northwoods.Go.GoChangedEventArgs e)
        {           
        }
        
        /// <summary>
        /// 新建页   
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public GraphDocument NewPage(string name, string description,Color color)
        {
            GraphDocument doc = new GraphDocument(new GraphPage() { Name = name, Description = description, Timestamp = DateTime.Now }) { PaperColor = color };
            doc.UpdateDB();
            doc.Changed += doc_Changed;
            //记录变更
            this.openedDocs.Add(doc);
            return doc;
        }
        /// <summary>
        /// 删除页
        /// </summary>
        /// <param name="id"></param>
        public void DeletePage(string name)
        {
            GraphDocument doc = GetOpenedDoc(name);
            if (doc != null)
            {
                this.openedDocs.Remove(doc);
                if (doc.GraphPage.ID != 0)
                    GraphDataLogic.Instance().RemoveGraph(doc.GraphPage.ID);
            }
            else
            {
                GraphDataLogic.Instance().DeleteGraph(name);
            }
        }
        /// <summary>
        /// 修改页
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void ModifyPage(string pageName, string name, string description)
        {
            GraphDataLogic.Instance().ModifyGraphContentWithName(pageName,name, description);
        }
        /// <summary>
        /// 保存组态页面
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public bool SavePage(string pageName)
        {
            try
            {
                GraphDocument doc = GetOpenedDoc(pageName);
                if (doc != null)
                {
                    if (doc.IsModified)
                    {
                        doc.UpdateDB();
                        doc.IsModified = false;
                    }
                    GraphDataLogic.Instance().UpdateModelVersion(ModelType.Graph);                   
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("GraphDocManager.SavePage:" + ex);
                return false;
            }
        }
        /// <summary>
        /// 保存所有页面
        /// </summary>
        /// <returns></returns>
        public bool SavePages()
        {
            try
            {
                foreach (GraphDocument doc in openedDocs)
                {
                    if (doc.IsModified)
                    {
                        doc.UpdateDB();
                        doc.IsModified = false;
                    }
                }

                GraphDataLogic.Instance().UpdateModelVersion(ModelType.Graph);
                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("GraphDocManager.SavePages:" + ex);
                return false;
            }
        }

        /// <summary>
        /// 添加备份
        /// </summary>
        /// <param name="people"></param>
        /// <param name="des"></param>
        /// <returns></returns>
        public bool Backup(string desFile)
        {
            string path = Path.GetTempPath();
            string timestamp = DateTime.Now.ToLongTimeString();
            string tempPath = string.Format("{0}\\{1}\\", path, timestamp);
            Directory.CreateDirectory(tempPath);
            IList<GraphPage> pages = GraphDataLogic.Instance().Query<GraphPage>(null, null, 0, 0);
            foreach (GraphPage page in pages)
            {
                XmlDocument xmlStream = new XmlDocument();
                xmlStream.CreateXmlDeclaration("1.0", "UTF-8", "");
                xmlStream.LoadXml(page.Content);
                xmlStream.Save(tempPath + page.Name + ".xml");
            }
            ZipHelper.Compress(Path.GetFileName(desFile), Path.GetFullPath(desFile));
            Directory.Delete(tempPath, true);
            return true;
        }

        /// <summary>
        /// 恢复到该备份
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool Recovery(string srcFile)
        {
            //清空库
            GraphDataLogic.Instance().ClearGraph();
            //解压倒入
            string path = Path.GetTempPath();
            string tempPath = string.Format("{0}\\{1}\\", path, Path.GetFileNameWithoutExtension(srcFile));
            Directory.CreateDirectory(tempPath);
            ZipHelper.Uncompress(srcFile, tempPath);
            foreach (string page in Directory.GetFiles(tempPath))
            {
                XmlDocument xmlStream = new XmlDocument();
                xmlStream.CreateXmlDeclaration("1.0", "UTF-8", "");
                xmlStream.Load(page);
                GraphDataLogic.Instance().NewGraph(Path.GetFileNameWithoutExtension(page), string.Empty, xmlStream.Value);
            }
            Directory.Delete(tempPath, true);
            return true;
        }

        /// <summary>
        /// 导出组态页面
        /// </summary>
        /// <param name="pageNames"></param>
        /// <param name="desPath"></param>
        /// <returns></returns>
        public bool Export(IList<string> pageNames, string desFile)
        {
            string path = Path.GetTempPath();
            string guid = Guid.NewGuid().ToString();
            string tempPath = string.Format("{0}\\{1}\\", path, guid);
            Directory.CreateDirectory(tempPath);
            IList<GraphPage> pages = GraphDataLogic.Instance().Query<GraphPage>(
                new List<AbstractCriterion> { Restrictions.In("Name", (IList)pageNames) }, null, 0, 0);
            foreach (GraphPage page in pages)
            {
                XmlDocument xmlStream = new XmlDocument();
                xmlStream.CreateXmlDeclaration("1.0", "UTF-8", "");
                xmlStream.LoadXml(page.Content);
                xmlStream.Save(tempPath + page.Name + ".xml");
            }
            ZipHelper.Compress(Path.GetFileName(desFile), Path.GetFullPath(desFile));
            Directory.Delete(tempPath, true);
            return true;
        }
        /// <summary>
        /// 导入组态画面
        /// </summary>
        /// <param name="srcFile"></param>
        /// <returns></returns>
        public bool Import(string srcFile)
        {
            string path = Path.GetTempPath();
            string tempPath = string.Format("{0}\\{1}\\", path, Path.GetFileNameWithoutExtension(srcFile));
            Directory.CreateDirectory(tempPath);
            ZipHelper.Uncompress(srcFile, tempPath);
            foreach (string page in Directory.GetFiles(tempPath))
            {
                XmlDocument xmlStream = new XmlDocument();
                xmlStream.CreateXmlDeclaration("1.0", "UTF-8", "");
                xmlStream.Load(page);
                GraphDataLogic.Instance().NewGraph(Path.GetFileNameWithoutExtension(page), string.Empty, xmlStream.Value);
            }
            Directory.Delete(tempPath, true);
            return true;
        }
        /// <summary>
        /// 从数据库获取所有页的简要信息
        /// </summary>
        /// <returns></returns>
        public static IList<GraphPageSummary> GetPageSummaryFromDB()
        {
            return GraphDataLogic.Instance().GetGraphSummarys();
        }
        /// <summary>
        /// 数据库库中是否存在页
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool IsExisted(string Name)
        {
            return GraphDataLogic.Instance().IsExisted(Name);
        }
    }
}
