
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 5.5M/A站优化算法块
    /// </summary>
    [Serializable]
    public class PIDMaex : PIDBindAlgorithm
    {
        #region 变量

        ///<summary>
        /// 输出增益
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";

        ///<summary>
        /// 输出偏置
        /// </summary>
        public const string ParamBias = PIDAlgorithmToken.prefixParam + "Bias";

        ///<summary>
        /// 输出上限
        /// </summary>
        public const string ParamYH = PIDAlgorithmToken.prefixParam + "YH";

        ///<summary>
        /// 输出下限
        /// </summary>
        public const string ParamYL = PIDAlgorithmToken.prefixParam + "YL";

        ///<summary>
        /// 设定值上限
        /// </summary>
        public const string ParamSPH = PIDAlgorithmToken.prefixParam + "SPH";

        ///<summary>
        /// 设定值下限
        /// </summary>
        public const string ParamSPL = PIDAlgorithmToken.prefixParam + "SPL";

        ///<summary>
        /// 初始化方式(0—手动；1—自动)
        /// </summary>
        public const string ParamFP = PIDAlgorithmToken.prefixParam + "FP";

        /////<summary>
        ///// 手动禁止(0—允许手动；1—只能自动)
        ///// </summary>
        //public const string ParamMANF = PIDAlgorithmToken.prefixParam + "MANF";

        ///<summary>
        /// 工作方式(0—Normal；1—Electric)
        /// </summary>
        public const string ParamMODE = PIDAlgorithmToken.prefixParam + "MODE";

        /////<summary>
        ///// Electric 输出方式(0—长信号；1—脉冲)
        ///// </summary>
        //public const string ParamEMODE = PIDAlgorithmToken.prefixParam + "EMODE";

        ///<summary>
        /// 跟踪切换时变化率
        /// </summary>
        public const string ParamTRATE = PIDAlgorithmToken.prefixParam + "TRATE";

        ///<summary>
        /// 死区
        /// </summary>
        public const string ParamDeadband = PIDAlgorithmToken.prefixParam + "Deadband";

        ///<summary>
        /// 手动自动面板  //-1默认,0手动,1自动
        /// </summary>
        public const string ParamDebugMode = PIDAlgorithmToken.prefixParam + "DebugMode";//-1默认,0手动,1自动

        /////<summary>
        ///// 高电平宽度
        ///// </summary>
        //public const string ParamOnTime = PIDAlgorithmToken.prefixParam + "OnTime";

        /////<summary>
        ///// 低电平宽度 
        ///// </summary>
        //public const string ParamOffTime = PIDAlgorithmToken.prefixParam + "OffTime";

        ///<summary>
        /// 手操板,点击标识
        /// </summary>
        public const string ParamTempFlag = PIDAlgorithmToken.prefixParam + "TempFlag";//0默认,1:SP增,2:SP减,3:SP直接输出,4:Y增,5:Y减,6:Y直接输出

        ///<summary>
        /// 手操板,点击数值
        /// </summary>
        public const string ParamTempValue = PIDAlgorithmToken.prefixParam + "TempValue";

        ///<summary>
        /// M/A 站输入
        /// </summary>
        public const string InputX = PIDAlgorithmToken.prefixInput + "X";

        ///<summary>
        /// 前馈输入
        /// </summary>
        public const string InputFF = PIDAlgorithmToken.prefixInput + "FF";

        ///<summary>
        /// 跟踪输入
        /// </summary>
        public const string InputTR = PIDAlgorithmToken.prefixInput + "TR";

        ///<summary>
        /// 位置反馈
        /// </summary>
        public const string InputYP = PIDAlgorithmToken.prefixInput + "YP";

        ///<summary>
        /// 给定跟踪
        /// </summary>
        public const string InputSPT = PIDAlgorithmToken.prefixInput + "SPT";

        ///<summary>
        /// 跟踪切换
        /// </summary>
        public const string InputTS = PIDAlgorithmToken.prefixInput + "TS";

        ///<summary>
        /// 闭锁增
        /// </summary>
        public const string InputBI = PIDAlgorithmToken.prefixInput + "BI";

        ///<summary>
        /// 闭锁减
        /// </summary>
        public const string InputBD = PIDAlgorithmToken.prefixInput + "BD";

        ///<summary>
        /// 强制手动信号
        /// </summary>
        public const string InputMRE = PIDAlgorithmToken.prefixInput + "MRE";

        ///<summary>
        /// 自动请求
        /// </summary>
        public const string InputAR = PIDAlgorithmToken.prefixInput + "AR";

        ///<summary>
        /// M/A 站输出
        /// </summary>
        public const string ResultY = PIDAlgorithmToken.prefixResult + "Y";

        ///<summary>
        /// 设定值输出
        /// </summary>
        public const string ResultSP = PIDAlgorithmToken.prefixResult + "SP";

        ///<summary>
        /// 手操器状态(0—自动；1—手动)
        /// </summary>
        public const string ResultS = PIDAlgorithmToken.prefixResult + "S";

        ///<summary>
        /// 输出增信号
        /// </summary>
        public const string ResultINC = PIDAlgorithmToken.prefixResult + "INC";

        ///<summary>
        /// 输出减信号
        /// </summary>
        public const string ResultDEC = PIDAlgorithmToken.prefixResult + "DEC";

        #endregion

        protected override void InitCalcParams()
        {
            calcParams[ParamK] = new PIDAlgorithmParam(ParamK, 1);
            calcParams[ParamBias] = new PIDAlgorithmParam(ParamBias);
            calcParams[ParamYH] = new PIDAlgorithmParam(ParamYH, 100);
            calcParams[ParamYL] = new PIDAlgorithmParam(ParamYL);
            //calcParams[ParamSPH] = new PIDAlgorithmParam(ParamSPH, 100);
            //calcParams[ParamSPL] = new PIDAlgorithmParam(ParamSPL);
            //calcParams[ParamTurnOver] = new PIDAlgorithmParam(ParamTurnOver, 0);//(0—0%~100%；1—100%~0%)
            calcParams[ParamFP] = new PIDAlgorithmParam(ParamFP, 0);//初始化方式(0—手动；1—自动)
            //calcParams[ParamMANF] = new PIDAlgorithmParam(ParamMANF, 0);//手动禁止(0—允许手动；1—只能自动)
            calcParams[ParamMODE] = new PIDAlgorithmParam(ParamMODE, 0);//工作方式(0—Normal；1—Electric)
            //calcParams[ParamEMODE] = new PIDAlgorithmParam(ParamEMODE, 1);//Electric 输出方式(0—长信号；1—脉冲)
            calcParams[ParamTRATE] = new PIDAlgorithmParam(ParamTRATE);
            calcParams[ParamDeadband] = new PIDAlgorithmParam(ParamDeadband);
            //calcParams[ParamOnTime] = new PIDAlgorithmParam(ParamOnTime, 1);
            //calcParams[ParamOffTime] = new PIDAlgorithmParam(ParamOffTime, 1);

            calcParams[ParamDebugMode] = new PIDAlgorithmParam(ParamDebugMode, -1);//-1默认,0手动,1自动


            calcParams[ParamTempFlag] = new PIDAlgorithmParam(ParamTempFlag, 0);
            calcParams[ParamTempValue] = new PIDAlgorithmParam(ParamTempValue, 0);

        }

        protected override void InitCalcInputs()
        {
            calcInputs[InputX] = new PIDAlgorithmVar(InputX, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            calcInputs[InputFF] = new PIDAlgorithmVar(InputFF, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            calcInputs[InputTR] = new PIDAlgorithmVar(InputTR, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            calcInputs[InputYP] = new PIDAlgorithmVar(InputYP, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            //calcInputs[InputSPT] = new PIDAlgorithmVar(InputSPT, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            calcInputs[InputTS] = new PIDAlgorithmVar(InputTS, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            calcInputs[InputBI] = new PIDAlgorithmVar(InputBI, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            calcInputs[InputBD] = new PIDAlgorithmVar(InputBD, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            calcInputs[InputMRE] = new PIDAlgorithmVar(InputMRE, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            calcInputs[InputAR] = new PIDAlgorithmVar(InputAR, 0, PIDVarInputType.Init, PIDVarDataType.DM);
        }

        protected override void InitCalcResults()
        {
            calcResults[ResultY] = new PIDAlgorithmVar(ResultY, PIDVarDataType.AM);
            //calcResults[ResultSP] = new PIDAlgorithmVar(ResultSP, PIDVarDataType.AM);
            calcResults[ResultS] = new PIDAlgorithmVar(ResultS, PIDVarDataType.DM);
            calcResults[ResultINC] = new PIDAlgorithmVar(ResultINC, PIDVarDataType.DM);
            calcResults[ResultDEC] = new PIDAlgorithmVar(ResultDEC, PIDVarDataType.DM);
        }

        private double ff_1 = 0;

        protected override void ResetEnvVars()
        {
            ff_1 = 0;
            base.ResetEnvVars();
        }


        protected override void InternalDoCalc()
        {
            var tempFlag = ConvertUtil.ConvertToInt(calcParams[ParamTempFlag].Value);
            var tempValue = calcParams[ParamTempValue].Value;

            var k = calcParams[ParamK].Value;
            var bias = calcParams[ParamBias].Value;
            var yh = calcParams[ParamYH].Value;
            var yl = calcParams[ParamYL].Value;
            //var sph = calcParams[ParamSPH].Value;
            //var spl = calcParams[ParamSPL].Value;
            var fp = calcParams[ParamFP].Value;
            //var manf = calcParams[ParamMANF].Value;
            var mode = calcParams[ParamMODE].Value;
            //var emode = calcParams[ParamEMODE].Value;
            var trate = calcParams[ParamTRATE].Value;
            var deadBand = calcParams[ParamDeadband].Value;
            //var onTime = calcParams[ParamOnTime].Value;
            //var offTime = calcParams[ParamOffTime].Value;
            var debugMode = calcParams[ParamDebugMode].Value;
            var x = calcInputs[InputX].Value;
            var ff = calcInputs[InputFF].Value;
            var tr = calcInputs[InputTR].Value;
            var yp = calcInputs[InputYP].Value;
            //var spt = calcInputs[InputSPT].Value;
            var ts = calcInputs[InputTS].Value;
            var bi = calcInputs[InputBI].Value;
            var bd = calcInputs[InputBD].Value;
            var mre = calcInputs[InputMRE].Value;
            var ar = calcInputs[InputAR].Value;


            double y_1 = calcResults[ResultY].Value;
            double y = 0;
            //double sp = 0;
            double inc = 0;
            double dec = 0;

            //sp = spt;
            var dt = GetDt();
            var flagIsAuto = IsAuto(dt, mre, ar, fp, debugMode);

            if (flagIsAuto) //自动
            {
                y = ConvertUtil.ConvertToInt(ts).Equals(1) ? tr : (k * x + bias) + (ff - ff_1);
                y = MathEx.ILandDL(y_1, y, bi, bd); //闭锁增减
            }
            else //手动
                y = ConvertUtil.ConvertToInt(ts).Equals(1) ? tr : y_1;

            if (!tempFlag.Equals(0))
            {
                switch (tempFlag) //0默认,1:SP增,2:SP减,3:SP直接输出,4:Y增,5:Y减,6:Y直接输出
                {
                    //case 1:
                    //    sp += tempValue;
                    //    calcParams[ParamTempFlag].Value = 0;
                    //    break;
                    //case 2:
                    //    sp += tempValue;
                    //    calcParams[ParamTempFlag].Value = 0;
                    //    break;
                    //case 3:
                    //    sp = tempValue;
                    //    calcParams[ParamTempFlag].Value = 0;
                    //    break;
                    case 4:
                        y += tempValue;
                        double yAddout = MathEx.OutRate(y_1, y, trate, GetDt());//输出变化率限制    
                        if (y <= yAddout)
                            calcParams[ParamTempFlag].Value = 0;
                        break;
                    case 5:
                        y += tempValue;
                        double ySubout = MathEx.OutRate(y_1, y, trate, GetDt());//输出变化率限制    
                        if (y >= ySubout)
                            calcParams[ParamTempFlag].Value = 0;
                        break;
                    case 6:
                        y = tempValue;
                        double yout = MathEx.OutRate(y_1, y, trate, GetDt());//输出变化率限制    
                        if (y_1 <= y) //Add
                        {
                            if (y <= yout)
                                calcParams[ParamTempFlag].Value = 0;
                        }
                        else //Sub
                        {
                            if (y >= yout)
                                calcParams[ParamTempFlag].Value = 0;
                        }
                        break;
                }
            }
            //切换变化率有问题,作用y,不作用sp   新老系统作用时间机制不同  +1 是一次一次的  还是按照时间做差值的 偏向1次1次的加？？
            y = MathEx.OutRate(y_1, y, trate, GetDt());//输出变化率限制    
            y = MathEx.InRange(y, yl, yh);             //输出上下限限制

            //sp = MathEx.InRange(sp, spl, sph);         //输出上下限限制

            if (ConvertUtil.ConvertToInt(mode).Equals(1))//工作方式(0—Normal;1—Electric)
            {
                //这里输出方式再扩展
                //if (ConvertUtil.ConvertToInt(emode).Equals(1))//脉冲
                //{
                //    //onTime 
                //    //offTime
                //    inc = y > yp + deadBand ? 1 : 0;
                //    dec = y < yp - deadBand ? 1 : 0;
                //}
                //else//长信号
                //{
                //}
                inc = y > yp + deadBand ? 1 : 0;
                dec = y < yp - deadBand ? 1 : 0;
            }

            ff_1 = ff;

            calcResults[ResultY].Value = y;
            //calcResults[ResultSP].Value = sp;
            calcResults[ResultS].Value = flagIsAuto ? 0 : 1;//自动状态0  手动状态1 
            calcResults[ResultINC].Value = inc;
            calcResults[ResultDEC].Value = dec;
        }

        /// <summary>
        /// 手自动判定函数
        /// </summary>
        /// <param name="dt">时间差,判断是否第一次计算,</param>
        /// <param name="mre">强制手动信号输入(mre=1时,手动)</param>
        /// <param name="ar">强制自动信号输入(ar=1时,自动)</param>
        /// <param name="fp">初始化方式(0—手动,1—自动)</param>
        /// <param name="debugMode">手动自动面板(-1默认,0手动,1自动)</param>
        /// <returns>true自动,false手动</returns>
        private bool IsAuto(double dt, double mre, double ar, double fp, double debugMode)
        {
            var flag = calcResults[ResultS].Value.Equals(0);//上一次状态值
            var flagDebugMode = ConvertUtil.ConvertToInt(debugMode);//手动自动面板,-1默认,0手动,1自动
            var flagMre = ConvertUtil.ConvertToInt(mre);
            var flagAr = ConvertUtil.ConvertToInt(ar);
            var flagFp = ConvertUtil.ConvertToInt(fp);

            if (ConvertUtil.ConvertToInt(dt).Equals(0))//第一次进来  只看fp
            {
                flag = flagFp.Equals(1);
            }
            else//其他情况  判断  mre,ar,zd,sd  原则优先手动
            {
                //手动优先
                if (flagDebugMode.Equals(0) || flagMre.Equals(1))
                    flag = false;

                else if (flagDebugMode.Equals(1) || flagAr.Equals(1))
                    flag = true;
            }

            calcParams[ParamDebugMode].Value = -1;//计算完一轮,把值重置一下
            return flag;
        }


        public override string AlgName
        {
            get { return "M/A站优化算法块"; }
        }
    }
}