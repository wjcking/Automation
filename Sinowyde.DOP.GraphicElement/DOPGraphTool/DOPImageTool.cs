using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwoods.Go;
using Sinowyde.DOP.GraphicElement.Base;

namespace Sinowyde.DOP.GraphicElement
{
    [Export(typeof(IGraphFactory))]
    [ExportGraphMetaDataAttribute("图像", 7, "基本图形", "Image")]
    public class DOPImageTool : GraphElementTool<DOPImage, GoImage>
    {
        public DOPImageTool(GoView goView)
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
            OpenFileDialog filePath = new OpenFileDialog()
            {
                Title = "选择图片",
                Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png",
                InitialDirectory = @"C:\",
                FilterIndex = 1
            };
            if (filePath.ShowDialog() == DialogResult.OK)
            {
                var fileName = Environment.CurrentDirectory + "\\ImageLibrary" + filePath.FileName.Substring(filePath.FileName.LastIndexOf('\\'));
                if (!File.Exists(fileName))
                    File.Copy(filePath.FileName, fileName);
                this.Shape.Location = this.LastInput.DocPoint;
                this.Shape.Name = filePath.FileName.Substring(filePath.FileName.LastIndexOf('\\')+1);
                this.Shape.Image = Image.FromFile(filePath.FileName);
                this.Shape.NameIsUri = false;
                FinishTool();
            }
            else {
                this.StopTool();
            }
        }

    }
}
