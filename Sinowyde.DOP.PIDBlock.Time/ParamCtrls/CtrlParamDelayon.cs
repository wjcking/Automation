using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Time
{
    public partial class CtrlParamDelayon : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamDelayon()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinParamDELAY.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDelayon.ParamDELAY).Value);
            this.drpInputDI.Text = Algorithm.GetInputVar(PIDDelayon.InputDI).Value.ToString();
            //链接后不可用
            this.drpInputDI.Enabled = !Block.IsLinkLeftPort(PIDDelayon.InputDI);

        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDDelayon.ParamDELAY, ConvertUtil.ConvertToDouble(this.spinParamDELAY.Value));
            Algorithm.SetInputSourceValue(PIDDelayon.InputDI, ConvertUtil.ConvertToDouble(this.drpInputDI.Text));
            return true;
        }
        //    this.spinParamSAO.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDelayon.ParamSAO).Value);


        public UserControl GetParamCtrl()
        {
            return this;
        }

    }
}
