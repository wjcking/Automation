using Newtonsoft.Json;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm
{
    public class PIDAlgTopic
    {
        /// <summary>
        /// 下发命令主题
        /// </summary>
        public const string PIDCommand = "PIDCommand";
        /// <summary>
        /// 下发命令返回报文
        /// </summary>
        public const string PIDReCommand = "PIDReCommand";
    }

    /// <summary>
    /// 命令内容
    /// </summary>
    public enum PIDCommandType
    {
        RunDebug = 0, //在线调试
        OfflineDebug, //开环调试
        ForceValue, //强制
        KeepValue,  //跟随
        Download,   //下装运行
        GetDebugSet, //获取调试设置
        Reset       //状态重置
    }

    /// <summary>
    /// 设置数值的类型
    /// </summary>
    public enum PIDCommandParamType
    {
        Param = 0, //参数
        Input,  //输入
        Output  //输出
    }

    /// <summary>
    /// PID命令报文
    /// </summary>
    public class PIDCommmandMsg
    {
        /// <summary>
        /// 命令类型
        /// </summary>
        public PIDCommandType CommandType
        {
            get;
            set;
        }
        /// <summary>
        /// 是否生效
        /// </summary>
        public bool TakeEffect
        {
            get;
            set;
        }
        /// <summary>
        /// 算法块标记
        /// </summary>
        public string Guid
        {
            get;
            set;
        }
        /// <summary>
        /// 输入、输出、参数标记
        /// </summary>
        public string Token
        {
            get;
            set;
        }
        /// <summary>
        /// 参数类型
        /// </summary>
        public PIDCommandParamType ParamType
        {
            get;
            set;
        }
        /// <summary>
        /// 目标值
        /// </summary>
        public string Value
        {
            get;
            set;
        }
        /// <summary>
        /// 是否是差值
        /// </summary>
        public bool IsBias
        {
            get;
            set;
        }
        /// <summary>
        /// 序列化为字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4} {5} {6}", (int)this.CommandType,
                this.TakeEffect.ToString(), this.Guid, this.Token,
                ((int)this.ParamType).ToString(), this.Value, this.IsBias.ToString());
        }


        /// <summary>
        /// 反序列化
        /// </summary>
        public static PIDCommmandMsg FromString(string content)
        {
            try
            {
                string[] vs = content.Split(new char[] { ' ' }, StringSplitOptions.None);
                return new PIDCommmandMsg
                {
                    CommandType = (PIDCommandType)(ConvertUtil.ConvertToInt(vs[0])),
                    TakeEffect = ConvertUtil.ConvertToBool(vs[1]),
                    Guid = vs[2],
                    Token = vs[3],
                    ParamType = (PIDCommandParamType)(ConvertUtil.ConvertToInt(vs[4])),
                    Value = vs[5],
                    IsBias = ConvertUtil.ConvertToBool(vs[6])
                };
            }
            catch
            {
                return null;
            }
        }
    }
    /// <summary>
    /// 设置的调试信息
    /// </summary>
    public class PIDDebugInfoMsg
    {
        /// <summary>
        /// 命令类型
        /// </summary>
        public PIDCommandType CommandType
        {
            get;
            set;
        }
        /// <summary>
        /// 算法块标记
        /// </summary>
        public string Guid
        {
            get;
            set;
        }
        /// <summary>
        /// 输入、输出、参数标记
        /// </summary>
        public string Token
        {
            get;
            set;
        }
        /// <summary>
        /// 参数类型
        /// </summary>
        public PIDCommandParamType ParamType
        {
            get;
            set;
        }
    }
    /// <summary>
    /// 参数变量简要信息
    /// </summary>
    public class AlgParamVarSummary
    {
        public string Name
        {
            get;
            set;
        }

        public PIDCommandParamType Type
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public Double DValue
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Value))
                    return ConvertUtil.ConvertToDouble(this.Value);
                else
                    return 0;
            }
        }
    }
}

