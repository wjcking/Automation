using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Sinowyde.DOP.GraphicElement
{
    public partial class frmGraphLibs : XtraForm
    {

        public string fileName { get; set; }
        private IList<string> imageList = new List<string>();

        public frmGraphLibs()
        {
            InitializeComponent();
        }

        private void frmGraphLibs_Load(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void LoadImage()
        {
            string imageLib = Environment.CurrentDirectory + "\\ImageLibrary";
            if (Directory.Exists(imageLib))
            {
                DirectoryInfo directory = new DirectoryInfo(imageLib);
                foreach (var s in directory.GetFiles())
                {
                    imageList.Add(s.FullName);
                    listBoxControl1.Items.Add(s.Name.Substring(0, s.Name.Length - 4));
                }
                if(listBoxControl1.Items.Count<1)
                    btnOpen.Enabled = false;
            }
            else
            {
                btnOpen.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            fileName = imageList[listBoxControl1.SelectedIndex];
            this.DialogResult = DialogResult.OK;
        }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.picImage.Image =Image.FromFile(imageList[listBoxControl1.SelectedIndex]);
        }
    }
}
