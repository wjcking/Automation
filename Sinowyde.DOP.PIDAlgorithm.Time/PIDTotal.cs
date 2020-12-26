using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Time
{
    ///<summary>
    /// �������㷨�飨TOTAL��Total11f2c
    /// </summary>
    [Serializable]
    public class PIDTotal : PIDBindAlgorithm
    {
        ///<summary>
        /// ������ʽ
        /// </summary>
        public const string ParamMODE = PIDAlgorithmToken.prefixParam + "MODE";

        /// <summary>
        /// �����ֵ
        /// </summary>
        public const string ParamInit = PIDAlgorithmToken.prefixParam + "Init";

        /// <summary>
        /// ת��ϵ��
        /// </summary>
        public const string ParamK = PIDAlgorithmToken.prefixParam + "K";

        ///<summary>
        /// ����ֵ
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        ///<summary>
        /// ͳ�ƿ�ʼ/�����ź�
        /// </summary>
        public const string InputSET = PIDAlgorithmToken.prefixInput + "SET";
        ///<summary>
        /// ����ֵ
        /// </summary>
        public const string ResultIV = PIDAlgorithmToken.prefixResult + "IV";
        ///<summary>
        /// ��һ�λ���ֵ
        /// </summary>
        public const string ResultLV = PIDAlgorithmToken.prefixResult + "LV";

        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamMODE] = new PIDAlgorithmParam(ParamMODE, (int)TotalMode.Sum);
            this.calcParams[ParamInit] = new PIDAlgorithmParam(ParamInit, 0);
            this.calcParams[ParamK] = new PIDAlgorithmParam(ParamK, 1);
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, 0, PIDVarInputType.Init, PIDVarDataType.AM);
            this.calcInputs[InputSET] = new PIDAlgorithmVar(InputSET, 0, PIDVarInputType.Init, PIDVarDataType.DM);
        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultIV] = new PIDAlgorithmVar(ResultIV, PIDVarDataType.AM);
            this.calcResults[ResultLV] = new PIDAlgorithmVar(ResultLV, PIDVarDataType.AM);
        }
        /// <summary>
        /// ������� ��һ��Ϊ0
        /// </summary>
        private int count = 0;
        /// <summary>
        /// ��һ������
        /// </summary>
        private double lastAI = 0;
        private double lastLV = 0;

        private double lastMaxAI = 0;
        private double lastMinAI = 0;
        private double lastAvg = 0;

        /// <summary>
        /// ���ò���
        /// </summary>
        protected override void ResetEnvVars()
        {
            base.ResetEnvVars();
            count = 0;
            lastAI = 0;
        }

        /// <summary>
        /// [�°汾]���㹫ʽ˵����
        ///1���ۼӣ�
        ///     Y0=�����ֵ + AI _0* ת��ϵ����
        ///     Y1=Y0 + AI_1 * ת��ϵ����
        ///     Y2=Y1 + AI_2 * ת��ϵ����
        ///2��ƽ����
        ///     Y0=�����ֵ + AI_0 * ת��ϵ����
        ///     Y1=�����ֵ + (AI_0 * ת��ϵ��+AI_1 * ת��ϵ��) / 2��
        ///     Y2=�����ֵ + (AI_0 * ת��ϵ��+AI_1 * ת��ϵ��+AI_2 * ת��ϵ��) / 3��
        ///3��MAX��
        ///     Y0=�����ֵ + AI_0 * ת��ϵ����
        ///     Y1=�����ֵ + MAX(AI_0 * ת��ϵ��, AI_1 * ת��ϵ��) ��
        ///     Y2=�����ֵ + MAX(AI_0 * ת��ϵ��, AI_1 * ת��ϵ��, AI_2 * ת��ϵ��) ��
        ///4��MIN ��MAX��ͬ��
        ///5�������ۼӺͣ�
        ///      Y0=�����ֵ + AI_0 * ת��ϵ�� * DT / 2��
        ///      Y1=Y0 + (AI_0 * ת��ϵ��+AI_1 * ת��ϵ��) * DT / 2��
        ///      Y2=Y1 + (AI_1 * ת��ϵ��+AI_2 * ת��ϵ��) * DT / 2��
        /// </summary>
        protected override void InternalDoCalc()
        {
            double k = this.calcParams[ParamK].Value;
            //����ת��ϵ�� ai * k
            double ai = this.calcInputs[InputAI].Value * k;
            double init = this.calcParams[ParamInit].Value;
            //����ǵ�һ�μ���
           // init = count == 0 ? init : 0;
            int set = ConvertUtil.ConvertToInt(this.calcInputs[InputSET].Value);

            if (set == 0)
            {
                this.calcResults[ResultIV].Value = 0;
                this.calcResults[ResultLV].Value = 0;
                count = 0;
            }
            else
            {
                //��һ���Ƿ����ת��ϵ��  * k; ����
                this.calcResults[ResultLV].Value = lastLV;
                int mode = ConvertUtil.ConvertToInt(this.calcParams[ParamMODE].Value);
                TotalMode tm = (TotalMode)mode;
                switch (tm)
                {
                    case TotalMode.Sum:
                        this.calcResults[ResultIV].Value = init + (lastLV + ai);
                        break;
                    case TotalMode.Min:
                        lastMinAI = Math.Min(lastAI, ai);
                        this.calcResults[ResultIV].Value = init + lastMinAI;
                        break;
                    case TotalMode.Max:
                        lastMaxAI = Math.Max(lastMaxAI, ai);
                        this.calcResults[ResultIV].Value = init + lastMaxAI;
                        break;
                    case TotalMode.Avg:
                        lastAvg += ai;
                        this.calcResults[ResultIV].Value = init + lastAvg / (count + 1);
                        //this.calcResults[ResultIV].Value = init + ((lastLV * count + ai) / (count + 1));
                        break;
                    case TotalMode.StepSum:// IV(n)=IV(n-1)+(AI(n-1)+AI(n))*DT/2
                        this.calcResults[ResultIV].Value = init + (lastLV + (lastAI + ai) * GetDt() / 2);
                        break;
                }

                count++;
                lastLV = this.calcResults[ResultIV].Value;
                lastAI = ai;

            }
        }

        public override string AlgName
        {
            get { return "�������㷨��"; }
        }
    }
}