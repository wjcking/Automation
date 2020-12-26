using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Time
{
    public partial class CtrlParamTex : XtraUserControl, ICtrlParamBase
    {
        private TModeText tmodeTexts = new TModeText();

        public CtrlParamTex()
        {
            InitializeComponent();
        }

        public PIDBindAlgorithm Algorithm { get; set; }

        public void LoadParam()
        {
            this.drpInputSet.Text = Algorithm.GetParam(PIDTex.InputSET).Value.ToString();
            this.drpInputRS.Text = Algorithm.GetParam(PIDTex.InputRS).Value.ToString();
            this.spinInputPV.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDTex.InputPV).Value);
            this.spinParamEndTime.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDTex.ParamEndTime).Value);
            drpMode.Properties.Items.AddRange(tmodeTexts.GetShowTexts());
            drpMode.SelectedIndex = ConvertUtil.ConvertToInt(Algorithm.GetParam(PIDT.ParamMODE).Value);

            //链接后不可用
            this.drpInputSet.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDTex.InputSET)) ? true : false;
            this.drpInputRS.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDTex.InputRS)) ? true : false;
            this.spinInputPV.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDTex.InputPV)) ? true : false;
        }

        public void SaveParam()
        {
            Algorithm.SetParam(PIDTex.InputSET, ConvertUtil.ConvertToDouble(this.drpInputSet.Text));
            Algorithm.SetParam(PIDTex.InputRS, ConvertUtil.ConvertToDouble(this.drpInputRS.Text));
            Algorithm.SetParam(PIDTex.InputPV, ConvertUtil.ConvertToDouble(this.spinInputPV.Value));
            Algorithm.SetParam(PIDTex.ParamEndTime,  ConvertUtil.ConvertToDouble(this.spinParamEndTime.Value));
            Algorithm.SetParam(PIDT.ParamMODE, ConvertUtil.ConvertToInt(tmodeTexts.GetSelectValue(drpMode.Text)));
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
    
        public string BlockName
        {
            get { return "定时器优化算法块"; }
        }
    }
}
