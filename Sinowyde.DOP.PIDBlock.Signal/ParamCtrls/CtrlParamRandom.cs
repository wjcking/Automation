using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.Util;
using System;
namespace Sinowyde.DOP.PIDBlock.Signal
{
    public partial class CtrlParamRandom : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamRandom()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinParamHigh.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDRandom.ParamHigh).Value);
            this.spinParamLow.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDRandom.ParamLow).Value);
            this.drpInputDI.Text = Algorithm.GetInputVar(PIDRandom.InputDI).Value.ToString();

            this.drpInputDI.Enabled = !Block.IsLinkLeftPort(PIDRandom.InputDI);  
        }

        public bool SaveParam()
        {
            if (!DataValidityChecked())
                return false;
            Algorithm.SetParamValue(PIDRandom.ParamHigh, ConvertUtil.ConvertToDouble(this.spinParamHigh.Value));
            Algorithm.SetParamValue(PIDRandom.ParamLow, ConvertUtil.ConvertToDouble(this.spinParamLow.Value));
            Algorithm.SetInputSourceValue(PIDRandom.InputDI, ConvertUtil.ConvertToDouble(this.drpInputDI.Text));

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
                XtraMessageBox.Show("信号上限值不能小于信号下限值！");
                return false;
            }
            return true;
        }
    }
}
