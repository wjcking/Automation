using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Ninject;
using Northwoods.Go;
using Sinowyde.Common.UI;
using Sinowyde.DOP.DTProxy;
using Sinowyde.DOP.DataBus;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Env;
using Sinowyde.DOP.Sama.Control.Frms;
using Sinowyde.DOP.Sama.Control.Properties;
using Sinowyde.DOP.Sama.Control.UserControls;
using Sinowyde.DOP.UI;
using ImageLocation = DevExpress.XtraEditors.ImageLocation;
using Sinowyde.DOP.PIDBlock.Xml;
using Sinowyde.DOP.PIDBlock.GoObjectEx;

namespace Sinowyde.DOP.Sama.Control
{
    [Export(typeof(IToolUc))]
    [ExportUcMetaData("Sama编辑软件")]
    public partial class UserControlSama : XtraUserControl, IToolUc
    {
        private GoViewEx goViewEx = new GoViewEx();

        //private PushThread commandPush = new PushThread("tcp://127.0.0.1:9001", PIDAlgTopic.PIDCommand);//推送命令线程
        //private SubscribeThreadPool subscribeCommand = new SubscribeThreadPool("tcp://127.0.0.1:9003", new List<string> { PIDAlgTopic.PIDReCommand });//接收命令线程

        private PushThread commandPush = new PushThread(Settings.Default.SamaCommandPush, PIDAlgTopic.PIDCommand);//推送命令线程
        private SubscribeThreadPool subscribeCommand = new SubscribeThreadPool(Settings.Default.SamaSubscribeCommand, new List<string> { PIDAlgTopic.PIDReCommand });//接收命令线程

        private enum ProcessState
        {
            Default = -1,//默认
            Open,//打开后
            Recovery,//恢复后
            Submit,//提交后(先编译,再提交)
            StartDebug,//调试
            StopDebug,//停止调试
        }

        public UserControlSama()
        {
            InitializeComponent();
        }

        private void CommandAction(string commandStr, int hascode = -1)
        {
            //1.输出类型,强制,取消强制,保持,取消保持直接在DB做,不需要存
            //2.输入 和 参数都可以动态改,动态留下来,确定下来类型是输入 或者 参数
            commandPush.AddBuffer(commandStr);

            if (PIDCommmandMsg.FromString(commandStr).ParamType != PIDCommandParamType.Output)
                PIDDocManager.Instance().SaveToCache(hascode);
        }

        private void UserControlSama_Load(object sender, EventArgs e)
        {
            RTValueMemCache.Instance().StartMemCache(); //出版本成品的时候需要停掉,外面统一处理了
            commandPush.Start();
            PIDGeneralBlock.CommandAction += CommandAction;
            PIDGeneralBlock.LocateAction += LocateBlock;
            subscribeCommand.Start();
            subscribeCommand.EventSubscribe += subscribeCommand_EventSubscribe;

            dockPanelGoView_Container.Controls.Add(goViewEx);
            searchControlBlocks.EditValueChanged += (ss, ee) => FillBlocks(searchControlBlocks.Text);
            FillBlocks();
            repositoryItemComboBoxZoom.Items.AddRange(new object[] { "25%", "50%", "100%", "200%", "400%" });
            barEditItemToolZoom.EditValueChanged += barEditItemToolZoom_EditValueChanged;

            goViewEx.Click += goViewEx_Click;
            goViewEx.DragDrop += goViewEx_DragDrop;
            goViewEx.MouseMove += goViewEx_MouseMove;
            goViewEx.ScaleChangedEvent += goViewEx_ScaleChangedEvent;

            panelControlBlocks.AutoScroll = true;
            barCheckItemViewIndexInGroup.Checked = true;
            SetUiState(ProcessState.Default);
        }

        private void subscribeCommand_EventSubscribe(object sender, SubscribePoolEventArgs arg)
        {
            IList<string> messages = arg.Messages;
            try
            {
                foreach (string message in messages)
                {
                    PIDCommmandMsg msg = PIDCommmandMsg.FromString(message);
                    //MessageBox.Show("subscribeCommand==>" + msg.CommandType.ToString());
                }
            }
            catch { }
        }

        #region GoViewEx

        private void goViewEx_ScaleChangedEvent()
        {
            this.barEditItemToolZoom.EditValue = string.Format("{0}%", (int)(goViewEx.DocScale * 100));
        }

