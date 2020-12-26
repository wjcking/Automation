namespace Sinowyde.DOP.Trend.Control
{
    partial class Form_VariableConfig
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gc_RTValue = new DevExpress.XtraGrid.GridControl();
            this.gv_RtValue = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.column_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_Number = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_Color = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemColorEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.column_CurrentValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_MinValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_MaxValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl_Variable = new DevExpress.XtraEditors.GroupControl();
            this.popControl_Variable = new DevExpress.XtraEditors.PopupContainerControl();
            this.txt_Variable = new DevExpress.XtraEditors.TextEdit();
            this.cmb_Device = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_DirectionType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gc_Variable = new DevExpress.XtraGrid.GridControl();
            this.gv_Variable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.column_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_Clear = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.txt_Color = new DevExpress.XtraEditors.ColorEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_MaxValue = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_MinValue = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.popEdit_Variable = new DevExpress.XtraEditors.PopupContainerEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmb_LineType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_RTValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_RtValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Variable)).BeginInit();
            this.groupControl_Variable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popControl_Variable)).BeginInit();
            this.popControl_Variable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Variable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Device.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_DirectionType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Variable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Variable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Color.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MaxValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MinValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popEdit_Variable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_LineType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gc_RTValue);
            this.groupControl2.Location = new System.Drawing.Point(2, 83);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(700, 245);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "变量列表";
            // 
            // gc_RTValue
            // 
            this.gc_RTValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_RTValue.Location = new System.Drawing.Point(2, 21);
            this.gc_RTValue.MainView = this.gv_RtValue;
            this.gc_RTValue.Name = "gc_RTValue";
            this.gc_RTValue.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorEdit1});
            this.gc_RTValue.Size = new System.Drawing.Size(696, 222);
            this.gc_RTValue.TabIndex = 1;
            this.gc_RTValue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_RtValue});
            // 
            // gv_RtValue
            // 
            this.gv_RtValue.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.column_Name,
            this.column_Number,
            this.column_Color,
            this.column_CurrentValue,
            this.column_MinValue,
            this.column_MaxValue});
            this.gv_RtValue.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gv_RtValue.GridControl = this.gc_RTValue;
            this.gv_RtValue.Name = "gv_RtValue";
            this.gv_RtValue.OptionsBehavior.Editable = false;
            this.gv_RtValue.OptionsCustomization.AllowColumnMoving = false;
            this.gv_RtValue.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv_RtValue.OptionsView.ShowGroupPanel = false;
            this.gv_RtValue.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gv_RtValue_PopupMenuShowing);
            this.gv_RtValue.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.gv_RtValue_CustomDrawEmptyForeground);
            this.gv_RtValue.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gv_RtValue_CustomColumnDisplayText);
            this.gv_RtValue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gv_RtValue_MouseDown);
            // 
            // column_Name
            // 
            this.column_Name.Caption = "点名";
            this.column_Name.FieldName = "Variable.Name";
            this.column_Name.Name = "column_Name";
            this.column_Name.Visible = true;
            this.column_Name.VisibleIndex = 0;
            this.column_Name.Width = 173;
            // 
            // column_Number
            // 
            this.column_Number.Caption = "中文名称";
            this.column_Number.FieldName = "Variable.Name";
            this.column_Number.Name = "column_Number";
            this.column_Number.Visible = true;
            this.column_Number.VisibleIndex = 1;
            this.column_Number.Width = 173;
            // 
            // column_Color
            // 
            this.column_Color.Caption = "颜色";
            this.column_Color.ColumnEdit = this.repositoryItemColorEdit1;
            this.column_Color.FieldName = "Color";
            this.column_Color.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.column_Color.MaxWidth = 100;
            this.column_Color.MinWidth = 100;
            this.column_Color.Name = "column_Color";
            this.column_Color.Visible = true;
            this.column_Color.VisibleIndex = 2;
            this.column_Color.Width = 100;
            // 
            // repositoryItemColorEdit1
            // 
            this.repositoryItemColorEdit1.AutoHeight = false;
            this.repositoryItemColorEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorEdit1.Name = "repositoryItemColorEdit1";
            // 
            // column_CurrentValue
            // 
            this.column_CurrentValue.Caption = "当前值";
            this.column_CurrentValue.FieldName = "Value";
            this.column_CurrentValue.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.column_CurrentValue.MaxWidth = 60;
            this.column_CurrentValue.Name = "column_CurrentValue";
            this.column_CurrentValue.Visible = true;
            this.column_CurrentValue.VisibleIndex = 3;
            this.column_CurrentValue.Width = 60;
            // 
            // column_MinValue
            // 
            this.column_MinValue.Caption = "最小值";
            this.column_MinValue.FieldName = "MinValue";
            this.column_MinValue.MaxWidth = 60;
            this.column_MinValue.MinWidth = 60;
            this.column_MinValue.Name = "column_MinValue";
            this.column_MinValue.Visible = true;
            this.column_MinValue.VisibleIndex = 4;
            this.column_MinValue.Width = 60;
            // 
            // column_MaxValue
            // 
            this.column_MaxValue.Caption = "最大值";
            this.column_MaxValue.FieldName = "MaxValue";
            this.column_MaxValue.MaxWidth = 60;
            this.column_MaxValue.MinWidth = 60;
            this.column_MaxValue.Name = "column_MaxValue";
            this.column_MaxValue.Visible = true;
            this.column_MaxValue.VisibleIndex = 5;
            this.column_MaxValue.Width = 60;
            // 
            // groupControl_Variable
            // 
            this.groupControl_Variable.Controls.Add(this.cmb_LineType);
            this.groupControl_Variable.Controls.Add(this.labelControl5);
            this.groupControl_Variable.Controls.Add(this.popControl_Variable);
            this.groupControl_Variable.Controls.Add(this.btn_Clear);
            this.groupControl_Variable.Controls.Add(this.btn_Save);
            this.groupControl_Variable.Controls.Add(this.txt_Color);
            this.groupControl_Variable.Controls.Add(this.labelControl4);
            this.groupControl_Variable.Controls.Add(this.txt_MaxValue);
            this.groupControl_Variable.Controls.Add(this.labelControl3);
            this.groupControl_Variable.Controls.Add(this.txt_MinValue);
            this.groupControl_Variable.Controls.Add(this.labelControl2);
            this.groupControl_Variable.Controls.Add(this.popEdit_Variable);
            this.groupControl_Variable.Controls.Add(this.labelControl1);
            this.groupControl_Variable.Location = new System.Drawing.Point(2, 2);
            this.groupControl_Variable.Name = "groupControl_Variable";
            this.groupControl_Variable.Size = new System.Drawing.Size(700, 80);
            this.groupControl_Variable.TabIndex = 1;
            this.groupControl_Variable.Text = "添加变量";
            // 
            // popControl_Variable
            // 
            this.popControl_Variable.Controls.Add(this.txt_Variable);
            this.popControl_Variable.Controls.Add(this.cmb_Device);
            this.popControl_Variable.Controls.Add(this.cmb_DirectionType);
            this.popControl_Variable.Controls.Add(this.gc_Variable);
            this.popControl_Variable.Location = new System.Drawing.Point(230, 51);
            this.popControl_Variable.MaximumSize = new System.Drawing.Size(260, 226);
            this.popControl_Variable.MinimumSize = new System.Drawing.Size(260, 226);
            this.popControl_Variable.Name = "popControl_Variable";
            this.popControl_Variable.Size = new System.Drawing.Size(260, 226);
            this.popControl_Variable.TabIndex = 16;
            // 
            // txt_Variable
            // 
            this.txt_Variable.Location = new System.Drawing.Point(2, 2);
            this.txt_Variable.Name = "txt_Variable";
            this.txt_Variable.Size = new System.Drawing.Size(89, 20);
            this.txt_Variable.TabIndex = 2;
            this.txt_Variable.TextChanged += new System.EventHandler(this.txt_Variable_TextChanged);
            // 
            // cmb_Device
            // 
            this.cmb_Device.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_Device.Location = new System.Drawing.Point(172, 2);
            this.cmb_Device.Name = "cmb_Device";
            this.cmb_Device.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_Device.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_Device.Size = new System.Drawing.Size(86, 20);
            this.cmb_Device.TabIndex = 1;
            this.cmb_Device.SelectedIndexChanged += new System.EventHandler(this.cmb_Device_SelectedIndexChanged);
            // 
            // cmb_DirectionType
            // 
            this.cmb_DirectionType.Location = new System.Drawing.Point(99, 2);
            this.cmb_DirectionType.Name = "cmb_DirectionType";
            this.cmb_DirectionType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_DirectionType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_DirectionType.Size = new System.Drawing.Size(67, 20);
            this.cmb_DirectionType.TabIndex = 1;
            this.cmb_DirectionType.SelectedIndexChanged += new System.EventHandler(this.cmb_DirectionType_SelectedIndexChanged);
            // 
            // gc_Variable
            // 
            this.gc_Variable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gc_Variable.Location = new System.Drawing.Point(2, 24);
            this.gc_Variable.MainView = this.gv_Variable;
            this.gc_Variable.Name = "gc_Variable";
            this.gc_Variable.Size = new System.Drawing.Size(258, 200);
            this.gc_Variable.TabIndex = 0;
            this.gc_Variable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Variable});
            // 
            // gv_Variable
            // 
            this.gv_Variable.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.column_ID,
            this.gridColumn1,
            this.gridColumn2});
            this.gv_Variable.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gv_Variable.GridControl = this.gc_Variable;
            this.gv_Variable.Name = "gv_Variable";
            this.gv_Variable.OptionsBehavior.Editable = false;
            this.gv_Variable.OptionsCustomization.AllowColumnMoving = false;
            this.gv_Variable.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv_Variable.OptionsView.ShowGroupPanel = false;
            this.gv_Variable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gv_Variable_MouseDown);
            // 
            // column_ID
            // 
            this.column_ID.Caption = "编号";
            this.column_ID.FieldName = "ID";
            this.column_ID.Name = "column_ID";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "变量";
            this.gridColumn1.FieldName = "Number";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 148;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "中文名称";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 129;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(620, 51);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 15;
            this.btn_Clear.Text = "重置";
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(539, 52);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 15;
            this.btn_Save.Text = "新增";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_Color
            // 
            this.txt_Color.EditValue = System.Drawing.Color.Black;
            this.txt_Color.Location = new System.Drawing.Point(605, 24);
            this.txt_Color.Name = "txt_Color";
            this.txt_Color.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_Color.Properties.HideSelection = false;
            this.txt_Color.Size = new System.Drawing.Size(90, 20);
            this.txt_Color.TabIndex = 14;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(566, 28);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "颜色：";
            // 
            // txt_MaxValue
            // 
            this.txt_MaxValue.EditValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txt_MaxValue.Location = new System.Drawing.Point(431, 25);
            this.txt_MaxValue.Name = "txt_MaxValue";
            this.txt_MaxValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_MaxValue.Size = new System.Drawing.Size(90, 20);
            this.txt_MaxValue.TabIndex = 12;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(380, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "最大值：";
            // 
            // txt_MinValue
            // 
            this.txt_MinValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_MinValue.Location = new System.Drawing.Point(264, 25);
            this.txt_MinValue.Name = "txt_MinValue";
            this.txt_MinValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_MinValue.Size = new System.Drawing.Size(90, 20);
            this.txt_MinValue.TabIndex = 10;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(213, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "最小值：";
            // 
            // popEdit_Variable
            // 
            this.popEdit_Variable.EditValue = "请选择变量";
            this.popEdit_Variable.Location = new System.Drawing.Point(51, 25);
            this.popEdit_Variable.Name = "popEdit_Variable";
            this.popEdit_Variable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popEdit_Variable.Properties.PopupControl = this.popControl_Variable;
            this.popEdit_Variable.Size = new System.Drawing.Size(143, 20);
            this.popEdit_Variable.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "变量：";
            // 
            // cmb_LineType
            // 
            this.cmb_LineType.EditValue = "Solid";
            this.cmb_LineType.Location = new System.Drawing.Point(51, 53);
            this.cmb_LineType.Name = "cmb_LineType";
            this.cmb_LineType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_LineType.Properties.Items.AddRange(new object[] {
            "Solid",
            "Dash",
            "Dot",
            "DashDot",
            "DashDotDot"});
            this.cmb_LineType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_LineType.Size = new System.Drawing.Size(143, 20);
            this.cmb_LineType.TabIndex = 18;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 56);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 17;
            this.labelControl5.Text = "线型：";
            // 
            // Form_VariableConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 331);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl_Variable);
            this.Name = "Form_VariableConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "变量配置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_VariableConfig_FormClosing);
            this.Load += new System.EventHandler(this.Form_VariableConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_RTValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_RtValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Variable)).EndInit();
            this.groupControl_Variable.ResumeLayout(false);
            this.groupControl_Variable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popControl_Variable)).EndInit();
            this.popControl_Variable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Variable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Device.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_DirectionType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Variable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Variable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Color.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MaxValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MinValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popEdit_Variable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_LineType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gc_RTValue;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_RtValue;
        private DevExpress.XtraGrid.Columns.GridColumn column_Name;
        private DevExpress.XtraGrid.Columns.GridColumn column_Number;
        private DevExpress.XtraGrid.Columns.GridColumn column_Color;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repositoryItemColorEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn column_CurrentValue;
        private DevExpress.XtraGrid.Columns.GridColumn column_MinValue;
        private DevExpress.XtraGrid.Columns.GridColumn column_MaxValue;
        private DevExpress.XtraEditors.GroupControl groupControl_Variable;
        private DevExpress.XtraEditors.PopupContainerEdit popEdit_Variable;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit txt_MinValue;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit txt_MaxValue;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ColorEdit txt_Color;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btn_Clear;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.PopupContainerControl popControl_Variable;
        private DevExpress.XtraEditors.TextEdit txt_Variable;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_Device;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_DirectionType;
        private DevExpress.XtraGrid.GridControl gc_Variable;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Variable;
        private DevExpress.XtraGrid.Columns.GridColumn column_ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_LineType;
        private DevExpress.XtraEditors.LabelControl labelControl5;

    }
}