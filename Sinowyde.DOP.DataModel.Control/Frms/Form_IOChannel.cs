using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataModel;

namespace Sinowyde.DOP.DataModel.Control
{
    public partial class Form_IOChannel : DevExpress.XtraEditors.XtraForm
    {
        private IOChannel entity = new IOChannel();

        public Form_IOChannel(IOChannel model = null)
        {
            InitializeComponent();
            if (model != null)
            {
                entity = model;
                if (entity.ID > 0)
                {
                    this.Text = "修改IO通道";
                    btn_Save.Text = "修改";
                    entity = DOPDataLogic.Instance().Get<IOChannel>(entity.ID);
                }
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!CheckValid())
                return;
            entity.IP = txt_Ip.Text.Trim();
            entity.Name = txt_Name.Text.Trim();
            entity.Params = GetParam();
            entity.Port = Sinowyde.Util.ConvertUtil.ConvertToInt(txt_Port.Value);
            entity.CommuType = new CommuTypeHelper().GetSelectValue(cmb_CommuType.Text);
            entity.GatherPeriod = Sinowyde.Util.ConvertUtil.ConvertToInt(txt_GatherPeriod.Value);
            entity.IOServer = cmb_IOServer.GetComboxData<IOServer>();
            if (entity.ID <= 0)
            {
                DOPDataLogic.Instance().Insert(entity);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                DOPDataLogic.Instance().Update(entity);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void Form_IOChannel_Load(object sender, EventArgs e)
        {
            CommuTypeHelper helper = new CommuTypeHelper();

            
            #region 绑定下拉列表
            string[] commuTypes = helper.GetShowTexts().ToArray<string>();
            cmb_CommuType.Properties.Items.AddRange(commuTypes);
            cmb_CommuType.SelectedIndex = 0;

            string[] serialNos = System.IO.Ports.SerialPort.GetPortNames();
            Array.Sort(serialNos);
            cmb_SerialNo.Properties.Items.AddRange(serialNos);
            cmb_SerialNo.SelectedIndex = 0;

            int[] bauds = new int[] { 4800, 9600, 14400, 19200, 38400, 56000, 115200 };
            cmb_baud.Properties.Items.AddRange(bauds);
            cmb_baud.SelectedIndex = 0;

            int[] dataBits = new int[] { 5, 6, 7, 8 };
            cmb_dataBits.Properties.Items.AddRange(dataBits);
            cmb_dataBits.SelectedIndex = 0;


            string[] paritys = new string[] { "None", "Odd", "Even", "MFlag", "Space" };
            cmb_parity.Properties.Items.AddRange(paritys);
            cmb_parity.SelectedIndex = 0;

            float[] stopBitses = new float[] { 1, 1.5f, 2 };
            cmb_stopBits.Properties.Items.AddRange(stopBitses);
            cmb_stopBits.SelectedIndex = 0;
            #endregion

            List<IOServer> list = DOPDataLogic.Instance().GetAllBy<IOServer>();
            cmb_IOServer.SetComboxDataSource<IOServer>(list);
            cmb_IOServer.SelectedIndex = 0;
            if (entity.IOServer != null)
            {
                cmb_IOServer.SetComboxIndex<IOServer>(entity.IOServer);
            }
            cmb_IOServer.Enabled = false;

            if (entity.ID > 0)
            {
                entity = DOPDataLogic.Instance().Get<IOChannel>(entity.ID);
            }
            txt_Ip.Text = entity.IP;
            txt_Name.Text = entity.Name;
            txt_Port.Text = entity.Port.ToString();
            txt_GatherPeriod.Value = entity.GatherPeriod;
            cmb_CommuType.SelectedIndex = new CommuTypeHelper().GetIndexByValue(entity.CommuType);
            
            if (entity.CommuType == CommuType.Serial)
            {
                SerialChannel serialChannel = new SerialChannel(entity);
                cmb_baud.SetIndexByText(serialChannel.Baud);
                cmb_dataBits.SetIndexByText(serialChannel.DataBits);
                cmb_stopBits.SetIndexByText(serialChannel.StopBits);
                cmb_SerialNo.SetIndexByText(serialChannel.SerialNo);
                cmb_parity.SetIndexByText(serialChannel.ParityVerify);
            }

        }

        private void cmb_CommuType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string commuStr = cmb_CommuType.Text.Trim();
            CommuType commuType = new CommuTypeHelper().GetSelectValue(commuStr);
            switch (commuType)
            {
                case CommuType.Serial:
                    ChoseCommuType(false);
                    break;
                case CommuType.TcpServer:
                    ChoseCommuType(true);
                    break;
                case CommuType.TcpClient:
                    ChoseCommuType(true);
                    break;
                default:
                    EnableAll();
                    break;
            }
        }

        #region Custom Method

        private void ChoseCommuType(bool isTcp)
        {
            txt_Ip.Enabled = isTcp;
            txt_Port.Enabled = isTcp;
            cmb_baud.Enabled = !isTcp;
            cmb_dataBits.Enabled = !isTcp;
            cmb_parity.Enabled = !isTcp;
            cmb_SerialNo.Enabled = !isTcp;
            cmb_stopBits.Enabled = !isTcp;
        }

        private void EnableAll()
        {
            txt_Ip.Enabled = false;
            txt_Port.Enabled = false;
            cmb_baud.Enabled = false;
            cmb_dataBits.Enabled = false;
            cmb_parity.Enabled = false;
            cmb_SerialNo.Enabled = false;
            cmb_stopBits.Enabled = false;
        }

        private string GetParam()
        {
            string param = string.Format("{0} {1} {2} {3} {4}", cmb_SerialNo.Text, cmb_baud.Text, cmb_dataBits.Text, cmb_stopBits.Text, cmb_parity.Text);
            return param;
        }

        private bool CheckValid()
        {
            if (string.IsNullOrEmpty(txt_Name.Text.Trim()))
            {
                MessageBox.Show("通道名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                if (entity.ID > 0)
                {
                    //修改
                    if (!entity.Name.Equals(txt_Name.Text) && DOPDataLogic.Instance().IsExist<IOChannel>(txt_Name.Text.Trim()))
                    {
                        MessageBox.Show("通道名称已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    if (DOPDataLogic.Instance().IsExist<IOChannel>(txt_Name.Text.Trim()))
                    {
                        MessageBox.Show("通道名称已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            CommuType commuType = new CommuTypeHelper().GetSelectValue(cmb_CommuType.Text);
            if (commuType == CommuType.TcpServer || commuType == CommuType.TcpClient)
            {
                System.Net.IPAddress ress;
                if (!System.Net.IPAddress.TryParse(txt_Ip.Text, out ress))
                {
                    MessageBox.Show("IP地址无效", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (txt_Port.Value <= 0 || txt_Port.Value > 65535)
                {
                    MessageBox.Show("端口无效", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (txt_GatherPeriod.Value <= 0)
            {
                MessageBox.Show("采集周期应大于0", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            return true;
        }

        #endregion
    }
}