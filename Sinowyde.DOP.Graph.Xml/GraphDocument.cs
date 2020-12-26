using Newtonsoft.Json;
using Northwoods.Go;
using Northwoods.Go.Xml;
using Sinowyde.DOP.Graph.DB;
using Sinowyde.DOP.GraphicElement.Base;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sinowyde.DOP.Graph.Xml
{    
    [Serializable]
    public class GraphDocument : GoDocument
    {  
        public GraphDocument()
        {
            MaintainsPartID = true;
            this.GraphPage = new GraphPage();
            this.Changed += GraphDocument_Changed;
        }

        void GraphDocument_Changed(object sender, GoChangedEventArgs e)
        {            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphPage"></param>
        public GraphDocument(GraphPage graphPage)
        {
            if (graphPage == null)
                throw new ArgumentNullException("graphPage is null");
            MaintainsPartID = true;
            this.GraphPage = graphPage;
            this.UnSerializeContent();
            this.Changed += GraphDocument_Changed;
            this.Bounds  = new RectangleF(this.Bounds.X, this.Bounds.Y, this.Bounds.Width, this.Bounds.Height);
        }
       
        /// <summary>
        /// 关联算法页
        /// </summary>
        [NonSerialized]
        private GraphPage graphPage = null;
        public GraphPage GraphPage
        {
            get
            {
                return this.graphPage;
            }
            private set
            {
                this.graphPage = value;
            }
        }
        /// <summary>
        /// 文档名称
        /// </summary>
        public override string Name
        {
            get
            {
                return GraphPage.Name;
            }
            set
            {
                GraphPage.Name = value;
            }
        }
        /// <summary>
        /// 解析算法页，生成内部图形
        /// </summary>
        /// <returns></returns>
        public bool UnSerializeContent()
        {
            try
            {
                string content = GraphPage.Content.Trim();
                if (!string.IsNullOrEmpty(content))
                {
                    this.DefaultLayer.Clear();

                    XmlDocument xmlStream = new XmlDocument();
                    xmlStream.CreateXmlDeclaration("1.0", "UTF-8", "");
                    xmlStream.LoadXml(content);

                    GoXmlReader xr = new GoXmlReader();
                    xr.AddTransformer(new GraphTransformer());
                    xr.AddTransformer(new GraphDocTransformer(this));
                    xr.RootObject = this;
                    object doc = xr.Consume(xmlStream);
                    var elements = (doc as GoDocument).OfType<DOPGraphElement>();
                    foreach (var element in elements)
                    {
                        this.DefaultLayer.Add(element);
                    }
                }                
                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("解析Graph流出错" + this.GraphPage.Name, ex);
                return false;
            }
        }
        /// <summary>
        /// 生成页内容
        /// </summary>
        /// <returns></returns>
        public bool SaveFile(string fileFullName)
        {
            try
            {
                FileStream stream = new FileStream(fileFullName, FileMode.CreateNew);
                GetXmlWriter().Generate(stream);
                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("保存文件出错", ex);
                return false;
            }
        }

        
        /// <summary>
        /// 更新到数据库
        /// </summary>
        public void UpdateDB()
        {        
            this.GraphPage.Content = SerializeContent();
            if (GraphPage.ID == 0)
                GraphDataLogic.Instance().Insert(this.GraphPage);
            else
                GraphDataLogic.Instance().Update(this.GraphPage);
        }
        /// <summary>
        /// 序列化
        /// </summary>
        /// <returns></returns>
        private GoXmlWriter GetXmlWriter()
        {
            GoXmlWriter writer = new GoXmlWriter();
            writer.AddTransformer(new GraphDocTransformer(this));
            writer.AddTransformer(new GraphTransformer());
            writer.NodesGeneratedFirst = true;
            writer.Objects = this;
            return writer;
        }
        /// <summary>
        /// 序列化文档
        /// </summary>
        /// <returns></returns>
        public string SerializeContent()
        {
            StringWriter sw = new StringWriter();
            GetXmlWriter().Generate(sw);
            return sw.ToString();
        }
        
    }
}

