using DevExpress.XtraEditors;
using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataModel;
using Sinowyde.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;

namespace Sinowyde.DOP.PIDBlock.UserCtrl
{
    public partial class CtrlVariable : DevExpress.XtraEditors.XtraUserControl
    {

        public CtrlVariable()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当前选中的变量
        /// </summary>
        public Variable CurrentVariable { get; private set; }
        private VariableType defaultVariabelType = VariableType.AM;
        /// <summary>
        /// 这个可能替换掉
        /// </summary>
        private VarDirectionType defaultVarDirectionType = VarDirectionType.Read;
        /// <summary>
        /// 多个筛选选项
        /// </summary>
        private List<VarDirectionType> varDirectionList = new List<VarDirectionType>() { VarDirectionType.Read, VarDirectionType.Calc, VarDirectionType.Temp };

        public List<VarDirectionType> VarDirectionList
        {
            get { return varDirectionList; }
            set { varDirectionList = value; }
        }

        private string variableNumber;

        /// <summary>
        /// 点名
        /// </summary>
        public string VariableNumber
        {
            get { return this.variableNumber; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    variableNumber = value;
                    labelControl1.Text = "您上次选择的变量是:" + value;
                }
            }
        }

        private List<Variable> Variables = new List<Variable>();
        private List<Device> Devices = new List<Device>();

        /// <summary>
        /// 变量类型
        /// </summary>
        [Browsable(true), Description("变量类型"), DefaultValue(typeof(VariableType), "AM")]
        public VariableType DefaultVariabelType
        {
            get { return defaultVariabelType; }
            set { defaultVariabelType = value; }
        }

        /// <summary>
        /// 变量采集方式
        /// </summary>
        [Browsable(true), Description("变量采集方式"), DefaultValue(typeof(VarDirectionType), "Read")]
        public VarDirectionType DefaultVarDirectionType
        {
            get { return defaultVarDirectionType; }
            set { defaultVarDirectionType = value; }
        }

        [Obsolete("属性已停用")]
        [Browsable(true), Description("是否计算变量"), DefaultValue(false)]
        public bool IsCalcVariable
        {
            get;
            set;
        }

        private void CtrlPointPicker_Load(object sender, EventArgs e)
        {
            gc_Variables.DataSource = null;
            ResizePanel();
        }

        private DateTime ModelTimestamp = DateTime.MinValue;

        #region 事件

