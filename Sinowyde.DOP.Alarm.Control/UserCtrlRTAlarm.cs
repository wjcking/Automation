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
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.DataLogic;

namespace Sinowyde.DOP.Alarm.Control
{
    public partial class UserCtrlRTAlarm : DevExpress.XtraEditors.XtraUserControl
    {
        private System.Threading.Timer timer;
        private int RefreshCount = 0;

        public UserCtrlRTAlarm()
        {
            InitializeComponent();
        }

        private void InitData(object sender)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    lbl_LastTime.Text = "正在刷新";
                    btn_Refresh.Text = "停止";
                }));
                IList<RTAlarm> list = DOPDataLogic.Instance().GetTopItems<RTAlarm>(20);
                this.Invoke(new Action(() =>
                {
                    gc_RTAlarm.DataSource = list.ToList();
                    RefreshCount++;
                    lbl_LastTime.Text = string.Format("{0} （第{1}次）", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), RefreshCount);
                }));
            }
            catch (Exception)
            {
                this.Invoke(new Action(() =>
                {
                    gc_RTAlarm.DataSource = null;
                    Stop();
                    
                }));
            }
        }

        private void UserCtrlRTAlarm_Load(object sender, EventArgs e)
        {
            timer = new System.Threading.Timer(new TimerCallback(InitData), null, 0, 1000 * 10);
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            if (timer != null)
            {
                Stop();
            }
            else 
            {
                timer = new System.Threading.Timer(new TimerCallback(InitData), null, 0, 1000 * 10);
            }
        }

        private void Stop() 
        {
            btn_Refresh.Text = "开始";
            timer.Dispose();
            timer = null;
            RefreshCount = 0;
        }
    }
}
