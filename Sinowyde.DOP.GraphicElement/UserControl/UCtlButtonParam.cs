using System;
using Sinowyde.DOP.GraphicElement.Base;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Northwoods.Go;
using Sinowyde.Util;
using System.Drawing;
using System.Collections.Generic;
using DevExpress.XtraEditors.Controls;
using Sinowyde.DOP.DataModel;
using System.Linq;

namespace Sinowyde.DOP.GraphicElement
{
    public partial class UCtlButtonParam : XtraUserControl, ICtrlParamBase
    {
        private DOPGraphElement dopGraphElement = null;
        
        
        private Font selectedFont = null;
        private GoButton goButton = null;
        private float FontSize = 12f;
        public UCtlButtonParam()
        {
            InitializeComponent();
        }

        public UCtlButtonParam(DOPGraphElement generalShape)
        {
            InitializeComponent();
            this.dopGraphElement = generalShape;
            goButton = dopGraphElement.First as GoButton;
            selectedFont = new Font("宋体", 12);
            Rectangle rect = new Rectangle();
            rect = Screen.GetWorkingArea(this);
            this.spinTop.Properties.MaxValue = rect.Height - 30;
            this.spinLeft.Properties.MaxValue = rect.Width - 30;
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
            goButton.Label.Text = txtButtonCaption.Text;
            goButton.Bounds = new RectangleF(ConvertUtil.ConvertToFloat(this.spinEditLeft.Value),
                ConvertUtil.ConvertToFloat(this.spinEditTop.Value),
                ConvertUtil.ConvertToFloat(this.spinEditWidth.Value),
                ConvertUtil.ConvertToFloat(this.spinEditHeight.Value));
            goButton.Label.TextColor = this.colorEditPenColor.Color;
            (goButton.Background as GoRectangle).BrushColor = this.colorBackColor.Color;
            goButton.Label.Font = selectedFont;
            goButton.Label.FontSize = FontSize;
            var marginWidth = ConvertUtil.ConvertToFloat(this.spinEditWidth.Value) - goButton.Width + goButton.TopLeftMargin.Width * 2;
            var marginHeight = ConvertUtil.ConvertToFloat(this.spinEditHeight.Value) - goButton.Height + goButton.TopLeftMargin.Height * 2;
            goButton.TopLeftMargin = new SizeF(marginWidth / 2, marginHeight / 2);
            goButton.BottomRightMargin = new SizeF(marginWidth / 2, marginHeight / 2);
            //this.dopGraphElement.ActionScript.Clear();
            //ConditionAction conditionAction = null;
            //IList<string> condition = new List<string>();
            //condition.Add(this.txtFile.Text);
            //IList<string> expression = new List<string>();
            //expression.Add(this.cboOperate.SelectedIndex.ToString());
            //switch (cboOperate.SelectedIndex)
            //{ 
            //    case 0:     //切换底图
            //        conditionAction = new ConditionAction()
            //        {
            //            Expression =expression,
            //            Condition = condition,
            //            LinkType = LinkType.Button,
            //            ActionType = ActionType.Button,
            //            IsExcutedAction = true
            //        };
            //        break;
            //    case 1:     //弹出窗口
            //        condition.Add(this.spinTop.Text);
            //        condition.Add(this.spinLeft.Text);
                    
            //        condition.Add(this.spinWidth.Text);
            //        condition.Add(this.spinHeight.Text);
            //        conditionAction = new ConditionAction()
            //        {
            //            Expression =expression,
            //            Condition = condition,
            //            LinkType = LinkType.Button,
            //            ActionType = ActionType.Button,
            //            IsExcutedAction = true
            //        };
            //        break;
            //    case 2:     //执行程序
            //        conditionAction = new ConditionAction()
            //        {
            //            Expression =expression,
            //            Condition = condition,
            //            LinkType = LinkType.Button,
            //            ActionType = ActionType.Button,
            //            IsExcutedAction = true
            //        };
            //        break;
            //    default:
            //        break;
            //}
            //if (conditionAction != null)
            //    this.dopGraphElement.ActionScript.Add(conditionAction);
            ////颜色动画
            //if (this.chkColor.Checked)
            //{
            //    switch (radioGroupColor.SelectedIndex)
            //    {
            //        case 0:
            //            conditionAction = ColorDOAnimation();
            //            break;
            //        case 1:
            //            conditionAction = ColorPackageAnimation();
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

        public UserControl GetParamCtrl()
        {
            return this;
        }
        #endregion

        /// <summary>
        /// 基本参数
        /// </summary>
        private void BaseControlDataInit()
        {
            //位置、大小
            this.spinEditLeft.Value = ConvertUtil.ConvertToDecimal(goButton.Left);
            this.spinEditTop.Value = ConvertUtil.ConvertToDecimal(goButton.Top);
            this.spinEditWidth.Value = ConvertUtil.ConvertToDecimal(goButton.Width);
            this.spinEditHeight.Value = ConvertUtil.ConvertToDecimal(goButton.Height);
            if (goButton.Label != null)
            {
                txtButtonCaption.Text = goButton.Text;
                this.colorEditPenColor.Color = goButton.Label.TextColor;
                this.colorBackColor.Color = (goButton.Background as GoRectangle).BrushColor;
                selectedFont = goButton.Label.Font;
                FontSize = goButton.Label.FontSize;
                //chkTransparency.Checked = goButton.Label.TransparentBackground;
            }
        }

        ///// <summary>
        ///// 颜色动画初始化
        ///// </summary>
        //private void ColorAnimationInit()
        //{
        //    int index = -1;
        //    this.dopGraphElement.ActionScript.Where(v => v.ActionType == ActionType.ChangeColor).ToList()
        //        .ForEach(s =>
        //        {
        //            this.chkColor.Checked = s.IsExcutedAction;
        //            switch (s.LinkType)
        //            {
        //                case LinkType.DO:   //开关量值初始化
        //                    this.lblVariableColor.Text = s.Variable[0].Name;
        //                    index = 0;
        //                    this.uCtlGetVariableColorDO.SelectedVariable = s.Variable[0];
        //                    this.uCtlColorDO.Colors = s.Colors;
        //                    break;
        //                case LinkType.Package:  //打包点初始化
        //                    index = 1;
        //                    this.uCtlPIDAlgorithmsColor.SelectedVariable = s.Variable[0];
        //                    this.uCtlPIDAlgorithmsColor.AlgIndexes = s.DefaultValue;
        //                    this.uCtlColorPackage.Colors = s.Colors;
        //                    break;
        //                default:
        //                    break;
        //            }
        //            this.radioGroupColor.SelectedIndex = index;
        //            if (index > -1)
        //            {
        //                this.lblLinkTypeColor.Text = radioGroupColor.Properties.Items[index].Description;
        //            }
        //        });
        //    this.dopGraphElement.ActionScript.Where(v => v.ActionType == ActionType.Button).ToList()
        //        .ForEach(s =>
        //        {
        //            this.cboOperate.SelectedIndex = ConvertUtil.ConvertToInt(s.Expression[0]);
        //            txtFile.Text = ConvertUtil.ConvertToString(s.Condition[0]);
        //            if (s.Expression[0].Equals("1"))
        //            {
        //                spinTop.Value = ConvertUtil.ConvertToDecimal(s.Condition[1]);
        //                spinLeft.Value = ConvertUtil.ConvertToDecimal(s.Condition[2]);

        //                spinWidth.Value = ConvertUtil.ConvertToDecimal(s.Condition[3]);
        //                spinHeight.Value = ConvertUtil.ConvertToDecimal(s.Condition[4]);
        //                panelCtlSite.Visible = true;
        //            }
        //        });
        //}


        #region 颜色动画
        private void radioGroupColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.panelCtlDOColor.Enabled = radioGroupColor.SelectedIndex == 0 ? true : false;
            this.panelCtlPackageColor.Enabled = radioGroupColor.SelectedIndex == 1 ? true : false;
        }

