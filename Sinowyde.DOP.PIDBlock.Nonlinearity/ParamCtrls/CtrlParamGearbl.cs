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

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    public partial class CtrlParamGearbl : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamGearbl()
        {
            InitializeComponent();
        }

        #region ICtrlParamBase
        public string BlockName
        {
            get { return "齿轮间隙算法块"; }
        }
        public PIDAlgorithm.PIDBindAlgorithm Algorithm
        {
            get;
            set;
        }

        public void LoadParam()
        {
            this.UpdateParams(true, Algorithm);
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
