using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Northwoods.Go;
using Northwoods.Go.Draw;
using System.ComponentModel.Composition.Hosting;
using System.Windows.Forms;
using Sinowyde.Log;

namespace Sinowyde.DOP.GraphicElement.Base
{
    /// <summary>
    /// 创建元素，mef接口
    /// </summary>
    public interface IGraphFactory
    {
        DOPGraphElement CreateElement();
    }

    public interface IGraphMetaData
    {
        string Name { get; }
        int Order { get; }
        string Group { get; }
        string ImgUrl { get; }
    }
    
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property), MetadataAttribute]
    public class ExportGraphMetaDataAttribute : ExportAttribute, IGraphMetaData
    {
        public ExportGraphMetaDataAttribute(string name, int order, string group, string imgUrl = null)
        {
            this.Name = name;
            this.Order = order;
            this.Group = group;
            this.ImgUrl = imgUrl;
        }

        public string Name { get; set; }
        public int Order { get; set; }
        public string Group { get; set; }
        public string ImgUrl { get; set; }
    }

    public class MefFramkGraph
    {
        [ImportMany(typeof(IGraphFactory))]
        public IEnumerable<Lazy<IGraphFactory, IGraphMetaData>> ToolAddGraph { get; set; }//图形组态图元集合

        public string SamaCurrentTool { get; set; }//SAMA软件当前使用的工具

        /// <summary>
        /// 图形组态软件当前使用的工具
        /// </summary>
        public string GraphCurrentTool { get; set; }

        public MefFramkGraph()
        {
            try
            {
                var catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new DirectoryCatalog(Application.StartupPath));
                var container = new CompositionContainer(catalog);
                container.ComposeParts(this);
            }
            catch (CompositionException ex)
            {
                LogUtil.LogFatal("MefTool类container.ComposeParts(this)异常,异常信息:" + ex.ToString());
            }
            catch (Exception ex)
            {
                LogUtil.LogFatal("MefTool类container.Exception(this)异常,异常信息:" + ex.ToString());
            }
        }
    }
}
