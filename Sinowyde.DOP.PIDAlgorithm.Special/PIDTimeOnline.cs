using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDAlgorithm.Special
{
    /// <summary>
    /// 天在线时长
    /// </summary>
    [Serializable]
    public class PIDTimeOnline : PIDBindAlgorithm
    {
        #region 变量

        /// <summary>
        /// 输入参数名
        /// </summary>
        public const string InputDI1 = PIDAlgorithmToken.prefixInput + "DI1";
        public const string InputDI2 = PIDAlgorithmToken.prefixInput + "DI2";
        public const string InputDI3 = PIDAlgorithmToken.prefixInput + "DI3";
        public const string InputDI4 = PIDAlgorithmToken.prefixInput + "DI4";

        /// <summary>
        /// 输出结果名称
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";//毫秒单位在线时长

        /// <summary>
        /// 常量
        /// </summary>
        private const double hourMilliseconds = 60 * 60 * 1000;//一小时有多少毫秒

        #endregion

        #region PIDBindAlgorithm

        protected override void InitCalcInputs()
        {
            calcInputs[InputDI1] = new PIDAlgorithmVar(InputDI1, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            calcInputs[InputDI2] = new PIDAlgorithmVar(InputDI2, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            calcInputs[InputDI3] = new PIDAlgorithmVar(InputDI3, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            calcInputs[InputDI4] = new PIDAlgorithmVar(InputDI4, 0, PIDVarInputType.Init, PIDVarDataType.DM); 
        }

        protected override void InitCalcParams()
        {

        }

        protected override void InitCalcResults()
        {
            calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, 0, PIDVarInputType.Init, PIDVarDataType.AM); //初应该到数据库里取？
        }


        /// <summary>
        /// 因为现在没有刷新间隔,所以与LN系统计算方式不一样,目前采用累积时长差
        /// 因为不想引入数据库,会导致启动的当天计算结果不准确
        /// </summary>
        protected override void InternalDoCalc()
        {
            var cTime = DateTime.Now;
            if (GetDt() == 0)//第一次进来
            {
                calcResults[ResultAO].Value = 0;
                return;
            }

            var di1 = ConvertUtil.ConvertToBool(calcInputs[InputDI1].Value);
            var di2 = ConvertUtil.ConvertToBool(calcInputs[InputDI2].Value);
            var di3 = ConvertUtil.ConvertToBool(calcInputs[InputDI3].Value);
            var di4 = ConvertUtil.ConvertToBool(calcInputs[InputDI4].Value);

            if (di1 || di2 || di3 || di4)//在线判定条件：在线
            {
                if (!cTime.Day.Equals(LastCalcTime.Day))//处理跨度问题 
                {
                    var cZeroTime = new DateTime(cTime.Year, cTime.Month, cTime.Day, 0, 0, 0);//当天0点
                    var tmAfter = (cTime - cZeroTime).TotalMilliseconds;
                    //this.calcResults[ResultAO].Value += tmBefore;//最好库里取昨天的最后一个时刻值 +=tmBefore
                    calcResults[ResultAO].Value = tmAfter / hourMilliseconds;
                }
                else
                {
                    calcResults[ResultAO].Value += (cTime - LastCalcTime).TotalMilliseconds / hourMilliseconds;
                }

                if (Math.Abs(calcResults[ResultAO].Value - 24) <= (5000 / hourMilliseconds))
                    calcResults[ResultAO].Value = 24;

                calcResults[ResultAO].Value = MathEx.InRange(calcResults[ResultAO].Value, 0, 24); //处理[0-24]问题
            }
        }

        #endregion

        public override string AlgName
        {
            get { return "天在线时长算法块"; }
        }

    }
}
