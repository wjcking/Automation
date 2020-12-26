using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Control
{
    public partial class CtrlParamStepcontrol : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamStepcontrol()
        {
            InitializeComponent();
        }

        public PIDBindAlgorithm Algorithm { get; set; }

        public void LoadParam()
        {
            this.spinParamMAXS.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStepcontrol.ParamMAXS).Value);
            this.spinParamSetTime1.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStepcontrol.ParamSetTime1).Value);
            this.spinParamSetTime2.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStepcontrol.ParamSetTime2).Value);
            this.spinParamSetTime3.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStepcontrol.ParamSetTime3).Value);
            this.spinParamSetTime4.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStepcontrol.ParamSetTime4).Value);
            this.spinParamSetTime5.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStepcontrol.ParamSetTime5).Value);
            this.spinParamSetTime6.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStepcontrol.ParamSetTime6).Value);
            this.spinParamSetTime7.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStepcontrol.ParamSetTime7).Value);
            this.spinParamSetTime8.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStepcontrol.ParamSetTime8).Value);
            this.spinParamTlimit1.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStepcontrol.ParamTlimit1).Value);
            this.spinParamTlimit2.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStepcontrol.ParamTlimit2).Value);
            this.spinParamTlimit3.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStepcontrol.ParamTlimit3).Value);
            this.spinParamTlimit4.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStepcontrol.ParamTlimit4).Value);
            this.spinParamTlimit5.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStepcontrol.ParamTlimit5).Value);
            this.spinParamTlimit6.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStepcontrol.ParamTlimit6).Value);
            this.spinParamTlimit7.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStepcontrol.ParamTlimit7).Value);
            this.spinParamTlimit8.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDStepcontrol.ParamTlimit8).Value);
            this.drpInputTmode.Text = Algorithm.GetParam(PIDStepcontrol.InputTmode).Value.ToString();
            this.drpInputBitDis.Text = Algorithm.GetParam(PIDStepcontrol.InputBitDis).Value.ToString();
            this.drpInputStart.Text = Algorithm.GetParam(PIDStepcontrol.InputStart).Value.ToString();
            this.drpInputStop.Text = Algorithm.GetParam(PIDStepcontrol.InputStop).Value.ToString();
            this.drpInputDelay.Text = Algorithm.GetParam(PIDStepcontrol.InputDelay).Value.ToString();
            this.drpInputFB1.Text = Algorithm.GetParam(PIDStepcontrol.InputFB1).Value.ToString();
            this.drpInputFB2.Text = Algorithm.GetParam(PIDStepcontrol.InputFB2).Value.ToString();
            this.drpInputFB3.Text = Algorithm.GetParam(PIDStepcontrol.InputFB3).Value.ToString();
            this.drpInputFB4.Text = Algorithm.GetParam(PIDStepcontrol.InputFB4).Value.ToString();
            this.drpInputFB5.Text = Algorithm.GetParam(PIDStepcontrol.InputFB5).Value.ToString();
            this.drpInputFB6.Text = Algorithm.GetParam(PIDStepcontrol.InputFB6).Value.ToString();
            this.drpInputFB7.Text = Algorithm.GetParam(PIDStepcontrol.InputFB7).Value.ToString();
            this.drpInputFB8.Text = Algorithm.GetParam(PIDStepcontrol.InputFB8).Value.ToString();
            this.drpInputRst.Text = Algorithm.GetParam(PIDStepcontrol.InputRst).Value.ToString();
            this.drpInputDStep.Text = Algorithm.GetParam(PIDStepcontrol.InputDStep).Value.ToString();
            this.drpInputJStep.Text = Algorithm.GetParam(PIDStepcontrol.InputJStep).Value.ToString();
            //链接后不可用
            this.drpInputTmode.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDStepcontrol.InputTmode)) ? true : false;
            this.drpInputBitDis.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDStepcontrol.InputBitDis)) ? true : false;
            this.drpInputStart.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDStepcontrol.InputStart)) ? true : false;
            this.drpInputStop.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDStepcontrol.InputStop)) ? true : false;
            this.drpInputDelay.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDStepcontrol.InputDelay)) ? true : false;
            this.drpInputFB1.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDStepcontrol.InputFB1)) ? true : false;
            this.drpInputFB2.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDStepcontrol.InputFB2)) ? true : false;
            this.drpInputFB3.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDStepcontrol.InputFB3)) ? true : false;
            this.drpInputFB4.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDStepcontrol.InputFB4)) ? true : false;
            this.drpInputFB5.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDStepcontrol.InputFB5)) ? true : false;
            this.drpInputFB6.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDStepcontrol.InputFB6)) ? true : false;
            this.drpInputFB7.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDStepcontrol.InputFB7)) ? true : false;
            this.drpInputFB8.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDStepcontrol.InputFB8)) ? true : false;
            this.drpInputRst.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDStepcontrol.InputRst)) ? true : false;
            this.drpInputDStep.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDStepcontrol.InputDStep)) ? true : false;
            this.drpInputJStep.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDStepcontrol.InputJStep)) ? true : false;

        }

        public void SaveParam()
        {
            Algorithm.SetParam(PIDStepcontrol.ParamMAXS, ConvertUtil.ConvertToDouble(this.spinParamMAXS.Value));
            Algorithm.SetParam(PIDStepcontrol.ParamSetTime1, ConvertUtil.ConvertToDouble(this.spinParamSetTime1.Value));
            Algorithm.SetParam(PIDStepcontrol.ParamSetTime2, ConvertUtil.ConvertToDouble(this.spinParamSetTime2.Value));
            Algorithm.SetParam(PIDStepcontrol.ParamSetTime3, ConvertUtil.ConvertToDouble(this.spinParamSetTime3.Value));
            Algorithm.SetParam(PIDStepcontrol.ParamSetTime4, ConvertUtil.ConvertToDouble(this.spinParamSetTime4.Value));
            Algorithm.SetParam(PIDStepcontrol.ParamSetTime5, ConvertUtil.ConvertToDouble(this.spinParamSetTime5.Value));
            Algorithm.SetParam(PIDStepcontrol.ParamSetTime6, ConvertUtil.ConvertToDouble(this.spinParamSetTime6.Value));
            Algorithm.SetParam(PIDStepcontrol.ParamSetTime7, ConvertUtil.ConvertToDouble(this.spinParamSetTime7.Value));
            Algorithm.SetParam(PIDStepcontrol.ParamSetTime8, ConvertUtil.ConvertToDouble(this.spinParamSetTime8.Value));
            Algorithm.SetParam(PIDStepcontrol.ParamTlimit1, ConvertUtil.ConvertToDouble(this.spinParamTlimit1.Value));
            Algorithm.SetParam(PIDStepcontrol.ParamTlimit2, ConvertUtil.ConvertToDouble(this.spinParamTlimit2.Value));
            Algorithm.SetParam(PIDStepcontrol.ParamTlimit3, ConvertUtil.ConvertToDouble(this.spinParamTlimit3.Value));
            Algorithm.SetParam(PIDStepcontrol.ParamTlimit4, ConvertUtil.ConvertToDouble(this.spinParamTlimit4.Value));
            Algorithm.SetParam(PIDStepcontrol.ParamTlimit5, ConvertUtil.ConvertToDouble(this.spinParamTlimit5.Value));
            Algorithm.SetParam(PIDStepcontrol.ParamTlimit6, ConvertUtil.ConvertToDouble(this.spinParamTlimit6.Value));
            Algorithm.SetParam(PIDStepcontrol.ParamTlimit7, ConvertUtil.ConvertToDouble(this.spinParamTlimit7.Value));
            Algorithm.SetParam(PIDStepcontrol.ParamTlimit8, ConvertUtil.ConvertToDouble(this.spinParamTlimit8.Value));
            Algorithm.SetParam(PIDStepcontrol.InputTmode, ConvertUtil.ConvertToDouble(this.drpInputTmode.Text));
            Algorithm.SetParam(PIDStepcontrol.InputBitDis, ConvertUtil.ConvertToDouble(this.drpInputBitDis.Text));
            Algorithm.SetParam(PIDStepcontrol.InputStart, ConvertUtil.ConvertToDouble(this.drpInputStart.Text));
            Algorithm.SetParam(PIDStepcontrol.InputStop, ConvertUtil.ConvertToDouble(this.drpInputStop.Text));
            Algorithm.SetParam(PIDStepcontrol.InputDelay, ConvertUtil.ConvertToDouble(this.drpInputDelay.Text));
            Algorithm.SetParam(PIDStepcontrol.InputFB1, ConvertUtil.ConvertToDouble(this.drpInputFB1.Text));
            Algorithm.SetParam(PIDStepcontrol.InputFB2, ConvertUtil.ConvertToDouble(this.drpInputFB2.Text));
            Algorithm.SetParam(PIDStepcontrol.InputFB3, ConvertUtil.ConvertToDouble(this.drpInputFB3.Text));
            Algorithm.SetParam(PIDStepcontrol.InputFB4, ConvertUtil.ConvertToDouble(this.drpInputFB4.Text));
            Algorithm.SetParam(PIDStepcontrol.InputFB5, ConvertUtil.ConvertToDouble(this.drpInputFB5.Text));
            Algorithm.SetParam(PIDStepcontrol.InputFB6, ConvertUtil.ConvertToDouble(this.drpInputFB6.Text));
            Algorithm.SetParam(PIDStepcontrol.InputFB7, ConvertUtil.ConvertToDouble(this.drpInputFB7.Text));
            Algorithm.SetParam(PIDStepcontrol.InputFB8, ConvertUtil.ConvertToDouble(this.drpInputFB8.Text));
            Algorithm.SetParam(PIDStepcontrol.InputRst, ConvertUtil.ConvertToDouble(this.drpInputRst.Text));
            Algorithm.SetParam(PIDStepcontrol.InputDStep, ConvertUtil.ConvertToDouble(this.drpInputDStep.Text));
            Algorithm.SetParam(PIDStepcontrol.InputJStep, ConvertUtil.ConvertToDouble(this.drpInputJStep.Text));

        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        public string BlockName
        {
            get { return "步序控制算法块"; }
        }
    }
}
