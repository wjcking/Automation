using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Control
{
    public partial class CtrlParamSnc : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamSnc()
        {
            InitializeComponent();
        }

        public PIDBindAlgorithm Algorithm { get; set; }

        public void LoadParam()
        {
            this.spinParamK.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamK).Value);
            this.spinParamBias.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamBias).Value);
            this.spinParamYH.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamYH).Value);
            this.spinParamYL.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamYL).Value);
            this.spinParamSPH.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamSPH).Value);
            this.spinParamSPL.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamSPL).Value);
            this.spinParamTurnOver.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamTurnOver).Value);
            this.spinParamFP.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamFP).Value);
            this.spinParamMANF.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamMANF).Value);
            this.spinParamMODE.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamMODE).Value);
            this.spinParamEMODE.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamEMODE).Value);
            this.spinParamTRATE.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamTRATE).Value);
            this.spinParamDeadband.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamDeadband).Value);
            this.spinParamOnTime.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamOnTime).Value);
            this.spinParamOffTime.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamOffTime).Value);
            this.spinParamX.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamX).Value);
            this.spinParamFF.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamFF).Value);
            this.spinParamTR.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamTR).Value);
            this.spinParamYP.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamYP).Value);
            this.spinParamTS.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamTS).Value);
            this.spinParamBI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamBI).Value);
            this.spinParamBD.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamBD).Value);
            this.spinParamMRE.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamMRE).Value);
            this.spinParamY.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamY).Value);
            this.spinParamSP.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamSP).Value);
            this.spinParamS.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamS).Value);
            this.spinParamINC.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamINC).Value);
            this.spinParamDEC.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSnc.ParamDEC).Value);
            //链接后不可用

        }

        public void SaveParam()
        {
            Algorithm.SetParam(PIDSnc.ParamK, ConvertUtil.ConvertToDouble(this.spinParamK.Value));
            Algorithm.SetParam(PIDSnc.ParamBias, ConvertUtil.ConvertToDouble(this.spinParamBias.Value));
            Algorithm.SetParam(PIDSnc.ParamYH, ConvertUtil.ConvertToDouble(this.spinParamYH.Value));
            Algorithm.SetParam(PIDSnc.ParamYL, ConvertUtil.ConvertToDouble(this.spinParamYL.Value));
            Algorithm.SetParam(PIDSnc.ParamSPH, ConvertUtil.ConvertToDouble(this.spinParamSPH.Value));
            Algorithm.SetParam(PIDSnc.ParamSPL, ConvertUtil.ConvertToDouble(this.spinParamSPL.Value));
            Algorithm.SetParam(PIDSnc.ParamTurnOver, ConvertUtil.ConvertToDouble(this.spinParamTurnOver.Value));
            Algorithm.SetParam(PIDSnc.ParamFP, ConvertUtil.ConvertToDouble(this.spinParamFP.Value));
            Algorithm.SetParam(PIDSnc.ParamMANF, ConvertUtil.ConvertToDouble(this.spinParamMANF.Value));
            Algorithm.SetParam(PIDSnc.ParamMODE, ConvertUtil.ConvertToDouble(this.spinParamMODE.Value));
            Algorithm.SetParam(PIDSnc.ParamEMODE, ConvertUtil.ConvertToDouble(this.spinParamEMODE.Value));
            Algorithm.SetParam(PIDSnc.ParamTRATE, ConvertUtil.ConvertToDouble(this.spinParamTRATE.Value));
            Algorithm.SetParam(PIDSnc.ParamDeadband, ConvertUtil.ConvertToDouble(this.spinParamDeadband.Value));
            Algorithm.SetParam(PIDSnc.ParamOnTime, ConvertUtil.ConvertToDouble(this.spinParamOnTime.Value));
            Algorithm.SetParam(PIDSnc.ParamOffTime, ConvertUtil.ConvertToDouble(this.spinParamOffTime.Value));
            Algorithm.SetParam(PIDSnc.ParamX, ConvertUtil.ConvertToDouble(this.spinParamX.Value));
            Algorithm.SetParam(PIDSnc.ParamFF, ConvertUtil.ConvertToDouble(this.spinParamFF.Value));
            Algorithm.SetParam(PIDSnc.ParamTR, ConvertUtil.ConvertToDouble(this.spinParamTR.Value));
            Algorithm.SetParam(PIDSnc.ParamYP, ConvertUtil.ConvertToDouble(this.spinParamYP.Value));
            Algorithm.SetParam(PIDSnc.ParamTS, ConvertUtil.ConvertToDouble(this.spinParamTS.Value));
            Algorithm.SetParam(PIDSnc.ParamBI, ConvertUtil.ConvertToDouble(this.spinParamBI.Value));
            Algorithm.SetParam(PIDSnc.ParamBD, ConvertUtil.ConvertToDouble(this.spinParamBD.Value));
            Algorithm.SetParam(PIDSnc.ParamMRE, ConvertUtil.ConvertToDouble(this.spinParamMRE.Value));
            Algorithm.SetParam(PIDSnc.ParamY, ConvertUtil.ConvertToDouble(this.spinParamY.Value));
            Algorithm.SetParam(PIDSnc.ParamSP, ConvertUtil.ConvertToDouble(this.spinParamSP.Value));
            Algorithm.SetParam(PIDSnc.ParamS, ConvertUtil.ConvertToDouble(this.spinParamS.Value));
            Algorithm.SetParam(PIDSnc.ParamINC, ConvertUtil.ConvertToDouble(this.spinParamINC.Value));
            Algorithm.SetParam(PIDSnc.ParamDEC, ConvertUtil.ConvertToDouble(this.spinParamDEC.Value));

        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        public string BlockName
        {
            get { return "5.3基于单个神经元的自适应控制算法块"; }
        }
    }
}