        /// <summary>
        /// combox index 改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            gc_Variables.DataSource = Find();
        }

        /// <summary>
        /// 屏蔽 gridview header 右键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_Variabels_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            {
                e.Menu.Items.Clear();
                return;
            }
        }

        /// <summary>
        /// 按键释放 操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVariableName_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            gc_Variables.DataSource = Find();
        }

        /// <summary>
        /// gridview row 单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_Variabels_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            CurrentVariable = ((List<Variable>)gv_Variabels.DataSource)[gv_Variabels.FocusedRowHandle];
        }

        #endregion

        #region Custom method

        /// <summary>
        /// 根据Combox 和 txt 查找 variable
        /// </summary>
        /// <returns></returns>
        private List<Variable> Find()
        {
            var list = Variables.Where(o => o.Name.ToLower().IndexOf(txtVariableName.Text.Trim().ToLower()) > -1); //.OrderBy(o => o.Number).ThenBy(o => o.DeviceID).ThenBy(o => o.DirectionType).ToList();
            if (!cmbDevices.Text.Trim().Equals("所有"))
            {
                list = list.Where(o => o.Device.ID.Equals(cmbDevices.GetComboxData<Device>().ID));
            }
            CurrentVariable = new Variable();
            if (list.Count() > 0)
            {
                CurrentVariable = list.FirstOrDefault();
            }
            return list.ToList();
        }

        /// <summary>
        /// 重新布局Panel
        /// </summary>
        private void ResizePanel()
        {
            panel_Top.Location = new System.Drawing.Point(0, 0);
            panel_Top.Size = new System.Drawing.Size(this.Width, 24);

            panel_Bottom.Location = new System.Drawing.Point(0, panel_Top.Height + 2);
            panel_Bottom.Size = new System.Drawing.Size(this.Width, this.Height - panel_Top.Height - 2);
        }

        #endregion

        //Ai: 模拟量 Read calc temp
        //Di  开关量 Read calc temp
        //dset 开关量 Read calc temp
        //dset 模拟量 Read calc temp

        //Am  模拟量 calc temp
        //Dm  开关量 calc temp
        //Do  开关量 write
        //Ao  模拟量 write
        //zza add  需求AI/DI应该不能连接写入点;DO/AO应该不能连接读取点  varDirectionType,要过滤掉不需要的类型
        public void RefreshData()
        {
            DateTime version = DOPDataLogic.Instance().GetModelVersion(Sinowyde.DataModel.ModelType.Communication);
            if (ModelTimestamp != version)
            {
                lbl_loading.Location = new System.Drawing.Point((panel_Bottom.Width - lbl_loading.Width) / 2, (panel_Bottom.Height - lbl_loading.Height) / 2);
                panel_Bottom.Controls.Add(lbl_loading);
                lbl_loading.Visible = true;
                lbl_loading.BringToFront();
                lbl_loading.BackColor = System.Drawing.Color.Transparent;
                try
                {
                    Thread thread = new Thread(new ThreadStart(() =>
                    {
                        Variables = DOPDataLogic.Instance().GetAllBy<Variable>();
                        Devices = DOPDataLogic.Instance().GetAllBy<Device>();

                        if (this.InvokeRequired)
                        {
                            this.Invoke(new Action(() =>
                            {
                                if (DefaultVariabelType == 0)
                                {
                                    DefaultVariabelType = VariableType.AM;
                                }
                                Variables = Variables.Where(o => o.VariableType.Equals(DefaultVariabelType) && VarDirectionList.Contains(o.DirectionType)).ToList();
                                //Variables = Variables.Where(o => o.VariableType.Equals(DefaultVariabelType)).ToList();
                                Devices.Insert(0, new Device() { Name = "所有" });
                                cmbDevices.Properties.Items.Clear();
                                cmbDevices.SetComboxDataSource<Device>(Devices);
                                cmbDevices.SelectedIndex = 0;
                                gc_Variables.DataSource = Find();
                                if (!string.IsNullOrEmpty(variableNumber))
                                {
                                    CurrentVariable = Variables.Find(o => o.Number.Trim().Equals(VariableNumber.Trim()));
                                    int index = gv_Variabels.FindRow(CurrentVariable);
                                    gv_Variabels.FocusedRowHandle = index;
                                }
                                lbl_loading.Visible = false;
                            }));
                        }
                    }));
                    thread.IsBackground = true;
                    thread.Start();
                }
                catch (Exception ex)
                {
                    LogUtil.LogFatal("读取变量出错", ex);
                }

                this.ModelTimestamp = version;
            }
        }
        private void gv_Variabels_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "column_DirectionType")
            {
                e.DisplayText = new VarDirectionTypeHelper().GetKeyByValue((VarDirectionType)e.Value);
            }
        }

        private void CtrlVariable_VisibleChanged(object sender, EventArgs e)
        {

        }
    }

    public static class ComboBoxEditEx
    {
        /// <summary>
        /// 设置ComboxEdit的数据源
        /// 缺点：T 的 Name 属性不能重复
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmb"></param>
        /// <param name="list"></param>
        public static void SetComboxDataSource<T>(this ComboBoxEdit cmb, List<T> list)
        {
            System.Reflection.PropertyInfo propertyInfo = typeof(T).GetProperty("Name");
            if (propertyInfo != null)
            {
                foreach (T item in list)
                {
                    cmb.Properties.Items.Add(propertyInfo.GetValue(item, null).ToString());
                }
                cmb.Tag = list;
            }
        }

        public static T GetComboxData<T>(this ComboBoxEdit cmb)
        {
            List<T> list = cmb.Tag as List<T>;
            if (list != null)
            {
                foreach (T item in list)
                {
                    if (typeof(T).GetProperty("Name").GetValue(item, null).ToString() == cmb.Text.Trim())
                    {
                        return item;
                    }
                }
            }
            return default(T);
        }
    }
}
