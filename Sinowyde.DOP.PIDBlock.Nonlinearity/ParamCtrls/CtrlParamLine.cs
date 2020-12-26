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
using System.Collections;
using Sinowyde.Util;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Nonlinearity;

namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    public partial class CtrlParamLine : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamLine()
        {
            InitializeComponent();
        }

        #region ICtrlParamBase
        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            txt_inputAI.Enabled = false;
            if (!Block.IsLinkLeftPort(PIDLine.InputAI))
            {
                txt_inputAI.Enabled = true;
                txt_inputAI.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDLine.InputAI).Value);
            }
            this.txt_paramG1.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAI).Values[0]);
            this.txt_paramG2.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAI).Values[1]);
            this.txt_paramG3.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAI).Values[2]);
            this.txt_paramG4.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAI).Values[3]);
            this.txt_paramG5.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAI).Values[4]);
            this.txt_paramG6.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAI).Values[5]);
            this.txt_paramG7.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAI).Values[6]);
            this.txt_paramG8.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAI).Values[7]);
            this.txt_paramG9.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAI).Values[8]);
            this.txt_paramG10.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAI).Values[9]);
            this.txt_paramY1.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAO).Values[0]);
            this.txt_paramY2.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAO).Values[1]);
            this.txt_paramY3.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAO).Values[2]);
            this.txt_paramY4.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAO).Values[3]);
            this.txt_paramY5.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAO).Values[4]);
            this.txt_paramY6.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAO).Values[5]);
            this.txt_paramY7.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAO).Values[6]);
            this.txt_paramY8.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAO).Values[7]);
            this.txt_paramY9.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAO).Values[8]);
            this.txt_paramY10.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDLine.ParamSAO).Values[9]);
        }

        public bool SaveParam()
        {
            if (!DataValidityChecked())
                return false;
            if (string.IsNullOrEmpty(Algorithm.GetBindParam("inputAI")))
            {
                Algorithm.SetInputSourceValue("inputAI", ConvertUtil.ConvertToDouble(txt_inputAI.Value));
            }
            Algorithm.GetParam(PIDLine.ParamSAI).Values.Clear();
            Algorithm.GetParam(PIDLine.ParamSAI).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramG1.Value));
            Algorithm.GetParam(PIDLine.ParamSAI).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramG2.Value));
            Algorithm.GetParam(PIDLine.ParamSAI).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramG3.Value));
            Algorithm.GetParam(PIDLine.ParamSAI).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramG4.Value));
            Algorithm.GetParam(PIDLine.ParamSAI).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramG5.Value));
            Algorithm.GetParam(PIDLine.ParamSAI).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramG6.Value));
            Algorithm.GetParam(PIDLine.ParamSAI).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramG7.Value));
            Algorithm.GetParam(PIDLine.ParamSAI).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramG8.Value));
            Algorithm.GetParam(PIDLine.ParamSAI).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramG9.Value));
            Algorithm.GetParam(PIDLine.ParamSAI).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramG10.Value));

            Algorithm.GetParam(PIDLine.ParamSAO).Values.Clear();
            Algorithm.GetParam(PIDLine.ParamSAO).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramY1.Value));
            Algorithm.GetParam(PIDLine.ParamSAO).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramY2.Value));
            Algorithm.GetParam(PIDLine.ParamSAO).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramY3.Value));
            Algorithm.GetParam(PIDLine.ParamSAO).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramY4.Value));
            Algorithm.GetParam(PIDLine.ParamSAO).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramY5.Value));
            Algorithm.GetParam(PIDLine.ParamSAO).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramY6.Value));
            Algorithm.GetParam(PIDLine.ParamSAO).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramY7.Value));
            Algorithm.GetParam(PIDLine.ParamSAO).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramY8.Value));
            Algorithm.GetParam(PIDLine.ParamSAO).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramY9.Value));
            Algorithm.GetParam(PIDLine.ParamSAO).Values.Add(ConvertUtil.ConvertToDouble(this.txt_paramY10.Value));
            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }

        #endregion

        /// <summary>
        /// 数据校验
        /// </summary>
        /// <returns></returns>
        private bool DataValidityChecked()
        {
            if (this.txt_paramG1.Value == 0 && this.txt_paramG2.Value == 0 && this.txt_paramG3.Value == 0 && this.txt_paramG4.Value == 0
                    && this.txt_paramG5.Value == 0 && this.txt_paramG6.Value == 0 && this.txt_paramG7.Value == 0 && this.txt_paramG8.Value == 0
                    && this.txt_paramG9.Value == 0 && this.txt_paramG10.Value == 0)
            {
                XtraMessageBox.Show("请输入折点输入序列！");
                return false;
            }
            if (this.txt_paramG2.Value > 0 && this.txt_paramG2.Value < this.txt_paramG1.Value)
            {
                XtraMessageBox.Show("折点输入点2不能小于前一输入点1！");
                return false;
            }
            if (this.txt_paramG3.Value > 0 && this.txt_paramG3.Value < this.txt_paramG2.Value)
            {
                XtraMessageBox.Show("折点输入点3不能小于前一输入点2！");
                return false;
            }
            if (this.txt_paramG4.Value > 0 && this.txt_paramG4.Value < this.txt_paramG3.Value)
            {
                XtraMessageBox.Show("折点输入点4不能小于前一输入点3！");
                return false;
            }
            if (this.txt_paramG5.Value > 0 && this.txt_paramG5.Value < this.txt_paramG4.Value)
            {
                XtraMessageBox.Show("折点输入点5不能小于前一输入点4！");
                return false;
            }
            if (this.txt_paramG6.Value > 0 && this.txt_paramG6.Value < this.txt_paramG5.Value)
            {
                XtraMessageBox.Show("折点输入点6不能小于前一输入点5！");
                return false;
            }
            if (this.txt_paramG7.Value > 0 && this.txt_paramG7.Value < this.txt_paramG6.Value)
            {
                XtraMessageBox.Show("折点输入点7不能小于前一输入点6！");
                return false;
            }
            if (this.txt_paramG8.Value > 0 && this.txt_paramG8.Value < this.txt_paramG7.Value)
            {
                XtraMessageBox.Show("折点输入点8不能小于前一输入点7！");
                return false;
            }
            if (this.txt_paramG9.Value > 0 && this.txt_paramG9.Value < this.txt_paramG8.Value)
            {
                XtraMessageBox.Show("折点输入点9不能小于前一输入点8！");
                return false;
            }
            if (this.txt_paramG10.Value > 0 && this.txt_paramG10.Value < this.txt_paramG9.Value)
            {
                XtraMessageBox.Show("折点输入点10不能小于前一输入点9！");
                return false;
            }
            return DataCheck();
        }

        private bool DataCheck()
        {
            string ctlTimeName = "txt_paramG";
            string ctlOutName = "txt_paramY";

            for (int i = 2; i < 11; i++)
            {
                SpinEdit ctlTime = this.gc_bottom.Controls[ctlTimeName + i.ToString()] as SpinEdit;
                SpinEdit ctlOut = this.gc_bottom.Controls[ctlOutName + i.ToString()] as SpinEdit;

                if (ctlTime.Value == 0 && ctlOut.Value != 0)
                {
                    XtraMessageBox.Show("时间序列与输出值序列不对应！");
                    return false;
                }
            }


            var list = new Dictionary<decimal, int>();
            for (int i = 1; i < 11; i++)
            {
                SpinEdit ctlTime = this.gc_bottom.Controls[ctlTimeName + i.ToString()] as SpinEdit;
                if (ctlTime.Value != 0)
                {
                    if (!list.ContainsKey(ctlTime.Value))
                        list.Add(ctlTime.Value, 1);
                    else
                        list[ctlTime.Value]++;
                }
            }
            //if (list.Distinct().Count() != 10)
            foreach (var kv in list)
            {
                if (kv.Value > 1)
                {
                    XtraMessageBox.Show("折点输入顺序不能重复！");
                    return false;
                }
            }

            return true;
        }



        private void wq(object sender, EventArgs e)
        {

        }
    }
}
