using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Time
{
    public partial class CtrlParamSct : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamSct()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            //this.spinParamYear.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSct.ResultYear).Value);
            //this.spinParamMonth.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSct.ParamMonth).Value);
            //this.spinParamDay.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSct.ParamDay).Value);
            //this.spinParamHour.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSct.ParamHour).Value);
            //this.spinParamMinute.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSct.ParamMinute).Value);
            //this.spinParamScend.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSct.ParamScend).Value);
            //链接后不可用

        }

        public bool SaveParam()
        {
            //Algorithm.SetParam(PIDSct.ResultYear, ConvertUtil.ConvertToDouble(this.spinParamYear.Value));
            //Algorithm.SetParam(PIDSct.ParamMonth, ConvertUtil.ConvertToDouble(this.spinParamMonth.Value));
            //Algorithm.SetParam(PIDSct.ParamDay, ConvertUtil.ConvertToDouble(this.spinParamDay.Value));
            //Algorithm.SetParam(PIDSct.ParamHour, ConvertUtil.ConvertToDouble(this.spinParamHour.Value));
            //Algorithm.SetParam(PIDSct.ParamMinute, ConvertUtil.ConvertToDouble(this.spinParamMinute.Value));
            //Algorithm.SetParam(PIDSct.ParamScend, ConvertUtil.ConvertToDouble(this.spinParamScend.Value));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
 
    }
}
