using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Sinowyde.DOP.DataLogic;
using DevExpress.XtraTreeList;
using DevExpress.Utils.Menu;
using DevExpress.XtraTreeList.Nodes;
using System.ComponentModel.Composition;
using DevExpress.XtraEditors.Controls;
using Sinowyde.DOP.UI;
using PopupMenuShowingEventArgs = DevExpress.XtraTreeList.PopupMenuShowingEventArgs;

//using Sinowyde.DOP.UI;

namespace Sinowyde.DOP.DataModel.Control
{
    [Export(typeof(IToolUc))]
    [ExportUcMetaData("数据模型软件")]
    public partial class UserControlDataModel : DevExpress.XtraEditors.XtraUserControl, IToolUc
    {
        public LoadingControl loadingControl = null;

        public enum FormState
        {
            Add = 0,
            Update,
            Delete,
            Clear
        }

        public UserControlDataModel()
        {
            InitializeComponent();
        }

        private void UserControlDataModel_Load(object sender, EventArgs e)
        {
            //Localizer.Active = new CHLocalizer();
            loadingControl = new LoadingControl();

            int x = (this.Width - loadingControl.Width) / 2;
            int y = (this.Height - loadingControl.Height) / 2;
            loadingControl.Location = new Point(x, y);
            loadingControl.BringToFront();
            loadingControl.Visible = false;
            this.Controls.Add(loadingControl);
            LoadTree();


            this.gv_IOServer.RowClick += gv_RowClick;
            this.gv_IOChannel.RowClick += gv_RowClick;
            this.gv_IOUnit.RowClick += gv_RowClick;
            this.gv_Variable.RowClick += gv_RowClick;
        }

        private void gv_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var gridView = sender as GridView;
            if (null == gridView || e.Button != MouseButtons.Left || e.Clicks != 2)
                return;

            var id = gridView.GetRowCellValue(e.RowHandle, "ID");
            switch (gridView.Name)
            {
                case "gv_IOServer":
                    var iOServerList = gridControl_Right.DataSource as List<IOServer>;
                    if (null != iOServerList)
                        ShowIOServer(FormState.Update, iOServerList.FirstOrDefault(v => v.ID.Equals(id)));
                    break;
                case "gv_IOChannel":
                    var iOChannelList = gridControl_Right.DataSource as List<IOChannel>;
                    if (null != iOChannelList)
                        ShowIOChannel(FormState.Update, iOChannelList.FirstOrDefault(v => v.ID.Equals(id)));
                    break;
                case "gv_IOUnit":
                    var iOUnitList = gridControl_Right.DataSource as List<IOUnit>;
                    if (null != iOUnitList)
                        ShowIOUnit(FormState.Update, iOUnitList.FirstOrDefault(v => v.ID.Equals(id)));
                    break;
                case "gv_Variable":
                    var variableList = gridControl_Right.DataSource as List<Variable>;
                    if (null != variableList)
                        ShowVariable(FormState.Update, variableList.FirstOrDefault(v => v.ID.Equals(id)));
                    break;

            }
        }

        #region  Custon Method

