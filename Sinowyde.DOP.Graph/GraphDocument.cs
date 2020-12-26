using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;

namespace Sinowyde.DOP.Graph
{
    [Serializable]
    public class GraphDocument:GoDocument
    {
        #region 变量定义
        public const int changedLocation = LastHint + 23;

        /// <summary>
        /// 文档计数
        /// </summary>
        private static int docCounter = 1;

        /// <summary>
        /// 文档集合
        /// </summary>
        private IDictionary<string, GoDocument> docCollection = new Dictionary<string, GoDocument>();

        /// <summary>
        /// 文件路径
        /// </summary>
        private string filePath = "";
        #endregion

        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath
        {
            get { return filePath; }
            set
            {
                string oldFilePath = filePath;
                if (oldFilePath != value)
                {
                    RemoveDocument(oldFilePath);
                    filePath = value;
                    AddDocument(value, this);
                    RaiseChanged(changedLocation, 0, null, 0, oldFilePath, NullRect, 0, value, NullRect);
                }
            }
        }

        /// <summary>
        /// 是否只读
        /// </summary>
        public override bool IsReadOnly
        {
            get
            {
                if (string.IsNullOrEmpty(this.FilePath)) return false;
                FileInfo fileInfo = new FileInfo(this.FilePath);
                bool readOlny = ((fileInfo.Attributes & FileAttributes.ReadOnly) != 0);
                bool oldSkips = this.SkipsUndoManager;
                this.SkipsUndoManager = true;
                SetModifiable(!readOlny);
                this.SkipsUndoManager = oldSkips;
                return readOlny;
            }
        }

        public GraphDocument()
            : base() 
        {
            this.Name = "GraphDoc" + NextDocumentID();
            this.LinksLayer = this.Layers.CreateNewLayerBefore(this.Layers.Default);
            this.LinksLayer.Identifier = "Links";
            this.Layers.CreateNewLayerBefore(this.Layers.Default).Identifier = "bottom";
            this.MaintainsPartID = true;
            this.IsModified = false;
            UndoManager = new GoUndoManager();
        }
              
        public override void ChangeValue(GoChangedEventArgs e, bool undo)
        {
            if(e.Hint==changedLocation)
                this.FilePath = e.GetValue(undo).ToString();
            else
                base.ChangeValue(e, undo);
        }

        /// <summary>
        /// 文件保存
        /// </summary>
        /// <param name="fileStream"></param>
        /// <param name="filePath"></param>
        public void FileSave(Stream fileStream, String filePath)
        {
            bool oldskips = this.SkipsUndoManager;
            this.SkipsUndoManager = true;
            this.FilePath = filePath;
            int lastslash = filePath.LastIndexOf("\\");
            if (lastslash >= 0)
                this.Name = filePath.Substring(lastslash + 1);
            else
                this.Name = filePath;
            this.IsModified = false;
            this.SkipsUndoManager = oldskips;
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, this);
        }

        /// <summary>
        /// 文件加载
        /// </summary>
        /// <param name="fileStream">文件流</param>
        /// <param name="filePath">文档路径</param>
        /// <returns></returns>
        public GraphDocument FileLoad(Stream fileStream, string filePath)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                GraphDocument graphDocument = formatter.Deserialize(fileStream) as GraphDocument;
                graphDocument.FilePath = filePath;
                graphDocument.UndoManager = new GoUndoManager();
                graphDocument.IsModified = false;
                AddDocument(filePath, graphDocument);
                return graphDocument;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 下一个文档ID
        /// </summary>
        /// <returns></returns>
        public int NextDocumentID()
        {
            return docCounter++;
        }

        /// <summary>
        /// 查找文档
        /// </summary>
        /// <param name="filePath">文档键值</param>
        /// <returns></returns>
        public GraphDocument FindDocument(string docKey)
        {
            if (docCollection.ContainsKey(docKey))
            {
                return docCollection[docKey] as GraphDocument;
            }
            else { 
                return null;
            }
        }

        /// <summary>
        /// 添加文档
        /// </summary>
        /// <param name="docKey">文档键值</param>
        /// <param name="graphDocument">文档对象</param>
        private void AddDocument(string docKey, GraphDocument graphDocument)
        {
            docCollection.Add(docKey, graphDocument);
        }

        /// <summary>
        /// 删除文档
        /// </summary>
        /// <param name="docKey">文档键值</param>
        private bool RemoveDocument(string docKey)
        {
            if (docCollection.ContainsKey(docKey))
            {
                return docCollection.Remove(docKey);
            }
            return true;
        }
    }
}
