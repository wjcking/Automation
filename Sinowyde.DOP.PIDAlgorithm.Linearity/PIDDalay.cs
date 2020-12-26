
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace Sinowyde.DOP.PIDAlgorithm.Linearity
{
    public class DelayTempData
    {
        public DateTime Timestamp
        {
            get;
            set;
        }

        public double Value
        {
            get;
            set;
        }
    }
    ///<summary>
    /// ���ӳ��㷨�飨DALAY�� 
    /// </summary>
    [Serializable]
    public class PIDDalay : PIDBindAlgorithm
    {
        ///<summary>
        /// ������ʱ��
        /// </summary>
        public const string ParamT = PIDAlgorithmToken.prefixParam + "T";
        ///<summary>
        /// ģ��������
        /// </summary>
        public const string InputAI = PIDAlgorithmToken.prefixInput + "AI";
        ///<summary>
        /// ���ֵ
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";

        [NonSerialized]
        private IList<DelayTempData> buffer = new List<DelayTempData>();

        private DelayTempData GetFirstValue()
        {
            if (buffer.Count > 0)
                return buffer[0];
            else
                return null;
        }
        /// <summary>
        /// ��ʼ����������,��λ����
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamT] = new PIDAlgorithmParam(ParamT, 10);
        }
        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcInputs()
        {
            this.calcInputs[InputAI] = new PIDAlgorithmVar(InputAI, 0, PIDVarInputType.Init, PIDVarDataType.AM);
        }
        /// <summary>
        /// ��ʼ���������,���㷨�ĵ���һ��
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO, 0, PIDVarInputType.Init, PIDVarDataType.AM);
        }
        /// <summary>
        ///4������˵��
        ///��ģ�齫ģ�������뾭���ӦӺ������
        ///5���㷨˵��
        ///AO = AI ? e?�� ?S
        ///�Ӳ���Ϊ������
        /// </summary>  
        protected override void InternalDoCalc()
        {
            DateTime timestamp = DateTime.Now;
            if(buffer.Count == 0 ||
                (timestamp - GetFirstValue().Timestamp).TotalSeconds < this.calcParams[ParamT].Value)
            {
                buffer.Add(new DelayTempData{ Timestamp=DateTime.Now, Value=this.calcInputs[InputAI].Value});                
            }
            else
            {
                this.calcResults[ResultAO].Value = this.GetFirstValue().Value;
                buffer.RemoveAt(0);
            }
        }

        public override string AlgName
        {
            get { return "���ӳ��㷨��"; }
        }
    }
}