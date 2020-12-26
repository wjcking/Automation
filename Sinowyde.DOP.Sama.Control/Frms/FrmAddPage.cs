using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.Util;
using Sinowyde.DOP.PIDBlock.Xml;

namespace Sinowyde.DOP.Sama.Control.Frms
{
    public partial class FrmAddPage : XtraForm
    {
        #region 变量

        public PIDDocument PIDDoc
        {
            get;
            set;
        }

        private const string FrmText = "修改页";

        #endregion

        public FrmAddPage(PIDDocument doc = null)
        {
            InitializeComponent();
            this.PIDDoc = doc;
        }

        private void FrmAddPage_Load(object sender, EventArgs e)
        {
            if (null != PIDDoc)
            {
                Text = FrmText;
                textEditDescription.Text = PIDDoc.AlgPage.Description;
                textEditGIndex.Text = PIDDoc.AlgPage.GIndex.ToString();
            }
            else
            {
                long index = PIDDocManager.Instance().GetMaxPageIndex() + 1;
                textEditGIndex.Text = index.ToString();
            }
            this.ActiveControl = this.textEditDescription;
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            if (null == PIDDoc)//新建页
            {
                if (AddPageCheckParams())
                {
                    AddPage();
                    DialogResult = DialogResult.OK;
                }
            }

            else//修改页
            {
                if (ModifyCheckParams())
                {
                    ModifyPage();
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool AddPageCheckParams()
        {
            if (string.IsNullOrEmpty(textEditGIndex.Text))
            {
                XtraMessageBox.Show("页号不可空！");
                return false;
            }

            int resultIndex;
            if (!Int32.TryParse(textEditGIndex.Text, out resultIndex))
            {
                XtraMessageBox.Show("页号不可以是非数字！");
                return false;
            }

            var flag = PIDDocManager.Instance().ExistGIndex(ConvertUtil.ConvertToLong(textEditGIndex.Text));
            if (flag)
            {
                XtraMessageBox.Show("已经存在该序号！");
                return false;
            }

            if (textEditDescription.Text.Contains("."))
            {
                XtraMessageBox.Show("描述不可以有非法字符！");
                return false;
            }

            return true;
        }

        private bool ModifyCheckParams()
        {
            if (string.IsNullOrEmpty(textEditGIndex.Text))
            {
                XtraMessageBox.Show("页号不可空！");
                return false;
            }

            int resultIndex;
            if (!Int32.TryParse(textEditGIndex.Text, out resultIndex))
            {
                XtraMessageBox.Show("页号不可以是非数字！");
                return false;
            }

            if (textEditDescription.Text.Contains("."))
            {
                XtraMessageBox.Show("描述不可以有非法字符！");
                return false;
            }


            if (!ConvertUtil.ConvertToLong(textEditGIndex.Text).Equals(PIDDoc.AlgPage.GIndex))//修改了Gindex
            {
                var flag = PIDDocManager.Instance().ExistGIndex(ConvertUtil.ConvertToLong(textEditGIndex.Text));
                if (flag)
                {
                    XtraMessageBox.Show("已经存在该序号！");
                    return false;
                }
            }
            return true;
        }

        private void AddPage()
        {
            var index = ConvertUtil.ConvertToLong(textEditGIndex.Text);
            var description = textEditDescription.Text;
            var doc = PIDDocManager.Instance().NewDoc(index, description);
            PIDDocManager.Instance().SetActiveDoc(doc.AlgPage.Guid);
        }

        private void ModifyPage()
        {
            var guid = PIDDoc.AlgPage.Guid;
            var index = ConvertUtil.ConvertToLong(textEditGIndex.Text);
            var description = textEditDescription.Text;
            PIDDocManager.Instance().ModifyDoc(guid, index, description);
        }
    }
}
