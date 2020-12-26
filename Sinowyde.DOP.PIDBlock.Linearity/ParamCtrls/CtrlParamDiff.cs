using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.Util;
using System;
namespace Sinowyde.DOP.PIDBlock.Linearity
{
    public partial class CtrlParamDiff : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamDiff()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinParamT.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDiff.ParamT).Value);
            this.spinParamK.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDiff.ParamK).Value);
            //  this.spinParamINIT.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDiff.ParamINIT).Value);
            this.spinInputAI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDDiff.InputAI).Value);

            this.spinInputAI.Enabled = !Block.IsLinkLeftPort(PIDDiff.InputAI);
        }

        public bool SaveParam()
        {
            if (this.spinParamT.Value == 0)
            {
                MessageBox.Show("T:时间常数不能为0");
                return false;
            }

            Algorithm.SetParamValue(PIDDiff.ParamT, ConvertUtil.ConvertToDouble(this.spinParamT.Value));
            Algorithm.SetParamValue(PIDDiff.ParamK, ConvertUtil.ConvertToDouble(this.spinParamK.Value));
            //   Algorithm.SetParamValue(PIDDiff.ParamINIT, ConvertUtil.ConvertToDouble(this.spinParamINIT.Value));
            Algorithm.SetInputSourceValue(PIDDiff.InputAI, ConvertUtil.ConvertToDouble(this.spinInputAI.Value));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

    }
}
