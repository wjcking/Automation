using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Ninject;
using Northwoods.Go;
using Sinowyde.DOP.UI;
using Sinowyde.Util;

namespace Sinowyde.DOP.PIDBlock.Test2
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private PIDGeneralBlock pIDGeneralBlock = null;
        private GoView _goView = new GoView();
        private DataTable _dataTableParam = new DataTable();
        private DataTable _dataTableInput = new DataTable();
        private DataTable _dataTableOutput = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateDataTable();
            InitBlocks();
            InitUi();
        }

        private void InitUi()
        {
            this.comboBoxEditAlgorithms.SelectedIndexChanged += comboBoxEditAlgorithms_SelectedIndexChanged;
            _goView.Dock = DockStyle.Fill;
            this.panelControlGoView.Controls.Add(_goView);

            this.gridViewInput.OptionsMenu.EnableColumnMenu = false;
            this.gridViewInput.GroupPanelText = "输入";
            this.gridViewInput.OptionsCustomization.AllowColumnMoving = false;//列头禁止移动


            this.gridViewOutput.OptionsMenu.EnableColumnMenu = false;
            this.gridViewOutput.GroupPanelText = "输出";
            this.gridViewOutput.OptionsCustomization.AllowColumnMoving = false;//列头禁止移动

            this.gridViewParam.OptionsMenu.EnableColumnMenu = false;
            this.gridViewParam.GroupPanelText = "参数";
            this.gridViewParam.OptionsCustomization.AllowColumnMoving = false;//列头禁止移动
        }


        private void CreateBlock(string blockName)
        {
            var tool = NinjectHelper.Kernel.Get<MefTool>().ToolAddBlocks.Where(v => v.Metadata.Name.Equals(blockName)).FirstOrDefault();
            if (null == tool)
                return;

            pIDGeneralBlock = tool.Value.CreateBlock();
            pIDGeneralBlock.Location = new PointF(_goView.Width * 0.5f, _goView.Height * 0.5f);
            _goView.Document.Clear();
            _goView.Document.Add(pIDGeneralBlock);
            FillDataTable(pIDGeneralBlock);
        }

        private void comboBoxEditAlgorithms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null == this.comboBoxEditAlgorithms.SelectedItem)
                return;
            var str = this.comboBoxEditAlgorithms.SelectedItem.ToString().Split('.')[1];
            CreateBlock(str);
        }

        private void simpleButtonStepCalcu_Click(object sender, EventArgs e)
        {
            if (null == pIDGeneralBlock)
                return;

            DtToAlgorithm(pIDGeneralBlock);//把参数设置一遍,然后计算
            pIDGeneralBlock.Algorithm.DoCalc();
            FillDataTable(pIDGeneralBlock);//计算完把参数赋值回界面
        }

        private void simpleButtonReset_Click(object sender, EventArgs e)
        {
            if (null == this.comboBoxEditAlgorithms.SelectedItem)
                return;
            var str = this.comboBoxEditAlgorithms.SelectedItem.ToString().Split('.')[1];
            CreateBlock(str);
        }

        private void simpleButtonRefresh_Click(object sender, EventArgs e)
        {
            if (null == pIDGeneralBlock)
                return;

            FillDataTable(pIDGeneralBlock);//把参数设置一遍,然后计算
        }

        private void InitBlocks()
        {
            var mefTool = NinjectHelper.Kernel.Get<MefTool>();
            this.comboBoxEditAlgorithms.Properties.Items.Clear();
            foreach (var tool in mefTool.ToolAddBlocks)
            {
                var str = string.Format("{0}.{1}", tool.Metadata.Group, tool.Metadata.Name);
                this.comboBoxEditAlgorithms.Properties.Items.Add(str);
            }
        }

        private void CreateDataTable()
        {
            _dataTableParam.Clear();
            _dataTableInput.Clear();
            _dataTableOutput.Clear();


            var dataParamColumnKey = new DataColumn("Key");
            dataParamColumnKey.DataType = typeof(String);
            var dataParamColumnValue = new DataColumn("Value");
            dataParamColumnValue.DataType = typeof(Double);
            _dataTableParam.Columns.Add(dataParamColumnKey);
            _dataTableParam.Columns.Add(dataParamColumnValue);


            var dataInputColumnKey = new DataColumn("Key");
            dataInputColumnKey.DataType = typeof(String);
            var dataInputColumnValue = new DataColumn("Value");
            dataInputColumnValue.DataType = typeof(Double);
            var dataInputColumnBindSoure = new DataColumn("BindSoure");
            dataInputColumnBindSoure.DataType = typeof(String);
            _dataTableInput.Columns.Add(dataInputColumnKey);
            _dataTableInput.Columns.Add(dataInputColumnValue);
            _dataTableInput.Columns.Add(dataInputColumnBindSoure);

            var dataOutputColumnKey = new DataColumn("Key");
            dataOutputColumnKey.DataType = typeof(String);
            var dataOutputColumnValue = new DataColumn("Value");
            dataOutputColumnValue.DataType = typeof(Double);
            _dataTableOutput.Columns.Add(dataOutputColumnKey);
            _dataTableOutput.Columns.Add(dataOutputColumnValue);


            this.gridControlParam.DataSource = _dataTableParam;
            this.gridControlInput.DataSource = _dataTableInput;
            this.gridControlOutput.DataSource = _dataTableOutput;
        }

        private void DtToAlgorithm(PIDGeneralBlock block)
        {
            DtParamToAlgorithm(block);
            DtInputToAlgorithm(block);
        }

        private void DtParamToAlgorithm(PIDGeneralBlock block)
        {
            foreach (DataRow row in _dataTableParam.Rows)
            {
                var key = ConvertUtil.ConvertToString(row["Key"]);
                var value = ConvertUtil.ConvertToString(row["Value"]);
                block.Algorithm.SetParamValue(key, value);
            }
        }

        private void DtInputToAlgorithm(PIDGeneralBlock block)
        {
            foreach (DataRow row in _dataTableInput.Rows)
            {
                var key = ConvertUtil.ConvertToString(row["Key"]);
                var value = ConvertUtil.ConvertToDouble(row["Value"]);
                block.Algorithm.SetInputValue(key, value);
            }
        }


        private void FillDataTable(PIDGeneralBlock block)
        {
            FillDataTableParam(block);
            FillDataTableInput(block);
            FillDataTableOutput(block);
        }

        private void FillDataTableParam(PIDGeneralBlock block)
        {
            _dataTableParam.Rows.Clear();
            DataRow row = null;
            foreach (var item in block.Algorithm.GetAllParam())
            {
                row = _dataTableParam.NewRow();
                row["Key"] = item.Name;
                row["Value"] = item.Value;
                _dataTableParam.Rows.Add(row);
            }

            this.gridControlParam.Refresh();
        }

        private void FillDataTableInput(PIDGeneralBlock block)
        {
            _dataTableInput.Rows.Clear();
            DataRow row = null;
            foreach (var item in block.Algorithm.GetAllInput())
            {
                row = _dataTableInput.NewRow();
                row["Key"] = item.Name;
                row["Value"] = item.Value;
                row["BindSoure"] = item.BindSource;
                _dataTableInput.Rows.Add(row);
            }

            this.gridControlInput.Refresh();
        }

        private void FillDataTableOutput(PIDGeneralBlock block)
        {
            _dataTableOutput.Rows.Clear();
            DataRow row = null;
            foreach (var item in block.Algorithm.GetAllOutput())
            {
                row = _dataTableOutput.NewRow();
                row["Key"] = item.Name;
                row["Value"] = item.Value;
                _dataTableOutput.Rows.Add(row);
            }

            this.gridControlOutput.Refresh();
        }

        private void checkEditInput_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkEditInput.Checked)
                this.gridControlInput.Enabled = true;
            else
                this.gridControlInput.Enabled = false;
        }


    }
}
