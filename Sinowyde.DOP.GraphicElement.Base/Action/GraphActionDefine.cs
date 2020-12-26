using NCalc;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.DTProxy;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.GraphicElement.Base
{
    public enum GraphActionVarType
    {
        Analog=0,
        Digital,
        ThirdDigital,
        Pakage
    }

    public class GraphActionDefine
    {
        /// <summary>
        /// 动作ID
        /// </summary>
        public string ID
        {
            get;
            set;
        }

        public GraphActionVarType VarType
        {
            get;
            set;
        }
        /// <summary>
        /// 动作条件表达式
        /// </summary>
        private Expression CalcExpression = null;
        public virtual string Expression
        {
            get
            {
                if (this.CalcExpression != null)
                    return this.CalcExpression.ParsedExpression.ToString();
                else
                    return string.Empty;
            }
            set
            {
                this.CalcExpression = new Expression(value);                
            }
        }
        /// <summary>
        /// 参数变量
        /// </summary>
        private IDictionary<string, Variable> varParamMap
            = new Dictionary<string, Variable>();
        /// <summary>
        /// 设置参数变量
        /// </summary>
        /// <param name="param"></param>
        /// <param name="var"></param>
        public void SetParamVar(string var, Variable param)
        {
            varParamMap[var] = param;
        }
        /// <summary>
        /// 获取参数变量
        /// </summary>
        /// <param name="var"></param>
        /// <returns></returns>
        public Variable GetParamVar(string var)
        {
            if( varParamMap.ContainsKey(var))
                return varParamMap[var];
            return null;
        }
        public IList<string> GetVarNumbers()
        {
            IList<string> varNumbers = new List<string>();
            if(varParamMap.Values == null)
                return varNumbers;
            foreach (Variable variable in varParamMap.Values)
            {
                if(!varNumbers.Contains(variable.Number))
                       varNumbers.Add(variable.Number);
            }
            return varNumbers;
        }
        /// <summary>
        /// 参数变量
        /// </summary>
        private IDictionary<string, object> valueParamMap
            = new Dictionary<string, object>();
        /// <summary>
        /// 设置参数变量
        /// </summary>
        /// <param name="param"></param>
        /// <param name="var"></param>
        public void SetParamValue(string param, object value)
        {
            valueParamMap[param] = value;
        }
        /// <summary>
        /// 获得参数变量值
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public object GetParamValue(string param)
        {
            if (valueParamMap.ContainsKey(param))
                return valueParamMap[param];
            return null;
        }
        /// <summary>
        /// 获取计算结果
        /// </summary>
        /// <returns></returns>  
        public Object CalcResult
        {
            get;
            set;
        }
        /// <summary>
        /// 动作对象
        /// </summary>
        public DOPGraphElement Container
        {
            get;
            set;
        }
        public object GetResult()
        {
            return null;
        }
        /// <summary>
        /// 执行动作
        /// </summary>
        public virtual void Execute()
        {
            if (this.Enabled)
            {
                //读取变量值
                IList<string> varNumbers = this.GetVarNumbers();
                foreach (KeyValuePair<string, Variable> keyValue in this.varParamMap)
                {
                    RTValue value = RTValueMemCache.Instance().GetValue(keyValue.Value.Number);
                    string param = string.Format("\"{0}\"", keyValue.Key);
                    this.CalcExpression.Parameters[param] = value.Value;
                }

                if (Evaluate() && GraphAction != null)
                    GraphAction(this.Container, this);
            }
        }
        /// <summary>
        /// 用户对象，扩展保存动作参数
        /// </summary>
        public virtual Object UserObject
        {
            get;
            set;
        }

        /// <summary>
        /// 动作是否起效
        /// </summary>
        public bool Enabled
        {
            get;
            set;
        }
        /// <summary>
        /// 评估表达式
        /// </summary>
        /// <returns></returns>
        public virtual bool Evaluate()
        {
            if (CalcExpression != null)
                return ConvertUtil.ConvertToBool(CalcExpression.Evaluate());
            else
                return false;
        }
        /// <summary>
        /// 动画动作
        /// </summary>
        public ExecGraphAction GraphAction;
    }

    public delegate void ExecGraphAction(object sender, GraphActionDefine define);
}
