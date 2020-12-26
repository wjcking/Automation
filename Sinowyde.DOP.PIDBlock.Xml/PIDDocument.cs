using Northwoods.Go;
using Northwoods.Go.Xml;
using Sinowyde.DOP.PIDAlgorithm.DB;
using Sinowyde.DOP.PIDBlock.GoObjectEx;
using Sinowyde.DOP.PIDBlock.Xml.Transformer;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Sinowyde.DOP.PIDBlock.IO;
using System.Drawing;
using Sinowyde.DOP.PIDAlgorithm;

namespace Sinowyde.DOP.PIDBlock.Xml
{
    /// <summary>
    /// PID文档, 不要人为调用
    /// </summary>
    [Serializable]
    public class PIDDocument : GoDocument
    {
        public static bool VisBottomText = true;//组号-块号 显示

        public volatile bool ChangedBlock = false;

        public PIDDocument()
        {
            this.MaintainsPartID = true;
            //Ctrl C+V 走这个构造函数,用Doc当做容器整体序列化
            this.AlgPage = new PIDAlgPage();
            this.Changed += PIDDocument_Changed;
        }

        private PIDGeneralBlock lastPIDGeneralBlock = null;
        private void PIDDocument_Changed(object sender, GoChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Hint.ToString() + "   " + e.SubHint.ToString());  
            //这里要区分开新建的和复制的~
            switch (e.Hint)
            {
                case GoLayer.InsertedObject:
                    {
                        // 新建算法块，则需设置相关属性
                        PIDGeneralBlock block = e.GoObject as PIDGeneralBlock;
                        if (block != null)
                        {
                            if (this.AlgPage.GIndex != 0)  //==0时，是ctrl+c, !=0时，是ctrl+v,调试发现 ,如果有其它需要重置的地方，在此增加代码
                            {
                                block.Identity = Guid.NewGuid().ToString("N");
                                block.Algorithm.GroupIndex = this.AlgPage.GIndex.ToString();
                                block.Algorithm.IndexInGroup = GetMaxIndex().ToString();
                                block.BottomText = VisBottomText ? string.Format("{0}-{1}", block.Algorithm.GroupIndex, block.Algorithm.IndexInGroup) : string.Empty;
                                //页间关系
                                PageBlockRelation.Instance().AddBlock(block);
                            }
                            block.DrawBackground();//文字的需要改,把原来文字替换 不是新建zza IO里
                        }
                        lastPIDGeneralBlock = block;
                        this.ChangedBlock = true;
                    }
                    break;
                case GoLayer.RemovedObject:
                    {
                        PIDGeneralBlock block = e.GoObject as PIDGeneralBlock;
                        if (block != null)
                        {
                            //页间关系
                            PageBlockRelation.Instance().RemoveBlock(block);
                        }
                        BlockLink blockLink = e.GoObject as BlockLink;
                        if (null != blockLink)
                        {
                            var toPort = blockLink.ToPort;
                            if (null != toPort)
                            {
                                var toNodePort = toPort as GoGeneralNodePort;
                                if (null != toNodePort)
                                {
                                    var algorithmVarTo = toNodePort.UserObject as PIDAlgorithmVar;
                                    var toNode = toPort.Node as PIDGeneralBlock;
                                    toNode.Algorithm.UnBindParam(algorithmVarTo.Name);
                                }
                            }
                        }
                    }
                    this.ChangedBlock = true;
                    break;
                case GoLayer.ChangedObject:
                    //连接关系发生变化
                    if (e.SubHint == GoLink.ChangedFromPort || e.SubHint == GoLink.ChangedToPort)
                    {
                        this.ChangedBlock = true;
                    }
                    //算法发生变化
                    if (e.SubHint == PIDGeneralBlock.ChangedAlgorithm)
                    {
                        this.ChangedBlock = true; 
                    }
                    break;
                default:
                    break;
            }
        }

