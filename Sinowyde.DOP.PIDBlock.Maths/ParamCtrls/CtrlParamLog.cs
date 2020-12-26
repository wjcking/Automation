﻿using System;
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
    public partial class CtrlParamLog : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamLog()
        {
            InitializeComponent();
        }

        #region ICtrlParamBase
        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.UpdateParams(true, Algorithm);
            this.txt_inputAI.Enabled = !Block.IsLinkLeftPort(PIDLog.InputAI);
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

        private void txt_paramA_ValueChanged(object sender, EventArgs e)
        {
            if (txt_paramA.Value == 0 || this.txt_paramA.Value ==1)
                this.txt_paramA.Value = 0.1M;
        }
    }
}
