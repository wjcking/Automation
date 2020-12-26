using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using Sinowyde.Util;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    public partial class CtrlParamDTrigger : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamDTrigger()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.ctrlEnumGroup1.SelectedInteger = ConvertUtil.ConvertToInt( Algorithm.GetParam(PIDDTrigger.ParamSense).Value);
     
            this.drpInputSD.Text = Algorithm.GetInputVar(PIDDTrigger.InputSD).Value.ToString();
            this.drpInputRD.Text = Algorithm.GetInputVar(PIDDTrigger.InputRD).Value.ToString();
            this.drpInputCp.Text = Algorithm.GetInputVar(PIDDTrigger.InputCP).Value.ToString();
            this.drpInputD.Text = Algorithm.GetInputVar(PIDDTrigger.InputD).Value.ToString();

            this.drpInputSD.Enabled = !Block.IsLinkLeftPort(PIDDTrigger.InputSD); 
            this.drpInputRD.Enabled = !Block.IsLinkLeftPort(PIDDTrigger.InputRD); 
            this.drpInputCp.Enabled = !Block.IsLinkLeftPort(PIDDTrigger.InputCP); 
            this.drpInputD.Enabled = !Block.IsLinkLeftPort(PIDDTrigger.InputD); 
      
        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDDTrigger.ParamSense, this.ctrlEnumGroup1.SelectedInteger);
            Algorithm.SetInputSourceValue(PIDDTrigger.InputSD, ConvertUtil.ConvertToInt(this.drpInputSD.Text));
            Algorithm.SetInputSourceValue(PIDDTrigger.InputRD, ConvertUtil.ConvertToInt(this.drpInputRD.Text));
            Algorithm.SetInputSourceValue(PIDDTrigger.InputCP, ConvertUtil.ConvertToInt(this.drpInputCp.Text));
            Algorithm.SetInputSourceValue(PIDDTrigger.InputD, ConvertUtil.ConvertToInt(this.drpInputD.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
 
    }
}
