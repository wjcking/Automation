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
    public partial class CtrlParamDiv : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamDiv()
        {
            InitializeComponent();
        }
        #region ICtrlParamBase
        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.UpdateParams(true, Algorithm);
            this.txt_inputAI1.Enabled = !Block.IsLinkLeftPort(PIDDiv.InputAI1);
            this.txt_inputAI2.Enabled = !Block.IsLinkLeftPort(PIDDiv.InputAI2);
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
            if (this.txt_inputAI2.Value ==0)
            {
                XtraMessageBox.Show("除数为非零实数！");
                return false;
            }
            if (this.txt_paramK2.Value == 0)
            {
                XtraMessageBox.Show("系数k2为非零实数！");
                return false;
            }
            return true;
        }
    }
}