        private void goViewEx_MouseMove(object sender, MouseEventArgs e)
        {
            //var point = goViewEx.PointToClient(MousePosition);
            //barStaticItemMove.Caption = string.Format("x={0},y={1}", point.X, point.Y);
        }

        private void goViewEx_DragDrop(object sender, DragEventArgs e)
        {
            if (PIDGeneralBlock.IsRunning || string.IsNullOrEmpty(NinjectHelper.Kernel.Get<MefTool>().SamaCurrentTool))
                return;

            AddPidBlock();
        }

        private void goViewEx_Click(object sender, EventArgs e)
        {
            if (PIDGeneralBlock.IsRunning || string.IsNullOrEmpty(NinjectHelper.Kernel.Get<MefTool>().SamaCurrentTool) || ((MouseEventArgs)e).Button != MouseButtons.Left)
                return;

            if (NinjectHelper.Kernel.Get<MefTool>().SamaCurrentTool.Equals("AddBlockText"))
                AddBlockText();
            else
                AddPidBlock();
        }

        #endregion

        #region 项目

        private void barButtonItemProjectOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (PIDDocManager.Instance().ExistCache())
            {
                var str = string.Format("检测到缓存文件！是否下载并覆盖缓存？{0}是：下载并覆盖缓存{1}否：直接打开缓存", Environment.NewLine, Environment.NewLine);
                var dialogResult = XtraMessageBox.Show(str, "提示", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Cancel) return; //取消

                if (dialogResult == DialogResult.Yes)//是：下载并覆盖缓存
                {
                    using (new WaitDialogForm("请等待", "下载数据中...", new Size(200, 50), ParentForm))
                    {
                        if (PIDDocManager.Instance().UpdateToCache())
                        {
                            if (PIDDocManager.Instance().ExistCache())
                                PIDDocManager.Instance().Backup("操作人员", "自动备份下载操作！");
                        }

                        else
                        {
                            XtraMessageBox.Show("下载失败!");
                            return;
                        }
                    }
                }

                //否：直接打开缓存
                using (new WaitDialogForm("请等待", "加载数据中...", new Size(200, 50), ParentForm))
                {
                    if (PIDDocManager.Instance().OpenFromCache())
                        InitPages();
                    else
                        XtraMessageBox.Show("打开失败!");
                }
            }
            else
            {

                using (new WaitDialogForm("请等待", "下载数据中...", new Size(200, 50), ParentForm))
                {
                    if (PIDDocManager.Instance().UpdateToCache())
                    {
                        if (PIDDocManager.Instance().ExistCache())
                            PIDDocManager.Instance().Backup("操作人员", "自动备份下载操作！");

                        if (PIDDocManager.Instance().OpenFromCache())
                            InitPages();
                        else
                            XtraMessageBox.Show("打开失败!");
                    }
                    else
                        XtraMessageBox.Show("下载失败!");
                }
            }

            if (PIDDocManager.Instance().ChangeAlgorithm)
            {
                SetUiState(ProcessState.Open);
            }
            else
            {
                SetUiState(ProcessState.Submit);
                PIDRunTime.Instance().CreateMemCache();
            }
        }

