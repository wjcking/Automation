namespace Sinowyde.DOP.DataModel.Control
{
    partial class Form_ServiceCfg
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Address = new DevExpress.XtraEditors.TextEdit();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.gc_ServiceCfg = new DevExpress.XtraGrid.GridControl();
            this.gv_ServiceCfg = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ServiceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmb_ServiceType = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Address.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_ServiceCfg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_ServiceCfg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_ServiceType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "名称：";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(46, 8);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(127, 20);
            this.txt_Name.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(339, 11);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "地址：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(176, 11);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "类型：";
            // 
            // txt_Address
            // 
            this.txt_Address.Location = new System.Drawing.Point(378, 8);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(122, 20);
            this.txt_Address.TabIndex = 1;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(506, 7);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "保存";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // gc_ServiceCfg
            // 
            this.gc_ServiceCfg.Location = new System.Drawing.Point(7, 35);
            this.gc_ServiceCfg.MainView = this.gv_ServiceCfg;
            this.gc_ServiceCfg.Name = "gc_ServiceCfg";
            this.gc_ServiceCfg.Size = new System.Drawing.Size(574, 303);
            this.gc_ServiceCfg.TabIndex = 4;
            this.gc_ServiceCfg.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_ServiceCfg});
            // 
            // gv_ServiceCfg
            // 
            this.gv_ServiceCfg.ActiveFilterEnabled = false;
            this.gv_ServiceCfg.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ID,
            this.col_Name,
            this.col_ServiceType,
            this.col_Address});
            this.gv_ServiceCfg.GridControl = this.gc_ServiceCfg;
            this.gv_ServiceCfg.Name = "gv_ServiceCfg";
            this.gv_ServiceCfg.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gv_ServiceCfg.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gv_ServiceCfg.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.gv_ServiceCfg.OptionsBehavior.AutoPopulateColumns = false;
            this.gv_ServiceCfg.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gv_ServiceCfg.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.gv_ServiceCfg.OptionsBehavior.Editable = false;
            this.gv_ServiceCfg.OptionsBehavior.ReadOnly = true;
            this.gv_ServiceCfg.OptionsCustomization.AllowColumnMoving = false;
            this.gv_ServiceCfg.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gv_ServiceCfg.OptionsFilter.AllowFilterEditor = false;
            this.gv_ServiceCfg.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.gv_ServiceCfg.OptionsFilter.AllowMRUFilterList = false;
            this.gv_ServiceCfg.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
            this.gv_ServiceCfg.OptionsFilter.FilterEditorUseMenuForOperandsAndOperators = false;
            this.gv_ServiceCfg.OptionsHint.ShowCellHints = false;
            this.gv_ServiceCfg.OptionsHint.ShowColumnHeaderHints = false;
            this.gv_ServiceCfg.OptionsHint.ShowFooterHints = false;
            this.gv_ServiceCfg.OptionsView.ShowGroupPanel = false;
            this.gv_ServiceCfg.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.None;
            this.gv_ServiceCfg.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gv_ServiceCfg_PopupMenuShowing);
            this.gv_ServiceCfg.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.gv_ServiceCfg_CustomDrawEmptyForeground);
            this.gv_ServiceCfg.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gv_ServiceCfg_CustomColumnDisplayText);
            // 
            // col_ID
            // 
            this.col_ID.Caption = "ID";
            this.col_ID.FieldName = "ID";
            this.col_ID.Name = "col_ID";
            // 
            // col_Name
            // 
            this.col_Name.Caption = "服务名称";
            this.col_Name.FieldName = "Name";
            this.col_Name.Name = "col_Name";
            this.col_Name.OptionsColumn.AllowEdit = false;
            this.col_Name.OptionsColumn.AllowFocus = false;
            this.col_Name.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.col_Name.OptionsColumn.AllowIncrementalSearch = false;
            this.col_Name.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.col_Name.OptionsColumn.AllowMove = false;
            this.col_Name.OptionsColumn.AllowShowHide = false;
            this.col_Name.OptionsColumn.AllowSize = false;
            this.col_Name.OptionsColumn.ReadOnly = true;
            this.col_Name.OptionsColumn.TabStop = false;
            this.col_Name.Visible = true;
            this.col_Name.VisibleIndex = 0;
            // 
            // col_ServiceType
            // 
            this.col_ServiceType.Caption = "服务类型";
            this.col_ServiceType.FieldName = "ServiceType";
            this.col_ServiceType.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.col_ServiceType.Name = "col_ServiceType";
            this.col_ServiceType.OptionsColumn.AllowEdit = false;
            this.col_ServiceType.OptionsColumn.AllowFocus = false;
            this.col_ServiceType.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.col_ServiceType.OptionsColumn.AllowIncrementalSearch = false;
            this.col_ServiceType.OptionsColumn.AllowMove = false;
            this.col_ServiceType.OptionsColumn.AllowShowHide = false;
            this.col_ServiceType.OptionsColumn.AllowSize = false;
            this.col_ServiceType.OptionsColumn.ReadOnly = true;
            this.col_ServiceType.OptionsColumn.TabStop = false;
            this.col_ServiceType.OptionsFilter.AllowAutoFilter = false;
            this.col_ServiceType.OptionsFilter.AllowFilter = false;
            this.col_ServiceType.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.col_ServiceType.Visible = true;
            this.col_ServiceType.VisibleIndex = 1;
            // 
            // col_Address
            // 
            this.col_Address.Caption = "服务地址";
            this.col_Address.FieldName = "Address";
            this.col_Address.Name = "col_Address";
            this.col_Address.OptionsColumn.AllowEdit = false;
            this.col_Address.OptionsColumn.AllowFocus = false;
            this.col_Address.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.col_Address.OptionsColumn.AllowIncrementalSearch = false;
            this.col_Address.OptionsColumn.AllowMove = false;
            this.col_Address.OptionsColumn.AllowShowHide = false;
            this.col_Address.OptionsColumn.AllowSize = false;
            this.col_Address.OptionsColumn.ReadOnly = true;
            this.col_Address.OptionsColumn.TabStop = false;
            this.col_Address.Visible = true;
            this.col_Address.VisibleIndex = 2;
            // 
            // cmb_ServiceType
            // 
            this.cmb_ServiceType.Location = new System.Drawing.Point(209, 8);
            this.cmb_ServiceType.Name = "cmb_ServiceType";
            this.cmb_ServiceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_ServiceType.Size = new System.Drawing.Size(125, 20);
            this.cmb_ServiceType.TabIndex = 6;
            // 
            // Form_ServiceCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 345);
            this.Controls.Add(this.cmb_ServiceType);
            this.Controls.Add(this.gc_ServiceCfg);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_Address);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ServiceCfg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_ServiceCfg";
            this.Load += new System.EventHandler(this.Form_ServiceCfg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Address.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_ServiceCfg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_ServiceCfg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_ServiceType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_Name;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_Address;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraGrid.GridControl gc_ServiceCfg;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_ServiceCfg;
        private DevExpress.XtraGrid.Columns.GridColumn col_ID;
        private DevExpress.XtraGrid.Columns.GridColumn col_Name;
        private DevExpress.XtraGrid.Columns.GridColumn col_ServiceType;
        private DevExpress.XtraGrid.Columns.GridColumn col_Address;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_ServiceType;
    }
}