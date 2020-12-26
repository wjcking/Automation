using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDBlock.Control
{
    public partial class CtrlParamLeadleg : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamLeadleg()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinParamT1.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLeadleg.ParamT1).Value);
            this.spinParamT2.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLeadleg.ParamT2).Value);
            this.spinInputPV.Value = (decimal)Algorithm.GetInputVar(PIDLeadleg.InputPV).Value;
            //链接后不可用
            this.spinInputPV.Enabled = !Block.IsLinkLeftPort(PIDLeadleg.InputPV);
        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDLeadleg.ParamT1, ConvertUtil.ConvertToDouble(this.spinParamT1.Value));
            Algorithm.SetParamValue(PIDLeadleg.ParamT2, ConvertUtil.ConvertToDouble(this.spinParamT2.Value));
            Algorithm.SetInputSourceValue(PIDLeadleg.InputPV, ConvertUtil.ConvertToDouble(this.spinInputPV.Value));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

    }
}
