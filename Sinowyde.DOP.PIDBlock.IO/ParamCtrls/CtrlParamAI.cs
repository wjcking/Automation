using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.IO;
using Sinowyde.Util;
using Sinowyde.DataModel;
using System;

namespace Sinowyde.DOP.PIDBlock.IO
{
    public partial class CtrlParamAI : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamAI()
        {
            InitializeComponent();
            ctrlPointPicker1.DefaultVariabelType = DataModel.VariableType.AM;
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            ctrlPointPicker1.RefreshData();
            ctrlPointPicker1.VariableNumber = Algorithm.GetBindParam(PIDAI.InputAI);
            ctrlPointPicker1.Enabled = !PIDGeneralBlock.IsRunning;
        }

        public bool SaveParam()
        {
            var p = ctrlPointPicker1.CurrentVariable;
            if (p != null)
            {
                Algorithm.UnBindParam(PIDAI.InputAI);
                Algorithm.BindParam(PIDAI.InputAI, p.Number);
            }
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
    }
}
