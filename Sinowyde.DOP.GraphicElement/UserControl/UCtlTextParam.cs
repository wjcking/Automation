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
using Northwoods.Go;
using Sinowyde.Util;
using DevExpress.XtraEditors.Controls;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.GraphicElement.Base.Action;

namespace Sinowyde.DOP.GraphicElement
{
    public partial class UCtlTextParam : XtraUserControl, ICtrlParamBase
    {
        private DOPGraphElement dopGraphElement = null;
        private Font txtFont = null;

        public UCtlTextParam()
        {
            InitializeComponent();
        }

        public UCtlTextParam(DOPGraphElement GraphElement)
        {
            InitializeComponent();
            this.dopGraphElement = GraphElement;
            txtFont = new Font("宋体",12);
        }

        #region 方法定义
        /// <summary>
        /// 加载控件数据
        /// </summary>
        private void LoadControlData()
        {
            BaseControlDataInit();
            if (this.dopGraphElement.GraphActionMap.Count < 1) return;
            DynamicDataInit();
        }

        /// <summary>
        /// 保存参数信息
        /// </summary>
        private bool SaveParamInfo()
        {
            //var goText = this.dopGraphElement.First as GoText;
            //this.dopGraphElement.ActionScript.Clear();
            //ConditionAction conditionAction = null;
            //if (chkData.Checked)
            //{
            //    conditionAction = BindDataPoint();
            //    if (conditionAction == null)
            //        return false;
            //    this.dopGraphElement.ActionScript.Add(conditionAction);
            //    if (chkFontColor.Checked)
            //    {
            //        conditionAction = FontColorAnimation();
            //        if (conditionAction == null)
            //            return false;
            //        this.dopGraphElement.ActionScript.Add(conditionAction);
            //    }
            //    if (chkFontBackColor.Checked)
            //    {
            //        conditionAction = FontBackColorAnimation();
            //        if (conditionAction == null)
            //            return false;
            //        this.dopGraphElement.ActionScript.Add(conditionAction);
            //    }
            //    if (this.spinEditDataFormat.Value > 0)
            //    {
            //        this.txtText.Text = "####.".PadRight(5 + ConvertUtil.ConvertToInt(this.spinEditDataFormat.Value), '#');
            //    }
            //    else {
            //        this.txtText.Text = "####.#";
            //    }
            //}
            //else {
            //    if (this.txtText.Text.Contains("#.#"))
            //        this.txtText.Text = "文本";
            //}
            //if (chkSwitch.Checked)
            //{
            //    switch(radioGroupSwitch.SelectedIndex)
            //    {
            //        case 0:
            //            conditionAction = DataPointAnimation();
            //            break;
            //        case 1:
            //            conditionAction = PackageAnimation();
            //            break;
            //        default:
            //            break;
            //    }
            //    if (conditionAction == null)
            //        return false;
            //    this.dopGraphElement.ActionScript.Add(conditionAction);
            //}
            //if (chkData.Checked || this.chkSwitch.Checked)
            //{
            //    if (conditionAction == null)
            //    {
            //        return false;
            //    }
            //}
            //goText.Text = this.txtText.Text;
            //goText.Font = txtFont;
            //goText.TextColor = this.colorEditForeColor.Color;
            //goText.TransparentBackground = this.chkIsTransparent.Checked;
            //goText.BackgroundColor = this.colorEditBackGroundColor.Color;
            //if (this.chkMulRow.Checked)
            //{
            //    goText.Multiline = true;
            //    StringBuilder s = new StringBuilder();
            //    foreach (var c in this.txtText.Text)
            //    {
            //        s.AppendLine(c.ToString());
            //    }
            //    goText.Text = s.ToString();
            //}
            //else
            //{
            //    goText.Multiline = false;
            //}
            return true;
        }
        #endregion

        #region ICtrlParamBase 成员

        public void LoadParam()
        {
            LoadControlData();
        }

        public bool SaveParam()
        {
            return SaveParamInfo();
        }

        public System.Windows.Forms.UserControl GetParamCtrl()
        {
            return this;
        }

        #endregion

        #region 静态文本
        private void BaseControlDataInit()
        {
            var goText = this.dopGraphElement.First as GoText;
            this.txtText.Text = goText.Text.Replace("\r\n","");
            txtFont = goText.Font;
            this.colorEditForeColor.Color = goText.TextColor;
            this.chkIsTransparent.Checked = goText.TransparentBackground;
            this.colorEditBackGroundColor.Color = goText.BackgroundColor;
            this.chkMulRow.Checked = goText.Multiline;
        }

