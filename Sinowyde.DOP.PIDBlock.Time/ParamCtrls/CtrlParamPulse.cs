using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Time
{
    public partial class CtrlParamPulse : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamPulse()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinParamDELAY.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPulse.ParamDELAY).Value);
            this.drpInputDI.Text = Algorithm.GetInputVar(PIDPulse.InputDI).Value.ToString();
            //链接后不可用
            this.drpInputDI.Enabled = !Block.IsLinkLeftPort(PIDPulse.InputDI); 

        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDPulse.ParamDELAY, ConvertUtil.ConvertToDouble(this.spinParamDELAY.Value));
            Algorithm.SetInputSourceValue(PIDPulse.InputDI, ConvertUtil.ConvertToDouble(this.drpInputDI.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
 
    }
}
