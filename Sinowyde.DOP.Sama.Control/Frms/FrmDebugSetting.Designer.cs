namespace Sinowyde.DOP.Sama.Control.Frms
{
    partial class FrmDebugSetting
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
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnIdentity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnGroupIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIndexInGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIsOpenloop = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemToggleSwitch = new DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Location = new System.Drawing.Point(854, 476);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOk.TabIndex = 2;
            this.simpleButtonOk.Text = "确定";
            this.simpleButtonOk.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemToggleSwitch});
            this.gridControl.Size = new System.Drawing.Size(941, 458);
            this.gridControl.TabIndex = 3;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnIdentity,
            this.gridColumnGroupIndex,
            this.gridColumnIndexInGroup,
            this.gridColumnNumber,
            this.gridColumnName,
            this.gridColumnIsOpenloop});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            // 
            // gridColumnIdentity
            // 
            this.gridColumnIdentity.Caption = "唯一标识";
            this.gridColumnIdentity.FieldName = "Identity";
            this.gridColumnIdentity.Name = "gridColumnIdentity";
            this.gridColumnIdentity.OptionsColumn.AllowEdit = false;
            this.gridColumnIdentity.OptionsColumn.AllowMove = false;
            // 
            // gridColumnGroupIndex
            // 
            this.gridColumnGroupIndex.Caption = "页号";
            this.gridColumnGroupIndex.FieldName = "GroupIndex";
            this.gridColumnGroupIndex.Name = "gridColumnGroupIndex";
            this.gridColumnGroupIndex.OptionsColumn.AllowEdit = false;
            this.gridColumnGroupIndex.OptionsColumn.AllowMove = false;
            this.gridColumnGroupIndex.Visible = true;
            this.gridColumnGroupIndex.VisibleIndex = 0;
            // 
            // gridColumnIndexInGroup
            // 
            this.gridColumnIndexInGroup.Caption = "块号";
            this.gridColumnIndexInGroup.FieldName = "IndexInGroup";
            this.gridColumnIndexInGroup.Name = "gridColumnIndexInGroup";
            this.gridColumnIndexInGroup.OptionsColumn.AllowEdit = false;
            this.gridColumnIndexInGroup.OptionsColumn.AllowMove = false;
            this.gridColumnIndexInGroup.Visible = true;
            this.gridColumnIndexInGroup.VisibleIndex = 1;
            // 
            // gridColumnNumber
            // 
            this.gridColumnNumber.Caption = "点名称";
            this.gridColumnNumber.FieldName = "Number";
            this.gridColumnNumber.Name = "gridColumnNumber";
            this.gridColumnNumber.OptionsColumn.AllowEdit = false;
            this.gridColumnNumber.OptionsColumn.AllowMove = false;
            this.gridColumnNumber.Visible = true;
            this.gridColumnNumber.VisibleIndex = 2;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "点中文名称";
            this.gridColumnName.FieldName = "Name";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.OptionsColumn.AllowEdit = false;
            this.gridColumnName.OptionsColumn.AllowMove = false;
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 3;
            // 
            // gridColumnIsOpenloop
            // 
            this.gridColumnIsOpenloop.Caption = "开环调试";
            this.gridColumnIsOpenloop.ColumnEdit = this.repositoryItemToggleSwitch;
            this.gridColumnIsOpenloop.FieldName = "IsOpenloop";
            this.gridColumnIsOpenloop.Name = "gridColumnIsOpenloop";
            this.gridColumnIsOpenloop.OptionsColumn.AllowMove = false;
            this.gridColumnIsOpenloop.Visible = true;
            this.gridColumnIsOpenloop.VisibleIndex = 4;
            // 
            // repositoryItemToggleSwitch
            // 
            this.repositoryItemToggleSwitch.AutoHeight = false;
            this.repositoryItemToggleSwitch.Name = "repositoryItemToggleSwitch";
            this.repositoryItemToggleSwitch.OffText = "Off";
            this.repositoryItemToggleSwitch.OnText = "On";
            // 
            // FrmDebugSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 511);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.simpleButtonOk);
            this.Name = "FrmDebugSetting";
            this.ShowIcon = false;
            this.Text = "调试设置";
            this.Load += new System.EventHandler(this.FrmDebugSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemToggleSwitch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnGroupIndex;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIndexInGroup;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIsOpenloop;
        private DevExpress.XtraEditors.Repository.RepositoryItemToggleSwitch repositoryItemToggleSwitch;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIdentity;
    }
}