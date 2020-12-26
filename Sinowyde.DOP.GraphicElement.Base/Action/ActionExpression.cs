using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.GraphicElement.Base.Action
{
    public class ActionExpression
    {
        public const string ColorAction = "COLORACTION";
        public const string FlashAction = "FLASHACTION";
        public const string MoveAction = "MOVEACTION";
        public const string HiderAction = "HIDEACTION";
        public const string TextAction = "TEXTACTION";

        public const string Variable = "VAR";
        public const string Param = "PARAM";
        public const string Result = "RESULT";
        
        public const string Variable1 = "VAR1";
                
        public const string Param1 = "PARAM1";
        public const string Param2 = "PARAM2";
        public const string Param3 = "PARAM3";               

        /// <summary>
        /// 大于表达式
        /// </summary>
        /// <returns></returns>
        public static string Greater()
        {
            return string.Format("{0} > {1}", Variable, Param); 
        }
        /// <summary>
        /// 等于表达式
        /// </summary>
        /// <returns></returns>
        public static string Equal()
        {
            return string.Format("{0} == {1}", Variable, Param); 
        }
        /// <summary>
        /// 大于等于表达式
        /// </summary>
        /// <returns></returns>
        public static string GreaterEqual()
        {
            return string.Format("{0} >= {1}", Variable, Param); 
        }
        /// <summary>
        /// 等于表达式
        /// </summary>
        /// <returns></returns>
        public static string Less()
        {
            return string.Format("{0} < {1}", Variable, Param); 
        }
        /// <summary>
        /// 等于表达式
        /// </summary>
        /// <returns></returns>
        public static string LessEqual()
        {
            return string.Format("{0} <= {1}", Variable, Param); 
        }
        /// <summary>
        /// 等于表达式
        /// </summary>
        /// <returns></returns>
        public static string NotEqual()
        {
            return string.Format("{0} != {1}", Variable, Param); 
        }
        /// <summary>
        /// 等于表达式
        /// </summary>
        /// <returns></returns>
        public static string Between()
        {
            return string.Format("{0} > {1} && {0} < {2}", Variable, Param1, Param2); 
        }
        /// <summary>
        /// 条件表达式
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        //public static string IfValue(string condition)
        //{
        //    return "if (condition, result=param3,)";
        //}
    }
}
