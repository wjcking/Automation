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

namespace Sinowyde.DOP.Graph
{

    public partial class frmOpenDialog : XtraForm
    {
        public GraphDocument GraphDoc
        {
            get;
            set;
        }

        private ActionEnum ActionEnum = ActionEnum.Default;

        private long docID = 0;

        public frmOpenDialog()
        {
            InitializeComponent();
        }

        public frmOpenDialog(ActionEnum actionEnum)
        {
            InitializeComponent();
            ActionEnum = actionEnum;
            LoadGraphInfo();
        }

        public frmOpenDialog(ActionEnum actionEnum,long id)
        {
            InitializeComponent();
            ActionEnum = actionEnum;
            docID = id;
            LoadGraphInfo();
        }

        private void frmOpenDialog_Load(object sender, EventArgs e)
        {
            switch (this.ActionEnum)
            {
                case ActionEnum.OpenGraph:
                    this.Text = "打开文档";
                    this.btnOpen.Text = "打 开";
                    break;
                case ActionEnum.SaveGraph:
                    this.Text = "保存文档";
                    this.btnOpen.Text = "保 存";
                    break;
                default:
                    break;
            }
            this.cboFileType.SelectedIndex = 0;
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
            switch (this.ActionEnum)
            {
                case ActionEnum.OpenGraph:
                    var Name = ((List<GraphPageSummary>)gridView.DataSource)[this.gridView.GetFocusedDataSourceRowIndex()].Name;
                    if (GraphDocManager.Instance().DocIsOpen(Name))
                    {
                        XtraMessageBox.Show("文档已经打开！");
                    }
                    else
                    {
                        GraphDoc = GraphDocManager.Instance().GetDocument(Name);
                        this.DialogResult = DialogResult.OK;
                    }
                    break;
                case ActionEnum.SaveGraph:
                    //if (SaveDocument())
                    //{
                    //    XtraMessageBox.Show("保存图元成功！");
                    //    this.DialogResult = DialogResult.OK;
                    //}
                    //else
                    //{
                    //    XtraMessageBox.Show("保存图元失败！");
                    //}
                    break;
                default:
                    break;
            }
            
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
            if (this.ActionEnum == ActionEnum.OpenGraph)
            {
                btnOpen_Click(null, null);
            }
        }


    }
}
