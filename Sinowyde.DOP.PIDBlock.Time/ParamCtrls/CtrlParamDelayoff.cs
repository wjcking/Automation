using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Time
{
    public partial class CtrlParamDelayoff : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamDelayoff()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinParamDELAY.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDelayoff.ParamDELAY).Value);
            this.drpInputDI.Text = Algorithm.GetInputVar(PIDDelayoff.InputDI).Value.ToString();
            //链接后不可用
            this.drpInputDI.Enabled = !Block.IsLinkLeftPort(PIDDelayoff.InputDI); 

        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDDelayoff.ParamDELAY, ConvertUtil.ConvertToDouble(this.spinParamDELAY.Value));
            Algorithm.SetInputSourceValue(PIDDelayoff.InputDI, ConvertUtil.ConvertToDouble(this.drpInputDI.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
    }
}
