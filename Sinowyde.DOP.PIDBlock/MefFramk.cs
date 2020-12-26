using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwoods.Go;

namespace Sinowyde.DOP.PIDBlock
{
    public interface IToolBlock
    {
        PIDGeneralBlock CreateBlock();//用于拖拽 点击后 加载到View里
        PIDGeneralBlock CreateBlockForXml();//用于XmlTransformer序列化
    }

    public interface IBlockMetaData
    {
        string Name { get; }
        string Group { get; }
        int Order { get; }
        string NormalImgUrl { get; }
        string ThumImgUrl { get; }
    }


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property), MetadataAttribute]
    public class ExportBlockMetaDataAttribute : ExportAttribute, IBlockMetaData
    {
        public ExportBlockMetaDataAttribute(string name, string group, int order, string normalImgUrl = null, string thumImgUrl = null)
        {
            this.Name = name;
            this.Group = group;
            this.Order = order;
            this.NormalImgUrl = normalImgUrl;
            this.ThumImgUrl = thumImgUrl;
        }

        public string Name { get; set; }
        public string Group { get; set; }
        public int Order { get; set; }
        public string NormalImgUrl { get; set; }
        public string ThumImgUrl { get; set; }
    }
}
