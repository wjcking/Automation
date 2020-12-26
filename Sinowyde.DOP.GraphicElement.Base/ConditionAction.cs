using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;
using Sinowyde.DOP.DataModel;

namespace Sinowyde.DOP.GraphicElement.Base
{
    /// <summary>
    /// 动画类型
    /// </summary>
    [Serializable]
    public enum ActionType
    {
        ChangeColor = 1,
        Flash,
        Hide,
        Move,
        Text,
        Meter,
        Button,
        Hotspot,
        Dialog
    }

    /// <summary>
    /// 连接类型
    /// </summary>
    [Serializable]
    public enum LinkType
    {
        AO = 1,
        DO,
        DOThree,
        Package,
        Text,
        ForeColor,
        BackColor,
        DataPoint,
        Button,
        Hotspot,
        Meter
    }

  

    /// <summary>
    /// 条件动作表达式
    /// </summary>
    [Serializable]
    public class ConditionAction
    {
        public ConditionAction() { }

        /// <summary>
        /// 获取所有变量Number
        /// </summary>
        /// <returns></returns>
        public IList<string> GetAllVariable()
        {
            if (null == Variable)
                return null;
            IList<string> lstVariable = new List<string>();
            foreach (var var in Variable)
            {
                lstVariable.Add(var.Number);
            }

            return lstVariable;
        }

        /// <summary>
        /// 动画类型
        /// </summary>
        public ActionType ActionType { get; set; }

        /// <summary>
        /// 连接类型
        /// </summary>
        public LinkType LinkType { get; set; }

        public IList<Variable> Variable { get; set; }
        public IList<RTValue> RTValue { get; set; }
        public IList<string> Expression { get; set; }
        public List<Color> Colors { get; set; }
        public IList<string> Condition { get; set; }
        public IList<string> DefaultValue { get; set; }
        public Color DefaultColor { get; set; }
        public bool IsShowUnit { get; set; }
        public int DataFormat { get;set;}
        /// <summary>
        /// 是否执行动画
        /// </summary>
        public bool IsExcutedAction { get; set; }


    }
}
