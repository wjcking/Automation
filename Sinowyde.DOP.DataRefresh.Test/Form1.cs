using Sinowyde.DOP.DataBus;
using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.DataRefresh.Test.Properties;
using Sinowyde.DOP.DTProxy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sinowyde.DOP.DataRefresh.Test
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private RefreshThread refreshThread = new RefreshThread();

        private IList<Variable> variables = new List<Variable>();

        private SubscribeThreadPool subThread = new SubscribeThreadPool(Settings.Default.Publish, new List<string> { "IOServer"});
        
        private Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();
            refreshThread.RefreshEvent += EventRefreshArgsMessage;

            subThread.EventSubscribe += subThread_EventSubscribe;    
            timer.Interval = 100;
            timer.Tick += timer_Tick;

            variables = DOPDataLogic.Instance().Query<Variable>(null, null, 0, 0);
            MessageBox.Show(variables.Count.ToString());
        }

        void subThread_EventSubscribe(object sender, SubscribePoolEventArgs arg)
        {
            IList<string> messages = arg.Messages;
            IList<RTValue> values = new List<RTValue>();
            foreach (string message in messages)
            {
                values.Add(RTValue.FromString(message));
            }
            RefreshThread.AddValues(values);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            DateTime begin = DateTime.Now;

            IList<RTValue> values = new List<RTValue>();
            foreach (Variable variable in variables)
            {
                RTValue value = RefreshThread.valueMap.Get(variable.Number);
                if (value != null)
                    values.Add(value);
            }

            DateTime end = DateTime.Now;
            this.bindingSource1.DataSource = values;
            simpleButton3.Text = (end - begin).TotalSeconds.ToString();
        }

        void subThread_EventSubscribe(object sender, SubscribeEventArgs arg)
        {
            IList<string> messages = arg.Messages;
            IList<RTValue> values = new List<RTValue>();
            foreach (string message in messages)
            {
                values.Add(RTValue.FromString(message));
            }
            RefreshThread.AddValues(values);
        }

        public void EventRefreshArgsMessage(object sender, EventArgs arg)
        {
            DateTime begin = DateTime.Now;

            IList<RTValue> values = new List<RTValue>();
            foreach (Variable variable in variables)
            {
                RTValue value = RefreshThread.valueMap.Get(variable.Number);
                if (value != null)
                    values.Add(value);
                //this.bindingSource1.DataSource = values;
                //this.gridControl1.DataSource = values;
            }

            DateTime end = DateTime.Now;
            this.bindingSource1.DataSource = values;
            //simpleButton3.Text = (end - begin).TotalSeconds.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RTValueMemCache.Instance().StartMemCache("tcp://127.0.0.1:9003", new List<string> { "IOServer"});

            this.subThread.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            RTValueMemCache.Instance().StopMemCache();
            this.subThread.Stop();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            timer.Start();
 
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

    }
}