        private void LoadTree()
        {
            List<IOServer> ioservers = DOPDataLogic.Instance().GetAllBy<IOServer>();
            List<IOChannel> iochannels = DOPDataLogic.Instance().GetAllBy<IOChannel>();
            List<IOUnit> iounits = DOPDataLogic.Instance().GetAllBy<IOUnit>();
            treeList_Left.Nodes.Clear();
            TreeData Root = new TreeData();
            Root.Caption = "通讯模型";
            Root.ID = 1;
            Root.ParentID = 0;
            Root.TreeDataType = TreeData.NodeType.Root;

            int id = 1;
            List<TreeData> treeList = new List<TreeData>();
            treeList.Add(Root);
            id++;
            treeList.Add(new TreeData() { ID = id, ParentID = 0, Caption = "计算变量", TreeDataType = TreeData.NodeType.CalcVariable, Entity = new Variable() { DirectionType = VarDirectionType.Calc } });
            id++;
            treeList.Add(new TreeData() { ID = id, ParentID = 0, Caption = "中间变量", TreeDataType = TreeData.NodeType.TempVariabel, Entity = new Variable() { DirectionType = VarDirectionType.Temp } });



            #region 装载tree数据
            foreach (IOServer item in ioservers)
            {
                id++;
                TreeData model = new TreeData();
                model.ID = id;
                model.Caption = item.Name;
                model.ParentID = 1;
                model.Entity = item;
                model.TreeDataType = TreeData.NodeType.IOServer;
                treeList.Add(model);
            }


            foreach (IOChannel item in iochannels)
            {
                var servers = treeList.Where(o => o.TreeDataType.Equals(TreeData.NodeType.IOServer));
                int parentID = servers.Where(o => ((IOServer)o.Entity).ID.Equals(item.IOServerID)).FirstOrDefault().ID;
                id++;
                TreeData model = new TreeData();
                model.ID = id;
                model.Caption = item.Name;
                model.ParentID = parentID;
                model.Entity = item;
                model.TreeDataType = TreeData.NodeType.IOChannel;
                treeList.Add(model);
            }

            foreach (IOUnit item in iounits)
            {
                var channels = treeList.Where(o => o.TreeDataType.Equals(TreeData.NodeType.IOChannel));
                int parentID = channels.Where(o => ((IOChannel)o.Entity).ID.Equals(item.ChannelID)).FirstOrDefault().ID;
                id++;
                TreeData model = new TreeData();
                model.ID = id;
                model.Caption = item.Name;
                model.ParentID = parentID;
                model.Entity = item;
                model.TreeDataType = TreeData.NodeType.IOUnit;
                treeList.Add(model);
                id++;

                TreeData inputVariable = new TreeData();
                inputVariable.ID = id;
                inputVariable.Caption = "输入";
                inputVariable.ParentID = model.ID;
                inputVariable.Entity = new Variable() { IOUnit = item, DirectionType = Sinowyde.DOP.DataModel.VarDirectionType.Read };
                inputVariable.TreeDataType = TreeData.NodeType.VarDirection;
                treeList.Add(inputVariable);
                id++;

                TreeData outVariable = new TreeData();
                outVariable.ID = id;
                outVariable.Caption = "输出";
                outVariable.ParentID = model.ID;
                outVariable.Entity = new Variable() { IOUnit = item, DirectionType = Sinowyde.DOP.DataModel.VarDirectionType.Write };
                outVariable.TreeDataType = TreeData.NodeType.VarDirection;
                treeList.Add(outVariable);
            }
            #endregion
            //treeList.Insert(0, new TreeData() { ID = 0, ParentID = 0, Caption = "模型通道", TreeDataType = TreeData.NodeType.Root });
            treeList_Left.DataSource = treeList;
            treeList_Left.ExpandToLevel(0);
        }

        /// <summary>
        /// 导入导出 的 提示信息
        /// </summary>
        /// <param name="explain"></param>
        /// <param name="isOver"></param>
        private void loadTip(string explain, bool isOver = false)
        {
            if (loadingControl.InvokeRequired)
            {
                Action action = () =>
                {
                    loadingControl.Visible = !isOver;
                    loadingControl.Content = explain;
                };
                loadingControl.Invoke(action);
            }
            else
            {
                loadingControl.Visible = !isOver;
                loadingControl.Content = explain;
            }

        }

        private void BindView<T>(List<T> list)
        {
            gridControl_Right.DataSource = list;
            if (typeof(T) == typeof(IOChannel))
            {
                gridControl_Right.MainView = gv_IOChannel;
            }
            else if (typeof(T) == typeof(Variable))
            {
                gridControl_Right.MainView = gv_Variable;
            }
            else if (typeof(T) == typeof(IOUnit))
            {
                gridControl_Right.MainView = gv_IOUnit;
            }
            else if (typeof(T) == typeof(IOServer))
            {
                gridControl_Right.MainView = gv_IOServer;
            }
        }

        /// <summary>
        /// 刷新树
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isReloadParentNode"></param>
        private void RefreshTree(TreeListNode node)
        {

            LoadTree();
            List<TreeListNode> list = treeList_Left.GetNodeList();
            foreach (TreeListNode item in list)
            {
                TreeData data = (TreeData)treeList_Left.GetDataRecordByNode(item);
                TreeData now = (TreeData)treeList_Left.GetDataRecordByNode(node);
                if (data.Entity == now.Entity)
                {
                    item.Selected = true;
                }
            }
            //node.Selected = true;
        }

