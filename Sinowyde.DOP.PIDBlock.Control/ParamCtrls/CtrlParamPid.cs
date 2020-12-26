using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Control
{
    public partial class CtrlParamPid : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamPid()
        {
            InitializeComponent();
        }
        private PidOutModeText outModeText = new PidOutModeText();
        private PidDirectText directText = new PidDirectText();
        public PIDBindAlgorithm Algorithm { get; set; }

        public void LoadParam()
        {
            this.spinParamB.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.ParamB).Value);
            this.spinParamTI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.ParamTI).Value);
            this.spinParamTD.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.ParamTD).Value);
            this.spinParamKD.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.ParamKD).Value);
            this.spinParamPVGain.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.ParamPVGain).Value);
            this.spinParamPVBias.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.ParamPVBias).Value);
            this.spinParamSPGain.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.ParamSPGain).Value);
            this.spinParamSPBiao.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.ParamSPBiao).Value);
            //this.spinParamOutMode.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.ParamOutMode).Value);
            //this.spinParamDirect.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.ParamDirect).Value);
            this.spinParamHighRange.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.ParamHighRange).Value);
            this.spinParamLowRange.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.ParamLowRange).Value);
            this.spinParamHighLmt.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.ParamHighLmt).Value);
            this.spinParamLowLmt.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.ParamLowLmt).Value);
            this.spinParamErrALM.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.ParamErrALM).Value);
            this.spinParamOutRate.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.ParamOutRate).Value);
            this.spinInputPV.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.InputPV).Value);
            this.spinInputSP.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.InputSP).Value);
            this.spinInputFF.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.InputFF).Value);
            this.spinInputTR.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.InputTR).Value);
            this.spinInputKKP.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.InputKKP).Value);
            this.spinInputKTI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.InputKTI).Value);
            this.spinInputKTD.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.InputKTD).Value);
            this.spinInputPIDDB.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDPid.InputPIDDB).Value);
            this.drpInputSTR.Text = Algorithm.GetParam(PIDPid.InputSTR).Value.ToString();

            drpOutMode.Properties.Items.AddRange(outModeText.GetShowTexts());
            comboBoxEdit1.Properties.Items.AddRange(directText.GetShowTexts());

            drpOutMode.SelectedIndex = ConvertUtil.ConvertToInt(Algorithm.GetParam(PIDPid.ParamOutMode).Value);
            comboBoxEdit1.SelectedIndex = ConvertUtil.ConvertToInt(Algorithm.GetParam(PIDPid.ParamDirect).Value);

            //链接后不可用
            this.spinInputPV.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDPid.InputPV)) ? true : false;
            this.spinInputSP.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDPid.InputSP)) ? true : false;
            this.spinInputFF.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDPid.InputFF)) ? true : false;
            this.spinInputTR.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDPid.InputTR)) ? true : false;
            this.spinInputKKP.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDPid.InputKKP)) ? true : false;
            this.spinInputKTI.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDPid.InputKTI)) ? true : false;
            this.spinInputKTD.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDPid.InputKTD)) ? true : false;
            this.spinInputPIDDB.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDPid.InputPIDDB)) ? true : false;
            this.drpInputSTR.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDPid.InputSTR)) ? true : false;

            if (!string.IsNullOrEmpty(Algorithm.GetBindParam(PIDPid.InputPV)))
            {
                drpLinkPoint.Text = PIDPid.InputPV;
                ctrlPointPicker1.SelectedNumber = PIDPid.InputPV;
            }
            else if (!string.IsNullOrEmpty(Algorithm.GetBindParam(PIDPid.InputSP)))
            {
                drpLinkPoint.Text = PIDPid.InputSP;
                ctrlPointPicker1.SelectedNumber = PIDPid.InputSP;
            }
            else
            {
                drpLinkPoint.Text = PIDPid.ResultAO;
                ctrlPointPicker1.SelectedNumber = PIDPid.ResultAO;
            }
            if (!string.IsNullOrEmpty(Algorithm.GetBindParam(PIDPid.ResultDO)))
                ctrlPointPicker1.SelectedNumber = PIDPid.ResultDO;
        }

        public void SaveParam()
        {
            Algorithm.SetParam(PIDPid.ParamB, ConvertUtil.ConvertToDouble(this.spinParamB.Value));
            Algorithm.SetParam(PIDPid.ParamTI, ConvertUtil.ConvertToDouble(this.spinParamTI.Value));
            Algorithm.SetParam(PIDPid.ParamTD, ConvertUtil.ConvertToDouble(this.spinParamTD.Value));
            Algorithm.SetParam(PIDPid.ParamKD, ConvertUtil.ConvertToDouble(this.spinParamKD.Value));
            Algorithm.SetParam(PIDPid.ParamPVGain, ConvertUtil.ConvertToDouble(this.spinParamPVGain.Value));
            Algorithm.SetParam(PIDPid.ParamPVBias, ConvertUtil.ConvertToDouble(this.spinParamPVBias.Value));
            Algorithm.SetParam(PIDPid.ParamSPGain, ConvertUtil.ConvertToDouble(this.spinParamSPGain.Value));
            Algorithm.SetParam(PIDPid.ParamSPBiao, ConvertUtil.ConvertToDouble(this.spinParamSPBiao.Value));
            Algorithm.SetParam(PIDPid.ParamOutMode, ConvertUtil.ConvertToDouble(this.drpOutMode.SelectedIndex));
            Algorithm.SetParam(PIDPid.ParamDirect, ConvertUtil.ConvertToDouble(this.comboBoxEdit1.SelectedIndex));
            Algorithm.SetParam(PIDPid.ParamHighRange, ConvertUtil.ConvertToDouble(this.spinParamHighRange.Value));
            Algorithm.SetParam(PIDPid.ParamLowRange, ConvertUtil.ConvertToDouble(this.spinParamLowRange.Value));
            Algorithm.SetParam(PIDPid.ParamHighLmt, ConvertUtil.ConvertToDouble(this.spinParamHighLmt.Value));
            Algorithm.SetParam(PIDPid.ParamLowLmt, ConvertUtil.ConvertToDouble(this.spinParamLowLmt.Value));
            Algorithm.SetParam(PIDPid.ParamErrALM, ConvertUtil.ConvertToDouble(this.spinParamErrALM.Value));
            Algorithm.SetParam(PIDPid.ParamOutRate, ConvertUtil.ConvertToDouble(this.spinParamOutRate.Value));
            Algorithm.SetParam(PIDPid.InputPV, ConvertUtil.ConvertToDouble(this.spinInputPV.Value));
            Algorithm.SetParam(PIDPid.InputSP, ConvertUtil.ConvertToDouble(this.spinInputSP.Value));
            Algorithm.SetParam(PIDPid.InputFF, ConvertUtil.ConvertToDouble(this.spinInputFF.Value));
            Algorithm.SetParam(PIDPid.InputTR, ConvertUtil.ConvertToDouble(this.spinInputTR.Value));
            Algorithm.SetParam(PIDPid.InputKKP, ConvertUtil.ConvertToDouble(this.spinInputKKP.Value));
            Algorithm.SetParam(PIDPid.InputKTI, ConvertUtil.ConvertToDouble(this.spinInputKTI.Value));
            Algorithm.SetParam(PIDPid.InputKTD, ConvertUtil.ConvertToDouble(this.spinInputKTD.Value));
            Algorithm.SetParam(PIDPid.InputPIDDB, ConvertUtil.ConvertToDouble(this.spinInputPIDDB.Text));
            Algorithm.SetParam(PIDPid.InputSTR, ConvertUtil.ConvertToDouble(this.drpInputSTR.Text));

            if (ctrlPointPicker1.Point != null)
            {
                switch (drpLinkPoint.Text)
                {
                    case PIDPid.InputPV:
                        Algorithm.BindParam(PIDPid.InputPV, BindSourceToken.PrefixVariable + ctrlPointPicker1.Point.Number);
                        break;
                    case PIDPid.InputSP:
                        Algorithm.BindParam(PIDPid.InputSP, BindSourceToken.PrefixVariable + ctrlPointPicker1.Point.Number);
                        break;
                    case PIDPid.ResultAO:
                        Algorithm.BindParam(PIDPid.ResultAO, BindSourceToken.PrefixVariable + ctrlPointPicker1.Point.Number);
                        break;
                }
            }
            if (ctrlPointPicker2.Point != null)
                Algorithm.BindParam(PIDPid.ResultDO, BindSourceToken.PrefixVariable + ctrlPointPicker2.Point.Number);

        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        public string BlockName
        {
            get { return "PID控制算法块"; }
        }

        private void xtraTabPage2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
