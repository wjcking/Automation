using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Sinowyde.DOP.Graph.DB;
using Sinowyde.DOP.Graph.Xml;
using Sinowyde.Util;

namespace Sinowyde.DOP.GraphicElement
{

    public partial class frmOpenDialog : XtraForm
    {
        public GraphDocument GraphDoc
        {
            get;
            set;
        }
         

        public frmOpenDialog()
        {
            InitializeComponent();

            this.Text = "打开图元";
            this.btnOpen.Text = "打 开";
            this.cboFileType.SelectedIndex = 0;
            LoadGraphInfo();
        }

        /// <summary>
        /// 加载图形信息
        /// </summary>
        private void LoadGraphInfo()
        {
            using (new WaitDialogForm("请等待", "文档加载中...", new Size(200, 50), ParentForm))
            {
                IList<GraphPageSummary> graphEntity = GraphDocManager.GetPageSummaryFromDB();
                this.gridCtrlDataInfo.DataSource = graphEntity;
                this.gridCtrlDataInfo.RefreshDataSource();
            }
        }
        /// <summary>
        /// 打开图元
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            var Name = ((List<GraphPageSummary>)gridView.DataSource)[this.gridView.GetFocusedDataSourceRowIndex()].Name;

            GraphDoc = GraphDocManager.Instance().GetDocument(Name);
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 取得文件名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridCtrlDataInfo_Click(object sender, EventArgs e)
        {
            this.txtFileName.Text = gridView.GetFocusedRowCellValue("Name").ToString();
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            btnOpen_Click(null, null);
        }


    }
}
