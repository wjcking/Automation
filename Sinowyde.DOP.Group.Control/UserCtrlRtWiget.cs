using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Sinowyde.DOP.Group.Control
{
    public partial class UserCtrlRtWiget : DevExpress.XtraEditors.XtraUserControl
    {
        private double variableValue = 0;
        private double? percentage = 0;
        private string variableName = string.Empty;

        /// <summary>
        /// 变量名
        /// </summary>
        public string VariableName
        {
            get { return variableName; }
            set 
            {
                variableName = value;
                //lbl_VariableName.Text = variableName;
            }
        }

        /// <summary>
        /// 变量值
        /// </summary>
        public double VariableValue
        {
            get { return variableValue; }
            set 
            {
                percentage = 0;

                double lastValue = this.variableValue;

                this.variableValue = value;

                if (!lastValue.Equals(0))
                {
                    percentage = ((this.variableValue - lastValue) / lastValue);
                }
                else
                {
                    percentage = null;
                }
                decimal before = Sinowyde.Util.ConvertUtil.ConvertToDecimal(percentage);
                decimal percentagedec = Math.Round(before, 2);

                //lable 赋值
                lbl_VariableValue.Text = this.variableValue.ToString("#0.00");
                if (percentagedec == null || percentagedec == 0)
                {
                    lbl_Percentage.Text = "";
                    lbl_PercentageImage.Appearance.Image = Sinowyde.DOP.Group.Control.Properties.Resources.none;
                }
                else if (percentagedec > 0)
                {
                    lbl_Percentage.Text = string.Format("+{0}%", percentagedec);
                    lbl_Percentage.ForeColor = Color.Green;
                    lbl_PercentageImage.Appearance.Image = Sinowyde.DOP.Group.Control.Properties.Resources.up;
                }
                else if (percentagedec < 0)
                {
                    lbl_Percentage.Text = string.Format("-{0}%", percentagedec);
                    lbl_Percentage.ForeColor = Color.Red;
                    lbl_PercentageImage.Appearance.Image = Sinowyde.DOP.Group.Control.Properties.Resources.down;
                }

                
            }

        }
        

    
        public UserCtrlRtWiget()
        {
            InitializeComponent();
        }
    }
}
