using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDAlgorithm.Logic
{
    /// <summary>
    /// 首出模块
    /// </summary>
    [Serializable]
    public class PIDFirst : PIDBindAlgorithm
    {
        #region 变量
        /// <summary>
        /// 复位输入为 1 时允许复位
        /// </summary>
        public const string InputRst = PIDAlgorithmToken.prefixInput + "Rst";

        /// <summary>
        /// 当输入有>=Num 个 1 时， DO 输出为 1
        /// </summary>
        public const string ParamNum = PIDAlgorithmToken.prefixParam + "Num";

        /// <summary>
        /// 数字输入量 1-8 为空则表示没有链接
        /// </summary> 
        public const string InputDI1 = PIDAlgorithmToken.prefixInput + "DI1";
        public const string InputDI2 = PIDAlgorithmToken.prefixInput + "DI2";
        public const string InputDI3 = PIDAlgorithmToken.prefixInput + "DI3";
        public const string InputDI4 = PIDAlgorithmToken.prefixInput + "DI4";
        public const string InputDI5 = PIDAlgorithmToken.prefixInput + "DI5";
        public const string InputDI6 = PIDAlgorithmToken.prefixInput + "DI6";
        public const string InputDI7 = PIDAlgorithmToken.prefixInput + "DI7";
        public const string InputDI8 = PIDAlgorithmToken.prefixInput + "DI8";


        public const string PrefixDI = PIDAlgorithmToken.prefixInput + "DI";
        /// <summary>
        /// 为 0 表示开关量无 0 到 1 变化；其他为输入第一个从 0 到 1 的开关量序号（ 1－8）
        /// </summary>
        public const string ResultY = PIDAlgorithmToken.prefixResult + "Y";
        /// <summary>
        /// 当前输入量或运算
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";
        /// <summary>
        /// 0：输入开关量无 0 到 1 的变化
        ///1：输入开关量有 0 到 1 的变化
        /// </summary>
        public const string ResultFDO = PIDAlgorithmToken.prefixResult + "FDO";

        private Dictionary<string, bool> lastCon = new Dictionary<string, bool>();
        #endregion

        #region Abstract class PIDAlgorithm

        /// <summary>
        /// 初始化输入参数
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputDI1] = new PIDAlgorithmVar(InputDI1, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI2] = new PIDAlgorithmVar(InputDI2, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI3] = new PIDAlgorithmVar(InputDI3, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI4] = new PIDAlgorithmVar(InputDI4, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI5] = new PIDAlgorithmVar(InputDI5, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI6] = new PIDAlgorithmVar(InputDI6, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI7] = new PIDAlgorithmVar(InputDI7, 0, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputDI8] = new PIDAlgorithmVar(InputDI8, 0, PIDVarInputType.Init, PIDVarDataType.DM);

            this.calcInputs[InputRst] = new PIDAlgorithmVar(InputRst, 1, PIDVarInputType.Init, PIDVarDataType.DM);
        }
        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamNum] = new PIDAlgorithmParam(ParamNum, 1);
        }

        /// <summary>
        /// 初始化输出参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultY] = new PIDAlgorithmVar(ResultY, PIDVarDataType.AM);
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
            this.calcResults[ResultFDO] = new PIDAlgorithmVar(ResultFDO, PIDVarDataType.DM);

        }
        /// <summary>
        /// 计算，如何设置结果输出
        /// </summary>
        /// <returns></returns>
        protected override void InternalDoCalc()
        {
            if (calcInputs[InputRst].Value == 1)
            {
                this.calcResults[ResultY].Value = 0;
                this.calcResults[ResultDO].Value = 0;
                this.calcResults[ResultFDO].Value = 0;
            }
            else
            {
                bool isChange = false;
                foreach (var item in calcInputs)
                {
                    if (!item.Key.Equals(InputRst))
                    {
                        if (item.Value.ValueToBool())
                        {
                            if (!lastCon.ContainsKey(item.Key))
                            {
                                lastCon.Add(item.Key, item.Value.ValueToBool());

                                isChange = true;
                            }
                        }
                        else
                        {
                            //false
                            if (lastCon.ContainsKey(item.Key))
                            {
                                lastCon.Remove(item.Key);
                            }
                        }
                    }
                }
                if (isChange)
                {
                    calcResults[ResultFDO].Value = 1;
                }
                else
                {
                    calcResults[ResultFDO].Value = 0;
                }
                if (lastCon.Count() >= calcParams[ParamNum].Value)
                {
                    calcResults[ResultDO].Value = 1;
                }
                if (lastCon.Keys.Count() <= 0)
                {
                    calcResults[ResultY].Value = 0;
                }
                else
                {
                    calcResults[ResultY].Value = Convert.ToDouble(lastCon.Keys.First<string>().Replace(PrefixDI, ""));
                }
            }
        }

        #endregion

        public override string AlgName
        {
            get { return "首出模块"; }
        }

    }
}
