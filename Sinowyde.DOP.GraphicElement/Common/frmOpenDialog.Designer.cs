namespace Sinowyde.DOP.GraphicElement
{
    partial class frmOpenDialog
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
            this.btnOpen = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lblFileType = new DevExpress.XtraEditors.LabelControl();
            this.cboFileType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.pnlCtrMain = new DevExpress.XtraEditors.PanelControl();
            this.txtFileName = new DevExpress.XtraEditors.TextEdit();
            this.lblFileName = new DevExpress.XtraEditors.LabelControl();
            this.gridCtrlDataInfo = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTimestamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cboFileType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrMain)).BeginInit();
            this.pnlCtrMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrlDataInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(416, 42);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(68, 27);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Tag = "";
            this.btnOpen.Text = "打 开";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(504, 42);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 27);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取 消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblFileType
            // 
            this.lblFileType.Location = new System.Drawing.Point(15, 51);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(60, 14);
            this.lblFileType.TabIndex = 7;
            this.lblFileType.Text = "文档类型：";
            // 
            // cboFileType
            // 
            this.cboFileType.Location = new System.Drawing.Point(78, 48);
            this.cboFileType.Name = "cboFileType";
            this.cboFileType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFileType.Properties.Items.AddRange(new object[] {
            "窗体文件(*.frm)"});
            this.cboFileType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboFileType.Size = new System.Drawing.Size(172, 20);
            this.cboFileType.TabIndex = 8;
            // 
            // pnlCtrMain
            // 
            this.pnlCtrMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlCtrMain.Controls.Add(this.txtFileName);
            this.pnlCtrMain.Controls.Add(this.btnCancel);
            this.pnlCtrMain.Controls.Add(this.btnOpen);
            this.pnlCtrMain.Controls.Add(this.cboFileType);
            this.pnlCtrMain.Controls.Add(this.lblFileName);
            this.pnlCtrMain.Controls.Add(this.lblFileType);
            this.pnlCtrMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCtrMain.Location = new System.Drawing.Point(0, 315);
            this.pnlCtrMain.Name = "pnlCtrMain";
            this.pnlCtrMain.Size = new System.Drawing.Size(584, 79);
            this.pnlCtrMain.TabIndex = 10;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(78, 14);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(172, 20);
            this.txtFileName.TabIndex = 9;
            // 
            // lblFileName
            // 
            this.lblFileName.Location = new System.Drawing.Point(15, 17);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(60, 14);
            this.lblFileName.TabIndex = 7;
            this.lblFileName.Text = "文档名称：";
            // 
            // gridCtrlDataInfo
            // 
            this.gridCtrlDataInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCtrlDataInfo.Location = new System.Drawing.Point(0, 0);
            this.gridCtrlDataInfo.MainView = this.gridView;
            this.gridCtrlDataInfo.Name = "gridCtrlDataInfo";
            this.gridCtrlDataInfo.Size = new System.Drawing.Size(584, 315);
            this.gridCtrlDataInfo.TabIndex = 13;
            this.gridCtrlDataInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.gridCtrlDataInfo.Click += new System.EventHandler(this.gridCtrlDataInfo_Click);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnName,
            this.gridColumnTimestamp,
            this.gridColumnDescription,
            this.gridColumnID});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView.GridControl = this.gridCtrlDataInfo;
            this.gridView.Name = "gridView";
            this.gridView.OptionsCustomization.AllowColumnMoving = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.DoubleClick += new System.EventHandler(this.gridView_DoubleClick);
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "名称";
            this.gridColumnName.FieldName = "Name";
            this.gridColumnName.MinWidth = 100;
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.OptionsColumn.AllowEdit = false;
            this.gridColumnName.OptionsColumn.AllowFocus = false;
            this.gridColumnName.OptionsColumn.AllowMove = false;
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 0;
            this.gridColumnName.Width = 100;
            // 
            // gridColumnTimestamp
            // 
            this.gridColumnTimestamp.Caption = "修改日期";
            this.gridColumnTimestamp.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumnTimestamp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnTimestamp.FieldName = "Timestamp";
            this.gridColumnTimestamp.MinWidth = 100;
            this.gridColumnTimestamp.Name = "gridColumnTimestamp";
            this.gridColumnTimestamp.OptionsColumn.AllowEdit = false;
            this.gridColumnTimestamp.OptionsColumn.AllowFocus = false;
            this.gridColumnTimestamp.OptionsColumn.AllowMove = false;
            this.gridColumnTimestamp.Visible = true;
            this.gridColumnTimestamp.VisibleIndex = 1;
            this.gridColumnTimestamp.Width = 200;
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "描述";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.OptionsColumn.AllowEdit = false;
            this.gridColumnDescription.OptionsColumn.AllowFocus = false;
            this.gridColumnDescription.OptionsColumn.AllowMove = false;
            this.gridColumnDescription.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 2;
            this.gridColumnDescription.Width = 891;
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.FieldName = "Graph.ID";
            this.gridColumnID.Name = "gridColumnID";
            // 
            // frmOpenDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 394);
            this.Controls.Add(this.gridCtrlDataInfo);
            this.Controls.Add(this.pnlCtrMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOpenDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打开图元";
            ((System.ComponentModel.ISupportInitialize)(this.cboFileType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCtrMain)).EndInit();
            this.pnlCtrMain.ResumeLayout(false);
            this.pnlCtrMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrlDataInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnOpen;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl lblFileType;
        private DevExpress.XtraEditors.ComboBoxEdit cboFileType;
        private DevExpress.XtraEditors.PanelControl pnlCtrMain;
        private DevExpress.XtraGrid.GridControl gridCtrlDataInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTimestamp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnID;
        private DevExpress.XtraEditors.LabelControl lblFileName;
        private DevExpress.XtraEditors.TextEdit txtFileName;

    }
}