        /// <summary>
        /// 字体样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleBtnFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = this.txtFont==null?this.txtText.Font:this.txtFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                //this.txtText.Font = fontDialog.Font;
                txtFont = fontDialog.Font;
            }
        }

        /// <summary>
        /// 字体颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorEditForeColor_ColorChanged(object sender, EventArgs e)
        {
            //this.txtText.ForeColor = this.colorEditForeColor.Color;
            //(this.dopGraphElement.First as GoText).TextColor = this.colorEditForeColor.Color;
        }

        private void chkData_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkData.Checked)
            {
                this.chkSwitch.Checked = false;
            }
            else {
                uCtlGetVarBind.SelectedVariable = null;
                this.txtText.Text = "文本";
            }
            this.xtraTabPageData.PageVisible = this.chkData.Checked;
        }

        private void chkSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSwitch.Checked)
            {
                this.chkData.Checked = false;
            }
            else {
                uCtlGetVarSwitch.SelectedVariable = null;
            }
            this.xtraTabPageSwitch.PageVisible = this.chkSwitch.Checked;
        }
        #endregion

        #region 动态数据点
        private void DynamicDataInit()
        {
            this.dopGraphElement.GraphActionMap.Where(v => v.Key == ActionExpression.TextAction).ToList()
                .ForEach(s =>
                {
                    switch (s.Value.VarType)
                    {
                        //case LinkType.Text:
                        //    this.chkData.Checked = s.IsExcutedAction;
                        //    this.lblVariableDataPoint.Text = s.Variable[0].Name;
                        //    this.uCtlGetVarBind.SelectedVariable = s.Variable[0];
                        //    this.chkShowUnit.Checked = s.IsShowUnit;
                        //    this.spinEditDataFormat.Value = ConvertUtil.ConvertToDecimal(s.DataFormat);
                        //    break;
                        //case LinkType.ForeColor:
                        //    this.chkData.Checked = s.IsExcutedAction;
                        //    this.chkFontColor.Checked = s.IsExcutedAction;
                        //    this.uCtlGetVarFontColor.SelectedVariable = s.Variable[0];
                        //    this.uCtlFontColor.VariableColor = s.Colors;
                        //    this.uCtlFontColor.VariableValue = s.Condition;
                        //    break;
                        //case LinkType.BackColor:
                        //    this.chkData.Checked = s.IsExcutedAction;
                        //    this.chkFontBackColor.Checked = s.IsExcutedAction;
                        //    this.uCtlGetVarFontBackColor.SelectedVariable = s.Variable[0];
                        //    this.uCtlFontBackColor.VariableColor = s.Colors;
                        //    this.uCtlFontBackColor.VariableValue = s.Condition;
                        //    break;
                        //case LinkType.DataPoint:
                        //    chkSwitch.Checked = s.IsExcutedAction;
                        //    this.lblVariableSwitch.Text = s.Variable[0].Name;
                        //    this.radioGroupSwitch.SelectedIndex = 0;
                        //    this.uCtlGetVarSwitch.SelectedVariable = s.Variable[0];
                        //    this.uCtlHValueColor1.Expression = s.Condition[0];
                        //    this.uCtlHValueColor1.color = s.Colors[0];
                        //    this.uCtlHValueColor1.BackColor = s.Colors[1];
                        //    this.uCtlHValueColor2.Expression = s.Condition[1];
                        //    this.uCtlHValueColor2.color = s.Colors[2];
                        //    this.uCtlHValueColor2.BackColor = s.Colors[3];
                        //    break;
                        //case LinkType.Package:
                        //    chkSwitch.Checked = s.IsExcutedAction;
                        //    this.lblVariableSwitch.Text = s.Variable[0].Name;
                        //    this.radioGroupSwitch.SelectedIndex = 1;
                        //    break;
                        default:
                            break;
                    }
                });
        }

        /// <summary>
        /// 字体颜色复选框选中后，控件有效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkFontColor_CheckedChanged(object sender, EventArgs e)
        {
            this.panelCtlFontColor.Enabled = this.chkFontColor.Checked;
        }
        /// <summary>
        /// 字体背景颜色复选框选中后，控件有效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkFontBackColor_CheckedChanged(object sender, EventArgs e)
        {
            this.panelCtlFontBackColor.Enabled = this.chkFontBackColor.Checked;
        }

        //private ConditionAction BindDataPoint()
        //{
        //    if (this.uCtlGetVarBind.SelectedVariable == null || this.uCtlGetVarBind.SelectedVariable.Number == null)
        //    {
        //        XtraMessageBox.Show("请选择变量！");
        //        return null;
        //    }
        //    IList<Variable> lstVariable = new List<Variable>();
        //    lstVariable.Add(this.uCtlGetVarBind.SelectedVariable);

        //    var conditionAction = new ConditionAction()
        //    {
        //        Variable = lstVariable, 
        //        LinkType = LinkType.Text, 
        //        ActionType = ActionType.Text,
        //        IsExcutedAction = true,
        //        IsShowUnit = chkShowUnit.Checked,
        //        DataFormat = ConvertUtil.ConvertToInt(spinEditDataFormat.Value)
        //    };
        //    return conditionAction;
        //}

        ///// <summary>
        ///// 字体颜色
        ///// </summary>
        //private ConditionAction FontColorAnimation()
        //{
        //    if (this.uCtlGetVarFontColor.SelectedVariable == null || this.uCtlGetVarFontColor.SelectedVariable.Number == "")
        //    {
        //        XtraMessageBox.Show("请选择变量！");
        //        return null;
        //    }
        //    IList<Variable> lstVariable = new List<Variable>();
        //    lstVariable.Add(this.uCtlGetVarFontColor.SelectedVariable);
        //    var conditionAction = new ConditionAction()
        //    {
        //        Condition = uCtlFontColor.VariableValue,
        //        Colors = uCtlFontColor.VariableColor,
        //        Variable = lstVariable,
        //        LinkType = LinkType.ForeColor,
        //        ActionType = ActionType.Text,
        //        IsExcutedAction = true
        //    };
        //    return conditionAction;
        //}

        ///// <summary>
        ///// 字体背景色
        ///// </summary>
        //private ConditionAction FontBackColorAnimation()
        //{
        //    if (this.uCtlGetVarFontBackColor.SelectedVariable == null || this.uCtlGetVarFontBackColor.SelectedVariable.Number == "")
        //    {
        //        XtraMessageBox.Show("请选择变量！");
        //        return null;
        //    }
        //    IList<Variable> lstVariable = new List<Variable>();
        //    lstVariable.Add(this.uCtlGetVarFontBackColor.SelectedVariable);
        //    var conditionAction = new ConditionAction()
        //    {
        //        Condition = uCtlFontBackColor.VariableValue,
        //        Colors = uCtlFontBackColor.VariableColor,
        //        Variable = lstVariable,
        //        LinkType = LinkType.BackColor,
        //        ActionType = ActionType.Text,
        //        IsExcutedAction = true
        //    };
        //    return conditionAction;
        //}
        #endregion

        #region 开关量
        /// <summary>
        /// 数据点与打包点选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioGroupSwitch_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (radioGroupSwitch.SelectedIndex)
            { 
                case 0:
                    panelCtlPackage.Enabled = false;
                    break;
                case 1:
                    panelCtlPackage.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        //private ConditionAction DataPointAnimation()
        //{
        //    if (this.uCtlGetVarFontColor.SelectedVariable == null || this.uCtlGetVarFontColor.SelectedVariable.Number == "")
        //    {
        //        XtraMessageBox.Show("请选择变量！");
        //        return null;
        //    }
        //    IList<Variable> lstVariable = new List<Variable>();
        //    lstVariable.Add(this.uCtlGetVarSwitch.SelectedVariable);
        //    IList<string> expression = new List<string>();
        //    expression.Add(uCtlHValueColor1.Expression);
        //    expression.Add(uCtlHValueColor2.Expression);
        //    IList<string> condition = new List<string>();
        //    condition.Add("0");
        //    condition.Add("1");
        //    List<Color> colors = new List<Color>();
        //    colors.Add(uCtlHValueColor1.color);
        //    colors.Add(uCtlHValueColor1.BackColor);
        //    colors.Add(uCtlHValueColor2.color);
        //    colors.Add(uCtlHValueColor2.BackColor);
        //    var conditionAction = new ConditionAction()
        //    {
        //        Condition =condition,
        //        Expression = expression,
        //        Colors = colors,
        //        Variable = lstVariable,
        //        LinkType = LinkType.DataPoint,
        //        ActionType = ActionType.Text,
        //        IsExcutedAction = true
        //    };
        //    return conditionAction;
        //}

        //private ConditionAction PackageAnimation()
        //{
        //    if (this.uCtlGetVarFontColor.SelectedVariable == null || this.uCtlGetVarFontColor.SelectedVariable.Number == "")
        //    {
        //        XtraMessageBox.Show("请选择变量！");
        //        return null;
        //    }
        //    var conditionAction = new ConditionAction()
        //    {
        //        //Condition = condition,
        //        //Expression = expression,
        //        //Colors = colors,
        //        //Variable = lstVariable,
        //        LinkType = LinkType.Package, 
        //        ActionType = ActionType.Text, 
        //        IsExcutedAction =true
        //    };
        //    return conditionAction;
        //}
        #endregion

        private void chkIsTransparent_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
