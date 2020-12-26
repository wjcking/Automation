namespace Sinowyde.DOP.Trend.Control
{
    partial class UserCtrlHisTrend
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barBtnItem_Variable = new DevExpress.XtraBars.BarButtonItem();
            this.batBtnItem_CurveConfig = new DevExpress.XtraBars.BarButtonItem();
            this.pcc_CurveConfig = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.ck_ShowAxisY = new DevExpress.XtraEditors.CheckEdit();
            this.ck_ShowAxisX = new DevExpress.XtraEditors.CheckEdit();
            this.ck_ShowRealValue = new DevExpress.XtraEditors.CheckEdit();
            this.barBtnItem_Search = new DevExpress.XtraBars.BarButtonItem();
            this.pcc_Search = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateTxt_begin = new DevExpress.XtraEditors.DateEdit();
            this.tsTxt_Sample = new DevExpress.XtraEditors.TimeSpanEdit();
            this.timeSpanTxt = new DevExpress.XtraEditors.TimeSpanEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.barBtnItem_CompressionCurve = new DevExpress.XtraBars.BarButtonItem();
            this.pcc_CurveChange = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.btn_Curve_Save = new DevExpress.XtraEditors.SimpleButton();
            this.txt_movePercentage = new DevExpress.XtraEditors.SpinEdit();
            this.lbl_CurveDesc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Curves = new DevExpress.XtraEditors.ComboBoxEdit();
            this.barBtnItem_ZoomCurve = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnItem_CurveMoveUp = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnItem_CurveMoveDown = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnItem_RestoreDefault = new DevExpress.XtraBars.BarButtonItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.chartControl = new Sinowyde.DOP.Trend.Control.ChartEx();
            this.panel_Container = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcc_CurveConfig)).BeginInit();
            this.pcc_CurveConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ck_ShowAxisY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_ShowAxisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_ShowRealValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcc_Search)).BeginInit();
            this.pcc_Search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTxt_begin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTxt_begin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsTxt_Sample.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSpanTxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcc_CurveChange)).BeginInit();
            this.pcc_CurveChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_movePercentage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Curves.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            this.panel_Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnItem_Variable,
            this.batBtnItem_CurveConfig,
            this.barBtnItem_Search,
            this.barBtnItem_CompressionCurve,
            this.barBtnItem_ZoomCurve,
            this.barBtnItem_CurveMoveUp,
            this.barBtnItem_CurveMoveDown,
            this.barBtnItem_RestoreDefault});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 12;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Caption, this.barBtnItem_Variable, "变量配置"),
            new DevExpress.XtraBars.LinkPersistInfo(this.batBtnItem_CurveConfig),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItem_Search),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Caption, this.barBtnItem_CompressionCurve, "压缩曲线"),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItem_ZoomCurve),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItem_CurveMoveUp),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItem_CurveMoveDown),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItem_RestoreDefault)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barBtnItem_Variable
            // 
            this.barBtnItem_Variable.Caption = "barButtonItem1";
            this.barBtnItem_Variable.Id = 0;
            this.barBtnItem_Variable.Name = "barBtnItem_Variable";
            this.barBtnItem_Variable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnItem_Variable_ItemClick);
            // 
            // batBtnItem_CurveConfig
            // 
            this.batBtnItem_CurveConfig.ActAsDropDown = true;
            this.batBtnItem_CurveConfig.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.batBtnItem_CurveConfig.Caption = "曲线配置";
            this.batBtnItem_CurveConfig.DropDownControl = this.pcc_CurveConfig;
            this.batBtnItem_CurveConfig.Id = 4;
            this.batBtnItem_CurveConfig.Name = "batBtnItem_CurveConfig";
            this.batBtnItem_CurveConfig.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.Caption;
            // 
            // pcc_CurveConfig
            // 
            this.pcc_CurveConfig.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcc_CurveConfig.Controls.Add(this.ck_ShowAxisY);
            this.pcc_CurveConfig.Controls.Add(this.ck_ShowAxisX);
            this.pcc_CurveConfig.Controls.Add(this.ck_ShowRealValue);
            this.pcc_CurveConfig.Location = new System.Drawing.Point(46, 51);
            this.pcc_CurveConfig.Manager = this.barManager1;
            this.pcc_CurveConfig.Name = "pcc_CurveConfig";
            this.pcc_CurveConfig.Size = new System.Drawing.Size(110, 77);
            this.pcc_CurveConfig.TabIndex = 25;
            this.pcc_CurveConfig.Visible = false;
            // 
            // ck_ShowAxisY
            // 
            this.ck_ShowAxisY.Location = new System.Drawing.Point(8, 5);
            this.ck_ShowAxisY.Name = "ck_ShowAxisY";
            this.ck_ShowAxisY.Properties.Caption = "显示Y轴";
            this.ck_ShowAxisY.Size = new System.Drawing.Size(70, 19);
            this.ck_ShowAxisY.TabIndex = 0;
            this.ck_ShowAxisY.CheckedChanged += new System.EventHandler(this.ck_ShowAxisY_CheckedChanged);
            // 
            // ck_ShowAxisX
            // 
            this.ck_ShowAxisX.Location = new System.Drawing.Point(8, 29);
            this.ck_ShowAxisX.Name = "ck_ShowAxisX";
            this.ck_ShowAxisX.Properties.Caption = "显示X轴";
            this.ck_ShowAxisX.Size = new System.Drawing.Size(96, 19);
            this.ck_ShowAxisX.TabIndex = 0;
            this.ck_ShowAxisX.CheckedChanged += new System.EventHandler(this.ck_ShowAxisX_CheckedChanged);
            // 
            // ck_ShowRealValue
            // 
            this.ck_ShowRealValue.Location = new System.Drawing.Point(8, 53);
            this.ck_ShowRealValue.MenuManager = this.barManager1;
            this.ck_ShowRealValue.Name = "ck_ShowRealValue";
            this.ck_ShowRealValue.Properties.Caption = "显示实际值";
            this.ck_ShowRealValue.Size = new System.Drawing.Size(96, 19);
            this.ck_ShowRealValue.TabIndex = 0;
            this.ck_ShowRealValue.CheckedChanged += new System.EventHandler(this.ck_ShowRealValue_CheckedChanged);
            // 
            // barBtnItem_Search
            // 
            this.barBtnItem_Search.ActAsDropDown = true;
            this.barBtnItem_Search.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barBtnItem_Search.Caption = "查询";
            this.barBtnItem_Search.DropDownControl = this.pcc_Search;
            this.barBtnItem_Search.Id = 6;
            this.barBtnItem_Search.Name = "barBtnItem_Search";
            // 
            // pcc_Search
            // 
            this.pcc_Search.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcc_Search.Controls.Add(this.btn_Search);
            this.pcc_Search.Controls.Add(this.labelControl1);
            this.pcc_Search.Controls.Add(this.dateTxt_begin);
            this.pcc_Search.Controls.Add(this.tsTxt_Sample);
            this.pcc_Search.Controls.Add(this.timeSpanTxt);
            this.pcc_Search.Controls.Add(this.labelControl3);
            this.pcc_Search.Controls.Add(this.labelControl2);
            this.pcc_Search.Location = new System.Drawing.Point(176, 51);
            this.pcc_Search.Manager = this.barManager1;
            this.pcc_Search.Name = "pcc_Search";
            this.pcc_Search.Size = new System.Drawing.Size(169, 165);
            this.pcc_Search.TabIndex = 40;
            this.pcc_Search.Visible = false;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(47, 136);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 5;
            this.btn_Search.Text = "查 询";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "起始时间:";
            // 
            // dateTxt_begin
            // 
            this.dateTxt_begin.EditValue = null;
            this.dateTxt_begin.Location = new System.Drawing.Point(8, 24);
            this.dateTxt_begin.MenuManager = this.barManager1;
            this.dateTxt_begin.Name = "dateTxt_begin";
            this.dateTxt_begin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTxt_begin.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.dateTxt_begin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTxt_begin.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Classic;
            this.dateTxt_begin.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.dateTxt_begin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTxt_begin.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.dateTxt_begin.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTxt_begin.Properties.Mask.EditMask = "yyyy-MM-dd HH:mm:ss";
            this.dateTxt_begin.Properties.MinValue = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTxt_begin.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dateTxt_begin.Size = new System.Drawing.Size(154, 20);
            this.dateTxt_begin.TabIndex = 2;
            // 
            // tsTxt_Sample
            // 
            this.tsTxt_Sample.EditValue = System.TimeSpan.Parse("00:00:00");
            this.tsTxt_Sample.Location = new System.Drawing.Point(8, 112);
            this.tsTxt_Sample.Name = "tsTxt_Sample";
            this.tsTxt_Sample.Properties.AllowEditSeconds = false;
            this.tsTxt_Sample.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tsTxt_Sample.Properties.Mask.EditMask = "dd天HH时mm分";
            this.tsTxt_Sample.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.SpinButtons;
            this.tsTxt_Sample.Size = new System.Drawing.Size(154, 20);
            this.tsTxt_Sample.TabIndex = 3;
            // 
            // timeSpanTxt
            // 
            this.timeSpanTxt.EditValue = System.TimeSpan.Parse("00:00:00");
            this.timeSpanTxt.Location = new System.Drawing.Point(8, 68);
            this.timeSpanTxt.MenuManager = this.barManager1;
            this.timeSpanTxt.Name = "timeSpanTxt";
            this.timeSpanTxt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeSpanTxt.Properties.Mask.EditMask = "dd天HH时mm分ss秒";
            this.timeSpanTxt.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.SpinButtons;
            this.timeSpanTxt.Size = new System.Drawing.Size(154, 20);
            this.timeSpanTxt.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 93);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "采样间隔:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 49);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "时间范围:";
            // 
            // barBtnItem_CompressionCurve
            // 
            this.barBtnItem_CompressionCurve.ActAsDropDown = true;
            this.barBtnItem_CompressionCurve.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barBtnItem_CompressionCurve.Caption = "压缩曲线";
            this.barBtnItem_CompressionCurve.DropDownControl = this.pcc_CurveChange;
            this.barBtnItem_CompressionCurve.Id = 7;
            this.barBtnItem_CompressionCurve.Name = "barBtnItem_CompressionCurve";
            // 
            // pcc_CurveChange
            // 
            this.pcc_CurveChange.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcc_CurveChange.Controls.Add(this.btn_Curve_Save);
            this.pcc_CurveChange.Controls.Add(this.txt_movePercentage);
            this.pcc_CurveChange.Controls.Add(this.lbl_CurveDesc);
            this.pcc_CurveChange.Controls.Add(this.label1);
            this.pcc_CurveChange.Controls.Add(this.cmb_Curves);
            this.pcc_CurveChange.Location = new System.Drawing.Point(370, 48);
            this.pcc_CurveChange.Name = "pcc_CurveChange";
            this.pcc_CurveChange.Size = new System.Drawing.Size(194, 91);
            this.pcc_CurveChange.TabIndex = 31;
            this.pcc_CurveChange.Visible = false;
            this.pcc_CurveChange.Popup += new System.EventHandler(this.pcc_CurveChange_Popup);
            // 
            // btn_Curve_Save
            // 
            this.btn_Curve_Save.Location = new System.Drawing.Point(87, 59);
            this.btn_Curve_Save.Name = "btn_Curve_Save";
            this.btn_Curve_Save.Size = new System.Drawing.Size(100, 23);
            this.btn_Curve_Save.TabIndex = 8;
            this.btn_Curve_Save.Text = "设置";
            this.btn_Curve_Save.Click += new System.EventHandler(this.btn_Curve_Save_Click);
            // 
            // txt_movePercentage
            // 
            this.txt_movePercentage.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txt_movePercentage.Location = new System.Drawing.Point(87, 33);
            this.txt_movePercentage.Name = "txt_movePercentage";
            this.txt_movePercentage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_movePercentage.Size = new System.Drawing.Size(100, 20);
            this.txt_movePercentage.TabIndex = 7;
            // 
            // lbl_CurveDesc
            // 
            this.lbl_CurveDesc.AutoSize = true;
            this.lbl_CurveDesc.Location = new System.Drawing.Point(6, 36);
            this.lbl_CurveDesc.Name = "lbl_CurveDesc";
            this.lbl_CurveDesc.Size = new System.Drawing.Size(79, 14);
            this.lbl_CurveDesc.TabIndex = 5;
            this.lbl_CurveDesc.Text = "上移（%）：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "变量：";
            // 
            // cmb_Curves
            // 
            this.cmb_Curves.Location = new System.Drawing.Point(87, 6);
            this.cmb_Curves.Name = "cmb_Curves";
            this.cmb_Curves.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_Curves.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_Curves.Size = new System.Drawing.Size(100, 20);
            this.cmb_Curves.TabIndex = 4;
            // 
            // barBtnItem_ZoomCurve
            // 
            this.barBtnItem_ZoomCurve.ActAsDropDown = true;
            this.barBtnItem_ZoomCurve.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barBtnItem_ZoomCurve.Caption = "放大曲线";
            this.barBtnItem_ZoomCurve.DropDownControl = this.pcc_CurveChange;
            this.barBtnItem_ZoomCurve.Id = 8;
            this.barBtnItem_ZoomCurve.Name = "barBtnItem_ZoomCurve";
            // 
            // barBtnItem_CurveMoveUp
            // 
            this.barBtnItem_CurveMoveUp.ActAsDropDown = true;
            this.barBtnItem_CurveMoveUp.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barBtnItem_CurveMoveUp.Caption = "曲线上移";
            this.barBtnItem_CurveMoveUp.DropDownControl = this.pcc_CurveChange;
            this.barBtnItem_CurveMoveUp.Id = 9;
            this.barBtnItem_CurveMoveUp.Name = "barBtnItem_CurveMoveUp";
            // 
            // barBtnItem_CurveMoveDown
            // 
            this.barBtnItem_CurveMoveDown.ActAsDropDown = true;
            this.barBtnItem_CurveMoveDown.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barBtnItem_CurveMoveDown.Caption = "曲线下移";
            this.barBtnItem_CurveMoveDown.DropDownControl = this.pcc_CurveChange;
            this.barBtnItem_CurveMoveDown.Id = 10;
            this.barBtnItem_CurveMoveDown.Name = "barBtnItem_CurveMoveDown";
            // 
            // barBtnItem_RestoreDefault
            // 
            this.barBtnItem_RestoreDefault.Caption = "恢复默认";
            this.barBtnItem_RestoreDefault.Id = 11;
            this.barBtnItem_RestoreDefault.Name = "barBtnItem_RestoreDefault";
            this.barBtnItem_RestoreDefault.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnItem_RestoreDefault_ItemClick);
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PaintStyleName = "Skin";
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
            this.barAndDockingController1.PropertiesBar.DefaultGlyphSize = new System.Drawing.Size(16, 16);
            this.barAndDockingController1.PropertiesBar.DefaultLargeGlyphSize = new System.Drawing.Size(32, 32);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(822, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 389);
            this.barDockControlBottom.Size = new System.Drawing.Size(822, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 365);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(822, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 365);
            // 
            // chartControl
            // 
            this.chartControl.CurveConfig_ShowAxisX = true;
            this.chartControl.CurveConfig_ShowAxisY = true;
            this.chartControl.CurveConfig_ShowRealValue = true;
            this.chartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl.Location = new System.Drawing.Point(0, 0);
            this.chartControl.Name = "chartControl";
            this.chartControl.Size = new System.Drawing.Size(816, 356);
            this.chartControl.TabIndex = 30;
            // 
            // panel_Container
            // 
            this.panel_Container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Container.Controls.Add(this.pcc_CurveChange);
            this.panel_Container.Controls.Add(this.chartControl);
            this.panel_Container.Location = new System.Drawing.Point(3, 30);
            this.panel_Container.Name = "panel_Container";
            this.panel_Container.Size = new System.Drawing.Size(816, 356);
            this.panel_Container.TabIndex = 45;
            // 
            // UserCtrlHisTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pcc_Search);
            this.Controls.Add(this.pcc_CurveConfig);
            this.Controls.Add(this.panel_Container);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UserCtrlHisTrend";
            this.Size = new System.Drawing.Size(822, 389);
            this.Load += new System.EventHandler(this.UserCtrlHisTrend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcc_CurveConfig)).EndInit();
            this.pcc_CurveConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ck_ShowAxisY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_ShowAxisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ck_ShowRealValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcc_Search)).EndInit();
            this.pcc_Search.ResumeLayout(false);
            this.pcc_Search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTxt_begin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTxt_begin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsTxt_Sample.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSpanTxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcc_CurveChange)).EndInit();
            this.pcc_CurveChange.ResumeLayout(false);
            this.pcc_CurveChange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_movePercentage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Curves.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            this.panel_Container.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barBtnItem_Variable;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem batBtnItem_CurveConfig;
        private DevExpress.XtraBars.PopupControlContainer pcc_CurveConfig;
        private DevExpress.XtraEditors.CheckEdit ck_ShowAxisY;
        private DevExpress.XtraEditors.CheckEdit ck_ShowAxisX;
        private DevExpress.XtraEditors.CheckEdit ck_ShowRealValue;
        private ChartEx chartControl;
        private DevExpress.XtraEditors.DateEdit dateTxt_begin;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TimeSpanEdit timeSpanTxt;
        private DevExpress.XtraBars.BarButtonItem barBtnItem_Search;
        private DevExpress.XtraEditors.SimpleButton btn_Search;
        private DevExpress.XtraBars.PopupControlContainer pcc_Search;
        private System.Windows.Forms.Panel panel_Container;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TimeSpanEdit tsTxt_Sample;
        private DevExpress.XtraBars.BarButtonItem barBtnItem_CompressionCurve;
        private DevExpress.XtraBars.PopupControlContainer pcc_CurveChange;
        private DevExpress.XtraEditors.SimpleButton btn_Curve_Save;
        private DevExpress.XtraEditors.SpinEdit txt_movePercentage;
        private System.Windows.Forms.Label lbl_CurveDesc;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_Curves;
        private DevExpress.XtraBars.BarButtonItem barBtnItem_ZoomCurve;
        private DevExpress.XtraBars.BarButtonItem barBtnItem_CurveMoveUp;
        private DevExpress.XtraBars.BarButtonItem barBtnItem_CurveMoveDown;
        private DevExpress.XtraBars.BarButtonItem barBtnItem_RestoreDefault;
    }
}
