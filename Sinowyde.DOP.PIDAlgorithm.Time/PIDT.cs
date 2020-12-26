
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Time
{
    ///<summary>
    /// ��ʱ���㷨�飨T��Timer33d6a
    /// </summary>
    public class PIDT : PIDBindAlgorithm
    {  ///<summary>
        /// ��ʱʱ�䵥λ����
        /// </summary>
        public const string ParamEndTime = PIDAlgorithmToken.prefixParam + "EndTime";
        ///<summary>
        /// ������ʽ
        /// </summary>
        public const string ParamMODE = PIDAlgorithmToken.prefixParam + "MODE";
        ///<summary>
        /// ��ʼ�����ź�
        /// </summary>
        public const string InputSET = PIDAlgorithmToken.prefixParam + "SET";
        ///<summary>
        /// ��λ�ź� RESET
        /// </summary>
        public const string InputRS = PIDAlgorithmToken.prefixParam + "RS";
        ///<summary>
        /// ��ǰ��ʱʱ��ֵ
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";
        ///<summary>
        /// ��ʱ���������
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        private double lastSet = 1;
        private double lastRS = 1;
        private double lastDO = 1;
        private double lastAO = 1;
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        protected override void InitCalcParams()
        {
            this.calcParams[ParamEndTime] = new PIDAlgorithmParam(ParamEndTime,1);
            this.calcParams[ParamMODE] = new PIDAlgorithmParam(ParamMODE, (int)TMode.TimerBasic);
        }

        protected override void InitCalcInputs()
        {
            this.calcInputs[InputSET] = new PIDAlgorithmVar(InputSET, 1, PIDVarInputType.Init, PIDVarDataType.DM);
            this.calcInputs[InputRS] = new PIDAlgorithmVar(InputRS, 1, PIDVarInputType.Init, PIDVarDataType.DM);
        }
        /// <summary>
        /// ��ʼ���������
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO);
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }

        /// <summary>
        ///4������˵��
        ///��ɶ�ʱ���������巢�������ͺ���λ���ͺ�λ���ͺ�λ���ֵȹ��ܡ�
        /// </summary>  
        protected override void InternalDoCalc()
        {
            double timer = this.calcParams[ParamEndTime].Value;
            double mode = this.calcParams[ParamMODE].Value;
            double set = this.calcInputs[InputSET].Value;
            double rs = this.calcInputs[InputRS].Value;
            double aOut = this.calcResults[ResultAO].Value;
            double dOut = this.calcResults[ResultDO].Value;

            bool Alarm = false;
            double dt = GetDt();
            double t = 0;
            TMode tm = (TMode)mode;
            //  setRS[2]={0,0};	    //in[0]:set ��ʼ�źţ�rs[1]��λ�ź�
            switch (tm)
            {
                case TMode.TimerBasic:
                    if (lastRS == 0 && rs == 1)
                    {
                        aOut = 0;
                        Alarm = false;
                        dOut = 0;
                    }//in[1]Ϊ��λֵ 
                    /*���1ʱֻά��һ������*/
                    if (lastDO == 1)
                        dOut = 0;
                    /*������ʱ�ӳ�DT*/
                    if (lastSet == 0 && set == 1)
                    {
                        Alarm = true;
                        aOut = timer + dt;
                    }	//int[0]Ϊset��ʼֵ		
                    /*��ʱ*/
                    if (Alarm)
                    {
                        aOut = aOut - dt;
                        if (aOut <= 0)
                            aOut = 0;

                        if (aOut == 0)
                        {
                            dOut = 1;
                            Alarm = false;
                        }
                        //    Aout = paraTIMER[ID].AIt - Aout;	//debug 2014-6-13		
                    }
                    break;
                case TMode.Pulse:
                    if (lastRS == 0 && rs == 1)
                    {
                        t = 0;
                        Alarm = false;
                        dOut = 0;
                        aOut = 0;
                    }
                    /*������ʱ*/
                    if (lastSet == 0 && set == 1)
                    {
                        dOut = 1;
                        aOut = 0;
                        Alarm = true;
                        t = 0;
                    }
                    /*��ʱ*/
                    if (t < timer && Alarm)
                    {
                        dOut = 1;
                        t = t + dt;
                        aOut = t;
                    }
                    else
                    {
                        Alarm = false;
                        t = 0;
                        dOut = 0;
                        aOut = 0;
                    }
                    break;
                case TMode.TDON:
                    if (lastRS == 0 && rs == 1)
                    {
                        t = timer;
                        Alarm = false;
                        dOut = 0;
                        aOut = 0;
                    }
                    /*����set�źű�0*/
                    if (lastSet == 1 && set == 0)
                    {
                        t = timer;
                        Alarm = false;
                        dOut = 0;
                        aOut = 0;
                    }
                    /*set �ź�������ʱ*/
                    if (lastSet == 0 && set == 1)
                    {
                        t = timer;
                        Alarm = true;
                        dOut = 0;
                        aOut = t;
                    }
                    if (Alarm)
                    {
                        if (t > 0)
                        {
                            dOut = 0;
                            t = t - dt;
                            aOut = t;
                        }
                        else
                        {
                            aOut = 0;
                            dOut = 1;
                        }
                        //   Aout = paraTIMER[ID].AIt - Aout;	//debug 2014-6-13		
                    }
                    break;
                case TMode.TDOFF:

                    if (set == 1)
                        dOut = 1;
                    //Mode3Init=1;


                    /*��λ*/
                    if (rs == 1)//( lastRS==0 && in[1]==1)	
                    {
                        t = 0;
                        Alarm = false;
                        dOut = 0;
                        aOut = 0;
                        //if(in[0]==1) 
                        //Mode3Init=1;
                    }
                    /*����������Ϊ������ʱ*/
                    if (lastSet == 0 && rs == 1)
                    {
                        t = 0;
                        //Mode3Init=0;
                        Alarm = false;
                        dOut = 1;
                        aOut = t;
                    }
                    /*��������Ϊ�½���ʱ*/
                    if (lastSet == 1 && rs == 0)
                    {
                        Alarm = true;
                        t = 0;
                        //Mode3Init=0; 
                        aOut = timer;
                    }

                    if (Alarm)
                    {
                        //if((t<DT) && (Mode3Init!=1)) 
                        if (t < timer)
                        {
                            t = t + dt;
                            aOut = aOut - dt;
                            dOut = 1;
                        }
                        else
                        {
                            aOut = 0;
                            dOut = 0;
                        }
                        //   Aout = paraTIMER[ID].AIt - Aout;	//debug 2014-6-13		
                    }
                    break;
                case TMode.LSH:
                    if (lastRS == 0 && rs == 1)
                    {
                        Alarm = false;
                        dOut = 0;
                        aOut = 0;
                    }
                    /*����������ʱ*/
                    if (lastSet == 0 && set == 1)
                    {
                        Alarm = true;
                        aOut = timer;
                    }

                    if (Alarm)
                    {
                        aOut = aOut - dt;
                        if (aOut <= 0)
                        {
                            aOut = 0;
                            Alarm = false;
                            dOut = 1;
                        }
                        //  Aout = paraTIMER[ID].AIt - Aout;	//debug 2014-6-13	
                    }
                    break;
            }
            this.calcResults[ResultAO].Value = aOut;
            this.calcResults[ResultDO].Value = dOut;
            lastDO = dOut;
            lastAO = aOut;
        }
    }
}