using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Control
{
    public partial class CtrlParam8ib : XtraUserControl, ICtrlParamBase
    {
        public CtrlParam8ib()
        {
            InitializeComponent();
        }

        public PIDBindAlgorithm Algorithm { get; set; }

        public void LoadParam()
        {
            this.spinParamHigh.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID8ib.ParamHigh).Value);
            this.spinParamLow.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID8ib.ParamLow).Value);
            this.spinParamSout.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID8ib.ParamSout).Value);
            this.spinInputAI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID8ib.InputAI).Value);
            this.spinInputTR1.Value =ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID8ib.InputTR1).Value );
            this.spinInputTR2.Value =ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID8ib.InputTR2).Value );
            this.spinInputTR3.Value =ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID8ib.InputTR3).Value );
            this.spinInputTR4.Value =ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID8ib.InputTR4).Value );
            this.spinInputTR5.Value =ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID8ib.InputTR5).Value );
            this.spinInputTR6.Value =ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID8ib.InputTR6).Value );
            this.spinInputTR7.Value =ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID8ib.InputTR7).Value );
            this.spinInputTR8.Value =ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID8ib.InputTR8).Value );
            this.drpInputTS1.Text = Algorithm.GetParam(PID8ib.InputTS1).Value.ToString();
            this.drpInputTS2.Text = Algorithm.GetParam(PID8ib.InputTS2).Value.ToString();
            this.drpInputTS3.Text = Algorithm.GetParam(PID8ib.InputTS3).Value.ToString();
            this.drpInputTS4.Text = Algorithm.GetParam(PID8ib.InputTS4).Value.ToString();
            this.drpInputTS5.Text = Algorithm.GetParam(PID8ib.InputTS5).Value.ToString();
            this.drpInputTS6.Text = Algorithm.GetParam(PID8ib.InputTS6).Value.ToString();
            this.drpInputTS7.Text = Algorithm.GetParam(PID8ib.InputTS7).Value.ToString();
            this.drpInputTS8.Text = Algorithm.GetParam(PID8ib.InputTS8).Value.ToString();
            //链接后不可用
            this.spinInputAI.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID8ib.InputAI)) ? true : false;
            this.spinInputTR1.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID8ib.InputTR1)) ? true : false;
            this.spinInputTR2.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID8ib.InputTR2)) ? true : false;
            this.spinInputTR3.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID8ib.InputTR3)) ? true : false;
            this.spinInputTR4.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID8ib.InputTR4)) ? true : false;
            this.spinInputTR5.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID8ib.InputTR5)) ? true : false;
            this.spinInputTR6.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID8ib.InputTR6)) ? true : false;
            this.spinInputTR7.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID8ib.InputTR7)) ? true : false;
            this.spinInputTR8.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID8ib.InputTR8)) ? true : false;
            this.drpInputTS1.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID8ib.InputTS1)) ? true : false;
            this.drpInputTS2.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID8ib.InputTS2)) ? true : false;
            this.drpInputTS3.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID8ib.InputTS3)) ? true : false;
            this.drpInputTS4.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID8ib.InputTS4)) ? true : false;
            this.drpInputTS5.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID8ib.InputTS5)) ? true : false;
            this.drpInputTS6.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID8ib.InputTS6)) ? true : false;
            this.drpInputTS7.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID8ib.InputTS7)) ? true : false;
            this.drpInputTS8.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID8ib.InputTS8)) ? true : false;

        }

        public void SaveParam()
        {
            Algorithm.SetParam(PID8ib.ParamHigh, ConvertUtil.ConvertToDouble(this.spinParamHigh.Value));
            Algorithm.SetParam(PID8ib.ParamLow, ConvertUtil.ConvertToDouble(this.spinParamLow.Value));
            Algorithm.SetParam(PID8ib.ParamSout, ConvertUtil.ConvertToDouble(this.spinParamSout.Value));
            Algorithm.SetParam(PID8ib.InputAI, ConvertUtil.ConvertToDouble(this.spinInputAI.Value));
            Algorithm.SetParam(PID8ib.InputTR1, ConvertUtil.ConvertToDouble(this.spinInputTR1.Value));
            Algorithm.SetParam(PID8ib.InputTR2, ConvertUtil.ConvertToDouble(this.spinInputTR2.Value));
            Algorithm.SetParam(PID8ib.InputTR3, ConvertUtil.ConvertToDouble(this.spinInputTR3.Value));
            Algorithm.SetParam(PID8ib.InputTR4, ConvertUtil.ConvertToDouble(this.spinInputTR4.Value));
            Algorithm.SetParam(PID8ib.InputTR5, ConvertUtil.ConvertToDouble(this.spinInputTR5.Value));
            Algorithm.SetParam(PID8ib.InputTR6, ConvertUtil.ConvertToDouble(this.spinInputTR6.Value));
            Algorithm.SetParam(PID8ib.InputTR7, ConvertUtil.ConvertToDouble(this.spinInputTR7.Value));
            Algorithm.SetParam(PID8ib.InputTR8, ConvertUtil.ConvertToDouble(this.spinInputTR8.Value));
            Algorithm.SetParam(PID8ib.InputTS1, ConvertUtil.ConvertToDouble(this.drpInputTS1.Text));
            Algorithm.SetParam(PID8ib.InputTS2, ConvertUtil.ConvertToDouble(this.drpInputTS2.Text));
            Algorithm.SetParam(PID8ib.InputTS3, ConvertUtil.ConvertToDouble(this.drpInputTS3.Text));
            Algorithm.SetParam(PID8ib.InputTS4, ConvertUtil.ConvertToDouble(this.drpInputTS4.Text));
            Algorithm.SetParam(PID8ib.InputTS5, ConvertUtil.ConvertToDouble(this.drpInputTS5.Text));
            Algorithm.SetParam(PID8ib.InputTS6, ConvertUtil.ConvertToDouble(this.drpInputTS6.Text));
            Algorithm.SetParam(PID8ib.InputTS7, ConvertUtil.ConvertToDouble(this.drpInputTS7.Text));
            Algorithm.SetParam(PID8ib.InputTS8, ConvertUtil.ConvertToDouble(this.drpInputTS8.Text));

        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        public string BlockName
        {
            get { return "8输入平衡算法块"; }
        }
    }
}
