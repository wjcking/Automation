using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDBlock.Xml.Entitys
{
    public enum EntityTypeEnum
    {
        AllS = 1,//统计所有
        GroupS,//统计算法块种类
        BlockS,//统计一种算法块算法个数
        Block
    }

    public class StatisticsEntity
    {
        public int ID { get; set; }//treeList的数据源 必须ID 注意大小写
        public int ParentID { get; set; }//treeList的数据源 ParentID 注意大小写
        public string PageGuid { get; set; }
        public string BlockGuid { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }//用于统计
        public EntityTypeEnum Type { get; set; }
        public string Caption
        {
            get
            {
                if (Type == EntityTypeEnum.AllS)
                {
                    return string.Format("共有{0}个算法块", Count);
                }
                else if (Type == EntityTypeEnum.GroupS)
                {
                    return string.Format("{0}算法块,共有{1}个", Name, Count);
                }
                else if (Type == EntityTypeEnum.BlockS)
                {
                    return string.Format("{0}算法块,共有{1}个", Name, Count);
                }
                else if (Type == EntityTypeEnum.Block)
                {
                    return string.Format("{0}", Name);
                }

                return string.Empty;
            }
        }

        public StatisticsEntity()
        {
            PageGuid = string.Empty;
            BlockGuid = string.Empty;
            Count = 0;
        }
    }
}
