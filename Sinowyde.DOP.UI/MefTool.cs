using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using Northwoods.Go;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.Log;
namespace Sinowyde.DOP.UI
{
    public class MefTool
    {
        [ImportMany(typeof(IToolUc))]
        public IEnumerable<Lazy<IToolUc, IUcMetaData>> ToolAddUc { get; set; }//自定义控件集合,管理多个软件程序

        [ImportMany(typeof(IToolBlock))]
        public IEnumerable<Lazy<IToolBlock, IBlockMetaData>> ToolAddBlocks { get; set; }//Sama软件 Blocks集合
        public string SamaCurrentTool { get; set; }//SAMA软件当前使用的工具

        //[ImportMany(typeof(IToolGraph))]
        //public IEnumerable<Lazy<IToolGraph, IGraphMetaData>> ToolAddGraph { get; set; }//图形组态图元集合

        ///// <summary>
        ///// 图形组态软件当前使用的工具
        ///// </summary>
        //public string GraphCurrentTool { get; set; }
        public MefTool()
        {
            try
            {
                var catalog = new AggregateCatalog();
                catalog.Catalogs.Add(new DirectoryCatalog(Application.StartupPath));
                var container = new CompositionContainer(catalog);
                container.ComposeExportedValue<GoView>(NinjectHelper.Kernel.Get<GoView>());//DOPGeneralTool 需要构造函数
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
