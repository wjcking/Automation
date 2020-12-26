using System;
using System.Collections.Generic;
using System.Linq;
using Sinowyde.Util;
using Newtonsoft.Json;

namespace Sinowyde.DOP.PIDAlgorithm
{
    /// <summary>
    /// 绑定算法前缀
    /// </summary>
    public class BindSourceToken
    {
        /// <summary>
        /// 算法块点前缀
        /// </summary>
        public const string PrefixBlock = "BLO";

        public static string GetName(string guid, string token)
        {
            return string.Format("{0}.{1}.{2}", PrefixBlock, guid, token);
        }

        public static string[] GetParts(string name)
        {
            return name.Split(new char[] { '.' }, StringSplitOptions.None);
        }
    }

    /// <summary>
    /// 算法参数字典键前缀
    /// </summary>
    public class PIDAlgorithmToken
    {
        /// <summary>
        /// 手动设置参数前缀
        /// </summary>
        public const string prefixParam = "param";

        /// <summary>
        /// 动态输入前缀
        /// </summary>
        public const string prefixInput = "input";

        /// <summary>
        /// 结果前缀
        /// </summary>
        public const string prefixResult = "result";

        /// <summary>
        /// 上一次输出的前缀
        /// </summary>
        public const string PrefixLast = prefixResult + "Last";
    }

    /// <summary>
    /// 仅支持简单数据类型
    /// </summary>
    public enum PIDVarDataType
    {
        AM = 1, //模拟量
        DM    //数字量    
    }

    /// <summary>
    /// 变量输入类型
    /// </summary>
    public enum PIDVarInputType
    {
        Dynamic = 0,    //动态输入
        Init,           //取初值
        Keep,           //保留前次值
        Set             //强制
    }

