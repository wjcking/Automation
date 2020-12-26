using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Logic;
using Sinowyde.Util;
using System;

namespace Sinowyde.DOP.PIDBlock.Logic
{
    public partial class CtrlParamAlarm : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamAlarm()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinParamHL.Value = Convert.ToDecimal(Algorithm.GetParam(PIDAlarm.ParamHL).Value);
            this.spinParamLL.Value = Convert.ToDecimal(Algorithm.GetParam(PIDAlarm.ParamLL).Value);
            this.spinParamBD.Value = Convert.ToDecimal(Algorithm.GetParam(PIDAlarm.ParamBD).Value);

            this.spinInputAI1.Value = Convert.ToDecimal(Algorithm.GetInputVar(PIDAlarm.InputAI1).Value);
            this.spinInputAI2.Value = Convert.ToDecimal(Algorithm.GetInputVar(PIDAlarm.InputAI2).Value);

            this.spinInputAI1.Enabled = !Block.IsLinkLeftPort(PIDAlarm.InputAI1);  
            this.spinInputAI2.Enabled = !Block.IsLinkLeftPort(PIDAlarm.InputAI2);  
        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDAlarm.ParamHL, Convert.ToDouble(this.spinParamHL.Value));
            Algorithm.SetParamValue(PIDAlarm.ParamLL, Convert.ToDouble(this.spinParamLL.Value));
            Algorithm.SetParamValue(PIDAlarm.ParamBD, Convert.ToDouble(this.spinParamBD.Value));

            Algorithm.SetInputSourceValue(PIDAlarm.InputAI1, Convert.ToDouble(this.spinInputAI1.Value));
            Algorithm.SetInputSourceValue(PIDAlarm.InputAI2, Convert.ToDouble(this.spinInputAI2.Value));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
    }
}
