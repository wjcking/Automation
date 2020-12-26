namespace Sinowyde.DOP.Trend.Control
{
    partial class UserCtrlRtTrend
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
            this.barBtnItem_CompressedDate = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnItem_CompressionCurve = new DevExpress.XtraBars.BarButtonItem();
            this.pcc_CurveChange = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.btn_Curve_Save = new DevExpress.XtraEditors.SimpleButton();
            this.txt_movePercentage = new DevExpress.XtraEditors.SpinEdit();
            this.lbl_CurveDesc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Curves = new DevExpress.XtraEditors.ComboBoxEdit();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.batBtnItem_CurveConfig = new DevExpress.XtraBars.BarButtonItem();
            this.pcc_CurveConfig = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.batBtnItem_CurveConfig_Save = new DevExpress.XtraEditors.SimpleButton();
            this.txt_LastValueDate = new DevExpress.XtraEditors.SpinEdit();
            this.txt_PollingPeriod = new DevExpress.XtraEditors.SpinEdit();
            this.cmb_ShowAxisX = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_ShowAxisY = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_RealTimeValue = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbl_RealTimeCurveRange = new DevExpress.XtraEditors.LabelControl();
            this.lbl_ShowAxisX = new DevExpress.XtraEditors.LabelControl();
            this.cmb_RealTimeCurveRange = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbl_ShowAxisY = new DevExpress.XtraEditors.LabelControl();
            this.lbl_RealTimeValue = new DevExpress.XtraEditors.LabelControl();
            this.lbl_LastValueDate = new DevExpress.XtraEditors.LabelControl();
            this.lbl_PollingPeriod = new DevExpress.XtraEditors.LabelControl();
            this.batBtnItem_VariableConfig = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnItem_ZoomDate = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnItem_ZoomCurve = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnItem_CurveMoveUp = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnItem_CurveMoveDown = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnItem_Freeze = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnItem_RestoreDefault = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.chartControl = new Sinowyde.DOP.Trend.Control.ChartEx();
            ((System.ComponentModel.ISupportInitialize)(this.pcc_CurveChange)).BeginInit();
            this.pcc_CurveChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_movePercentage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Curves.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcc_CurveConfig)).BeginInit();
            this.pcc_CurveConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LastValueDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PollingPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_ShowAxisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_ShowAxisY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_RealTimeValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_RealTimeCurveRange.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barBtnItem_CompressedDate
            // 
            this.barBtnItem_CompressedDate.Caption = "压缩时间";
            this.barBtnItem_CompressedDate.Id = 59;
            this.barBtnItem_CompressedDate.Name = "barBtnItem_CompressedDate";
            this.barBtnItem_CompressedDate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnItem_CompressedDate_ItemClick);
            // 
            // barBtnItem_CompressionCurve
            // 
            this.barBtnItem_CompressionCurve.ActAsDropDown = true;
            this.barBtnItem_CompressionCurve.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barBtnItem_CompressionCurve.Caption = "压缩曲线";
            this.barBtnItem_CompressionCurve.DropDownControl = this.pcc_CurveChange;
            this.barBtnItem_CompressionCurve.Id = 55;
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
            this.pcc_CurveChange.Location = new System.Drawing.Point(288, 86);
            this.pcc_CurveChange.Manager = this.barManager;
            this.pcc_CurveChange.Name = "pcc_CurveChange";
            this.pcc_CurveChange.Size = new System.Drawing.Size(194, 91);
            this.pcc_CurveChange.TabIndex = 18;
            this.pcc_CurveChange.Visible = false;
            this.pcc_CurveChange.Popup += new System.EventHandler(this.pcc_CurveChange_Popup);
            this.pcc_CurveChange.Click += new System.EventHandler(this.pcc_CurveChange_Popup);
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
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.batBtnItem_CurveConfig,
            this.batBtnItem_VariableConfig,
            this.barBtnItem_CompressionCurve,
            this.barBtnItem_ZoomCurve,
            this.barBtnItem_CurveMoveUp,
            this.barBtnItem_CurveMoveDown,
            this.barBtnItem_CompressedDate,
            this.barBtnItem_ZoomDate,
            this.barBtnItem_Freeze,
            this.barBtnItem_RestoreDefault});
            this.barManager.MainMenu = this.bar1;
            this.barManager.MaxItemId = 71;
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.batBtnItem_CurveConfig),
            new DevExpress.XtraBars.LinkPersistInfo(this.batBtnItem_VariableConfig),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItem_CompressedDate),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItem_ZoomDate),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItem_CompressionCurve),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItem_ZoomCurve),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItem_CurveMoveUp),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItem_CurveMoveDown),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItem_Freeze),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnItem_RestoreDefault)});
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // batBtnItem_CurveConfig
            // 
            this.batBtnItem_CurveConfig.ActAsDropDown = true;
            this.batBtnItem_CurveConfig.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.batBtnItem_CurveConfig.Caption = "曲线配置";
            this.batBtnItem_CurveConfig.DropDownControl = this.pcc_CurveConfig;
            this.batBtnItem_CurveConfig.Id = 46;
            this.batBtnItem_CurveConfig.Name = "batBtnItem_CurveConfig";
            // 
            // pcc_CurveConfig
            // 
            this.pcc_CurveConfig.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcc_CurveConfig.Controls.Add(this.batBtnItem_CurveConfig_Save);
            this.pcc_CurveConfig.Controls.Add(this.txt_LastValueDate);
            this.pcc_CurveConfig.Controls.Add(this.txt_PollingPeriod);
            this.pcc_CurveConfig.Controls.Add(this.cmb_ShowAxisX);
            this.pcc_CurveConfig.Controls.Add(this.cmb_ShowAxisY);
            this.pcc_CurveConfig.Controls.Add(this.cmb_RealTimeValue);
            this.pcc_CurveConfig.Controls.Add(this.lbl_RealTimeCurveRange);
            this.pcc_CurveConfig.Controls.Add(this.lbl_ShowAxisX);
            this.pcc_CurveConfig.Controls.Add(this.cmb_RealTimeCurveRange);
            this.pcc_CurveConfig.Controls.Add(this.lbl_ShowAxisY);
            this.pcc_CurveConfig.Controls.Add(this.lbl_RealTimeValue);
            this.pcc_CurveConfig.Controls.Add(this.lbl_LastValueDate);
            this.pcc_CurveConfig.Controls.Add(this.lbl_PollingPeriod);
            this.pcc_CurveConfig.Location = new System.Drawing.Point(33, 64);
            this.pcc_CurveConfig.Manager = this.barManager;
            this.pcc_CurveConfig.Name = "pcc_CurveConfig";
            this.pcc_CurveConfig.Size = new System.Drawing.Size(215, 187);
            this.pcc_CurveConfig.TabIndex = 16;
            this.pcc_CurveConfig.Visible = false;
            this.pcc_CurveConfig.Popup += new System.EventHandler(this.pcc_CurveConfig_Popup);
            this.pcc_CurveConfig.Click += new System.EventHandler(this.pcc_CurveConfig_Popup);
            // 
            // batBtnItem_CurveConfig_Save
            // 
            this.batBtnItem_CurveConfig_Save.Location = new System.Drawing.Point(107, 159);
            this.batBtnItem_CurveConfig_Save.Name = "batBtnItem_CurveConfig_Save";
            this.batBtnItem_CurveConfig_Save.Size = new System.Drawing.Size(100, 23);
            this.batBtnItem_CurveConfig_Save.TabIndex = 17;
            this.batBtnItem_CurveConfig_Save.Text = "设置";
            this.batBtnItem_CurveConfig_Save.Click += new System.EventHandler(this.batBtnItem_CurveConfig_Save_Click);
            // 
            // txt_LastValueDate
            // 
            this.txt_LastValueDate.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_LastValueDate.Location = new System.Drawing.Point(107, 57);
            this.txt_LastValueDate.Name = "txt_LastValueDate";
            this.txt_LastValueDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_LastValueDate.Properties.Mask.EditMask = "d";
            this.txt_LastValueDate.Size = new System.Drawing.Size(100, 20);
            this.txt_LastValueDate.TabIndex = 15;
            // 
            // txt_PollingPeriod
            // 
            this.txt_PollingPeriod.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_PollingPeriod.Location = new System.Drawing.Point(107, 31);
            this.txt_PollingPeriod.Name = "txt_PollingPeriod";
            this.txt_PollingPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_PollingPeriod.Properties.Mask.EditMask = "d";
            this.txt_PollingPeriod.Size = new System.Drawing.Size(100, 20);
            this.txt_PollingPeriod.TabIndex = 16;
            // 
            // cmb_ShowAxisX
            // 
            this.cmb_ShowAxisX.Location = new System.Drawing.Point(107, 109);
            this.cmb_ShowAxisX.Name = "cmb_ShowAxisX";
            this.cmb_ShowAxisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_ShowAxisX.Properties.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cmb_ShowAxisX.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_ShowAxisX.Size = new System.Drawing.Size(100, 20);
            this.cmb_ShowAxisX.TabIndex = 11;
            this.cmb_ShowAxisX.SelectedIndexChanged += new System.EventHandler(this.cmb_ShowAxisX_SelectedIndexChanged);
            // 
            // cmb_ShowAxisY
            // 
            this.cmb_ShowAxisY.Location = new System.Drawing.Point(107, 135);
            this.cmb_ShowAxisY.Name = "cmb_ShowAxisY";
            this.cmb_ShowAxisY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_ShowAxisY.Properties.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cmb_ShowAxisY.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_ShowAxisY.Size = new System.Drawing.Size(100, 20);
            this.cmb_ShowAxisY.TabIndex = 12;
            this.cmb_ShowAxisY.SelectedIndexChanged += new System.EventHandler(this.cmb_ShowAxisY_SelectedIndexChanged);
            // 
            // cmb_RealTimeValue
            // 
            this.cmb_RealTimeValue.Location = new System.Drawing.Point(107, 83);
            this.cmb_RealTimeValue.Name = "cmb_RealTimeValue";
            this.cmb_RealTimeValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_RealTimeValue.Properties.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cmb_RealTimeValue.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_RealTimeValue.Size = new System.Drawing.Size(100, 20);
            this.cmb_RealTimeValue.TabIndex = 13;
            this.cmb_RealTimeValue.SelectedIndexChanged += new System.EventHandler(this.cmb_RealTimeValue_SelectedIndexChanged);
            // 
            // lbl_RealTimeCurveRange
            // 
            this.lbl_RealTimeCurveRange.Location = new System.Drawing.Point(8, 8);
            this.lbl_RealTimeCurveRange.Name = "lbl_RealTimeCurveRange";
            this.lbl_RealTimeCurveRange.Size = new System.Drawing.Size(84, 14);
            this.lbl_RealTimeCurveRange.TabIndex = 5;
            this.lbl_RealTimeCurveRange.Text = "实时曲线范围：";
            // 
            // lbl_ShowAxisX
            // 
            this.lbl_ShowAxisX.Location = new System.Drawing.Point(8, 112);
            this.lbl_ShowAxisX.Name = "lbl_ShowAxisX";
            this.lbl_ShowAxisX.Size = new System.Drawing.Size(55, 14);
            this.lbl_ShowAxisX.TabIndex = 6;
            this.lbl_ShowAxisX.Text = "显示X轴：";
            // 
            // cmb_RealTimeCurveRange
            // 
            this.cmb_RealTimeCurveRange.Location = new System.Drawing.Point(107, 5);
            this.cmb_RealTimeCurveRange.Name = "cmb_RealTimeCurveRange";
            this.cmb_RealTimeCurveRange.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_RealTimeCurveRange.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_RealTimeCurveRange.Size = new System.Drawing.Size(100, 20);
            this.cmb_RealTimeCurveRange.TabIndex = 14;
            // 
            // lbl_ShowAxisY
            // 
            this.lbl_ShowAxisY.Location = new System.Drawing.Point(8, 138);
            this.lbl_ShowAxisY.Name = "lbl_ShowAxisY";
            this.lbl_ShowAxisY.Size = new System.Drawing.Size(56, 14);
            this.lbl_ShowAxisY.TabIndex = 7;
            this.lbl_ShowAxisY.Text = "显示Y轴：";
            // 
            // lbl_RealTimeValue
            // 
            this.lbl_RealTimeValue.Location = new System.Drawing.Point(8, 86);
            this.lbl_RealTimeValue.Name = "lbl_RealTimeValue";
            this.lbl_RealTimeValue.Size = new System.Drawing.Size(72, 14);
            this.lbl_RealTimeValue.TabIndex = 8;
            this.lbl_RealTimeValue.Text = "显示实时值：";
            // 
            // lbl_LastValueDate
            // 
            this.lbl_LastValueDate.Location = new System.Drawing.Point(8, 60);
            this.lbl_LastValueDate.Name = "lbl_LastValueDate";
            this.lbl_LastValueDate.Size = new System.Drawing.Size(96, 14);
            this.lbl_LastValueDate.TabIndex = 9;
            this.lbl_LastValueDate.Text = "时间间隔（秒）：";
            // 
            // lbl_PollingPeriod
            // 
            this.lbl_PollingPeriod.Location = new System.Drawing.Point(8, 34);
            this.lbl_PollingPeriod.Name = "lbl_PollingPeriod";
            this.lbl_PollingPeriod.Size = new System.Drawing.Size(96, 14);
            this.lbl_PollingPeriod.TabIndex = 10;
            this.lbl_PollingPeriod.Text = "刷新周期（秒）：";
            // 
            // batBtnItem_VariableConfig
            // 
            this.batBtnItem_VariableConfig.Caption = "变量配置";
            this.batBtnItem_VariableConfig.Id = 54;
            this.batBtnItem_VariableConfig.Name = "batBtnItem_VariableConfig";
            this.batBtnItem_VariableConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.batBtnItem_VariableConfig_ItemClick);
            // 
            // barBtnItem_ZoomDate
            // 
            this.barBtnItem_ZoomDate.Caption = "拉伸时间";
            this.barBtnItem_ZoomDate.Id = 60;
            this.barBtnItem_ZoomDate.Name = "barBtnItem_ZoomDate";
            this.barBtnItem_ZoomDate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnItem_ZoomDate_ItemClick);
            // 
            // barBtnItem_ZoomCurve
            // 
            this.barBtnItem_ZoomCurve.ActAsDropDown = true;
            this.barBtnItem_ZoomCurve.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barBtnItem_ZoomCurve.Caption = "放大曲线";
            this.barBtnItem_ZoomCurve.DropDownControl = this.pcc_CurveChange;
            this.barBtnItem_ZoomCurve.Id = 56;
            this.barBtnItem_ZoomCurve.Name = "barBtnItem_ZoomCurve";
            // 
            // barBtnItem_CurveMoveUp
            // 
            this.barBtnItem_CurveMoveUp.ActAsDropDown = true;
            this.barBtnItem_CurveMoveUp.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barBtnItem_CurveMoveUp.Caption = "曲线上移";
            this.barBtnItem_CurveMoveUp.DropDownControl = this.pcc_CurveChange;
            this.barBtnItem_CurveMoveUp.Id = 57;
            this.barBtnItem_CurveMoveUp.Name = "barBtnItem_CurveMoveUp";
            // 
            // barBtnItem_CurveMoveDown
            // 
            this.barBtnItem_CurveMoveDown.ActAsDropDown = true;
            this.barBtnItem_CurveMoveDown.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barBtnItem_CurveMoveDown.Caption = "曲线下移";
            this.barBtnItem_CurveMoveDown.DropDownControl = this.pcc_CurveChange;
            this.barBtnItem_CurveMoveDown.Id = 58;
            this.barBtnItem_CurveMoveDown.Name = "barBtnItem_CurveMoveDown";
            // 
            // barBtnItem_Freeze
            // 
            this.barBtnItem_Freeze.Caption = "冻结";
            this.barBtnItem_Freeze.Id = 61;
            this.barBtnItem_Freeze.Name = "barBtnItem_Freeze";
            this.barBtnItem_Freeze.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnItem_Freeze_ItemClick);
            // 
            // barBtnItem_RestoreDefault
            // 
            this.barBtnItem_RestoreDefault.Caption = "恢复默认";
            this.barBtnItem_RestoreDefault.Id = 66;
            this.barBtnItem_RestoreDefault.Name = "barBtnItem_RestoreDefault";
            this.barBtnItem_RestoreDefault.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnItem_RestoreDefault_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(810, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 314);
            this.barDockControlBottom.Size = new System.Drawing.Size(810, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 290);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(810, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 290);
            // 
            // chartControl
            // 
            this.chartControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartControl.CurveConfig_ShowAxisX = false;
            this.chartControl.CurveConfig_ShowAxisY = false;
            this.chartControl.CurveConfig_ShowRealValue = false;
            this.chartControl.Location = new System.Drawing.Point(3, 30);
            this.chartControl.Name = "chartControl";
            this.chartControl.Size = new System.Drawing.Size(804, 281);
            this.chartControl.TabIndex = 23;
            // 
            // UserCtrlRtTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pcc_CurveConfig);
            this.Controls.Add(this.pcc_CurveChange);
            this.Controls.Add(this.chartControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "UserCtrlRtTrend";
            this.Size = new System.Drawing.Size(810, 314);
            this.Load += new System.EventHandler(this.UserCtrlRtTrend_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcc_CurveChange)).EndInit();
            this.pcc_CurveChange.ResumeLayout(false);
            this.pcc_CurveChange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_movePercentage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Curves.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcc_CurveConfig)).EndInit();
            this.pcc_CurveConfig.ResumeLayout(false);
            this.pcc_CurveConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LastValueDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PollingPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_ShowAxisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_ShowAxisY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_RealTimeValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_RealTimeCurveRange.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarButtonItem barBtnItem_CompressedDate;
        private DevExpress.XtraBars.BarButtonItem barBtnItem_CompressionCurve;
        private DevExpress.XtraBars.PopupControlContainer pcc_CurveChange;
        private DevExpress.XtraEditors.SimpleButton btn_Curve_Save;
        private DevExpress.XtraEditors.SpinEdit txt_movePercentage;
        private System.Windows.Forms.Label lbl_CurveDesc;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_Curves;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem batBtnItem_CurveConfig;
        private DevExpress.XtraBars.PopupControlContainer pcc_CurveConfig;
        private DevExpress.XtraEditors.SimpleButton batBtnItem_CurveConfig_Save;
        private DevExpress.XtraEditors.SpinEdit txt_LastValueDate;
        private DevExpress.XtraEditors.SpinEdit txt_PollingPeriod;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_ShowAxisX;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_ShowAxisY;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_RealTimeValue;
        private DevExpress.XtraEditors.LabelControl lbl_RealTimeCurveRange;
        private DevExpress.XtraEditors.LabelControl lbl_ShowAxisX;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_RealTimeCurveRange;
        private DevExpress.XtraEditors.LabelControl lbl_ShowAxisY;
        private DevExpress.XtraEditors.LabelControl lbl_RealTimeValue;
        private DevExpress.XtraEditors.LabelControl lbl_LastValueDate;
        private DevExpress.XtraEditors.LabelControl lbl_PollingPeriod;
        private DevExpress.XtraBars.BarButtonItem batBtnItem_VariableConfig;
        private DevExpress.XtraBars.BarButtonItem barBtnItem_ZoomDate;
        private DevExpress.XtraBars.BarButtonItem barBtnItem_ZoomCurve;
        private DevExpress.XtraBars.BarButtonItem barBtnItem_CurveMoveUp;
        private DevExpress.XtraBars.BarButtonItem barBtnItem_CurveMoveDown;
        private DevExpress.XtraBars.BarButtonItem barBtnItem_Freeze;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barBtnItem_RestoreDefault;
        private ChartEx chartControl;

    }
}
