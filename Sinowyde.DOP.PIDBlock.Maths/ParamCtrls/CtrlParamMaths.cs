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
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.Util;
using Sinowyde.DOP.PIDAlgorithm.Math;

namespace Sinowyde.DOP.PIDBlock.Math
{
    public partial class CtrlParamMaths : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamMaths()
        {
            InitializeComponent();
        }

        #region ICtrlParamBase
        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            txt_inputAI.Enabled = false;
            //if (string.IsNullOrEmpty(Algorithm.GetBindParam(txt_inputAI.Tag.ToString())))
            //{
            //    txt_inputAI.Enabled = true;
            //    txt_inputAI.Value = Convert.ToDecimal(Algorithm.GetInputVar(txt_inputAI.Tag.ToString()).Value);
            //}
            if (!Block.IsLinkLeftPort(PIDMaths.InputAI))
            {
                txt_inputAI.Enabled = true;
                txt_inputAI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDMaths.InputAI).Value);
            }
            this.txt_k1.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMaths.ParamK0).Value);
            this.txt_k2.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMaths.ParamK1).Value);
            this.txt_k3.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMaths.ParamK2).Value);
            this.txt_k4.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMaths.ParamK3).Value);
            this.txt_k5.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMaths.ParamK4).Value);
            this.txt_k6.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMaths.ParamK5).Value);
        }

        public bool SaveParam()
        {
            if (string.IsNullOrEmpty(Algorithm.GetBindParam(txt_inputAI.Tag.ToString())))
            {
                Algorithm.SetInputValue(txt_inputAI.Tag.ToString(), ConvertUtil.ConvertToDouble(txt_inputAI.Value));
            }
            Algorithm.GetParam(PIDMaths.ParamK0).Value = (double)this.txt_k1.Value;
            Algorithm.GetParam(PIDMaths.ParamK1).Value = (double)this.txt_k2.Value;
            Algorithm.GetParam(PIDMaths.ParamK2).Value = (double)this.txt_k3.Value;
            Algorithm.GetParam(PIDMaths.ParamK3).Value = (double)this.txt_k4.Value;
            Algorithm.GetParam(PIDMaths.ParamK4).Value = (double)this.txt_k5.Value;
            Algorithm.GetParam(PIDMaths.ParamK5).Value = (double)this.txt_k6.Value;
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }
        #endregion
    }
}

