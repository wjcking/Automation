
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Nonlinearity
{
    ///<summary>
    /// 磁放算法块（MAGAMP）Magnetic Amplifier1cd04　　注意：此算法块去掉不做
    /// </summary>
    [Serializable]
    public class PIDMagAmp : PIDBindAlgorithm
    {
        ///<summary>
        /// 死区值
        /// </summary>
        public const string ParamDead = PIDAlgorithmToken.prefixParam + "Dead";
        ///<summary>
        /// 磁放区
        /// </summary>
        public const string ParamMag = PIDAlgorithmToken.prefixParam + "Mag";
        ///<summary>
        /// 输出 Y1
        /// </summary>
        public const string ParamY1 = PIDAlgorithmToken.prefixParam + "Y1";
        ///<summary>
        /// 输出 Y2
        /// </summary>
        public const string ParamY2 = PIDAlgorithmToken.prefixParam + "Y2";
        ///<summary>
        /// 输入值
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        ///<summary>
        /// 输出值
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";
        public const string LastAI = PIDAlgorithmToken.prefixResult + "LastAI";

        public override string AlgName
        {
            get { return "磁放算法块"; }
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamDead] = new PIDAlgorithmParam(ParamDead,1.0);
            this.calcParams[ParamMag] = new PIDAlgorithmParam(ParamMag,1.0);
            this.calcParams[ParamY1] = new PIDAlgorithmParam(ParamY1,1.0);
            this.calcParams[ParamY2] = new PIDAlgorithmParam(ParamY2,1.0);
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, 0.0, PIDVarInputType.Init, PIDVarDataType.AM);
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, PIDVarDataType.AM);
            this.calcResults[LastAI] = new PIDAlgorithmVar(LastAI, PIDVarDataType.AM);
        }

        /// <summary>
        ///4、功能说明 
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double dead = calcParams[ParamDead].Value;
            //double nDead = calcParams[ParamDead].Value * -1;
            double mag = calcParams[ParamMag].Value;
            //double nMag = calcParams[ParamMag].Value * -1;
            double y1 = calcParams[ParamY1].Value;
            double y2 = calcParams[ParamY2].Value;
            double ai = calcInputs[InputAI].Value;
            double lastAI = this.calcResults[LastAI].Value;
            //if (ai > lastAI)
            //{
            //    if (ai >= mag)
            //        calcResults[ResultAO].Value = y1;
            //    else if (nDead < ai && ai < mag)
            //        calcResults[ResultAO].Value = 0;
            //    else if (ai <= nDead)
            //        calcResults[ResultAO].Value = y2;
            //}
            //else if (ai < lastAI)
            //{
            //    if (ai >= dead)
            //        calcResults[ResultAO].Value = y1;
            //    else if (nMag < ai && ai < dead)
            //        calcResults[ResultAO].Value = 0;
            //    else if (ai <= nMag)
            //        calcResults[ResultAO].Value = y2;
            //}

            if (ai > lastAI)
            {
                if (ai >= mag)
                    calcResults[ResultAO].Value = y1;
                else if (-dead < ai && ai < mag)
                    calcResults[ResultAO].Value = 0;
                else if (ai <= -dead)
                    calcResults[ResultAO].Value = y2;
            }
            else if (ai < lastAI)
            {
                if (ai >= dead)
                    calcResults[ResultAO].Value = y1;
                else if (-mag < ai && ai < dead)
                    calcResults[ResultAO].Value = 0;
                else if (ai <= -mag)
                    calcResults[ResultAO].Value = y2;
            }
            this.calcResults[LastAI].Value = ai;

        }
    }
}