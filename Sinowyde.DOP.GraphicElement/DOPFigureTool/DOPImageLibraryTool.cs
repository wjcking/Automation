using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwoods.Go;
using Sinowyde.DOP.GraphicElement.Base;

namespace Sinowyde.DOP.GraphicElement
{
    [Export(typeof(IGraphFactory))]
    [ExportGraphMetaDataAttribute("图库", 17, "扩展图形", "ImageLibrary")]
    public class DOPImageLibraryTool : GraphElementTool<DOPImage, GoImage>
    {
        public DOPImageLibraryTool(GoView goView)
            : base(goView)
        {
        }

        /// <summary>
        /// 启动绘制
        /// </summary>
        public override void Start()
        {
            this.View.CursorName = "crosshair";
            var extent = this.View.DocExtent;
            this.Shape.Position = new PointF(extent.Right + 10, extent.Bottom + 10);
        }

        public override void Stop()
        {
            this.View.CursorName = "default";
        }

        public override void DoMouseMove()
        {
            this.Shape.Location = this.LastInput.DocPoint;
        }

        public override void DoMouseUp()
        {
            frmGraphLibs frm = new frmGraphLibs();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Shape.Location = this.LastInput.DocPoint;
                this.Shape.Name = frm.fileName.Substring(frm.fileName.LastIndexOf('\\') + 1);
                this.Shape.Image = Image.FromFile(frm.fileName);
                FinishTool();
            }
            else
            {
                this.StopTool();
            }
        }

           public DOPGraphElement CreateElement()
        {
            return new DOPImageLibrary();
        }
    }

}
