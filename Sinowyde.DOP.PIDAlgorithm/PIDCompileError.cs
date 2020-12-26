using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm
{
    public class PIDCompileError
    {
        /// <summary>
        /// 组索引
        /// </summary>
        public string GroupIndex
        {
            get;
            set;
        }
        /// <summary>
        /// 组内索引
        /// </summary>
        public string IndexInGroup
        {
            get;
            set;
        }
        /// <summary>
        /// 全局唯一标识
        /// </summary>
        public string Identity
        {
            get;
            set;
        }
        /// <summary>
        /// 错误内容
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        public string AlgName
        {
            get;
            set;
        }
    }
    /// <summary>
    /// 错误管理器
    /// </summary>
    public class PIDCompileErrManager
    {
        /// <summary>
        /// 单例管理器
        /// </summary>
        private static PIDCompileErrManager instance = null;

        private static object _lock = new object();

        public static PIDCompileErrManager Instance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new PIDCompileErrManager();
                }
            }

            return instance;
        }
        /// <summary>
        /// 错误列表
        /// </summary>
        private IList<PIDCompileError> errors = new List<PIDCompileError>();
        public IList<PIDCompileError> Errors
        {
            get
            {
                return errors;
            }
        }
        /// <summary>
        /// 添加错误
        /// </summary>
        /// <param name="error"></param>
        public void AddError(PIDCompileError error)
        {
            errors.Add(error);
        }
        /// <summary>
        /// 添加错误
        /// </summary>
        /// <param name="errors"></param>
        public void AddErrors(IList<PIDCompileError> errors)
        {
            foreach (PIDCompileError error in errors)
            {
                errors.Add(error);
            }
        }
        /// <summary>
        /// 清空错误
        /// </summary>
        public void ClearError()
        {
            errors.Clear();
        }
    }
}
