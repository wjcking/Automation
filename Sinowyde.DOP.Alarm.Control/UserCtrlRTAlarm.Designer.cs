namespace Sinowyde.DOP.Alarm.Control
{
    partial class UserCtrlRTAlarm
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
            this.gc_RTAlarm = new DevExpress.XtraGrid.GridControl();
            this.gv_RTAlarm = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.column_Channel_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_VarNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_Timestamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_Content = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_LastTime = new DevExpress.XtraEditors.LabelControl();
            this.btn_Refresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gc_RTAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_RTAlarm)).BeginInit();
            this.SuspendLayout();
            // 
            // gc_RTAlarm
            // 
            this.gc_RTAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gc_RTAlarm.Location = new System.Drawing.Point(3, 29);
            this.gc_RTAlarm.MainView = this.gv_RTAlarm;
            this.gc_RTAlarm.Name = "gc_RTAlarm";
            this.gc_RTAlarm.Size = new System.Drawing.Size(693, 365);
            this.gc_RTAlarm.TabIndex = 0;
            this.gc_RTAlarm.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_RTAlarm});
            // 
            // gv_RTAlarm
            // 
            this.gv_RTAlarm.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.column_Channel_ID,
            this.column_VarNumber,
            this.column_Timestamp,
            this.column_Content});
            this.gv_RTAlarm.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gv_RTAlarm.GridControl = this.gc_RTAlarm;
            this.gv_RTAlarm.IndicatorWidth = 10;
            this.gv_RTAlarm.Name = "gv_RTAlarm";
            this.gv_RTAlarm.OptionsBehavior.Editable = false;
            this.gv_RTAlarm.OptionsCustomization.AllowColumnMoving = false;
            this.gv_RTAlarm.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv_RTAlarm.OptionsView.ShowGroupPanel = false;
            // 
            // column_Channel_ID
            // 
            this.column_Channel_ID.Caption = "编号";
            this.column_Channel_ID.FieldName = "ID";
            this.column_Channel_ID.Name = "column_Channel_ID";
            // 
            // column_VarNumber
            // 
            this.column_VarNumber.Caption = "变量";
            this.column_VarNumber.FieldName = "VarNumber";
            this.column_VarNumber.Name = "column_VarNumber";
            this.column_VarNumber.Visible = true;
            this.column_VarNumber.VisibleIndex = 0;
            this.column_VarNumber.Width = 80;
            // 
            // column_Timestamp
            // 
            this.column_Timestamp.Caption = "报警时间";
            this.column_Timestamp.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.column_Timestamp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.column_Timestamp.FieldName = "Timestamp";
            this.column_Timestamp.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.column_Timestamp.Name = "column_Timestamp";
            this.column_Timestamp.Visible = true;
            this.column_Timestamp.VisibleIndex = 1;
            this.column_Timestamp.Width = 100;
            // 
            // column_Content
            // 
            this.column_Content.Caption = "报警内容";
            this.column_Content.FieldName = "Content";
            this.column_Content.Name = "column_Content";
            this.column_Content.Visible = true;
            this.column_Content.VisibleIndex = 2;
            this.column_Content.Width = 318;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(10, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "上一次刷新时间：";
            // 
            // lbl_LastTime
            // 
            this.lbl_LastTime.Location = new System.Drawing.Point(112, 6);
            this.lbl_LastTime.Name = "lbl_LastTime";
            this.lbl_LastTime.Size = new System.Drawing.Size(118, 14);
            this.lbl_LastTime.TabIndex = 2;
            this.lbl_LastTime.Text = "0001-00-00 00:00:00";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Refresh.Location = new System.Drawing.Point(619, 2);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_Refresh.TabIndex = 3;
            this.btn_Refresh.Text = "刷新";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // UserCtrlRTAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.lbl_LastTime);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gc_RTAlarm);
            this.Name = "UserCtrlRTAlarm";
            this.Size = new System.Drawing.Size(699, 397);
            this.Load += new System.EventHandler(this.UserCtrlRTAlarm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gc_RTAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_RTAlarm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gc_RTAlarm;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_RTAlarm;
        private DevExpress.XtraGrid.Columns.GridColumn column_Channel_ID;
        private DevExpress.XtraGrid.Columns.GridColumn column_VarNumber;
        private DevExpress.XtraGrid.Columns.GridColumn column_Timestamp;
        private DevExpress.XtraGrid.Columns.GridColumn column_Content;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lbl_LastTime;
        private DevExpress.XtraEditors.SimpleButton btn_Refresh;
    }
}
