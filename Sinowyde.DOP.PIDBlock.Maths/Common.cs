using DevExpress.XtraEditors;
using Sinowyde.DOP.PIDAlgorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sinowyde.DOP.PIDBlock
{
    public static class Common
    {
        /// <summary>
        /// 更新算法参数
        /// </summary>
        /// <param name="isSet"></param>
        public static void UpdateParams(this UserControl Control, bool isSet, PIDBindAlgorithm Algorithm)
        {
            UpdateAlgorithmParams(Control, isSet, Algorithm);
        }

        /// <summary>
        /// 递归查找控件tag 赋值
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="isSet">true : 获取 false : 保存</param>
        /// <param name="Algorithm">算法块</param>
        private static void UpdateAlgorithmParams(Control control, bool isSet, PIDBindAlgorithm Algorithm)
        {
            foreach (Control item in control.Controls)
            {
                if (item is GroupControl)
                {
                    UpdateAlgorithmParams(item, isSet, Algorithm);
                }
                else
                {
                    if (item is SpinEdit && item.Tag != null)
                    {
                        if (isSet)
                        {
                            if (item.Tag.ToString().IndexOf(PIDAlgorithmToken.prefixInput) > -1)
                            {
                                //输入
                                ((SpinEdit)item).Enabled = string.IsNullOrEmpty(Algorithm.GetBindParam(item.Tag.ToString())) ? true : false;
                                ((SpinEdit)item).Value = Convert.ToDecimal(Algorithm.GetInputVar(item.Tag.ToString()).Value);
                            }
                            else
                            {
                                //参数
                                PIDAlgorithmParam param = Algorithm.GetParam(item.Tag.ToString());
                                if (param != null)
                                {
                                    ((SpinEdit)item).Value = Convert.ToDecimal(param.Value);
                                }
                            }
                        }
                        else
                        {
                            if (item.Tag.ToString().IndexOf(PIDAlgorithmToken.prefixInput) > -1)
                            {
                                //输入
                                Algorithm.SetInputSourceValue(item.Tag.ToString(), Sinowyde.Util.ConvertUtil.ConvertToDouble(((SpinEdit)item).Value));
                            }
                            else
                            {
                                //参数
                                Algorithm.SetParamValue(item.Tag.ToString(), Sinowyde.Util.ConvertUtil.ConvertToDouble(((SpinEdit)item).Value));
                            }
                        }
                    }
                }
            }
        }
    }
}
