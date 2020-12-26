using System;
using Sinowyde.DOP.GraphicElement.Base;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Northwoods.Go;
using Sinowyde.Util;
using System.IO;
using System.Drawing;
namespace Sinowyde.DOP.GraphicElement
{
    public partial class UCtlImageLibraryParam : XtraUserControl, ICtrlParamBase
    {
        private DOPGraphElement dopGraphElement = null;
        private OpenFileDialog ofd = new OpenFileDialog();
        private Image[] imageList;

        public UCtlImageLibraryParam()
        {
            InitializeComponent();
        }

        public UCtlImageLibraryParam(DOPGraphElement generalShape)
        {
            InitializeComponent();
            this.dopGraphElement = generalShape;
        }


        public void LoadParam()
        {
            string imageLib = Environment.CurrentDirectory + "\\ImageLibrary";

            if (!Directory.Exists(imageLib))
            {
                Directory.CreateDirectory(imageLib);
                listBoxControl1.Items.Add("请添加图片");
                return;
            }
           
            string[] imageFiles = Directory.GetFiles(imageLib);

            imageList = new Image[imageFiles.Length];

            for (int i = 0; i < imageList.Length; i++)
            {
                imageList[i] = Image.FromFile(imageFiles[i]);
                listBoxControl1.Items.Add(Path.GetFileName(imageFiles[i]));
            }

        }

        public bool SaveParam()
        {
            (dopGraphElement.First as GoImage).Name = listBoxControl1.SelectedItem.ToString();
            (dopGraphElement.First as GoImage).Image = pictureEdit1.Image;
            
            return true;
        }

        public System.Windows.Forms.UserControl GetParamCtrl()
        {
            return this;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

        }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureEdit1.Image = imageList[listBoxControl1.SelectedIndex];
        }

    }
}