        private long GetMaxIndex()
        {
            IEnumerable<PIDGeneralBlock> blocks = this.Blocks;
            if (null == blocks || blocks.Count<PIDGeneralBlock>() == 0)
                return 1L;

            long index = blocks.Max(v => ConvertUtil.ConvertToLong(v.Algorithm.IndexInGroup));
            return index + 1L;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="algPage"></param>
        public PIDDocument(PIDAlgPage algPage)
        {
            this.MaintainsPartID = true;
            if (algPage == null)
                throw new ArgumentNullException("AlgPage is null");
            this.AlgPage = algPage;
            this.UnSerializeContent();
            this.Changed += PIDDocument_Changed;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="algPage"></param>
        public PIDDocument(string summary, string pageContent)
        {
            this.MaintainsPartID = true;
            this.AlgPage = new PIDAlgPage();
            this.Name = summary;
            this.AlgPage.Content = pageContent;
            this.UnSerializeContent();
            this.Changed += PIDDocument_Changed;
        }
        /// <summary>
        /// 包含的所有算法块
        /// </summary>
        public IEnumerable<PIDGeneralBlock> Blocks
        {
            get
            {
                return this.OfType<PIDGeneralBlock>();
            }
        }
        /// <summary>
        /// 所有线条
        /// </summary>
        public IEnumerable<BlockLink> Links
        {
            get
            {
                return this.OfType<BlockLink>();
            }
        }
        /// <summary>
        /// 关联算法页
        /// </summary>
        [NonSerialized]
        private PIDAlgPage algPage = null;
        public PIDAlgPage AlgPage
        {
            get
            {
                return this.algPage;
            }
            private set
            {
                this.algPage = value;
            }
        }
        /// <summary>
        /// 文档名称
        /// </summary>
        public override string Name
        {
            get
            {
                return AlgPage.Summary;
            }
            set
            {
                AlgPage.Summary = value;
            }
        }

        public override string ToString()
        {
            return AlgPage.ToString();
        }

        /// <summary>
        /// 解析算法页，生成内部算法块
        /// </summary>
        /// <returns></returns>
        public bool UnSerializeContent()
        {
            try
            {
                string content = AlgPage.Content.Trim();
                if (!string.IsNullOrEmpty(content))
                {
                    this.DefaultLayer.Clear();

                    XmlDocument xmlStream = new XmlDocument();
                    xmlStream.CreateXmlDeclaration("1.0", "UTF-8", "");
                    xmlStream.LoadXml(content);

                    GoXmlReader xr = new GoXmlReader();
                    xr.AddTransformer(new PIDBlockTransformer());
                    xr.AddTransformer(new PIDBlockLinkTransformer());
                    xr.AddTransformer(new PIDBlockTextTransformer());
                    xr.RootObject = this;
                    object doc = xr.Consume(xmlStream);
                    //关联link
                    IEnumerable<BlockLink> links = this.Links;
                    foreach (BlockLink link in links)
                    {
                        PointF[] points = link.RealLink.CopyPointsArray();
                        link.FromPort = this.FindPart(link.FromPortID) as IGoPort;
                        link.ToPort = this.FindPart(link.ToPortID) as IGoPort;
                        //设置端口后，线会被按照默认规则绘制，原有轨迹失效，此处强制再次绘制
                        link.RealLink.ClearPoints();
                        foreach (PointF point in points)
                        {
                            link.RealLink.AddPoint(point);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogFatal("解析sama流出错" + this.AlgPage.Guid, ex);
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
            this.AlgPage.Content = SerializeContent();
            PIDDataLogic.Instance().Insert(this.AlgPage);
            this.ChangedBlock = false;
        }

        private GoXmlWriter GetXmlWriter()
        {
            GoXmlWriter writer = new GoXmlWriter();
            writer.RootElementName = "PIDDoc";
            writer.AddTransformer(new PIDBlockTransformer());
            writer.AddTransformer(new PIDBlockLinkTransformer());
            writer.AddTransformer(new PIDBlockTextTransformer());
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

        /// <summary>
        /// 更新页索引
        /// </summary>
        /// <param name="index"></param>
        public void UpdateIndex(long pageIndex)
        {
            this.AlgPage.GIndex = pageIndex;
            foreach (GoObject obj in this.DefaultLayer.GetEnumerator())
            {
                if (obj is PIDGeneralBlock)
                    (obj as PIDGeneralBlock).Algorithm.GroupIndex = pageIndex.ToString();
            }
        }
        /// <summary>
        /// 检测文档有效性
        /// 返回错误算法块
        /// </summary>
        /// <returns></returns>
        public bool CheckValid()
        {
            var isValid = true;
            var blocks = this.Blocks;
            foreach (var block in blocks)
            {
                if (!block.CheckSelfValid())
                    isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// 设置连线变量连接关系
        /// </summary>
        public void ResetRelation()
        {
            //分析数据库变量引用关系
            IEnumerable<BlockLink> links = this.Links;
            foreach (var link in links)
            {
                //解析连接关系
                var fromPort = link.FromPort as GoGeneralNodePort;
                var toPort = link.ToPort as GoGeneralNodePort;
                var fromBlock = link.FromNode as PIDGeneralBlock;
                var algorithmVar = toPort.UserObject as PIDAlgorithmVar;
                algorithmVar.BindSource = BindSourceToken.GetName(fromBlock.Identity, (fromPort.UserObject as PIDAlgorithmVar).Name);
            }
        }
    }
}