        ///// <summary>
        ///// 开关量
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private ConditionAction ColorDOAnimation()
        //{
        //    if (this.uCtlGetVariableColorDO.SelectedVariable == null ||
        //        string.IsNullOrEmpty(this.uCtlGetVariableColorDO.SelectedVariable.Number))
        //    {
        //        XtraMessageBox.Show("请选择变量！");
        //        return null;
        //    }
        //    IList<Variable> lstVariable = new List<Variable>();
        //    lstVariable.Add(this.uCtlGetVariableColorDO.SelectedVariable);
        //    var conditionAction = new ConditionAction()
        //    {
        //        Condition = this.uCtlColorDO.Labels,
        //        Colors = this.uCtlColorDO.Colors,
        //        Variable = lstVariable,
        //        LinkType = LinkType.DO,
        //        ActionType = ActionType.ChangeColor,
        //        IsExcutedAction = true,
        //        DefaultColor = colorBackColor.Color
        //    };

        //    return conditionAction;
        //}
        ///// <summary>
        ///// 打包点
        ///// </summary>
        //private ConditionAction ColorPackageAnimation()
        //{
        //    if (this.uCtlPIDAlgorithmsColor.SelectedVariable == null ||
        //        string.IsNullOrEmpty(this.uCtlPIDAlgorithmsColor.SelectedVariable.Number))
        //    {
        //        XtraMessageBox.Show("请选择变量！");
        //        return null;
        //    }
        //    IList<Variable> lstVariable = new List<Variable>();
        //    lstVariable.Add(this.uCtlPIDAlgorithmsColor.SelectedVariable);
        //    var conditionAction = new ConditionAction()
        //    {
        //        Condition = this.uCtlColorPackage.Labels,
        //        Colors = this.uCtlColorPackage.Colors,
        //        Variable = lstVariable,
        //        LinkType = LinkType.Package,
        //        ActionType = ActionType.ChangeColor,
        //        IsExcutedAction = true,
        //        DefaultValue = this.uCtlPIDAlgorithmsColor.AlgIndexes,
        //        DefaultColor = colorBackColor.Color
        //    };

        //    return conditionAction;
        //}
        #endregion
        
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (cboOperate.SelectedIndex == 2)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "All files (*.exe)|*.exe" };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    txtFile.Text = openFileDialog.FileName;
            }
            else {
                frmOpenDialog frm = new frmOpenDialog();
                if (frm.ShowDialog() == DialogResult.OK)
                    txtFile.Text = frm.GraphDoc.Name;
            }
        }

        private void cbxOperate_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelCtlSite.Visible = cboOperate.SelectedIndex == 1 ? true : false;
            this.txtFile.Text = "";
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            var fontDlg = new FontDialog();
            fontDlg.Font = goButton.Label.Font;
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                selectedFont = fontDlg.Font;
                FontSize = fontDlg.Font.Size;
            }
        }

        private void chkColor_CheckStateChanged(object sender, EventArgs e)
        {
            this.xtraTabPageDynamic.PageVisible = this.chkColor.Checked;
        }

        private void chkTransparency_CheckStateChanged(object sender, EventArgs e)
        {
            this.colorBackColor.Enabled = chkTransparency.Checked;
        }

    }
}
