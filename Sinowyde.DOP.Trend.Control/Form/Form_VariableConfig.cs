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
using Sinowyde.DOP.DataModel;
using System.Threading;
using Sinowyde.DOP.DataLogic;
using DevExpress.Utils.Menu;

namespace Sinowyde.DOP.Trend.Control
{
    public partial class Form_VariableConfig : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 是否加载完成
        /// </summary>
        private bool IsLoaded = false;

        /// <summary>
        /// 缓存变量列表
        /// </summary>
        private List<Variable> Variables;

        /// <summary>
        /// 中间数据
        /// </summary>
        private ChartData TempChartData;


        public Form_VariableConfig()
        {
            InitializeComponent();
            Variables = new List<Variable>();
            TempChartData = new ChartData();
            
        }

        private void SetValue(ChartData model)
        {
            if (model == null)
            {
                model = new ChartData();
            }
            txt_Color.Color = model.Color;
            txt_MaxValue.Value = (decimal)model.MaxValue;
            txt_MinValue.Value = (decimal)model.MinValue;
            popEdit_Variable.Text = model.Variable.Number;
            if (TempChartData.Variable == null || string.IsNullOrEmpty(TempChartData.Variable.Number))
            {
                btn_Save.Text = "新增";
                groupControl_Variable.Text = "新增变量";
                popEdit_Variable.Enabled = true;
            }
            else { btn_Save.Text = "修改"; groupControl_Variable.Text = "修改变量"; popEdit_Variable.Enabled = false; }
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void ReloadData()
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
                if (!cmb_Device.Text.Equals("全部"))
                {
                    dataSource = Variables.Where(o => o.Device.ID == cmb_Device.GetSelectItem<Device>().ID).ToList();
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
        private void LoadData()
        {
            new Thread(new ThreadStart(() =>
            {
                List<Device> devices = DOPDataLogic.Instance().GetAllBy<Device>();
                devices.Insert(0, new Device() { Name = "全部", ID = 0 });
                Variables = DOPDataLogic.Instance().GetAllBy<Variable>();

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        cmb_Device.SetDataSource<Device>(devices);
                        cmb_DirectionType.SelectedIndex = 0;
                        cmb_Device.SelectedIndex = 0;
                        IsLoaded = true;
                        popEdit_Variable.Text = "请选择变量";
                        popEdit_Variable.Enabled = true;
                        ReloadData();
                    }));
                }
            })).Start();
        }
        
        private void cmb_DirectionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void cmb_Device_SelectedIndexChanged(object sender, EventArgs e)
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

            ReloadData();
        }

        private void txt_Variable_TextChanged(object sender, EventArgs e)
        {
            ReloadData();
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
                    TempChartData.Variable = var;
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (TempChartData.Variable == null || string.IsNullOrEmpty(TempChartData.Variable.Number))
            {
                MessageBox.Show("请选择变量", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_MaxValue.Value <= txt_MinValue.Value)
            {
                MessageBox.Show("最大值应该大于最小值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_Color.Color == null)
            {
                MessageBox.Show("请选择颜色", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TempChartData.MaxValue = (double)txt_MaxValue.Value;
            TempChartData.MinValue = (double)txt_MinValue.Value;
            TempChartData.Color = txt_Color.Color;
            TempChartData.LineType = cmb_LineType.Text.Trim();
            ((UserCtrlRtTrend)this.Parent).UpdateCacheVariabel(TempChartData);
            TempChartData = new ChartData();
            SetValue(TempChartData);
        }

        public void ChangeData(List<ChartData> list)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    gc_RTValue.DataSource = list;
                    gv_RtValue.RefreshData();
                }));
            }
            else 
            {
                gc_RTValue.DataSource = list;
                gv_RtValue.RefreshData();
            }
        }

        private void Form_VariableConfig_Load(object sender, EventArgs e)
        {
            cmb_DirectionType.Properties.Items.AddRange(new string[] { "全部", "读取", "写入", "计算", "临时" });
            popEdit_Variable.Text = "正在加载...";
            popEdit_Variable.Enabled = false;
            LoadData();

        }

        private void gv_RtValue_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            //if (e.Column.Name.Equals("column_CurrentValue"))
            //{
            //    var chartData = (((List<ChartData>)gv_RtValue.DataSource)[e.ListSourceRowIndex]);
            //    if (chartData.RTValues.Count > 0)
            //    {
            //        e.DisplayText = (((List<ChartData>)gv_RtValue.DataSource)[e.ListSourceRowIndex]).RTValues.Last().Value.ToString();
            //    }
            //}
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            TempChartData = new ChartData();
            SetValue(TempChartData);
        }

        private void gv_RtValue_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
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

        private void gv_RtValue_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = ((DevExpress.XtraGrid.Views.Grid.GridView)sender).CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内  
                if (hInfo.InRow)
                {
                    TempChartData = ((List<ChartData>)gv_RtValue.DataSource)[hInfo.RowHandle];
                    SetValue(TempChartData);
                }
            }
        }

        private void Form_VariableConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                
            }
            catch (Exception)
            {

            }
           
        }

        private void gv_RtValue_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            {
                e.Menu.Items.Clear();
                return;
            }

            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                if (e.HitInfo.InRowCell)
                {
                    int index = gv_RtValue.GetDataSourceRowIndex(e.HitInfo.RowHandle);
                    ChartData model = ((List<ChartData>)gv_RtValue.DataSource)[index];
                    e.Menu.Items.Add(new DXMenuItem("删 除", delegate(object obj, EventArgs es)
                    {
                        if (MessageBox.Show(string.Format("是否删除{0}",model.Variable.Number), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            ((UserCtrlRtTrend)this.Parent).DeleteCacheVariabel(model.Variable.Number);
                        }
                    }));
                }
            }
        }
    }
}