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
using Sinowyde.DOP.GraphicElement.Base;
using Northwoods.Go.Instruments;
using Sinowyde.Util;
using Northwoods.Go;
using Sinowyde.DOP.DataModel;

namespace Sinowyde.DOP.GraphicElement
{
    public partial class UCtlBarMeterParam : XtraUserControl, ICtrlParamBase
    {
        private DOPGraphElement dopGraphElement = null;

        public UCtlBarMeterParam()
        {
            InitializeComponent();
        }

        public UCtlBarMeterParam(DOPGraphElement graphElement)
        {
            InitializeComponent();
            dopGraphElement = graphElement;
        }

        #region ICtrlParamBase 成员


        public void LoadParam()
        {
            BaseControlDataInit();
            //if (this.dopGraphElement.ActionScript == null || this.dopGraphElement.ActionScript.Count < 1) return;
            //ColorAnimationInit();
        }

        public bool SaveParam()
        {
            if (this.uCtlGetVarBar.SelectedVariable == null ||
               string.IsNullOrEmpty(this.uCtlGetVarBar.SelectedVariable.Number))
            {
                XtraMessageBox.Show("请选择变量！");
                return false;
            }
            if (this.spinMin.Value > this.spinMax.Value)
            {
                XtraMessageBox.Show("最小值不能大于最大值！");
                return false;
            }
            if (this.spinFillMin.Value > this.spinFillMax.Value)
            {
                XtraMessageBox.Show("最小值不能大于最大值！");
                return false;
            }
            var obj = this.dopGraphElement.First as Meter;
            (obj.Background as GoRectangle).BrushColor = this.colorBackColor.Color;
            obj.Maximum = ConvertUtil.ConvertToDouble(spinMax.Value);
            obj.Minimum = ConvertUtil.ConvertToDouble(spinMin.Value);
            obj.Indicator.BrushColor = this.colorForeColor.Color;
            obj.Value = 0;
            obj.Orientation = this.rbDirection.SelectedIndex == 1 ? Orientation.Horizontal : Orientation.Vertical;
            //颜色动画
            //this.dopGraphElement.ActionScript.Clear();
            //var bias = (this.spinFillMax.Value - this.spinFillMin.Value) / 100;
            //var offset = (this.spinMax.Value - this.spinMin.Value) * this.spinFillMin.Value / 100;
            //this.dopGraphElement.ActionScript.Add(new ConditionAction()
            //{
            //    Condition = new List<string>() { spinFillMax.Value.ToString(), spinFillMin.Value.ToString(), bias.ToString(), offset.ToString() },
            //    Variable = new Variable[1] { this.uCtlGetVarBar.SelectedVariable },
            //    IsExcutedAction = true,
            //    ActionType = ActionType.Meter
            //});
            //if (this.cbBarOption.Checked)
            //{
            //    ConditionAction conditionAction = ColorAOAnimation() ;
            //    if (conditionAction == null)
            //    {
            //        return false;
            //    }
            //    else {
            //        this.dopGraphElement.ActionScript.Add(conditionAction);
            //    }
            //}
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        #endregion
        /// <summary>
        /// 基本属性初始化
        /// </summary>
        private void BaseControlDataInit()
        {
            var obj = this.dopGraphElement.First as Meter;

            spinMax.Value = ConvertUtil.ConvertToDecimal(obj.Maximum);
            spinMin.Value = ConvertUtil.ConvertToDecimal(obj.Minimum);
            this.colorForeColor.Color = obj.Indicator.BrushColor;
            this.colorBackColor.Color = (obj.Background as GoRectangle).BrushColor;
            this.rbDirection.SelectedIndex = obj.Orientation == Orientation.Horizontal ? 1 : 0;
        }
        ///// <summary>
        ///// 颜色动画初始化
        ///// </summary>
        //private void ColorAnimationInit()
        //{
        //    this.dopGraphElement.ActionScript.Where(v => v.ActionType == ActionType.Meter).ToList()
        //        .ForEach(s =>
        //        {
        //            uCtlGetVarBar.SelectedVariable = s.Variable[0];
        //            spinFillMax.Value = ConvertUtil.ConvertToDecimal(s.Condition[0]);
        //            spinFillMin.Value = ConvertUtil.ConvertToDecimal(s.Condition[1]);
        //        });
        //    this.dopGraphElement.ActionScript.Where(v => v.ActionType == ActionType.ChangeColor).ToList()
        //        .ForEach(s => 
        //        {

        //            uCtlGetVarFill.SelectedVariable = s.Variable[0];
        //            uCtlValueColorFill.VariableValue = s.Condition;
        //            uCtlValueColorFill.VariableColor = s.Colors;
        //            cbBarOption.Checked = s.IsExcutedAction;
        //        });
        //}

        ///// <summary>
        ///// 模拟量
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private ConditionAction ColorAOAnimation()
        //{
        //    if (this.uCtlGetVarFill.SelectedVariable == null ||
        //        string.IsNullOrEmpty(this.uCtlGetVarFill.SelectedVariable.Number))
        //    {
        //        XtraMessageBox.Show("请选择变量！");
        //        return null;
        //    }
        //    IList<Variable> lstVariable = new List<Variable>();
        //    lstVariable.Add(this.uCtlGetVarFill.SelectedVariable);
        //    var conditionAction = new ConditionAction()
        //    {
        //        Condition = uCtlValueColorFill.VariableValue,
        //        Colors = uCtlValueColorFill.VariableColor,
        //        Variable = lstVariable,
        //        LinkType = LinkType.AO,
        //        ActionType = ActionType.ChangeColor,
        //        IsExcutedAction = true,
        //        DefaultColor = colorForeColor.Color
        //    };
        //    return conditionAction;
        //}

        private void cbBarOption_CheckStateChanged(object sender, EventArgs e)
        {
            this.xtraTabPageFill.PageVisible = this.cbBarOption.Checked;
        }

    }
}
