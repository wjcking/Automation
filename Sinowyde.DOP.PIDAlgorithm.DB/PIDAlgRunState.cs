using NHibernate.Mapping.Attributes;
using Sinowyde.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.DB
{
    /// <summary>
    /// sama运行状态
    /// 1、sama引擎重启后，放弃所有状态，强制以及跟随需要从新设置
    /// 2、运行状态不包含参数的设置，参数设置直接修改sama文件
    /// 3、运行状态独立成表
    /// </summary>
    [Class]
    public class PIDAlgRunState : Entity
    {
        /// <summary>
        /// 命令类型
        /// </summary>
        [Property]
        public virtual PIDCommandType CommandType
        {
            get;
            set;
        }       
        /// <summary>
        /// 算法块标记
        /// </summary>
        [Property]
        public virtual string Guid
        {
            get;
            set;
        }
        /// <summary>
        /// 输入、输出、参数标记
        /// </summary>
        [Property]
        public virtual string Token
        {
            get;
            set;
        }
        /// <summary>
        /// 参数类型
        /// </summary>
        [Property]
        public virtual PIDCommandParamType ParamType
        {
            get;
            set;
        }
        /// <summary>
        /// 目标值
        /// </summary>
        [Property]
        public virtual string Value
        {
            get;
            set;
        }
        /// <summary>
        /// 设置时间
        /// </summary>
        [Property]
        public virtual DateTime Timestamp
        {
            get;
            set;
        }

        public static PIDAlgRunState NewFrom(PIDCommmandMsg msg, string value)
        {
            return new PIDAlgRunState
            { 
                 CommandType = msg.CommandType,
                  Guid = msg.Guid,
                   ParamType = msg.ParamType,
                    Token = msg.Token,
                       Value = value,
                         Timestamp = DateTime.Now
            };
        }
    }
}
