using NHibernate.Mapping.Attributes;
using Sinowyde.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sinowyde.RTModel;

namespace Sinowyde.DOP.DataModel
{
    [Class]
    [Serializable]
    public class Variable : Entity
    {        
        /// <summary>
        /// 名称，英文数字,不能包含空字符
        /// </summary>
        [Property(Length = 50)]
        public virtual string Number { get; set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        [Property(Length = 50)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 变量地址
        /// </summary>
        [Property]
        public virtual int Address { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [Property(Length = 50)]
        public virtual string Unit { get; set; }

        /// <summary>
        /// 比例系数
        /// </summary>
        [Property]
        public virtual float Ratio { get; set; }

        /// <summary>
        /// 偏移
        /// </summary>
        [Property]
        public virtual float Bias { get; set; }

        /// <summary>
        /// 是否压缩
        /// 
        /// </summary>
        [Property]
        public virtual bool IsCompressed { get; set; }

        /// <summary>
        /// 压缩率
        /// 
        /// </summary>
        [Property]
        public virtual float CompressRatio { get; set; }

        /// <summary>
        /// 是否上传
        /// 
        /// </summary>
        [Property]
        public virtual bool IsTransfer { get; set; }

        /// <summary>
        /// 最大存储周期
        /// </summary>
        [Property]
        public virtual int MaxPeriod { get; set; }

        /// <summary>
        /// 采集类型
        /// </summary>
        [Property]
        public virtual VarDirectionType DirectionType { get; set; }

        /// <summary>
        /// 变量类型
        /// </summary>
        [Property]
        public virtual VariableType VariableType { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        [Property]
        public virtual DataType DataType { get; set; }

        [ReadOnlyManyToOne(ClassType = typeof(Device), Column = "DeviceID", ForeignKey = "FK_Variable_DeviceID")]
        public virtual Device Device { get; set; }


        public virtual long? DeviceID
        {
            get
            {
                return Entity.ToID<Device>(this.Device);
            }
            set
            {
                this.Device = Entity.ToEntity<Device>(value);
            }
        }

        [ReadOnlyManyToOne(ClassType = typeof(IOUnit), Column = "IOUnitID", ForeignKey = "FK_Variable_IOUnitID")]
        public virtual IOUnit IOUnit { get; set; }


        public virtual long? IOUnitID
        {
            get
            {
                return Entity.ToID<IOUnit>(this.IOUnit);
            }
            set
            {
                this.IOUnit = Entity.ToEntity<IOUnit>(value);
            }
        }

        public static IList<RtPoint> ConvertToPoints(IList<Variable> variables)
        {
            IList<RtPoint> points = new List<RtPoint>();
            foreach (Variable variable in variables)
            {
                points.Add(new RtPoint { Address=variable.Address, DataType=variable.DataType, Number=variable.Number });
            }
            return points;
        }

    }
}
