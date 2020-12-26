using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    public partial class CtrlParamMagamp : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamMagamp()
        {
            InitializeComponent();
        }
        #region ICtrlParamBase
        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.UpdateParams(true, Algorithm);
            this.txt_inputAI.Enabled = !Block.IsLinkLeftPort(PIDMagAmp.InputAI);
        }

        public bool SaveParam()
        {
            this.UpdateParams(false, Algorithm);
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        #endregion
    }
}
