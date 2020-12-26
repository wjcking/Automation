using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.GraphicElement.Base
{
    /// <summary>
    /// 组态画面状态
    /// </summary>
    public enum GraphDocStatus
    {
        IsEdit=0, //编辑状态
        IsDebug,  //调试状态
        IsRun     //运行状态
    }
    /// <summary>
    /// 修改graph事件参数
    /// </summary>
    public class GraphEditEventArgs : EventArgs
    {
        public GraphDocStatus Status
        {
            get;
            set;
        }
    }
    /// <summary>
    ///  修改组态编辑环境事件
    /// </summary>
    /// <param name="criteria"></param>
    /// <param name="condValue"></param>
    public delegate void ChangeEdithRunTime(object sender, GraphEditEventArgs arg); 
    /// <summary>
    /// graph运行环境动态设置
    /// 
    /// </summary>
    public class GraphRunTime
    {
        /// <summary>
        /// 单例数据库访问对象
        /// </summary>
        private static GraphRunTime instance = null;

        private static object _lock = new object();

        public static GraphRunTime Instance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new GraphRunTime();
                }
            }

            return instance;
        }

        public GraphRunTime()
        {
        }
        // <summary>
        /// graph是否在编辑状态
        /// </summary>
        private GraphDocStatus docStatus = GraphDocStatus.IsEdit;
        public virtual GraphDocStatus GraphStatus
        {
            get
            {
                return docStatus;
            }
            set
            {
                if (docStatus != value)
                {
                    docStatus = value;
                    if (DocChangeEditEvent != null)
                        DocChangeEditEvent(this, new GraphEditEventArgs { Status = value });
                }
                
            }
        }
        /// <summary>
        /// 订阅事件
        /// </summary>
        public event ChangeEdithRunTime DocChangeEditEvent;

        public virtual bool IsRun()
        {
            if (this.GraphStatus == GraphDocStatus.IsRun || this.GraphStatus == GraphDocStatus.IsDebug)
                return true;

            return false;
        }

        public virtual bool IsEdit()
        {
            return this.GraphStatus == GraphDocStatus.IsEdit;
        }
    }
}
