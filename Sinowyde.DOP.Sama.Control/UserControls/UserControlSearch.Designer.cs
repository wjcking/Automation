namespace Sinowyde.DOP.Sama.Control.UserControls
{
    partial class UserControlSearch
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
            this.gridColumnGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAlg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnVariableType = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridControl.Size = new System.Drawing.Size(1072, 499);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnGroupIndex,
            this.gridColumnIndexInGroup,
            this.gridColumnGroup,
            this.gridColumnAlg,
            this.gridColumnNumber,
            this.gridColumnName,
            this.gridColumnVariableType});
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
            this.gridColumnGroupIndex.VisibleIndex = 0;
            // 
            // gridColumnIndexInGroup
            // 
            this.gridColumnIndexInGroup.Caption = "块号";
            this.gridColumnIndexInGroup.FieldName = "IndexInGroup";
            this.gridColumnIndexInGroup.Name = "gridColumnIndexInGroup";
            this.gridColumnIndexInGroup.OptionsColumn.AllowEdit = false;
            this.gridColumnIndexInGroup.Visible = true;
            this.gridColumnIndexInGroup.VisibleIndex = 1;
            // 
            // gridColumnGroup
            // 
            this.gridColumnGroup.Caption = "算法类名";
            this.gridColumnGroup.FieldName = "Group";
            this.gridColumnGroup.Name = "gridColumnGroup";
            this.gridColumnGroup.OptionsColumn.AllowEdit = false;
            this.gridColumnGroup.Visible = true;
            this.gridColumnGroup.VisibleIndex = 2;
            // 
            // gridColumnAlg
            // 
            this.gridColumnAlg.Caption = "算法名";
            this.gridColumnAlg.FieldName = "Alg";
            this.gridColumnAlg.Name = "gridColumnAlg";
            this.gridColumnAlg.Visible = true;
            this.gridColumnAlg.VisibleIndex = 3;
            // 
            // gridColumnNumber
            // 
            this.gridColumnNumber.Caption = "点名称";
            this.gridColumnNumber.FieldName = "Number";
            this.gridColumnNumber.Name = "gridColumnNumber";
            this.gridColumnNumber.Visible = true;
            this.gridColumnNumber.VisibleIndex = 4;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "点中文名称";
            this.gridColumnName.FieldName = "Name";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 5;
            // 
            // gridColumnVariableType
            // 
            this.gridColumnVariableType.Caption = "点类型";
            this.gridColumnVariableType.FieldName = "VariableType";
            this.gridColumnVariableType.Name = "gridColumnVariableType";
            this.gridColumnVariableType.Visible = true;
            this.gridColumnVariableType.VisibleIndex = 6;
            // 
            // UserControlSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Name = "UserControlSearch";
            this.Size = new System.Drawing.Size(1072, 499);
            this.Load += new System.EventHandler(this.UserControlSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnGroupIndex;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIndexInGroup;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnGroup;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAlg;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnVariableType;
    }
}
