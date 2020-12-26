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

namespace Sinowyde.DOP.GraphicElement
{
    public partial class UCtlColor : XtraUserControl
    {
        private List<Color> colors = new List<Color>();
        public List<Color> Colors 
        {
            get
            {
                return colors;
            }
            set
            {
                colors = value;
                CreateControls();
            }
        }

        private List<string> labels = new List<string>();
        [Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> Labels 
        {
            get
            {
                return labels;
            }
            set
            {
                labels = value;
            }
        
        }

        public UCtlColor()
        {
            InitializeComponent();
            colors = new List<Color>() { Color.Blue, Color.Red };
            labels = new List<string>() { "0", "1" };
            CreateControls();
        }

        private void UCtlColor_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 创建控件
        /// </summary>
        private void CreateControls()
        {
            this.panelControl.Controls.Clear();
            for (int i = 0; i < colors.Count; i++)
            {
                var w = this.panelControl.Width / Colors.Count;
                var labelControl = new LabelControl()
                {
                    AutoSizeMode = LabelAutoSizeMode.None,
                    BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple,
                    Location = new Point(i * w, 0),
                    Size = new Size(w, 23),
                    BackColor = colors.Count>=labels.Count ?colors[i]:Color.White,
                    Tag = i
                };
                labelControl.MouseDoubleClick += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        labelControl.BackColor = GetColor(labelControl.BackColor);
                        Colors[ConvertUtil.ConvertToInt(labelControl.Tag)] = labelControl.BackColor;
                    }
                };               
                this.panelControl.Controls.Add(labelControl);
                var labelControlValue = new LabelControl()
                {
                    Location = new Point(labelControl.Left + w/2-5, 28),
                    Text = labels.Count>=colors.Count ? labels[i]:"0", 
                };
                this.panelControl.Controls.Add(labelControlValue);
            }
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

        private void panelControl_Resize(object sender, EventArgs e)
        {
            CreateControls();
        }
    }
}
