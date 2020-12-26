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
using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;
using Sinowyde.Util;
using Sinowyde.DOP.PIDAlgorithm;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    public partial class CtrlParamRange : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamRange()
        {
            InitializeComponent();
        }
        #region ICtrlParamBase
        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.txt_paramUL.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDRange.InputUL).Value);
            this.txt_paramDL.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDRange.InputDL).Value);
            this.txt_inputAI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDRange.InputAI).Value);
            this.txt_paramUL.Enabled = !Block.IsLinkLeftPort(PIDRange.InputUL);
            this.txt_paramDL.Enabled = !Block.IsLinkLeftPort(PIDRange.InputDL);
            this.txt_inputAI.Enabled = !Block.IsLinkLeftPort(PIDRange.InputAI);
        }

        public bool SaveParam()
        {
            if (!DataValidityChecked())
                return false;
            Algorithm.SetInputSourceValue(PIDRange.InputUL, ConvertUtil.ConvertToDouble(this.txt_paramUL.Value));
            Algorithm.SetInputSourceValue(PIDRange.InputDL, ConvertUtil.ConvertToDouble(this.txt_paramDL.Value));
            Algorithm.SetInputSourceValue(PIDRange.InputAI, ConvertUtil.ConvertToDouble(this.txt_inputAI.Value));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
        #endregion

        /// <summary>
        /// 数据校验
        /// </summary>
        /// <returns></returns>
        private bool DataValidityChecked()
        {
            //if (this.txt_paramUL.Value < this.txt_paramDL.Value)
            //{
            //    XtraMessageBox.Show("幅值上限不能小于幅值下限！");
            //    return false;
            //}
            return true;
        }
    }
}
