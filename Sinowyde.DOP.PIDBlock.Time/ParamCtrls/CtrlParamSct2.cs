using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Time;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Time
{
    public partial class CtrlParamSct2 : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamSct2()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
          //  this.spinParamSAO.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDSct2.ParamSAO).Value);
//链接后不可用

        }

        public bool SaveParam()
        {
           // Algorithm.SetParam(PIDSct2.ParamSAO,  ConvertUtil.ConvertToDouble(this.spinParamSAO.Value));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
 
    }
}
