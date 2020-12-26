using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Control
{
    public partial class CtrlParamDms : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamDms()
        {
            InitializeComponent();
        }

        public PIDBindAlgorithm Algorithm { get; set; }

        public void LoadParam()
        {
            this.spinParamMO.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDms.ParamMO).Value);
            // this.spinParamMA.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDDms.ParamMA).Value);
            this.drpInputPV.Text = Algorithm.GetParam(PIDDms.InputPV).Value.ToString();
            this.drpInputSI.Text = Algorithm.GetParam(PIDDms.InputSI).Value.ToString();
            //链接后不可用
            this.drpInputPV.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDms.InputPV)) ? true : false;
            this.drpInputSI.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDms.InputSI)) ? true : false;


            if (!string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDms.InputPV)))
                groupControl1.Text = PIDDms.InputPV;
            else if (!string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDms.InputSI)))
                groupControl1.Text = PIDDms.InputSI;
            else if (!string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDms.ResultDO)))
                groupControl1.Text = PIDDms.ResultDO;
            else if (!string.IsNullOrEmpty(Algorithm.GetBindParam(PIDDms.ResultSO)))
                groupControl1.Text = PIDDms.ResultSO;
        }

        public void SaveParam()
        {
            Algorithm.SetParam(PIDDms.ParamMO, ConvertUtil.ConvertToDouble(this.spinParamMO.Value));
            //  Algorithm.SetParam(PIDDms.ParamMA, ConvertUtil.ConvertToDouble(this.spinParamMA.Value));
            Algorithm.SetParam(PIDDms.InputPV, ConvertUtil.ConvertToDouble(this.drpInputPV.Text));
            Algorithm.SetParam(PIDDms.InputSI, ConvertUtil.ConvertToDouble(this.drpInputSI.Text));
            if (ctrlPointPicker1.Point != null)
                Algorithm.BindParam(groupControl1.Text, BindSourceToken.PrefixVariable + ctrlPointPicker1.Point.Number);
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        public string BlockName
        {
            get { return "数字手动站算法块"; }
        }
    }
}
