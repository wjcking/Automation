using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using Sinowyde.Util;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    public partial class CtrlParamSign : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamSign()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }


        public void LoadParam()
        {
            this.spinInputAI.Value = Convert.ToDecimal(Algorithm.GetInputVar(PIDSign.InputAI).Value);

            this.spinInputAI.Enabled = !Block.IsLinkLeftPort(PIDSign.InputAI); 

        }

        public bool SaveParam()
        {
            Algorithm.SetInputSourceValue(PIDSign.InputAI, Convert.ToDouble(this.spinInputAI.Value));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
 
    }
}
