using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Time
{
    public partial class CtrlParamTotal : XtraUserControl, ICtrlParamBase
    {
        private TotalModeText totalModeText = new TotalModeText();
        public CtrlParamTotal()
        {
            InitializeComponent();
            drpMode.Properties.Items.Clear();
            drpMode.Properties.Items.AddRange(totalModeText.GetShowTexts());
            drpMode.SelectedIndex = 0;
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinK.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDTotal.ParamK).Value);
            this.spinInit.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDTotal.ParamInit).Value);

            this.spinInputAI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDTotal.InputAI).Value);
            this.drpInputSet.Text = Algorithm.GetInputVar(PIDTotal.InputSET).Value.ToString();
            drpMode.SelectedIndex = ConvertUtil.ConvertToInt(Algorithm.GetParam(PIDTotal.ParamMODE).Value);

            //链接后不可用
            this.spinInputAI.Enabled = !Block.IsLinkLeftPort(PIDTotal.InputAI);  
            this.drpInputSet.Enabled = !Block.IsLinkLeftPort(PIDTotal.InputSET); 
        }

        public bool SaveParam()
        {
            if (spinK.Value == 0)
            {
                MessageBox.Show("转换系数不能为0");
                return false;
            }

            Algorithm.SetParamValue(PIDTotal.ParamK, (double)spinK.Value);
            Algorithm.SetParamValue(PIDTotal.ParamInit, (double)spinInit.Value);
            Algorithm.SetParamValue(PIDTotal.ParamMODE, ConvertUtil.ConvertToInt(totalModeText.GetSelectValue(drpMode.Text)));

            Algorithm.SetInputSourceValue(PIDTotal.InputAI, ConvertUtil.ConvertToDouble(this.spinInputAI.Value));
            Algorithm.SetInputSourceValue(PIDTotal.InputSET, ConvertUtil.ConvertToDouble(this.drpInputSet.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
 
    }
}
