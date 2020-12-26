using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Linearity
{
    public partial class CtrlParamDalay : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamDalay()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinParamT.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDalay.ParamT).Value);
            //   this.spinParamINIT.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDalay.ParamINIT).Value);
            this.spinInputAI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDDalay.InputAI).Value);

            this.spinInputAI.Enabled = !Block.IsLinkLeftPort(PIDDalay.InputAI);
        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDDalay.ParamT, ConvertUtil.ConvertToDouble(this.spinParamT.Value));
            //    Algorithm.SetParamValue(PIDDalay.ParamINIT, ConvertUtil.ConvertToDouble(this.spinParamINIT.Value));
            Algorithm.SetInputSourceValue(PIDDalay.InputAI, ConvertUtil.ConvertToDouble(this.spinInputAI.Value));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
    }
}
