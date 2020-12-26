using NHibernate.Mapping.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.DB
{
    /// <summary>
    /// 算法块描述字符串
    /// </summary>
    public class PIDAlgEntity
    {
        public PIDAlgEntity()
        {
            this.Inputs = new List<string>();
            this.Outputs = new List<string>();
            this.Params = new List<string>();
        }
        /// <summary>
        /// 块号
        /// </summary>
        public virtual string BIndex
        {
            get;
            set;
        }

        public virtual string Identity
        {
            get;
            set;
        }
        /// <summary>
        /// 算法块类型
        /// </summary>
        public virtual string AlgType
        {
            get;
            set;
        }

        /// <summary>
        /// 算法定义字符串
        /// </summary>
        public virtual string Define
        {
            get;
            set;
        }

        /// <summary>
        /// 输出名称
        /// </summary>
        public IList<string> Outputs
        {
            get;
            set;
        }

        /// <summary>
        /// 输入名称
        /// </summary>        
        public IList<string> Inputs
        {
            get;
            private set;
        }

        /// <summary>
        /// 参数名称
        /// </summary>
        public IList<string> Params
        {
            get;
            private set;
        }

        public string VarNnumber(string token)
        {
            return BindSourceToken.GetName(this.Identity, token); 
        }
    }
}
