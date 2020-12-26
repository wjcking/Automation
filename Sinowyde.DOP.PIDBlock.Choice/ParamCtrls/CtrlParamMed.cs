using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Choice;
using Sinowyde.Util;
using System;

namespace Sinowyde.DOP.PIDBlock.Choice
{
    public partial class CtrlParamMed : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamMed()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam() { }

        public bool SaveParam() { return true; }

        public UserControl GetParamCtrl()
        {
            return this;
        }

    }
}
