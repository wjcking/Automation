using Sinowyde.DOP.PIDAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinowyde.DOP.PIDBlock
{
    public interface ICtrlParamBase
    {
        PIDGeneralBlock Block
        {
            get;
            set;
        }

        /// <summary>
        /// 加载界面参数显示
        /// </summary>
        void LoadParam();
        
        /// <summary>
        /// 保存参数
        /// </summary>
        bool SaveParam();

        /// <summary>
        /// 获取参数设置界面
        /// </summary>
        /// <returns></returns>
        UserControl GetParamCtrl();

    }
}
