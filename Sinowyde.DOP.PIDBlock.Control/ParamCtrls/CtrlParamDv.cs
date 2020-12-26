using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Control
{
    public partial class CtrlParamDv : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamDv()
        {
            InitializeComponent();

            //var dms = new string[19] 
            //{
            //   PIDDv.InputOvr1, PIDDv.
            //};
        }

        public PIDBindAlgorithm Algorithm { get; set; }

        public void LoadParam()
        {
            //this.spinParamOutM.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDv.ParamOutM).Value);
            //this.spinParamSetT.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDv.ParamSetT).Value);
            //this.spinParamRseT.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDv.ParamRseT).Value);
            //this.spinParamMod0.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDv.ParamMod0).Value);
            //this.spinParamSTP.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDv.ParamSTP).Value);
            //this.spinParamMP.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDv.ParamMP).Value);
            //this.spinParamFLB.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDv.ParamFLB).Value);
            //this.spinParamTout.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDv.ParamTout).Value);
            this.spinParamTover.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDv.ParamTover).Value);
            this.drpInputOvr1.Text = Algorithm.GetParam(PIDDv.InputOvr1).Value.ToString();
            this.drpInputOvr2.Text = Algorithm.GetParam(PIDDv.InputOvr2).Value.ToString();
            this.drpInputS1p.Text = Algorithm.GetParam(PIDDv.InputS1p).Value.ToString();
            this.drpInputS2p.Text = Algorithm.GetParam(PIDDv.InputS2p).Value.ToString();
            this.drpInputToM.Text = Algorithm.GetParam(PIDDv.InputToM).Value.ToString();
            this.drpInputReqA.Text = Algorithm.GetParam(PIDDv.InputReqA).Value.ToString();
            this.drpInputDmd1.Text = Algorithm.GetParam(PIDDv.InputDmd1).Value.ToString();
            this.drpInputDmd2.Text = Algorithm.GetParam(PIDDv.InputDmd2).Value.ToString();
            this.drpInputDmd3.Text = Algorithm.GetParam(PIDDv.InputDmd3).Value.ToString();
            this.drpInputFB1.Text = Algorithm.GetParam(PIDDv.InputFB1).Value.ToString();
            this.drpInputFB2.Text = Algorithm.GetParam(PIDDv.InputFB2).Value.ToString();
            this.drpInputFB3.Text = Algorithm.GetParam(PIDDv.InputFB3).Value.ToString();
            this.drpInputToTP.Text = Algorithm.GetParam(PIDDv.InputToTP).Value.ToString();
            //链接后不可用
            this.drpInputOvr1.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDv.InputOvr1)) ? true : false;
            this.drpInputOvr2.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDv.InputOvr2)) ? true : false;
            this.drpInputS1p.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDv.InputS1p)) ? true : false;
            this.drpInputS2p.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDv.InputS2p)) ? true : false;
            this.drpInputToM.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDv.InputToM)) ? true : false;
            this.drpInputReqA.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDv.InputReqA)) ? true : false;
            this.drpInputDmd1.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDv.InputDmd1)) ? true : false;
            this.drpInputDmd2.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDv.InputDmd2)) ? true : false;
            this.drpInputDmd3.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDv.InputDmd3)) ? true : false;
            this.drpInputFB1.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDv.InputFB1)) ? true : false;
            this.drpInputFB2.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDv.InputFB2)) ? true : false;
            this.drpInputFB3.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDv.InputFB3)) ? true : false;
            this.drpInputToTP.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDv.InputToTP)) ? true : false;


            for (int i = 0; i < radioGroup1.Properties.Items.Count;i++ )
            {
                var g = radioGroup1.Properties.Items[i];

                if (!string.IsNullOrEmpty(Algorithm.GetBindParam(BindSourceToken.PrefixVariable + g.Description)))
                {
                    radioGroup1.SelectedIndex = i;
                    break;
                }

            }
        }

        public void SaveParam()
        {
            //Algorithm.SetParam(PIDDv.ParamOutM, ConvertUtil.ConvertToDouble(this.spinParamOutM.Value));
            Algorithm.SetParam(PIDDv.ParamSetT, ConvertUtil.ConvertToDouble(this.spinParamSetT.Value));
            Algorithm.SetParam(PIDDv.ParamRseT, ConvertUtil.ConvertToDouble(this.spinParamRseT.Value));
            //Algorithm.SetParam(PIDDv.ParamMod0, ConvertUtil.ConvertToDouble(this.spinParamMod0.Value));
            //Algorithm.SetParam(PIDDv.ParamSTP, ConvertUtil.ConvertToDouble(this.spinParamSTP.Value));
            //Algorithm.SetParam(PIDDv.ParamMP, ConvertUtil.ConvertToDouble(this.spinParamMP.Value));
            //Algorithm.SetParam(PIDDv.ParamFLB, ConvertUtil.ConvertToDouble(this.spinParamFLB.Value));
            //Algorithm.SetParam(PIDDv.ParamTout, ConvertUtil.ConvertToDouble(this.spinParamTout.Value));
            Algorithm.SetParam(PIDDv.ParamTover, ConvertUtil.ConvertToDouble(this.spinParamTover.Value));
            Algorithm.SetParam(PIDDv.InputOvr1, ConvertUtil.ConvertToDouble(this.drpInputOvr1.Text));
            Algorithm.SetParam(PIDDv.InputOvr2, ConvertUtil.ConvertToDouble(this.drpInputOvr2.Text));
            Algorithm.SetParam(PIDDv.InputS1p, ConvertUtil.ConvertToDouble(this.drpInputS1p.Text));
            Algorithm.SetParam(PIDDv.InputS2p, ConvertUtil.ConvertToDouble(this.drpInputS2p.Text));
            Algorithm.SetParam(PIDDv.InputToM, ConvertUtil.ConvertToDouble(this.drpInputToM.Text));
            Algorithm.SetParam(PIDDv.InputReqA, ConvertUtil.ConvertToDouble(this.drpInputReqA.Text));
            Algorithm.SetParam(PIDDv.InputDmd1, ConvertUtil.ConvertToDouble(this.drpInputDmd1.Text));
            Algorithm.SetParam(PIDDv.InputDmd2, ConvertUtil.ConvertToDouble(this.drpInputDmd2.Text));
            Algorithm.SetParam(PIDDv.InputDmd3, ConvertUtil.ConvertToDouble(this.drpInputDmd3.Text));
            Algorithm.SetParam(PIDDv.InputFB1, ConvertUtil.ConvertToDouble(this.drpInputFB1.Text));
            Algorithm.SetParam(PIDDv.InputFB2, ConvertUtil.ConvertToDouble(this.drpInputFB2.Text));
            Algorithm.SetParam(PIDDv.InputFB3, ConvertUtil.ConvertToDouble(this.drpInputFB3.Text));
            Algorithm.SetParam(PIDDv.InputToTP, ConvertUtil.ConvertToDouble(this.drpInputToTP.Text));


            if (ctrlPointPicker1.Point != null)
                Algorithm.BindParam(radioGroup1.Text, BindSourceToken.PrefixVariable + ctrlPointPicker1.Point.Number);
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        public string BlockName
        {
            get { return "5.15设备驱动算法块"; }
        }

        private void simpleButton1_Click(object sender, System.EventArgs e)
        {

        }

    }
}
