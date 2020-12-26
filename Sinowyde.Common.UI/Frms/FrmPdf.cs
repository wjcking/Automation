using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Sinowyde.Common.UI
{
    public partial class FrmPdf : XtraForm
    {
        private string fileName = string.Empty;

        public FrmPdf(string fileName)
        {
            InitializeComponent();
            this.fileName = fileName;
        }

        private void FrmPdf_Load(object sender, EventArgs e)
        {
            pdfViewer.LoadDocument(fileName);
        }
    }
}
