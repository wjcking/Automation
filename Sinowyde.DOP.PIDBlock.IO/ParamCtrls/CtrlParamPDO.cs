using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.IO;
using Sinowyde.Util;
using Sinowyde.DataModel;

namespace Sinowyde.DOP.PIDBlock.IO
{
    public partial class CtrlParamPDO : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamPDO()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam() { }

        public bool SaveParam() { return true; }

        public UserControl GetParamCtrl() { return this; }

    }
}
