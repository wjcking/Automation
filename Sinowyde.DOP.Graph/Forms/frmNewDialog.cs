using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using Sinowyde.DOP.Graph.DB;
using Sinowyde.DOP.Graph.Xml;

namespace Sinowyde.DOP.Graph
{
    public partial class frmNewDialog : XtraForm
    {
        public GraphDocument GraphDoc
        {
            get;
            set;
        }

        public frmNewDialog(GraphDocument doc=null)
        {
            this.GraphDoc = doc;
            InitializeComponent();
        }

        private void frmNewDialog_Load(object sender, EventArgs e)
        {
            if (GraphDoc != null)
            {
                this.txtName.Text = GraphDoc.Name;
                this.txtDescription.Text = GraphDoc.GraphPage.Description;
                this.colorBackGroudColor.Color = GraphDoc.PaperColor;
            }
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (GraphDoc == null)
                {
                    if (string.IsNullOrEmpty(this.txtName.Text) || this.txtName.Text.Trim().Length==0)
                    {
                        XtraMessageBox.Show("请输入文档名称！");
                        this.txtName.Focus();
                        return;
                    }
                    if (GraphDataLogic.Instance().IsExisted(this.txtName.Text))
                    {
                        XtraMessageBox.Show("图元已经存在！");
                        this.txtName.Focus();
                        return;
                    }
                    GraphDoc = GraphDocManager.Instance().NewPage(this.txtName.Text, this.txtDescription.Text, this.colorBackGroudColor.Color);
                }
                else {
                    GraphDoc.Name = this.txtName.Text;
                    GraphDoc.GraphPage.Description = this.txtDescription.Text;
                    GraphDoc.PaperColor = this.colorBackGroudColor.Color;
                    GraphDoc.UpdateDB();
                }
                this.DialogResult = DialogResult.OK ;
            }
            catch(Exception)
            {
                XtraMessageBox.Show("新建或者更新图元失败！");      
            }
        }
        /// <summary>
        /// 关闭画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lblBackGroudColor_Click(object sender, EventArgs e)
        {

        }

    }
}
