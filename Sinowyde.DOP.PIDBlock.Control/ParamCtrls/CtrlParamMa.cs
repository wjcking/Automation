using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Control
{
    public partial class CtrlParamMa : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamMa()
        {
            InitializeComponent();
        }

        public PIDBindAlgorithm Algorithm { get; set; }

        public void LoadParam()
        {
            this.spinParamK.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMa.ParamK).Value);
            this.spinParamBias.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMa.ParamBias).Value);
            this.spinParamYH.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMa.ParamYH).Value);
            this.spinParamYL.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMa.ParamYL).Value);
            this.spinParamSPH.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMa.ParamSPH).Value);
            this.spinParamSPL.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMa.ParamSPL).Value);
            this.drpParamTurnOver.SelectedIndex = ConvertUtil.ConvertToInt(Algorithm.GetParam(PIDMa.ParamTurnOver).Value);
            this.drpParamFP.SelectedIndex = ConvertUtil.ConvertToInt(Algorithm.GetParam(PIDMa.ParamFP).Value);
            this.drpParamMANF.SelectedIndex = ConvertUtil.ConvertToInt(Algorithm.GetParam(PIDMa.ParamMANF).Value);
            this.drpParamMODE.SelectedIndex = ConvertUtil.ConvertToInt(Algorithm.GetParam(PIDMa.ParamMODE).Value);
            this.drpParamEMODE.SelectedIndex = ConvertUtil.ConvertToInt(Algorithm.GetParam(PIDMa.ParamEMODE).Value);
            this.spinParamTRATE.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMa.ParamTRATE).Value);
            this.spinParamDeadband.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMa.ParamDeadband).Value);
            this.spinParamOnTime.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMa.ParamOnTime).Value);
            this.spinParamOffTime.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMa.ParamOffTime).Value);
            this.spinInputX.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMa.InputX).Value);
            this.spinInputFF.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMa.InputFF).Value);
            this.spinInputTR.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMa.InputTR).Value);
            this.spinInputYP.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMa.InputYP).Value);
            this.spinParamSPT.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMa.ParamSPT).Value);
            this.drpInputTS.Text = Algorithm.GetParam(PIDMa.InputTS).Value.ToString();
            this.drpInputBI.Text = Algorithm.GetParam(PIDMa.InputBI).Value.ToString();
            this.drpInputBD.Text = Algorithm.GetParam(PIDMa.InputBD).Value.ToString();
            this.drpInputMRE.Text = Algorithm.GetParam(PIDMa.InputMRE).Value.ToString();
            this.spinParamAR.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMa.ParamAR).Value);
       //     this.spinParamDEC.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMa.ResultDEC).Value);
            //链接后不可用
            this.spinInputX.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDMa.InputX)) ? true : false;
            this.spinInputFF.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDMa.InputFF)) ? true : false;
            this.spinInputTR.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDMa.InputTR)) ? true : false;
            this.spinInputYP.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDMa.InputYP)) ? true : false;
            this.drpInputTS.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDMa.InputTS)) ? true : false;
            this.drpInputBI.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDMa.InputBI)) ? true : false;
            this.drpInputBD.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDMa.InputBD)) ? true : false;
            this.drpInputMRE.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDMa.InputMRE)) ? true : false;

        }

        public void SaveParam()
        {
            Algorithm.SetParam(PIDMa.ParamK, ConvertUtil.ConvertToDouble(this.spinParamK.Value));
            Algorithm.SetParam(PIDMa.ParamBias, ConvertUtil.ConvertToDouble(this.spinParamBias.Value));
            Algorithm.SetParam(PIDMa.ParamYH, ConvertUtil.ConvertToDouble(this.spinParamYH.Value));
            Algorithm.SetParam(PIDMa.ParamYL, ConvertUtil.ConvertToDouble(this.spinParamYL.Value));
            Algorithm.SetParam(PIDMa.ParamSPH, ConvertUtil.ConvertToDouble(this.spinParamSPH.Value));
            Algorithm.SetParam(PIDMa.ParamSPL, ConvertUtil.ConvertToDouble(this.spinParamSPL.Value));
            Algorithm.SetParam(PIDMa.ParamTurnOver, this.drpParamTurnOver.SelectedIndex);
            Algorithm.SetParam(PIDMa.ParamFP, this.drpParamFP.SelectedIndex);
            Algorithm.SetParam(PIDMa.ParamMANF, this.drpParamMANF.SelectedIndex);
            Algorithm.SetParam(PIDMa.ParamMODE, this.drpParamMODE.SelectedIndex);
            Algorithm.SetParam(PIDMa.ParamEMODE, this.drpParamEMODE.SelectedIndex);
            Algorithm.SetParam(PIDMa.ParamTRATE, ConvertUtil.ConvertToDouble(this.spinParamTRATE.Value));
            Algorithm.SetParam(PIDMa.ParamDeadband, ConvertUtil.ConvertToDouble(this.spinParamDeadband.Value));
            Algorithm.SetParam(PIDMa.ParamOnTime, ConvertUtil.ConvertToDouble(this.spinParamOnTime.Value));
            Algorithm.SetParam(PIDMa.ParamOffTime, ConvertUtil.ConvertToDouble(this.spinParamOffTime.Value));
            Algorithm.SetParam(PIDMa.InputX, ConvertUtil.ConvertToDouble(this. spinInputX.Value));
            Algorithm.SetParam(PIDMa.InputFF, ConvertUtil.ConvertToDouble(this.spinInputFF.Value));
            Algorithm.SetParam(PIDMa.InputTR, ConvertUtil.ConvertToDouble(this.spinInputTR.Value));
            Algorithm.SetParam(PIDMa.InputYP, ConvertUtil.ConvertToDouble(this.spinInputYP.Value));
            Algorithm.SetParam(PIDMa.ParamSPT, ConvertUtil.ConvertToDouble(this.spinParamSPT.Value));
            Algorithm.SetParam(PIDMa.InputTS, ConvertUtil.ConvertToDouble(this.drpInputTS.Text));
            Algorithm.SetParam(PIDMa.InputBI, ConvertUtil.ConvertToDouble(this.drpInputBI.Text));
            Algorithm.SetParam(PIDMa.InputBD, ConvertUtil.ConvertToDouble(this.drpInputBD.Text));
            Algorithm.SetParam(PIDMa.InputMRE, ConvertUtil.ConvertToDouble(this.drpInputMRE.Text));
            Algorithm.SetParam(PIDMa.ParamAR, ConvertUtil.ConvertToDouble(this.spinParamAR.Value));
            //Algorithm.SetParam(PIDMa.ResultDEC, ConvertUtil.ConvertToDouble(this.spinParamDEC.Value));

        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        public string BlockName
        {
            get { return "5.4模拟手动站算法块"; }
        }
    }
}
