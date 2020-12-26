using System;
using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace Sinowyde.DOP.UI
{
    public interface IToolUc
    {
        UserControl CreateUc();
        void SaveUc();
    }

    public interface IUcMetaData
    {
        string Name { get; }
        string ImgUrl { get; }
    }


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property), MetadataAttribute]
    public class ExportUcMetaDataAttribute : ExportAttribute, IUcMetaData
    {
        public ExportUcMetaDataAttribute(string name, string imgUrl = null)
        {
            this.Name = name;
            this.ImgUrl = imgUrl;
        }

        public string Name { get; set; }
        public string ImgUrl { get; set; }
    }
}
