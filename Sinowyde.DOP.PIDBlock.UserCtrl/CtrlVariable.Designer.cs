namespace Sinowyde.DOP.PIDBlock.UserCtrl
{
    partial class CtrlVariable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlVariable));
            this.txtVariableName = new DevExpress.XtraEditors.TextEdit();
            this.cmbDevices = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gc_Variables = new DevExpress.XtraGrid.GridControl();
            this.gv_Variabels = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.column_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_Number = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_DeviceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_DirectionType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel_Top = new DevExpress.XtraEditors.PanelControl();
            this.panel_Bottom = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_loading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtVariableName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDevices.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Variables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Variabels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_Top)).BeginInit();
            this.panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel_Bottom)).BeginInit();
            this.panel_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtVariableName
            // 
            this.txtVariableName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtVariableName.EditValue = "";
            this.txtVariableName.Location = new System.Drawing.Point(135, 0);
            this.txtVariableName.Name = "txtVariableName";
            this.txtVariableName.Properties.Appearance.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtVariableName.Properties.Appearance.Options.UseForeColor = true;
            this.txtVariableName.Size = new System.Drawing.Size(203, 20);
            this.txtVariableName.TabIndex = 2;
            this.txtVariableName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtVariableName_KeyUp);
            // 
            // cmbDevices
            // 
            this.cmbDevices.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbDevices.Location = new System.Drawing.Point(1, 0);
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDevices.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbDevices.Size = new System.Drawing.Size(124, 20);
            this.cmbDevices.TabIndex = 5;
            this.cmbDevices.SelectedIndexChanged += new System.EventHandler(this.cmbDevices_SelectedIndexChanged);
            // 
            // gc_Variables
            // 
            this.gc_Variables.Location = new System.Drawing.Point(2, 4);
            this.gc_Variables.MainView = this.gv_Variabels;
            this.gc_Variables.Name = "gc_Variables";
            this.gc_Variables.Size = new System.Drawing.Size(336, 102);
            this.gc_Variables.TabIndex = 6;
            this.gc_Variables.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Variabels});
            // 
            // gv_Variabels
            // 
            this.gv_Variabels.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.column_ID,
            this.column_Name,
            this.column_Number,
            this.column_DeviceName,
            this.column_DirectionType});
            this.gv_Variabels.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gv_Variabels.GridControl = this.gc_Variables;
            this.gv_Variabels.Name = "gv_Variabels";
            this.gv_Variabels.OptionsBehavior.Editable = false;
            this.gv_Variabels.OptionsCustomization.AllowColumnMoving = false;
            this.gv_Variabels.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gv_Variabels.OptionsFilter.AllowFilterEditor = false;
            this.gv_Variabels.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.gv_Variabels.OptionsFilter.AllowMRUFilterList = false;
            this.gv_Variabels.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
            this.gv_Variabels.OptionsFilter.FilterEditorUseMenuForOperandsAndOperators = false;
            this.gv_Variabels.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = false;
            this.gv_Variabels.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv_Variabels.OptionsView.ShowGroupPanel = false;
            this.gv_Variabels.OptionsView.ShowIndicator = false;
            this.gv_Variabels.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gv_Variabels_RowClick);
            this.gv_Variabels.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gv_Variabels_PopupMenuShowing);
            this.gv_Variabels.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gv_Variabels_CustomColumnDisplayText);
            // 
            // column_ID
            // 
            this.column_ID.Caption = "编号";
            this.column_ID.FieldName = "ID";
            this.column_ID.Name = "column_ID";
            // 
            // column_Name
            // 
            this.column_Name.Caption = "变量";
            this.column_Name.FieldName = "Number";
            this.column_Name.Name = "column_Name";
            this.column_Name.OptionsColumn.AllowEdit = false;
            this.column_Name.OptionsColumn.AllowIncrementalSearch = false;
            this.column_Name.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.column_Name.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.column_Name.OptionsColumn.ReadOnly = true;
            this.column_Name.OptionsFilter.AllowAutoFilter = false;
            this.column_Name.OptionsFilter.AllowFilter = false;
            this.column_Name.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.column_Name.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.column_Name.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.column_Name.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.column_Name.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.column_Name.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.column_Name.Visible = true;
            this.column_Name.VisibleIndex = 0;
            // 
            // column_Number
            // 
            this.column_Number.Caption = "中文名称";
            this.column_Number.FieldName = "Name";
            this.column_Number.Name = "column_Number";
            this.column_Number.OptionsColumn.AllowEdit = false;
            this.column_Number.OptionsColumn.AllowIncrementalSearch = false;
            this.column_Number.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.column_Number.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.column_Number.OptionsColumn.ReadOnly = true;
            this.column_Number.OptionsFilter.AllowAutoFilter = false;
            this.column_Number.OptionsFilter.AllowFilter = false;
            this.column_Number.Visible = true;
            this.column_Number.VisibleIndex = 1;
            // 
            // column_DeviceName
            // 
            this.column_DeviceName.Caption = "设备名称";
            this.column_DeviceName.FieldName = "Device.Name";
            this.column_DeviceName.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.column_DeviceName.Name = "column_DeviceName";
            this.column_DeviceName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.column_DeviceName.OptionsColumn.ReadOnly = true;
            this.column_DeviceName.OptionsFilter.AllowAutoFilter = false;
            this.column_DeviceName.OptionsFilter.AllowFilter = false;
            this.column_DeviceName.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.column_DeviceName.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.column_DeviceName.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.column_DeviceName.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.column_DeviceName.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.column_DeviceName.Visible = true;
            this.column_DeviceName.VisibleIndex = 2;
            // 
            // column_DirectionType
            // 
            this.column_DirectionType.Caption = "类型";
            this.column_DirectionType.FieldName = "DirectionType";
            this.column_DirectionType.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.column_DirectionType.Name = "column_DirectionType";
            this.column_DirectionType.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.column_DirectionType.OptionsColumn.ReadOnly = true;
            this.column_DirectionType.OptionsFilter.AllowAutoFilter = false;
            this.column_DirectionType.OptionsFilter.AllowFilter = false;
            this.column_DirectionType.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.column_DirectionType.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.column_DirectionType.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.column_DirectionType.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.column_DirectionType.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.column_DirectionType.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.False;
            this.column_DirectionType.Visible = true;
            this.column_DirectionType.VisibleIndex = 3;
            // 
            // panel_Top
            // 
            this.panel_Top.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel_Top.Controls.Add(this.cmbDevices);
            this.panel_Top.Controls.Add(this.txtVariableName);
            this.panel_Top.Location = new System.Drawing.Point(0, 5);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(340, 24);
            this.panel_Top.TabIndex = 7;
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel_Bottom.Controls.Add(this.labelControl1);
            this.panel_Bottom.Controls.Add(this.gc_Variables);
            this.panel_Bottom.Controls.Add(this.lbl_loading);
            this.panel_Bottom.Location = new System.Drawing.Point(2, 31);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(336, 140);
            this.panel_Bottom.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 115);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "请选择变量";
            // 
            // lbl_loading
            // 
            this.lbl_loading.BackColor = System.Drawing.Color.Transparent;
            this.lbl_loading.Image = ((System.Drawing.Image)(resources.GetObject("lbl_loading.Image")));
            this.lbl_loading.Location = new System.Drawing.Point(133, -3);
            this.lbl_loading.Name = "lbl_loading";
            this.lbl_loading.Size = new System.Drawing.Size(16, 16);
            this.lbl_loading.TabIndex = 7;
            this.lbl_loading.Visible = false;
            // 
            // CtrlVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_Bottom);
            this.Controls.Add(this.panel_Top);
            this.Name = "CtrlVariable";
            this.Size = new System.Drawing.Size(340, 177);
            this.Load += new System.EventHandler(this.CtrlPointPicker_Load);
            this.VisibleChanged += new System.EventHandler(this.CtrlVariable_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.txtVariableName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDevices.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Variables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Variabels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_Top)).EndInit();
            this.panel_Top.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel_Bottom)).EndInit();
            this.panel_Bottom.ResumeLayout(false);
            this.panel_Bottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtVariableName;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDevices;
        private DevExpress.XtraGrid.GridControl gc_Variables;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Variabels;
        private DevExpress.XtraGrid.Columns.GridColumn column_ID;
        private DevExpress.XtraGrid.Columns.GridColumn column_Name;
        private DevExpress.XtraGrid.Columns.GridColumn column_DeviceName;
        private DevExpress.XtraEditors.PanelControl panel_Top;
        private DevExpress.XtraEditors.PanelControl panel_Bottom;
        private DevExpress.XtraGrid.Columns.GridColumn column_DirectionType;
        private System.Windows.Forms.Label lbl_loading;
        private DevExpress.XtraGrid.Columns.GridColumn column_Number;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
