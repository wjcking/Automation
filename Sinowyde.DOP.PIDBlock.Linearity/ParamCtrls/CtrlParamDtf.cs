using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.Util;
using System;
namespace Sinowyde.DOP.PIDBlock.Linearity
{
    public partial class CtrlParamDtf : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamDtf()
        {
            InitializeComponent();
        }

        public PIDBindAlgorithm Algorithm { get; set; }

        public void LoadParam()
        {
            this.spinParamK.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDtf.ParamK).Value);
            //this.spinParamA.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDtf.ParamA).Value);
            //this.spinParamB.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDtf.ParamB).Value);
            this.spinParamT.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDtf.ParamT).Value);
            this.spinParamINIT.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDtf.ParamINIT).Value);
            this.spinInputAI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDtf.InputAI).Value);


            this.spinInputAI.Enabled = String.IsNullOrEmpty(Algorithm.GetBindParam(PIDDtf.InputAI)) ? true : false;
           
        }

        public void SaveParam()
        {
            Algorithm.SetParam(PIDDtf.ParamK, ConvertUtil.ConvertToDouble(this.spinParamK.Value));
            //Algorithm.SetParam(PIDDtf.ParamA,  ConvertUtil.ConvertToDouble(this.spinParamA.Value));
            //Algorithm.SetParam(PIDDtf.ParamB,  ConvertUtil.ConvertToDouble(this.spinParamB.Value));
            Algorithm.SetParam(PIDDtf.ParamT, ConvertUtil.ConvertToDouble(this.spinParamT.Value));
            Algorithm.SetParam(PIDDtf.ParamINIT, ConvertUtil.ConvertToDouble(this.spinParamINIT.Value));
            Algorithm.SetParam(PIDDtf.InputAI, ConvertUtil.ConvertToDouble(this.spinInputAI.Value));
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        public string BlockName
        {
            get { return "ÀëÉ¢´«µÝº¯ÊýËã·¨¿é£¨DTF£©DiscreteTransFunction6ab8e"; }
        }
    }
}
