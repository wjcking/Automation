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
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.DataLogic;
using System.Threading;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.DragDrop;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid;
using DevExpress.Utils.Drawing.Helpers;
using DevExpress.Utils;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Sinowyde.DOP.DataReport.Control
{
    public partial class UserCtrlDataReport : DevExpress.XtraEditors.XtraUserControl
    {
        public UserCtrlDataReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 根据变量类型获取报表类型
        /// </summary>
        /// <param name="type">变量类型:AM 开关量 DM 模拟量</param>
        /// <returns></returns>
        private Dictionary<string, ReportType> GetReportType(VariableType type)
        {
            if (type.Equals(VariableType.AM))
            {
                //开关量
                return new Dictionary<string, ReportType>() 
            {
                
                { "实时值", ReportType.Max },
                { "0次数", ReportType.Max },
                { "1次数", ReportType.Max },
                { "跳变数", ReportType.Max }
            };
            }
            else if (type.Equals(VariableType.DM))
            {
                //数字量
                return new Dictionary<string, ReportType>() 
            {
                { "实时值", ReportType.Max },
                { "最大值", ReportType.Max },
                { "最小值", ReportType.Max },
                { "累计值", ReportType.Max },
                { "平均值", ReportType.Max },
            };
            }
            return default(Dictionary<string, ReportType>);

        }
        private bool IsLoaded = false;
        private List<Variable> Variables;
        private bool isSearch = false;
        /// <summary>
        /// 打开excel路径
        /// </summary>
        private string filePath = string.Empty;

        #region 加载变量数据信息

        public void ReloadVariableDataSource()
        {
            if (IsLoaded)
            {
                switch (cmb_DirectionType.Text)
                {
                    case "计算":
                        cmb_Device.SelectedIndex = 0;
                        break;
                    case "临时":
                        cmb_Device.SelectedIndex = 0;
                        break;
                    default:
                        break;
                }
                List<Variable> dataSource = Variables;
                if (!cmb_Device.Text.Equals("全部设备"))
                {
                    long deviceId = (cmb_Device.Tag as List<Device>).Find(o => o.Name.Equals(cmb_Device.Text)).ID;
                    dataSource = Variables.Where(o => o.Device.ID == deviceId).ToList();
                }
                if (!cmb_DirectionType.Text.Equals("全部"))
                {
                    dataSource = dataSource.Where(o => o.DirectionType == (VarDirectionType)cmb_DirectionType.SelectedIndex).ToList();
                }
                if (!string.IsNullOrEmpty(txt_Variable.Text))
                {
                    dataSource = dataSource.Where(o => o.Name.IndexOf(txt_Variable.Text.Trim()) > -1 || o.Number.IndexOf(txt_Variable.Text.Trim()) > -1).ToList();
                }
                gc_Variable.DataSource = dataSource;
            }
        }

        public void LoadVariableDataSource()
        {
            new Thread(new ThreadStart(() =>
            {
                List<Device> devices = DOPDataLogic.Instance().GetAllBy<Device>();
                devices.Insert(0, new Device() { Name = "全部设备", ID = 0 });
                Variables = DOPDataLogic.Instance().GetAllBy<Variable>();
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        cmb_Device.Properties.Items.Clear();
                        string[] deviceNames = (from c in devices select c.Name).ToArray();
                        cmb_Device.Properties.Items.AddRange(deviceNames);
                        cmb_Device.Tag = devices;
                        cmb_DirectionType.Properties.Items.Clear();
                        cmb_DirectionType.Properties.Items.AddRange(new string[] { "全部", "读取", "写入", "计算", "临时" });
                        cmb_DirectionType.SelectedIndex = 0;
                        cmb_Device.SelectedIndex = 0;
                        IsLoaded = true;
                        popEdit_Variable.Text = "请选择变量";
                        popEdit_Variable.Enabled = true;
                        ReloadVariableDataSource();
                    }));
                }
            })).Start();

        }

        #endregion

        /// <summary>
        /// 创建固定列
        /// </summary>
        private void CreateFixedColumn()
        {
            //创建固定列 [点名 描述 报表属性 单位]

            gv_Report.Columns.Clear();
            int visibleIndex = gv_Report.Columns.Count;
            GridColumn fixedColNumber = new GridColumn();
            fixedColNumber.Name = "column_Number";
            fixedColNumber.Caption = "点名";
            fixedColNumber.Visible = false;
            fixedColNumber.VisibleIndex = gv_Report.Columns.Count;
            gv_Report.Columns.Add(fixedColNumber);

            GridColumn fixedColName = new GridColumn();
            fixedColName.Name = "column_Name";
            fixedColName.Caption = "描述";
            fixedColName.Visible = false;
            fixedColName.VisibleIndex = gv_Report.Columns.Count;
            gv_Report.Columns.Add(fixedColName);

            GridColumn fixedColReportType = new GridColumn();
            fixedColReportType.Name = "column_ReportType";
            fixedColReportType.Caption = "属性";
            fixedColReportType.Visible = false;
            fixedColReportType.VisibleIndex = gv_Report.Columns.Count;
            gv_Report.Columns.Add(fixedColReportType);

            GridColumn fixedColUnit = new GridColumn();
            fixedColUnit.Name = "column_Unit";
            fixedColUnit.Caption = "单位";
            fixedColUnit.Visible = false;
            fixedColUnit.VisibleIndex = gv_Report.Columns.Count;
            gv_Report.Columns.Add(fixedColUnit);
        }

        /// <summary>
        /// 创建时间列
        /// </summary>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="Interval">时间间隔</param>
        private void CreateDateColumn(DateTime begin, DateTime end, TimeSpan Interval)
        {
            GridColumn column = new GridColumn();
            column.Name = begin.ToString("yyyy-MM-dd HH:mm:ss");
            column.Caption = begin.ToString("MMdd HH:mm:ss");
            column.Visible = false;
            column.VisibleIndex = gv_Report.Columns.Count;
            column.MaxWidth = 100;
            column.MinWidth = 100;
            gv_Report.Columns.Add(column);

            bool isAdd = true;
            DateTime lastDate = begin;
            while (isAdd)
            {

                DateTime currentDate = lastDate.AddDays(Interval.Days)
                    .AddHours(Interval.Hours)
                    .AddMinutes(Interval.Minutes)
                    .AddSeconds(Interval.Seconds);
                string dateName = currentDate.ToString("yyyy-MM-dd HH:mm:ss");
                if (currentDate.Ticks >= end.Ticks)
                {

                    if (gv_Report.Columns.Where(o => o.Name.Equals(end.ToString("yyyy-MM-dd HH:mm:ss"))).Count() <= 0)
                    {
                        GridColumn col = new GridColumn();
                        col.Name = end.ToString("yyyy-MM-dd HH:mm:ss");
                        col.Caption = end.ToString("MMdd HH:mm:ss");
                        col.Visible = false;
                        col.VisibleIndex = gv_Report.Columns.Count;
                        col.MaxWidth = 100;
                        col.MinWidth = 100;
                        gv_Report.Columns.Add(col);
                    }
                    isAdd = false;
                }
                else
                {
                    GridColumn col = new GridColumn();
                    col.Name = dateName;
                    col.Caption = currentDate.ToString("MMdd HH:mm:ss");
                    col.Visible = false;
                    col.VisibleIndex = gv_Report.Columns.Count;
                    col.MaxWidth = 100;
                    col.MinWidth = 100;
                    gv_Report.Columns.Add(col);

                    lastDate = currentDate;
                }
            }
        }

        /// <summary>
        /// 设置绑定数据
        /// </summary>
        private void SetGridColumnFieldName()
        {
            for (int i = 0; i < gv_Report.Columns.Count; i++)
            {
                GridColumn col = gv_Report.Columns[i];
                col.FieldName = col.Name;
            }
        }

        /// <summary>
        /// 整理所需要的数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public DataTable AnalyzeData(List<ReportConfigEntity> list, List<RTValue> values, TimeSpan tSpan)
        {
            DataTable table = new DataTable();
            for (int i = 0; i < gv_Report.Columns.Count; i++)
            {
                table.Columns.Add(gv_Report.Columns[i].Name);
            }

            #region  增加 虚拟列 为了查询

            string lastName = Convert.ToDateTime(table.Columns[table.Columns.Count - 1].ColumnName)
                    .AddDays(tSpan.Days)
                    .AddHours(tSpan.Hours)
                    .AddMinutes(tSpan.Minutes)
                    .AddSeconds(tSpan.Seconds).ToString("yyyy-MM-dd HH:mm:ss");
            table.Columns.Add(lastName);
            #endregion
            foreach (var item in list)
            {
                DataRow row = table.NewRow();

                row[0] = item.RCENumber;
                row[1] = item.RCEName;
                row[2] = item.ReportTypeName;
                row[3] = item.RCEUnit;

                //整理所需要的数据
                for (int c = 4; c < table.Columns.Count - 1; c++)
                {
                    DataColumn col = table.Columns[c];
                    DataColumn colNext = table.Columns[c + 1];
                    DateTime beginDate = Convert.ToDateTime(col.ColumnName);
                    DateTime endDate = Convert.ToDateTime(colNext.ColumnName);
                    //拿到当前 变量的在一段时间的数据
                    var currentDate = (from v in values where v.VarNumber.Equals(item.RCENumber) && v.Timestamp >= beginDate && v.Timestamp < endDate orderby v.Timestamp ascending select v.Value);

                    bool isHaveData = currentDate.Count() > 0;
                    switch (item.ReportType)
                    {
                        case ReportType.Max:
                            row[c] = isHaveData ? currentDate.Max().ToString("#0.00") : "0.00";
                            break;
                        case ReportType.Min:
                            row[c] = isHaveData ? currentDate.Min().ToString("#0.00") : "0.00";
                            break;
                        case ReportType.Real:
                            row[c] = isHaveData ? currentDate.First().ToString("#0.00") : "0.00";
                            break;
                        case ReportType.Total:
                            row[c] = isHaveData ? currentDate.Sum().ToString("#0.00") : "0.00";
                            break;
                        case ReportType.Average:

                            row[c] = isHaveData ? currentDate.Average().ToString("#0.00") : "0.00";
                            break;
                        case ReportType.FalseCount:
                            row[c] = currentDate.Where(v => v.Equals(0)).Count();
                            break;
                        case ReportType.TrueCount:
                            row[c] = currentDate.Where(v => v.Equals(1)).Count();
                            break;
                        case ReportType.Saltus:
                            int SaltusCount = 0;
                            double[] currentCount = currentDate.ToArray();
                            if (currentCount.Count() > 0)
                            {
                                double beginSaltus = currentDate.First();
                                for (int i = 1; i < currentCount.Count(); i++)
                                {
                                    if (!currentCount[i].Equals(beginSaltus))
                                    {
                                        SaltusCount++;
                                        beginSaltus = currentCount[i];
                                    }
                                }
                            }
                            row[c] = SaltusCount;
                            break;
                        default:
                            break;
                    }
                }
                table.Rows.Add(row);
            }
            return table;
        }

        public void ImportFromExcel(string path)
        {
            try
            {
                using (FileStream fs = File.Open(path, FileMode.Open))
                {
                    HSSFWorkbook workbook = new HSSFWorkbook(fs);
                    HSSFSheet sheet = workbook.GetSheet("查询信息") as HSSFSheet;
                    IRow row = sheet.GetRow(1);
                    DateTime beginDate = Convert.ToDateTime(row.GetCell(0).StringCellValue);
                    DateTime endDate = Convert.ToDateTime(row.GetCell(1).StringCellValue);
                    TimeSpan tSpan = TimeSpan.Parse(row.GetCell(2).StringCellValue);

                    dateTxt_Begin.DateTime = beginDate;
                    dateTxt_End.DateTime = endDate;
                    tsDateTxt_Interval.TimeSpan = tSpan;

                    HSSFSheet sheetReportConfigEntity = (HSSFSheet)workbook.GetSheet("配置信息");
                    List<ReportConfigEntity> reportConfigs = new List<ReportConfigEntity>();
                    System.Collections.IEnumerator rows = sheetReportConfigEntity.GetRowEnumerator();
                    rows.MoveNext();//移动到标题的下一行
                    while (rows.MoveNext())
                    {
                        IRow currentRow = (IRow)rows.Current;
                        ReportConfigEntity config = new ReportConfigEntity();
                        config.Variable = new Variable()
                        {
                            Name = currentRow.GetCell(1).StringCellValue,
                            Number = currentRow.GetCell(0).StringCellValue,
                            Unit = currentRow.GetCell(2).StringCellValue,
                            VariableType = new VariableTypeHelper().GetSelectValue(currentRow.GetCell(4).StringCellValue)
                        };
                        config.ReportType = new ReportTypeHelper(config.Variable.VariableType == VariableType.DM).GetValueByText(currentRow.GetCell(3).StringCellValue);
                        reportConfigs.Add(config);
                        //rows.MoveNext();
                    }

                    bindSourceReportConfig.DataSource = reportConfigs;


                    HSSFSheet sheetHisReport = (HSSFSheet)workbook.GetSheet("历史报表");
                    System.Collections.IEnumerator hisRows = sheetHisReport.GetRowEnumerator();

                    CreateFixedColumn();
                    CreateDateColumn(beginDate, endDate, tSpan);
                    hisRows.MoveNext();

                    DataTable table = new DataTable();

                    for (int i = 0; i < gv_Report.Columns.Count; i++)
                    {
                        table.Columns.Add(gv_Report.Columns[i].Name);
                    }
                    SetGridColumnFieldName();
                    while (hisRows.MoveNext())
                    {
                        IRow currentRow = hisRows.Current as IRow;
                        DataRow rowReport = table.NewRow();
                        for (int i = 0; i < currentRow.Cells.Count; i++)
                        {
                            rowReport[i] = currentRow.GetCell(i).StringCellValue;
                        }
                        table.Rows.Add(rowReport);
                    }

                    gc_Report.DataSource = table;
                    gv_Report.RefreshData();

                    workbook = null;
                    MessageBox.Show("已从文件中导入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请检查文件是否已打开", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        public void ExportToExcel(string filePath, DataTable table)
        {
            try
            {
                /**
             * 1 -> 保存查询条件
             *    1.1 ->开始时间
             *    1.2 ->结束时间
             *    1.3 ->时间间隔
             *    1.4 ->变量列表
             * 2 -> 保存查询结果
             * */
                using (FileStream fs = File.Open(filePath, FileMode.Create))
                {
                    HSSFWorkbook workbook = new HSSFWorkbook();

                    HSSFSheet sheetHisReport = (HSSFSheet)workbook.CreateSheet("历史报表");
                    IRow firstHisReportRow = sheetHisReport.CreateRow(0);
                    for (int i = 0; i < gv_Report.Columns.Count; i++)
                    {
                        //显示行
                        firstHisReportRow.CreateCell(i).SetCellValue(gv_Report.Columns[i].Caption);
                    }


                    DataView viewHisReport = gv_Report.DataSource as DataView;
                    DataTable tableHisReport = viewHisReport.Table;
                    IRow dbRow = sheetHisReport.CreateRow(1);
                    for (int i = 0; i < tableHisReport.Columns.Count; i++)
                    {
                        //隐藏行
                        dbRow.CreateCell(i).SetCellValue(tableHisReport.Columns[i].ColumnName);
                        dbRow.ZeroHeight = true;
                    }

                    for (int j = 0; j < tableHisReport.Rows.Count; j++)
                    {
                        IRow contentHisReportRow = sheetHisReport.CreateRow(j + 1);
                        for (int k = 0; k < tableHisReport.Columns.Count - 1; k++)
                        {
                            if (k > 3)
                            {
                                contentHisReportRow.CreateCell(k).SetCellValue(Convert.ToDouble(tableHisReport.Rows[j][k]).ToString("#0.00"));
                            }
                            else
                            {
                                contentHisReportRow.CreateCell(k).SetCellValue(tableHisReport.Rows[j][k].ToString());
                            }

                        }

                    }

                    //创建查询条件 工作薄
                    HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet("查询信息");
                    IRow firstRow = sheet.CreateRow(0);
                    firstRow.CreateCell(0).SetCellValue("开始时间");
                    firstRow.CreateCell(1).SetCellValue("结束时间");
                    firstRow.CreateCell(2).SetCellValue("时间间隔");
                    IRow contentRow = sheet.CreateRow(1);
                    contentRow.CreateCell(0).SetCellValue(dateTxt_Begin.DateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    contentRow.CreateCell(1).SetCellValue(dateTxt_End.DateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    contentRow.CreateCell(2).SetCellValue(tsDateTxt_Interval.TimeSpan.ToString());

                    HSSFSheet sheetReportConfigEntity = (HSSFSheet)workbook.CreateSheet("配置信息");
                    IRow firstRFERow = sheetReportConfigEntity.CreateRow(0);
                    for (int i = 0; i < gv_ReportConfig.Columns.Count; i++)
                    {
                        firstRFERow.CreateCell(i).SetCellValue(gv_ReportConfig.Columns[i].Name);
                    }

                    List<ReportConfigEntity> configs = ((gv_ReportConfig.DataSource as BindingSource).DataSource as List<ReportConfigEntity>);
                    for (int j = 0; j < configs.Count; j++)
                    {
                        IRow itemRow = sheetReportConfigEntity.CreateRow(j + 1);
                        itemRow.CreateCell(0).SetCellValue(configs[j].RCENumber);
                        itemRow.CreateCell(1).SetCellValue(configs[j].RCEName);
                        itemRow.CreateCell(2).SetCellValue(configs[j].RCEUnit);
                        itemRow.CreateCell(3).SetCellValue(configs[j].ReportTypeName);
                        itemRow.CreateCell(4).SetCellValue(new VariableTypeHelper().GetKeyByValue(configs[j].Variable.VariableType));
                    }

                    //隐藏工作簿
                    workbook.SetSheetHidden(1, true);
                    workbook.SetSheetHidden(2, true);
                    workbook.Write(fs);
                    workbook = null;
                    MessageBox.Show("已导出到文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请检查文件是否已打开", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 加载 cmb_reporttype 下拉框数据
        /// </summary>
        /// <param name="isDM"></param>
        private void LoadReportType(bool isDM)
        {
            cmb_ReportType.Properties.Items.Clear();
            cmb_ReportType.Properties.Items.AddRange(new ReportTypeHelper(isDM).GetNames());
            cmb_ReportType.SelectedIndex = 0;
        }

        private void UserCtrlDataReport_Load(object sender, EventArgs e)
        {
            cmb_ReportType.Properties.Items.Clear();
            LoadVariableDataSource();
            popEdit_Variable.Text = "正在加载...";
            navigationPane.SelectedPageIndex = 2;
            gc_Report.Location = new Point(12, 90);

        }

        private void cmb_DirectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_DirectionType.Text)
            {
                case "计算":
                    cmb_Device.SelectedIndex = 0;
                    cmb_Device.Enabled = false;
                    break;
                case "临时":
                    cmb_Device.SelectedIndex = 0;
                    cmb_Device.Enabled = false;
                    break;
                default:
                    cmb_Device.Enabled = true;
                    break;
            }

            ReloadVariableDataSource();
        }

        private void cmb_Device_SelectedIndexChanged(object sender, EventArgs e)
        {

            ReloadVariableDataSource();
        }

        private void txt_Variable_TextChanged(object sender, EventArgs e)
        {
            ReloadVariableDataSource();
        }

        private void gv_Variable_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = ((DevExpress.XtraGrid.Views.Grid.GridView)sender).CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内  
                if (hInfo.InRow)
                {
                    Variable var = ((List<Variable>)gv_Variable.DataSource)[hInfo.RowHandle];
                    popEdit_Variable.Text = var.Number;
                    popEdit_Variable.ClosePopup();
                    popEdit_Variable.Tag = var;
                    LoadReportType(var.VariableType == VariableType.DM);

                }
            }
        }

        /// <summary>
        /// 空数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            if (((DevExpress.XtraGrid.Views.Grid.GridView)sender).RowCount == 0)
            {
                string str = "暂无数据!";
                Font f = new Font("宋体", 10, FontStyle.Bold);
                SizeF sizeF = e.Graphics.MeasureString(str, f);
                int x = (int)((e.Bounds.Width - sizeF.Width) / 2);
                Rectangle r = new Rectangle(e.Bounds.Top + 5, e.Bounds.Left + 5, e.Bounds.Right - 5, e.Bounds.Height - 5);
                e.Graphics.DrawString(str, f, Brushes.Black, x, 40);
            }
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {



        }

        /// <summary>
        /// 添加变量到配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (popEdit_Variable.Tag == null)
            {
                return;
            }
            List<ReportConfigEntity> configs = null;
            if (bindSourceReportConfig.DataSource == null)
            {
                configs = new List<ReportConfigEntity>();
            }
            else
            {
                configs = bindSourceReportConfig.DataSource as List<ReportConfigEntity>;
            }

            ReportConfigEntity config = new ReportConfigEntity();
            config.Variable = popEdit_Variable.Tag as Variable;
            config.ReportType = new ReportTypeHelper(config.Variable.VariableType == VariableType.DM).GetValueByText(cmb_ReportType.Text);

            if (configs.Find(o => o.RCENumber.Equals(config.RCENumber) && o.ReportType.Equals(config.ReportType)) != null)
            {
                MessageBox.Show("该报表点定义已存在,请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            configs.Add(config);
            bindSourceReportConfig.DataSource = configs;
            gv_ReportConfig.RefreshData();
            gv_ReportConfig.DragGridRow<ReportConfigEntity>();
        }

        private void navigationPane_SelectedPageChanging(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangingEventArgs e)
        {
            switch (e.Page.Caption)
            {
                case "打开":
                    e.Cancel = true;
                    OpenFileDialog openFile = new OpenFileDialog();
                    openFile.Filter = "Excel文档(*.xls)|*.xls|Excel文档(*.xlsx)|*.xlsx";
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        ImportFromExcel(openFile.FileName);
                        filePath = openFile.FileName;
                    }
                    break;
                case "保存":
                    e.Cancel = true;
                    if (gv_Report.DataSource == null ||
                       (gv_Report.DataSource as DataView).Table == null ||
                       (gv_Report.DataSource as DataView).Table.Rows.Count <= 0)
                    {
                        return;
                    }
                    if (string.IsNullOrEmpty(filePath))
                    {
                        goto case "导出";
                    }
                    else
                    {
                        ExportToExcel(filePath, gv_Report.DataSource as DataTable);
                    }
                    break;
                case "导出":
                    e.Cancel = true;
                    if (gv_Report.DataSource == null ||
                        (gv_Report.DataSource as DataView).Table == null ||
                        (gv_Report.DataSource as DataView).Table.Rows.Count <= 0)
                    {
                        return;
                    }
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.Filter = "Excel文档(*.xls)|*.xls|Excel文档(*.xlsx)|*.xlsx";
                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        ExportToExcel(saveFile.FileName, gv_Report.DataSource as DataTable);
                    }
                    break;
                default:
                    break;
            }
        }

        private void btn_Application_Click(object sender, EventArgs e)
        {
            if (splashScreenManager1.IsSplashFormVisible)
            {
                return;
            }
            if (isSearch)
                return;

            if (dateTxt_Begin.DateTime == DateTime.MinValue)
            {
                XtraMessageBox.Show("请选择开始时间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dateTxt_End.DateTime == DateTime.MinValue)
            {
                XtraMessageBox.Show("请选择结束时间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateTxt_Begin.DateTime.Ticks > dateTxt_End.DateTime.Ticks)
            {
                XtraMessageBox.Show("结束时间应大于等于开始时间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tsDateTxt_Interval.TimeSpan.Ticks <= 0)
            {
                XtraMessageBox.Show("请选择报表时间间隔", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (bindSourceReportConfig.DataSource == null)
            {
                XtraMessageBox.Show("请进行报表组态", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dateTxt_End.DateTime.Ticks < dateTxt_Begin.DateTime.Ticks)
            {
                XtraMessageBox.Show("结束时间不能小于开始时间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //计算最大列数 如果超过1000列 
            if ((dateTxt_End.DateTime.Ticks - dateTxt_Begin.DateTime.Ticks) / tsDateTxt_Interval.TimeSpan.Ticks > 1000)
            {
                XtraMessageBox.Show("报表时间太长或间隔过大", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            splashScreenManager1.ShowWaitForm();
            //整理数据
            List<ReportConfigEntity> listReportConfigEntity = bindSourceReportConfig.DataSource as List<ReportConfigEntity>;

            CreateFixedColumn();
            CreateDateColumn(dateTxt_Begin.DateTime, dateTxt_End.DateTime, tsDateTxt_Interval.TimeSpan);



            //装载数据


            new Thread(new ThreadStart(() =>
            {
                Console.WriteLine(DateTime.Now.ToString());
                string[] numbers = (from c in listReportConfigEntity select c.RCENumber).Distinct().ToArray();
                DateTime beginDate = dateTxt_Begin.DateTime;
                DateTime endDate = dateTxt_End.DateTime;
                TimeSpan intervalTimeSpan = tsDateTxt_Interval.TimeSpan;

                DateTime lastEndDate = endDate.AddDays(intervalTimeSpan.Days)
                    .AddHours(intervalTimeSpan.Hours)
                    .AddMinutes(intervalTimeSpan.Minutes)
                    .AddSeconds(intervalTimeSpan.Seconds);
                List<RTValue> lists = DOPDataLogic.Instance().GetRTValueBy(numbers, beginDate, lastEndDate);
                //List<RTValue> lists = new List<RTValue>(); /*调试用*/
                Console.WriteLine(DateTime.Now.ToString());
                isSearch = false;
                DataTable table = AnalyzeData(listReportConfigEntity, lists, intervalTimeSpan);
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        SetGridColumnFieldName();
                        gc_Report.DataSource = table;
                        gv_Report.RefreshData();
                        splashScreenManager1.CloseWaitForm();
                    }));
                }
            })).Start();

        }

        private void gv_ReportConfig_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {

        }

        private void gv_ReportConfig_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = ((DevExpress.XtraGrid.Views.Grid.GridView)sender).CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内  
                if (hInfo.InRow)
                {

                    ReportConfigEntity choseEntity = (bindSourceReportConfig.DataSource as List<ReportConfigEntity>)[hInfo.RowHandle];
                    bindSourceReportConfig.Remove(choseEntity);
                }
            }
        }
    }

    public class ReportConfigEntity
    {
        public string RCENumber { get { return Variable.Number; } }
        public string RCEName { get { return Variable.Name; } }
        public string RCEUnit { get { return Variable.Name; } }
        public Variable Variable { get; set; }

        /// <summary>
        /// 报表属性
        /// </summary>
        public ReportType ReportType { get; set; }

        public string ReportTypeName
        {
            get
            {
                string reportTypeName = string.Empty;
                if (this.Variable != null)
                {
                    reportTypeName = new ReportTypeHelper(this.Variable.VariableType == VariableType.DM).GetNameByValue(this.ReportType);
                }
                return reportTypeName;
            }
        }
    }

    public class ReportTypeHelper
    {
        //DM开关量 0,1
        Dictionary<string, ReportType> dic = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isDM">是否开关量</param>
        public ReportTypeHelper(bool isDM = false)
        {
            dic = new Dictionary<string, ReportType>();
            dic.Add("实时值", ReportType.Real);
            if (isDM)
            {
                dic.Add("0次数", ReportType.FalseCount);
                dic.Add("1次数", ReportType.TrueCount);
                dic.Add("跳变数", ReportType.Saltus);
            }
            else
            {
                dic.Add("最大值", ReportType.Max);
                dic.Add("最小值", ReportType.Min);
                dic.Add("累计值", ReportType.Total);
                dic.Add("平均值", ReportType.Average);
            }
        }

        public string GetNameByValue(ReportType rt)
        {
            foreach (var item in dic)
            {
                if (item.Value == rt)
                {
                    return item.Key;
                }
            }
            return string.Empty;
        }
        public ReportType GetValueByText(string txt)
        {
            KeyValuePair<string, ReportType> rt = dic.First(o => o.Key.Equals(txt.Trim()));
            return rt.Value;

        }
        public string[] GetNames()
        {
            return dic.Keys.ToArray();
        }
    }

    public enum ReportType
    {
        /// <summary>
        /// 最大值
        /// </summary>
        Max = 1,

        /// <summary>
        /// 最小值
        /// </summary>
        Min = 2,

        /// <summary>
        /// 实时值
        /// </summary>
        Real = 3,

        /// <summary>
        /// 累计值
        /// </summary>
        Total = 4,

        /// <summary>
        /// 平均值
        /// </summary>
        Average,
        /// <summary>
        /// 0次数
        /// </summary>
        FalseCount,

        /// <summary>
        /// 1次数
        /// </summary>
        TrueCount,

        /// <summary>
        /// 跳变数
        /// </summary>
        Saltus
    }

}

