using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.IO;
using Sinowyde.Util;
using System;
namespace Sinowyde.DOP.PIDBlock.IO
{
    public partial class CtrlParamAM : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamAM()
        {
            InitializeComponent();
            cpp_Variables.VarDirectionList.Clear();
            cpp_Variables.VarDirectionList.Add(DataModel.VarDirectionType.Calc);
            cpp_Variables.VarDirectionList.Add(DataModel.VarDirectionType.Temp);
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            cpp_Variables.RefreshData();
            cpp_Variables.VariableNumber = Algorithm.GetBindParam(PIDAM.Result);
            cpp_Variables.Enabled = !PIDGeneralBlock.IsRunning;
        }

        public bool SaveParam()
        {
            var p = cpp_Variables.CurrentVariable;
            if (p != null)
            {
                Algorithm.UnBindParam(PIDAM.Result);
                Algorithm.BindParam(PIDAM.Result, p.Number);
            }
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
    }
}
