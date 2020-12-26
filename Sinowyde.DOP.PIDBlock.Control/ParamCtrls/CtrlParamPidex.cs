using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDBlock.Control
{
    public partial class CtrlParamPidex : XtraUserControl, ICtrlParamBase
    {
        private PidOutModeText outModeText = new PidOutModeText();
        private PidDirectText directText = new PidDirectText();

        public CtrlParamPidex()
        {
            InitializeComponent();

            drpOutMode.Properties.Items.AddRange(outModeText.GetShowTexts());
            drpOutput.Properties.Items.AddRange(directText.GetShowTexts());

            drpOutMode.SelectedIndex = 0;
            drpOutput.SelectedIndex = 0;
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.spinParamKP.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPidex.ParamKP).Value);
            this.spinParamTI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPidex.ParamTI).Value);
            this.spinParamTD.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPidex.ParamTD).Value);
            this.spinParamKD.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPidex.ParamKD).Value);
            this.spinParamPVGain.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPidex.ParamPVGain).Value);
            this.spinParamPVBias.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPidex.ParamPVBias).Value);
            this.spinParamSPGain.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPidex.ParamSPGain).Value);
            this.spinParamSPBiao.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPidex.ParamSPBias).Value);
            this.spinParamHighLmt.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPidex.ParamHighLmt).Value);
            this.spinParamLowLmt.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPidex.ParamLowLmt).Value);
            this.spinParamErrALM.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPidex.ParamErrALM).Value);
            this.spinParamOutRate.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPidex.ParamOutRate).Value);

            this.spinInputPV.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDPidex.InputPV).Value);
            this.spinInputSP.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDPidex.InputSP).Value);
            this.spinInputFF.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDPidex.InputFF).Value);
            this.spinInputTR.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDPidex.InputTR).Value);
            this.spinInputKKP.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDPidex.InputKKP).Value);
            this.spinInputKTI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDPidex.InputKTI).Value);
            this.spinInputKTD.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDPidex.InputKTD).Value);
            this.spinInputPIDDB.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDPidex.InputPIDDB).Value);
            this.drpInputSTR.Text = Algorithm.GetInputVar(PIDPidex.InputSTR).Value.ToString();
            this.drpInputIL.Text = Algorithm.GetInputVar(PIDPidex.InputIL).Value.ToString();
            this.drpInputDL.Text = Algorithm.GetInputVar(PIDPidex.InputDL).Value.ToString();

            drpOutMode.SelectedIndex = ConvertUtil.ConvertToInt(Algorithm.GetParam(PIDPidex.ParamOutMode).Value);
            drpOutput.SelectedIndex = ConvertUtil.ConvertToInt(Algorithm.GetParam(PIDPidex.ParamDirect).Value);

            //链接后不可用
            this.spinInputPV.Enabled = !Block.IsLinkLeftPort(PIDPidex.InputPV);
            this.spinInputSP.Enabled = !Block.IsLinkLeftPort(PIDPidex.InputSP);
            this.spinInputFF.Enabled = !Block.IsLinkLeftPort(PIDPidex.InputFF);
            this.spinInputTR.Enabled = !Block.IsLinkLeftPort(PIDPidex.InputTR);
            this.spinInputKKP.Enabled = !Block.IsLinkLeftPort(PIDPidex.InputKKP);
            this.spinInputKTI.Enabled = !Block.IsLinkLeftPort(PIDPidex.InputKTI);
            this.spinInputKTD.Enabled = !Block.IsLinkLeftPort(PIDPidex.InputKTD);
            this.spinInputPIDDB.Enabled = !Block.IsLinkLeftPort(PIDPidex.InputPIDDB);
            this.drpInputSTR.Enabled = !Block.IsLinkLeftPort(PIDPidex.InputSTR);
            this.drpInputDL.Enabled = !Block.IsLinkLeftPort(PIDPidex.InputDL);
            this.drpInputIL.Enabled = !Block.IsLinkLeftPort(PIDPidex.InputIL);
        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDPidex.ParamKP, ConvertUtil.ConvertToDouble(this.spinParamKP.Value));
            Algorithm.SetParamValue(PIDPidex.ParamTI, ConvertUtil.ConvertToDouble(this.spinParamTI.Value));
            Algorithm.SetParamValue(PIDPidex.ParamTD, ConvertUtil.ConvertToDouble(this.spinParamTD.Value));
            Algorithm.SetParamValue(PIDPidex.ParamKD, ConvertUtil.ConvertToDouble(this.spinParamKD.Value));
            Algorithm.SetParamValue(PIDPidex.ParamPVGain, ConvertUtil.ConvertToDouble(this.spinParamPVGain.Value));
            Algorithm.SetParamValue(PIDPidex.ParamPVBias, ConvertUtil.ConvertToDouble(this.spinParamPVBias.Value));
            Algorithm.SetParamValue(PIDPidex.ParamSPGain, ConvertUtil.ConvertToDouble(this.spinParamSPGain.Value));
            Algorithm.SetParamValue(PIDPidex.ParamSPBias, ConvertUtil.ConvertToDouble(this.spinParamSPBiao.Value));
            Algorithm.SetParamValue(PIDPidex.ParamOutMode, ConvertUtil.ConvertToDouble(this.drpOutMode.SelectedIndex));
            Algorithm.SetParamValue(PIDPidex.ParamDirect, ConvertUtil.ConvertToDouble(this.drpOutput.SelectedIndex));
            Algorithm.SetParamValue(PIDPidex.ParamHighLmt, ConvertUtil.ConvertToDouble(this.spinParamHighLmt.Value));
            Algorithm.SetParamValue(PIDPidex.ParamLowLmt, ConvertUtil.ConvertToDouble(this.spinParamLowLmt.Value));
            Algorithm.SetParamValue(PIDPidex.ParamErrALM, ConvertUtil.ConvertToDouble(this.spinParamErrALM.Value));
            Algorithm.SetParamValue(PIDPidex.ParamOutRate, ConvertUtil.ConvertToDouble(this.spinParamOutRate.Value));

            Algorithm.SetInputSourceValue(PIDPidex.InputPV, ConvertUtil.ConvertToDouble(this.spinInputPV.Value));
            Algorithm.SetInputSourceValue(PIDPidex.InputSP, ConvertUtil.ConvertToDouble(this.spinInputSP.Value));
            Algorithm.SetInputSourceValue(PIDPidex.InputFF, ConvertUtil.ConvertToDouble(this.spinInputFF.Value));
            Algorithm.SetInputSourceValue(PIDPidex.InputTR, ConvertUtil.ConvertToDouble(this.spinInputTR.Value));
            Algorithm.SetInputSourceValue(PIDPidex.InputKKP, ConvertUtil.ConvertToDouble(this.spinInputKKP.Value));
            Algorithm.SetInputSourceValue(PIDPidex.InputKTI, ConvertUtil.ConvertToDouble(this.spinInputKTI.Value));
            Algorithm.SetInputSourceValue(PIDPidex.InputKTD, ConvertUtil.ConvertToDouble(this.spinInputKTD.Value));
            Algorithm.SetInputSourceValue(PIDPidex.InputPIDDB, ConvertUtil.ConvertToDouble(this.spinInputPIDDB.Text));
            Algorithm.SetInputSourceValue(PIDPidex.InputSTR, ConvertUtil.ConvertToDouble(this.drpInputSTR.Text));
            Algorithm.SetInputSourceValue(PIDPidex.InputIL, ConvertUtil.ConvertToDouble(this.drpInputIL.Text));
            Algorithm.SetInputSourceValue(PIDPidex.InputDL, ConvertUtil.ConvertToDouble(this.drpInputDL.Text));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

    }
}
