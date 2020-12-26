using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.DataLogic;
using System.Threading;
using Sinowyde.Util;

namespace Sinowyde.DOP.GraphicElement
{
    public partial class frmVariable : XtraForm
    {
        public Variable SelectedVariables
        {
            get;
            set;
        }
        private VariableType variableType = VariableType.AM;
        public frmVariable()
        {
            InitializeComponent();
        }

        public frmVariable(VariableType VariableType)
        {
            InitializeComponent();
            variableType = VariableType;
        }

        private void frmVariable_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                IList<Device> devices = DOPDataLogic.Instance().GetAllBy<Device>().OrderBy(v=>v.Name).ToList();
                this.Invoke(new Action(() =>
                {
                    if (devices != null && devices.Count > 0)
                    {
                        BindComboBox(this.cboDevice, devices);
                        this.cboDevice.SelectedIndex = 0;
                    }
                    this.cboDataType.Properties.Items.AddRange(new VarDataTypeHelper().GetShowTexts().ToArray<string>());
                    this.cboDataType.SelectedIndex = 2;
                }));
            }));
            thread.IsBackground = true;
            thread.Start();
        }

        private IList<Variable> GetVariableInfo(long DeviceID)
        {
            IList<Variable> Variables = null;
            if (DeviceID < 1 && this.txtVariableName.Text=="")
            {
                Variables = DOPDataLogic.Instance().GetVariable("", "", null, 0, variableType,null, null, 0);
            }
            else
            {
                Variables = DOPDataLogic.Instance().GetVariable("", this.txtVariableName.Text, null, DeviceID, variableType, 
                    new VarDataTypeHelper().GetSelectValue(this.cboDataType.Text), null, 0);
            }

            return Variables.ToList();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="cmb">绑定控件</param>
        /// <param name="Devices"></param>
        private void BindComboBox(ComboBoxEdit cmb, IList<Device> Devices)
        {
            cmb.Properties.Items.Add("所有变量");
            foreach (var device in Devices)
            {
                this.cboDevice.Properties.Items.Add(new ComboxData() {
                    Text = device.Name,
                    DeviceID = device.ID
                });
            }
        }

        /// <summary>
        /// 填充数据区
        /// </summary>
        private void FillVariableInfo()
        {
            if (this.cboDevice.SelectedItem == null)
                return;
            IList<Variable> variables = null;
            long DeviceID = 0;
            if (this.cboDevice.SelectedIndex > 0)
                DeviceID = (this.cboDevice.SelectedItem as ComboxData).DeviceID;
            variables = GetVariableInfo(DeviceID);
            if (variables == null)
                return;
            this.gridCtrlDataInfo.DataSource = variables;
            this.gridCtrlDataInfo.RefreshDataSource();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SelectedVariables = ((List<Variable>)gridView.DataSource)[this.gridView.GetFocusedDataSourceRowIndex()];
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cboDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillVariableInfo();
        }

        private void cboDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillVariableInfo();
        }

        private void gridView_DoubleClick(object sender, EventArgs e)
        {
            btnSave_Click(null, null);
        }

        private void txtVariableName_KeyUp(object sender, KeyEventArgs e)
        {
            FillVariableInfo();
        }
    }

    public class ComboxData
    {
        public string Text { set; get; }
        public long DeviceID { set; get; }
        public override string ToString()
        {
            return Text;
        }
    }
}