        private T GetDataRecordByNode<T>()
        {
            TreeData obj = treeList_Left.GetDataRecordByNode(treeList_Left.FocusedNode) as TreeData;
            return (T)obj.Entity;
        }

        public void ShowIOChannel(FormState state, IOChannel model = null)
        {
            var node = ((TreeData)treeList_Left.GetDataRecordByNode(treeList_Left.FocusedNode)).Entity;

            switch (state)
            {
                case FormState.Delete:
                    if (DialogResult.Yes == MessageBox.Show(string.Format("是否删除 {0} ?", model.Name), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        DOPDataLogic.Instance().Delete<IOChannel>(model.ID);
                        RefreshTree(treeList_Left.FocusedNode);
                    }
                    break;
                case FormState.Clear:

                    if (DialogResult.Yes == MessageBox.Show(string.Format("是否清空{0}下IO通道?", ((IOServer)node).Name), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        DOPDataLogic.Instance().Delete(string.Format("DELETE FROM IOChannel where IOServerID = {0}", ((IOServer)node).ID));
                        RefreshTree(treeList_Left.FocusedNode);
                    }
                    break;
                default:
                    if (model == null)
                    {
                        model = new IOChannel() { IOServer = (IOServer)node };
                    }
                    Form_IOChannel form = new Form_IOChannel(model);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        RefreshTree(treeList_Left.FocusedNode);
                    }
                    break;
            }

        }

        public void ShowIOServer(FormState state, IOServer model = null)
        {
            switch (state)
            {
                case FormState.Delete:
                    if (DialogResult.Yes == MessageBox.Show(string.Format("是否删除 {0} ?", model.Name), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        DOPDataLogic.Instance().Delete<IOServer>(model.ID);
                        LoadTree();
                    }
                    break;
                case FormState.Clear:
                    if (DialogResult.Yes == MessageBox.Show("是否清空所有IOServer?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        DOPDataLogic.Instance().Delete("DELETE FROM IOServer");
                        LoadTree();
                    }
                    break;
                default:
                    if (model == null)
                    {
                        model = new IOServer();
                    }
                    From_IOServer form = new From_IOServer(model);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadTree();
                    }
                    break;
            }

        }

        public void ShowIOUnit(FormState state, IOUnit model = null)
        {
            var node = ((TreeData)treeList_Left.GetDataRecordByNode(treeList_Left.FocusedNode)).Entity;

            switch (state)
            {
                case FormState.Delete:
                    if (DialogResult.Yes == MessageBox.Show(string.Format("是否删除 {0} ?", model.Name), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        DOPDataLogic.Instance().Delete<IOUnit>(model.ID);
                        IList<IOUnit> list = DOPDataLogic.Instance().GetIOUnitByChannelID(model.Channel.ID);

                        RefreshTree(treeList_Left.FocusedNode.ParentNode);
                    }
                    break;
                case FormState.Clear:
                    if (DialogResult.Yes == MessageBox.Show("是否清空所有IO单元?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        string sql = string.Format("DELETE FROM IOUnit WHERE ChannelID = {0}", GetDataRecordByNode<IOChannel>().ID);
                        DOPDataLogic.Instance().Delete(sql);
                        RefreshTree(treeList_Left.FocusedNode);
                    }
                    break;
                default:
                    if (model == null)
                    {
                        model = new IOUnit() { Channel = (IOChannel)node };
                    }
                    Form_IOUnit form = new Form_IOUnit(model);
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        long nodeId = state == FormState.Add ? Sinowyde.Util.ConvertUtil.ConvertToLong(treeList_Left.Tag) : model.Channel.ID;
                        RefreshTree(treeList_Left.FocusedNode);
                    }
                    break;
            }
        }

        public void ShowVariable(FormState state, Variable model = null)
        {
            var node = ((TreeData)treeList_Left.GetDataRecordByNode(treeList_Left.FocusedNode));//.Entity;
            var entity = ((TreeData)node).Entity;
            switch (state)
            {
                case FormState.Delete:
                    if (DialogResult.Yes == MessageBox.Show(string.Format("是否删除 {0} ?", model.Name), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        DOPDataLogic.Instance().Delete<Variable>(model.ID);
                        BindView<Variable>(DOPDataLogic.Instance().GetByIOUnitID(model.IOUnit.ID));
                        RefreshTree(treeList_Left.FocusedNode);
                    }
                    break;
                case FormState.Clear:
                    if (node.TreeDataType == TreeData.NodeType.TempVariabel)
                    {
                        if (DialogResult.Yes == MessageBox.Show(string.Format("是否清空所有中间变量"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            string sql = string.Format("DELETE FROM variable WHERE DirectionType = {0}", (int)VarDirectionType.Temp);

                            DOPDataLogic.Instance().Delete(sql);
                            RefreshTree(treeList_Left.FocusedNode);
                        }
                    }
                    else if (node.TreeDataType == TreeData.NodeType.CalcVariable)
                    {
                        if (DialogResult.Yes == MessageBox.Show(string.Format("是否清空所有计算变量"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            string sql = string.Format("DELETE FROM variable WHERE DirectionType = {0}", (int)VarDirectionType.Calc);

                            DOPDataLogic.Instance().Delete(sql);
                            RefreshTree(treeList_Left.FocusedNode);
                        }
                    }
                    else
                    {
                        long id = 0;
                        if (entity is IOUnit) { id = ((IOUnit)entity).ID; }
                        else if (entity is Variable) { id = ((Variable)entity).IOUnit.ID; }
                        IOUnit iounit = DOPDataLogic.Instance().Get<IOUnit>(id);
                        if (DialogResult.Yes == MessageBox.Show(string.Format("是否清空{0}下所有变量?", iounit.Name), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            string sql = string.Format("DELETE FROM variable WHERE IOUnitID = {0}", id);
                            DOPDataLogic.Instance().Delete(sql);
                            RefreshTree(treeList_Left.FocusedNode);
                        }
                    }
                    break;
                default:
                    if (model == null)
                    {
                        model = new Variable();
                        if (entity is IOUnit) { model.IOUnit = (IOUnit)entity; }
                        else if (entity is Variable) { model.IOUnit = ((Variable)entity).IOUnit; model.DirectionType = ((Variable)entity).DirectionType; }

                    }
                    if (node.TreeDataType == TreeData.NodeType.TempVariabel || node.TreeDataType == TreeData.NodeType.CalcVariable)
                    {
                        model.DirectionType = node.TreeDataType == TreeData.NodeType.TempVariabel ? VarDirectionType.Temp : VarDirectionType.Calc;
                        Form_CalcVariabel form = new Form_CalcVariabel(model);
                        if (DialogResult.OK == form.ShowDialog())
                        {
                            RefreshTree(treeList_Left.FocusedNode);
                        }
                    }
                    else
                    {
                        var flag = node is IOUnit;//采集类型
                        Form_Variable form = new Form_Variable(model, flag);
                        if (DialogResult.OK == form.ShowDialog())
                        {
                            RefreshTree(treeList_Left.FocusedNode);
                        }
                    }
                    break;
            }
        }

        #endregion

        #region TreeView Event
        /// <summary>
        /// 选中tree节点 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList_Left_AfterFocusNode(object sender, NodeEventArgs e)
        {
            TreeData data = ((sender as TreeList).GetDataRecordByNode(e.Node)) as TreeData;
            switch (data.TreeDataType)
            {
                case TreeData.NodeType.Root:
                    List<IOServer> ioservers = DOPDataLogic.Instance().GetAllBy<IOServer>();
                    BindView<IOServer>(ioservers);
                    break;
                case TreeData.NodeType.IOServer:
                    List<IOChannel> iochannels = DOPDataLogic.Instance().GetIOChannelByServerID(((IOServer)data.Entity).ID);
                    BindView<IOChannel>(iochannels);
                    break;
                case TreeData.NodeType.IOChannel:
                    List<IOUnit> iounits = DOPDataLogic.Instance().GetIOUnitByChannelID(((IOChannel)data.Entity).ID);
                    BindView<IOUnit>(iounits);
                    break;
                case TreeData.NodeType.IOUnit:
                    List<Variable> lists = DOPDataLogic.Instance().GetReadWriteVaribale(((IOUnit)data.Entity).ID);
                    BindView<Variable>(lists);
                    break;
                case TreeData.NodeType.VarDirection:
                    Variable var = data.Entity as Variable;
                    List<Variable> vs = DOPDataLogic.Instance().GetReadWriteVaribale(var.IOUnit.ID, var.DirectionType);
                    BindView<Variable>(vs);
                    break;
                case TreeData.NodeType.CalcVariable:
                    List<Variable> calcVar = DOPDataLogic.Instance().GetCalcVariabel();
                    BindView<Variable>(calcVar);
                    break;
                case TreeData.NodeType.TempVariabel:
                    List<Variable> tempVar = DOPDataLogic.Instance().GetTempVariabel();
                    BindView<Variable>(tempVar);
                    break;
                default:
                    List<IOChannel> defaultIOChannels = DOPDataLogic.Instance().GetAllBy<IOChannel>();
                    BindView<IOChannel>(defaultIOChannels);
                    break;
            }
        }
        /// <summary>
        /// 自定义 treelist 右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeList_Left_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu.MenuType == DevExpress.XtraTreeList.Menu.TreeListMenuType.Node)
            {
                TreeListHitInfo hitInfo = ((TreeList)sender).CalcHitInfo(e.Point);
                if (hitInfo.Node.Selected)
                {
                    TreeData data = (TreeData)(sender as TreeList).GetDataRecordByNode(hitInfo.Node);
                    object entity = data.Entity;
                    if (data.TreeDataType == TreeData.NodeType.Root)
                    {
                        //level 1 node

                        e.Menu.Items.Add(new DXMenuItem("添加IOServer", delegate(object obj, EventArgs es) { ShowIOServer(FormState.Add); }));
                        e.Menu.Items.Add(new DXMenuItem("清空IOServer", delegate(object obj, EventArgs es) { ShowIOServer(FormState.Clear); }));
                        e.Menu.Items.Add(new DXMenuItem("刷新", delegate(object obj, EventArgs es) { LoadTree(); }));
                    }
                    else if (data.TreeDataType == TreeData.NodeType.CalcVariable)
                    {
                        e.Menu.Items.Add(new DXMenuItem("添加计算变量", delegate(object obj, EventArgs es) { ShowVariable(FormState.Add); }));
                        e.Menu.Items.Add(new DXMenuItem("清空计算变量", delegate(object obj, EventArgs es) { ShowVariable(FormState.Clear); }));

                    }
                    else if (data.TreeDataType == TreeData.NodeType.TempVariabel)
                    {
                        e.Menu.Items.Add(new DXMenuItem("添加中间变量", delegate(object obj, EventArgs es) { ShowVariable(FormState.Add); }));
                        e.Menu.Items.Add(new DXMenuItem("清空中间变量", delegate(object obj, EventArgs es) { ShowVariable(FormState.Clear); }));
                    }
                    else if (data.TreeDataType == TreeData.NodeType.IOServer)
                    {
                        //level 1 node
                        IOServer model = DOPDataLogic.Instance().Get<IOServer>(((IOServer)entity).ID);
                        e.Menu.Items.Add(new DXMenuItem("编辑IOServer", delegate(object obj, EventArgs es) { ShowIOServer(FormState.Update, model); }));
                        e.Menu.Items.Add(new DXMenuItem("删除IOServer", delegate(object obj, EventArgs es) { ShowIOServer(FormState.Delete, model); }));
                        e.Menu.Items.Add(new DXMenuItem("添加IO通道", delegate(object obj, EventArgs es) { ShowIOChannel(FormState.Add); }));
                        e.Menu.Items.Add(new DXMenuItem("清空IO通道", delegate(object obj, EventArgs es) { ShowIOChannel(FormState.Clear); }));
                    }
                    else if (data.TreeDataType == TreeData.NodeType.IOChannel)
                    {
                        //level 2 node
                        #region
                        IOChannel model = DOPDataLogic.Instance().Get<IOChannel>(((IOChannel)entity).ID);
                        e.Menu.Items.Add(new DXMenuItem("编辑IO通道", delegate(object obj, EventArgs es) { ShowIOChannel(FormState.Update, model); }));
                        e.Menu.Items.Add(new DXMenuItem("删除IO通道", delegate(object obj, EventArgs es) { ShowIOChannel(FormState.Delete, model); }));
                        e.Menu.Items.Add(new DXMenuItem("添加IO单元", delegate(object obj, EventArgs es) { ShowIOUnit(FormState.Add, new IOUnit() { Channel = model }); }));
                        e.Menu.Items.Add(new DXMenuItem("清空IO单元", delegate(object obj, EventArgs es) { ShowIOUnit(FormState.Clear); }));
                        #endregion
                    }
                    else if (data.TreeDataType == TreeData.NodeType.IOUnit)
                    {
                        #region
                        IOUnit model = DOPDataLogic.Instance().Get<IOUnit>(((IOUnit)entity).ID);
                        e.Menu.Items.Add(new DXMenuItem("编辑IO单元", delegate(object obj, EventArgs es) { ShowIOUnit(FormState.Update, model); }));
                        e.Menu.Items.Add(new DXMenuItem("删除IO单元", delegate(object obj, EventArgs es) { ShowIOUnit(FormState.Delete, model); }));
                        e.Menu.Items.Add(new DXMenuItem("添加变量", delegate(object obj, EventArgs es)
                        { ShowVariable(FormState.Add); }));
                        e.Menu.Items.Add(new DXMenuItem("清空变量", delegate(object obj, EventArgs es)
                        { ShowVariable(FormState.Clear); }));
                        #endregion
                    }
                    else if (data.TreeDataType == TreeData.NodeType.VarDirection)
                    {
                        #region
                        IOUnit model = DOPDataLogic.Instance().Get<IOUnit>(((Variable)entity).IOUnit.ID);
                        e.Menu.Items.Add(new DXMenuItem("添加变量", delegate(object obj, EventArgs es)
                        { ShowVariable(FormState.Add); }));
                        e.Menu.Items.Add(new DXMenuItem("清空变量", delegate(object obj, EventArgs es)
                        { ShowVariable(FormState.Clear); }));
                        #endregion
                    }
                }

            }
        }

        private void treeList_Left_BeforeCollapse(object sender, BeforeCollapseEventArgs e)
        {
            if (!treeList_Left.FocusedNode.Equals(e.Node))
            {
                e.Node.Selected = true;
            }
        }

        private void treeList_Left_BeforeExpand(object sender, BeforeExpandEventArgs e)
        {
            if (!treeList_Left.FocusedNode.Equals(e.Node))
            {
                e.Node.Selected = true;
            }
        }


        #endregion

        #region Grid Event

        /// <summary>
        /// 自定义列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "column_DataType")
            {
                e.DisplayText = new VarDataTypeHelper().GetKeyByValue((Sinowyde.RTModel.DataType)e.Value);
            }
            else if (e.Column.Name == "column_DirectionType")
            {
                e.DisplayText = new VarDirectionTypeHelper().GetKeyByValue((VarDirectionType)e.Value);
            }
            else if (e.Column.Name == "column_VariableType")
            {
                e.DisplayText = new VariableTypeHelper().GetKeyByValue((VariableType)e.Value);
            }
            else if (e.Column.Name.Equals("column_Channel_IP") || e.Column.Name.Equals("column_Channel_Port"))
            {
                IOChannel channel = ((List<IOChannel>)gridControl_Right.DataSource)[e.ListSourceRowIndex];
                if (channel.CommuType == CommuType.Serial)
                {
                    e.DisplayText = string.Empty;
                }
                else
                {
                    e.DisplayText = e.Value.ToString();
                }
            }
            else if (e.Column.Name.Equals("column_Channel_Params"))
            {
                IOChannel channel = ((List<IOChannel>)gridControl_Right.DataSource)[e.ListSourceRowIndex];
                if (channel.CommuType == CommuType.Serial)
                {
                    SerialChannel serial = new SerialChannel(channel);
                    e.DisplayText = string.Format("串口号:{0} 波特率:{1} 数据位:{2} 停止位:{3} 奇偶校验:{4}", serial.SerialNo, serial.Baud, serial.DataBits, serial.StopBits, serial.ParityVerify);
                }
                else
                {
                    e.DisplayText = string.Empty;
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

        /// <summary>
        /// 目标行双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_MouseDown(object sender, MouseEventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = ((DevExpress.XtraGrid.Views.Grid.GridView)sender).CalcHitInfo(new Point(e.X, e.Y));
            //if (e.Button == MouseButtons.Left && e.Clicks == 2)
            //{
            //    //判断光标是否在行范围内  
            //    if (hInfo.InRow)
            //    {
            //        if (gridControl_Right.DataSource is List<IOChannel>)
            //        {
            //            ShowIOChannel(FormState.Update, ((List<IOChannel>)gridControl_Right.DataSource)[hInfo.RowHandle]);
            //        }
            //        else if (gridControl_Right.DataSource is List<IOUnit>)
            //        {
            //            ShowIOUnit(FormState.Update, ((List<IOUnit>)gridControl_Right.DataSource)[hInfo.RowHandle]);
            //        }
            //        else if (gridControl_Right.DataSource is List<Variable>)
            //        {
            //            ShowVariable(FormState.Update, ((List<Variable>)gridControl_Right.DataSource)[hInfo.RowHandle]);
            //        }
            //        else if (gridControl_Right.DataSource is List<IOServer>)
            //        {
            //            ShowIOServer(FormState.Update, ((List<IOServer>)gridControl_Right.DataSource)[hInfo.RowHandle]);
            //        }
            //    }
            //}
        }

        private void gv_IOServer_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
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

            e.Menu.Items.Add(new DXMenuItem("添加IOServer"));
            e.Menu.Items.Add(new DXMenuItem("编辑IOServer"));
            e.Menu.Items.Add(new DXMenuItem("删除IOServer"));
            e.Menu.Items.Add(new DXMenuItem("清空IOServer"));

            e.Menu.Items[1].Enabled = e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row;
            e.Menu.Items[2].Enabled = e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row;

            IOServer model = new IOServer();
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                if (e.HitInfo.InRowCell)
                {
                    int index = gv_IOServer.GetDataSourceRowIndex(e.HitInfo.RowHandle);
                    model = ((List<IOServer>)gridControl_Right.DataSource)[index];

                    e.Menu.Items[1].Click += delegate(object obj, EventArgs es) { ShowIOServer(FormState.Update, model); };
                    e.Menu.Items[2].Click += delegate(object obj, EventArgs es) { ShowIOServer(FormState.Delete, model); };
                }
            }

            e.Menu.Items[0].Click += delegate(object obj, EventArgs es) { ShowIOServer(FormState.Add); };
            e.Menu.Items[3].Click += delegate(object obj, EventArgs es) { ShowIOServer(FormState.Clear); };
        }

        private void gv_IOUnit_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
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

            e.Menu.Items.Add(new DXMenuItem("添加IO单元"));
            e.Menu.Items.Add(new DXMenuItem("编辑IO单元"));
            e.Menu.Items.Add(new DXMenuItem("删除IO单元"));
            e.Menu.Items.Add(new DXMenuItem("清空IO单元"));

            e.Menu.Items[1].Enabled = e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row;
            e.Menu.Items[2].Enabled = e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row;

            IOUnit model = new IOUnit();
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                if (e.HitInfo.InRowCell)
                {
                    int index = gv_IOUnit.GetDataSourceRowIndex(e.HitInfo.RowHandle);
                    model = ((List<IOUnit>)gridControl_Right.DataSource)[index];

                    e.Menu.Items[1].Click += delegate(object obj, EventArgs es) { ShowIOUnit(FormState.Update, model); };
                    e.Menu.Items[2].Click += delegate(object obj, EventArgs es) { ShowIOUnit(FormState.Delete, model); };
                }
            }

            e.Menu.Items[0].Click += delegate(object obj, EventArgs es) { ShowIOUnit(FormState.Add); };
            e.Menu.Items[3].Click += delegate(object obj, EventArgs es) { ShowIOUnit(FormState.Clear); };
        }

        private void gv_Channel_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
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

            e.Menu.Items.Add(new DXMenuItem("添加IO通道"));
            e.Menu.Items.Add(new DXMenuItem("编辑IO通道"));
            e.Menu.Items.Add(new DXMenuItem("删除IO通道"));
            e.Menu.Items.Add(new DXMenuItem("清空IO通道"));

            e.Menu.Items[1].Enabled = e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row;
            e.Menu.Items[2].Enabled = e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row;

            IOChannel model = new IOChannel();
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                if (e.HitInfo.InRowCell)
                {
                    int index = gv_IOChannel.GetDataSourceRowIndex(e.HitInfo.RowHandle);
                    model = ((List<IOChannel>)gridControl_Right.DataSource)[index];

                    e.Menu.Items[1].Click += delegate(object obj, EventArgs es) { ShowIOChannel(FormState.Update, model); };
                    e.Menu.Items[2].Click += delegate(object obj, EventArgs es) { ShowIOChannel(FormState.Delete, model); };
                }
            }

            e.Menu.Items[0].Click += delegate(object obj, EventArgs es) { ShowIOChannel(FormState.Add); };
            e.Menu.Items[3].Click += delegate(object obj, EventArgs es) { ShowIOChannel(FormState.Clear); };
        }

        /// <summary>
        /// grid 右键单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_Variable_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
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

            e.Menu.Items.Add(new DXMenuItem("添加变量"));
            e.Menu.Items.Add(new DXMenuItem("编辑变量"));
            e.Menu.Items.Add(new DXMenuItem("删除变量"));
            e.Menu.Items.Add(new DXMenuItem("清空变量"));
            e.Menu.Items.Add(new DXMenuItem("配置报警规则"));

            e.Menu.Items[1].Enabled = e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row;
            e.Menu.Items[2].Enabled = e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row;
            e.Menu.Items[4].Enabled = e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row;

            Variable model = new Variable();
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                if (e.HitInfo.InRowCell)
                {
                    int index = gv_Variable.GetDataSourceRowIndex(e.HitInfo.RowHandle);
                    model = ((List<Variable>)gridControl_Right.DataSource)[index];

                    e.Menu.Items[1].Click += delegate(object obj, EventArgs es) { ShowVariable(FormState.Update, model); };
                    e.Menu.Items[2].Click += delegate(object obj, EventArgs es) { ShowVariable(FormState.Delete, model); };

                    e.Menu.Items[4].Click += delegate(object obj, EventArgs es) { new Form_Alarmrule(model).ShowDialog(); };

                    if (model.DirectionType == VarDirectionType.Temp)
                    {
                        e.Menu.Items[4].Enabled = false;
                    }
                }
            }

            e.Menu.Items[0].Click += delegate(object obj, EventArgs es) { ShowVariable(FormState.Add); };
            e.Menu.Items[3].Click += delegate(object obj, EventArgs es) { ShowVariable(FormState.Clear); };
        }

        #endregion

        private void barBtn_Device_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Form_Device().ShowDialog();
        }

