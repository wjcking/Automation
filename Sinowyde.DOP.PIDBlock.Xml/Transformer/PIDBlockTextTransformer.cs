using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go.Xml;
using Sinowyde.DOP.PIDBlock.GoObjectEx;

namespace Sinowyde.DOP.PIDBlock.Xml.Transformer
{
    /// <summary>
    /// text 序列化转换
    /// </summary>
    public class PIDBlockTextTransformer : GoXmlTransformer
    {
        public PIDBlockTextTransformer()
        {
            this.ElementName = "BlockText";
            this.TransformerType = typeof(BlockText);
        }

        /// <summary>
        /// 生成xml文件节点
        /// </summary>
        /// <param name="obj"></param>
        public override void GenerateAttributes(Object obj)
        {
            BlockText blockText = obj as BlockText;
            base.GenerateAttributes(blockText);
            WriteAttrVal("Location", blockText.Location);
            WriteAttrVal("Text", blockText.Text);
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="obj"></param>        
        public override void ConsumeAttributes(object obj)
        {
            base.ConsumeAttributes(obj);
            BlockText blockText = obj as BlockText;
            blockText.Location = PointFAttr("Location", new PointF(100, 100));//?
            blockText.Text = StringAttr("Text", "?");
        }
    }
}
