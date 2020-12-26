using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Control
{
    public partial class CtrlParam3si : XtraUserControl, ICtrlParamBase
    {
        public CtrlParam3si()
        {
            InitializeComponent();
        }

        public PIDBindAlgorithm Algorithm { get; set; }

        public void LoadParam()
        {
            this.spinParamMode.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID3si.ParamMode).Value);
            this.spinParamOutMode.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID3si.ParamOutMode).Value);
            this.spinParamRange.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID3si.ParamRange).Value);
            this.spinParamDead.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID3si.ParamDead).Value);
            this.spinParamSaftV.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID3si.ParamSaftV).Value);
            this.drpInputPV1.Text = Algorithm.GetParam(PID3si.InputPV1).Value.ToString();
            this.drpInputPV2.Text = Algorithm.GetParam(PID3si.InputPV2).Value.ToString();
            this.drpInputPV3.Text = Algorithm.GetParam(PID3si.InputPV3).Value.ToString();
            //链接后不可用
            this.drpInputPV1.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID3si.InputPV1)) ? true : false;
            this.drpInputPV2.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID3si.InputPV2)) ? true : false;
            this.drpInputPV3.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID3si.InputPV3)) ? true : false;

        }

        public void SaveParam()
        {
            Algorithm.SetParam(PID3si.ParamMode, ConvertUtil.ConvertToDouble(this.spinParamMode.Value));
            Algorithm.SetParam(PID3si.ParamOutMode, ConvertUtil.ConvertToDouble(this.spinParamOutMode.Value));
            Algorithm.SetParam(PID3si.ParamRange, ConvertUtil.ConvertToDouble(this.spinParamRange.Value));
            Algorithm.SetParam(PID3si.ParamDead, ConvertUtil.ConvertToDouble(this.spinParamDead.Value));
            Algorithm.SetParam(PID3si.ParamSaftV, ConvertUtil.ConvertToDouble(this.spinParamSaftV.Value));
            Algorithm.SetParam(PID3si.InputPV1, ConvertUtil.ConvertToDouble(this.drpInputPV1.Text));
            Algorithm.SetParam(PID3si.InputPV2, ConvertUtil.ConvertToDouble(this.drpInputPV2.Text));
            Algorithm.SetParam(PID3si.InputPV3, ConvertUtil.ConvertToDouble(this.drpInputPV3.Text));

        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        public string BlockName
        {
            get { return "5.14三变送器整合算法块"; }
        }
    }
}
