using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using Sinowyde.Util;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    public partial class CtrlParamRSTrigger : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamRSTrigger()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.drpInputRd.Text = Algorithm.GetInputVar(PIDRSTrigger.InputRd).Value.ToString();
            this.drpInputSd.Text = Algorithm.GetInputVar(PIDRSTrigger.InputSd).Value.ToString();

            this.drpInputRd.Enabled = !Block.IsLinkLeftPort(PIDRSTrigger.InputRd);  
            this.drpInputSd.Enabled = !Block.IsLinkLeftPort(PIDRSTrigger.InputSd);  
        }

        public bool SaveParam()
        {
            Algorithm.SetInputSourceValue(PIDRSTrigger.InputRd, ConvertUtil.ConvertToInt(this.drpInputRd.Text));
            Algorithm.SetInputSourceValue(PIDRSTrigger.InputSd, ConvertUtil.ConvertToInt(this.drpInputSd.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
 
    }
}
