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
    public partial class CtrlParamRangeAlm : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamRangeAlm()
        {
            InitializeComponent();
        }
        #region ICtrlParamBase
        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.UpdateParams(true, Algorithm);
            this.txt_inputAI.Enabled = !Block.IsLinkLeftPort(PIDRangeAlm.inputAI);
        }

        public bool SaveParam()
        {
            if (!DataValidityChecked())
                return false;
            this.UpdateParams(false, Algorithm);
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
            if (this.txt_paramHigh.Value < this.txt_paramLow.Value)
            {
                XtraMessageBox.Show("报警上限不能小于报警下限！");
                return false;
            }
            return true;
        }
    }
}
