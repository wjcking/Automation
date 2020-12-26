namespace Sinowyde.DOP.Sama.Control.Frms
{
    partial class FrmRecovery
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
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnBackupTimestamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPeople = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1008, 390);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnBackupTimestamp,
            this.gridColumnPeople,
            this.gridColumnDescription,
            this.gridColumnFileName});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            // 
            // gridColumnBackupTimestamp
            // 
            this.gridColumnBackupTimestamp.Caption = "备份时间";
            this.gridColumnBackupTimestamp.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.gridColumnBackupTimestamp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnBackupTimestamp.FieldName = "BackupTimestamp";
            this.gridColumnBackupTimestamp.MinWidth = 200;
            this.gridColumnBackupTimestamp.Name = "gridColumnBackupTimestamp";
            this.gridColumnBackupTimestamp.OptionsColumn.AllowEdit = false;
            this.gridColumnBackupTimestamp.OptionsColumn.AllowMove = false;
            this.gridColumnBackupTimestamp.Visible = true;
            this.gridColumnBackupTimestamp.VisibleIndex = 0;
            this.gridColumnBackupTimestamp.Width = 200;
            // 
            // gridColumnPeople
            // 
            this.gridColumnPeople.Caption = "备份人员";
            this.gridColumnPeople.FieldName = "People";
            this.gridColumnPeople.MinWidth = 100;
            this.gridColumnPeople.Name = "gridColumnPeople";
            this.gridColumnPeople.OptionsColumn.AllowEdit = false;
            this.gridColumnPeople.OptionsColumn.AllowMove = false;
            this.gridColumnPeople.Visible = true;
            this.gridColumnPeople.VisibleIndex = 1;
            this.gridColumnPeople.Width = 100;
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "说明";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.OptionsColumn.AllowEdit = false;
            this.gridColumnDescription.OptionsColumn.AllowMove = false;
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 2;
            this.gridColumnDescription.Width = 891;
            // 
            // gridColumnFileName
            // 
            this.gridColumnFileName.Caption = "文件路径";
            this.gridColumnFileName.FieldName = "FileName";
            this.gridColumnFileName.Name = "gridColumnFileName";
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Location = new System.Drawing.Point(922, 453);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOk.TabIndex = 2;
            this.simpleButtonOk.Text = "关闭";
            this.simpleButtonOk.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // FrmRecovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 488);
            this.Controls.Add(this.simpleButtonOk);
            this.Controls.Add(this.gridControl);
            this.MaximumSize = new System.Drawing.Size(1024, 526);
            this.MinimumSize = new System.Drawing.Size(1024, 526);
            this.Name = "FrmRecovery";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "恢复";
            this.Load += new System.EventHandler(this.FrmRecovery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBackupTimestamp;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPeople;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFileName;
    }
}