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

/* 变量配置窗体
 * 需要 父窗体的List<ChartData> 数据集
 * 
 * */

namespace Sinowyde.DOP.Trend.Control
{
    public partial class Form_Variable : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// cData发生变化
        /// </summary>
        /// <param name="cData">发生变化的实体</param>
        /// <param name="dState">状态</param>
        public delegate void DataChange(ChartData cData,DataState dState);

        /// <summary>
        /// 缓存数据发生变化 事件通知
        /// </summary>
        public event DataChange DataChangeEvent;


        public Form_Variable(List<ChartData> dataSource)
        {
            InitializeComponent();
            this.ChartDatas = dataSource ?? new List<ChartData>();
            this.CurrentChartData = new ChartData();
            IsAdd = true;
        }

        /// <summary>
        /// 是否加载完成
        /// </summary>
        private bool IsLoaded = false;

        /// <summary>
        /// 缓存变量列表
        /// </summary>
        private List<Variable> Variables;

        /// <summary>
        /// 当前变量集合
        /// </summary>
        private List<ChartData> ChartDatas { get; set; }

        private ChartData CurrentChartData;

        private bool IsAdd = true;

        private void Clear()
        {
            CurrentChartData = new ChartData();
            SetValue(CurrentChartData);
            IsAdd = true;
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
                //bindingSource_ChartData.DataSource = dataSource;
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
            if (string.IsNullOrEmpty(model.Variable.Number))
            {
                btn_Save.Text = "新增";
                groupControl_Variable.Text = "新增变量";
                popEdit_Variable.Enabled = true;
                
            }
            else { 
                btn_Save.Text = "修改"; 
                groupControl_Variable.Text = "修改变量"; 
                popEdit_Variable.Tag = model.Variable; 
                popEdit_Variable.Enabled = false; 
            }
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
                    popEdit_Variable.Tag = var;
                }
            }
        }

        private void Form_Variable_Load(object sender, EventArgs e)
        {
            bindingSource_ChartData.DataSource = ChartDatas;
            cmb_DirectionType.Properties.Items.AddRange(new string[] { "全部", "读取", "写入", "计算", "临时" });
            popEdit_Variable.Text = "正在加载...";
            LoadData();
        }

        /// <summary>
        /// 编辑 || 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (popEdit_Variable.Tag == null || string.IsNullOrEmpty((popEdit_Variable.Tag as Variable).Number))
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

            if (IsAdd)
            {
                //新增
                if (ChartDatas.Count > ChartConfig.MaxVariableCount)
                {
                    XtraMessageBox.Show(string.Format("曲线最多只能有{0}条",ChartConfig.MaxVariableCount), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Variable current = popEdit_Variable.Tag as Variable;
                if ((bindingSource_ChartData.DataSource as List<ChartData>).Where(o => o.Variable.Number.Equals(current.Number)).Count() > 0)
                {
                    XtraMessageBox.Show(string.Format("{0}已存在",current.Number), "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CurrentChartData.MaxValue = (double)txt_MaxValue.Value;
                CurrentChartData.MinValue = (double)txt_MinValue.Value;
                CurrentChartData.Color = txt_Color.Color;
                CurrentChartData.LineType = cmb_LineType.Text.Trim();
                CurrentChartData.Variable = popEdit_Variable.Tag as Variable;
                ChartDatas.Add(CurrentChartData);
                DataChangeEvent(CurrentChartData, DataState.Add);
            }
            else
            {
                //修改
                ChartData choseModel = ChartDatas.Find(o => o.Variable.Number == CurrentChartData.Variable.Number);
                choseModel.MaxValue = (double)txt_MaxValue.Value;
                choseModel.MinValue = (double)txt_MinValue.Value;
                choseModel.Color = txt_Color.Color;
                choseModel.LineType = cmb_LineType.Text.Trim();
                DataChangeEvent(choseModel, DataState.Modify);
            }
            gv_RtValue.RefreshData();
            Clear();
        }

        private void Form_Variable_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void gv_RtValue_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = ((DevExpress.XtraGrid.Views.Grid.GridView)sender).CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内  
                if (hInfo.InRow)
                {
                    CurrentChartData = (((gv_RtValue.DataSource as BindingSource).DataSource) as List<ChartData>)[hInfo.RowHandle];
                    
                    SetValue(CurrentChartData);
                    IsAdd = false;
                }
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void gv_RtValue_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            {
                e.Menu.Items.Clear();
                return;
            }

            if (e.Menu == null)
            {
                e.Menu = new DevExpress.XtraGrid.Menu.GridViewMenu((DevExpress.XtraGrid.Views.Grid.GridView)sender);
            }

            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                if (e.HitInfo.InRowCell)
                {
                    int index = gv_RtValue.GetDataSourceRowIndex(e.HitInfo.RowHandle);
                    ChartData model = ((List<ChartData>)bindingSource_ChartData.DataSource)[index];
                    e.Menu.Items.Add(new DXMenuItem("删除",delegate(object obj, EventArgs es){
                        if (DataChangeEvent != null)
                        {
                            DataChangeEvent(model, DataState.Delete);
                        }
                        gv_RtValue.RefreshData();
                    }));
                }
            }
        }
    }
}