
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.Nonlinearity
{
    ///<summary>
    /// 滞环开关算法块（HYLOOP）Hysteresis Loop622da注意：此算法块去掉不做
    /// </summary>
    public class PIDHYLoop : PIDBindAlgorithm
    {  ///<summary>
        /// 死区值
        /// </summary>
        public const string ParamDead = PIDAlgorithmToken.prefixParam + "Dead";
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
        public const string InputAI1 = PIDAlgorithmToken.prefixInput + "AI1";
        ///<summary>
        /// 输出值
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";
        public const string LastAI1 = PIDAlgorithmToken.prefixResult + "LastAI1";
        public const string LastAO = PIDAlgorithmToken.prefixResult + "LastAO";

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamDead] = new PIDAlgorithmParam(ParamDead,1.0);
            this.calcParams[ParamY1] = new PIDAlgorithmParam(ParamY1, 1.0);
            this.calcParams[ParamY2] = new PIDAlgorithmParam(ParamY2, 1.0);
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI1] = new PIDAlgorithmVar(InputAI1, 0.0);
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO);
            this.calcResults[LastAI1] = new PIDAlgorithmVar(ResultAO);
            this.calcResults[LastAO] = new PIDAlgorithmVar(ResultAO);
        }

        /// <summary>
        ///4、功能说明
        ///当 AI1 大于等于 Dead 时，AO=Y1； 
        ///当 AI1 小于等于 -Dead 时，AO=Y2；
        ///当-Dead小于AI1小于Dead，且 AI1大于AI1(k-1)时，AO=Y2； 当-Dead小于AI1小于Dead，且 AI1小于AI1(k-1)时，AO=Y1；
        ///当-Dead小于AI1小于Dead，且 AI1=AI1(k-1)时，AO=AO(k-1)。
        ///式中：AI1(k-1)-前一时刻的输入值；
        ///AO(k-1)-前一时刻的输出值。 
        ///</summary>  
        protected override void InternalDoCalc()
        {
            double dead = calcParams[ParamDead].Value;
            //double nDead = calcParams[ParamDead].Value * -1;
            double y1 = calcParams[ParamY1].Value;
            double y2 = calcParams[ParamY2].Value;
            double ai1 = calcInputs[InputAI1].Value;

            double lastAI1 = this.calcResults[LastAI1].Value;
            double lastAO = this.calcResults[LastAO].Value;

            if (ai1 >= dead)
                calcResults[ResultAO].Value = y1;
            else if (ai1 <= -dead)
                calcResults[ResultAO].Value = y2;
            else if (-dead < ai1 && ai1 < dead)
            {
                if (ai1 > lastAI1)
                    calcResults[ResultAO].Value = y2;
                else if (ai1 < lastAI1)
                    calcResults[ResultAO].Value = y1;
                else if (ai1 == lastAI1)
                    calcResults[ResultAO].Value = lastAO;
            }

            this.calcResults[LastAI1].Value = ai1;
            this.calcResults[LastAO].Value = calcResults[ResultAO].Value;
        }
    }
}