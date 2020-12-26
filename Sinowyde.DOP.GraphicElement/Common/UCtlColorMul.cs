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

namespace Sinowyde.DOP.GraphicElement
{
    public partial class UCtlColorMul : XtraUserControl
    {
        public UCtlColorMul()
        {
            InitializeComponent();
        }

        private List<Color> mulColor = null;
        public List<Color> MulColor
        {
            get 
            {
                mulColor = new List<Color>() { 
                    this.lblColor1.BackColor, 
                    this.lblColor2.BackColor, 
                    this.lblColor3.BackColor, 
                    this.lblColor4.BackColor, 
                    this.lblColor5.BackColor 
                };
                return mulColor;
            }
            set
            {
                mulColor = value;
                this.lblColor1.BackColor = mulColor[0];
                this.lblColor2.BackColor = mulColor[1];
                this.lblColor3.BackColor = mulColor[2];
                this.lblColor4.BackColor = mulColor[3];
                this.lblColor5.BackColor = mulColor[4];
            }
        }

        public IList<string> Condition
        {
            get
            {
                return new List<string>() { 
                    this.spinEditColorVar1.Text, 
                    this.spinEditColorVar2.Text, 
                    this.spinEditColorVar3.Text, 
                    this.spinEditColorVar4.Text,
                    this.spinEditColorVar5.Text
                };
            }
            set
            {
                this.spinEditColorVar1.Value = Convert.ToDecimal(value[0]);
                this.spinEditColorVar2.Value = Convert.ToDecimal(value[1]);
                this.spinEditColorVar3.Value = Convert.ToDecimal(value[2]);
                this.spinEditColorVar4.Value = Convert.ToDecimal(value[3]);
                this.spinEditColorVar5.Value = Convert.ToDecimal(value[4]);
            }
        }

        #region 改变颜色动画修改颜色事件
        private void lblColor1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.lblColor1.BackColor = GetColor(this.lblColor1.BackColor);
        }

        private void lblColor2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.lblColor2.BackColor = GetColor(this.lblColor2.BackColor);
        }

        private void lblColor3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.lblColor3.BackColor = GetColor(this.lblColor3.BackColor);
        }

        private void lblColor4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.lblColor4.BackColor = GetColor(this.lblColor4.BackColor);
        }

        private void lblColor5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.lblColor5.BackColor = GetColor(this.lblColor5.BackColor);
        }
        /// <summary>
        /// 取得颜色
        /// </summary>
        /// <param name="color">默认颜色</param>
        /// <returns></returns>
        private Color GetColor(Color color)
        {
            var colorDialog = new ColorDialog();
            colorDialog.Color = color;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                return colorDialog.Color;
            }
            return color;
        }
        #endregion
        

        
    }
}