    /// <summary>
    /// PID算法块静态参数
    /// </summary>
    [Serializable]
    public class PIDAlgorithmParam
    {
        /// <summary>
        /// 初始化变量 
        /// </summary>
        public PIDAlgorithmParam(string name, double value)
        {
            this.Name = name;
            this.values.Add(value);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        public PIDAlgorithmParam(string name)
        {
            this.Name = name;
            this.values.Add(0);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public PIDAlgorithmParam(string name, string value)
        {
            this.Name = name;
            this.StringToValue(value);
        }

        /// <summary>
        /// 初始化数值列表,默认已经创建1个
        /// </summary>
        /// <param name="count"></param>
        public void InitValues(int count)
        {
            for (int i = 1; i < count; i++)
            {
                this.values.Add(0);
            }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 数值
        /// </summary>
        private IList<double> values = new List<double>();

        /// <summary>
        /// 参数数值列表
        /// </summary>
        public IList<double> Values
        {
            get { return this.values; }

        }

        public double Value
        {
            get
            {
                return values[0];
            }
            set
            {
                this.values[0] = value;
            }
        }

        /// <summary>
        /// 参数值列表转字符串
        /// </summary>
        /// <returns></returns>
        public string ValueToString()
        {
            string reValue = values[0].ToString();
            if (values.Count > 1)
            {
                for (int i = 1; i < values.Count; i++)
                {
                    reValue += "#" + values[i].ToString();
                }
            }
            return reValue;
        }
        /// <summary>
        /// 字符串转参数列表
        /// </summary>
        /// <param name="content"></param>
        public void StringToValue(string content)
        {
            string[] parts = content.Split(new char[] { '#' });
            if (parts.Length == 0)
                return;
            values.Clear();
            for (int i = 0; i < parts.Length; i++)
            {
                values.Add(ConvertUtil.ConvertToDouble(parts[i].Trim()));
            }
        }

        /// <summary>
        /// 数据转成bool
        /// </summary>
        /// <returns></returns>
        public bool ValueToBool()
        {
            return this.Value != 0;
        }
    }


    /// <summary>
    /// PID算法块输出变量
    /// </summary>
    [Serializable]
    public class PIDAlgorithmVar
    {
        /// <summary>
        /// 初始化变量 
        /// </summary>
        public PIDAlgorithmVar(string name, PIDVarDataType varDataType)
        {
            this.Name = name;
            this.Timestamp = DateTime.MinValue;
            this.InputType = PIDVarInputType.Dynamic;

            this.IsValid = false;
            this.Value = 0;
            this.SourceValue = 0;

            this.VarType = varDataType;
            this.BindSource = string.Empty;
        }

        /// <summary>
        /// 初始化变量,设置初值 
        /// </summary>
        public PIDAlgorithmVar(string name, double sourceValue, PIDVarInputType inputType, PIDVarDataType varDataType)
        {
            this.Name = name;
            this.Timestamp = DateTime.MinValue;

            this.SourceValue = sourceValue;
            this.InputType = inputType;
            this.Value = this.SourceValue;
            this.IsValid = true;

            this.VarType = varDataType;
            this.BindSource = string.Empty;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get;
            private set;
        }
        /// <summary>
        /// 数值
        /// </summary>
        public double Value
        {
            get;
            set;
        }
        /// <summary>
        /// 初值
        /// </summary>
        public double SourceValue
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
        /// 数据时戳
        /// </summary>
        public DateTime Timestamp
        {
            get;
            private set;
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid
        {
            get;
            set;
        }
        /// <summary>
        ///  关联变量来源
        /// </summary>
        public string BindSource
        {
            get;
            set;
        }
        /// <summary>
        /// PID变量类型
        /// </summary>
        public PIDVarDataType VarType
        {
            get;
            set;
        }

        /// <summary>
        /// 数据转成bool
        /// </summary>
        /// <returns></returns>
        public bool ValueToBool()
        {
            return this.Value != 0;
        }
    }

    /// <summary>
    /// 设置数值的类型
    /// </summary>
    public enum AlgParamType
    {
        Param = 0, //参数
        Input,     //输入
        Output,    //输出
        Propertity //自身属性
    }

    /// <summary>
    /// 参数类型
    /// </summary>
    public class AlgorithmChangeArg : EventArgs
    {
        public AlgParamType ParamType
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public object ChangedValue
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 算法修改事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="arg"></param>
    public delegate void AlgorithmChangeEvent(Object sender, AlgorithmChangeArg arg);

    /// <summary>
    /// 计算接口类
    /// </summary>
    [Serializable]
    public class PIDBindAlgorithm
    {
        /// <summary>
        /// 关联变量与算法变量之间的关系
        /// </summary>
        private IDictionary<string, IList<PIDAlgorithmVar>> bindRelation = new Dictionary<string, IList<PIDAlgorithmVar>>();
        /// <summary>
        /// 算法用到参数
        /// </summary>
        protected IDictionary<string, PIDAlgorithmParam> calcParams = new Dictionary<string, PIDAlgorithmParam>();
        /// <summary>
        /// 算法输入变量
        /// </summary>
        protected IDictionary<string, PIDAlgorithmVar> calcInputs = new Dictionary<string, PIDAlgorithmVar>();
        /// <summary>
        /// 算法输出结果
        /// </summary>
        protected IDictionary<string, PIDAlgorithmVar> calcResults = new Dictionary<string, PIDAlgorithmVar>();
        /// <summary>
        /// 初始化变量参数
        /// </summary>
        protected virtual void InitCalcParams() { }
        /// <summary>
        /// 初始化输入变量
        /// </summary>
        protected virtual void InitCalcInputs() { }
        /// <summary>
        /// 初始化结果参数
        /// </summary>
        protected virtual void InitCalcResults() { }
        /// <summary>
        /// 算法发生变化事件
        /// </summary>
        public AlgorithmChangeEvent AlgChangedEvent;
        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="arg"></param>
        public void RaiseAlgChangedEvent(AlgParamType paramType, string name, Object changedValue)
        {
            if (AlgChangedEvent != null)
                AlgChangedEvent(this, new AlgorithmChangeArg { ParamType = paramType, Name = name, ChangedValue = changedValue });
        }

        public virtual string AlgName
        {
            get { return string.Empty; }
        }
        /// <summary>
        /// 是否在调试状态
        /// </summary>
        public volatile bool IsDebug = false;

        /// <summary>
        /// 初始化
        /// </summary>
        public PIDBindAlgorithm()
        {
            this.FirstCalcTime = DateTime.MinValue;
            this.CurrentCalcTime = DateTime.MinValue;
            this.LastCalcTime = DateTime.MinValue;

            this.Identity = string.Empty;
            this.GroupIndex = string.Empty;
            this.IndexInGroup = string.Empty;

            InitCalcParams();
            InitCalcInputs();
            InitCalcResults();

            this.IsDebug = false;
        }

        /// <summary>
        /// 重置中间变量
        /// </summary>
        protected virtual void ResetEnvVars()
        {
            this.FirstCalcTime = DateTime.MinValue;
            this.CurrentCalcTime = DateTime.MinValue;
            this.LastCalcTime = DateTime.MinValue;

            foreach (var output in calcResults.Values)
            {
                output.Value = output.SourceValue;
            }
        }
        /// <summary>
        /// 第一次计算时间 
        /// </summary>
        public DateTime FirstCalcTime
        {
            get;
            protected set;
        }
        /// <summary>
        /// 上次计算时间 第一次没有dt
        /// </summary>
        public DateTime LastCalcTime
        {
            get;
            protected set;
        }
        /// <summary>
        /// 当前计算时间，目前用于输出调试
        /// </summary>
        public DateTime CurrentCalcTime
        {
            get;
            protected set;
        }
        /// <summary>
        /// 获得上次-当前=时间差值,如果是第一次执行 返回1并且记录当前时间
        /// </summary>
        /// <returns>毫秒</returns>
        public double GetDt()
        {
            return (DateTime.MinValue == LastCalcTime) ? 0 :
                (CurrentCalcTime - LastCalcTime).TotalSeconds;
        }
        /// <summary>
        /// 与第一次计算的世间差 
        /// </summary>
        /// <returns>秒</returns>
        public double GetTotalDt()
        {
            return (DateTime.MinValue == FirstCalcTime) ? 0 :
                (CurrentCalcTime - FirstCalcTime).TotalSeconds;
        }
        /// <summary>
        /// 设置参数值,外部检验有效性
        /// </summary>
        /// <param name="param"></param>
        /// <param name="value"></param>
        public void SetParamValue(string param, double value)
        {
            if (calcParams[param].Value != value)
            {
                calcParams[param].Value = value;
                //参数数值发生变化
                RaiseAlgChangedEvent(AlgParamType.Param, param, calcParams[param]);
            }
        }
        /// <summary>
        /// 设置参数值,外部检验有效性
        /// </summary>
        /// <param name="param"></param>
        /// <param name="value"></param>
        public void SetParamValue(string param, string value)
        {
            if (calcParams[param].ValueToString() != value)
            {
                calcParams[param].StringToValue(value);
                //参数数值发生变化
                RaiseAlgChangedEvent(AlgParamType.Param, param, calcParams[param]);
            }
        }
        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="param"></param>
        /// <param name="value"></param>
        public PIDAlgorithmParam GetParam(string param)
        {
            if (calcParams.ContainsKey(param))
                return calcParams[param];
            else
                return null;
        }
        /// <summary>
        /// 设置输入类型，建议放在设置数值前面调用
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetInputType(string input, PIDVarInputType inputType)
        {
            calcInputs[input].InputType = inputType;
            //非动态输入则一直有效
            if (inputType != PIDVarInputType.Dynamic)
                calcInputs[input].IsValid = true;
            else
                calcInputs[input].IsValid = false;

            RaiseAlgChangedEvent(AlgParamType.Input, input, calcInputs[input]);
        }

        public void ResetInputType(string input)
        {
            if (string.IsNullOrEmpty(calcInputs[input].BindSource))
            {
                calcInputs[input].InputType = PIDVarInputType.Dynamic;
                calcInputs[input].IsValid = false;
            }
            else
            {
                calcInputs[input].InputType = PIDVarInputType.Init;
                calcInputs[input].IsValid = true;
            }
            RaiseAlgChangedEvent(AlgParamType.Input, input, calcInputs[input]);
        }
        /// <summary>
        /// 设置输入值,设置标志位有效
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        public bool SetInputValue(string input, double value)
        {
            if (IsValidInput(input, value))
            {
                calcInputs[input].Value = value;
                calcInputs[input].IsValid = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 设置输入值以及输入类型
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        /// <param name="inputType"></param>
        /// <returns></returns>
        public bool SetInputValue(string input, double value, PIDVarInputType inputType)
        {
            if (IsValidInput(input, value))
            {
                calcInputs[input].Value = value;
                if (inputType != PIDVarInputType.Dynamic)
                {
                    calcInputs[input].SourceValue = value;
                }
                calcInputs[input].IsValid = true;
                calcInputs[input].InputType = inputType;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 设置源值
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        public void SetInputSourceValue(string input, double value)
        {
            if (IsValidInput(input, value))
            {
                calcInputs[input].SourceValue = value;
                calcInputs[input].Value = value;  //同步更新
                RaiseAlgChangedEvent(AlgParamType.Input, input, calcInputs[input]);
            }
        }
        /// <summary>
        /// 获取输入值
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PIDAlgorithmVar GetInputVar(string input)
        {
            return this.calcInputs[input];
        }
        /// <summary>
        /// 强制输出变量的输入类型
        /// </summary>
        /// <param name="output"></param>
        /// <param name="inputType"></param>
        public void SetOutputInputType(string output, PIDVarInputType inputType)
        {
            calcResults[output].InputType = inputType;
            if (inputType == PIDVarInputType.Keep)
                calcResults[output].SourceValue = calcResults[output].Value;
            RaiseAlgChangedEvent(AlgParamType.Output, output, calcResults[output]);
        }
        /// <summary>
        /// 强制改变设置输入值,设置标志位有效
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        public void SetOutputValue(string output, double value, PIDVarInputType inputType = PIDVarInputType.Set)
        {
            if (inputType == PIDVarInputType.Keep
                || inputType == PIDVarInputType.Set)
            {
                calcResults[output].Value = value;
                calcResults[output].IsValid = true;
                calcResults[output].SourceValue = value;
                calcResults[output].InputType = inputType;
            }
        }
        /// <summary>
        /// 设置源值
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        public void SetOutputSourceValue(string output, double value)
        {
            if (value != calcResults[output].SourceValue)
            {
                calcResults[output].SourceValue = value;
                RaiseAlgChangedEvent(AlgParamType.Output, output, calcResults[output]);
            }
        }
        /// <summary>
        /// 获取输入值
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PIDAlgorithmVar GetOutputVar(string output)
        {
            return this.calcResults[output];
        }
        /// <summary>
        /// 参数是否有效
        /// </summary>
        /// <param name="param"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual bool IsValidInput(string input, object value)
        {
            return true;
        }
        /// <summary>
        /// 是否具备计算条件
        /// </summary>
        /// <returns></returns>
        public virtual bool IsReadyToCalc()
        {
            foreach (PIDAlgorithmVar var in calcInputs.Values)
            {
                if (var.IsValid == false)
                    return false;
            }

            return true;
        }
        /// <summary>
        /// 计算,需要注意结果
        /// </summary>
        /// <returns>计算是否成功</returns>
        public virtual bool DoCalc()
        {
            if (this.IsReadyToCalc())
            {
                return CalcOneRound();
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 进行一轮计算
        /// </summary>
        /// <returns></returns>
        protected virtual bool CalcOneRound()
        {
            //更新时戳
            CurrentCalcTime = DateTime.Now;

            //更新参数,根据工作模式重置输入值
            foreach (PIDAlgorithmVar var in this.calcInputs.Values)
            {
                if (var.InputType != PIDVarInputType.Dynamic)
                    var.Value = var.SourceValue;
            }
            InternalDoCalc();
            if (FirstCalcTime == DateTime.MinValue)
                FirstCalcTime = CurrentCalcTime;
            LastCalcTime = CurrentCalcTime;

            //动态输入数据类型，重置可变变量的有效性
            foreach (PIDAlgorithmVar var in this.calcInputs.Values)
            {
                if (var.InputType == PIDVarInputType.Dynamic)
                    var.IsValid = false;
            }
            // 如果数据强制的话，采用原值覆盖计算后值
            foreach (PIDAlgorithmVar var in this.calcResults.Values)
            {
                if (var.InputType == PIDVarInputType.Keep ||
                    var.InputType == PIDVarInputType.Set)
                    var.Value = var.SourceValue;
            }
            return true;
        }

        protected virtual void InternalDoCalc() { }
        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="calcParams"></param>
        /// <returns></returns>
        public bool DoCalc(IDictionary<string, double> calcInputs)
        {
            foreach (string input in calcInputs.Keys)
            {
                this.calcInputs[input].Value = calcInputs[input];
            }
            return DoCalc();
        }
        /// <summary>
        /// 获取计算结果
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PIDAlgorithmVar GetResultVariable(string name)
        {
            if (this.calcResults.ContainsKey(name))
                return this.calcResults[name];
            else
                return null;
        }
        /// <summary>
        /// 获取默认结果,可重载
        /// </summary>
        /// <returns></returns>
        public virtual object GetDefaultResult()
        {
            if (this.calcResults.Keys.Count > 0)
                return this.calcResults[this.calcResults.Keys.ElementAt<string>(0)];

            return null;
        }

        /// <summary>
        /// 获取所有参数
        /// </summary>
        /// <returns></returns>
        public IList<PIDAlgorithmParam> GetAllParam()
        {
            return this.calcParams.Values.ToList<PIDAlgorithmParam>();
        }

        /// <summary>
        /// 获取所有输入点
        /// </summary>
        /// <returns></returns>
        public IList<PIDAlgorithmVar> GetAllInput()
        {
            return this.calcInputs.Values.ToList<PIDAlgorithmVar>();
        }

        /// <summary>
        ///  获取所有输出点
        /// </summary>
        /// <returns></returns>
        public IList<PIDAlgorithmVar> GetAllOutput(bool useDisplay = true)
        {
            return calcResults.Values.ToList<PIDAlgorithmVar>();
        }

        /// <summary>
        /// 组索引 long不支持序列化
        /// </summary>
        public virtual string GroupIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 组内索引  long不支持序列化
        /// </summary>
        public virtual string IndexInGroup
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

        public virtual string GetBindVarNumber()
        {
            return string.Empty;
        }

        /// <summary>
        /// 获取绑定变量列表
        /// </summary>
        /// <returns></returns>
        public IList<string> GetBindInputNames()
        {
            var bindParams = new List<string>();
            foreach (PIDAlgorithmVar one in this.calcInputs.Values)
            {
                if (!string.IsNullOrEmpty(one.BindSource))
                    bindParams.Add(one.BindSource);
            }
            return bindParams;
        }

        /// <summary>
        /// 设置关联关系，不需要响应变化事件，保存时调用此方法
        /// </summary>
        /// <param name="param"></param>
        /// <param name="sourceVar"></param>
        public void BindParam(string param, string sourceVar)
        {
            if (!bindRelation.ContainsKey(sourceVar))
                bindRelation[sourceVar] = new List<PIDAlgorithmVar>();

            if (this.calcInputs.ContainsKey(param))
            {
                this.calcInputs[param].BindSource = sourceVar;
                this.calcInputs[param].InputType = PIDVarInputType.Dynamic;
                //2016 1 14 wang 为了解决闭环的问题，参数输入的有效性修改为如下判断
                //当为数据库点时，绑定时，设置为false
                //当是由其它block连接过来时，设置为true，以保证首次计算能进行                
                this.calcInputs[param].IsValid = sourceVar.IndexOf(BindSourceToken.PrefixBlock) >= 0;
                bindRelation[sourceVar].Add(this.calcInputs[param]);
                //设置数据库点，发送事件
                if (sourceVar.IndexOf(BindSourceToken.PrefixBlock) == -1)
                    this.AlgChangedEvent(this, new AlgorithmChangeArg { Name = param, ParamType = AlgParamType.Input, ChangedValue = sourceVar });
            }
            else
            {
                if (this.calcResults.ContainsKey(param))
                {
                    this.calcResults[param].BindSource = sourceVar;
                    this.calcResults[param].InputType = PIDVarInputType.Dynamic;
                    this.calcResults[param].IsValid = false;
                    bindRelation[sourceVar].Add(this.calcResults[param]);
                    //设置数据库点，发送事件
                    if (sourceVar.IndexOf(BindSourceToken.PrefixBlock) == -1)
                        this.AlgChangedEvent(this, new AlgorithmChangeArg { Name = param, ParamType = AlgParamType.Output, ChangedValue = sourceVar });
                }
            }
        }

        /// <summary>
        /// 解除绑定
        /// </summary>
        /// <param name="param"></param>
        public void UnBindParam(string param)
        {
            string source = string.Empty;
            if (this.calcInputs.ContainsKey(param))
            {
                source = this.calcInputs[param].BindSource;
                this.calcInputs[param].BindSource = string.Empty;
                this.calcInputs[param].InputType = PIDVarInputType.Init;

                //设置数据库点，发送事件
                if (source.IndexOf(BindSourceToken.PrefixBlock) == -1)
                    this.AlgChangedEvent(this, new AlgorithmChangeArg { Name = param, ParamType = AlgParamType.Input, ChangedValue = string.Empty });
            }
            else
            {
                if (this.calcResults.ContainsKey(param))
                {
                    source = this.calcResults[param].BindSource;
                    this.calcResults[param].BindSource = string.Empty;
                    this.calcResults[param].InputType = PIDVarInputType.Dynamic;

                    //设置数据库点，发送事件
                    if (source.IndexOf(BindSourceToken.PrefixBlock) == -1)
                        this.AlgChangedEvent(this, new AlgorithmChangeArg { Name = param, ParamType = AlgParamType.Output, ChangedValue = string.Empty });
                }
            }
            if (!string.IsNullOrEmpty(source) && bindRelation.ContainsKey(source))
            {
                foreach (PIDAlgorithmVar varParam in bindRelation[source])
                {
                    if (varParam.Name == param)
                    {
                        bindRelation[source].Remove(varParam);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 获取关联变量
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string GetBindParam(string param)
        {
            if (this.calcInputs.ContainsKey(param))
            {
                return this.calcInputs[param].BindSource;
            }
            else
            {
                if (this.calcResults.ContainsKey(param))
                    return this.calcResults[param].BindSource;
            }
            return string.Empty;
        }

        /// <summary>
        /// 判断算法有效性,主要检测输入参数是否绑定变量或者数值
        /// 需要确认修改
        /// </summary>
        /// <returns></returns>
        public virtual bool CheckSelfValid()
        {
            //孤立检测，动态输入变量必须关联
            bool isValid = true;
            foreach (string key in calcInputs.Keys)
            {
                PIDAlgorithmVar input = calcInputs[key];
                if (input.InputType == PIDVarInputType.Dynamic && string.IsNullOrEmpty(input.BindSource))
                {
                    isValid = false;
                    //生成错误记录
                    PIDCompileErrManager.Instance().AddError(new PIDCompileError
                    {
                        Identity = this.Identity,
                        GroupIndex = this.GroupIndex,
                        IndexInGroup = this.IndexInGroup,
                        Description = string.Format("输入变量 {0} 须关联变量", input.Name),
                        AlgName = this.AlgName
                    });
                }
            }

            return isValid;
        }

        /// <summary>
        /// 设置输入值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        public void SetBindParamValue(string source, double value)
        {
            if (bindRelation.ContainsKey(source))
            {
                foreach (PIDAlgorithmVar param in bindRelation[source])
                {
                    if (calcInputs.ContainsKey(param.Name))
                    {
                        this.SetInputValue(param.Name, value);
                    }
                }
            }
        }

        /// <summary>
        /// 获取输出名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetResultVarName(string name)
        {
            if (!calcResults.ContainsKey(name))
            {
                return string.Empty;
            }

            PIDAlgorithmVar result = calcResults[name];
            if (!string.IsNullOrEmpty(result.BindSource))
            {
                return result.BindSource;
            }
            else
            {
                return BindSourceToken.GetName(this.Identity.ToString(), name);
            }
        }

        /// <summary>
        /// 得到所有输出变量名称
        /// </summary>
        /// <returns></returns>
        public IList<string> GetAllResultVarName()
        {
            var list = new List<string>();
            foreach (var item in calcResults)
            {
                PIDAlgorithmVar result = calcResults[item.Key];
                var str = !string.IsNullOrEmpty(result.BindSource)
                              ? result.BindSource
                              : BindSourceToken.GetName(Identity, item.Key);
                list.Add(str);
            }
            return list;
        }

        public virtual string AlgAssembly
        {
            get
            {
                return GetType().Assembly.FullName;
            }
        }

        public virtual string AlgType
        {
            get
            {
                return GetType().FullName;
            }
        }

        /// <summary>
        /// 参数字符串
        /// </summary>
        public virtual string VarParams
        {
            get
            {
                IList<PIDAlgorithmVarSpec> specs = new List<PIDAlgorithmVarSpec>();
                foreach (PIDAlgorithmParam param in this.calcParams.Values)
                {
                    specs.Add(new PIDAlgorithmVarSpec { Name = param.Name, Value = param.ValueToString() });
                }
                return JsonConvert.SerializeObject(specs);
            }
            set
            {
                try
                {
                    IList<PIDAlgorithmVarSpec> specs = JsonConvert.DeserializeObject<IList<PIDAlgorithmVarSpec>>(value);
                    if (specs != null)
                    {
                        foreach (PIDAlgorithmVarSpec spec in specs)
                        {
                            if (!string.IsNullOrEmpty(spec.Value))
                                this.SetParamValue(spec.Name, spec.Value);
                        }
                    }
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 输入字符串
        /// </summary>
        public virtual string VarInputs
        {
            get
            {
                IList<PIDAlgorithmVarSpec> specs = new List<PIDAlgorithmVarSpec>();
                foreach (PIDAlgorithmVar input in this.calcInputs.Values)
                {
                    specs.Add(new PIDAlgorithmVarSpec
                    {
                        Name = input.Name,
                        BindSource = input.BindSource,
                        Value = input.Value.ToString(),
                        InputType = input.InputType
                    });
                }
                return JsonConvert.SerializeObject(specs);
            }
            set
            {
                try
                {
                    IList<PIDAlgorithmVarSpec> varInputs = JsonConvert.DeserializeObject<IList<PIDAlgorithmVarSpec>>(value);
                    if (varInputs != null)
                    {
                        foreach (PIDAlgorithmVarSpec input in varInputs)
                        {
                            this.SetInputValue(input.Name, ConvertUtil.ConvertToDouble(input.Value), input.InputType);
                            if (!string.IsNullOrEmpty(input.BindSource))
                            {
                                this.BindParam(input.Name, input.BindSource);
                            }
                        }
                    }
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 输出字符串
        /// </summary>
        public virtual string VarOutputs
        {
            get
            {
                IList<PIDAlgorithmVarSpec> specs = new List<PIDAlgorithmVarSpec>();
                foreach (PIDAlgorithmVar output in this.calcResults.Values)
                {
                    specs.Add(new PIDAlgorithmVarSpec { Name = output.Name, BindSource = output.BindSource, Value = output.Value.ToString() });
                }
                return JsonConvert.SerializeObject(specs);
            }
            set
            {
                try
                {
                    IList<PIDAlgorithmVarSpec> varOutputs = JsonConvert.DeserializeObject<IList<PIDAlgorithmVarSpec>>(value);
                    if (varOutputs != null)
                    {
                        foreach (PIDAlgorithmVarSpec output in varOutputs)
                        {
                            if (!string.IsNullOrEmpty(output.BindSource))
                                this.BindParam(output.Name, output.BindSource);
                        }
                    }
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 获取相关算法块标识
        /// </summary>
        /// <returns></returns>
        public IList<string> GetRelatedAlgs()
        {
            IList<string> ids = new List<string>();
            foreach (PIDAlgorithmVar input in this.calcInputs.Values)
            {
                if (string.IsNullOrEmpty(input.BindSource))
                    continue;

                string[] parts = BindSourceToken.GetParts(input.BindSource);
                if (parts.Length == 3 && parts[0] == BindSourceToken.PrefixBlock)
                    ids.Add(parts[1]);
            }
            return ids;
        }

        /// <summary>
        /// 克隆数据状态
        /// </summary>
        /// <param name="srcAlg"></param>
        public virtual void CloneFrom(PIDBindAlgorithm srcAlg)
        {
            if (srcAlg == null || srcAlg.Identity != this.Identity)
                return;

            foreach (KeyValuePair<string, PIDAlgorithmVar> inputVar in this.calcInputs)
            {
                PIDAlgorithmVar inputSrc = srcAlg.calcInputs[inputVar.Key];
                inputVar.Value.InputType = inputSrc.InputType;
                inputVar.Value.SourceValue = inputSrc.SourceValue;
                inputVar.Value.Value = inputSrc.Value;
            }

            foreach (KeyValuePair<string, PIDAlgorithmVar> outputVar in this.calcResults)
            {
                PIDAlgorithmVar outputSrc = srcAlg.calcResults[outputVar.Key];
                outputVar.Value.InputType = outputSrc.InputType;
                outputVar.Value.SourceValue = outputSrc.SourceValue;
                outputVar.Value.Value = outputSrc.Value;
            }

            foreach (KeyValuePair<string, PIDAlgorithmParam> paramVar in this.calcParams)
            {
                PIDAlgorithmParam paramSrc = srcAlg.calcParams[paramVar.Key];
                paramVar.Value.StringToValue(paramSrc.ValueToString());
            }
        }
    }
}
