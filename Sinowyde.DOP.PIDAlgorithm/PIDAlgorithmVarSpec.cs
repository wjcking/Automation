using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm
{
    /// <summary>
    /// 参数变量规格
    /// </summary>
    public class PIDAlgorithmVarSpec
    {
        public string Name
        {
            get;
            set;
        }

        public string BindSource
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
        /// <summary>
        /// 输入类型
        /// </summary>
        public PIDVarInputType InputType
        {
            get;
            set;
        }
        /// <summary>
        /// 转换为json串
        /// </summary>
        /// <returns></returns>
        public String ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        /// <summary>
        /// 解析json串
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static PIDAlgorithmVarSpec FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<PIDAlgorithmVarSpec>(json);
            }
            catch
            {
                return null;
            }
        }
    }
}
