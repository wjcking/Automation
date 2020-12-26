using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Northwoods.Go;
using System.ComponentModel.Composition;
using Sinowyde.DOP.Graph.FORMS;
using Sinowyde.DOP.GraphicElement.Base;
using DevExpress.XtraBars.Docking;
using Sinowyde.DOP.UI;
using DevExpress.XtraEditors.Controls;
using Sinowyde.DOP.DTProxy;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.Graph.Xml;
using DevExpress.Utils;
using Northwoods.Go.Instruments;
using Sinowyde.DOP.GraphicElement;

namespace Sinowyde.DOP.Graph
{
    [Export(typeof(IToolUc))]
    [ExportUcMetaData("Graph组态软件")]
    public partial class UCtlGraph : XtraUserControl,IToolUc
    {
        #region 变量定义
        private GoDrawViewEx goDrawView = null;
        private string docName = "";
        private MefFramkGraph mefTool = null;
        #endregion

        public UCtlGraph()
        {
            InitializeComponent();
            DOPGraphElement.CommandAction += (commandStr) => ExcutedContextMenu(commandStr);
            searchControlDocs.EditValueChanged += (ss, ee) => LoadDocs(searchControlDocs.Text);
            GraphRunTime.Instance().DocChangeEditEvent += UCtlGraph_DocChangeEditEvent;
            Application.Idle += Application_Idle;
            Application.EnableVisualStyles();
            //IKernel iKernal = new StandardKernel(new GraphNinject());
            //mefTool = iKernal.Get<MefFramkGraph>();
            mefTool = new MefFramkGraph();
            barManager.AllowQuickCustomization = false;
            LoadGraphControls();
            CreateDrawView();
            InitDocs();
        }

        private void CreateDrawView()
        {
            this.goDrawView = new GoDrawViewEx()
            {
                ArrowMoveLarge = 25,
                ArrowMoveSmall = 1,
                GridCellSize = new SizeF(25, 25),
                SheetShowsMargins = true,
                ShadowHeight = 0,
                ShadowWidth = 0,
                Dock = DockStyle.Fill,
                AllowResize = true,
                Name = "DrawView"
            };
            DPnlGoView.Controls.Add(this.goDrawView);
            this.goDrawView.DragDrop += goDrawView_DragDrop;
            this.goDrawView.ObjectGotSelection += goDrawView_ObjectGotSelection;
            this.goDrawView.ObjectLostSelection += goDrawView_ObjectLostSelection;
            this.goDrawView.MouseDown += goDrawView_MouseDown;
            this.goDrawView.KeyDown += goDrawView_KeyDown;
            //this.goDrawView.ObjectSingleClicked += goView_ObjectSingleClicked;
            this.goDrawView.Visible = false;
            this.barChkItemMesh.Checked = this.goDrawView.Visible;
        }

        private void UCtlGraph_DocChangeEditEvent(object sender, GraphEditEventArgs arg)
        {
            if (arg.Status == GraphDocStatus.IsEdit)
            {
                ExecuteStopRun();
            }
            else
            {
                ExecuteRun();
            }
        }

        #region IToolUc

        public void SaveUc()
        {
            if (this.goDrawView.Visible && this.goDrawView.Document.IsModified)
                GraphDocManager.Instance().SavePages();
        }


        public UserControl CreateUc()
        {
            GraphRunTime.Instance().GraphStatus = GraphDocStatus.IsEdit;
            return this;
        }
        #endregion

        #region GoView事件
        /// <summary>
        /// 鼠标拖动产生图元对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goDrawView_DragDrop(object sender, DragEventArgs e)
        {
            if (string.IsNullOrEmpty(mefTool.GraphCurrentTool)) return;
            switch (mefTool.GraphCurrentTool)
            {
                case "图库":
                case "直线":
                case "多边形":
                case "图像":
                    break;
                case "文本":
                    CreateText();
                    break;
                default:
                    var iToolGraph = mefTool.ToolAddGraph.FirstOrDefault(v => v.Metadata.Name.Equals(mefTool.GraphCurrentTool)).Value;
                    var instance = iToolGraph.CreateElement();
                    if (instance != null)
                        CreateShape(instance);
                    break;
            }
            mefTool.GraphCurrentTool = string.Empty;
        }

        /// <summary>
        /// 设置按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goDrawView_ObjectGotSelection(object sender, GoSelectionEventArgs e)
        {
            SetControlStaturs();
            //(goDrawView.Selection.Primary).TopLevelObject
        }

        /// <summary>
        /// 设置按钮状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goDrawView_ObjectLostSelection(object sender, GoSelectionEventArgs e)
        {
            SetControlStaturs();
            e.GoObject.Selectable = true;
        }

