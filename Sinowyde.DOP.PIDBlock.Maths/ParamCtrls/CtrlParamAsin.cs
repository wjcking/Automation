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
using DevExpress.XtraEditors.Controls;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Math;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDBlock.Math
{
    public partial class CtrlParamAsin : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamAsin()
        {
            InitializeComponent();
        }
        
        #region ICtrlParamBase
        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            cmb_ATrigonometricFunc.Properties.Items.Clear();
            cmb_ATrigonometricFunc.Properties.Items.AddRange(new PIDAsinHelper().GetShowTexts().ToArray<string>());
            cmb_ATrigonometricFunc.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            cmb_ATrigonometricFunc.Text = new PIDAsinHelper().GetKeyByValue((PIDAsins)Algorithm.GetParam(PIDASin.ParamATrigonometricFunc).Value);
            txt_inputAI.Enabled = false;
            if (!Block.IsLinkLeftPort(PIDASin.InputAI))
            {
                txt_inputAI.Enabled = true;
                txt_inputAI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDASin.InputAI).Value);
            }
            txt_paramBias.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam("paramBias").Value);
            txt_paramK.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam("paramK").Value);
            this.UpdateParams(true, Algorithm);
            this.txt_inputAI.Enabled = !Block.IsLinkLeftPort(PIDASin.InputAI);
        }

        public bool SaveParam()
        {
            if (string.IsNullOrEmpty(Algorithm.GetBindParam("inputAI")))
            {
                txt_inputAI.Enabled = true;
                Algorithm.SetInputSourceValue("inputAI", ConvertUtil.ConvertToDouble(txt_inputAI.Value));
            }
            Algorithm.SetParamValue("paramBias", ConvertUtil.ConvertToDouble(txt_paramBias.Value));
            Algorithm.SetParamValue("paramK", ConvertUtil.ConvertToDouble(txt_paramK.Value));

            PIDAsins selectType = new PIDAsinHelper().GetSelectValue(cmb_ATrigonometricFunc.Text);
            Algorithm.SetParamValue(PIDASin.ParamATrigonometricFunc, (double)selectType);

            ((FrmPIDBlockParam)this.ParentForm).NewImageName = string.Format("math_{0}_normal", cmb_ATrigonometricFunc.Text.ToLower());
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
        #endregion

        /// <summary>
        /// 输入值校验，反正弦与反余弦输入范围：-1~1,反正切为任意实数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_ATrigonometricFunc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmb_ATrigonometricFunc.SelectedIndex == 2)
            {
                this.txt_inputAI.Properties.MaxValue = 0;
                this.txt_inputAI.Properties.MinValue = 0;
            }
            else {
                this.txt_inputAI.Properties.MaxValue = 1;
                this.txt_inputAI.Properties.MinValue = -1;
            }
        }
    }
}
