
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinowyde.DOP.PIDAlgorithm.Time
{
    ///<summary>
    /// 定时器算法块（T）Timer33d6a
    /// </summary>
    public class PIDT : PIDBindAlgorithm
    {  ///<summary>
        /// 计时时间单位：秒
        /// </summary>
        public const string ParamEndTime = PIDAlgorithmToken.prefixParam + "EndTime";
        ///<summary>
        /// 工作方式
        /// </summary>
        public const string ParamMODE = PIDAlgorithmToken.prefixParam + "MODE";
        ///<summary>
        /// 开始工作信号
        /// </summary>
        public const string InputSET = PIDAlgorithmToken.prefixParam + "SET";
        ///<summary>
        /// 复位信号 RESET
        /// </summary>
        public const string InputRS = PIDAlgorithmToken.prefixParam + "RS";
        ///<summary>
        /// 当前定时时间值
        /// </summary>
        public const string ResultAO = PIDAlgorithmToken.prefixResult + "AO";
        ///<summary>
        /// 定时器脉冲输出
        /// </summary>
        public const string ResultDO = PIDAlgorithmToken.prefixResult + "DO";

        private double lastSet = 1;
        private double lastRS = 1;
        private double lastDO = 1;
        private double lastAO = 1;
        /// <summary>
        /// 初始化变量参数
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
        /// 初始化结果参数
        /// </summary>
        protected override void InitCalcResults()
        {
            this.calcResults[ResultAO] = new PIDAlgorithmVar(ResultAO);
            this.calcResults[ResultDO] = new PIDAlgorithmVar(ResultDO, PIDVarDataType.DM);
        }

        /// <summary>
        ///4、功能说明
        ///完成定时器，单脉冲发生器，滞后置位，滞后复位，滞后复位保持等功能。
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
            //  setRS[2]={0,0};	    //in[0]:set 开始信号，rs[1]复位信号
            switch (tm)
            {
                case TMode.TimerBasic:
                    if (lastRS == 0 && rs == 1)
                    {
                        aOut = 0;
                        Alarm = false;
                        dOut = 0;
                    }//in[1]为复位值 
                    /*输出1时只维持一个周期*/
                    if (lastDO == 1)
                        dOut = 0;
                    /*脉冲来时延迟DT*/
                    if (lastSet == 0 && set == 1)
                    {
                        Alarm = true;
                        aOut = timer + dt;
                    }	//int[0]为set开始值		
                    /*计时*/
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
                    /*脉冲来时*/
                    if (lastSet == 0 && set == 1)
                    {
                        dOut = 1;
                        aOut = 0;
                        Alarm = true;
                        t = 0;
                    }
                    /*计时*/
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
                    /*跟随set信号变0*/
                    if (lastSet == 1 && set == 0)
                    {
                        t = timer;
                        Alarm = false;
                        dOut = 0;
                        aOut = 0;
                    }
                    /*set 信号来脉冲时*/
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


                    /*复位*/
                    if (rs == 1)//( lastRS==0 && in[1]==1)	
                    {
                        t = 0;
                        Alarm = false;
                        dOut = 0;
                        aOut = 0;
                        //if(in[0]==1) 
                        //Mode3Init=1;
                    }
                    /*输入来脉冲为上升沿时*/
                    if (lastSet == 0 && rs == 1)
                    {
                        t = 0;
                        //Mode3Init=0;
                        Alarm = false;
                        dOut = 1;
                        aOut = t;
                    }
                    /*输入脉冲为下降沿时*/
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
                    /*输入来脉冲时*/
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