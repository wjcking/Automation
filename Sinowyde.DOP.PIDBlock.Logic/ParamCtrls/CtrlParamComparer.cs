using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using Sinowyde.Util;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    public partial class CtrlParamComparer : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamComparer()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.ctrlEnumComp.SelectedItem = Convert.ToInt32(Algorithm.GetParam(PIDComparer.ParamFx).Value);
            this.spinParamBD.Value = Convert.ToDecimal(Algorithm.GetParam(PIDComparer.ParamBD).Value);

            this.spinInputAI1.Value = Convert.ToDecimal(Algorithm.GetInputVar(PIDComparer.InputAI1).Value);
            this.spinInputAI2.Value = Convert.ToDecimal(Algorithm.GetInputVar(PIDComparer.InputAI2).Value);

            this.spinInputAI1.Enabled = !Block.IsLinkLeftPort(PIDComparer.InputAI1);
            this.spinInputAI2.Enabled = !Block.IsLinkLeftPort(PIDComparer.InputAI2);  

        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDComparer.ParamFx, this.ctrlEnumComp.SelectedInteger);
            Algorithm.SetParamValue(PIDComparer.ParamBD, Convert.ToDouble(this.spinParamBD.Value));

            Algorithm.SetInputSourceValue(PIDComparer.InputAI1, Convert.ToDouble(this.spinInputAI1.Value));
            Algorithm.SetInputSourceValue(PIDComparer.InputAI2, Convert.ToDouble(this.spinInputAI2.Value));

            ((FrmPIDBlockParam)this.ParentForm).NewImageName = string.Format("logic_comparer_{0}_normal", Enum.GetName(typeof(FxEnum), this.ctrlEnumComp.SelectedInteger).ToLower());
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
    }
}
