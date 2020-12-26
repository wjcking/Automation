using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Northwoods.Go;

namespace Sinowyde.DOP.GraphicElement.Base
{
    public partial class FrmGraphParam : XtraForm
    {
        public ICtrlParamBase CtrlParam
        {
            get;
            protected set;
        }

        public FrmGraphParam()
        {
            InitializeComponent();
        }

        public void SetCtrlParam(ICtrlParamBase ctrlParam, string FormTitle)
        {
            if (ctrlParam != null)
            {
                var ctl = ctrlParam.GetParamCtrl();
                this.CtrlParam = ctrlParam;
                this.pnlCtrMain.Controls.Clear();
                ctl.SetBounds(6, 6, ctl.Width, ctl.Height);
                this.pnlCtrMain.Controls.Add(ctl);
                this.Width = ctl.Width + 30;
                this.Height = ctl.Height + 100;
                this.Text = FormTitle;
                ctrlParam.LoadParam();
            }
        }

        /// <summary>
        /// 关闭画面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            if (CtrlParam != null)
            {
                if (CtrlParam.SaveParam() == true)
                    Close();
            }
        }
    }
}
