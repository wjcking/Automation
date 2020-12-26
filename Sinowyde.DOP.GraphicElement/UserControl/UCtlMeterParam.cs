using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;
using Sinowyde.Util;
using DevExpress.XtraEditors.Controls;
using Sinowyde.DOP.GraphicElement.Base;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Northwoods.Go.Instruments;
using Sinowyde.DOP.DataModel;
namespace Sinowyde.DOP.GraphicElement
{
    public partial class UCtlMeterParam : XtraUserControl, ICtrlParamBase
    {
        private DOPGraphElement dopGeneralShape = null;
        private Meter meter = null;

        public UCtlMeterParam()
        {
            InitializeComponent();
        }

        public UCtlMeterParam(DOPGraphElement generalShape)
        {
            InitializeComponent();
            this.dopGeneralShape = generalShape;
            meter = this.dopGeneralShape.First as Meter;
             
            cbBarOption.CheckedChanged += (sender, e) =>
            {
                xtraTabPage2.PageVisible = cbBarOption.Checked;
            };
        }

        public void LoadParam()
        {
            GoRectangle rec = meter.Background as GoRectangle;
            cBackColor.Color = rec.BrushColor;
            cbHideIndicator.Checked = meter.Indicator.Visible;
            cbHideScale.Checked = meter.Scale.Visible;

            //颠倒条形和厚度
            if (meter.GetType() == typeof(DOPBarMeter))
            {
                var dopBar = meter as DOPBarMeters;

                spinWidth.Value = (decimal)((IndicatorBar)meter.Indicator).Thickness;

                //if (meter.Orientation == Orientation.Vertical)
                //{
                //    rbDirection.SelectedIndex = 0;
                //    if (dopBar.IsBarUpsideDown)
                //        rbDirection.SelectedIndex = 1;
                //}

                //else if (meter.Orientation == Orientation.Horizontal)
                //{
                //    rbDirection.SelectedIndex = 2;

                //    if (dopBar.IsBarUpsideDown)
                //        rbDirection.SelectedIndex = 3;
                //}
                //cForeColor.Color = dopBar.BarColor;
            }
            else
            {
                cForeColor.Color = meter.Indicator.BrushColor;
            }
            spinFillMax.Value = (decimal)meter.Maximum;
            spinFillMin.Value = (decimal)meter.Minimum;
            spinMax.Value = (decimal)meter.Scale.Maximum;
            spinMin.Value = (decimal)meter.Scale.Minimum;
            spinValue.Value = (decimal)meter.Indicator.Value;
            spinFrequency.Value = (decimal)meter.TickMajorFrequency;
            spinUnit.Value = (decimal)meter.TickUnit;

            //var variable = dopGeneralShape.ActionScript[0].Variable[0];

            //uCtlGetVariable1.SelectedVariable = variable;

            //cbBarOption.Checked = dopGeneralShape.ActionScript[1].IsExcutedAction;
            //if (cbBarOption.Checked)
            //{
            //    // dopGeneralShape.ActionScript[1].IsExcutedAction = cbBarOption.Checked;
            //    // uCtlGetVariable2.ButtonText = dopGeneralShape.ActionScript[1].Variable[0].Number;
            //    uCtlGetVariable2.SelectedVariable = dopGeneralShape.ActionScript[1].Variable[0];
            //    uCtlValueColor1.VariableValue = dopGeneralShape.ActionScript[1].Condition;
            //    uCtlValueColor1.VariableColor = dopGeneralShape.ActionScript[1].Colors;
            //}
        }
        public bool SaveParam()
        {
            //if (string.IsNullOrEmpty(uCtlGetVariable1.SelectedVariable.Number))
            //{
            //    XtraMessageBox.Show(DOPDialog.ERROR_NullVar);
            //    return false;
            //}
            meter.Indicator.Visible = cbHideIndicator.Checked;
            meter.Scale.Visible = cbHideScale.Checked;
            //颠倒条形和厚度
            if (meter.GetType() == typeof(DOPBarMeters))
            {
                meter.Orientation = meter.Orientation == Orientation.Vertical ? Orientation.Horizontal : Orientation.Vertical;
                var dopBar = meter as DOPBarMeters;
                //if (rbDirection.SelectedIndex == 0)
                //{
                //    meter.Orientation = Orientation.Vertical;
                //    dopBar.IsBarUpsideDown = false;
                //}
                //else if (rbDirection.SelectedIndex == 1)
                //{
                //    meter.Orientation = Orientation.Vertical;
                //    dopBar.IsBarUpsideDown = true;
                //}
                //else if (rbDirection.SelectedIndex == 2)
                //{
                //    dopBar.IsBarUpsideDown = false;
                //    meter.Orientation = Orientation.Horizontal;
                //}
                //else if (rbDirection.SelectedIndex == 3)
                //{
                //    meter.Orientation = Orientation.Horizontal;
                //    dopBar.IsBarUpsideDown = true;
                //}
                //(meter as DOPBarMeters).BarColor = cForeColor.Color;
                ((IndicatorBar)meter.Indicator).Thickness = (float)spinWidth.Value;
            }
            GoRectangle rec = meter.Background as GoRectangle;
            rec.BrushColor = cBackColor.Color;

            meter.Maximum = (double)spinMax.Value;
            meter.Minimum = (double)spinMin.Value;
            meter.Scale.Maximum = (double)spinFillMax.Value;
            meter.Scale.Minimum = (double)spinFillMin.Value;
            meter.Indicator.BrushColor = cForeColor.Color;
            meter.TickMajorFrequency = (int)spinFrequency.Value;
            meter.TickUnit = (double)spinUnit.Value;
            meter.Indicator.Value = (double)spinValue.Value;
            meter.Value = (double)spinValue.Value;

            //dopGeneralShape.ActionScript[0].Variable[0] = uCtlGetVariable1.SelectedVariable;
            //dopGeneralShape.ActionScript[0].Variable[0].Number = uCtlGetVariable1.SelectedVariable.Number;
            //dopGeneralShape.ActionScript[0].IsExcutedAction = false;

            if (cbBarOption.Checked)
            {
                if (string.IsNullOrEmpty(uCtlGetVariable2.SelectedVariable.Number))
                {
                    xtraTabControl1.SelectedTabPageIndex = 1;
                    XtraMessageBox.Show(DOPDialog.ERROR_NullVar);
                    return false;
                }
                //dopGeneralShape.ActionScript[1].IsExcutedAction = true;
                //dopGeneralShape.ActionScript[1].Variable[0] = uCtlGetVariable2.SelectedVariable;
                //dopGeneralShape.ActionScript[1].Condition = uCtlValueColor1.VariableValue;
                //dopGeneralShape.ActionScript[1].Colors = uCtlValueColor1.VariableColor;
            }
            //else
            //    dopGeneralShape.ActionScript[1].IsExcutedAction = false;
            //meter.InvalidateViews();
            //dopGeneralShape.Refresh();

            return true;
        }

        public System.Windows.Forms.UserControl GetParamCtrl()
        {
            return this;
        }

    }
}
