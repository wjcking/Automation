using NHibernate.Mapping.Attributes;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.DataModel;

namespace Sinowyde.DOP.DataModel
{

    [Class]
    [Serializable]
    public class RTValue : Entity
    {
        /// <summary>
        /// 变量名
        /// </summary>
        [Property]
        public virtual string VarNumber { get; set; }

        /// <summary>
        /// 时戳
        /// </summary>
        [Property]
        public virtual DateTime Timestamp { get; set; }

        /// <summary>
        /// 数值
        /// </summary>
        [Property]
        public virtual double Value { get; set; }

        /// <summary>
        /// 数据质量
        /// </summary>
        [Property]
        public virtual RtValueQuality Quality { get; set; }

        /// <summary>
        /// 序列化为字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", this.VarNumber, this.Timestamp.Ticks.ToString(), this.Value.ToString(), ((int)(this.Quality)).ToString());
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        public static RTValue FromString(string content)
        {
            try
            {
                string[] vs = content.Split(new char[] { ' ' }, StringSplitOptions.None);
                return new RTValue
                        {
                            VarNumber = vs[0],
                            Quality = (RtValueQuality)(ConvertUtil.ConvertToInt(vs[3])),
                            Timestamp = new DateTime(ConvertUtil.ConvertToLong(vs[1])),
                            Value = ConvertUtil.ConvertToDouble(vs[2])
                        };
            }
            catch
            {
                return null;
            }
        }


    }
}
