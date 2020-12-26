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
using Sinowyde.Util;
using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using Sinowyde.DOP.PIDAlgorithm;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    public partial class CtrlParamRatio : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamRatio()
        {
            InitializeComponent();
        }
        #region ICtrlParamBase
        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.txtInputAL.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDRatio.inputAL).Value);
            this.txtInputDL.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDRatio.inputDL).Value);
            this.txt_inputAI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDRatio.inputAI).Value);
            this.txtInputAL.Enabled = !Block.IsLinkLeftPort(PIDRatio.inputAL);
            this.txtInputDL.Enabled = !Block.IsLinkLeftPort(PIDRatio.inputDL);
            this.txt_inputAI.Enabled = !Block.IsLinkLeftPort(PIDRatio.inputAI);
        }

        public bool SaveParam()
        {
            Algorithm.SetInputSourceValue(PIDRatio.inputAL, ConvertUtil.ConvertToDouble(this.txtInputAL.Value));
            Algorithm.SetInputSourceValue(PIDRatio.inputDL, ConvertUtil.ConvertToDouble(this.txtInputDL.Value));
            Algorithm.SetInputSourceValue(PIDRatio.inputAI, ConvertUtil.ConvertToDouble(this.txt_inputAI.Value));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
        #endregion

    }
}
