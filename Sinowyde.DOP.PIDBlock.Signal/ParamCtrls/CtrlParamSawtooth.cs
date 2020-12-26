using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.Util;
using System;
namespace Sinowyde.DOP.PIDBlock.Signal
{
    public partial class CtrlParamSawtooth : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamSawtooth()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinParamHigh.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSawtooth.ParamHigh).Value);
            this.spinParamLow.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSawtooth.ParamLow).Value);
            this.spinParamWidth.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSawtooth.ParamWidth).Value);
            this.drpInputDI.Text = Algorithm.GetInputVar(PIDSawtooth.InputDI).Value.ToString();

            this.drpInputDI.Enabled = !Block.IsLinkLeftPort(PIDSawtooth.InputDI);  
        }

        public bool SaveParam()
        {
            if (!DataValidityChecked())
                return false;
            Algorithm.SetParamValue(PIDSawtooth.ParamHigh, ConvertUtil.ConvertToDouble(this.spinParamHigh.Value));
            Algorithm.SetParamValue(PIDSawtooth.ParamLow, ConvertUtil.ConvertToDouble(this.spinParamLow.Value));
            Algorithm.SetParamValue(PIDSawtooth.ParamWidth, ConvertUtil.ConvertToDouble(this.spinParamWidth.Value));
            Algorithm.SetInputSourceValue(PIDSawtooth.InputDI, ConvertUtil.ConvertToDouble(this.drpInputDI.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
 

        /// <summary>
        /// 数据校验
        /// </summary>
        /// <returns></returns>
        private bool DataValidityChecked()
        {
            if (this.spinParamHigh.Value < this.spinParamLow.Value)
            {
                XtraMessageBox.Show("波峰值不能小于波谷值！");
                return false;
            }
            return true;
        }
    }
}
