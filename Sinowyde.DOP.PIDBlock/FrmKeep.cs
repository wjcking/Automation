using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;

namespace Sinowyde.DOP.PIDBlock
{
    public partial class FrmKeep : XtraForm
    {
        public string CommmandMsgStr = string.Empty;
        private PIDGeneralBlock block;
        private bool isKeep = true;

        public FrmKeep(PIDGeneralBlock block, bool isKeep = true)
        {
            InitializeComponent();
            this.block = block;
            this.isKeep = isKeep;
        }

        private void InitUi()
        {
            if (isKeep)
            {
                this.Text = "保持输出";
                this.labelControl.Text = "选择保持输出端:";
            }
            else
            {
                this.Text = "取消保持输出";
                this.labelControl.Text = "选择取消保持输出端:";
            }

            lookUpEditVar.Properties.NullText = "请选择变量";
        }

        private void FrmKeep_Load(object sender, EventArgs e)
        {
            InitUi();

            if (null != block && null != block.Algorithm)
            {
                var list = block.Algorithm.GetAllOutput();
                lookUpEditVar.Properties.DisplayMember = "Name";
                //lookUpEditVar.Properties.ValueMember = "VarType";
                lookUpEditVar.Properties.DataSource = list;
                lookUpEditVar.ItemIndex = 0;
            }
        }

        private bool CheckParams()
        {
            if (null == lookUpEditVar.EditValue)
            {
                XtraMessageBox.Show("请选择变量！");
                return false;
            }
            return true;
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            if (CheckParams())
            {
                var msg = new PIDCommmandMsg();
                msg.CommandType = PIDCommandType.KeepValue;
                msg.TakeEffect = isKeep;//保持 取消保持
                msg.Guid = block.Algorithm.Identity;
                msg.Token = lookUpEditVar.Text;
                msg.ParamType = PIDCommandParamType.Output;

                CommmandMsgStr = msg.ToString();

                for (int i = 0; i < block.RightPortsCount; i++)
                {
                    var port = block.GetRightPort(i);
                    if (msg.Token.EndsWith(port.Name))
                        port.BrushColor = isKeep ? StateColor.Keep : StateColor.Normal;
                }


                this.DialogResult = DialogResult.OK;
            }
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
