using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;
using Sinowyde.DOP.UI;
using Ninject;
using Sinowyde.Log;
using Sinowyde.DOP.Graph.DB;
using Sinowyde.Util;
using Sinowyde.DOP.GraphicElement.Base;
using System.IO;
using Northwoods.Go.Xml;
using System.Windows.Forms;
using Sinowyde.DOP.DTProxy;
using Sinowyde.DOP.DataModel;

namespace Sinowyde.DOP.Graph
{
    public enum ActionEnum
    {
        Default = -1,
        OpenGraph,
        NewGraph,
        ModifyGraph,
        SaveGraph,
        DeleteGraph,
    }

    public class GraphDocManager:GoDocument
    {
        #region 属性变量
        /// <summary>
        /// 文档集合
        /// </summary>
        private IDictionary<long, GoDocument> docDictionary = new Dictionary<long, GoDocument>();

        public IDictionary<string, GoDrawViewEx> dicDrawViewEx = new Dictionary<string, GoDrawViewEx>();

        private static GraphDocManager instance = null;

        private static object graphLock = new object();

        public ActionEnum CurrentAction { get; set; }

        public  GoDocument ActiveDoc 
        { 
            get; 
            private set; 
        }

        public GoDrawViewEx goDrawViewEx
        {
            get;
            private set; 
        }
        #endregion

        public static GraphDocManager Instance()
        {
            if (null == instance)
            {
                lock (graphLock)
                {
                    if (null == instance)
                        instance = new GraphDocManager();
                }
            }

            return instance;
        }

        /// <summary>
        /// 新建文档
        /// </summary>
        /// <returns></returns>
        public bool NewGraphDoc(string name, string description)
        {
            try
            {
                var goDocument = new GoDocument() { Name = name, MaintainsPartID = true };
                var content = XmlTransformer.GoDocumentToString(goDocument);
                var graphEntity = GraphDataLogic.Instance().NewGraph(name, description, content);
                AddGraphToDocument(goDocument,graphEntity.ID);
                goDocument.Name = goDocument.Name + "," + graphEntity.ID.ToString();

                return SetActiveDoc(graphEntity.ID);
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogInfo("[GraphDocManager].[DeleteGraphDoc]新建文档失败", ex);
                return false;
            }
        }

        /// <summary>
        /// 修改文档
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        public bool ModifyGraphDoc(long id, string description)
        {
            try
            {
                GraphDataLogic.Instance().ModifyGraphDescription(id, description);

                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogInfo("[GraphDocManager].[ModifyGraphDoc]修改文档失败", ex);
                return false;
            }
        }

        /// <summary>
        /// 删除文档
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteGraphDoc(long id)
        {
            try
            {
                GraphDataLogic.Instance().RemoveOneGraph(id);
                if (this.docDictionary.ContainsKey(id))
                   return this.docDictionary.Remove(id);
                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogInfo("[GraphDocManager].[DeleteGraphDoc]删除文档失败" , ex);
                return false;
            }
        }

        /// <summary>
        /// 打开文档
        /// </summary>
        /// <param name="id">文档id</param>
        /// <returns></returns>
        public bool OpenGraphDoc(long id)
        {
            try
            {
                var graphEntity = GraphDataLogic.Instance().GetGraph(id);
                GoDocument graphDocument = XmlTransformer.StringToDocument(graphEntity.Content);
                graphDocument.Name = graphEntity.Name + "," + id.ToString();
                AddGraphToDocument(graphDocument, id);

                return SetActiveDoc(graphEntity.ID);
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogInfo("[GraphDocManager].[OpenGraphDoc]打开文档失败" , ex);
                return false;
            }
        }

        /// <summary>
        /// 保存文档
        /// </summary>
        /// <returns></returns>
        public bool SaveGraphDoc()
        {
            try
            {
                foreach (var item in docDictionary)
                {
                    var docContent = XmlTransformer.GoDocumentToString(item.Value);
                    GraphDataLogic.Instance().ModifyGraphContent(item.Key, docContent);
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogInfo("[GraphDocManager].[SaveGraphDoc]保存异常", ex);
                return false;
            }
        }

        /// <summary>
        /// 保存文档
        /// </summary>
        /// <returns></returns>
        public bool SaveAsGraphDoc(long id, string Name)
        {
            try
            {
                var docContent = XmlTransformer.GoDocumentToString(docDictionary[id]);
                //GraphDataLogic.Instance().ModifyGraphContentWithName(id, docContent, Name);
                File.WriteAllText(@"C:\Users\Administrator\Desktop\TestXML.Graph", docContent);
                return true ;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogInfo("[GraphDocManager].[SaveGraphDoc]保存异常", ex);
                return false;
            }
        }

        /// <summary>
        /// 添加图形到文档
        /// </summary>
        /// <param name="goDocument"></param>
        public void AddGraphToDocument(GoDocument goDocument,long id)
        {
            if (null == goDocument) return;
            RemoveGraphToDocument(id);
            docDictionary.Add(id, goDocument);
        }
        /// <summary>
        /// 删除图形
        /// </summary>
        /// <param name="id"></param>
        public void RemoveGraphToDocument(long id)
        {
            if (docDictionary.ContainsKey(id))
            {
                var name = docDictionary[id].Name.Split(',')[0];
                if (dicDrawViewEx.ContainsKey(name))
                    dicDrawViewEx.Remove(name);
                docDictionary.Remove(id);
            }
        }

        /// <summary>
        /// 设置当前文档  
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  bool SetActiveDoc(long id)
        {
            GoDocument goDocument = null;
            var flag = docDictionary.TryGetValue(id, out goDocument);
            if (flag)
                this.ActiveDoc = goDocument;
            if (dicDrawViewEx.ContainsKey(goDocument.Name.Split(',')[0]))
                goDrawViewEx = this.dicDrawViewEx[goDocument.Name.Split(',')[0]];
            return flag;
        }

        public bool IsExisted(string Name)
        {
            return GraphDataLogic.Instance().IsExisted(Name);
        }

        /// <summary>
        /// 保存图形与动画
        /// </summary>
        private void SaveGraphWithAction()
        {
            //保存图形及动画
            foreach (var goView in this.dicDrawViewEx)
            {
                foreach (GoObject obj in goView.Value.Document.GetEnumerator())
                {
                    foreach (var action in DOPGeneralShape.TransFromShape(obj).Action)
                    {
                        
                    }
                }
            }
        }
    }
}
