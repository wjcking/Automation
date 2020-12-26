using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;
using Northwoods.Go.Xml;
using Sinowyde.DOP.PIDBlock.GoObjectEx;

namespace Sinowyde.DOP.PIDBlock.Xml.Transformer
{

    /// <summary>
    /// Link 序列化转换
    /// </summary>
    public class PIDBlockLinkTransformer : GoXmlTransformer
    {
        public PIDBlockLinkTransformer()
        {
            this.ElementName = "Link";
            this.TransformerType = typeof(BlockLink);
        }

        /// <summary>
        /// 生成xml文件节点
        /// </summary>
        /// <param name="obj"></param>
        public override void GenerateAttributes(Object obj)
        {
            BlockLink blockLink = obj as BlockLink;
            base.GenerateAttributes(blockLink);
            WriteAttrVal("PartID", blockLink.PartID);
            WriteAttrVal("FromPortID", (blockLink.FromPort as GoPort).PartID);
            WriteAttrVal("ToPortID", (blockLink.ToPort as GoPort).PartID);
            WriteAttrVal("LinkStyle", blockLink.LinkStyle);
            WriteAttrVal("Points", blockLink.RealLink.CopyPointsArray());
        }
        /// <summary>
        /// 设置算法属性
        /// </summary>
        /// <param name="obj"></param>        
        public override void ConsumeAttributes(object obj)
        {         
            base.ConsumeAttributes(obj);
            BlockLink blockLink = obj as BlockLink;
            blockLink.PartID = Int32Attr("PartID", 0);           
            blockLink.LinkStyle = Int32Attr("LinkStyle", 0);
            PointF[] points = PointFArrayAttr("Points", null);
            if (points != null)
            {
                foreach (PointF point in points)
                {
                    blockLink.RealLink.AddPoint(point);
                }
            }
            blockLink.FromPortID = Int32Attr("FromPortID", 0);
            blockLink.ToPortID = Int32Attr("ToPortID", 0);
        }
    }
}
