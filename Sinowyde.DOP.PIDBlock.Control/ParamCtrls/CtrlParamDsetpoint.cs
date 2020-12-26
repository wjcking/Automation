using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.Util;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.DTProxy;
namespace Sinowyde.DOP.PIDBlock.Control
{
    public partial class CtrlParamDsetpoint : XtraUserControl, ICtrlParamBase
    {

        private DsetPulseHelper dsetText = new DsetPulseHelper();

        public CtrlParamDsetpoint()
        {
            InitializeComponent();

            drpMode.Properties.Items.AddRange(dsetText.GetShowTexts());            
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.drpMode.SelectedIndex = ConvertUtil.ConvertToInt(Algorithm.GetParam(PIDDsetpoint.ParamMODE).Value);
            this.drpInputDI.Text = Algorithm.GetInputVar(PIDDsetpoint.InputDI).Value.ToString();

            //链接后不可用
            this.drpInputDI.Enabled = !Block.IsLinkLeftPort(PIDDsetpoint.InputDI);

            this.drpInputDI.Enabled = !PIDGeneralBlock.IsRunning;

            if (PIDGeneralBlock.IsRunning)
            {                
                double value = Algorithm.GetInputVar(PIDAsetpoint.InputDI).Value;
                string bindVar = Algorithm.GetBindParam(PIDAsetpoint.InputDI);
                if (!string.IsNullOrEmpty(bindVar))
                {
                    RTValue rtValue = RTValueMemCache.Instance().GetValue(BindSourceToken.GetName(this.Algorithm.Identity, PIDDsetpoint.InputDI));
                    if (null != rtValue)
                        value = rtValue.Value;
                }
                this.btnOutput.Enabled = ConvertUtil.ConvertToBool(value);
            }
        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDDsetpoint.ParamMODE, this.drpMode.SelectedIndex);
            Algorithm.SetInputSourceValue(PIDDsetpoint.InputDI, ConvertUtil.ConvertToDouble(drpInputDI.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        public string BlockName
        {
            get { return "数字给定值发生器算法块"; }
        }
        
        private void btnOutput_MouseDown(object sender, MouseEventArgs e)
        {
            var msg = new PIDCommmandMsg();
            msg.CommandType = PIDCommandType.ForceValue;
            msg.TakeEffect = true;
            msg.Guid = Algorithm.Identity;
            msg.Token = PIDDsetpoint.InputBtn;
            msg.ParamType = PIDCommandParamType.Input;
            msg.Value = 1.ToString();
            PIDBlock.PIDGeneralBlock.CommandAction(msg.ToString(), -1);
        }

        private void btnOutput_MouseUp(object sender, MouseEventArgs e)
        {
            DsetPulseStyle mode = new DsetPulseHelper().GetSelectValue(drpMode.Text);
            if (mode == DsetPulseStyle.LongSignal)
            {
                var msg = new PIDCommmandMsg();
                msg.CommandType = PIDCommandType.ForceValue;
                msg.TakeEffect = true;
                msg.Guid = Algorithm.Identity;
                msg.Token = PIDDsetpoint.InputBtn;
                msg.ParamType = PIDCommandParamType.Input;
                msg.Value = 0.ToString();
                PIDBlock.PIDGeneralBlock.CommandAction(msg.ToString(), -1);
            }
        }

        private void drpMode_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var msg = new PIDCommmandMsg();
            msg.CommandType = PIDCommandType.ForceValue;
            msg.TakeEffect = true;
            msg.Guid = Algorithm.Identity;
            msg.Token = PIDDsetpoint.ParamMODE;
            msg.ParamType = PIDCommandParamType.Param;
            msg.Value = this.drpMode.SelectedIndex.ToString();
            PIDBlock.PIDGeneralBlock.CommandAction(msg.ToString(), -1);
        }
    }
}
