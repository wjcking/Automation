using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Time
{
    public partial class CtrlParamCycle : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamCycle()
        {
            InitializeComponent();
        }

        public PIDBindAlgorithm Algorithm { get; set; }

        public void LoadParam()
        {

            this.spinParamMonth.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDCycle.ParamMonth).Value);
            this.spinParamDay.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDCycle.ParamDay).Value);
            this.spinParamHour.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDCycle.ParamHour).Value);
            this.spinParamMinute.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDCycle.ParamMinute).Value);
            this.spinParamScend.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDCycle.ParamScend).Value);
            //链接后不可用
        }

        public void SaveParam()
        {
         

            Algorithm.SetParam(PIDCycle.ParamMonth, ConvertUtil.ConvertToDouble(this.spinParamMonth.Value));
            Algorithm.SetParam(PIDCycle.ParamDay, ConvertUtil.ConvertToDouble(this.spinParamDay.Value));
            Algorithm.SetParam(PIDCycle.ParamHour, ConvertUtil.ConvertToDouble(this.spinParamHour.Value));
            Algorithm.SetParam(PIDCycle.ParamMinute, ConvertUtil.ConvertToDouble(this.spinParamMinute.Value));
            Algorithm.SetParam(PIDCycle.ParamScend, ConvertUtil.ConvertToDouble(this.spinParamScend.Value));

        }
        //public void LoadParam()
        //{
        //    this.spinParamEndTime.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDCycle.ParamEndTime).Value);
        //    this.spinParamMODE.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDCycle.ParamMODE).Value);
        //    this.spinParamPV.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDCycle.ParamPV).Value);
        //    this.spinParamRS.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDCycle.ParamRS).Value);
        //    this.drpInputSet.Text = Algorithm.GetParam(PIDCycle.InputSET).Value.ToString();
        //   //链接后不可用
        //    this.drpInputSet.Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(PIDCycle.InputSET)) ? true : false;
 
        //}

        //public void SaveParam()
        //{
        //    Algorithm.SetParam(PIDCycle.InputSET, ConvertUtil.ConvertToDouble(this.drpInputSet.Text));
        //    Algorithm.SetParam(PIDCycle.ParamEndTime, ConvertUtil.ConvertToDouble(this.spinParamEndTime.Value));
        //    Algorithm.SetParam(PIDCycle.ParamMODE, ConvertUtil.ConvertToDouble(this.spinParamMODE.Value));
        //    Algorithm.SetParam(PIDCycle.ParamPV, ConvertUtil.ConvertToDouble(this.spinParamPV.Value));
        //    Algorithm.SetParam(PIDCycle.ParamRS, ConvertUtil.ConvertToDouble(this.spinParamRS.Value));
        //}

        public UserControl GetParamCtrl()
        {
            return this;
        }

        public string BlockName
        {
            get { return "周期定时器算法块"; }
        }
    }
}
