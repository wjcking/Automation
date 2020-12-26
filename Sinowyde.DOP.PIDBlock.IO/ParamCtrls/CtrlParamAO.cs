using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.IO;
using Sinowyde.Util;
using System;
namespace Sinowyde.DOP.PIDBlock.IO
{
    public partial class CtrlParamAO : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamAO()
        {
            InitializeComponent();
            cpp_Variables.VarDirectionList.Clear();
            cpp_Variables.VarDirectionList.Add(DataModel.VarDirectionType.Write);
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            cpp_Variables.RefreshData();
            cpp_Variables.VariableNumber = Algorithm.GetBindParam(PIDAO.Result);
            cpp_Variables.Enabled = !PIDGeneralBlock.IsRunning;
        }

        public bool SaveParam()
        {
            var p = cpp_Variables.CurrentVariable;
            if (p != null)
            {
                Algorithm.UnBindParam(PIDAO.Result);
                Algorithm.BindParam(PIDAO.Result, p.Number);
            }
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

    }
}
