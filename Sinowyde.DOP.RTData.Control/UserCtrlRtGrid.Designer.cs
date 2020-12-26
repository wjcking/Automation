namespace Sinowyde.DOP.RTData.Control
{
    partial class UserCtrlRtGrid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserCtrlRtGrid));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleIconSet formatConditionRuleIconSet1 = new DevExpress.XtraEditors.FormatConditionRuleIconSet();
            DevExpress.XtraEditors.FormatConditionIconSet formatConditionIconSet1 = new DevExpress.XtraEditors.FormatConditionIconSet();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon1 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon2 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon3 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            this.column_Percentage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cmb_DirectionType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txt_keys = new DevExpress.XtraEditors.TextEdit();
            this.lbl_DirectionType = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Device = new DevExpress.XtraEditors.LabelControl();
            this.cmb_Device = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl_Search = new DevExpress.XtraEditors.GroupControl();
            this.gc_Variable = new DevExpress.XtraGrid.GridControl();
            this.gv_Varibale = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.column_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_Device = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_CurrentTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_CurrentValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.column_Number = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_DirectionType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_keys.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Device.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Search)).BeginInit();
            this.groupControl_Search.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Variable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Varibale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // column_Percentage
            // 
            this.column_Percentage.AppearanceCell.Image = ((System.Drawing.Image)(resources.GetObject("column_Percentage.AppearanceCell.Image")));
            this.column_Percentage.AppearanceCell.Options.UseImage = true;
            this.column_Percentage.Caption = "变化率";
            this.column_Percentage.ColumnEdit = this.repositoryItemTextEdit1;
            this.column_Percentage.FieldName = "Percentage";
            this.column_Percentage.Name = "column_Percentage";
            this.column_Percentage.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.column_Percentage.Visible = true;
            this.column_Percentage.VisibleIndex = 5;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.EditMask = "p";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // cmb_DirectionType
            // 
            this.cmb_DirectionType.Location = new System.Drawing.Point(218, 24);
            this.cmb_DirectionType.Name = "cmb_DirectionType";
            this.cmb_DirectionType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_DirectionType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_DirectionType.Size = new System.Drawing.Size(100, 20);
            this.cmb_DirectionType.TabIndex = 1;
            // 
            // txt_keys
            // 
            this.txt_keys.EditValue = "Name Or Number";
            this.txt_keys.Location = new System.Drawing.Point(321, 24);
            this.txt_keys.Name = "txt_keys";
            this.txt_keys.Properties.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.txt_keys.Properties.Appearance.Options.UseForeColor = true;
            this.txt_keys.Size = new System.Drawing.Size(115, 20);
            this.txt_keys.TabIndex = 2;
            this.txt_keys.Enter += new System.EventHandler(this.txt_keys_Enter);
            this.txt_keys.Validated += new System.EventHandler(this.txt_keys_Validated);
            // 
            // lbl_DirectionType
            // 
            this.lbl_DirectionType.Location = new System.Drawing.Point(155, 27);
            this.lbl_DirectionType.Name = "lbl_DirectionType";
            this.lbl_DirectionType.Size = new System.Drawing.Size(60, 14);
            this.lbl_DirectionType.TabIndex = 0;
            this.lbl_DirectionType.Text = "变量类型：";
            // 
            // lbl_Device
            // 
            this.lbl_Device.Location = new System.Drawing.Point(10, 27);
            this.lbl_Device.Name = "lbl_Device";
            this.lbl_Device.Size = new System.Drawing.Size(36, 14);
            this.lbl_Device.TabIndex = 0;
            this.lbl_Device.Text = "设备：";
            // 
            // cmb_Device
            // 
            this.cmb_Device.Location = new System.Drawing.Point(49, 24);
            this.cmb_Device.Name = "cmb_Device";
            this.cmb_Device.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_Device.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_Device.Size = new System.Drawing.Size(100, 20);
            this.cmb_Device.TabIndex = 1;
            // 
            // btn_Search
            // 
            this.btn_Search.Enabled = false;
            this.btn_Search.Location = new System.Drawing.Point(442, 23);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.Text = "查询";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // groupControl_Search
            // 
            this.groupControl_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl_Search.Controls.Add(this.btn_Search);
            this.groupControl_Search.Controls.Add(this.lbl_DirectionType);
            this.groupControl_Search.Controls.Add(this.txt_keys);
            this.groupControl_Search.Controls.Add(this.cmb_DirectionType);
            this.groupControl_Search.Controls.Add(this.cmb_Device);
            this.groupControl_Search.Controls.Add(this.lbl_Device);
            this.groupControl_Search.Location = new System.Drawing.Point(2, 2);
            this.groupControl_Search.Name = "groupControl_Search";
            this.groupControl_Search.Size = new System.Drawing.Size(525, 50);
            this.groupControl_Search.TabIndex = 4;
            this.groupControl_Search.Text = "查询条件";
            // 
            // gc_Variable
            // 
            this.gc_Variable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gc_Variable.Location = new System.Drawing.Point(2, 54);
            this.gc_Variable.MainView = this.gv_Varibale;
            this.gc_Variable.Name = "gc_Variable";
            this.gc_Variable.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemTextEdit1});
            this.gc_Variable.Size = new System.Drawing.Size(525, 246);
            this.gc_Variable.TabIndex = 5;
            this.gc_Variable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Varibale});
            // 
            // gv_Varibale
            // 
            this.gv_Varibale.ActiveFilterEnabled = false;
            this.gv_Varibale.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gv_Varibale.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.column_Number,
            this.column_Name,
            this.column_Device,
            this.column_CurrentTime,
            this.column_CurrentValue,
            this.column_Percentage});
            this.gv_Varibale.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridFormatRule1.Column = this.column_Percentage;
            gridFormatRule1.Name = "Format0";
            formatConditionIconSet1.CategoryName = "Directional";
            formatConditionIconSetIcon1.PredefinedName = "Triangles3_1.png";
            formatConditionIconSetIcon2.PredefinedName = "Triangles3_2.png";
            formatConditionIconSetIcon2.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon3.PredefinedName = "Triangles3_3.png";
            formatConditionIconSetIcon3.Value = new decimal(new int[] {
            1215752192,
            23,
            0,
            -2147483648});
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon1);
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon2);
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon3);
            formatConditionIconSet1.Name = "Triangles3";
            formatConditionIconSet1.ValueType = DevExpress.XtraEditors.FormatConditionValueType.Percent;
            formatConditionRuleIconSet1.IconSet = formatConditionIconSet1;
            gridFormatRule1.Rule = formatConditionRuleIconSet1;
            gridFormatRule1.StopIfTrue = true;
            this.gv_Varibale.FormatRules.Add(gridFormatRule1);
            this.gv_Varibale.GridControl = this.gc_Variable;
            this.gv_Varibale.Name = "gv_Varibale";
            this.gv_Varibale.OptionsBehavior.AutoPopulateColumns = false;
            this.gv_Varibale.OptionsBehavior.Editable = false;
            this.gv_Varibale.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gv_Varibale.OptionsFilter.AllowFilterEditor = false;
            this.gv_Varibale.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.gv_Varibale.OptionsFilter.AllowMRUFilterList = false;
            this.gv_Varibale.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
            this.gv_Varibale.OptionsFilter.FilterEditorUseMenuForOperandsAndOperators = false;
            this.gv_Varibale.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = false;
            this.gv_Varibale.OptionsView.ShowGroupPanel = false;
            this.gv_Varibale.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.gv_Varibale_CustomUnboundColumnData);
            this.gv_Varibale.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gv_Varibale_CustomColumnDisplayText);
            // 
            // column_Name
            // 
            this.column_Name.Caption = "中文名称";
            this.column_Name.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.column_Name.FieldName = "Name";
            this.column_Name.Name = "column_Name";
            this.column_Name.Visible = true;
            this.column_Name.VisibleIndex = 1;
            this.column_Name.Width = 100;
            // 
            // column_Device
            // 
            this.column_Device.Caption = "设备";
            this.column_Device.FieldName = "Device.Name";
            this.column_Device.Name = "column_Device";
            this.column_Device.Visible = true;
            this.column_Device.VisibleIndex = 2;
            this.column_Device.Width = 121;
            // 
            // column_CurrentTime
            // 
            this.column_CurrentTime.Caption = "采集时间";
            this.column_CurrentTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.column_CurrentTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.column_CurrentTime.FieldName = "Timestamp";
            this.column_CurrentTime.Name = "column_CurrentTime";
            this.column_CurrentTime.Visible = true;
            this.column_CurrentTime.VisibleIndex = 3;
            this.column_CurrentTime.Width = 140;
            // 
            // column_CurrentValue
            // 
            this.column_CurrentValue.Caption = "变量值";
            this.column_CurrentValue.FieldName = "Value";
            this.column_CurrentValue.Name = "column_CurrentValue";
            this.column_CurrentValue.Visible = true;
            this.column_CurrentValue.VisibleIndex = 4;
            this.column_CurrentValue.Width = 60;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("moveup_16x16.png", "images/arrows/moveup_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/moveup_16x16.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "moveup_16x16.png");
            this.imageCollection1.InsertGalleryImage("movedown_16x16.png", "images/arrows/movedown_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrows/movedown_16x16.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "movedown_16x16.png");
            // 
            // column_Number
            // 
            this.column_Number.Caption = "变量";
            this.column_Number.FieldName = "Number";
            this.column_Number.Name = "column_Number";
            this.column_Number.Visible = true;
            this.column_Number.VisibleIndex = 0;
            // 
            // UserCtrlRtGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gc_Variable);
            this.Controls.Add(this.groupControl_Search);
            this.Name = "UserCtrlRtGrid";
            this.Size = new System.Drawing.Size(529, 300);
            this.Load += new System.EventHandler(this.UserCtrlRtGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_DirectionType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_keys.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Device.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Search)).EndInit();
            this.groupControl_Search.ResumeLayout(false);
            this.groupControl_Search.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Variable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Varibale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cmb_DirectionType;
        private DevExpress.XtraEditors.TextEdit txt_keys;
        private DevExpress.XtraEditors.LabelControl lbl_DirectionType;
        private DevExpress.XtraEditors.LabelControl lbl_Device;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_Device;
        private DevExpress.XtraEditors.SimpleButton btn_Search;
        private DevExpress.XtraEditors.GroupControl groupControl_Search;
        private DevExpress.XtraGrid.GridControl gc_Variable;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Varibale;
        private DevExpress.XtraGrid.Columns.GridColumn column_Name;
        private DevExpress.XtraGrid.Columns.GridColumn column_Device;
        private DevExpress.XtraGrid.Columns.GridColumn column_CurrentTime;
        private DevExpress.XtraGrid.Columns.GridColumn column_CurrentValue;
        private DevExpress.XtraGrid.Columns.GridColumn column_Percentage;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn column_Number;
    }
}
