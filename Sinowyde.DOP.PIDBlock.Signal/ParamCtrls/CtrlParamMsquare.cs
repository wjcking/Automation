using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Signal;
using Sinowyde.Util;
using System;
namespace Sinowyde.DOP.PIDBlock.Signal
{
    public partial class CtrlParamMsquare : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamMsquare()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }

        public void LoadParam()
        {
            this.drpInputDI.Text = Algorithm.GetInputVar(PIDMsquare.InputDI).Value.ToString();

            this.txt_ParamSTime1.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSTime).Values[0]);
            this.txt_ParamSTime2.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSTime).Values[1]);
            this.txt_ParamSTime3.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSTime).Values[2]);
            this.txt_ParamSTime4.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSTime).Values[3]);
            this.txt_ParamSTime5.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSTime).Values[4]);
            this.txt_ParamSTime6.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSTime).Values[5]);
            this.txt_ParamSTime7.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSTime).Values[6]);
            this.txt_ParamSTime8.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSTime).Values[7]);
            this.txt_ParamSTime9.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSTime).Values[8]);
            this.txt_ParamSTime10.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSTime).Values[9]);

            this.txt_ParamSOut1.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSOut).Values[0]);
            this.txt_ParamSOut2.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSOut).Values[1]);
            this.txt_ParamSOut3.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSOut).Values[2]);
            this.txt_ParamSOut4.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSOut).Values[3]);
            this.txt_ParamSOut5.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSOut).Values[4]);
            this.txt_ParamSOut6.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSOut).Values[5]);
            this.txt_ParamSOut7.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSOut).Values[6]);
            this.txt_ParamSOut8.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSOut).Values[7]);
            this.txt_ParamSOut9.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSOut).Values[8]);
            this.txt_ParamSOut10.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMsquare.ParamSOut).Values[9]);

            this.drpInputDI.Enabled = !Block.IsLinkLeftPort(PIDMsquare.InputDI);  
        }

        public bool SaveParam()
        {
            if (!DataValidityChecked())
                return false;
            Algorithm.GetParam(PIDMsquare.ParamSTime).Values.Clear();
            Algorithm.GetParam(PIDMsquare.ParamSTime).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSTime1.Value));
            Algorithm.GetParam(PIDMsquare.ParamSTime).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSTime2.Value));
            Algorithm.GetParam(PIDMsquare.ParamSTime).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSTime3.Value));
            Algorithm.GetParam(PIDMsquare.ParamSTime).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSTime4.Value));
            Algorithm.GetParam(PIDMsquare.ParamSTime).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSTime5.Value));
            Algorithm.GetParam(PIDMsquare.ParamSTime).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSTime6.Value));
            Algorithm.GetParam(PIDMsquare.ParamSTime).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSTime7.Value));
            Algorithm.GetParam(PIDMsquare.ParamSTime).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSTime8.Value));
            Algorithm.GetParam(PIDMsquare.ParamSTime).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSTime9.Value));
            Algorithm.GetParam(PIDMsquare.ParamSTime).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSTime10.Value));
            Algorithm.GetParam(PIDMsquare.ParamSOut).Values.Clear();
            Algorithm.GetParam(PIDMsquare.ParamSOut).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSOut1.Value));
            Algorithm.GetParam(PIDMsquare.ParamSOut).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSOut2.Value));
            Algorithm.GetParam(PIDMsquare.ParamSOut).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSOut3.Value));
            Algorithm.GetParam(PIDMsquare.ParamSOut).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSOut4.Value));
            Algorithm.GetParam(PIDMsquare.ParamSOut).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSOut5.Value));
            Algorithm.GetParam(PIDMsquare.ParamSOut).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSOut6.Value));
            Algorithm.GetParam(PIDMsquare.ParamSOut).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSOut7.Value));
            Algorithm.GetParam(PIDMsquare.ParamSOut).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSOut8.Value));
            Algorithm.GetParam(PIDMsquare.ParamSOut).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSOut9.Value));
            Algorithm.GetParam(PIDMsquare.ParamSOut).Values.Add(ConvertUtil.ConvertToDouble(this.txt_ParamSOut10.Value));
            Algorithm.SetInputSourceValue(PIDMsquare.InputDI, ConvertUtil.ConvertToDouble(this.drpInputDI.Text));

            return true;
        }

        public UserControl GetParamCtrl()
        {
            return this;
        }


        /// <summary>
        /// ����У��
        /// </summary>
        /// <returns></returns>
        private bool DataValidityChecked()
        {
            if (this.txt_ParamSTime1.Value == 0 && this.txt_ParamSTime2.Value == 0 && this.txt_ParamSTime3.Value == 0 && this.txt_ParamSTime4.Value == 0
                    && this.txt_ParamSTime5.Value == 0 && this.txt_ParamSTime6.Value == 0 && this.txt_ParamSTime7.Value == 0 && this.txt_ParamSTime8.Value == 0
                    && this.txt_ParamSTime9.Value == 0 && this.txt_ParamSTime10.Value == 0)
            {
                XtraMessageBox.Show("�������۵�ʱ�����У�");
                return false;
            }
            if (this.txt_ParamSTime2.Value > 0 && this.txt_ParamSTime2.Value < this.txt_ParamSTime1.Value)
            {
                XtraMessageBox.Show("�۵������2����С��ǰһ�����1��");
                return false;
            }
            if (this.txt_ParamSTime3.Value > 0 && this.txt_ParamSTime3.Value < this.txt_ParamSTime2.Value)
            {
                XtraMessageBox.Show("�۵������3����С��ǰһ�����2��");
                return false;
            }
            if (this.txt_ParamSTime4.Value > 0 && this.txt_ParamSTime4.Value < this.txt_ParamSTime3.Value)
            {
                XtraMessageBox.Show("�۵������4����С��ǰһ�����3��");
                return false;
            }
            if (this.txt_ParamSTime5.Value > 0 && this.txt_ParamSTime5.Value < this.txt_ParamSTime4.Value)
            {
                XtraMessageBox.Show("�۵������5����С��ǰһ�����4��");
                return false;
            }
            if (this.txt_ParamSTime6.Value > 0 && this.txt_ParamSTime6.Value < this.txt_ParamSTime5.Value)
            {
                XtraMessageBox.Show("�۵������6����С��ǰһ�����5��");
                return false;
            }
            if (this.txt_ParamSTime7.Value > 0 && this.txt_ParamSTime7.Value < this.txt_ParamSTime6.Value)
            {
                XtraMessageBox.Show("�۵������7����С��ǰһ�����6��");
                return false;
            }
            if (this.txt_ParamSTime8.Value > 0 && this.txt_ParamSTime8.Value < this.txt_ParamSTime7.Value)
            {
                XtraMessageBox.Show("�۵������8����С��ǰһ�����7��");
                return false;
            }
            if (this.txt_ParamSTime9.Value > 0 && this.txt_ParamSTime9.Value < this.txt_ParamSTime8.Value)
            {
                XtraMessageBox.Show("�۵������9����С��ǰһ�����8��");
                return false;
            }
            if (this.txt_ParamSTime10.Value > 0 && this.txt_ParamSTime10.Value < this.txt_ParamSTime9.Value)
            {
                XtraMessageBox.Show("�۵������10����С��ǰһ�����9��");
                return false;
            }

            return DataCheck();
        }

        private bool DataCheck()
        { 
            string ctlTimeName = "txt_ParamSTime";
            string ctlOutName = "txt_ParamSOut";
            for (int i = 2; i < 11; i++)
            {
                SpinEdit ctlTime = this.groupPid.Controls[ctlTimeName + i.ToString()] as SpinEdit;
                SpinEdit ctlOut = this.groupPid.Controls[ctlOutName + i.ToString()] as SpinEdit;
                if (ctlTime.Value == 0 && ctlOut.Value != 0)
                {
                    XtraMessageBox.Show("ʱ�����������ֵ���в���Ӧ��");
                    return false;
                }
            }
            return true;
        }
    }
}
