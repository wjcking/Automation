using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.Util;
using System;
namespace Sinowyde.DOP.PIDBlock.Linearity
{
    public partial class CtrlParamCtf2 : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamCtf2()
        {
            InitializeComponent();
        }

        public PIDBindAlgorithm Algorithm { get; set; }

        public void LoadParam()
        {
            this.spinParamK.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDCtf2.ParamK).Value);
            this.spinParamT.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDCtf2.ParamT).Value);
            this.spinParamN.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDCtf2.ParamN).Value);
            this.spinParamINIT.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDCtf2.ParamINIT).Value);
            this.spinInputAI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDCtf2.InputAI).Value);

            this.spinInputAI.Enabled = String.IsNullOrEmpty(Algorithm.GetBindParam(PIDCtf2.InputAI)) ? true : false;

        }

        public void SaveParam()
        {
            Algorithm.SetParam(PIDCtf2.ParamK, ConvertUtil.ConvertToDouble(this.spinParamK.Value));
            Algorithm.SetParam(PIDCtf2.ParamT, ConvertUtil.ConvertToDouble(this.spinParamT.Value));
            Algorithm.SetParam(PIDCtf2.ParamN, ConvertUtil.ConvertToDouble(this.spinParamN.Value));
            Algorithm.SetParam(PIDCtf2.ParamINIT, ConvertUtil.ConvertToDouble(this.spinParamINIT.Value));
            Algorithm.SetParam(PIDCtf2.InputAI, ConvertUtil.ConvertToDouble(this.spinInputAI.Value));

        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        public string BlockName
        {
            get { return "连续传递函数2算法块（CTF2）ContinuousTransFunction203877"; }
        }
    }
}
