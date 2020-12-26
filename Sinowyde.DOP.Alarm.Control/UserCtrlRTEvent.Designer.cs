namespace Sinowyde.DOP.Alarm.Control
{
    partial class UserCtrlRTEvent
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
            this.btn_Refresh = new DevExpress.XtraEditors.SimpleButton();
            this.gc_RTEvent = new DevExpress.XtraGrid.GridControl();
            this.gv_RTEvent = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.column_Channel_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_VarNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_Timestamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_Content = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lbl_LastTime = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gc_RTEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_RTEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Refresh.Location = new System.Drawing.Point(619, 2);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_Refresh.TabIndex = 7;
            this.btn_Refresh.Text = "刷新";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // gc_RTEvent
            // 
            this.gc_RTEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gc_RTEvent.Location = new System.Drawing.Point(3, 29);
            this.gc_RTEvent.MainView = this.gv_RTEvent;
            this.gc_RTEvent.Name = "gc_RTEvent";
            this.gc_RTEvent.Size = new System.Drawing.Size(693, 365);
            this.gc_RTEvent.TabIndex = 4;
            this.gc_RTEvent.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_RTEvent});
            // 
            // gv_RTEvent
            // 
            this.gv_RTEvent.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.column_Channel_ID,
            this.column_VarNumber,
            this.column_Timestamp,
            this.column_Content});
            this.gv_RTEvent.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gv_RTEvent.GridControl = this.gc_RTEvent;
            this.gv_RTEvent.IndicatorWidth = 10;
            this.gv_RTEvent.Name = "gv_RTEvent";
            this.gv_RTEvent.OptionsBehavior.Editable = false;
            this.gv_RTEvent.OptionsCustomization.AllowColumnMoving = false;
            this.gv_RTEvent.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv_RTEvent.OptionsView.ShowGroupPanel = false;
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
            this.column_Timestamp.Caption = "记录时间";
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
            this.column_Content.Caption = "事件内容";
            this.column_Content.FieldName = "Content";
            this.column_Content.Name = "column_Content";
            this.column_Content.Visible = true;
            this.column_Content.VisibleIndex = 2;
            this.column_Content.Width = 318;
            // 
            // lbl_LastTime
            // 
            this.lbl_LastTime.Location = new System.Drawing.Point(112, 6);
            this.lbl_LastTime.Name = "lbl_LastTime";
            this.lbl_LastTime.Size = new System.Drawing.Size(118, 14);
            this.lbl_LastTime.TabIndex = 6;
            this.lbl_LastTime.Text = "0001-00-00 00:00:00";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(10, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 14);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "上一次刷新时间：";
            // 
            // UserCtrlRTEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.gc_RTEvent);
            this.Controls.Add(this.lbl_LastTime);
            this.Controls.Add(this.labelControl1);
            this.Name = "UserCtrlRTEvent";
            this.Size = new System.Drawing.Size(699, 397);
            this.Load += new System.EventHandler(this.UserCtrlRTEvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gc_RTEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_RTEvent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_Refresh;
        private DevExpress.XtraGrid.GridControl gc_RTEvent;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_RTEvent;
        private DevExpress.XtraGrid.Columns.GridColumn column_Channel_ID;
        private DevExpress.XtraGrid.Columns.GridColumn column_VarNumber;
        private DevExpress.XtraGrid.Columns.GridColumn column_Timestamp;
        private DevExpress.XtraGrid.Columns.GridColumn column_Content;
        private DevExpress.XtraEditors.LabelControl lbl_LastTime;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
