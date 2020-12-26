using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Control
{
    public partial class CtrlParam2ib : XtraUserControl, ICtrlParamBase
    {
        public CtrlParam2ib()
        {
            InitializeComponent();
        }

        public PIDBindAlgorithm Algorithm { get; set; }

        public void LoadParam()
        {
            this.spinParamYH.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID2ib.ParamYH).Value);
            this.spinParamYL.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PID2ib.ParamYL).Value);
            //this.drpInputX.Text = Algorithm.GetParam(PID2ib.InputX).Value.ToString();
            //this.drpInputTR1.Text = Algorithm.GetParam(PID2ib.InputTR1).Value.ToString();
            //this.drpInputTR2.Text = Algorithm.GetParam(PID2ib.InputTR2).Value.ToString();
            //this.drpInputTS1.Text = Algorithm.GetParam(PID2ib.InputTS1).Value.ToString();
            //this.drpInputTS2.Text = Algorithm.GetParam(PID2ib.InputTS2).Value.ToString();
            //链接后不可用
            //this.drpInputX.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID2ib.InputX)) ? true : false;
            //this.drpInputTR1.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID2ib.InputTR1)) ? true : false;
            //this.drpInputTR2.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID2ib.InputTR2)) ? true : false;
            this.drpInputTS1.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID2ib.InputTS1)) ? true : false;
            this.drpInputTS2.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PID2ib.InputTS2)) ? true : false;

        }

        public void SaveParam()
        {
            Algorithm.SetParam(PID2ib.ParamYH, ConvertUtil.ConvertToDouble(this.spinParamYH.Value));
            Algorithm.SetParam(PID2ib.ParamYL, ConvertUtil.ConvertToDouble(this.spinParamYL.Value));
            //Algorithm.SetParam(PID2ib.InputX, ConvertUtil.ConvertToDouble(this.drpInputX.Text));
            //Algorithm.SetParam(PID2ib.InputTR1, ConvertUtil.ConvertToDouble(this.drpInputTR1.Text));
            //Algorithm.SetParam(PID2ib.InputTR2, ConvertUtil.ConvertToDouble(this.drpInputTR2.Text));
            Algorithm.SetParam(PID2ib.InputTS1, ConvertUtil.ConvertToDouble(this.drpInputTS1.Text));
            Algorithm.SetParam(PID2ib.InputTS2, ConvertUtil.ConvertToDouble(this.drpInputTS2.Text));

        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        public string BlockName
        {
            get { return "2输入平衡算法块"; }
        }
    }
}