        private void barButtonItemProjectSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (new WaitDialogForm("请等待", "保存数据中...", new Size(200, 50), ParentForm))
            {
                var flag = PIDDocManager.Instance().SaveToCache();
                if (!flag)
                    XtraMessageBox.Show("保存失败!");
            }
        }

        private void barButtonItemProjectSubmit_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (!PIDDocManager.Instance().ExistCache())
            //{
            //    XtraMessageBox.Show("没有文件!");
            //    return;
            //}

            var flagCheck = PIDDocManager.Instance().CheckValid();
            barButtonItemViewError_ItemClick(null, null);
            this.dockPanelError.Visibility = flagCheck ? DockVisibility.Hidden : DockVisibility.Visible;

            if (flagCheck) //编译通过
            {
                using (new WaitDialogForm("请等待", "提交中...", new Size(200, 50), ParentForm))
                {
                    if (PIDDocManager.Instance().UploadToDB())
                    {
                        commandPush.AddBuffer(new PIDCommmandMsg { CommandType = PIDCommandType.Download }.ToString());
                        SetUiState(ProcessState.Submit);
                        PIDRunTime.Instance().CreateMemCache();
                    }
                    else
                        XtraMessageBox.Show("提交失败!");
                }
            }
        }

        private void barButtonItemProjectRecovery_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmRecovery = new FrmRecovery();
            if (frmRecovery.ShowDialog() == DialogResult.OK)
            {
                using (new WaitDialogForm("请等待", "恢复数据中...", new Size(200, 50), ParentForm))
                {
                    if (frmRecovery.FlagRecovery)
                    {
                        if (PIDDocManager.Instance().OpenFromCache())
                        {
                            InitPages();
                            SetUiState(ProcessState.Recovery);
                        }
                        else
                            XtraMessageBox.Show("恢复失败!");
                    }
                }
            }
        }

        private void barButtonItemProjectBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (PIDDocManager.Instance().ExistCache())
                new FrmBackup().ShowDialog();
            else
                XtraMessageBox.Show("没有缓存文件！无法进行备份！");
        }

        #endregion

        #region 页

        private void barSubItemPageAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmAddPage = new FrmAddPage();
            if (frmAddPage.ShowDialog() == DialogResult.OK)
            {
                PIDDocManager.Instance().CurrentAction = ActionEnum.NewDoc;
                FillPages();
                PIDDocManager.Instance().CurrentAction = ActionEnum.Default;
            }
        }

        private void barSubItemPageModify_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (null == listBoxControlPage.SelectedItem) return;

            var frmAddPage = new FrmAddPage((PIDDocument)listBoxControlPage.SelectedItem);
            if (frmAddPage.ShowDialog() == DialogResult.OK)
            {
                PIDDocManager.Instance().CurrentAction = ActionEnum.ModifyDoc;
                FillPages();
                PIDDocManager.Instance().CurrentAction = ActionEnum.Default;


                if (barCheckItemViewIndexInGroup.Checked)//刷新显示
                    PIDDocManager.Instance().VisIndexInGroup(barCheckItemViewIndexInGroup.Checked);
            }
        }

        private void barSubItemPageDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (null == listBoxControlPage.SelectedItem) return;

            if (XtraMessageBox.Show("确定要删除？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                PIDDocManager.Instance().CurrentAction = ActionEnum.DeleteDoc;
                PIDDocManager.Instance().DeleteDoc(((PIDDocument)listBoxControlPage.SelectedItem).AlgPage.Guid);

                listBoxControlPage.Items.Remove(listBoxControlPage.SelectedItem);
                if (listBoxControlPage.ItemCount == 0)
                {
                    goViewEx.Document = new GoDocument();
                    goViewEx.CanEnabled(false);
                }

                PIDDocManager.Instance().CurrentAction = ActionEnum.Default;
            }
        }

        private void barSubItemPagePrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            goViewEx.Print();
        }

        private void barSubItemPagePrintView_ItemClick(object sender, ItemClickEventArgs e)
        {
            goViewEx.PrintPreview();
        }

        #endregion

        #region  编辑

        private void barButtonItemEditCut_ItemClick(object sender, ItemClickEventArgs e)
        {
            goViewEx.EditCut();
        }

        private void barButtonItemEditCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            goViewEx.EditCopy();
        }

        private void barButtonItemEditPaste_ItemClick(object sender, ItemClickEventArgs e)
        {
            goViewEx.EditPaste();
        }

        private void barButtonItemEditDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            goViewEx.EditDelete();
        }

        private void barButtonItemEditAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            goViewEx.SelectAll();
        }

        private void barButtonItemEditFindUsages_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItemEditSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmSearch = new FrmSearch();
            if (frmSearch.ShowDialog() == DialogResult.OK)
            {
                var userControlSearch = new UserControlSearch();
                userControlSearch.LocateAction += LocateBlock;
                userControlSearch.Dock = DockStyle.Fill;
                //this.dockPanelError_Container.Controls.Add(userControlErr);
                //barButtonItemViewError_ItemClick(null, null);
                //this.dockPanelError.Visibility = barButtonItemViewSearch ? DockVisibility.Hidden : DockVisibility.Visible;
                dockPanelSearch_Container.Controls.Clear();
                dockPanelSearch_Container.Controls.Add(userControlSearch);

                this.dockPanelSearch.Visibility = DockVisibility.Visible;
            }
        }

        private void barButtonItemEditStatistics_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmStatistics = new FrmStatistics();
            frmStatistics.SelectPageAction += SelectBlock;
            frmStatistics.Show();
        }

        #endregion

        #region 调试

        private void barCheckItemDebug_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            barToggleSwitchItemQToolDebug.Checked = barCheckItemDebug.Checked;
            commandPush.AddBuffer(new PIDCommmandMsg
            {
                CommandType = PIDCommandType.RunDebug,
                TakeEffect = barCheckItemDebug.Checked
            }.ToString());

            if (barCheckItemDebug.Checked)
                PIDRunTime.Instance().StartRun();
            else
                PIDRunTime.Instance().StopRun();

            this.goViewEx.AllowEdit = !barCheckItemDebug.Checked;
            this.goViewEx.AllowCopy = !barCheckItemDebug.Checked;
            this.goViewEx.AllowDelete = !barCheckItemDebug.Checked;
            this.goViewEx.AllowDrop = !barCheckItemDebug.Checked;
            this.goViewEx.AllowLink = !barCheckItemDebug.Checked;

            SetUiState(barCheckItemDebug.Checked ? ProcessState.StartDebug : ProcessState.StopDebug);
        }

        #endregion

        #region  视图

        private void barButtonItemViewTool_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.barTools.Visible = true;
        }

        private void barButtonItemViewStatusbar_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.barBottom.Visible = true;
        }

        private void barButtonItemViewPage_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.dockPanelPage.Visibility = DockVisibility.Visible;
        }

        private void barButtonItemViewBlocks_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.dockPanelBlocks.Visibility = DockVisibility.Visible;
        }

        private void barButtonItemViewError_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.dockPanelError.Visibility = DockVisibility.Visible;

            this.dockPanelError_Container.Controls.Clear();
            var userControlErr = new UserControlErr();
            userControlErr.LocateAction += LocateBlock;
            userControlErr.Dock = DockStyle.Fill;
            this.dockPanelError_Container.Controls.Add(userControlErr);
        }

        private void barButtonItemViewSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.dockPanelSearch.Visibility = DockVisibility.Visible;
        }

        private void barCheckItemViewIndexInGroup_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            PIDDocManager.Instance().VisIndexInGroup(barCheckItemViewIndexInGroup.Checked);
        }

        #endregion

        #region 设置

        private void barButtonItemSettingDebug_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frmDebugSetting = new FrmDebugSetting();
            frmDebugSetting.ShowDialog();
        }

        #endregion

        #region  帮助

        private void barButtonItemHelpTopics_ItemClick(object sender, ItemClickEventArgs e)
        {
            var fileName = Path.Combine(Application.StartupPath, "Helps", "SamaHelp.pdf");
            new FrmPdf(fileName).ShowDialog();
        }

        private void barButtonItemHelpAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            new FrmAbout().ShowDialog();
        }

        #endregion

        #region Page页操作

        private void simpleButtonNewPage_Click(object sender, EventArgs e)
        {
            barSubItemPageAdd_ItemClick(null, null);
        }

        private void simpleButtonModifyPage_Click(object sender, EventArgs e)
        {
            barSubItemPageModify_ItemClick(null, null);
        }

        private void simpleButtonDeletePage_Click(object sender, EventArgs e)
        {
            barSubItemPageDelete_ItemClick(null, null);
        }

        private void listBoxControlPage_SelectedValueChanged(object sender, EventArgs e)
        {
            if (null == listBoxControlPage.SelectedItem) return;
            var docManager = PIDDocManager.Instance();

            if (docManager.CurrentAction == ActionEnum.LoadDoc || docManager.CurrentAction == ActionEnum.DeleteDoc || docManager.CurrentAction == ActionEnum.Default)
            {
                var doc = (PIDDocument)listBoxControlPage.SelectedItem;
                docManager.SetActiveDoc(doc.AlgPage.Guid);
                goViewEx.Document = docManager.ActiveDoc;
            }

            else if (docManager.CurrentAction == ActionEnum.NewDoc || docManager.CurrentAction == ActionEnum.ModifyDoc)
            {
                goViewEx.Document = docManager.ActiveDoc;
            }
        }

        #endregion

        #region QTools操作

        private void barButtonItemQToolOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            barButtonItemProjectOpen_ItemClick(null, null);
        }

        private void barButtonItemQToolSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            barButtonItemProjectSave_ItemClick(null, null);
        }

        private void barButtonItemQToolSubmit_ItemClick(object sender, ItemClickEventArgs e)
        {
            barButtonItemProjectSubmit_ItemClick(null, null);
        }

        private void barButtonItemQToolFind_ItemClick(object sender, ItemClickEventArgs e)
        {
            barButtonItemEditSearch_ItemClick(null, null);
        }

        private void barButtonItemQToolFindUsages_ItemClick(object sender, ItemClickEventArgs e)
        {
            barButtonItemEditFindUsages_ItemClick(null, null);
        }

        private void barButtonItemQToolStatistics_ItemClick(object sender, ItemClickEventArgs e)
        {
            barButtonItemEditStatistics_ItemClick(null, null);
        }

        private void barButtonItemQToolAddLabel_ItemClick(object sender, ItemClickEventArgs e)
        {
            var mefTool = NinjectHelper.Kernel.Get<MefTool>();
            if (null != mefTool)
                mefTool.SamaCurrentTool = "AddBlockText";
        }

        private void barEditItemToolZoom_EditValueChanged(object sender, EventArgs e)
        {
            var str = barEditItemToolZoom.EditValue.ToString();
            switch (str)
            {
                case "25%":
                    goViewEx.Zoom(0.25f);
                    break;
                case "50%":
                    goViewEx.Zoom(0.5f);
                    break;
                case "100%":
                    goViewEx.Zoom();
                    break;
                case "200%":
                    goViewEx.Zoom(2f);
                    break;
                case "400%":
                    goViewEx.Zoom(4f);
                    break;
            }
        }

        private void barToggleSwitchItemQToolDebug_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            barCheckItemDebug.Checked = barToggleSwitchItemQToolDebug.Checked;
        }

        private void barCheckItemQToolForce_CheckedChanged(object sender, ItemClickEventArgs e)
        {

        }

        private void barCheckItemQToolKeep_CheckedChanged(object sender, ItemClickEventArgs e)
        {

        }

        #endregion

        #region IToolUc

        public void SaveUc()
        {
            //PIDDocManager.Instance().SaveDoc();
            //释放资源

            //PIDDocManager.Instance().DisposeTimer();
            commandPush.Stop();
            subscribeCommand.Stop();
        }

        public UserControl CreateUc()
        {
            return this; //new UserControlSama();
        }

        #endregion

        #region 其他方法

        //切换页
        private void SelectPage(string pageGuid)
        {
            PIDDocManager.Instance().SetActiveDoc(pageGuid);
            foreach (var doc in listBoxControlPage.Items.OfType<PIDDocument>())
            {
                if (doc.AlgPage.Guid.Equals(pageGuid))
                {
                    listBoxControlPage.SelectedItem = doc;
                    break;
                }
            }
        }

        //切换页 选择块
        private void LocateBlock(string strGroupIndex, string strIndexInGroup)
        {
            PIDDocManager.Instance().SetActiveDoc(strGroupIndex);
            foreach (var doc in listBoxControlPage.Items.OfType<PIDDocument>())
            {
                if (doc.AlgPage.GIndex.ToString().Equals(strGroupIndex))
                {
                    listBoxControlPage.SelectedItem = doc;

                    var block = PIDDocManager.Instance()
                        .ActiveDoc.OfType<PIDGeneralBlock>()
                        .FirstOrDefault(v => v.Algorithm.IndexInGroup.Equals(strIndexInGroup));

                    if (null != block)
                    {
                        this.goViewEx.DocExtentCenter = block.Center;
                        goViewEx.Selection.Clear();
                        goViewEx.Selection.Add(block);
                        goViewEx.Focus();
                    }
                    break;
                }
            }
        }

        //切换页 选择块
        private void SelectBlock(string pageGuid, string blockGuid)
        {
            PIDDocManager.Instance().SetActiveDoc(pageGuid);
            foreach (var doc in listBoxControlPage.Items.OfType<PIDDocument>())
            {
                if (doc.AlgPage.Guid.Equals(pageGuid))
                {
                    listBoxControlPage.SelectedItem = doc;

                    var block = PIDDocManager.Instance()
                        .ActiveDoc.OfType<PIDGeneralBlock>()
                        .FirstOrDefault(v => v.Algorithm.Identity.Equals(blockGuid));

                    if (null != block)
                    {
                        this.goViewEx.DocExtentCenter = block.Center;
                        goViewEx.Selection.Clear();
                        goViewEx.Selection.Add(block);
                        goViewEx.Focus();
                    }
                    break;
                }
            }
        }

        private void FillBlocks(string searchStr = "")
        {
            var mefTool = NinjectHelper.Kernel.Get<MefTool>();
            panelControlBlocks.Controls.Clear();

            #region AddGroups
            mefTool.ToolAddBlocks.Where(q => q.Metadata.Name.Contains(searchStr)).GroupBy(v => v.Metadata.Group).ToList()
                  .ForEach(v =>
                  {
                      var flowLayoutPanel = new FlowLayoutPanel { Name = v.Key, Dock = DockStyle.Top, Visible = !string.IsNullOrEmpty(searchStr), AutoSize = true };
                      panelControlBlocks.Controls.Add(flowLayoutPanel);//AddFlowLayoutPanel


                      var groupBtn = new SimpleButton { Text = v.Key, Image = Resources.BtnNormal, ButtonStyle = BorderStyles.HotFlat, Dock = DockStyle.Top, Height = 24 };
                      groupBtn.MouseDown += (sender, e) =>
                      {
                          if (e.Button == MouseButtons.Left)
                          {
                              flowLayoutPanel.Visible = !flowLayoutPanel.Visible;
                              groupBtn.Image = flowLayoutPanel.Visible ? Resources.BtnSelected : Resources.BtnNormal;
                          }
                      };
                      panelControlBlocks.Controls.Add(groupBtn);//AddBtn
                  });
            #endregion

            #region AddItems
            foreach (var block in mefTool.ToolAddBlocks.Where(v => v.Metadata.Name.Contains(searchStr)).OrderBy(v => v.Metadata.Order))
            {
                var simpleButton = new SimpleButton
                {
                    AllowDrop = true,
                    ToolTip = block.Metadata.Name,
                    ButtonStyle = BorderStyles.UltraFlat,
                    Size = new Size(36, 36),
                    Image = (Image)DrawBlockUtil.GetImageManager(block.Value, block.Metadata.ThumImgUrl),
                    ImageLocation = ImageLocation.MiddleCenter
                };
                simpleButton.Click += (sender, e) => { mefTool.SamaCurrentTool = block.Metadata.Name; };
                simpleButton.MouseDown += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        mefTool.SamaCurrentTool = block.Metadata.Name;
                        simpleButton.DoDragDrop(block.Metadata.Name, DragDropEffects.Copy);
                    }
                };
                panelControlBlocks.Controls.OfType<FlowLayoutPanel>().FirstOrDefault(v => v.Name.Equals(block.Metadata.Group)).Controls.Add(simpleButton);
            }
            #endregion
        }

        private void InitPages()
        {
            var docManager = PIDDocManager.Instance();
            PIDDocManager.Instance().CurrentAction = ActionEnum.LoadDoc;

            listBoxControlPage.Items.Clear();

            foreach (var doc in docManager.Documents)
            {
                listBoxControlPage.Items.Add(doc);
            }

            goViewEx.CanEnabled(listBoxControlPage.ItemCount > 0);

            PIDDocManager.Instance().CurrentAction = ActionEnum.Default;
        }

        private void FillPages()
        {
            var docManager = PIDDocManager.Instance();
            listBoxControlPage.Items.Clear();
            foreach (var doc in docManager.Documents)
            {
                listBoxControlPage.Items.Add(doc);
            }
            goViewEx.CanEnabled(listBoxControlPage.ItemCount > 0);
            foreach (var doc in listBoxControlPage.Items.OfType<PIDDocument>())
            {
                if (doc.AlgPage.Guid.Equals(docManager.ActiveDoc.AlgPage.Guid))
                {
                    listBoxControlPage.SelectedItem = doc;
                    break;
                }
            }
        }

        private void AddPidBlock()
        {
            var mefTool = NinjectHelper.Kernel.Get<MefTool>();
            var docManager = PIDDocManager.Instance();
            var iToolblock = mefTool.ToolAddBlocks.FirstOrDefault(v => v.Metadata.Name.Equals(mefTool.SamaCurrentTool)).Value;
            var pointClient = goViewEx.PointToClient(MousePosition);
            var pointDoc = goViewEx.ConvertViewToDoc(pointClient);
            var block = iToolblock.CreateBlock();
            //var block = new PAIBlock();
            block.Center = new PointF(pointDoc.X, pointDoc.Y);
            //迁移至PIDDocument_Changed去做
            //block.Algorithm.GroupIndex = docManager.ActiveDoc.Name.Split('.')[1];//当前group
            //block.Algorithm.IndexInGroup = ConvertUtil.ConvertToString(docManager.ActiveDoc.OfType<PIDGeneralBlock>().Count() + 1);
            //block.BottomText = visibility ? string.Format("{0}-{1}", block.Algorithm.GroupIndex, block.Algorithm.IndexInGroup) : string.Empty;//bool visibility
            goViewEx.Document.Add(block);
            mefTool.SamaCurrentTool = string.Empty;
        }

        private void AddBlockText()
        {
            var pointClient = goViewEx.PointToClient(MousePosition);
            var pointDoc = goViewEx.ConvertViewToDoc(pointClient);
            goViewEx.Document.Add(new BlockText { Center = new PointF(pointDoc.X, pointDoc.Y) });
            NinjectHelper.Kernel.Get<MefTool>().SamaCurrentTool = string.Empty;
        }

        private void UiStateSubmit()
        {
            simpleButtonModifyPage.Enabled = true;//修改
            simpleButtonAddPage.Enabled = true;//新建
            simpleButtonDeletePage.Enabled = true;//删除页
            //
            barButtonItemProjectSave.Enabled = true;//保存
            barButtonItemProjectSubmit.Enabled = true;//提交
            barButtonItemProjectBackup.Enabled = true;//备份
            barSubItemPageAdd.Enabled = true;//打开
            barSubItemPageModify.Enabled = true;//保存
            barSubItemPageDelete.Enabled = true;//提交
            barButtonItemEditCut.Enabled = true;//剪切
            barButtonItemEditCopy.Enabled = true;//复制
            barButtonItemEditPaste.Enabled = true;//粘贴
            barButtonItemEditDelete.Enabled = true;//删除
            barButtonItemEditAll.Enabled = true;//全选
            barButtonItemEditSearch.Enabled = true;//条件查找
            barButtonItemEditFindUsages.Enabled = true;//跳转到引用
            barButtonItemEditStatistics.Enabled = true;//算法块个数统计
            barCheckItemDebug.Enabled = true;//调试
            //QTool
            barButtonItemQToolSave.Enabled = true;//保存
            barButtonItemQToolSubmit.Enabled = true;//提交
            barButtonItemQToolFind.Enabled = true;//查找
            barButtonItemQToolFindUsages.Enabled = true;//定位
            barButtonItemQToolStatistics.Enabled = true;//统计
            barEditItemToolZoom.Enabled = true;//100%
            barButtonItemQToolAddLabel.Enabled = true;//A       
            barToggleSwitchItemQToolDebug.Enabled = true;//调试       
        }

        private void UiStateDefault()
        {
            //页View操作
            simpleButtonModifyPage.Enabled = false;//修改页
            simpleButtonAddPage.Enabled = false;//新建页
            simpleButtonDeletePage.Enabled = false;//删除页
            //
            barButtonItemProjectOpen.Enabled = false;//打开
            barButtonItemProjectSave.Enabled = false;//保存
            barButtonItemProjectSubmit.Enabled = false;//提交
            barButtonItemProjectRecovery.Enabled = false;//恢复
            barButtonItemProjectBackup.Enabled = false;//备份
            //
            barSubItemPageAdd.Enabled = false;//打开
            barSubItemPageModify.Enabled = false;//保存
            barSubItemPageDelete.Enabled = false;//提交
            barSubItemPagePrint.Enabled = false;//打印
            barSubItemPagePrintView.Enabled = false;//打印预览
            //
            barButtonItemEditCut.Enabled = false;//剪切
            barButtonItemEditCopy.Enabled = false;//复制
            barButtonItemEditPaste.Enabled = false;//粘贴
            barButtonItemEditDelete.Enabled = false;//删除
            barButtonItemEditAll.Enabled = false;//全选
            barButtonItemEditSearch.Enabled = false;//条件查找
            barButtonItemEditFindUsages.Enabled = false;//跳转引用
            barButtonItemEditStatistics.Enabled = false;//算法块个数统计
            //
            barCheckItemDebug.Enabled = false;//调试
            //QTool
            barButtonItemQToolOpen.Enabled = false;//打开
            barButtonItemQToolSave.Enabled = false;//保存
            barButtonItemQToolSubmit.Enabled = false;//提交
            //
            barButtonItemQToolFind.Enabled = false;//查找
            barButtonItemQToolFindUsages.Enabled = false;//定位
            barButtonItemQToolStatistics.Enabled = false;//统计
            //
            barEditItemToolZoom.Enabled = false;//100%
            barButtonItemQToolAddLabel.Enabled = false;//A       
            //
            barToggleSwitchItemQToolDebug.Enabled = false;//调试 
            //
            barCheckItemQToolForce.Enabled = false;//强制
            barCheckItemQToolKeep.Enabled = false;//保持

            //
            barButtonItemProjectOpen.Enabled = true;//打开
            barButtonItemProjectRecovery.Enabled = true;//恢复
            barSubItemPagePrint.Enabled = true;//打印
            barSubItemPagePrintView.Enabled = true;//打印预览
            barButtonItemQToolOpen.Enabled = true;//打开
        }

        private void SetUiState(ProcessState processState)
        {
            UiStateDefault();
            switch (processState)
            {
                case ProcessState.Default:
                    this.dockPanelError.Visibility = DockVisibility.Hidden;
                    break;
                case ProcessState.Open:
                case ProcessState.Recovery:
                    simpleButtonModifyPage.Enabled = true;//修改
                    simpleButtonAddPage.Enabled = true;//新建
                    simpleButtonDeletePage.Enabled = true;//删除页
                    //
                    barButtonItemProjectSave.Enabled = true;//保存
                    barButtonItemProjectSubmit.Enabled = true;//提交
                    barButtonItemProjectBackup.Enabled = true;//备份
                    barSubItemPageAdd.Enabled = true;//打开
                    barSubItemPageModify.Enabled = true;//保存
                    barSubItemPageDelete.Enabled = true;//提交
                    barButtonItemEditCut.Enabled = true;//剪切
                    barButtonItemEditCopy.Enabled = true;//复制
                    barButtonItemEditPaste.Enabled = true;//粘贴
                    barButtonItemEditDelete.Enabled = true;//删除
                    barButtonItemEditAll.Enabled = true;//全选
                    barButtonItemEditSearch.Enabled = true;//条件查找
                    barButtonItemEditFindUsages.Enabled = true;//跳转到引用
                    barButtonItemEditStatistics.Enabled = true;//算法块个数统计
                    //QTool
                    barButtonItemQToolSave.Enabled = true;//保存
                    barButtonItemQToolSubmit.Enabled = true;//提交
                    barButtonItemQToolFind.Enabled = true;//查找
                    barButtonItemQToolFindUsages.Enabled = true;//定位
                    barButtonItemQToolStatistics.Enabled = true;//统计
                    barEditItemToolZoom.Enabled = true;//100%
                    barButtonItemQToolAddLabel.Enabled = true;//A    
                    break;
                case ProcessState.Submit:
                    UiStateSubmit();
                    break;
                case ProcessState.StartDebug:
                    barButtonItemProjectOpen.Enabled = false;//打开
                    barButtonItemProjectRecovery.Enabled = false;//恢复
                    barSubItemPagePrint.Enabled = false;//打印
                    barSubItemPagePrintView.Enabled = false;//打印预览
                    barButtonItemQToolOpen.Enabled = false;//打开
                    barCheckItemDebug.Enabled = true;//调试
                    barToggleSwitchItemQToolDebug.Enabled = true;//调试
                    break;
                case ProcessState.StopDebug:
                    UiStateSubmit();
                    barCheckItemDebug.Enabled = true;//调试
                    barToggleSwitchItemQToolDebug.Enabled = true;//调试
                    break;
            }

            //barCheckItemQToolForce.Enabled = true;//强制
            //barCheckItemQToolKeep.Enabled = true;//保持
        }

        #endregion
    }
}

