using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Linearity;
using Sinowyde.Util;
using System;
namespace Sinowyde.DOP.PIDBlock.Linearity
{
    public partial class CtrlParamCtf1 : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamCtf1()
        {
            InitializeComponent();
        }

        public PIDBindAlgorithm Algorithm { get; set; }

        public void LoadParam()
        {
            this.spinParamK.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDCtf1.ParamK).Value);
            this.txtA.Text = Algorithm.GetParam(PIDCtf1.ParamA).ValueToString();
            this.txtB.Text = Algorithm.GetParam(PIDCtf1.ParamB).ValueToString(); 
            this.spinParamINIT.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDCtf1.ParamINIT).Value);
            this.spinInputAI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDCtf1.InputAI).Value);

            this.spinInputAI.Enabled = String.IsNullOrEmpty(Algorithm.GetBindParam(PIDCtf1.InputAI)) ? true : false;

        }

        public void SaveParam()
        {
            Algorithm.SetParam(PIDCtf1.ParamK, ConvertUtil.ConvertToDouble(this.spinParamK.Value));
            Algorithm.GetParam(PIDCtf1.ParamA).StringToValue(txtA.Text);
            Algorithm.GetParam(PIDCtf1.ParamB).StringToValue(txtB.Text);
            Algorithm.SetParam(PIDCtf1.ParamINIT, ConvertUtil.ConvertToDouble(this.spinParamINIT.Value));
            Algorithm.SetParam(PIDCtf1.InputAI, ConvertUtil.ConvertToDouble(this.spinInputAI.Value));

        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        public string BlockName
        {
            get { return "连续传递函数1算法块"; }
        }
    }
}
