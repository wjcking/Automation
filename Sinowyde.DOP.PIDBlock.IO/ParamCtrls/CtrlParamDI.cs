using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.IO;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.IO
{
    public partial class CtrlParamDI : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamDI()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            cpp_Variables.RefreshData();
            cpp_Variables.VariableNumber = Algorithm.GetBindParam(PIDDI.InputDI);
            cpp_Variables.Enabled = !PIDGeneralBlock.IsRunning;
        }

        public bool SaveParam()
        {
            var p = cpp_Variables.CurrentVariable;
            if (p != null)
            {
                Algorithm.UnBindParam(PIDDI.InputDI);
                Algorithm.BindParam(PIDDI.InputDI, p.Number);
            }
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
    }
}
