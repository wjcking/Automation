using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using Sinowyde.DOP.GraphicElement.Base;
using Northwoods.Go;
using Sinowyde.Util;

namespace Sinowyde.DOP.GraphicElement
{
    public partial class UCtlImageButtonParam : XtraUserControl, ICtrlParamBase
    {
        private DOPGraphElement dopGraphElement = null;

        public UCtlImageButtonParam()
        {
            InitializeComponent();
        }

        public UCtlImageButtonParam(DOPGraphElement generalShape)
        {
            InitializeComponent();
            this.dopGraphElement = generalShape;
            //goButton = dopGraphElement.First as GoButton;
        }

        #region ICtrlParamBase 成员


        public void LoadParam()
        {
            BaseControlDataInit();
            //if (this.dopGraphElement.ActionScript == null || 
            //    this.dopGraphElement.ActionScript.Count < 1) return;
            //ActionDataInit();
        }

        public bool SaveParam()
        {
            var goButton = dopGraphElement.First as GoButton;
            goButton.Left = ConvertUtil.ConvertToFloat(this.spinEditLeft.Value);
            goButton.Top = ConvertUtil.ConvertToFloat(this.spinEditTop.Value);
            goButton.Width = ConvertUtil.ConvertToFloat(this.spinEditWidth.Value);
            goButton.Height = ConvertUtil.ConvertToFloat(this.spinEditHeight.Value);
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
            //            Expression = expression,
            //            Condition = condition,
            //            LinkType = LinkType.Button,
            //            ActionType = ActionType.Button,
            //            IsExcutedAction = true
            //        };
            //        break;
            //    case 1:     //弹出窗口
            //        condition.Add(this.spinTop.Text);
            //        condition.Add(this.spinLeft.Text);
            //        conditionAction = new ConditionAction()
            //        {
            //            Expression = expression,
            //            Condition = condition,
            //            LinkType = LinkType.Button,
            //            ActionType = ActionType.Button,
            //            IsExcutedAction = true
            //        };
            //        break;
            //    case 2:     //执行程序
            //        conditionAction = new ConditionAction()
            //        {
            //            Expression = expression,
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
        /// 取得图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImagePath_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog() { Filter = "jpg文件(*.jpg)|*.jpg|png文件(*.png)|*.png|gif文件(*.gif)|*.gif", InitialDirectory = "C:\\" };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = openFileDialog.FileName;
                this.pictureEditImage.Image = Image.FromFile(openFileDialog.FileName);
                var buttonImage = new GoImage();
                buttonImage.Name = openFileDialog.FileName;
                (dopGraphElement.First as GoButton).Icon = buttonImage;
            }
        }

        /// <summary>
        /// 基本参数
        /// </summary>
        private void BaseControlDataInit()
        {
            var goButton = dopGraphElement.First as GoButton;
            //位置、大小
            this.spinEditLeft.Value = ConvertUtil.ConvertToDecimal(goButton.Left);
            this.spinEditTop.Value = ConvertUtil.ConvertToDecimal(goButton.Top);
            this.spinEditWidth.Value = ConvertUtil.ConvertToDecimal(goButton.Width);
            this.spinEditHeight.Value = ConvertUtil.ConvertToDecimal(goButton.Height);
            var image = goButton.Icon as GoImage;
            this.txtImagePath.Text = image.Name;
            this.pictureEditImage.Image = image.Image;
        }

        //private void ActionDataInit()
        //{
        //    this.dopGraphElement.ActionScript.Where(v => v.ActionType == ActionType.Button).ToList()
        //        .ForEach(s =>
        //        {
        //            this.cboOperate.SelectedIndex = ConvertUtil.ConvertToInt(s.Expression[0]);
        //            txtFile.Text = ConvertUtil.ConvertToString(s.Condition[0]);
        //            if (s.Expression[0].Equals("1"))
        //            {
        //                spinTop.Value = ConvertUtil.ConvertToDecimal(s.Condition[1]);
        //                spinLeft.Value = ConvertUtil.ConvertToDecimal(s.Condition[2]);
        //                panelCtlSite.Visible = true;
        //            }
        //        });
        //}
        /// <summary>
        /// 动作选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (cboOperate.SelectedIndex == 2)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Title = "选择文件",
                    Filter = "执行文件|*.exe",
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    txtFile.Text = openFileDialog.FileName;
            }
            else
            {
                frmOpenDialog frm = new frmOpenDialog();
                if (frm.ShowDialog() == DialogResult.OK)
                    txtFile.Text = frm.GraphDoc.Name;
            }
        }

        private void cboOperate_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelCtlSite.Visible = cboOperate.SelectedIndex == 1 ? true : false;
            this.txtFile.Text = "";
        }
    }
}
