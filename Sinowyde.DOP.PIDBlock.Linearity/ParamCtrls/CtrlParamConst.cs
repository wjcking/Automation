using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.Util;
using System;
namespace Sinowyde.DOP.PIDBlock.Linearity
{
    public partial class CtrlParamConst : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamConst()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinParamK.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDConst.ParamK).Value);
            this.spinInputAI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDConst.InputAI).Value);
            //
            this.spinInputAI.Enabled = !Block.IsLinkLeftPort(PIDConst.InputAI);
        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDConst.ParamK, ConvertUtil.ConvertToDouble(this.spinParamK.Value));
            Algorithm.SetInputSourceValue(PIDConst.InputAI, ConvertUtil.ConvertToDouble(this.spinInputAI.Value));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
    }
}
