using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Time
{
    public partial class CtrlParamT : XtraUserControl, ICtrlParamBase
    {
        private TModeText tmodeTexts = new TModeText();

        public CtrlParamT()
        {
            InitializeComponent();
        }

        public PIDBindAlgorithm Algorithm { get; set; }

        public void LoadParam()
        {
            this.spinParamEndTime.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDT.ParamEndTime).Value);
            //this.spinParamMODE.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDT.ParamMODE).Value);
            
            drpMode.Properties.Items.AddRange(tmodeTexts.GetShowTexts());
            drpMode.SelectedIndex = ConvertUtil.ConvertToInt(Algorithm.GetParam(PIDT.ParamMODE).Value);
            this.drpInputSet.Text =  Algorithm.GetParam(PIDT.InputSET).Value.ToString();
            this.drpInputRS.Text = Algorithm.GetParam(PIDT.InputRS).Value.ToString();  
            //链接后不可用

        }

        public void SaveParam()
        {
            Algorithm.SetParam(PIDT.ParamEndTime, ConvertUtil.ConvertToDouble(this.spinParamEndTime.Value));
            Algorithm.SetParam(PIDT.ParamMODE, ConvertUtil.ConvertToInt(tmodeTexts.GetSelectValue(drpMode.Text)));
            Algorithm.SetParam(PIDT.InputSET, ConvertUtil.ConvertToDouble(this.drpInputSet.Text));
            Algorithm.SetParam(PIDT.InputRS, ConvertUtil.ConvertToDouble(this.drpInputRS.Text));

        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        public string BlockName
        {
            get { return "定时器算法块"; }
        }
    }
}
