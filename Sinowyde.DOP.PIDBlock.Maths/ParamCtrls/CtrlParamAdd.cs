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
using Sinowyde.DOP.PIDAlgorithm.Math;

namespace Sinowyde.DOP.PIDBlock.Math
{
    public partial class CtrlParamAdd : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamAdd()
        {
            InitializeComponent();
        }

        #region ICtrlParamBase
        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.UpdateParams(true, Algorithm);
            this.txt_inputAI1.Enabled = !Block.IsLinkLeftPort(PIDAdd.InputAI1);
            this.txt_inputAI2.Enabled = !Block.IsLinkLeftPort(PIDAdd.InputAI2);
            this.txt_inputAI3.Enabled = !Block.IsLinkLeftPort(PIDAdd.InputAI3);
            this.txt_inputAI4.Enabled = !Block.IsLinkLeftPort(PIDAdd.InputAI4);
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
