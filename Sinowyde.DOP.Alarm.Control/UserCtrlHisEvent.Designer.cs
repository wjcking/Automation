namespace Sinowyde.DOP.Alarm.Control
{
    partial class UserCtrlHisEvent
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
            this.dtxt_Timestamp_End = new DevExpress.XtraEditors.DateEdit();
            this.dtxt_Timestamp_Begin = new DevExpress.XtraEditors.DateEdit();
            this.lbl_Type = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Timestamp = new DevExpress.XtraEditors.LabelControl();
            this.lbl_To1 = new DevExpress.XtraEditors.LabelControl();
            this.gv_RTEvent = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.column_Channel_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_VarNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_Timestamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_Content = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_RTEvent = new DevExpress.XtraGrid.GridControl();
            this.panel_Bottom = new DevExpress.XtraEditors.PanelControl();
            this.panel_Top = new DevExpress.XtraEditors.PanelControl();
            this.cmb_Type = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_Level = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
            this.txt_EventType = new DevExpress.XtraEditors.TextEdit();
            this.txt_Number = new DevExpress.XtraEditors.TextEdit();
            this.lbl_Level = new DevExpress.XtraEditors.LabelControl();
            this.lbl_EventType = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Number = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_Timestamp_End.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_Timestamp_End.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_Timestamp_Begin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_Timestamp_Begin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_RTEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_RTEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_Bottom)).BeginInit();
            this.panel_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel_Top)).BeginInit();
            this.panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Level.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EventType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Number.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dtxt_Timestamp_End
            // 
            this.dtxt_Timestamp_End.EditValue = null;
            this.dtxt_Timestamp_End.Location = new System.Drawing.Point(213, 33);
            this.dtxt_Timestamp_End.Name = "dtxt_Timestamp_End";
            this.dtxt_Timestamp_End.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtxt_Timestamp_End.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtxt_Timestamp_End.Size = new System.Drawing.Size(107, 20);
            this.dtxt_Timestamp_End.TabIndex = 8;
            // 
            // dtxt_Timestamp_Begin
            // 
            this.dtxt_Timestamp_Begin.EditValue = null;
            this.dtxt_Timestamp_Begin.Location = new System.Drawing.Point(82, 33);
            this.dtxt_Timestamp_Begin.Name = "dtxt_Timestamp_Begin";
            this.dtxt_Timestamp_Begin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtxt_Timestamp_Begin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtxt_Timestamp_Begin.Size = new System.Drawing.Size(107, 20);
            this.dtxt_Timestamp_Begin.TabIndex = 8;
            // 
            // lbl_Type
            // 
            this.lbl_Type.Location = new System.Drawing.Point(573, 10);
            this.lbl_Type.Name = "lbl_Type";
            this.lbl_Type.Size = new System.Drawing.Size(60, 14);
            this.lbl_Type.TabIndex = 1;
            this.lbl_Type.Text = "报警类型：";
            // 
            // lbl_Timestamp
            // 
            this.lbl_Timestamp.Location = new System.Drawing.Point(18, 36);
            this.lbl_Timestamp.Name = "lbl_Timestamp";
            this.lbl_Timestamp.Size = new System.Drawing.Size(60, 14);
            this.lbl_Timestamp.TabIndex = 1;
            this.lbl_Timestamp.Text = "记录时间：";
            // 
            // lbl_To1
            // 
            this.lbl_To1.Location = new System.Drawing.Point(195, 36);
            this.lbl_To1.Name = "lbl_To1";
            this.lbl_To1.Size = new System.Drawing.Size(12, 14);
            this.lbl_To1.TabIndex = 1;
            this.lbl_To1.Text = "至";
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
            // gc_RTEvent
            // 
            this.gc_RTEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_RTEvent.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gc_RTEvent.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.gc_RTEvent.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gc_RTEvent.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gc_RTEvent.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gc_RTEvent.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.gc_RTEvent.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gc_RTEvent.EmbeddedNavigator.Buttons.First.Hint = "首页";
            this.gc_RTEvent.EmbeddedNavigator.Buttons.Last.Hint = "尾页";
            this.gc_RTEvent.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.gc_RTEvent.EmbeddedNavigator.Buttons.NextPage.Hint = "下一页";
            this.gc_RTEvent.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.gc_RTEvent.EmbeddedNavigator.Buttons.PrevPage.Hint = "上一页";
            this.gc_RTEvent.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gc_RTEvent.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gc_RTEvent.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.End;
            this.gc_RTEvent.EmbeddedNavigator.TextStringFormat = "第 {0}条记录（共{1}条）";
            this.gc_RTEvent.Location = new System.Drawing.Point(2, 2);
            this.gc_RTEvent.MainView = this.gv_RTEvent;
            this.gc_RTEvent.Name = "gc_RTEvent";
            this.gc_RTEvent.Size = new System.Drawing.Size(756, 411);
            this.gc_RTEvent.TabIndex = 0;
            this.gc_RTEvent.UseEmbeddedNavigator = true;
            this.gc_RTEvent.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_RTEvent});
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Bottom.Controls.Add(this.gc_RTEvent);
            this.panel_Bottom.Location = new System.Drawing.Point(0, 64);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(760, 415);
            this.panel_Bottom.TabIndex = 5;
            // 
            // panel_Top
            // 
            this.panel_Top.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Top.Controls.Add(this.dtxt_Timestamp_End);
            this.panel_Top.Controls.Add(this.dtxt_Timestamp_Begin);
            this.panel_Top.Controls.Add(this.cmb_Type);
            this.panel_Top.Controls.Add(this.cmb_Level);
            this.panel_Top.Controls.Add(this.btn_Search);
            this.panel_Top.Controls.Add(this.txt_EventType);
            this.panel_Top.Controls.Add(this.txt_Number);
            this.panel_Top.Controls.Add(this.lbl_Type);
            this.panel_Top.Controls.Add(this.lbl_Timestamp);
            this.panel_Top.Controls.Add(this.lbl_Level);
            this.panel_Top.Controls.Add(this.lbl_EventType);
            this.panel_Top.Controls.Add(this.lbl_To1);
            this.panel_Top.Controls.Add(this.lbl_Number);
            this.panel_Top.Location = new System.Drawing.Point(2, 2);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(756, 60);
            this.panel_Top.TabIndex = 6;
            // 
            // cmb_Type
            // 
            this.cmb_Type.Location = new System.Drawing.Point(636, 7);
            this.cmb_Type.Name = "cmb_Type";
            this.cmb_Type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_Type.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_Type.Size = new System.Drawing.Size(100, 20);
            this.cmb_Type.TabIndex = 4;
            // 
            // cmb_Level
            // 
            this.cmb_Level.Location = new System.Drawing.Point(431, 7);
            this.cmb_Level.Name = "cmb_Level";
            this.cmb_Level.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_Level.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_Level.Size = new System.Drawing.Size(100, 20);
            this.cmb_Level.TabIndex = 4;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(636, 32);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(100, 23);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.Text = "查 询";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // txt_EventType
            // 
            this.txt_EventType.Location = new System.Drawing.Point(431, 33);
            this.txt_EventType.Name = "txt_EventType";
            this.txt_EventType.Size = new System.Drawing.Size(100, 20);
            this.txt_EventType.TabIndex = 2;
            // 
            // txt_Number
            // 
            this.txt_Number.Location = new System.Drawing.Point(81, 7);
            this.txt_Number.Name = "txt_Number";
            this.txt_Number.Size = new System.Drawing.Size(239, 20);
            this.txt_Number.TabIndex = 2;
            // 
            // lbl_Level
            // 
            this.lbl_Level.Location = new System.Drawing.Point(358, 10);
            this.lbl_Level.Name = "lbl_Level";
            this.lbl_Level.Size = new System.Drawing.Size(60, 14);
            this.lbl_Level.TabIndex = 1;
            this.lbl_Level.Text = "报警级别：";
            // 
            // lbl_EventType
            // 
            this.lbl_EventType.Location = new System.Drawing.Point(358, 36);
            this.lbl_EventType.Name = "lbl_EventType";
            this.lbl_EventType.Size = new System.Drawing.Size(60, 14);
            this.lbl_EventType.TabIndex = 1;
            this.lbl_EventType.Text = "事件类型：";
            // 
            // lbl_Number
            // 
            this.lbl_Number.Location = new System.Drawing.Point(18, 10);
            this.lbl_Number.Name = "lbl_Number";
            this.lbl_Number.Size = new System.Drawing.Size(36, 14);
            this.lbl_Number.TabIndex = 1;
            this.lbl_Number.Text = "点名：";
            // 
            // UserCtrlHisEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_Bottom);
            this.Controls.Add(this.panel_Top);
            this.Name = "UserCtrlHisEvent";
            this.Size = new System.Drawing.Size(760, 480);
            this.Load += new System.EventHandler(this.UserCtrlHisEvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_Timestamp_End.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_Timestamp_End.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_Timestamp_Begin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_Timestamp_Begin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_RTEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_RTEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_Bottom)).EndInit();
            this.panel_Bottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel_Top)).EndInit();
            this.panel_Top.ResumeLayout(false);
            this.panel_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Level.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EventType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Number.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dtxt_Timestamp_End;
        private DevExpress.XtraEditors.DateEdit dtxt_Timestamp_Begin;
        private DevExpress.XtraEditors.LabelControl lbl_Type;
        private DevExpress.XtraEditors.LabelControl lbl_Timestamp;
        private DevExpress.XtraEditors.LabelControl lbl_To1;
        private DevExpress.XtraGrid.Columns.GridColumn column_Content;
        private DevExpress.XtraGrid.Columns.GridColumn column_Timestamp;
        private DevExpress.XtraGrid.Columns.GridColumn column_VarNumber;
        private DevExpress.XtraGrid.Columns.GridColumn column_Channel_ID;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_RTEvent;
        private DevExpress.XtraGrid.GridControl gc_RTEvent;
        private DevExpress.XtraEditors.PanelControl panel_Bottom;
        private DevExpress.XtraEditors.PanelControl panel_Top;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_Type;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_Level;
        private DevExpress.XtraEditors.SimpleButton btn_Search;
        private DevExpress.XtraEditors.TextEdit txt_Number;
        private DevExpress.XtraEditors.LabelControl lbl_Level;
        private DevExpress.XtraEditors.LabelControl lbl_Number;
        private DevExpress.XtraEditors.TextEdit txt_EventType;
        private DevExpress.XtraEditors.LabelControl lbl_EventType;
    }
}
