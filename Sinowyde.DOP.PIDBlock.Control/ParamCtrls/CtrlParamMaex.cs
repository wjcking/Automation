using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.DTProxy;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDAlgorithm.Control;
using Sinowyde.Util;
namespace Sinowyde.DOP.PIDBlock.Control
{
    public partial class CtrlParamMaex : XtraUserControl, ICtrlParamBase
    {
        public CtrlParamMaex()
        {
            InitializeComponent();
        }

        public PIDGeneralBlock Block { get; set; }

        private PIDBindAlgorithm Algorithm { get { return Block.Algorithm; } }


        public void LoadParam()
        {
            this.spinParamK.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMaex.ParamK).Value);
            this.spinParamBias.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMaex.ParamBias).Value);
            this.spinParamYH.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMaex.ParamYH).Value);
            this.spinParamYL.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMaex.ParamYL).Value);
            this.spinParamSPH.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMaex.ParamSPH).Value);
            this.spinParamSPL.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMaex.ParamSPL).Value);
            this.drpParamFP.SelectedIndex = ConvertUtil.ConvertToInt(Algorithm.GetParam(PIDMaex.ParamFP).Value);
            this.drpParamMODE.SelectedIndex = ConvertUtil.ConvertToInt(Algorithm.GetParam(PIDMaex.ParamMODE).Value);
            this.spinParamTRATE.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMaex.ParamTRATE).Value);
            this.spinParamDeadband.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetParam(PIDMaex.ParamDeadband).Value);
            this.spinInputX.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDMaex.InputX).Value);
            this.spinInputFF.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDMaex.InputFF).Value);
            this.spinInputTR.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDMaex.InputTR).Value);
            this.spinInputYP.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDMaex.InputYP).Value);
            this.spinInputSPT.Value = ConvertUtil.ConvertToDecimal(Algorithm.GetInputVar(PIDMaex.InputSPT).Value);
            this.drpInputTS.Text = Algorithm.GetInputVar(PIDMaex.InputTS).Value.ToString();
            this.drpInputBI.Text = Algorithm.GetInputVar(PIDMaex.InputBI).Value.ToString();
            this.drpInputBD.Text = Algorithm.GetInputVar(PIDMaex.InputBD).Value.ToString();
            this.drpInputMRE.Text = Algorithm.GetInputVar(PIDMaex.InputMRE).Value.ToString();
            this.drpInputAR.Text = Algorithm.GetInputVar(PIDMaex.InputAR).Value.ToString();

            //链接后不可用
            this.spinInputX.Enabled = !Block.IsLinkLeftPort(PIDMaex.InputX);
            this.spinInputFF.Enabled = !Block.IsLinkLeftPort(PIDMaex.InputFF);
            this.spinInputTR.Enabled = !Block.IsLinkLeftPort(PIDMaex.InputTR);
            this.spinInputYP.Enabled = !Block.IsLinkLeftPort(PIDMaex.InputYP);
            this.drpInputTS.Enabled = !Block.IsLinkLeftPort(PIDMaex.InputTS);
            this.drpInputBI.Enabled = !Block.IsLinkLeftPort(PIDMaex.InputBI);
            this.drpInputBD.Enabled = !Block.IsLinkLeftPort(PIDMaex.InputBD);
            this.drpInputMRE.Enabled = !Block.IsLinkLeftPort(PIDMaex.InputMRE);
            this.spinInputSPT.Enabled = !Block.IsLinkLeftPort(PIDMaex.InputSPT);

            this.drpInputAR.Enabled = !Block.IsLinkLeftPort(PIDMaex.InputAR);
        }

        public bool SaveParam()
        {
            Algorithm.SetParamValue(PIDMaex.ParamK, ConvertUtil.ConvertToDouble(this.spinParamK.Value));
            Algorithm.SetParamValue(PIDMaex.ParamBias, ConvertUtil.ConvertToDouble(this.spinParamBias.Value));
            Algorithm.SetParamValue(PIDMaex.ParamYH, ConvertUtil.ConvertToDouble(this.spinParamYH.Value));
            Algorithm.SetParamValue(PIDMaex.ParamYL, ConvertUtil.ConvertToDouble(this.spinParamYL.Value));
            Algorithm.SetParamValue(PIDMaex.ParamSPH, ConvertUtil.ConvertToDouble(this.spinParamSPH.Value));
            Algorithm.SetParamValue(PIDMaex.ParamSPL, ConvertUtil.ConvertToDouble(this.spinParamSPL.Value));
            Algorithm.SetParamValue(PIDMaex.ParamFP, this.drpParamFP.SelectedIndex);
            Algorithm.SetParamValue(PIDMaex.ParamMODE, this.drpParamMODE.SelectedIndex);
            Algorithm.SetParamValue(PIDMaex.ParamTRATE, ConvertUtil.ConvertToDouble(this.spinParamTRATE.Value));
            Algorithm.SetParamValue(PIDMaex.ParamDeadband, ConvertUtil.ConvertToDouble(this.spinParamDeadband.Value));

            Algorithm.SetInputSourceValue(PIDMaex.InputSPT, ConvertUtil.ConvertToDouble(this.spinInputSPT.Value));
            Algorithm.SetInputSourceValue(PIDMaex.InputX, ConvertUtil.ConvertToDouble(this.spinInputX.Value));
            Algorithm.SetInputSourceValue(PIDMaex.InputFF, ConvertUtil.ConvertToDouble(this.spinInputFF.Value));
            Algorithm.SetInputSourceValue(PIDMaex.InputTR, ConvertUtil.ConvertToDouble(this.spinInputTR.Value));
            Algorithm.SetInputSourceValue(PIDMaex.InputYP, ConvertUtil.ConvertToDouble(this.spinInputYP.Value));
            Algorithm.SetInputSourceValue(PIDMaex.InputTS, ConvertUtil.ConvertToDouble(this.drpInputTS.Text));
            Algorithm.SetInputSourceValue(PIDMaex.InputBI, ConvertUtil.ConvertToDouble(this.drpInputBI.Text));
            Algorithm.SetInputSourceValue(PIDMaex.InputBD, ConvertUtil.ConvertToDouble(this.drpInputBD.Text));
            Algorithm.SetInputSourceValue(PIDMaex.InputMRE, ConvertUtil.ConvertToDouble(this.drpInputMRE.Text));
            Algorithm.SetInputSourceValue(PIDMaex.InputAR, ConvertUtil.ConvertToDouble(this.drpInputAR.Text));
            return true;
        }


        public UserControl GetParamCtrl()
        {
            return this;
        }

        private bool IsAuto()
        {
            var resultS = Algorithm.GetResultVarName(PIDMaex.ResultS);
            var realResultValue = RTValueMemCache.Instance().GetValue(resultS);
            if (null == realResultValue || realResultValue.Value.Equals(0))//自动状态0  手动状态1 
                return true;

            return false;
        }

        private PIDCommmandMsg CreateParamMsg(string token)
        {
            var msg = new PIDCommmandMsg();
            msg.CommandType = PIDCommandType.ForceValue;
            msg.TakeEffect = true;
            msg.Guid = Algorithm.Identity;
            msg.ParamType = PIDCommandParamType.Param;
            msg.Token = token;
            return msg;
        }

        private void btnSP_Click(object sender, System.EventArgs e)
        {
            //Flag://0默认,1:SP增,2:SP减,3:SP直接输出,4:Y增,5:Y减,6:Y直接输出
            //sp增,sp减,sp直接输出,在手动自动状态下都有效
            //y增,y减,y直接输出,仅在手动状态下有效
            var simpleButton = sender as SimpleButton;
            if (simpleButton.Name.Equals("btnAuto") || simpleButton.Name.Equals("btnManual"))//操作面板手自动切换,等待外界条件更改后,取消强制 
            {
                var msg = new PIDCommmandMsg();
                msg.CommandType = PIDCommandType.ForceValue;//(BUG 关闭软件状态不能重置)
                msg.TakeEffect = true;
                msg.Guid = Algorithm.Identity;
                msg.ParamType = PIDCommandParamType.Param;
                msg.Token = PIDMaex.ParamDebugMode;
                msg.Value = simpleButton.Name.Equals("btnAuto") ? "1" : "0";
                PIDGeneralBlock.CommandAction(msg.ToString(), -1);
            }
            else
            {
                var msgFlag = CreateParamMsg(PIDMaex.ParamTempFlag);
                var msgValue = CreateParamMsg(PIDMaex.ParamTempValue);
                switch (simpleButton.Name)
                {
                    case "btnAdd"://SP增
                        msgFlag.Value = "1";
                        msgValue.Value = (this.spinInc.Value).ToString();
                        PIDGeneralBlock.CommandAction(msgValue.ToString(), -1);
                        PIDGeneralBlock.CommandAction(msgFlag.ToString(), -1);
                        break;
                    case "btnDec"://SP减
                        msgFlag.Value = "2";
                        msgValue.Value = (-1 * this.spinDec.Value).ToString();
                        PIDGeneralBlock.CommandAction(msgValue.ToString(), -1);
                        PIDGeneralBlock.CommandAction(msgFlag.ToString(), -1);
                        break;
                    case "btnOut"://SP直接输出
                        msgFlag.Value = "3";
                        msgValue.Value = (this.spinOut.Value).ToString();
                        PIDGeneralBlock.CommandAction(msgValue.ToString(), -1);
                        PIDGeneralBlock.CommandAction(msgFlag.ToString(), -1);
                        break;
                    case "btnManInc"://手动增  y增,y减,y直接输出,仅在手动状态下有效
                        if (!IsAuto())
                        {
                            msgFlag.Value = "4";
                            msgValue.Value = (this.spinMInc.Value).ToString();
                            PIDGeneralBlock.CommandAction(msgValue.ToString(), -1);
                            PIDGeneralBlock.CommandAction(msgFlag.ToString(), -1);
                        }
                        break;
                    case "btnManDec"://手动减  y增,y减,y直接输出,仅在手动状态下有效
                        if (!IsAuto())
                        {
                            msgFlag.Value = "5";
                            msgValue.Value = (-1 * this.spinMDec.Value).ToString();
                            PIDGeneralBlock.CommandAction(msgValue.ToString(), -1);
                            PIDGeneralBlock.CommandAction(msgFlag.ToString(), -1);
                        }
                        break;
                    case "btnOutY"://Y直接输出  y增,y减,y直接输出,仅在手动状态下有效
                        if (!IsAuto())
                        {
                            msgFlag.Value = "6";
                            msgValue.Value = (this.spinYOut.Value).ToString();
                            PIDGeneralBlock.CommandAction(msgValue.ToString(), -1);
                            PIDGeneralBlock.CommandAction(msgFlag.ToString(), -1);
                        }
                        break;
                }
            }

        }
    }
}
