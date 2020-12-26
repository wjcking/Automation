using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDAlgorithm.Logic
{
    public enum FxEnum : int
    {
        Bigger = 1,//>
        Samller = 2,//<
        Equal = 3,//=
        BiggerEqual = 4,//>=
        SamllerEqual = 5 //<=
    }
    
    /// <summary>
    /// 比较器算法块
    /// </summary>
    [Serializable]
    public class PIDComparer : PIDBindAlgorithm
    {
        #region 变量

        public const string ParamFx = PIDAlgorithmToken.prefixParam + "Fx";

        /// <summary>
        /// 不灵敏带
        /// </summary>
        public const string ParamBD = PIDAlgorithmToken.prefixParam + "BD";
        public const string InputAI1 = PIDAlgorithmToken.prefixInput + "AI1";
        public const string InputAI2 = PIDAlgorithmToken.prefixInput + "AI2";

        /// <summary>
        /// 数字量输出
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        #endregion

        #region Abstract class PIDAlgorithm

        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI1] = new PIDAlgorithmVar(InputAI1, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputAI2] = new PIDAlgorithmVar(InputAI2, 0, PIDVarInputType.Init, PIDVarDataType.AM);
        }

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamFx] = new PIDAlgorithmParam(ParamFx, (double)FxEnum.Bigger);
            this.calcParams[ParamBD] = new PIDAlgorithmParam(ParamBD);
           
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }

        /// <summary> 
        /// 4、功能说明
        ///COMPARE 模块比较两个模拟输入，执行逻辑比较功能，输出比较的逻辑结果。
        ///5、算法说明
        ///如果 Fx 为【 =】，则当 AI1=AI2 时 DO=1；否则 DO=0；
        ///如果 Fx 为【  大于 】，则当 AI1  大于 AI2 时 DO=1；否则 DO=0；
        ///如果 Fx 为【  小于 】，则当 AI1  小于  AI2 时 DO=1；否则 DO=0；
        ///如果 Fx 为【  大于 =】，则当 AI1≥AI2 时 DO=1；否则 DO=0；
        ///如果 Fx 为【  小于 =】，则当 AI1≤AI2 时 DO=1；否则 DO=0。
        ///如果 AI1 与 AI2 的绝对值之差小于不灵敏带 BD，那么 AI1， AI2 按照相等处理。
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            double bd = calcParams[ParamBD].Value;
            var fx = (FxEnum)(calcParams[ParamFx].Value);

            double ai1 = calcInputs[InputAI1].Value;
            double ai2 = calcInputs[InputAI2].Value;

            if (Math.Abs(Math.Abs(ai1) - Math.Abs(ai2)) < bd)
            {
                ai1 = ai2;
            }
            
            switch (fx)
            {
                case FxEnum.Bigger:
                    calcResults[ResultDO].Value = ai1 > ai2 ? 1 : 0;
                    break;
                case FxEnum.Samller:
                    calcResults[ResultDO].Value = ai1 < ai2 ? 1 : 0;
                    break;
                case FxEnum.Equal:
                    calcResults[ResultDO].Value = ai1.Equals(ai2) ? 1 : 0;
                    break;
                case FxEnum.BiggerEqual:
                    calcResults[ResultDO].Value = ai1 >= ai2 ? 1 : 0;
                    break;
                case FxEnum.SamllerEqual:
                    calcResults[ResultDO].Value = ai1 <= ai2 ? 1 : 0;
                    break;
            }
        }

        #endregion

        public override string AlgName
        {
            get { return "比较器算法块"; }
        }
    }
}
