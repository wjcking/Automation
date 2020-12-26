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
    public partial class Form_IOUnit : DevExpress.XtraEditors.XtraForm
    {
        private IOUnit entity = new IOUnit();

        public Form_IOUnit(IOUnit model)
        {
            InitializeComponent();
            entity = model ??  new IOUnit();
        }

        private void Form_IOUnit_Load(object sender, EventArgs e)
        {
            if (entity!= null && entity.ID > 0)
            {
                this.Text = "修改IO单元";
                btn_Save.Text = "修改";
            }

            //加载所有通道
            List<IOChannel> list = DOPDataLogic.Instance().GetAllBy<IOChannel>();
            cmb_Channel.SetComboxDataSource<IOChannel>(list);
            cmb_Channel.SelectedIndex = 0;
            if (entity.Channel != null)
            {
                cmb_Channel.SetComboxIndex<IOChannel>(entity.Channel);
            }
            cmb_Channel.Enabled = false;

            var Protocols = DOPDataLogic.Instance().GetAllBy<IOUnit>().DistinctBy(p => p.Protocol);
            string[] pros = (from c in Protocols select c.Protocol).ToArray<string>();
            cmb_Protocol.Properties.Items.AddRange(pros);
            cmb_Protocol.Text = entity.Protocol == null ? "":entity.Protocol.Trim();
            txt_Address.Value = entity.Address;
            txt_Name.Text = entity.Name;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Name.Text.Trim()))
            {
                MessageBox.Show("名称不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (entity != null && entity.ID > 0)
            {
                if (entity.Name != null && !entity.Name.Equals(txt_Name.Text.Trim()) && DOPDataLogic.Instance().IsExist<IOUnit>(txt_Name.Text.Trim()))
                {
                    MessageBox.Show("IO单元已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (DOPDataLogic.Instance().IsExist<IOUnit>(txt_Name.Text.Trim()))
                {
                    MessageBox.Show("IO单元已存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txt_Address.Value<=0)
            {
                MessageBox.Show("采集地址应大于0", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cmb_Protocol.Text))
            {
                MessageBox.Show("协议类型不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            entity.Name = txt_Name.Text.Trim();
            entity.Protocol = cmb_Protocol.Text.Trim();
            entity.Channel = cmb_Channel.GetComboxData<IOChannel>(); //((IOChannel)cmb_Channel.SelectedItem).ID;
            entity.Address = Sinowyde.Util.ConvertUtil.ConvertToInt(txt_Address.Value);

            if (entity.ID > 0)
            {
                //update
                 DOPDataLogic.Instance().Update(entity);
                 this.Close();
            }
            else 
            {
                //add
                object result = DOPDataLogic.Instance().Insert(entity);
                this.Close();
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}