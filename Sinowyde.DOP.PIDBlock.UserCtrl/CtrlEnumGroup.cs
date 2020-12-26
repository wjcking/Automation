using Sinowyde.DOP.PIDAlgorithm.Logic;
using DevExpress.XtraEditors.Controls;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDBlock.UserCtrl
{
    public enum GroupEnum
    {
        None = 0,
        ETimer,
        ECompare,
        EPulse,
        ECounter
    }
    public partial class CtrlEnumGroup : DevExpress.XtraEditors.GroupControl
    {

        public CtrlEnumGroup()
        {
            InitializeComponent();

        }

        private GroupEnum enumType;
        public GroupEnum EnumType
        {
            get { return enumType; }
            set
            {
                enumType = value;
                LoadEnum();
            }
        }
        public TimerSenseType TimerSense
        {
            get
            {

                return (TimerSenseType)rdEnum.Properties.Items[rdEnum.SelectedIndex].Value;
            }
        }

        /// <summary>
        /// 按照相应的enumtype类型选取，枚举类转换成int
        /// </summary>
        public object SelectedItem
        {
            get
            {
                if (rdEnum.SelectedIndex > -1)
                    return rdEnum.Properties.Items[rdEnum.SelectedIndex].Value;
                return null;
            }
            set
            {
                for (int i = 0; i < rdEnum.Properties.Items.Count; i++)
                {
                    if (value == rdEnum.Properties.Items[i].Value ||  ConvertUtil.ConvertToInt(value) == ConvertUtil.ConvertToInt(rdEnum.Properties.Items[i].Value))
                    {
                        rdEnum.SelectedIndex = i;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 返回枚举或者布尔值的int
        /// </summary>
        public int SelectedInteger
        {
            get
            {
                return ConvertUtil.ConvertToInt(SelectedItem);
            }
            set
            {
                switch (enumType)
                {
                    case GroupEnum.ETimer:
                        SelectedItem = (TimerSenseType)value;
                        break;
                    case GroupEnum.ECompare:
                        SelectedItem = (FxEnum)value;
                        break;
                    case GroupEnum.EPulse:
                        SelectedItem = (PulseSignal)value;
                        break;
                    case GroupEnum.ECounter:
                        SelectedItem = ConvertUtil.ConvertToBool(value);
                        break;
                }
            }
        }
        public void LoadEnum()
        {
            this.Controls.Clear();
            rdEnum.Properties.Items.Clear();

            switch (EnumType)
            {
                case GroupEnum.ETimer:
                    Text = "请选择时钟输入触发边界";
                    rdEnum.Properties.Items.Add(new RadioGroupItem(TimerSenseType.Up, "上升沿触发"));
                    rdEnum.Properties.Items.Add(new RadioGroupItem(TimerSenseType.Down, "下降沿触发"));
                    rdEnum.Properties.Items.Add(new RadioGroupItem(TimerSenseType.Any, "任意沿触发"));

                    //  rdEnum.Properties.Items.AddEnum<TimerSenseType>(
                    break;
                case GroupEnum.ECompare:
                    Text = "请选择比较类型";
                    rdEnum.Properties.Items.Add(new RadioGroupItem(FxEnum.Bigger, ">"));
                    rdEnum.Properties.Items.Add(new RadioGroupItem(FxEnum.Samller, "<"));
                    rdEnum.Properties.Items.Add(new RadioGroupItem(FxEnum.Equal, "="));
                    rdEnum.Properties.Items.Add(new RadioGroupItem(FxEnum.BiggerEqual, ">="));
                    rdEnum.Properties.Items.Add(new RadioGroupItem(FxEnum.SamllerEqual, "<="));
                    break;
                case GroupEnum.EPulse:
                    Text = "脉冲信号";
                    rdEnum.Properties.Items.Add(new RadioGroupItem(PulseSignal.Up, "上升"));
                    rdEnum.Properties.Items.Add(new RadioGroupItem(PulseSignal.Down, "下降"));
                    //  rdEnum.Properties.Items.Add(new RadioGroupItem(PulseSignal.Normal, "无变化"));
                    break;
                case GroupEnum.ECounter:
                    Text = "选择计数器记数方向";
                    rdEnum.Properties.Items.Add(new RadioGroupItem(true, "正向"));
                    rdEnum.Properties.Items.Add(new RadioGroupItem(false, "逆向"));

                    break;
                default:
                    rdEnum.Properties.Items.Add(new RadioGroupItem(false, "请输入tag标签显示相关枚举"));
                    break;
            }

            if (rdEnum.Properties.Items.Count > 0)
                rdEnum.SelectedIndex = 0;

            rdEnum.Properties.Columns = rdEnum.Properties.Items.Count;
            this.Controls.Add(rdEnum);
        }
    }
}
