using NHibernate.Mapping.Attributes;
using Sinowyde.DataModel;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.DB
{
    public class PIDAlgPageBase : Entity
    {
        /// <summary>
        /// 组索引,数据库自增,可外部修改
        /// </summary>
        [Property(Unique = true)]
        public virtual long GIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 作为文件固定标识
        /// </summary>
        [Property(Unique = true)]
        public virtual string Guid
        {
            get;
            set;
        }

        /// <summary>
        /// 组描述
        /// </summary>
        [Property]
        public virtual string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 作为版本时戳,没有截断的,保留毫秒,
        /// 保存ticks值
        /// </summary>
        [Property]
        public virtual long Timestamp
        {
            get;
            set;
        }

        /// <summary>
        /// 并发锁定
        /// </summary>
        [Property]
        public virtual bool IsLock
        {
            get;
            set;
        }

        /// <summary>
        /// 组合名称显示
        /// </summary>
        /// <returns></returns>
        public virtual string Summary
        {
            get
            {
                return string.Format("{0}.{1}.{2}.{3}", this.Guid,
                        this.GIndex, this.Description, this.Timestamp);
            }
            set
            {
                try
                {
                    string[] parts = value.Split('.');
                    this.Guid = parts[0];
                    this.GIndex = ConvertUtil.ConvertToLong(parts[1]);
                    this.Description = parts[2];
                    this.Timestamp = ConvertUtil.ConvertToLong(parts[3]);
                }
                catch
                { }
            }
        }
    }

    /// <summary>
    /// 简要信息
    /// </summary>
    [Class(Table = "PIDAlgPage")]
    public class PIDAlgPageSummary : PIDAlgPageBase
    {
        public override string ToString()
        {
            return string.Format("{0}.{1}", GIndex, Description);
        }
    }


    [Class]
    public class PIDAlgPage : PIDAlgPageBase
    {
        /// <summary>
        /// 展现用的xml流
        /// </summary>
        [Property(Column = "Content", Length = 16777216)]
        public virtual string Content
        {
            get;
            set;
        }

        /// <summary>
        /// 字符串显示
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}.{1}", GIndex, Description);
        }
    }

}
