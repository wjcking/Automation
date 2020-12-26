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
    public partial class UCtlGraphParam :  XtraUserControl,ICtrlParamBase
    {
        private DOPGraphElement dopGraphElement = null;
        private IDictionary<int, GoBrushStyle> brushStyle = new Dictionary<int, GoBrushStyle>();

        public UCtlGraphParam()
        {
            InitializeComponent();
        }

        public UCtlGraphParam(DOPGraphElement graphElement)
        {
            InitializeComponent();
            dopGraphElement = graphElement;
        }

        #region ICtrlParamBase 成员

        public void LoadParam()
        {
            if (this.dopGraphElement.First is GoShape)
            {
                LoadBrushStyle();
                LoadLineStyle();
            }
            else
            {
                this.groupCtrlBase.Enabled = false;
                this.chkColor.Enabled = false;
            }
            LoadControlData();
        }

        public bool SaveParam()
        {
            return SaveParamInfo();
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        #endregion

        #region 方法定义
        /// <summary>
        /// 加载控件数据
        /// </summary>
        private void LoadControlData()
        {
            BaseControlDataInit();
            if (this.dopGraphElement.GraphActionMap == null || this.dopGraphElement.GraphActionMap.Count < 1) return;
            if (this.dopGraphElement.First is GoShape)
                ColorAnimationInit();
            FlashAnimationInit();
            HideAnimationInit();
            MoveAnimationInit();
        }

        /// <summary>
        /// 加载填充样式
        /// </summary>
        private void LoadBrushStyle()
        {
            brushStyle.Add(0, GoBrushStyle.None);           //透明
            brushStyle.Add(1, GoBrushStyle.Solid);          //带背景色
            brushStyle.Add(2, GoBrushStyle.HatchCross);     //网格正
            brushStyle.Add(3, GoBrushStyle.HatchWideDownwardDiagonal);   //斜线左
            brushStyle.Add(4, GoBrushStyle.HatchWideUpwardDiagonal);   //斜线右
            brushStyle.Add(5, GoBrushStyle.HatchOutlinedDiamond);   //网格斜
            brushStyle.Add(6, GoBrushStyle.DoubleEdgeGradientVertical);   //水平渐变
            brushStyle.Add(7, GoBrushStyle.DoubleEdgeGradientHorizontal);   //垂直渐变
            for (Int16 i = 0; i < brushStyle.Count; i++)
            {
                imgCboEditBrushStyle.Properties.Items.Add(new ImageComboBoxItem("", brushStyle[i], i));
            }
        }

        /// <summary>
        /// 加载线样式
        /// </summary>
        private void LoadLineStyle()
        {
            this.imgCboEditLineStyle.Properties.SmallImages = this.imageCollectionLine;
            for (int i = 1; i < 7; i++)
            {
                this.imgCboEditLineStyle.Properties.Items.Add(new ImageComboBoxItem(i.ToString(), i, i - 1));
            }
        }

        /// <summary>
        /// 保存参数信息
        /// </summary>
        private bool SaveParamInfo()
        {
            if (this.dopGraphElement.First is GoShape)
            {
                var dopGeneralShape = this.dopGraphElement.First as GoShape;
                dopGeneralShape.BrushColor = this.colorEditBrushColor.Color;
                dopGeneralShape.PenColor = this.colorEditPenColor.Color;
                dopGeneralShape.BrushStyle = (GoBrushStyle)this.imgCboEditBrushStyle.EditValue;
                dopGeneralShape.PenWidth = ConvertUtil.ConvertToFloat(this.imgCboEditLineStyle.EditValue);
                dopGeneralShape.Bounds = new RectangleF(ConvertUtil.ConvertToFloat(this.spinEditLeft.Value), ConvertUtil.ConvertToFloat(this.spinEditTop.Value),
                        ConvertUtil.ConvertToFloat(this.spinEditWidth.Value), ConvertUtil.ConvertToFloat(this.spinEditHeight.Value));
                if (this.dopGraphElement.First is GoRoundedRectangle)
                {
                    (this.dopGraphElement.First as GoRoundedRectangle).Corner = new SizeF(ConvertUtil.ConvertToFloat(this.spinEditCornerW.Value), ConvertUtil.ConvertToFloat(this.spinEditCornerH.Value)); 
                }
                if (!chkColor.Checked && !this.chkFlash.Checked && !chkHide.Checked && !chkMove.Checked)
                {
                    return true;
                }
            }
            
            this.dopGraphElement.GraphActionMap.Clear();
            GraphActionDefine graphActionDefine = new GraphActionDefine();
            //颜色动画
            if (this.chkColor.Checked)
            {
                switch (radioGroupColor.SelectedIndex)
                { 
                    case 0:
                        graphActionDefine = ColorAOAnimation();
                        break;
                    case 1:
                        graphActionDefine = ColorDOAnimation();
                        break;
                    case 2:
                        graphActionDefine = ColorDOThreeAnimation();
                        break;
                    case 3:
                        graphActionDefine = ColorPackageAnimation();
                        break;
                    default:
                        break;
                }
                if (graphActionDefine != null)
                    this.dopGraphElement.GraphActionMap.Add(ActionExpression.ColorAction, graphActionDefine);

            }
            //闪烁动画
            if (this.chkFlash.Checked)
            {
                switch (radioGroupFlash.SelectedIndex)
                {
                    case 0:
                        graphActionDefine = FlashAOAnimation();
                        break;
                    case 1:
                        graphActionDefine = FlashDOAnimation();
                        break;
                    case 2:
                        graphActionDefine = FlashPackageAnimation();
                        break;
                    default:
                        break;
                }
                if (graphActionDefine != null)
                    this.dopGraphElement.GraphActionMap.Add("ColorAction", graphActionDefine);
            }
            ////隐藏动画
            //if (this.chkHide.Checked)
            //{
            //    conditionAction = null;
            //    switch (radioGroupHide.SelectedIndex)
            //    {
            //        case 0:
            //            conditionAction = HideAOAnimation();
            //            break;
            //        case 1:
            //            conditionAction = HideDOAnimation();
            //            break;
            //        case 2:
            //            conditionAction = HidePackageAnimation();
            //            break;
            //        default:
            //            break;
            //    }
            //    if (conditionAction != null)
            //        this.dopGraphElement.ActionScript.Add(conditionAction);
            //}
            ////移动动画
            //if (this.chkMove.Checked)
            //{
            //    conditionAction = null;
            //    switch (radioGroupMove.SelectedIndex)
            //    {
            //        case 0:
            //            conditionAction = MoveAOAnimation();
            //            break;
            //        default:
            //            break;
            //    }
            //    if (conditionAction != null)
            //        this.dopGraphElement.ActionScript.Add(conditionAction);
            //}
            //if (conditionAction == null)
            //{
            //    return false;
            //}
            //else
            //{
            return true;
            //}
        }

        /// <summary>
        /// 基本控件数据初始化
        /// </summary>
        private void BaseControlDataInit()
        {
            //if (this.dopGraphElement is DOPGraphGroup)
            //{
            //    this.spinEditWidth.Value = ConvertUtil.ConvertToDecimal(this.dopGraphElement.Width);
            //    this.spinEditHeight.Value = ConvertUtil.ConvertToDecimal(this.dopGraphElement.Height);
            //    this.spinEditLeft.Value = ConvertUtil.ConvertToDecimal(this.dopGraphElement.Location.X);
            //    this.spinEditTop.Value = ConvertUtil.ConvertToDecimal(this.dopGraphElement.Location.Y);
            //    return;
            //}
            this.spinEditWidth.Value = ConvertUtil.ConvertToDecimal(this.dopGraphElement.First.Size.Width);
            this.spinEditHeight.Value = ConvertUtil.ConvertToDecimal(this.dopGraphElement.First.Size.Height);
            this.spinEditLeft.Value = ConvertUtil.ConvertToDecimal(this.dopGraphElement.First.Location.X);
            this.spinEditTop.Value = ConvertUtil.ConvertToDecimal(this.dopGraphElement.First.Location.Y);
            if (this.dopGraphElement.First is GoRoundedRectangle)
            {
                this.spinEditCornerW.Value = ConvertUtil.ConvertToDecimal((this.dopGraphElement.First as GoRoundedRectangle).Corner.Width);
                this.spinEditCornerH.Value = ConvertUtil.ConvertToDecimal((this.dopGraphElement.First as GoRoundedRectangle).Corner.Height);
                this.spinEditCornerW.Enabled = true;
                this.spinEditCornerH.Enabled = true;
            }
            var obj = this.dopGraphElement.First;
            if (obj is GoImage) return;
            if (obj is GoStroke || obj is GoArc)
            {
                this.colorEditBrushColor.Enabled = false;
                this.imgCboEditBrushStyle.Enabled = false;
            }
            var dopGeneralShape = obj as GoShape;
            this.colorEditBrushColor.Color = dopGeneralShape.BrushColor;
            this.colorEditPenColor.Color = dopGeneralShape.PenColor;
            this.imgCboEditBrushStyle.SelectedIndex = this.brushStyle.FirstOrDefault(v => v.Value.Equals(dopGeneralShape.BrushStyle)).Key;
            this.imgCboEditLineStyle.SelectedIndex = ConvertUtil.ConvertToInt(dopGeneralShape.PenWidth) - 1;
        }
        #endregion

        #region 复选框事件
        /// <summary>
        /// 改变颜色动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkColor_CheckedChanged(object sender, EventArgs e)
        {
            this.xtraTabPageColor.PageVisible = this.chkColor.Checked;
        }

        /// <summary>
        /// 颜色动画初始化
        /// </summary>
        private void ColorAnimationInit()
        {
            if (this.dopGraphElement.First is GoImage)
            {
                this.chkColor.Enabled = false;
                return;
            }
            int index = 0;
            this.dopGraphElement.GraphActionMap.Where(v => v.Key == ActionExpression.ColorAction).ToList()
                .ForEach(s =>
                {
                    this.chkColor.Checked = s.Value.Enabled;
                    switch (s.Value.VarType)
                    {
                        case GraphActionVarType.Analog:   //模拟量值初始化
                            this.lblVariableColor.Text = s.Value.GetParamVar(ActionExpression.Variable).Name;
                            index = 0;
                            this.uCtlVarColorAO.SelectedVariable = s.Value.GetParamVar(ActionExpression.Variable);
                            this.uCtlColorAO.Condition = (List<string>)s.Value.GetParamValue(ActionExpression.Result);
                            this.uCtlColorAO.MulColor = (List<Color>)s.Value.GetParamValue(ActionExpression.Param);
                            break;
                        case GraphActionVarType.Digital:   //开关量值初始化
                            this.lblVariableColor.Text = s.Value.GetParamVar(ActionExpression.Variable).Name;
                            index = 1;
                            this.uCtlVarColorDO.SelectedVariable = s.Value.GetParamVar(ActionExpression.Variable);
                            this.uCtlColorDO.Colors = (List<Color>)s.Value.GetParamValue(ActionExpression.Param);
                            break;
                        case GraphActionVarType.ThirdDigital:  //三位开关量连接值初始化
                            this.lblVariableColor.Text = s.Value.GetParamVar(ActionExpression.Variable).Name;
                            index = 2;
                            this.uCtlVarColorDOThree1.SelectedVariable = s.Value.GetParamVar(ActionExpression.Variable);
                            this.uCtlVarColorDOThree2.SelectedVariable = s.Value.GetParamVar(ActionExpression.Variable1);
                            this.uCtlColorSwitchThree.Colors = (List<Color>)s.Value.GetParamValue(ActionExpression.Param);
                            break;
                        case GraphActionVarType.Pakage:
                            index = 3;
                            this.uCtlPIDAlgorithmsColor.SelectedVariable = s.Value.GetParamVar(ActionExpression.Variable);
                            //this.uCtlPIDAlgorithmsColor.AlgIndexes = s.DefaultValue;
                            this.uCtlColorPackage.Colors = (List<Color>)s.Value.GetParamValue(ActionExpression.Param);
                            break;
                        default:
                            break;
                    }
                    if (index > -1)
                    {
                        this.lblLinkTypeColor.Text = radioGroupColor.Properties.Items[index].Description;
                    }
                });
            this.radioGroupColor.SelectedIndex = index;
        }

        /// <summary>
        /// 闪烁动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkFlash_CheckedChanged(object sender, EventArgs e)
        {
            this.xtraTabPageFlash.PageVisible = this.chkFlash.Checked;
        }

        /// <summary>
        /// 闪烁动画
        /// </summary>
        private void FlashAnimationInit()
        {
            int index = 0;
            this.dopGraphElement.GraphActionMap.Where(v => v.Key == "GraphColorActionDefine").ToList()
                .ForEach(s =>
                {
                    this.chkFlash.Checked = s.Value.Enabled;
                    switch (s.Value.VarType)
                    {
                        case GraphActionVarType.Analog:   //模拟量值初始化
                            this.lblVariableFlash.Text = s.Value.GetParamVar(ActionExpression.Variable).Name;
                            index = 0;
                            this.uCtlVarFlashAO.SelectedVariable = s.Value.GetParamVar(ActionExpression.Variable);
                            this.spinEditAOFlashCondition.Value = ConvertUtil.ConvertToDecimal(s.Value.GetParamValue(ActionExpression.Result));
                            //this.radioGroupFlashAO.SelectedIndex = ConvertUtil.ConvertToInt(s.Expression[0]);
                            break;
                        case GraphActionVarType.Digital:   //开关量值初始化
                            this.lblVariableFlash.Text = s.Value.GetParamVar(ActionExpression.Variable).Name;
                            index = 1;
                            this.uCtlVarFlashDO.SelectedVariable = s.Value.GetParamVar(ActionExpression.Variable);
                            //this.radioGroupFlashDO.SelectedIndex = ConvertUtil.ConvertToInt(s.Expression[0]);
                            break;
                        case GraphActionVarType.Pakage:  //打包点值初始化
                            this.lblVariableFlash.Text = s.Value.GetParamVar(ActionExpression.Variable).Name;
                            index = 2;
                            this.uCtlPIDAlgorithmsFlash.SelectedVariable = s.Value.GetParamVar(ActionExpression.Variable);
                            //this.uCtlPIDAlgorithmsColor.AlgIndexes = s.DefaultValue;
                            //this.radioGroupFlash.SelectedIndex = ConvertUtil.ConvertToInt(s.Expression[0]);
                            break;
                        default:
                            break;
                    }
                    if (index > -1)
                        this.lblLinkTypeFlash.Text = radioGroupFlash.Properties.Items[index].Description;
                });
            this.radioGroupFlash.SelectedIndex = index;
        }

        /// <summary>
        /// 隐藏动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkHide_CheckedChanged(object sender, EventArgs e)
        {
            this.xtraTabPageHide.PageVisible = this.chkHide.Checked;
        }
        /// <summary>
        /// 隐藏动画初始化
        /// </summary>
        private void HideAnimationInit()
        {
            int index = 0;
            this.dopGraphElement.GraphActionMap.Where(v => v.Key == "GraphColorActionDefine").ToList()
                .ForEach(s =>
                {
                    this.chkHide.Checked = s.Value.Enabled;
                    switch (s.Value.VarType)
                    {
                        case GraphActionVarType.Analog:   //模拟量值初始化
                            this.lblVariableHide.Text = s.Value.GetParamVar(ActionExpression.Variable).Name;
                            index = 0;
                            this.uCtlVarHideAO.SelectedVariable = s.Value.GetParamVar(ActionExpression.Variable);
                            //this.spinEditHideAOCondition.Value = ConvertUtil.ConvertToDecimal(s.Condition[0]);
                            //this.radioGroupHideAO.SelectedIndex = ConvertUtil.ConvertToInt(s.Expression[0]);
                            break;
                        case GraphActionVarType.Digital:   //开关量值初始化
                            this.lblVariableHide.Text = s.Value.GetParamVar(ActionExpression.Variable).Name;
                            index = 1;
                            this.uCtlVarHideDO.SelectedVariable = s.Value.GetParamVar(ActionExpression.Variable);
                            //this.radioGroupHideDO.SelectedIndex = ConvertUtil.ConvertToInt(s.Expression[0]);
                            break;
                        case GraphActionVarType.Pakage: //打包点初始化
                            this.lblVariableHide.Text = s.Value.GetParamVar(ActionExpression.Variable).Name;
                            index = 2;
                            this.uCtlPIDAlgorithmsHide.SelectedVariable = s.Value.GetParamVar(ActionExpression.Variable);
                            //this.uCtlPIDAlgorithmsColor.AlgIndexes = s.DefaultValue;
                            //this.uCtlVarHidePackage.SelectedIndex = ConvertUtil.ConvertToInt(s.Expression[0]);
                            break;
                        default:
                            break;
                    }
                    if (index > -1)
                        this.lblLinkTypeHide.Text = radioGroupHide.Properties.Items[index].Description;
                });
            this.radioGroupHide.SelectedIndex = index;
        }

        /// <summary>
        /// 移动动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkMove_CheckedChanged(object sender, EventArgs e)
        {
            this.xtraTabPageMove.PageVisible = this.chkMove.Checked;
        }

        /// <summary>
        /// 移动动画初始化
        /// </summary>
        private void MoveAnimationInit()
        {
            int index = 0;
            this.dopGraphElement.GraphActionMap.Where(v => v.Key == ActionExpression.MoveAction).ToList()
                .ForEach(s =>
                {
                    this.chkMove.Checked = s.Value.Enabled;
                    switch (s.Value.VarType)
                    {
                        case GraphActionVarType.Analog:   //模拟量值初始化
                            this.lblVariableMove.Text = s.Value.GetParamVar(ActionExpression.Variable).Name;
                            index = 0;
                            this.uCtlVarMoveAO.SelectedVariable = s.Value.GetParamVar(ActionExpression.Variable);
                            //this.spinEditMoveConditionMin.Value = ConvertUtil.ConvertToDecimal(s.Condition[0]);
                            //this.spinEditMoveConditionMax.Value = ConvertUtil.ConvertToDecimal(s.Condition[1]);
                            //this.spinEditMoveConditionDistance.Value = ConvertUtil.ConvertToDecimal(s.Condition[2]);
                            //this.radioGroupMoveAO.SelectedIndex = ConvertUtil.ConvertToInt(s.Expression[0]);
                            break;
                        default:
                            break;
                    }
                    if (index > -1)
                        this.lblLinkTypeMove.Text = radioGroupMove.Properties.Items[index].Description;
                });
            this.radioGroupMove.SelectedIndex = index;
        }
        #endregion

        #region 颜色动画
        private void radioGroupColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.panelCtlAOColor.Enabled = radioGroupColor.SelectedIndex == 0 ? true : false;
            this.panelCtlDOColor.Enabled = radioGroupColor.SelectedIndex == 1 ? true : false;
            this.panelCtlDOThreeColor.Enabled = radioGroupColor.SelectedIndex == 2 ? true : false;
            this.panelCtlPackageColor.Enabled = radioGroupColor.SelectedIndex == 3 ? true : false;
        }

        /// <summary>
        /// 模拟量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private GraphActionDefine  ColorAOAnimation()
        {
            if (this.uCtlVarColorAO.SelectedVariable == null || 
                string.IsNullOrEmpty(this.uCtlVarColorAO.SelectedVariable.Number))
            {
                XtraMessageBox.Show("请选择变量！");
                return null;
            }
            var graphActionDefine = new GraphActionDefine()
            {
                 VarType = GraphActionVarType.Analog,
                 Enabled = true,
                 Expression = ActionExpression.Equal(),
                 UserObject = new GraphColorActionDefine(),
                 Container = this.dopGraphElement
            };
            graphActionDefine.SetParamVar(ActionExpression.Variable, this.uCtlVarColorAO.SelectedVariable);
            //graphActionDefine.SetParamVar(this.uCtlVarColorAO.SelectedVariable.Number, this.uCtlVarColorAO.SelectedVariable);
            graphActionDefine.SetParamValue(ActionExpression.Param, uCtlColorAO.MulColor);
            graphActionDefine.SetParamValue(ActionExpression.Result, uCtlColorAO.Condition);
            return graphActionDefine;
        }
        /// <summary>
        /// 开关量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private GraphActionDefine ColorDOAnimation()
        {
            if (this.uCtlVarColorDO.SelectedVariable == null || 
                string.IsNullOrEmpty(this.uCtlVarColorDO.SelectedVariable.Number))
            {
                XtraMessageBox.Show("请选择变量！");
                return null;
            }
            var graphActionDefine = new GraphActionDefine()
            {
                VarType = GraphActionVarType.Digital,
                Enabled = true,
                Expression = "",
                UserObject = new GraphColorActionDefine()
                //Condition = this.uCtlColorDO.Labels,
                //Colors = this.uCtlColorDO.Colors,
                //Variable = lstVariable,
                //LinkType = LinkType.DO,
                //ActionType = ActionType.ChangeColor,
                //IsExcutedAction = true,
                //DefaultColor = colorEditBrushColor.Color
            };
            graphActionDefine.SetParamVar(ActionExpression.Variable, this.uCtlVarColorDO.SelectedVariable);
            graphActionDefine.SetParamValue(ActionExpression.Param, this.uCtlColorDO.Colors);
            return graphActionDefine;
        }
        /// <summary>
        /// 三位开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private GraphActionDefine ColorDOThreeAnimation()
        {
            if (this.uCtlVarColorDOThree1.SelectedVariable == null ||
                string.IsNullOrEmpty(this.uCtlVarColorDOThree1.SelectedVariable.Number))
            {
                XtraMessageBox.Show("请选择变量！");
                return null;
            }
            var graphActionDefine = new GraphActionDefine()
            {
                VarType = GraphActionVarType.ThirdDigital,
                Enabled = true,
                Expression = "",
                UserObject = new GraphColorActionDefine()
                //Condition = this.uCtlColorSwitchThree.Labels,
                //Colors = this.uCtlColorSwitchThree.Colors,
                //Variable = lstVariable,
                //LinkType = LinkType.DOThree,
                //ActionType = ActionType.ChangeColor,
                //IsExcutedAction = true,
                //DefaultColor = colorEditBrushColor.Color
            };
            graphActionDefine.SetParamVar(ActionExpression.Variable, this.uCtlVarColorDOThree1.SelectedVariable);
            graphActionDefine.SetParamVar(ActionExpression.Variable1, this.uCtlVarColorDOThree2.SelectedVariable);
            graphActionDefine.SetParamValue(ActionExpression.Param, this.uCtlColorDO.Colors);
            return graphActionDefine;
        }
        /// <summary>
        /// 打包点
        /// </summary>
        private GraphActionDefine ColorPackageAnimation()
        {
            if (this.uCtlPIDAlgorithmsColor.SelectedVariable == null ||
                string.IsNullOrEmpty(this.uCtlPIDAlgorithmsColor.SelectedVariable.Number))
            {
                XtraMessageBox.Show("请选择变量！");
                return null;
            }
            var graphActionDefine = new GraphActionDefine()
            {
                VarType = GraphActionVarType.Pakage,
                Enabled = true,
                Expression = "",
                UserObject = new GraphColorActionDefine()
                //Condition = this.uCtlColorPackage.Labels,
                //Colors = this.uCtlColorPackage.Colors,
                //Variable = lstVariable,
                //LinkType = LinkType.Package,
                //ActionType = ActionType.ChangeColor,
                //IsExcutedAction = true,
                //DefaultValue = this.uCtlPIDAlgorithmsColor.AlgIndexes,
                //DefaultColor = colorEditBrushColor.Color
            };
            graphActionDefine.SetParamVar(ActionExpression.Variable, this.uCtlPIDAlgorithmsColor.SelectedVariable);
            graphActionDefine.SetParamValue(ActionExpression.Param, this.uCtlColorPackage.Colors);
            return graphActionDefine;
        }
        #endregion

        #region 闪烁动画
        private void radioGroupFlash_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.panelCtlFlashAO.Enabled = radioGroupFlash.SelectedIndex == 0 ? true : false;
            this.panelCtlFlashDO.Enabled = radioGroupFlash.SelectedIndex == 1 ? true : false;
            this.panelCtlFlashPacked.Enabled = radioGroupFlash.SelectedIndex == 2 ? true : false;
        }
        private GraphActionDefine FlashAOAnimation()
        {
            if (this.uCtlVarFlashAO.SelectedVariable == null ||
                string.IsNullOrEmpty(this.uCtlVarFlashAO.SelectedVariable.Number))
            {
                XtraMessageBox.Show("请选择变量！");
                return null;
            }
            IList<string> condition = new List<string>();
            condition.Add(this.spinEditAOFlashCondition.Text);
            IList<string> expression = new List<string>();
            expression.Add(this.radioGroupFlashAO.SelectedIndex.ToString());
            IList<Variable> lstVariable = new List<Variable>();
            lstVariable.Add(this.uCtlVarFlashAO.SelectedVariable);
            var graphActionDefine = new GraphActionDefine()
            {
                VarType = GraphActionVarType.Analog,
                Enabled = true,
                Expression = "",
                UserObject = new GraphColorActionDefine()
                //Condition = condition,
                //Expression = expression,
                //Variable = lstVariable,
                //LinkType = LinkType.AO,
                //ActionType = ActionType.Flash,
                //IsExcutedAction = true
            };

            graphActionDefine.SetParamVar(ActionExpression.Variable, this.uCtlPIDAlgorithmsColor.SelectedVariable);
            graphActionDefine.SetParamValue(ActionExpression.Param, this.uCtlColorPackage.Colors);
            return graphActionDefine;
        }

        private GraphActionDefine FlashDOAnimation()
        {
            if (this.uCtlVarFlashDO.SelectedVariable == null ||
                string.IsNullOrEmpty(this.uCtlVarFlashDO.SelectedVariable.Number))
            {
                XtraMessageBox.Show("请选择变量！");
                return null;
            }
            IList<string> condition = new List<string>();
            condition.Add(this.radioGroupFlashDO.SelectedIndex.ToString());
            IList<string> expression = new List<string>();
            expression.Add(this.radioGroupFlashDO.SelectedIndex.ToString());
            IList<Variable> lstVariable = new List<Variable>();
            lstVariable.Add(this.uCtlVarFlashDO.SelectedVariable);
            var graphActionDefine = new GraphActionDefine()
            {
                VarType = GraphActionVarType.Digital,
                Enabled = true,
                Expression = "",
                UserObject = new GraphColorActionDefine()
                //Condition = condition,
                //Expression = expression,
                //Variable = lstVariable,
                //LinkType = LinkType.DO,
                //ActionType = ActionType.Flash,
                //IsExcutedAction = true
            };
            graphActionDefine.SetParamVar(ActionExpression.Variable, this.uCtlPIDAlgorithmsColor.SelectedVariable);
            graphActionDefine.SetParamValue(ActionExpression.Param, this.uCtlColorPackage.Colors);
            return graphActionDefine;
        }

        private GraphActionDefine FlashPackageAnimation()
        {
            if (this.uCtlPIDAlgorithmsFlash.SelectedVariable == null
                || string.IsNullOrEmpty(this.uCtlPIDAlgorithmsFlash.SelectedVariable.Number))
            {
                XtraMessageBox.Show("请选择变量！");
                return null;
            }
            IList<Variable> lstVariable = new List<Variable>();
            lstVariable.Add(this.uCtlPIDAlgorithmsFlash.SelectedVariable);
            IList<string> condition = new List<string>();
            condition.Add(this.radioGroupFlashPackage.SelectedIndex.ToString());
            IList<string> expression = new List<string>();
            expression.Add(this.radioGroupFlashPackage.SelectedIndex.ToString());
            var graphActionDefine = new GraphActionDefine()
            {
                VarType = GraphActionVarType.Pakage,
                Enabled = true,
                Expression = "",
                UserObject = new GraphColorActionDefine()
                //Condition = condition,
                //Expression = expression,
                //Variable = lstVariable,
                //LinkType = LinkType.Package,
                //ActionType = ActionType.Flash,
                //DefaultValue = this.uCtlPIDAlgorithmsColor.AlgIndexes,
                //IsExcutedAction = true
            };
            graphActionDefine.SetParamVar(ActionExpression.Variable, this.uCtlPIDAlgorithmsColor.SelectedVariable);
            graphActionDefine.SetParamValue(ActionExpression.Param, this.uCtlColorPackage.Colors);
            return graphActionDefine;
        }
        #endregion

        #region 隐藏动画
        private void radioGroupHide_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.panelCtlHideAO.Enabled = radioGroupHide.SelectedIndex == 0 ? true : false;
            this.panelCtlHideDO.Enabled = radioGroupHide.SelectedIndex == 1 ? true : false;
            this.panelCtlHidePakage.Enabled = radioGroupHide.SelectedIndex == 2 ? true : false;
        }
        //private ConditionAction HideAOAnimation()
        //{
        //    if (this.uCtlVarHideAO.SelectedVariable == null || 
        //        string.IsNullOrEmpty(this.uCtlVarHideAO.SelectedVariable.Number))
        //    {
        //        XtraMessageBox.Show("请选择变量！");
        //        return null;
        //    }
        //    IList<string> condition = new List<string>();
        //    condition.Add(this.spinEditHideAOCondition.Text);
        //    IList<string> expression = new List<string>();
        //    expression.Add(this.radioGroupHideAO.SelectedIndex.ToString());
        //    IList<Variable> lstVariable = new List<Variable>();
        //    lstVariable.Add(this.uCtlVarHideAO.SelectedVariable);
        //    var conditionAction = new ConditionAction()
        //    {
        //        Condition = condition,
        //        Expression = expression,
        //        Variable = lstVariable,
        //        LinkType = LinkType.AO,
        //        ActionType = ActionType.Hide,
        //        IsExcutedAction = true
        //    };
        //    return conditionAction;
        //}

        //private ConditionAction HideDOAnimation()
        //{
        //    if (this.uCtlVarHideDO.SelectedVariable == null || 
        //        string.IsNullOrEmpty(this.uCtlVarHideDO.SelectedVariable.Number))
        //    {
        //        XtraMessageBox.Show("请选择变量！");
        //        return null;
        //    }
        //    IList<string> expression = new List<string>();
        //    expression.Add(this.radioGroupHideDO.SelectedIndex.ToString());
        //    IList<string> condition = new List<string>();
        //    condition.Add(this.radioGroupHideDO.SelectedIndex.ToString());
        //    IList<Variable> lstVariable = new List<Variable>();
        //    lstVariable.Add(this.uCtlVarHideDO.SelectedVariable);
        //    var conditionAction = new ConditionAction()
        //    {
        //        Condition = condition,
        //        Expression = expression,
        //        Variable = lstVariable,
        //        LinkType = LinkType.DO,
        //        ActionType = ActionType.Hide,
        //        IsExcutedAction = true
        //    };
        //    return conditionAction;
        //}

        //private ConditionAction HidePackageAnimation()
        //{
        //    if (this.uCtlPIDAlgorithmsHide.SelectedVariable == null || 
        //        string.IsNullOrEmpty(this.uCtlPIDAlgorithmsHide.SelectedVariable.Number))
        //    {
        //        XtraMessageBox.Show("请选择变量！");
        //        return null;
        //    }
        //    IList<Variable> lstVariable = new List<Variable>();
        //    lstVariable.Add(this.uCtlPIDAlgorithmsHide.SelectedVariable);
        //    IList<string> expression = new List<string>();
        //    expression.Add(this.uCtlVarHidePackage.SelectedIndex.ToString());
        //    IList<string> condition = new List<string>();
        //    condition.Add(this.uCtlVarHidePackage.SelectedIndex.ToString());
        //    var conditionAction = new ConditionAction()
        //    {
        //        Condition = condition,
        //        Expression = expression,
        //        Variable = lstVariable,
        //        LinkType = LinkType.Package,
        //        ActionType = ActionType.Hide,
        //        DefaultValue = this.uCtlPIDAlgorithmsColor.AlgIndexes,
        //        IsExcutedAction = true
        //    };

        //    return conditionAction;
        //}
        #endregion

        #region 移动动画
        private void radioGroupMove_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.panelCtlMoveAO.Enabled = radioGroupMove.SelectedIndex == 0 ? true : false;
        }
        //private ConditionAction MoveAOAnimation()
        //{
        //    if (this.uCtlVarMoveAO.SelectedVariable == null || 
        //        string.IsNullOrEmpty(this.uCtlVarMoveAO.SelectedVariable.Number))
        //    {
        //        XtraMessageBox.Show("请选择变量！");
        //        return null;
        //    }
        //    IList<string> condition = new List<string>();
        //    condition.Add(this.spinEditMoveConditionMin.Text);
        //    condition.Add(this.spinEditMoveConditionMax.Text);
        //    condition.Add(this.spinEditMoveConditionDistance.Text);
        //    IList<string> expression = new List<string>();
        //    expression.Add(this.radioGroupMoveAO.SelectedIndex.ToString());
        //    IList<Variable> lstVariable = new List<Variable>();
        //    lstVariable.Add(this.uCtlVarMoveAO.SelectedVariable);
        //    var conditionAction = new ConditionAction()
        //    {
        //        Condition = condition,
        //        Expression = expression,
        //        Variable = lstVariable,
        //        LinkType = LinkType.AO,
        //        ActionType = ActionType.Move,
        //        IsExcutedAction = true
        //    };
        //    return conditionAction;
        //}
        #endregion


    }
}
