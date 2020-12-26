using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.RTData.Control
{
    /// <summary>
    /// ComboBoxEdit扩展方法
    /// </summary>
    public static class ComBoxEx
    {
        public static void SetDataSource<T>(this ComboBoxEdit cbe, List<T> dataSource, string showName = "Name") where T : Sinowyde.DataModel.Entity
        {
            foreach (T item in dataSource)
            {
                cbe.Properties.Items.Add(item.GetType().GetProperty(showName).GetValue(item, null).ToString());
            }
            cbe.Tag = dataSource;
        }

        public static T GetSelectItem<T>(this ComboBoxEdit cbe)
        {
            if (cbe.SelectedIndex == -1)
            {
                cbe.SelectedIndex = 0;
            }
            return ((List<T>)cbe.Tag)[cbe.SelectedIndex];
        }
    }
}
