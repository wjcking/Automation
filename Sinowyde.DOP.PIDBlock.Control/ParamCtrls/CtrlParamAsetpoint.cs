using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.Util;
using Sinowyde.DOP.DTProxy;
using Sinowyde.DOP.DataModel;

namespace Sinowyde.DOP.PIDBlock.Control
{
    public partial class CtrlParamAsetpoint : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamAsetpoint()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.drpInputDI.Text = Algorithm.GetInputVar(PIDAsetpoint.InputDI).Value.ToString();
            //链接后不可用
            this.drpInputDI.Enabled = !Block.IsLinkLeftPort(PIDAsetpoint.InputDI);
            
            if (PIDGeneralBlock.IsRunning)
            {
                this.spinParamMO.Enabled = false;
                double value = Algorithm.GetInputVar(PIDAsetpoint.InputDI).Value;
                string bindVar = Algorithm.GetBindParam(PIDAsetpoint.InputDI);
                if (!string.IsNullOrEmpty(bindVar))
                {
                    RTValue rtValue = RTValueMemCache.Instance().GetValue(BindSourceToken.GetName(this.Algorithm.Identity, PIDAsetpoint.InputDI));
                    if (null != rtValue)
                        value = rtValue.Value;
                }
                if (!ConvertUtil.ConvertToBool(value))
                {
                    this.btnInc.Enabled = false;
                    this.btnDec.Enabled = false;
                    this.btnOutput.Enabled = false;
                }
                else
                {
                    this.btnInc.Enabled = true;
                    this.btnDec.Enabled = true;
                    this.btnOutput.Enabled = true;
                }
            }
        }

        public bool SaveParam()
        {
            this.Algorithm.SetInputSourceValue(PIDAsetpoint.InputDI, ConvertUtil.ConvertToDouble(this.drpInputDI.Text));
            this.Algorithm.SetOutputSourceValue(PIDAsetpoint.ResultAO, (double)this.spinParamMO.Value);
            this.Algorithm.SetInputSourceValue(PIDAsetpoint.InputBIAS, (double)this.spinParamMO.Value);
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        public string BlockName
        {
            get { return "模拟给定值发生器算法块"; }
        }

        private void btnOutput_Click(object sender, System.EventArgs e)
        {
            var msg = new PIDCommmandMsg();
            msg.CommandType = PIDCommandType.ForceValue;
            msg.TakeEffect = true;
            msg.Guid = Algorithm.Identity;
            msg.Token = PIDAsetpoint.InputBIAS;
            msg.ParamType = PIDCommandParamType.Input;           

            SimpleButton b = sender as SimpleButton;           
            switch (b.Name)
            {
                case "btnDec":
                    msg.Value = (-1*spinDec.Value).ToString();
                    msg.IsBias = true;
                    break;
                case "btnInc":
                    msg.Value = (spinInc.Value).ToString();
                    msg.IsBias = true;
                    break;
                case "btnOutput":
                    msg.Value = (spinOutput.Value).ToString();
                    msg.IsBias = false;
                    break;
            }

            PIDBlock.PIDGeneralBlock.CommandAction(msg.ToString(), -1);
        }
    }
}
