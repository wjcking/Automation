using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Control
{
    public partial class CtrlParam2si : XtraUserControl, ICtrlParamBase
    {
        public CtrlParam2si()
        {
            InitializeComponent();
        }

        public PIDBindAlgorithm Algorithm { get; set; }

        public void LoadParam()
        {
            this.spinParamMode.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID2si.ParamMode).Value);
            this.spinParamOutMode.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID2si.ParamOutMode).Value);
            this.spinParamRange.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID2si.ParamRange).Value);
            this.spinParamDead.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID2si.ParamDead).Value);
            this.spinParamSaftV.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID2si.ParamSaftV).Value);
            this.drpInputPV1.Text = Algorithm.GetParam(PID2si.InputPV1).Value.ToString();
            this.drpInputPV2.Text = Algorithm.GetParam(PID2si.InputPV2).Value.ToString();
            //链接后不可用
            this.drpInputPV1.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID2si.InputPV1)) ? true : false;
            this.drpInputPV2.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID2si.InputPV2)) ? true : false;

        }

        public void SaveParam()
        {
            Algorithm.SetParam(PID2si.ParamMode, ConvertUtil.ConvertToDouble(this.spinParamMode.Value));
            Algorithm.SetParam(PID2si.ParamOutMode, ConvertUtil.ConvertToDouble(this.spinParamOutMode.Value));
            Algorithm.SetParam(PID2si.ParamRange, ConvertUtil.ConvertToDouble(this.spinParamRange.Value));
            Algorithm.SetParam(PID2si.ParamDead, ConvertUtil.ConvertToDouble(this.spinParamDead.Value));
            Algorithm.SetParam(PID2si.ParamSaftV, ConvertUtil.ConvertToDouble(this.spinParamSaftV.Value));
            Algorithm.SetParam(PID2si.InputPV1, ConvertUtil.ConvertToDouble(this.drpInputPV1.Text));
            Algorithm.SetParam(PID2si.InputPV2, ConvertUtil.ConvertToDouble(this.drpInputPV2.Text));

        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        public string BlockName
        {
            get { return "5.13两变送器整合算法块"; }
        }
    }
}
