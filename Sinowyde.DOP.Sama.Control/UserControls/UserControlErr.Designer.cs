namespace Sinowyde.DOP.Sama.Control.UserControls
{
    partial class UserControlErr
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnGroupIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIndexInGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAlgName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(983, 432);
            this.gridControl.TabIndex = 1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnGroupIndex,
            this.gridColumnIndexInGroup,
            this.gridColumnDescription,
            this.gridColumnAlgName});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            // 
            // gridColumnGroupIndex
            // 
            this.gridColumnGroupIndex.Caption = "页号";
            this.gridColumnGroupIndex.FieldName = "GroupIndex";
            this.gridColumnGroupIndex.Name = "gridColumnGroupIndex";
            this.gridColumnGroupIndex.OptionsColumn.AllowEdit = false;
            this.gridColumnGroupIndex.Visible = true;
            this.gridColumnGroupIndex.VisibleIndex = 1;
            // 
            // gridColumnIndexInGroup
            // 
            this.gridColumnIndexInGroup.Caption = "块号";
            this.gridColumnIndexInGroup.FieldName = "IndexInGroup";
            this.gridColumnIndexInGroup.Name = "gridColumnIndexInGroup";
            this.gridColumnIndexInGroup.OptionsColumn.AllowEdit = false;
            this.gridColumnIndexInGroup.Visible = true;
            this.gridColumnIndexInGroup.VisibleIndex = 2;
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "描述";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.OptionsColumn.AllowEdit = false;
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 0;
            // 
            // gridColumnAlgName
            // 
            this.gridColumnAlgName.Caption = "算法名称";
            this.gridColumnAlgName.FieldName = "AlgName";
            this.gridColumnAlgName.Name = "gridColumnAlgName";
            this.gridColumnAlgName.Visible = true;
            this.gridColumnAlgName.VisibleIndex = 3;
            // 
            // UserControlErr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Name = "UserControlErr";
            this.Size = new System.Drawing.Size(983, 432);
            this.Load += new System.EventHandler(this.UserControlErr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnGroupIndex;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIndexInGroup;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAlgName;
    }
}