        private void barBtn_ServiceCfg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Form_ServiceCfg().ShowDialog();
        }

        private void barBtn_VariableSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Form_VariableSelect().ShowDialog();
        }

        private void barBtn_Import_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("模型导出暂时不可用", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Excel文档(*.xls)|*.xls|Excel文档(*.xlsx)|*.xlsx";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                ExportHelper.Import(openFile.FileName, loadTip);
            }
        }

        private void barBtn_Export_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel文档(*.xls)|*.xls|Excel文档(*.xlsx)|*.xlsx";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                List<Variable> list = DOPDataLogic.Instance().GetReadWriteVaribale();
                ExportHelper.Export(saveFile.FileName, list, loadTip);
            }
        }


        #region IToolUc 成员



        public void SaveUc()
        {

        }

        public UserControl CreateUc()
        {
            return this;
        }

        #endregion

        private void barBtn_ModelVersion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sinowyde.DataModel.ModelVersion model = new Sinowyde.DataModel.ModelVersion();
            model.ModelType = Sinowyde.DataModel.ModelType.Business;
            model.Timestamp = DateTime.Now;
            long id = (long)DOPDataLogic.Instance().Insert(model);
            if (id > 0)
            {
                MessageBox.Show("模型已变更", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void barBtn_CalcVariable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

    }

    public class CHLocalizer : Localizer
    {
        public override string GetLocalizedString(StringId id)
        {
            switch (id)
            {
                case StringId.FilterClauseIsNull:
                    return "空值";
                case StringId.FilterClauseIsNotNull:
                    return "非空值";
                case StringId.FilterClauseEquals:
                    return "等于";
                case StringId.OK:
                    return "确定";
                case StringId.Cancel:
                    return "取消";
                default:
                    return base.GetLocalizedString(id);
            }
        }
    }

    public class TreeData
    {
        public enum NodeType
        {
            Root = 0,
            IOServer,
            TempVariabel,
            CalcVariable,
            IOChannel,
            IOUnit,
            VarDirection
        }

        public int ID { get; set; }
        public string Caption { get; set; }
        public int ParentID { get; set; }
        public object Entity { get; set; }
        public NodeType TreeDataType { get; set; }

    }
}
