using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using Sinowyde.Util;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    public partial class CtrlParamFirst : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamFirst()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinParamNum.Value = Convert.ToDecimal(Algorithm.GetParam(PIDFirst.ParamNum).Value);

            string id = "";
            for (int i = 0; i < 8; i++)
            {
                id = (i + 1).ToString();
                var c = (ComboBoxEdit)this.groupPid.Controls["drpInputDI" + id];

                c.Text = Algorithm.GetInputVar(PIDFirst.PrefixDI + id).Value.ToString();
                //连线可用否？
                c.Enabled = !Block.IsLinkLeftPort(PIDFirst.PrefixDI + id);
            }

            drpInputRst.Enabled = !Block.IsLinkLeftPort(PIDFirst.InputRst);
        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDFirst.ParamNum, Convert.ToDouble(this.spinParamNum.Value));

            Algorithm.SetInputSourceValue(PIDFirst.InputRst, ConvertUtil.ConvertToDouble(this.drpInputRst.Text));

            string id = "";
            for (int i = 0; i < 8; i++)
            {
                id = (i + 1).ToString();
                var c = (ComboBoxEdit)this.groupPid.Controls["drpInputDI" + (i + 1).ToString()];
                Algorithm.SetInputSourceValue(PIDFirst.PrefixDI + id, ConvertUtil.ConvertToDouble(c.EditValue));
            }
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

    }
}