        /// <summary>
        /// 产生图元对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goDrawView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (null != mefTool && ((MouseEventArgs)e).Button == MouseButtons.Left && !string.IsNullOrEmpty(mefTool.GraphCurrentTool))
                {
                    switch (mefTool.GraphCurrentTool)
                    {
                        case "直线":
                            barBtnItemLine_ItemClick(null, null);
                            break;
                        case "多边形":
                            barBtnItemPolygon_ItemClick(null, null);
                            break;
                        case "图像":
                            barBtnItemImage_ItemClick(null, null);
                            break;
                        case "图库":
                            this.goDrawView.Tool = new DOPImageLibraryTool(this.goDrawView);
                            mefTool.GraphCurrentTool = string.Empty;
                            break;
                        case "文本":
                            CreateText();
                            break;
                        default:
                            var iToolGraph = mefTool.ToolAddGraph.FirstOrDefault(v => v.Metadata.Name.Equals(mefTool.GraphCurrentTool)).Value;
                            CreateShape(iToolGraph.CreateElement());
                            mefTool.GraphCurrentTool = string.Empty;
                            break;
                    }
                }
            }
        }

        private void goDrawView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                barBtnItemSelection_ItemClick(null, null);
            }
        }
        #endregion

        #region 方法定义
        private void InitDocs()
        {
            using (new WaitDialogForm("请等待", "数据加载中...", new Size(200, 50), ParentForm))
            {
                GraphDocManager.Instance().InitFromDB();
                IList<GraphDocument> graphEntity = GraphDocManager.Instance().OpenDocs;
                this.listBoxCtlDocs.Items.Clear();
                foreach (var doc in graphEntity)
                {
                    this.listBoxCtlDocs.Items.Add(doc.Name);
                }
                if (this.listBoxCtlDocs.Items.Count > 0)
                    docName = this.listBoxCtlDocs.SelectedItem.ToString();
            }
        }


        private void LoadDocs(string name = "")
        {
            this.listBoxCtlDocs.Items.Clear();
            IList<GraphDocument> graphEntity = GraphDocManager.Instance().OpenDocs;
            graphEntity.Where(w => w.Name.Contains(name)).GroupBy(g => g.Name).ToList().ForEach(v =>
            {
                this.listBoxCtlDocs.Items.Add(v.Key);
            });
            for (int i = 0; i < this.listBoxCtlDocs.Items.Count; i++)
            {
                if (this.listBoxCtlDocs.Items[i].ToString().Equals(docName))
                {
                    this.listBoxCtlDocs.SelectedIndex = i;
                    break;
                }
            }
        }

        private void ExcutedContextMenu(string command)
        {
            switch (command)
            {
                case "SendToBack":
                    barBtnItemMenuBack_ItemClick(null, null);
                    break;
                case "BringToFront":
                    barBtnItemMenuSetFront_ItemClick(null, null);
                    break;
                case "CutObject":
                    barBtnItemCut_ItemClick(null, null);
                    break;
                case "CopyObject":
                    barBtnItemCopy_ItemClick(null, null);
                    break;
                case "PasteObject":
                    barBtnItemPaste_ItemClick(null, null);
                    break;
                case "DeleteObject":
                    barBtnItemMenuDelete_ItemClick(null, null);
                    break;
                case "AutoResizes":
                    (this.goDrawView.Selection.Primary as GoGroup).AutoRescales = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 初始化图形元控件
        /// </summary>
        private void LoadGraphControls(string searchStr = "")
        {
            this.panelControl.Controls.Clear();
            #region 添加组
            mefTool.ToolAddGraph.Where(q => q.Metadata.Name.Contains(searchStr)).GroupBy(v => v.Metadata.Group).ToList()
                  .ForEach(v =>
                  {
                      var flowLayoutPanel = new FlowLayoutPanel { Name = v.Key, Dock = DockStyle.Top, Visible = !string.IsNullOrEmpty(searchStr), AutoSize = true };
                      panelControl.Controls.Add(flowLayoutPanel);
                      var groupBtn = new SimpleButton { Text = v.Key, ImageList = this.imageList1, ImageIndex = 0, ButtonStyle = BorderStyles.HotFlat, Dock = DockStyle.Top, Height = 24 };
                      groupBtn.MouseDown += (sender, e) =>
                      {
                          if (e.Button == MouseButtons.Left)
                          {
                              flowLayoutPanel.Visible = !flowLayoutPanel.Visible;
                              groupBtn.ImageIndex = groupBtn.ImageIndex == 0 ? 1 : 0;
                          }
                      };
                      panelControl.Controls.Add(groupBtn);
                  });
            #endregion

            #region 添加按钮
            foreach (var block in mefTool.ToolAddGraph.Where(v => v.Metadata.Name.Contains(searchStr)).OrderBy(v => v.Metadata.Order))
            {
                var simpleButton = new SimpleButton
                {
                    AllowDrop = true,
                    ToolTip = block.Metadata.Name,
                    ButtonStyle = BorderStyles.UltraFlat,
                    Size = new Size(32, 32),
                    ImageList = this.imgLstGraph,
                    ImageIndex = block.Metadata.Order,
                    ImageLocation = ImageLocation.MiddleCenter
                };
                simpleButton.MouseDown += (sender, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        mefTool.GraphCurrentTool = block.Metadata.Name;
                        simpleButton.DoDragDrop(block.Metadata.Name, DragDropEffects.Copy);
                    }
                };
                panelControl.Controls.OfType<FlowLayoutPanel>().FirstOrDefault(v => v.Name.Equals(block.Metadata.Group)).Controls.Add(simpleButton);
            }
            #endregion
        }

        /// <summary>
        /// 控件状态复位
        /// </summary>
        private void ResetControlsStaturs(BarButtonItem btn)
        {
            mefTool.GraphCurrentTool = "";
            this.barBtnItemSelection.Down = false;
            this.barBtnItemLine.Down = false;
            this.barBtnItemPolygon.Down = false;
            this.barBtnItemText.Down = false;
            btn.Down = true;
        }
        /// <summary>
        /// 设置按钮状态
        /// </summary>
        private void SetControlStaturs()
        {
            //保存
            barBtnItemSave.Enabled = true;
            //图形
            this.barBtnItemSelection.Enabled = true;
            this.barBtnItemLine.Enabled = true;
            this.barBtnItemPolygon.Enabled = true;
            this.barBtnItemText.Enabled = true;
            this.barBtnItemImage.Enabled = true;
            barChkItemMesh.Enabled = true;
            int n = this.goDrawView.Selection.Count;
            barBtnItemMenuCut.Enabled = this.goDrawView.CanEditCut();
            barBtnItemMenuCopy.Enabled = this.goDrawView.CanEditCopy();
            barBtnItemMenuPaste.Enabled = this.goDrawView.CanEditPaste();
            barBtnItemMenuDelete.Enabled = this.goDrawView.CanEditDelete();
            barBtnItemMenuAllSelection.Enabled = n > 0;
            //前后置、成组、解组
            barBtnItemMenuSetFront.Enabled = n > 0;
            barBtnItemMenuBack.Enabled = n > 0;
            barBtnItemMenuJoinGroup.Enabled = n > 1;
            barBtnItemMenuDisGroup.Enabled = n == 1;
            if (n == 1)
                barBtnItemMenuDisGroup.Enabled = this.goDrawView.Selection.Primary is GoGroup;
            barBtnItemSetFront.Enabled = barBtnItemMenuSetFront.Enabled;
            barBtnItemBack.Enabled = barBtnItemMenuBack.Enabled;
            barBtnJoinGroup.Enabled = barBtnItemMenuJoinGroup.Enabled;
            barBtnItemDisGroup.Enabled = barBtnItemMenuDisGroup.Enabled;
            //对齐
            barBtnItemMenuLeftAlign.Enabled = n > 1;
            barBtnItemMenuRightAlign.Enabled = n > 1;
            barBtnItemMenuTopAlign.Enabled = n > 1;
            barBtnItemMenuBottomAlign.Enabled = n > 1;
            barBtnItemMenuHAlign.Enabled = n > 1;
            barBtnItemMenuVAlign.Enabled = n > 1;
            barBtnItemAlignLeft.Enabled = barBtnItemMenuLeftAlign.Enabled;
            barBtnItemAlignRight.Enabled = barBtnItemMenuRightAlign.Enabled;
            barBtnItemAlignTop.Enabled = barBtnItemMenuTopAlign.Enabled;
            barBtnItemAlignBottom.Enabled = barBtnItemMenuBottomAlign.Enabled;
            barBtnItemAlignHCenter.Enabled = barBtnItemMenuHAlign.Enabled;
            barBtnItemAlignVCenter.Enabled = barBtnItemMenuVAlign.Enabled;
            //尺寸大小
            barBtnItemMenuEqualWidth.Enabled = n > 1;
            barBtnItemMenuEqualHeight.Enabled = n > 1;
            barBtnItemMenuEqualAll.Enabled = n > 1;
            barBtnItemEqualWidth.Enabled = barBtnItemMenuEqualWidth.Enabled;
            barBtnItemEqualHeight.Enabled = barBtnItemMenuEqualHeight.Enabled;
            barBtnItemEqualAll.Enabled = barBtnItemMenuEqualAll.Enabled;

            barBtnItemAllSelection.Enabled = barBtnItemMenuAllSelection.Enabled;
            //放大、缩小、还原
            barBtnItemZoom.Enabled = true;
            barBtnItemZoomIn.Enabled = true;
            barBtnItemZoomOut.Enabled = true;
        }

        /// <summary>
        /// 创建图形对象
        /// </summary>
        /// <param name="goShape"></param>
        /// <param name="p"></param>
        private void CreateShape(DOPGraphElement graphElement)
        {
            if (this.goDrawView == null)
                return;
            Point viewPnt = this.goDrawView.PointToClient(MousePosition);
            PointF docPnt = this.goDrawView.ConvertViewToDoc(viewPnt);
            this.goDrawView.StartTransaction();

            if (graphElement.First is GoButton)
            {
                graphElement.Bounds = new RectangleF(docPnt.X, docPnt.Y, (graphElement.First as GoButton).Width, (graphElement.First as GoButton).Height);
            }
            else if (graphElement.First is Meter)
            {
                graphElement.Bounds = new RectangleF(docPnt.X, docPnt.Y, (graphElement.First as Meter).Width, (graphElement.First as Meter).Height);
            }
            else
            {
                graphElement.Bounds = new RectangleF(docPnt.X, docPnt.Y, 100, 100);
            }
            this.goDrawView.Document.Add(graphElement);
            graphElement.Location = new PointF(docPnt.X, docPnt.Y);
            this.goDrawView.Selection.Select(graphElement);
            this.goDrawView.Selection.HotSpot = new SizeF(graphElement.Width / 2, graphElement.Height / 2);
            this.goDrawView.FinishTransaction("插入图元");
        }
        /// <summary>
        /// 创建文本
        /// </summary>
        private void CreateText()
        {
            if (this.goDrawView == null)
                return;
            var pointClient = this.goDrawView.PointToClient(MousePosition);
            var pointDoc = this.goDrawView.ConvertViewToDoc(pointClient);
            var graphElement = new DOPText() { Center = new PointF(pointDoc.X, pointDoc.Y) };
            this.goDrawView.StartTransaction();
            this.goDrawView.Document.Add(graphElement);
            this.goDrawView.FinishTransaction("插入文字");
            mefTool.GraphCurrentTool = string.Empty;
        }

        /// <summary>
        /// 撤消状态
        /// </summary>
        public void EnableToolBarUndoButtons()
        {
            if (this.goDrawView.Document != null)
            {
                barBtnItemUndo.Enabled = this.goDrawView.CanUndo();
                barBtnItemRedo.Enabled = this.goDrawView.CanRedo();
                barBtnItemMenuUndo.Enabled = barBtnItemUndo.Enabled;
                barBtnItemMenuRedo.Enabled = barBtnItemRedo.Enabled;
            }
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            EnableToolBarUndoButtons();
        }
        #endregion

        #region 文件菜单
        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemNew_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNewDialog frm = new frmNewDialog();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.docName = frm.GraphDoc.Name;
                LoadDocs();
            }
            frm.Dispose();
            SetControlStaturs();
        }

        /// <summary>
        /// 打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmOpenDialog frm = new frmOpenDialog(ActionEnum.OpenGraph);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.docName = frm.GraphDoc.Name;
                LoadDocs(frm.GraphDoc.Name);
            }
            frm.Dispose();
            SetControlStaturs();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (this.listBoxCtlDocs.Items.Count < 1)
                {
                    XtraMessageBox.Show("无保存对象！");
                }
                if (GraphDocManager.Instance().SavePages())
                {
                    XtraMessageBox.Show("保存文档成功！");
                    this.goDrawView.Document.IsModified = false;
                }
                else
                {
                    XtraMessageBox.Show("保存文档失败！");
                }
            }
            catch (Exception ex)
            {
                Log.LogUtil.LogInfo("保存文档失败", ex);
            }
        }

        /// <summary>
        /// 移除文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxCtlDocs.SelectedItem == null) return;
            GraphDocManager.Instance().RemoveDocument(listBoxCtlDocs.SelectedItem.ToString());
            listBoxCtlDocs.Items.Remove(listBoxCtlDocs.SelectedItem);
            if (listBoxCtlDocs.ItemCount == 0)
            {
                this.goDrawView.Visible = false;
                this.barChkItemMesh.Checked = this.goDrawView.Visible;
            }
        }

        /// <summary>
        /// 文件另存为
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemSaveAs_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemPrintView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.goDrawView.PrintPreview();
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.goDrawView.Print();
        }

        /// <summary>
        /// 导入文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemImport_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        /// <summary>
        /// 导出文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemOutport_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        /// <summary>
        /// 删除文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonDeleteDoc_Click(object sender, EventArgs e)
        {
            if (listBoxCtlDocs.SelectedIndex < 0) return;
            if (XtraMessageBox.Show("确定要删除？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                GraphDocManager.Instance().DeletePage(listBoxCtlDocs.SelectedItem.ToString());
                listBoxCtlDocs.Items.Remove(listBoxCtlDocs.SelectedItem);
                if (listBoxCtlDocs.ItemCount == 0)
                {
                    this.goDrawView.Visible = false;
                    this.barChkItemMesh.Checked = this.goDrawView.Visible;
                }
            }
        }
        /// <summary>
        /// 修改文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonModifyDoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxCtlDocs.SelectedIndex < 0) return;
                frmNewDialog frm = new frmNewDialog(GraphDocManager.Instance().GetDocument(listBoxCtlDocs.SelectedItem.ToString()));
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.docName = frm.GraphDoc.Name;
                    LoadDocs();
                    XtraMessageBox.Show("文档保存成功！");
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("文档保存失败！");
            }
        }
        /// <summary>
        /// 新建文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonAddDoc_Click(object sender, EventArgs e)
        {
            barBtnItemNew_ItemClick(null, null);
        }

        /// <summary>
        /// 刷新文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonRefrashDoc_Click(object sender, EventArgs e)
        {
            InitDocs();
        }
        #endregion

        #region 编辑
        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemMenuAllSelection_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView != null)
                this.goDrawView.SelectAll();
        }

        /// <summary>
        /// 撤消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemMenuUndo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView != null)
                this.goDrawView.Undo();
        }

        /// <summary>
        /// 重复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemMenuRedo_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView != null)
                this.goDrawView.Redo();
        }

        /// <summary>
        /// 撤消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemUndo_ItemClick(object sender, ItemClickEventArgs e)
        {
            barBtnItemMenuUndo_ItemClick(null, null);
        }

        /// <summary>
        /// 重复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemRedo_ItemClick(object sender, ItemClickEventArgs e)
        {
            barBtnItemMenuRedo_ItemClick(null, null);
        }

        /// <summary>
        /// 剪切
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemCut_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView != null)
            {
                this.goDrawView.EditCut();
                barBtnItemMenuPaste.Enabled = this.goDrawView.CanEditPaste();
            }
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView != null)
            {
                this.goDrawView.EditCopy();
                barBtnItemMenuPaste.Enabled = this.goDrawView.CanEditPaste();
            }
        }

        /// <summary>
        /// 粘贴
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemPaste_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView != null)
                this.goDrawView.EditPaste();

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemMenuDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView != null)
                this.goDrawView.EditDelete();
        }
        #endregion

        #region 绘制工具
        /// <summary>
        /// 选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemSelection_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            ResetControlsStaturs(this.barBtnItemSelection);
            this.goDrawView.Tool = new GoToolSelecting(this.goDrawView);
        }

        /// <summary>
        /// 绘制直线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemLine_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            ResetControlsStaturs(this.barBtnItemSelection);
            this.goDrawView.Tool = new DOPLineTool(this.goDrawView);
        }

        /// <summary>
        /// 绘制多边形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemPolygon_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            ResetControlsStaturs(this.barBtnItemPolygon);
            this.goDrawView.Tool = new DOPPolygonTool(this.goDrawView);
        }

        /// <summary>
        /// 绘制文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemText_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            ResetControlsStaturs(this.barBtnItemSelection);
            mefTool.GraphCurrentTool = "文本";
        }

        /// <summary>
        /// 图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            ResetControlsStaturs(this.barBtnItemSelection);
            this.goDrawView.Tool = new DOPImageTool(this.goDrawView);
        }
        #endregion

        #region 查看
        /// <summary>
        /// 工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barChkItemTool_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            this.barTool.Visible = barChkItemTool.Checked;
        }

        /// <summary>
        /// 状态栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barChkItemStaturs_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            this.barStaturs.Visible = barChkItemStaturs.Checked;
        }

        /// <summary>
        /// 图形控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barChkItemGraph_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            this.DPnlGraph.Visible = barChkItemGraph.Checked;
        }

        /// <summary>
        /// 编辑区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barChkItemEditArea_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            this.DPnlGoView.Visibility = barChkItemEditArea.Checked ? DockVisibility.Visible : DockVisibility.Hidden;
        }
        /// <summary>
        /// 文档列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barCheckItemDocList_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            this.DPnlDoc.Visibility = barCheckItemDocList.Checked ? DockVisibility.Visible : DockVisibility.Hidden;
        }


        private void dockPanelDoc_ClosingPanel(object sender, DockPanelCancelEventArgs e)
        {
            barCheckItemDocList.Checked = false;
        }
        #endregion

        #region 操作
        #region 对象对齐
        /// <summary>
        /// 左对齐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemMenuLeftAlign_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            GoObject obj = this.goDrawView.Selection.Primary;
            if (obj != null)
            {
                this.goDrawView.StartTransaction();
                foreach (GoObject temp in this.goDrawView.Selection)
                {
                    temp.SelectionObject.Left = obj.SelectionObject.Left;
                }
                this.goDrawView.FinishTransaction("左对齐");
            }
        }

        /// <summary>
        /// 右对齐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemMenuRightAlign_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            GoObject obj = this.goDrawView.Selection.Primary;
            if (obj != null)
            {
                this.goDrawView.StartTransaction();
                foreach (GoObject temp in this.goDrawView.Selection)
                {
                    temp.SelectionObject.Right = obj.SelectionObject.Right;
                }
                this.goDrawView.FinishTransaction("左对齐");
            }
        }

        /// <summary>
        /// 上对齐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemMenuTopAlign_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            GoObject obj = this.goDrawView.Selection.Primary;
            if (obj != null)
            {
                this.goDrawView.StartTransaction();
                foreach (GoObject temp in this.goDrawView.Selection)
                {
                    temp.SelectionObject.Top = obj.SelectionObject.Top;
                }
                this.goDrawView.FinishTransaction("左对齐");
            }
        }

        /// <summary>
        /// 下对齐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemMenuBottomAlign_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            GoObject obj = this.goDrawView.Selection.Primary;
            if (obj != null)
            {
                this.goDrawView.StartTransaction();
                foreach (GoObject temp in this.goDrawView.Selection)
                {
                    temp.SelectionObject.Bottom = obj.SelectionObject.Bottom;
                }
                this.goDrawView.FinishTransaction("左对齐");
            }
        }

        /// <summary>
        /// 水平对齐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemMenuHAlign_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            GoObject obj = this.goDrawView.Selection.Primary;
            if (obj != null)
            {
                this.goDrawView.StartTransaction();
                foreach (GoObject temp in this.goDrawView.Selection)
                {
                    var objSelection = temp.SelectionObject;
                    objSelection.Center = new PointF(obj.SelectionObject.Center.X, objSelection.Center.Y);
                }
                this.goDrawView.FinishTransaction("水平居中对齐");
            }
        }

        /// <summary>
        /// 垂直对齐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemMenuVAlign_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            GoObject obj = this.goDrawView.Selection.Primary;
            if (obj != null)
            {
                this.goDrawView.StartTransaction();
                foreach (GoObject temp in this.goDrawView.Selection)
                {
                    var objSelection = temp.SelectionObject;
                    objSelection.Center = new PointF(objSelection.Center.X, obj.SelectionObject.Center.Y);
                }
                this.goDrawView.FinishTransaction("垂直居中对齐");
            }
        }

        /// <summary>
        /// 左对齐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemAlignLeft_ItemClick(object sender, ItemClickEventArgs e)
        {
            barBtnItemMenuLeftAlign_ItemClick(null, null);
        }

        /// <summary>
        /// 右对齐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemAlignRight_ItemClick(object sender, ItemClickEventArgs e)
        {
            barBtnItemMenuRightAlign_ItemClick(null, null);
        }

        /// <summary>
        /// 顶端对齐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemAlignTop_ItemClick(object sender, ItemClickEventArgs e)
        {
            barBtnItemMenuTopAlign_ItemClick(null, null);
        }

        /// <summary>
        /// 下端对齐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemAlignBottom_ItemClick(object sender, ItemClickEventArgs e)
        {
            barBtnItemMenuBottomAlign_ItemClick(null, null);
        }

        /// <summary>
        /// 水平居中对齐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemAlignHCenter_ItemClick(object sender, ItemClickEventArgs e)
        {
            barBtnItemMenuHAlign_ItemClick(null, null);
        }

        /// <summary>
        /// 垂直居中对齐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemAlignVCenter_ItemClick(object sender, ItemClickEventArgs e)
        {
            barBtnItemMenuVAlign_ItemClick(null, null);
        }



        /// <summary>
        /// 图元全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemAllSelection_ItemClick(object sender, ItemClickEventArgs e)
        {
            barBtnItemMenuAllSelection_ItemClick(null, null);
        }
        #endregion

        #region 对象尺寸
        /// <summary>
        /// 等宽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemMenuEqualWidth_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            GoObject obj = this.goDrawView.Selection.Primary;
            if (obj != null)
            {
                this.goDrawView.StartTransaction();
                foreach (GoObject temp in this.goDrawView.Selection)
                {
                    temp.SelectionObject.Width = obj.SelectionObject.Width;
                }
                this.goDrawView.FinishTransaction("图元等宽");
            }
            else
            {
                MessageBox.Show("");
            }
        }

        /// <summary>
        /// 等高
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemMenuEqualHight_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            GoObject obj = this.goDrawView.Selection.Primary;
            if (obj != null)
            {
                this.goDrawView.StartTransaction();
                foreach (GoObject temp in this.goDrawView.Selection)
                {
                    temp.SelectionObject.Height = obj.SelectionObject.Height;
                }
                this.goDrawView.FinishTransaction("图元等高");
            }
            else
            {
                MessageBox.Show("");
            }
        }

        /// <summary>
        /// 全部相等
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemMenuEqualAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            GoObject obj = this.goDrawView.Selection.Primary;
            if (obj != null)
            {
                this.goDrawView.StartTransaction();
                foreach (GoObject temp in this.goDrawView.Selection)
                {
                    temp.SelectionObject.Size = obj.SelectionObject.Size;
                }
                this.goDrawView.FinishTransaction("相同大小");
            }
            else
            {
                MessageBox.Show("Sizing failure: Primary Selection is empty or a link instead of a node.");
            }
        }

        /// <summary>
        /// 所选图元等高
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemEqualH_ItemClick(object sender, ItemClickEventArgs e)
        {
            barBtnItemMenuEqualHight_ItemClick(null, null);
        }

        /// <summary>
        /// 所选图元等宽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemEqualW_ItemClick(object sender, ItemClickEventArgs e)
        {
            barBtnItemMenuEqualWidth_ItemClick(null, null);
        }

        /// <summary>
        /// 所选图元宽、高相等
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemEqualAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            barBtnItemMenuEqualAll_ItemClick(null, null);
        }
        #endregion

        #region 图元调整

        /// <summary>
        /// 前置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemMenuSetFront_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (this.goDrawView == null) return;
                foreach (GoObject obj in this.goDrawView.Selection)
                {
                    obj.Layer.MoveAfter(null, obj);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 后置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemMenuBack_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (this.goDrawView == null) return;
                foreach (GoObject obj in this.goDrawView.Selection)
                {
                    obj.Layer.MoveBefore(null, obj);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 图元前移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemSetFront_ItemClick(object sender, ItemClickEventArgs e)
        {
            barBtnItemMenuSetFront_ItemClick(null, null);
        }

        /// <summary>
        /// 图元后移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemBack_ItemClick(object sender, ItemClickEventArgs e)
        {
            barBtnItemMenuBack_ItemClick(null, null);
        }

        /// <summary>
        /// 组合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemMenuJoinGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (this.goDrawView == null) return;
            //this.goDrawView.StartTransaction();
            //GoSelection goSelection = this.goDrawView.Selection;
            ////GoNode group = new GoNode();
            ////GoGroup group = new GoGroup();
            //var group = new DOPGraphGroup();
            ////GoDocument goDocument = this.goDrawView.Document;
            //this.goDrawView.Document.Add(group);
            //IGoCollection iGoCollection = group.AddCollection(goSelection, false);
            //goSelection.Select(group);
            //foreach (GoObject obj in group)
            //{
            //    obj.Selectable = false;
            //}
            //this.goDrawView.FinishTransaction("组合");
        }

        /// <summary>
        /// 解组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemMenuDisGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            this.goDrawView.StartTransaction();
            GoSelection goSelection = this.goDrawView.Selection;
            GoObject goObject = goSelection.Primary;
            if ((goObject != null) && (goObject is GoGroup) && goObject.IsTopLevel)
            {
                GoGroup goGroup = (GoGroup)goObject;
                GoLayer goLayer = goGroup.Layer;
                goSelection.Clear();
                IGoCollection iGoCollection = goLayer.AddCollection(goGroup, false);
                foreach (GoObject obj in iGoCollection)
                {
                    obj.Selectable = true;
                    goSelection.Add(obj);
                }
                goLayer.Remove(goGroup);
            }
            this.goDrawView.FinishTransaction("解散组");
        }

        /// <summary>
        /// 成组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnJoinGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            barBtnItemMenuJoinGroup_ItemClick(null, null);
        }

        /// <summary>
        /// 分散组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemDisGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            barBtnItemMenuDisGroup_ItemClick(null, null);
        }

        /// <summary>
        /// 显示、隐藏网格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barChkItemMesh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView != null)
                this.goDrawView.GridStyle = this.goDrawView.GridStyle == GoViewGridStyle.None ? GoViewGridStyle.Line : GoViewGridStyle.None;
        }
        #endregion

        /// <summary>
        /// 放大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemZoomIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            this.goDrawView.ZoomIn();
        }
        /// <summary>
        /// 缩小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemZoomOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            this.goDrawView.ZoomOut();
        }
        /// <summary>
        /// 恢复大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItemZoom_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.goDrawView == null) return;
            this.goDrawView.SheetStyle = GoViewSheetStyle.None;
            this.goDrawView.SheetStyle = GoViewSheetStyle.SheetWidth;
            this.goDrawView.SheetStyle = GoViewSheetStyle.None;
            this.goDrawView.SheetStyle = GoViewSheetStyle.SheetWidth;
        }
        #endregion

        #region 调试

        /// <summary>
        /// 全屏下运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barCheckItemFullRun_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateRunDocument(this.goViewRun);
            if (barCheckItemFullRun.Checked)
            {
                GraphRunTime.Instance().GraphStatus = GraphDocStatus.IsDebug;
                if (new FrmFull(this.goViewRun).ShowDialog() == DialogResult.OK)
                {
                    barCheckItemFullRun.Checked = false;
                    SetButtonIsRun(this.goDrawView,false);
                }
                
            }
        }

        private void SetButtonIsRun(GoView goView , bool v)
        {
            foreach (GoObject obj in goView.Document.DefaultLayer)
            {
                var dopGraphElement = obj as DOPGraphElement;
                if (dopGraphElement is DOPButton || dopGraphElement is DOPImageButton)
                {
                    var btn = (GoButton)dopGraphElement.First;
                    btn.ActionEnabled = v;
                }
            }
        }
        #endregion

        #region 其它事件
        /// <summary>
        /// 工具栏状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barTool_VisibleChanged(object sender, EventArgs e)
        {
            this.barChkItemTool.Checked = this.barTool.Visible;
        }

        /// <summary>
        /// 编辑区显示、隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DPnlGoView_VisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            barChkItemEditArea.Checked = DPnlGoView.Visibility == DockVisibility.Visible;
        }

        /// <summary>
        /// 图形工具面板状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DPnlGraph_VisibilityChanged(object sender, VisibilityChangedEventArgs e)
        {
            barChkItemGraph.Checked = DPnlGraph.Visibility == DockVisibility.Visible;
        }
        #endregion

        /// <summary>
        /// 当前选择文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void documentManager_DocumentActivate(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentEventArgs e)
        {
            //barBtnItemSave.Enabled = true;
            //SetControlStaturs();
        }
        /// <summary>
        /// 关闭当前文档时释放对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabbedView_DocumentClosing(object sender, DevExpress.XtraBars.Docking2010.Views.DocumentCancelEventArgs e)
        {
            barChkItemEditArea.Checked = false;
        }

        #region 图形动画
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (GoObject obj in this.goViewRun.Document.DefaultLayer)
            {
                var dopGraphElement = obj as DOPGraphElement;
                dopGraphElement.Refresh();
            }
        }

        /// <summary>
        /// 开始订阅数据
        /// </summary>
        public void ExecuteRun()
        {
            this.timer1.Interval = 1000;
            //RTValueMemCache.Instance().StartMemCache("tcp://192.168.200.89:9003", new List<string> { IOTopic.IORead, IOTopic.IOWrite, IOTopic.IOCalc, IOTopic.IOTemp });
            RTValueMemCache.Instance().StartMemCache();
            timer1.Start();
        }

        /// <summary>
        /// 停止订阅数据
        /// </summary>
        public void ExecuteStopRun()
        {
            timer1.Stop();
            RTValueMemCache.Instance().StopMemCache();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxCtlDocs_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                CreateDocument(this.goDrawView);
                SetControlStaturs();
            }
            catch (Exception)
            {
            }

        }

        private void CreateDocument(GoDrawViewEx view)
        {
            if (listBoxCtlDocs.SelectedIndex < 0) return;
            var name = listBoxCtlDocs.SelectedItem.ToString();
            var doc = GraphDocManager.Instance().GetOpenedDoc(name);
            doc.UndoManager = new GoUndoManager();
            view.Document = doc;
            //document的颜色有bug，需要再次设置
            Color tempColor = view.Document.PaperColor;
            view.Document.PaperColor = Color.White;
            view.Document.PaperColor = tempColor;
            view.Visible = true;
            barChkItemMesh.Checked = true;
            SetButtonIsRun(this.goDrawView,false);
        }

        private void CreateRunDocument(GoView view)
        {
            if (listBoxCtlDocs.SelectedIndex < 0) return;
            var name = listBoxCtlDocs.SelectedItem.ToString();
            var doc = this.goDrawView.Document.Copy();
            view.Document = doc;
            //document的颜色有bug，需要再次设置
            Color tempColor = view.Document.PaperColor;
            view.Document.PaperColor = Color.White;
            view.Document.PaperColor = tempColor;
            view.Visible = true;
            SetButtonIsRun(view,true);
        }
    }
}