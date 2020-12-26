using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.DTProxy;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using Sinowyde.DOP.DataBus;

namespace Sinowyde.DOP.RTData.Control
{
    public partial class UserCtrlRtGrid : DevExpress.XtraEditors.XtraUserControl
    {
        private string Placeholder = "Name Or Number";

        private WorkThreadTimer WorkTimer = null;

        private int TimerPeriod = 1 * 1000;

        private SubscribeThread subThread = null;

        private bool isLoading = false;

        private DevExpress.XtraWaitForm.ProgressPanel loading = new DevExpress.XtraWaitForm.ProgressPanel()
        {
            ShowCaption = false,
            Description = "正在查询...",
            Visible = false,
            Size = new System.Drawing.Size(120, 50),
            Name = "sinowydeloading"
        };

        #region Custom Method
        /// <summary>
        /// 初始化下拉项的数据源
        /// </summary>
        private void LoadSearchData()
        {

            loading.Description = "正在加载 ...";
            loading.Visible = true;

            new Thread(new ThreadStart(() =>
            {
                List<Device> devices = DOPDataLogic.Instance().GetAllBy<Device>();
                devices.Insert(0, new Device() { Name = "全部" });
                string[] deviceNames = (from c in devices select c.Name).ToArray<string>();
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        cmb_DirectionType.Properties.Items.AddRange(new string[] { "全部", "读取", "写入", "计算", "临时" });
                        cmb_Device.Properties.Items.AddRange(deviceNames);
                        cmb_Device.SelectedIndex = 0;
                        cmb_Device.Tag = devices;
                        cmb_DirectionType.SelectedIndex = 0;
                        btn_Search.Enabled = true;
                        loading.Visible = false;
                    }));
                }

            })).Start();
        }

        #endregion

        void subPool_EventSubscribe(object sender, UpdateRTValuesArg arg)
        {
            try
            {
                IList<RTValue> realValue = arg.Values;
                if (realValue != null && realValue.Count > 0)
                {
                    for (int i = 0; i < realValue.Count; i++)
                    {
                        int index = ((IList<VariabelEx>)gc_Variable.DataSource).FindIndex(o => o.Number.Equals(realValue[i].VarNumber));
                        VariabelEx row = ((IList<VariabelEx>)gc_Variable.DataSource)[index];
                        row.Timestamp = realValue[i].Timestamp;
                        row.Value = realValue[i].Value;
                        gv_Varibale.RefreshRow(index);
                    }

                }
            }
            catch
            { }
        }

        public UserCtrlRtGrid()
        {
            InitializeComponent();
            WorkTimer = new WorkThreadTimer(TimerPeriod);
            //gv_Varibale.Columns["column_Percentage"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //gv_Varibale.Columns["column_Percentage"].DisplayFormat.Format = new MyExamFormat();
        }

        private void UserCtrlRtGrid_Load(object sender, EventArgs e)
        {
            //DTProxy.RTValueMemCache.Instance().EventUpdateRTValues += subPool_EventSubscribe;

            this.Controls.Add(loading);
            loading.BringToFront();
            loading.Location = new Point((this.Width - loading.Width) / 2, (this.Height - loading.Height) / 2);
            this.SizeChanged += delegate(object formSender, EventArgs ea)
            {
                loading.Location = new Point((this.Width - loading.Width) / 2, (this.Height - loading.Height) / 2);
            };

            LoadSearchData();

            
        }

        private void txt_keys_Enter(object sender, EventArgs e)
        {
            if (txt_keys.Text.Trim().Equals(Placeholder))
            {
                txt_keys.Text = string.Empty;
                txt_keys.ForeColor = Color.Black;
            }
        }

        private void txt_keys_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_keys.Text.Trim()))
            {
                txt_keys.Text = Placeholder;
                txt_keys.ForeColor = Color.Silver;
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (WorkTimer.TimerIsRun)
            {
                WorkTimer.StopWorkTimer();
            }

            isLoading = true;
            loading.Description = "正在查询 ...";
            loading.Visible = true;

            new Thread(new ThreadStart(() =>
            {

                string keyword = txt_keys.Text.Replace(Placeholder, "");
                Device device = ((List<Device>)cmb_Device.Tag).Find(o => o.Name.Equals(cmb_Device.Text));

                long? deviceId = device.ID;
                VarDirectionType? varDirectionType = null;
                if (!cmb_DirectionType.Text.Equals("全部"))
                {
                    varDirectionType = new VarDirectionTypeHelper().GetSelectValue(cmb_DirectionType.Text);
                }
                IList<Variable> lists = DOPDataLogic.Instance().GetVariableWithRTData(keyword, varDirectionType, deviceId);

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        loading.Visible = false;
                        gc_Variable.DataSource = (from c in lists select new VariabelEx { Number = c.Number, Name = c.Name, DirectionType = c.DirectionType, Device = c.Device, Timestamp = null }).ToList();
                       
                        WorkTimer.StartWorkTimer(DoWork);
                    }));
                }
            })).Start();
        }

        public void DoWork(object sender)
        {
            Random rd = new Random();
            var vars = from c in (List<VariabelEx>)gv_Varibale.DataSource select c.Number;
            string[] variables = vars.ToArray<string>();

            IList<RTValue> realValue = DOP.DTProxy.RTValueMemCache.Instance().GetValues(variables);
 
            //需要委托 因为跨线程
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    if (realValue != null && realValue.Count > 0)
                    {
                        for (int i = 0; i < realValue.Count; i++)
                        {
                            int index = ((IList<VariabelEx>)gc_Variable.DataSource).FindIndex(o => o.Number.Equals(realValue[i].VarNumber));
                            VariabelEx row = ((IList<VariabelEx>)gc_Variable.DataSource)[index];
                            row.Timestamp = realValue[i].Timestamp;
                            //row.SetChange(realValue[i].Value);
                            row.Value = realValue[i].Value;
                            gv_Varibale.RefreshRow(index);
                        }

                    }
                }));
            }

        }


        private void gv_Varibale_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            //if (e.Column.Name.Equals("column_Percentage") )//&& e.IsSetData)
            //{

            //    ImageComboBoxEdit com = new ImageComboBoxEdit();
            //    ImageComboBoxItem item = new ImageComboBoxItem();
            //    item.Description = e.Value.ToString();
            //    item.ImageIndex = 0;

            //    com.Properties.SmallImages = imageCollection1;

            //    com.Properties.Items.Add(item);
            //    e.Value = com;
            //}
            //if (e.Column.Name.Equals("") && e.IsGetData)
            //{
            //    ImageComboBoxEdit com = new ImageComboBoxEdit();

            //}
        }

        private void gv_Varibale_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if(e.Column.Name.Equals("column_Percentage"))
            {
                e.DisplayText = Convert.ToDouble(e.Value).ToString("#0.00") + "%";
            }
        }

    }
    public class VariabelEx : Variable
    {
        private double value = 0;
        public DateTime? Timestamp { get; set; }
        public double? Percentage { get; private set; }
        public double Value
        {
            get { return this.value; }
            set
            {
                // (b - a / a) * 100%
                Percentage = 0;
                if (!this.value.Equals(0))
                {
                    Percentage = ((value - this.value) / this.value);
                }
                else 
                {
                    Percentage = null;
                }
                this.value = value;
            }
        }

    }

    public class WorkThreadTimer
    {
        private int timerPeriod = 1000;

        private System.Threading.Timer workTimer;

        private bool timerIsRun = false;

        public bool TimerIsRun { get { return timerIsRun; } }

        /// <summary>
        /// 轮询周期
        /// </summary>
        public int TimerPeriod
        {
            get { return timerPeriod; }
            set
            {
                timerPeriod = value;
                if (this.workTimer != null)
                {
                    this.StopWorkTimer();
                    this.StartWorkTimer(this.action);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TimerPeriod">轮询周期</param>
        public WorkThreadTimer(int TimerPeriod)
        {
            this.timerPeriod = TimerPeriod;
        }

        /// <summary>
        /// 启动线程
        /// </summary>
        public void StartWorkTimer(Action<Object> action)
        {
            timerIsRun = true;
            this.action = action;
            if (workTimer != null)
            {
                workTimer.Dispose();
                workTimer = null;
            }
            workTimer = new System.Threading.Timer(new System.Threading.TimerCallback(action), null, 0, timerPeriod);
        }

        public void StopWorkTimer()
        {
            timerIsRun = false;
            if (workTimer != null)
            {
                workTimer.Dispose();
                workTimer = null;

            }
        }

        private Action<Object> action = null;
    }

    public class MyExamFormat : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            return "第" + arg + "" + "题";
        }
    }
}
