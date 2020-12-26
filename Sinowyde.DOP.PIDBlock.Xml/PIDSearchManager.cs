using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDBlock.Xml
{
    public class PIDSearchResult
    {
        /// <summary>
        /// 组号
        /// </summary>
        public string GroupIndex { get; set; }
        /// <summary>
        /// 块号
        /// </summary>
        public string IndexInGroup { get; set; }
        /// <summary>
        /// 组名
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// 算法名
        /// </summary>
        public string Alg { get; set; }
        /// <summary>
        /// 点名称
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// 点中文名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 点类型
        /// </summary>
        public string VariableType { get; set; }
    }

    /// <summary>
    /// 错误管理器
    /// </summary>
    public class PIDSearchManager
    {
        #region 单例模式

        private static PIDSearchManager instance = null;
        private static object _lock = new object();
        public static PIDSearchManager Instance()
        {
            if (null == instance)
            {
                lock (_lock)
                {
                    if (null == instance)
                        instance = new PIDSearchManager();
                }
            }

            return instance;
        }

        #endregion


        /// <summary>
        /// 搜索结果列表
        /// </summary>
        private IList<PIDSearchResult> results = new List<PIDSearchResult>();

        public IList<PIDSearchResult> Results
        {
            get
            {
                return results;
            }
        }

        /// <summary>
        /// 添加错误
        /// </summary>
        /// <param name="error"></param>
        public void AddResult(PIDSearchResult result)
        {
            results.Add(result);
        }
        /// <summary>
        /// 添加错误
        /// </summary>
        /// <param name="errors"></param>
        public void AddResult(IList<PIDSearchResult> resultList)
        {
            foreach (PIDSearchResult result in resultList)
            {
                results.Add(result);
            }
        }
        /// <summary>
        /// 清空错误
        /// </summary>
        public void ClearResult()
        {
            results.Clear();
        }
    }
}
