using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors.Controls;
using Sinowyde.DOP.DataModel;
using System.Reflection;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using DevExpress.XtraEditors;
using Sinowyde.DataModel;

namespace Sinowyde.DOP.DataModel.Control
{
    public static class Common
    {
        /// <summary>
        /// IEnumerable 扩展 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static void ShowError(string content)
        {
            MessageBox.Show(content, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 根据实体设置下拉列表的index （非枚举下拉框可用）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="com"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static void SetComboxIndex<T>(this ComboBoxEdit com, T model) where T:Entity
        {
            List<T> list = com.Tag as List<T>;
            int index = 0;
            foreach (T item in list)
            {
                if (item.Equals(model))
                {
                     break;
                }
                index++;
            }
            com.SelectedIndex = index;
        }

        /// <summary>
        /// 设置下拉框的列表（非枚举下拉框可用）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="com"></param>
        /// <param name="list"></param>
        public static void SetComboxDataSource<T>(this ComboBoxEdit com, List<T> list) where T : Entity
        {
            System.Reflection.PropertyInfo propertyInfo = typeof(T).GetProperty("Name");
            if (propertyInfo != null)
            {
                foreach (T item in list)
                {
                    com.Properties.Items.Add(propertyInfo.GetValue(item, null).ToString());
                }
                com.Tag = list;
            }
        }

        /// <summary>
        /// 获取下拉框选中的实体（非枚举下拉框可用）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="com"></param>
        /// <returns></returns>
        public static T GetComboxData<T>(this ComboBoxEdit com) where T : Entity
        {
            List<T> list = com.Tag as List<T>;
            foreach (T item in list)
            {
                if (typeof(T).GetProperty("Name").GetValue(item, null).ToString() == com.Text.Trim())
                {
                    return item;
                }
            }
            return default(T);
        }

        /// <summary>
        /// 根据文本内容设置ComboBoxEdit的index
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static void SetIndexByText(this ComboBoxEdit cmb, object txt)
        {
            int index = 0;
            try
            {
                for (int i = 0; i < cmb.Properties.Items.Count; i++)
                {
                    if (cmb.Properties.Items[i].ToString().Equals(txt.ToString()))
                    {
                        index = i;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            cmb.SelectedIndex = index;
        }

    }
}
