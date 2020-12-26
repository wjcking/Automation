using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    public partial class CtrlParamNot : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamNot()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.drpInputDI.Text = Algorithm.GetInputVar(PIDNot.InputDI).Value.ToString();

            this.drpInputDI.Enabled = !Block.IsLinkLeftPort(PIDNot.InputDI); 
        }

        public bool SaveParam()
        {
            Algorithm.SetInputSourceValue(PIDNot.InputDI, ConvertUtil.ConvertToInt(this.drpInputDI.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
 
    }
}
