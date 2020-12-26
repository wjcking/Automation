using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Control
{
    ///<summary>
    /// 数字手动站算法块（DMS）Digital Man Station4eecd
    /// </summary>
    public class PIDDms : PIDBindAlgorithm
    {

        ///<summary>
        /// Man 手动值
        /// </summary>
        public const string ParamMO = PIDAlgorithmToken.prefixParam + "MO";

        ///<summary>
        /// 选择手自动方式
        /// </summary>
        public const string ParamMA = PIDAlgorithmToken.prefixParam + "MA";

        ///<summary>
        /// 过程变量输入
        /// </summary>
        public const string InputPV = PIDAlgorithmToken.prefixInput + "PV";

        ///<summary>
        /// 手/自动切换允许信号(0—允许；1—禁止)
        /// </summary>
        public const string InputSI = PIDAlgorithmToken.prefixInput + "SI";

        ///<summary>
        /// 数字量输出
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        ///<summary>
        /// 状态指示输出(0—手动；1—自动)
        /// </summary>
        public const string ResultSO = PIDAlgorithmToken.prefixResult + "SO";

        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamMO] = new PIDAlgorithmVar(ParamMO, false, PIDVarDataType.Unknown);
            this.calcParams[ParamMA] = new PIDAlgorithmVar(ParamMA, false, PIDVarDataType.Unknown);
            this.calcParams[InputPV] = new PIDAlgorithmVar(InputPV, true, PIDVarDataType.DM);
            this.calcParams[InputSI] = new PIDAlgorithmVar(InputSI, true, PIDVarDataType.DM);
        }

        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, false, PIDVarDataType.DM);
            this.calcResults[ResultSO] = new PIDAlgorithmVar(ResultSO, false, PIDVarDataType.DM);

        }
        /// <summary>
        /// 4、功能说明
        ///数字手动站模块允许操作员在运行期间切换控制策略中的逻辑信号。 在自动方式下 DO 跟随 PV；
        ///在手动方式下 DO 由操作人员通过手操面板确定。
        ///5、算法说明
        ///自动：DO=PV 手动：DO=MANOUT
        ///当处于自动状态的时候，SO 为 1， 当处于手动状态的时候，SO 为 0。 只有手/自动切换允许信号 SI 为 0 时，才可以进行切换； SI 为 1 时，只能手动操作。
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double mo = this.calcParams[ParamMO].Value;
            double ma = this.calcParams[ParamMA].Value;
            double pv = this.calcParams[InputPV].Value; 
            //double do =  this.calcResults[ResultDO].Value;
            //double so =  ; 

            // 手/自动切换允许信号(0—  手动；1— 自动)
            if (this.calcParams[InputSI].Value == 1)
            {
                this.calcResults[ResultSO].Value = 0;
                this.calcResults[ResultDO].Value = pv;
            }
            else
            {
                this.calcResults[ResultSO].Value = 1;
                this.calcResults[ResultDO].Value = mo;
            }

        }
    }
}