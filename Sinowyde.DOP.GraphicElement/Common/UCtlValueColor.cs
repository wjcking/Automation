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
    public partial class UCtlValueColor : XtraUserControl
    {
        private IList<string> variableValue = new List<string> { "0", "0", "0", "0", "0" };
        public IList<string> VariableValue
        {
            get
            {
                return variableValue;
            }
            set
            {
                variableValue = value;
                CreateControls();
            }
        }

        private List<Color> variableColor = new List<Color> { Color.Black, Color.Black, Color.Black, Color.Black, Color.Black };
        public List<Color> VariableColor 
        {
            get
            {
                return variableColor;
            }
            set 
            {
                variableColor = value;
                CreateControls();
            }
        }

        public UCtlValueColor()
        {
            InitializeComponent();
            CreateControls();
        }

        private void UCtlValueColor_Load(object sender, EventArgs e)
        {

        }

        private void CreateControls()
        {
            try
            {
                this.Controls.Clear();
                this.Controls.Add(new LabelControl() { Location = new Point(18, 0), Text = "变量值" });
                this.Controls.Add(new LabelControl() { Location = new Point(110, 0), Text = "颜色值" });
                for (int i = 0; i < variableColor.Count; i++)
                {
                    var spinValue = new SpinEdit()
                    {
                        Location = new Point(0, i * 26 + 20),
                        Size = new Size(72, 20),
                        Value = VariableValue.Count <= VariableColor.Count ?  ConvertUtil.ConvertToDecimal(VariableValue[i]):0, 
                        Tag = i
                    };
                    spinValue.EditValueChanged += (sender, e) =>
                    {
                        VariableValue[ConvertUtil.ConvertToInt(spinValue.Tag)] = spinValue.Value.ToString();
                    };
                    this.Controls.Add(spinValue);
                    var colorEdit = new ColorEdit()
                    {
                        Location = new Point(90, spinValue.Top),
                        Size = new Size(86, 20),
                        Color =  VariableColor[i],
                        Tag = i
                    };
                    colorEdit.EditValueChanged += (sender, e) =>
                    {
                        variableColor[ConvertUtil.ConvertToInt(colorEdit.Tag)] = colorEdit.Color;
                    };  
                    this.Controls.Add(colorEdit);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}
