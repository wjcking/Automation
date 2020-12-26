using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Linearity
{
    public partial class CtrlParamInteg : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamInteg()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinParamK.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDInteg.ParamK).Value);
            //  this.spinParamINIT.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDInteg.ParamINIT).Value);
            this.spinInputAI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDInteg.InputAI).Value);
            this.spinInputAI.Enabled = !Block.IsLinkLeftPort(PIDInteg.InputAI);
        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDInteg.ParamK, ConvertUtil.ConvertToDouble(this.spinParamK.Value));
            //    Algorithm.SetParamValue(PIDInteg.ParamINIT, ConvertUtil.ConvertToDouble(this.spinParamINIT.Value));
            Algorithm.SetInputSourceValue(PIDInteg.InputAI, ConvertUtil.ConvertToDouble(this.spinInputAI.Value));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
    }
}
