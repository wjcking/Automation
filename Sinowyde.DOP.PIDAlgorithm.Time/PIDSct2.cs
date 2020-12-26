using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.PIDAlgorithm.Time
{
    /// <summary>
    ///系统当前时间功能块2 
    /// </summary>
    [Serializable]
    public class PIDSct2 : PIDBindAlgorithm
    {
        ///<summary>
        ///年显示项
        ///</summary>
        public const string resultSAO = PIDAlgorithmToken.prefixResult + "SAO";


        ///<summary>
        ///初始化结果参数
        ///</summary>
        protected override void InitCalcResults()
        {
            this.calcResults[resultSAO] = new PIDAlgorithmVar(resultSAO, PIDVarDataType.AM);
        }
        ///<summary>
        ///4、 功能说明
        ///显示标准时间（格林威治时间 1970 年 0 时 0 分 0 秒开始）秒显示
        ///5、算法说明
        ///提取标准秒显示时间
        ///</summary>  
        protected override void InternalDoCalc()
        {
            this.calcResults[resultSAO].Value = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        public override string AlgName
        {
            get { return "系统当前时间功能块2"; }
        }
    }
}
