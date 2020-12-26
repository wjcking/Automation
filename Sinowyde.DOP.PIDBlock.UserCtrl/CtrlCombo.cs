using DevExpress.XtraEditors.Controls;
using Sinowyde.DOP.DataModel;
using Sinowyde.Util;
using System.Collections.Generic;
using System.ComponentModel;

namespace Sinowyde.DOP.PIDBlock.UserCtrl
{
    public partial class CtrlCombo : DevExpress.XtraEditors.ComboBoxEdit
    {
        private EnumData[] itemEnums;

        public CtrlCombo()
        {
            InitializeComponent();
        }

        private DropEnum comboEnum = DropEnum.None;

        public DropEnum ComboEnum
        {
            get { return comboEnum; }
            set { comboEnum = value; }
        }

        /// <summary>
        /// 为空则表示未连接，如果有值则进行赋值
        /// </summary>
        public bool? NBoolValue
        {
            get
            {
                return Text.Equals("1") ? true : false;
            }
            set
            {
                if (value.HasValue)
                    Text = value.Value ? "1" : "0";
            }
        }

        /// <summary>
        /// 布尔值转换成整型
        /// </summary>
        public int IntValue
        {
            get
            {
                return ConvertUtil.ConvertToInt(Text);
            }
            set
            {
                Text = value == 1 ? "1" : "0";
            }
        }

        public void SetSelectedEnum(object ed)
        {
            foreach (EnumData e in itemEnums)
            {
                if (e.Value.ToString() == ed.ToString())
                {
                    SelectedItem = e;
                    break;
                }
            }
        }
        private void CtrlCombo_Layout(object sender, System.Windows.Forms.LayoutEventArgs e)
        {
            Properties.Items.Clear();
            itemEnums = EnumData.GetEnumDataHelper(ComboEnum);

            if (null != itemEnums)
            {
                Properties.Items.AddRange(itemEnums);
                SelectedIndex = 0;
                Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            }

        }

    }
}
