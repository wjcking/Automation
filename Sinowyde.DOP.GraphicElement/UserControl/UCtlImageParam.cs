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
using Sinowyde.Util;
using Sinowyde.DOP.DataModel;
using Northwoods.Go;

namespace Sinowyde.DOP.GraphicElement
{
    public partial class UCtlImageParam : XtraUserControl, ICtrlParamBase
    {
        private DOPGraphElement dopGraphElement = null;

        public UCtlImageParam()
        {
            InitializeComponent();
        }

        public UCtlImageParam(DOPGraphElement graphElement)
        {
            InitializeComponent();
            dopGraphElement = graphElement;
        }

        #region ICtrlParamBase 成员
        public void LoadParam()
        {
            BaseControlDataInit();
            //if (this.dopGraphElement.ActionScript == null || this.dopGraphElement.ActionScript.Count < 1) return;
            //FlashAnimationInit();
            //HideAnimationInit();
            //MoveAnimationInit();
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

        /// <summary>
        /// 基本控件数据初始化
        /// </summary>
        private void BaseControlDataInit()
        {
            string fileName = (this.dopGraphElement.First as GoImage).Name;
            if (!fileName.Contains(Environment.CurrentDirectory + "\\ImageLibrary\\"))
            {
                fileName = Environment.CurrentDirectory + "\\ImageLibrary\\" + fileName;
            }

            this.txtFile.Text =  fileName;
            this.spinEditWidth.Value = ConvertUtil.ConvertToDecimal(this.dopGraphElement.First.Size.Width);
            this.spinEditHeight.Value = ConvertUtil.ConvertToDecimal(this.dopGraphElement.First.Size.Height);
            this.spinEditLeft.Value = ConvertUtil.ConvertToDecimal(this.dopGraphElement.First.Location.X);
            this.spinEditTop.Value = ConvertUtil.ConvertToDecimal(this.dopGraphElement.First.Location.Y);
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

        ///// <summary>
        ///// 闪烁动画
        ///// </summary>
        //private void FlashAnimationInit()
        //{
        //    int index = 0;
        //    this.dopGraphElement.ActionScript.Where(v => v.ActionType == ActionType.Flash).ToList()
        //        .ForEach(s =>
        //        {
        //            this.chkFlash.Checked = s.IsExcutedAction;
        //            switch (s.LinkType)
        //            {
        //                case LinkType.AO:   //模拟量值初始化
        //                    this.lblVariableFlash.Text = s.Variable[0].Name;
        //                    index = 0;
        //                    this.uCtlVarFlashAO.SelectedVariable = s.Variable[0];
        //                    this.spinEditAOFlashCondition.Value = ConvertUtil.ConvertToDecimal(s.Condition[0]);
        //                    this.radioGroupFlashAO.SelectedIndex = ConvertUtil.ConvertToInt(s.Expression[0]);
        //                    break;
        //                case LinkType.DO:   //开关量值初始化
        //                    this.lblVariableFlash.Text = s.Variable[0].Name;
        //                    index = 1;
        //                    this.uCtlVarFlashDO.SelectedVariable = s.Variable[0];
        //                    this.radioGroupFlashDO.SelectedIndex = ConvertUtil.ConvertToInt(s.Expression[0]);
        //                    break;
        //                case LinkType.Package:  //打包点值初始化
        //                    this.lblVariableFlash.Text = s.Variable[0].Name;
        //                    index = 2;
        //                    this.uCtlPIDAlgorithmsFlash.SelectedVariable = s.Variable[0];
        //                    //this.uCtlPIDAlgorithmsColor.AlgIndexes = s.DefaultValue;
        //                    this.radioGroupFlash.SelectedIndex = ConvertUtil.ConvertToInt(s.Expression[0]);
        //                    break;
        //                default:
        //                    break;
        //            }
        //            if (index > -1)
        //                this.lblLinkTypeFlash.Text = radioGroupFlash.Properties.Items[index].Description;
        //        });
        //    this.radioGroupFlash.SelectedIndex = index;
        //}

        /// <summary>
        /// 隐藏动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkHide_CheckedChanged(object sender, EventArgs e)
        {
            this.xtraTabPageHide.PageVisible = this.chkHide.Checked;
        }
        ///// <summary>
        ///// 隐藏动画初始化
        ///// </summary>
        //private void HideAnimationInit()
        //{
        //    int index = 0;
        //    this.dopGraphElement.ActionScript.Where(v => v.ActionType == ActionType.Hide).ToList()
        //        .ForEach(s =>
        //        {
        //            this.chkHide.Checked = s.IsExcutedAction;
        //            switch (s.LinkType)
        //            {
        //                case LinkType.AO:   //模拟量值初始化
        //                    this.lblVariableHide.Text = s.Variable[0].Name;
        //                    index = 0;
        //                    this.uCtlVarHideAO.SelectedVariable = s.Variable[0];
        //                    this.spinEditHideAOCondition.Value = ConvertUtil.ConvertToDecimal(s.Condition[0]);
        //                    this.radioGroupHideAO.SelectedIndex = ConvertUtil.ConvertToInt(s.Expression[0]);
        //                    break;
        //                case LinkType.DO:   //开关量值初始化
        //                    this.lblVariableHide.Text = s.Variable[0].Name;
        //                    index = 1;
        //                    this.uCtlVarHideDO.SelectedVariable = s.Variable[0];
        //                    this.radioGroupHideDO.SelectedIndex = ConvertUtil.ConvertToInt(s.Expression[0]);
        //                    break;
        //                case LinkType.Package: //打包点初始化
        //                    this.lblVariableHide.Text = s.Variable[0].Name;
        //                    index = 2;
        //                    this.uCtlPIDAlgorithmsHide.SelectedVariable = s.Variable[0];
        //                    //this.uCtlPIDAlgorithmsColor.AlgIndexes = s.DefaultValue;
        //                    this.uCtlVarHidePackage.SelectedIndex = ConvertUtil.ConvertToInt(s.Expression[0]);
        //                    break;
        //                default:
        //                    break;
        //            }
        //            if (index > -1)
        //                this.lblLinkTypeHide.Text = radioGroupHide.Properties.Items[index].Description;
        //        });
        //    this.radioGroupHide.SelectedIndex = index;
        //}

        /// <summary>
        /// 移动动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkMove_CheckedChanged(object sender, EventArgs e)
        {
            this.xtraTabPageMove.PageVisible = this.chkMove.Checked;
        }

        ///// <summary>
        ///// 移动动画初始化
        ///// </summary>
        //private void MoveAnimationInit()
        //{
        //    int index = 0;
        //    this.dopGraphElement.ActionScript.Where(v => v.ActionType == ActionType.Move).ToList()
        //        .ForEach(s =>
        //        {
        //            this.chkMove.Checked = s.IsExcutedAction;
        //            switch (s.LinkType)
        //            {
        //                case LinkType.AO:   //模拟量值初始化
        //                    this.lblVariableMove.Text = s.Variable[0].Name;
        //                    index = 0;
        //                    this.uCtlVarMoveAO.SelectedVariable = s.Variable[0];
        //                    this.spinEditMoveConditionMin.Value = ConvertUtil.ConvertToDecimal(s.Condition[0]);
        //                    this.spinEditMoveConditionMax.Value = ConvertUtil.ConvertToDecimal(s.Condition[1]);
        //                    this.spinEditMoveConditionDistance.Value = ConvertUtil.ConvertToDecimal(s.Condition[2]);
        //                    this.radioGroupMoveAO.SelectedIndex = ConvertUtil.ConvertToInt(s.Expression[0]);
        //                    break;
        //                default:
        //                    break;
        //            }
        //            if (index > -1)
        //                this.lblLinkTypeMove.Text = radioGroupMove.Properties.Items[index].Description;
        //        });
        //    this.radioGroupMove.SelectedIndex = index;
        //}

        /// <summary>
        /// 保存参数信息
        /// </summary>
        private bool SaveParamInfo()
        {
            (dopGraphElement.First as GoImage).Image = Image.FromFile(this.txtFile.Text);
            (dopGraphElement.First as GoImage).Name = this.txtFile.Text;//.Substring(this.txtFile.Text.LastIndexOf('\\')+1);
            this.dopGraphElement.Bounds = new RectangleF(ConvertUtil.ConvertToFloat(this.spinEditLeft.Value), ConvertUtil.ConvertToFloat(this.spinEditTop.Value),
                                    ConvertUtil.ConvertToFloat(this.spinEditWidth.Value), ConvertUtil.ConvertToFloat(this.spinEditHeight.Value));
            if (!this.chkFlash.Checked && !chkHide.Checked && !chkMove.Checked)
            {
                return true;
            }
            //this.dopGraphElement.ActionScript.Clear();
            //ConditionAction conditionAction = null;
            ////闪烁动画
            //if (this.chkFlash.Checked)
            //{
            //    conditionAction = null;
            //    switch (radioGroupFlash.SelectedIndex)
            //    {
            //        case 0:
            //            conditionAction = FlashAOAnimation();
            //            break;
            //        case 1:
            //            conditionAction = FlashDOAnimation();
            //            break;
            //        case 2:
            //            conditionAction = FlashPackageAnimation();
            //            break;
            //        default:
            //            break;
            //    }
            //    if (conditionAction != null)
            //        this.dopGraphElement.ActionScript.Add(conditionAction);
            //}
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
        #region 闪烁动画
        private void radioGroupFlash_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.panelCtlFlashAO.Enabled = radioGroupFlash.SelectedIndex == 0 ? true : false;
            this.panelCtlFlashDO.Enabled = radioGroupFlash.SelectedIndex == 1 ? true : false;
            this.panelCtlFlashPacked.Enabled = radioGroupFlash.SelectedIndex == 2 ? true : false;
        }
        //private ConditionAction FlashAOAnimation()
        //{
        //    if (this.uCtlVarFlashAO.SelectedVariable == null ||
        //        string.IsNullOrEmpty(this.uCtlVarFlashAO.SelectedVariable.Number))
        //    {
        //        XtraMessageBox.Show("请选择变量！");
        //        return null;
        //    }
        //    IList<string> condition = new List<string>();
        //    condition.Add(this.spinEditAOFlashCondition.Text);
        //    IList<string> expression = new List<string>();
        //    expression.Add(this.radioGroupFlashAO.SelectedIndex.ToString());
        //    IList<Variable> lstVariable = new List<Variable>();
        //    lstVariable.Add(this.uCtlVarFlashAO.SelectedVariable);
        //    var conditionAction = new ConditionAction()
        //    {
        //        Condition = condition,
        //        Expression = expression,
        //        Variable = lstVariable,
        //        LinkType = LinkType.AO,
        //        ActionType = ActionType.Flash,
        //        IsExcutedAction = true
        //    };

        //    return conditionAction;
        //}

        //private ConditionAction FlashDOAnimation()
        //{
        //    if (this.uCtlVarFlashDO.SelectedVariable == null ||
        //        string.IsNullOrEmpty(this.uCtlVarFlashDO.SelectedVariable.Number))
        //    {
        //        XtraMessageBox.Show("请选择变量！");
        //        return null;
        //    }
        //    IList<string> condition = new List<string>();
        //    condition.Add(this.radioGroupFlashDO.SelectedIndex.ToString());
        //    IList<string> expression = new List<string>();
        //    expression.Add(this.radioGroupFlashDO.SelectedIndex.ToString());
        //    IList<Variable> lstVariable = new List<Variable>();
        //    lstVariable.Add(this.uCtlVarFlashDO.SelectedVariable);
        //    var conditionAction = new ConditionAction()
        //    {
        //        Condition = condition,
        //        Expression = expression,
        //        Variable = lstVariable,
        //        LinkType = LinkType.DO,
        //        ActionType = ActionType.Flash,
        //        IsExcutedAction = true
        //    };
        //    return conditionAction;
        //}

        //private ConditionAction FlashPackageAnimation()
        //{
        //    if (this.uCtlPIDAlgorithmsFlash.SelectedVariable == null
        //        || string.IsNullOrEmpty(this.uCtlPIDAlgorithmsFlash.SelectedVariable.Number))
        //    {
        //        XtraMessageBox.Show("请选择变量！");
        //        return null;
        //    }
        //    IList<Variable> lstVariable = new List<Variable>();
        //    lstVariable.Add(this.uCtlPIDAlgorithmsFlash.SelectedVariable);
        //    IList<string> condition = new List<string>();
        //    condition.Add(this.radioGroupFlashPackage.SelectedIndex.ToString());
        //    IList<string> expression = new List<string>();
        //    expression.Add(this.radioGroupFlashPackage.SelectedIndex.ToString());
        //    var conditionAction = new ConditionAction()
        //    {
        //        Condition = condition,
        //        Expression = expression,
        //        Variable = lstVariable,
        //        LinkType = LinkType.Package,
        //        ActionType = ActionType.Flash,
        //        //DefaultValue = this.uCtlPIDAlgorithmsColor.AlgIndexes,
        //        IsExcutedAction = true
        //    };

        //    return conditionAction;
        //}
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
        //        //DefaultValue = this.uCtlPIDAlgorithmsColor.AlgIndexes,
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog() { Filter = "jpg文件(*.jpg)|*.jpg|png文件(*.png)|*.png|gif文件(*.gif)|*.gif", InitialDirectory = "C:\\" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog.FileName;               
            }
        }
    }
}
