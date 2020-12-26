namespace Sinowyde.DOP.GraphicElement
{
    partial class frmVariable
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
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtVariableName = new DevExpress.XtraEditors.TextEdit();
            this.lblVariableName = new DevExpress.XtraEditors.LabelControl();
            this.lblVariableType = new DevExpress.XtraEditors.LabelControl();
            this.lblcboDeviceName = new DevExpress.XtraEditors.LabelControl();
            this.cboDataType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboDevice = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridCtrlDataInfo = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVariableName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDataType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDevice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrlDataInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(423, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 29);
            this.btnSave.TabIndex = 4;
            this.btnSave.Tag = "";
            this.btnSave.Text = "确定";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(524, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 29);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.txtVariableName);
            this.panelControl1.Controls.Add(this.lblVariableName);
            this.panelControl1.Controls.Add(this.lblVariableType);
            this.panelControl1.Controls.Add(this.lblcboDeviceName);
            this.panelControl1.Controls.Add(this.cboDataType);
            this.panelControl1.Controls.Add(this.cboDevice);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(633, 49);
            this.panelControl1.TabIndex = 15;
            // 
            // txtVariableName
            // 
            this.txtVariableName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtVariableName.EditValue = "";
            this.txtVariableName.Location = new System.Drawing.Point(456, 15);
            this.txtVariableName.Name = "txtVariableName";
            this.txtVariableName.Properties.Appearance.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtVariableName.Properties.Appearance.Options.UseForeColor = true;
            this.txtVariableName.Size = new System.Drawing.Size(156, 20);
            this.txtVariableName.TabIndex = 3;
            this.txtVariableName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtVariableName_KeyUp);
            // 
            // lblVariableName
            // 
            this.lblVariableName.Location = new System.Drawing.Point(393, 18);
            this.lblVariableName.Name = "lblVariableName";
            this.lblVariableName.Size = new System.Drawing.Size(60, 14);
            this.lblVariableName.TabIndex = 1;
            this.lblVariableName.Text = "变量名称：";
            // 
            // lblVariableType
            // 
            this.lblVariableType.Location = new System.Drawing.Point(226, 18);
            this.lblVariableType.Name = "lblVariableType";
            this.lblVariableType.Size = new System.Drawing.Size(60, 14);
            this.lblVariableType.TabIndex = 1;
            this.lblVariableType.Text = "数据类型：";
            // 
            // lblcboDeviceName
            // 
            this.lblcboDeviceName.Location = new System.Drawing.Point(15, 18);
            this.lblcboDeviceName.Name = "lblcboDeviceName";
            this.lblcboDeviceName.Size = new System.Drawing.Size(60, 14);
            this.lblcboDeviceName.TabIndex = 1;
            this.lblcboDeviceName.Text = "设备名称：";
            // 
            // cboDataType
            // 
            this.cboDataType.Location = new System.Drawing.Point(289, 15);
            this.cboDataType.Name = "cboDataType";
            this.cboDataType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDataType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboDataType.Size = new System.Drawing.Size(80, 20);
            this.cboDataType.TabIndex = 0;
            this.cboDataType.SelectedIndexChanged += new System.EventHandler(this.cboDataType_SelectedIndexChanged);
            // 
            // cboDevice
            // 
            this.cboDevice.Location = new System.Drawing.Point(78, 15);
            this.cboDevice.Name = "cboDevice";
            this.cboDevice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDevice.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboDevice.Size = new System.Drawing.Size(125, 20);
            this.cboDevice.TabIndex = 0;
            this.cboDevice.SelectedIndexChanged += new System.EventHandler(this.cboDevice_SelectedIndexChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 380);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(633, 52);
            this.panelControl2.TabIndex = 16;
            // 
            // gridCtrlDataInfo
            // 
            this.gridCtrlDataInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCtrlDataInfo.Location = new System.Drawing.Point(0, 49);
            this.gridCtrlDataInfo.MainView = this.gridView;
            this.gridCtrlDataInfo.Name = "gridCtrlDataInfo";
            this.gridCtrlDataInfo.Size = new System.Drawing.Size(633, 331);
            this.gridCtrlDataInfo.TabIndex = 17;
            this.gridCtrlDataInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnName,
            this.gridColumnNumber,
            this.gridColumnDataType,
            this.gridColumnID});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView.GridControl = this.gridCtrlDataInfo;
            this.gridView.Name = "gridView";
            this.gridView.OptionsCustomization.AllowColumnMoving = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.DoubleClick += new System.EventHandler(this.gridView_DoubleClick);
            // 
            // gridColumnNumber
            // 
            this.gridColumnNumber.Caption = "变量名称";
            this.gridColumnNumber.FieldName = "Number";
            this.gridColumnNumber.MinWidth = 100;
            this.gridColumnNumber.Name = "gridColumnNumber";
            this.gridColumnNumber.OptionsColumn.AllowEdit = false;
            this.gridColumnNumber.OptionsColumn.AllowFocus = false;
            this.gridColumnNumber.OptionsColumn.AllowMove = false;
            this.gridColumnNumber.Visible = true;
            this.gridColumnNumber.VisibleIndex = 1;
            this.gridColumnNumber.Width = 100;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "中文名称";
            this.gridColumnName.FieldName = "Name";
            this.gridColumnName.MinWidth = 100;
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.OptionsColumn.AllowEdit = false;
            this.gridColumnName.OptionsColumn.AllowFocus = false;
            this.gridColumnName.OptionsColumn.AllowMove = false;
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 0;
            this.gridColumnName.Width = 164;
            // 
            // gridColumnDataType
            // 
            this.gridColumnDataType.Caption = "数据类型";
            this.gridColumnDataType.FieldName = "DataType";
            this.gridColumnDataType.Name = "gridColumnDataType";
            this.gridColumnDataType.OptionsColumn.AllowEdit = false;
            this.gridColumnDataType.OptionsColumn.AllowFocus = false;
            this.gridColumnDataType.OptionsColumn.AllowMove = false;
            this.gridColumnDataType.Visible = true;
            this.gridColumnDataType.VisibleIndex = 2;
            this.gridColumnDataType.Width = 100;
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "ID";
            this.gridColumnID.Name = "gridColumnID";
            // 
            // frmVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 432);
            this.Controls.Add(this.gridCtrlDataInfo);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVariable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "变量选择";
            this.Load += new System.EventHandler(this.frmVariable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVariableName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDataType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDevice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrlDataInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridCtrlDataInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraEditors.LabelControl lblcboDeviceName;
        private DevExpress.XtraEditors.ComboBoxEdit cboDevice;
        private DevExpress.XtraEditors.LabelControl lblVariableType;
        private DevExpress.XtraEditors.ComboBoxEdit cboDataType;
        private DevExpress.XtraEditors.TextEdit txtVariableName;
        private DevExpress.XtraEditors.LabelControl lblVariableName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDataType;

    }
}