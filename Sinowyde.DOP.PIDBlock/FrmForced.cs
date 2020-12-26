using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Northwoods.Go;
using Sinowyde.DOP.PIDAlgorithm;
using System;
using System.Windows.Forms;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDBlock
{
    public partial class FrmForced : XtraForm
    {
        public string CommmandMsgStr = string.Empty;
        //private PIDBindAlgorithm algorithm;
        private PIDGeneralBlock block;
        private bool isForced = true;

        public FrmForced(PIDGeneralBlock block, bool isForced = true)
        {
            InitializeComponent();
            this.block = block;
            this.isForced = isForced;
        }

        private void InitUi()
        {
            if (isForced)
            {
                this.Text = "强制输出";
                this.labelControl.Text = "选择强制输出端:";
                this.Size = new Size(300, 160);
                this.MinimumSize = new Size(300, 160);
                this.MaximumSize = new Size(300, 160);
            }
            else
            {
                this.Text = "取消强制输出";
                this.labelControl.Text = "选择取消强制输出端:";
                this.labelControlSet.Visible = false;
                this.spinEditValue.Visible = false;
                this.comboBoxEditValue.Visible = false;
                this.Size = new Size(300, 120);
                this.MinimumSize = new Size(300, 120);
                this.MaximumSize = new Size(300, 120);
            }
            lookUpEditVar.Properties.NullText = "请选择变量";
            comboBoxEditValue.Properties.Items.AddRange(new object[] { 0, 1 });
            comboBoxEditValue.Properties.NullText = "请设置强制值";
            comboBoxEditValue.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            comboBoxEditValue.SelectedIndex = 0;
        }

        private void FrmForced_Load(object sender, EventArgs e)
        {
            InitUi();
            this.lookUpEditVar.EditValueChanged += lookUpEditVar_EditValueChanged;
            if (null != block && null != block.Algorithm)
            {
                var list = block.Algorithm.GetAllOutput();
                //lookUpEditVar.Properties.ValueMember = "VarType"; //重复会有bug
                lookUpEditVar.Properties.DisplayMember = "Name";
                lookUpEditVar.Properties.DataSource = list;
                lookUpEditVar.ItemIndex = 0;
            }
        }

        private void lookUpEditVar_EditValueChanged(object sender, EventArgs e)
        {
            if (isForced)
            {
                var varDataType = ((PIDAlgorithmVar)lookUpEditVar.EditValue).VarType;
                spinEditValue.Visible = varDataType == PIDVarDataType.AM;
                comboBoxEditValue.Visible = varDataType == PIDVarDataType.DM;
            }
        }

        private bool CheckParams()
        {
            if (null == lookUpEditVar.EditValue)
            {
                XtraMessageBox.Show("请选择变量！");
                return false;
            }
            if (isForced)
            {
                if (((PIDAlgorithmVar)lookUpEditVar.EditValue).VarType == PIDVarDataType.DM)
                {
                    if (null == comboBoxEditValue.EditValue)
                    {
                        XtraMessageBox.Show("请输入强制值！");
                        return false;
                    }
                }
            }
            return true;
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            if (CheckParams())
            {
                PIDVarDataType varDataType = ((PIDAlgorithmVar)lookUpEditVar.EditValue).VarType;

                var msg = new PIDCommmandMsg();
                msg.CommandType = PIDCommandType.ForceValue;
                msg.TakeEffect = isForced;
                msg.Guid = block.Algorithm.Identity;
                msg.Token = lookUpEditVar.Text;
                msg.ParamType = PIDCommandParamType.Output;
                if (isForced)
                    msg.Value = varDataType == PIDVarDataType.AM ? ConvertUtil.ConvertToString(spinEditValue.Value) : ConvertUtil.ConvertToString(comboBoxEditValue.EditValue);

                CommmandMsgStr = msg.ToString();


                for (int i = 0; i < block.RightPortsCount; i++)
                {
                    var port = block.GetRightPort(i);
                    if (msg.Token.EndsWith(port.Name))
                        port.BrushColor = isForced ? StateColor.Force : StateColor.Normal;
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
