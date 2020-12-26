using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.Util;
using System;
namespace Sinowyde.DOP.PIDBlock.Signal
{
    public partial class CtrlParamSinsig : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamSinsig()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinParamRad.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSinsig.ParamRad).Value);
            this.spinParamFreq.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSinsig.ParamFreq).Value);
            this.spinParamK.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSinsig.ParamK).Value);
            this.spinParamTime.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSinsig.ParamTime).Value);
            this.drpInputDI.Text = Algorithm.GetInputVar(PIDSinsig.InputDI).Value.ToString();

            this.drpInputDI.Enabled = !Block.IsLinkLeftPort(PIDSinsig.InputDI); 
       
        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDSinsig.ParamK, ConvertUtil.ConvertToDouble(this.spinParamK.Value));
            Algorithm.SetParamValue(PIDSinsig.ParamRad, ConvertUtil.ConvertToDouble(this.spinParamRad.Value));
            Algorithm.SetParamValue(PIDSinsig.ParamFreq, ConvertUtil.ConvertToDouble(this.spinParamFreq.Value));
            Algorithm.SetParamValue(PIDSinsig.ParamTime, ConvertUtil.ConvertToDouble(this.spinParamTime.Value));
            Algorithm.SetInputSourceValue(PIDSinsig.InputDI, ConvertUtil.ConvertToDouble(this.drpInputDI.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
 
    }
}
