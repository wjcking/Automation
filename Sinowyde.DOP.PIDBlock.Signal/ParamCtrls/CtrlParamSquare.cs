using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.Util;
using System;
namespace Sinowyde.DOP.PIDBlock.Signal
{
    public partial class CtrlParamSquare : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamSquare()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.drpInputDI.Text = Algorithm.GetInputVar(PIDSquare.InputDI).Value.ToString();
            this.spinParamHigh.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSquare.ParamHigh).Value);
            this.spinParamLow.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSquare.ParamLow).Value);
            this.spinParamWidth.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSquare.ParamWidth).Value);

            this.drpInputDI.Enabled = !Block.IsLinkLeftPort(PIDSquare.InputDI); 
        }

        public bool SaveParam()
        {
            if (!DataValidityChecked())
                return false;

            Algorithm.SetInputSourceValue(PIDSquare.InputDI , ConvertUtil.ConvertToDouble(this.drpInputDI.Text));
            Algorithm.SetParamValue(PIDSquare.ParamHigh, ConvertUtil.ConvertToDouble(this.spinParamHigh.Value));
            Algorithm.SetParamValue(PIDSquare.ParamLow, ConvertUtil.ConvertToDouble(this.spinParamLow.Value));
            Algorithm.SetParamValue(PIDSquare.ParamWidth, ConvertUtil.ConvertToDouble(this.spinParamWidth.Value));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
 
        /// <summary>
        /// ����У��
        /// </summary>
        /// <returns></returns>
        private bool DataValidityChecked()
        {
            if (this.spinParamHigh.Value < this.spinParamLow.Value)
            {
                XtraMessageBox.Show("����ֵ����С�ڲ���ֵ��");
                return false;
            }
            return true;
        }

    }
}
