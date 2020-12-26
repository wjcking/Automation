namespace Sinowyde.DOP.DataModel.Control.Frms
{
    partial class From_TempVariable
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.column_Device = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_VariableType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_DirectionType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_MaxPeriod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_IsTransfer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_CompressRatio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_IsCompressed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_Unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_Number = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gv_CalcVariabel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.column_DataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_CalcVariable = new DevExpress.XtraGrid.GridControl();
            this.cmb_DataType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_VariableType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_device = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_IsTransfer = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_IsCompressed = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.txt_MaxPeriod = new DevExpress.XtraEditors.SpinEdit();
            this.txt_CompressRatio = new DevExpress.XtraEditors.SpinEdit();
            this.txt_Unit = new DevExpress.XtraEditors.TextEdit();
            this.txt_Name = new DevExpress.XtraEditors.TextEdit();
            this.txt_Number = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_VariableType = new DevExpress.XtraEditors.LabelControl();
            this.lbl_MaxPeriod = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_CompressRatio = new DevExpress.XtraEditors.LabelControl();
            this.lbl_IsCompressed = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Unit = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gv_CalcVariabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_CalcVariable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_DataType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_VariableType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_device.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IsTransfer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IsCompressed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MaxPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CompressRatio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Unit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Number.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // column_Device
            // 
            this.column_Device.Caption = "设备";
            this.column_Device.FieldName = "Device.Name";
            this.column_Device.Name = "column_Device";
            this.column_Device.Visible = true;
            this.column_Device.VisibleIndex = 10;
            // 
            // column_VariableType
            // 
            this.column_VariableType.Caption = "变量类型";
            this.column_VariableType.FieldName = "VariableType";
            this.column_VariableType.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.column_VariableType.Name = "column_VariableType";
            this.column_VariableType.Visible = true;
            this.column_VariableType.VisibleIndex = 9;
            // 
            // column_DirectionType
            // 
            this.column_DirectionType.Caption = "采集类型";
            this.column_DirectionType.FieldName = "DirectionType";
            this.column_DirectionType.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.column_DirectionType.Name = "column_DirectionType";
            this.column_DirectionType.Visible = true;
            this.column_DirectionType.VisibleIndex = 7;
            // 
            // column_MaxPeriod
            // 
            this.column_MaxPeriod.Caption = "最大存储周期";
            this.column_MaxPeriod.FieldName = "MaxPeriod";
            this.column_MaxPeriod.Name = "column_MaxPeriod";
            this.column_MaxPeriod.Visible = true;
            this.column_MaxPeriod.VisibleIndex = 6;
            // 
            // column_IsTransfer
            // 
            this.column_IsTransfer.Caption = "是否上传";
            this.column_IsTransfer.FieldName = "IsTransfer";
            this.column_IsTransfer.Name = "column_IsTransfer";
            this.column_IsTransfer.Visible = true;
            this.column_IsTransfer.VisibleIndex = 5;
            // 
            // column_CompressRatio
            // 
            this.column_CompressRatio.Caption = "压缩率";
            this.column_CompressRatio.FieldName = "CompressRatio";
            this.column_CompressRatio.Name = "column_CompressRatio";
            this.column_CompressRatio.Visible = true;
            this.column_CompressRatio.VisibleIndex = 4;
            // 
            // column_IsCompressed
            // 
            this.column_IsCompressed.Caption = "是否压缩";
            this.column_IsCompressed.FieldName = "IsCompressed";
            this.column_IsCompressed.Name = "column_IsCompressed";
            this.column_IsCompressed.OptionsColumn.AllowEdit = false;
            this.column_IsCompressed.OptionsColumn.AllowFocus = false;
            this.column_IsCompressed.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.column_IsCompressed.OptionsColumn.AllowMove = false;
            this.column_IsCompressed.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.column_IsCompressed.OptionsColumn.ReadOnly = true;
            this.column_IsCompressed.Visible = true;
            this.column_IsCompressed.VisibleIndex = 3;
            // 
            // column_Unit
            // 
            this.column_Unit.Caption = "单位";
            this.column_Unit.FieldName = "Unit";
            this.column_Unit.Name = "column_Unit";
            this.column_Unit.Visible = true;
            this.column_Unit.VisibleIndex = 2;
            // 
            // column_Name
            // 
            this.column_Name.Caption = "中文名称";
            this.column_Name.FieldName = "Name";
            this.column_Name.Name = "column_Name";
            this.column_Name.Visible = true;
            this.column_Name.VisibleIndex = 1;
            // 
            // column_Number
            // 
            this.column_Number.Caption = "名称";
            this.column_Number.FieldName = "Number";
            this.column_Number.Name = "column_Number";
            this.column_Number.OptionsColumn.AllowMove = false;
            this.column_Number.OptionsColumn.AllowShowHide = false;
            this.column_Number.Visible = true;
            this.column_Number.VisibleIndex = 0;
            // 
            // column_ID
            // 
            this.column_ID.Caption = "编号";
            this.column_ID.Name = "column_ID";
            this.column_ID.OptionsColumn.AllowEdit = false;
            this.column_ID.OptionsColumn.AllowFocus = false;
            this.column_ID.OptionsColumn.AllowMove = false;
            // 
            // gv_CalcVariabel
            // 
            this.gv_CalcVariabel.ActiveFilterEnabled = false;
            this.gv_CalcVariabel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gv_CalcVariabel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.column_ID,
            this.column_Number,
            this.column_Name,
            this.column_Unit,
            this.column_IsCompressed,
            this.column_CompressRatio,
            this.column_IsTransfer,
            this.column_MaxPeriod,
            this.column_DirectionType,
            this.column_VariableType,
            this.column_DataType,
            this.column_Device});
            this.gv_CalcVariabel.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gv_CalcVariabel.GridControl = this.gc_CalcVariable;
            this.gv_CalcVariabel.Name = "gv_CalcVariabel";
            this.gv_CalcVariabel.OptionsBehavior.AutoPopulateColumns = false;
            this.gv_CalcVariabel.OptionsBehavior.Editable = false;
            this.gv_CalcVariabel.OptionsCustomization.AllowColumnMoving = false;
            this.gv_CalcVariabel.OptionsCustomization.AllowFilter = false;
            this.gv_CalcVariabel.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gv_CalcVariabel.OptionsFilter.AllowFilterEditor = false;
            this.gv_CalcVariabel.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.gv_CalcVariabel.OptionsFilter.AllowMRUFilterList = false;
            this.gv_CalcVariabel.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
            this.gv_CalcVariabel.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv_CalcVariabel.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gv_CalcVariabel.OptionsView.ShowGroupPanel = false;
            this.gv_CalcVariabel.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gv_CalcVariabel_PopupMenuShowing);
            this.gv_CalcVariabel.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.gv_CalcVariabel_CustomDrawEmptyForeground);
            this.gv_CalcVariabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gc_CalcVariable_MouseDown);
            // 
            // column_DataType
            // 
            this.column_DataType.Caption = "数据类型";
            this.column_DataType.FieldName = "DataType";
            this.column_DataType.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.column_DataType.Name = "column_DataType";
            this.column_DataType.Visible = true;
            this.column_DataType.VisibleIndex = 8;
            // 
            // gc_CalcVariable
            // 
            this.gc_CalcVariable.Location = new System.Drawing.Point(2, 7);
            this.gc_CalcVariable.MainView = this.gv_CalcVariabel;
            this.gc_CalcVariable.Name = "gc_CalcVariable";
            this.gc_CalcVariable.Size = new System.Drawing.Size(844, 339);
            this.gc_CalcVariable.TabIndex = 93;
            this.gc_CalcVariable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_CalcVariabel});
            // 
            // cmb_DataType
            // 
            this.cmb_DataType.Location = new System.Drawing.Point(404, 388);
            this.cmb_DataType.Name = "cmb_DataType";
            this.cmb_DataType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_DataType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_DataType.Size = new System.Drawing.Size(108, 20);
            this.cmb_DataType.TabIndex = 92;
            // 
            // cmb_VariableType
            // 
            this.cmb_VariableType.Location = new System.Drawing.Point(569, 388);
            this.cmb_VariableType.Name = "cmb_VariableType";
            this.cmb_VariableType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_VariableType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_VariableType.Size = new System.Drawing.Size(108, 20);
            this.cmb_VariableType.TabIndex = 91;
            // 
            // cmb_device
            // 
            this.cmb_device.Location = new System.Drawing.Point(569, 352);
            this.cmb_device.Name = "cmb_device";
            this.cmb_device.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_device.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_device.Size = new System.Drawing.Size(108, 20);
            this.cmb_device.TabIndex = 90;
            // 
            // cmb_IsTransfer
            // 
            this.cmb_IsTransfer.EditValue = "否";
            this.cmb_IsTransfer.Location = new System.Drawing.Point(734, 352);
            this.cmb_IsTransfer.Name = "cmb_IsTransfer";
            this.cmb_IsTransfer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_IsTransfer.Properties.Items.AddRange(new object[] {
            "否",
            "是"});
            this.cmb_IsTransfer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_IsTransfer.Size = new System.Drawing.Size(108, 20);
            this.cmb_IsTransfer.TabIndex = 89;
            // 
            // cmb_IsCompressed
            // 
            this.cmb_IsCompressed.EditValue = "否";
            this.cmb_IsCompressed.Location = new System.Drawing.Point(64, 388);
            this.cmb_IsCompressed.Name = "cmb_IsCompressed";
            this.cmb_IsCompressed.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_IsCompressed.Properties.Items.AddRange(new object[] {
            "否",
            "是"});
            this.cmb_IsCompressed.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_IsCompressed.Size = new System.Drawing.Size(108, 20);
            this.cmb_IsCompressed.TabIndex = 88;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(767, 421);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 87;
            this.btn_Close.Text = "清空";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(675, 421);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 86;
            this.btn_Save.Text = "新增";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_MaxPeriod
            // 
            this.txt_MaxPeriod.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_MaxPeriod.Location = new System.Drawing.Point(783, 388);
            this.txt_MaxPeriod.Name = "txt_MaxPeriod";
            this.txt_MaxPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_MaxPeriod.Properties.Mask.EditMask = "n0";
            this.txt_MaxPeriod.Properties.MaxLength = 10;
            this.txt_MaxPeriod.Size = new System.Drawing.Size(59, 20);
            this.txt_MaxPeriod.TabIndex = 78;
            // 
            // txt_CompressRatio
            // 
            this.txt_CompressRatio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_CompressRatio.Location = new System.Drawing.Point(239, 388);
            this.txt_CompressRatio.Name = "txt_CompressRatio";
            this.txt_CompressRatio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_CompressRatio.Properties.MaxLength = 6;
            this.txt_CompressRatio.Size = new System.Drawing.Size(108, 20);
            this.txt_CompressRatio.TabIndex = 77;
            // 
            // txt_Unit
            // 
            this.txt_Unit.EditValue = "";
            this.txt_Unit.Location = new System.Drawing.Point(404, 352);
            this.txt_Unit.Name = "txt_Unit";
            this.txt_Unit.Properties.MaxLength = 50;
            this.txt_Unit.Size = new System.Drawing.Size(108, 20);
            this.txt_Unit.TabIndex = 76;
            // 
            // txt_Name
            // 
            this.txt_Name.EditValue = "";
            this.txt_Name.Location = new System.Drawing.Point(239, 352);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Properties.MaxLength = 50;
            this.txt_Name.Size = new System.Drawing.Size(108, 20);
            this.txt_Name.TabIndex = 71;
            // 
            // txt_Number
            // 
            this.txt_Number.EditValue = "";
            this.txt_Number.Location = new System.Drawing.Point(64, 352);
            this.txt_Number.Name = "txt_Number";
            this.txt_Number.Properties.MaxLength = 50;
            this.txt_Number.Size = new System.Drawing.Size(108, 20);
            this.txt_Number.TabIndex = 72;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(349, 391);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 84;
            this.labelControl1.Text = "数据类型：";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(514, 355);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 14);
            this.labelControl7.TabIndex = 85;
            this.labelControl7.Text = "所属设备：";
            // 
            // lbl_VariableType
            // 
            this.lbl_VariableType.Location = new System.Drawing.Point(514, 391);
            this.lbl_VariableType.Name = "lbl_VariableType";
            this.lbl_VariableType.Size = new System.Drawing.Size(60, 14);
            this.lbl_VariableType.TabIndex = 83;
            this.lbl_VariableType.Text = "变量类型：";
            // 
            // lbl_MaxPeriod
            // 
            this.lbl_MaxPeriod.Location = new System.Drawing.Point(679, 391);
            this.lbl_MaxPeriod.Name = "lbl_MaxPeriod";
            this.lbl_MaxPeriod.Size = new System.Drawing.Size(109, 14);
            this.lbl_MaxPeriod.TabIndex = 82;
            this.lbl_MaxPeriod.Text = "最大存储周期(ms)：";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(679, 355);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(60, 14);
            this.labelControl11.TabIndex = 81;
            this.labelControl11.Text = "是否上传：";
            // 
            // lbl_CompressRatio
            // 
            this.lbl_CompressRatio.Location = new System.Drawing.Point(174, 391);
            this.lbl_CompressRatio.Name = "lbl_CompressRatio";
            this.lbl_CompressRatio.Size = new System.Drawing.Size(70, 14);
            this.lbl_CompressRatio.TabIndex = 80;
            this.lbl_CompressRatio.Text = "压缩率(%)：";
            // 
            // lbl_IsCompressed
            // 
            this.lbl_IsCompressed.Location = new System.Drawing.Point(9, 391);
            this.lbl_IsCompressed.Name = "lbl_IsCompressed";
            this.lbl_IsCompressed.Size = new System.Drawing.Size(60, 14);
            this.lbl_IsCompressed.TabIndex = 79;
            this.lbl_IsCompressed.Text = "是否压缩：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(184, 355);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 75;
            this.labelControl3.Text = "中文名称：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 355);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 74;
            this.labelControl2.Text = "点名：";
            // 
            // lbl_Unit
            // 
            this.lbl_Unit.Location = new System.Drawing.Point(373, 355);
            this.lbl_Unit.Name = "lbl_Unit";
            this.lbl_Unit.Size = new System.Drawing.Size(36, 14);
            this.lbl_Unit.TabIndex = 73;
            this.lbl_Unit.Text = "单位：";
            // 
            // From_TempVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 451);
            this.Controls.Add(this.gc_CalcVariable);
            this.Controls.Add(this.cmb_DataType);
            this.Controls.Add(this.cmb_VariableType);
            this.Controls.Add(this.cmb_device);
            this.Controls.Add(this.cmb_IsTransfer);
            this.Controls.Add(this.cmb_IsCompressed);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_MaxPeriod);
            this.Controls.Add(this.txt_CompressRatio);
            this.Controls.Add(this.txt_Unit);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.txt_Number);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.lbl_VariableType);
            this.Controls.Add(this.lbl_MaxPeriod);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.lbl_CompressRatio);
            this.Controls.Add(this.lbl_IsCompressed);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lbl_Unit);
            this.Name = "From_TempVariable";
            this.Text = "中间变量";
            ((System.ComponentModel.ISupportInitialize)(this.gv_CalcVariabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_CalcVariable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_DataType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_VariableType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_device.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IsTransfer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IsCompressed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MaxPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CompressRatio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Unit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Number.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn column_Device;
        private DevExpress.XtraGrid.Columns.GridColumn column_VariableType;
        private DevExpress.XtraGrid.Columns.GridColumn column_DirectionType;
        private DevExpress.XtraGrid.Columns.GridColumn column_MaxPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn column_IsTransfer;
        private DevExpress.XtraGrid.Columns.GridColumn column_CompressRatio;
        private DevExpress.XtraGrid.Columns.GridColumn column_IsCompressed;
        private DevExpress.XtraGrid.Columns.GridColumn column_Unit;
        private DevExpress.XtraGrid.Columns.GridColumn column_Name;
        private DevExpress.XtraGrid.Columns.GridColumn column_Number;
        private DevExpress.XtraGrid.Columns.GridColumn column_ID;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_CalcVariabel;
        private DevExpress.XtraGrid.Columns.GridColumn column_DataType;
        private DevExpress.XtraGrid.GridControl gc_CalcVariable;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_DataType;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_VariableType;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_device;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_IsTransfer;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_IsCompressed;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SpinEdit txt_MaxPeriod;
        private DevExpress.XtraEditors.SpinEdit txt_CompressRatio;
        private DevExpress.XtraEditors.TextEdit txt_Unit;
        private DevExpress.XtraEditors.TextEdit txt_Name;
        private DevExpress.XtraEditors.TextEdit txt_Number;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl lbl_VariableType;
        private DevExpress.XtraEditors.LabelControl lbl_MaxPeriod;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl lbl_CompressRatio;
        private DevExpress.XtraEditors.LabelControl lbl_IsCompressed;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lbl_Unit;
    }
}