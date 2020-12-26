namespace Sinowyde.DOP.Alarm.Control
{
    partial class UserCtrlHisAlarm
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
            this.lbl_Number = new DevExpress.XtraEditors.LabelControl();
            this.txt_Number = new DevExpress.XtraEditors.TextEdit();
            this.btn_Search = new DevExpress.XtraEditors.SimpleButton();
            this.panel_Top = new DevExpress.XtraEditors.PanelControl();
            this.dtxt_ConfirmTime_End = new DevExpress.XtraEditors.DateEdit();
            this.dtxt_ConfirmTime_Begin = new DevExpress.XtraEditors.DateEdit();
            this.dtxt_Timestamp_End = new DevExpress.XtraEditors.DateEdit();
            this.dtxt_Timestamp_Begin = new DevExpress.XtraEditors.DateEdit();
            this.txt_Operator = new DevExpress.XtraEditors.TextEdit();
            this.lbl_Operator = new DevExpress.XtraEditors.LabelControl();
            this.cmb_Type = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_Level = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_IsConfirm = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbl_ConfirmTime = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Type = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Timestamp = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Level = new DevExpress.XtraEditors.LabelControl();
            this.lbl_To2 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_IsConfirm = new DevExpress.XtraEditors.LabelControl();
            this.lbl_To1 = new DevExpress.XtraEditors.LabelControl();
            this.panel_Bottom = new DevExpress.XtraEditors.PanelControl();
            this.gc_RTAlarm = new DevExpress.XtraGrid.GridControl();
            this.gv_RTAlarm = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.column_Channel_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_VarNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_Timestamp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_Content = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_isConfirm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_ConfirmTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.column_Operator = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Number.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_Top)).BeginInit();
            this.panel_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_ConfirmTime_End.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_ConfirmTime_End.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_ConfirmTime_Begin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_ConfirmTime_Begin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_Timestamp_End.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_Timestamp_End.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_Timestamp_Begin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_Timestamp_Begin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Operator.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Level.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IsConfirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_Bottom)).BeginInit();
            this.panel_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_RTAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_RTAlarm)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Number
            // 
            this.lbl_Number.Location = new System.Drawing.Point(18, 10);
            this.lbl_Number.Name = "lbl_Number";
            this.lbl_Number.Size = new System.Drawing.Size(36, 14);
            this.lbl_Number.TabIndex = 1;
            this.lbl_Number.Text = "点名：";
            // 
            // txt_Number
            // 
            this.txt_Number.Location = new System.Drawing.Point(81, 7);
            this.txt_Number.Name = "txt_Number";
            this.txt_Number.Size = new System.Drawing.Size(239, 20);
            this.txt_Number.TabIndex = 2;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(636, 58);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(100, 23);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.Text = "查 询";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // panel_Top
            // 
            this.panel_Top.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Top.Controls.Add(this.dtxt_ConfirmTime_End);
            this.panel_Top.Controls.Add(this.dtxt_ConfirmTime_Begin);
            this.panel_Top.Controls.Add(this.dtxt_Timestamp_End);
            this.panel_Top.Controls.Add(this.dtxt_Timestamp_Begin);
            this.panel_Top.Controls.Add(this.txt_Operator);
            this.panel_Top.Controls.Add(this.lbl_Operator);
            this.panel_Top.Controls.Add(this.cmb_Type);
            this.panel_Top.Controls.Add(this.cmb_Level);
            this.panel_Top.Controls.Add(this.cmb_IsConfirm);
            this.panel_Top.Controls.Add(this.btn_Search);
            this.panel_Top.Controls.Add(this.lbl_ConfirmTime);
            this.panel_Top.Controls.Add(this.txt_Number);
            this.panel_Top.Controls.Add(this.lbl_Type);
            this.panel_Top.Controls.Add(this.lbl_Timestamp);
            this.panel_Top.Controls.Add(this.lbl_Level);
            this.panel_Top.Controls.Add(this.lbl_To2);
            this.panel_Top.Controls.Add(this.lbl_IsConfirm);
            this.panel_Top.Controls.Add(this.lbl_To1);
            this.panel_Top.Controls.Add(this.lbl_Number);
            this.panel_Top.Location = new System.Drawing.Point(2, 2);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(756, 88);
            this.panel_Top.TabIndex = 4;
            // 
            // dtxt_ConfirmTime_End
            // 
            this.dtxt_ConfirmTime_End.EditValue = null;
            this.dtxt_ConfirmTime_End.Location = new System.Drawing.Point(213, 59);
            this.dtxt_ConfirmTime_End.Name = "dtxt_ConfirmTime_End";
            this.dtxt_ConfirmTime_End.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtxt_ConfirmTime_End.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtxt_ConfirmTime_End.Size = new System.Drawing.Size(107, 20);
            this.dtxt_ConfirmTime_End.TabIndex = 8;
            // 
            // dtxt_ConfirmTime_Begin
            // 
            this.dtxt_ConfirmTime_Begin.EditValue = null;
            this.dtxt_ConfirmTime_Begin.Location = new System.Drawing.Point(82, 59);
            this.dtxt_ConfirmTime_Begin.Name = "dtxt_ConfirmTime_Begin";
            this.dtxt_ConfirmTime_Begin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtxt_ConfirmTime_Begin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtxt_ConfirmTime_Begin.Size = new System.Drawing.Size(107, 20);
            this.dtxt_ConfirmTime_Begin.TabIndex = 8;
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
            // txt_Operator
            // 
            this.txt_Operator.Location = new System.Drawing.Point(636, 33);
            this.txt_Operator.Name = "txt_Operator";
            this.txt_Operator.Size = new System.Drawing.Size(100, 20);
            this.txt_Operator.TabIndex = 6;
            // 
            // lbl_Operator
            // 
            this.lbl_Operator.Location = new System.Drawing.Point(573, 36);
            this.lbl_Operator.Name = "lbl_Operator";
            this.lbl_Operator.Size = new System.Drawing.Size(48, 14);
            this.lbl_Operator.TabIndex = 5;
            this.lbl_Operator.Text = "确认人：";
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
            // cmb_IsConfirm
            // 
            this.cmb_IsConfirm.Location = new System.Drawing.Point(431, 33);
            this.cmb_IsConfirm.Name = "cmb_IsConfirm";
            this.cmb_IsConfirm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_IsConfirm.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_IsConfirm.Size = new System.Drawing.Size(100, 20);
            this.cmb_IsConfirm.TabIndex = 4;
            // 
            // lbl_ConfirmTime
            // 
            this.lbl_ConfirmTime.Location = new System.Drawing.Point(18, 62);
            this.lbl_ConfirmTime.Name = "lbl_ConfirmTime";
            this.lbl_ConfirmTime.Size = new System.Drawing.Size(60, 14);
            this.lbl_ConfirmTime.TabIndex = 1;
            this.lbl_ConfirmTime.Text = "确认时间：";
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
            this.lbl_Timestamp.Text = "报警时间：";
            // 
            // lbl_Level
            // 
            this.lbl_Level.Location = new System.Drawing.Point(358, 10);
            this.lbl_Level.Name = "lbl_Level";
            this.lbl_Level.Size = new System.Drawing.Size(60, 14);
            this.lbl_Level.TabIndex = 1;
            this.lbl_Level.Text = "报警级别：";
            // 
            // lbl_To2
            // 
            this.lbl_To2.Location = new System.Drawing.Point(195, 62);
            this.lbl_To2.Name = "lbl_To2";
            this.lbl_To2.Size = new System.Drawing.Size(12, 14);
            this.lbl_To2.TabIndex = 1;
            this.lbl_To2.Text = "至";
            // 
            // lbl_IsConfirm
            // 
            this.lbl_IsConfirm.Location = new System.Drawing.Point(358, 36);
            this.lbl_IsConfirm.Name = "lbl_IsConfirm";
            this.lbl_IsConfirm.Size = new System.Drawing.Size(60, 14);
            this.lbl_IsConfirm.TabIndex = 1;
            this.lbl_IsConfirm.Text = "是否确认：";
            // 
            // lbl_To1
            // 
            this.lbl_To1.Location = new System.Drawing.Point(195, 36);
            this.lbl_To1.Name = "lbl_To1";
            this.lbl_To1.Size = new System.Drawing.Size(12, 14);
            this.lbl_To1.TabIndex = 1;
            this.lbl_To1.Text = "至";
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Bottom.Controls.Add(this.gc_RTAlarm);
            this.panel_Bottom.Location = new System.Drawing.Point(0, 92);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(760, 388);
            this.panel_Bottom.TabIndex = 4;
            // 
            // gc_RTAlarm
            // 
            this.gc_RTAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_RTAlarm.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gc_RTAlarm.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.gc_RTAlarm.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gc_RTAlarm.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.gc_RTAlarm.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gc_RTAlarm.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.gc_RTAlarm.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gc_RTAlarm.EmbeddedNavigator.Buttons.First.Hint = "首页";
            this.gc_RTAlarm.EmbeddedNavigator.Buttons.Last.Hint = "尾页";
            this.gc_RTAlarm.EmbeddedNavigator.Buttons.Next.Visible = false;
            this.gc_RTAlarm.EmbeddedNavigator.Buttons.NextPage.Hint = "下一页";
            this.gc_RTAlarm.EmbeddedNavigator.Buttons.Prev.Visible = false;
            this.gc_RTAlarm.EmbeddedNavigator.Buttons.PrevPage.Hint = "上一页";
            this.gc_RTAlarm.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.gc_RTAlarm.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gc_RTAlarm.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.End;
            this.gc_RTAlarm.EmbeddedNavigator.TextStringFormat = "第 {0}条记录（共{1}条）";
            this.gc_RTAlarm.Location = new System.Drawing.Point(2, 2);
            this.gc_RTAlarm.MainView = this.gv_RTAlarm;
            this.gc_RTAlarm.Name = "gc_RTAlarm";
            this.gc_RTAlarm.Size = new System.Drawing.Size(756, 384);
            this.gc_RTAlarm.TabIndex = 0;
            this.gc_RTAlarm.UseEmbeddedNavigator = true;
            this.gc_RTAlarm.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_RTAlarm});
            // 
            // gv_RTAlarm
            // 
            this.gv_RTAlarm.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.column_Channel_ID,
            this.column_VarNumber,
            this.column_Timestamp,
            this.column_Content,
            this.column_isConfirm,
            this.column_ConfirmTime,
            this.column_Operator});
            this.gv_RTAlarm.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gv_RTAlarm.GridControl = this.gc_RTAlarm;
            this.gv_RTAlarm.IndicatorWidth = 10;
            this.gv_RTAlarm.Name = "gv_RTAlarm";
            this.gv_RTAlarm.OptionsBehavior.Editable = false;
            this.gv_RTAlarm.OptionsCustomization.AllowColumnMoving = false;
            this.gv_RTAlarm.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv_RTAlarm.OptionsView.ShowGroupPanel = false;
            this.gv_RTAlarm.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gv_RTAlarm_PopupMenuShowing);
            this.gv_RTAlarm.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gv_RTAlarm_CustomColumnDisplayText);
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
            // column_isConfirm
            // 
            this.column_isConfirm.Caption = "是否确认";
            this.column_isConfirm.FieldName = "Operator";
            this.column_isConfirm.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.column_isConfirm.Name = "column_isConfirm";
            this.column_isConfirm.Visible = true;
            this.column_isConfirm.VisibleIndex = 3;
            // 
            // column_ConfirmTime
            // 
            this.column_ConfirmTime.Caption = "确认时间";
            this.column_ConfirmTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.column_ConfirmTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.column_ConfirmTime.FieldName = "ConfirmTime";
            this.column_ConfirmTime.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.column_ConfirmTime.Name = "column_ConfirmTime";
            this.column_ConfirmTime.Visible = true;
            this.column_ConfirmTime.VisibleIndex = 4;
            // 
            // column_Operator
            // 
            this.column_Operator.Caption = "确认人";
            this.column_Operator.FieldName = "Operator";
            this.column_Operator.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.column_Operator.Name = "column_Operator";
            this.column_Operator.Visible = true;
            this.column_Operator.VisibleIndex = 5;
            // 
            // UserCtrlHisAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_Bottom);
            this.Controls.Add(this.panel_Top);
            this.Name = "UserCtrlHisAlarm";
            this.Size = new System.Drawing.Size(760, 480);
            this.Load += new System.EventHandler(this.UserCtrlHisAlarm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Number.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_Top)).EndInit();
            this.panel_Top.ResumeLayout(false);
            this.panel_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_ConfirmTime_End.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_ConfirmTime_End.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_ConfirmTime_Begin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_ConfirmTime_Begin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_Timestamp_End.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_Timestamp_End.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_Timestamp_Begin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtxt_Timestamp_Begin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Operator.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Level.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IsConfirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_Bottom)).EndInit();
            this.panel_Bottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_RTAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_RTAlarm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_Number;
        private DevExpress.XtraEditors.TextEdit txt_Number;
        private DevExpress.XtraEditors.SimpleButton btn_Search;
        private DevExpress.XtraEditors.PanelControl panel_Top;
        private DevExpress.XtraEditors.PanelControl panel_Bottom;
        private DevExpress.XtraGrid.GridControl gc_RTAlarm;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_RTAlarm;
        private DevExpress.XtraGrid.Columns.GridColumn column_Channel_ID;
        private DevExpress.XtraGrid.Columns.GridColumn column_VarNumber;
        private DevExpress.XtraGrid.Columns.GridColumn column_Timestamp;
        private DevExpress.XtraGrid.Columns.GridColumn column_Content;
        private DevExpress.XtraGrid.Columns.GridColumn column_isConfirm;
        private DevExpress.XtraGrid.Columns.GridColumn column_ConfirmTime;
        private DevExpress.XtraGrid.Columns.GridColumn column_Operator;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_IsConfirm;
        private DevExpress.XtraEditors.LabelControl lbl_IsConfirm;
        private DevExpress.XtraEditors.TextEdit txt_Operator;
        private DevExpress.XtraEditors.LabelControl lbl_Operator;
        private DevExpress.XtraEditors.DateEdit dtxt_Timestamp_Begin;
        private DevExpress.XtraEditors.DateEdit dtxt_Timestamp_End;
        private DevExpress.XtraEditors.LabelControl lbl_Timestamp;
        private DevExpress.XtraEditors.LabelControl lbl_To1;
        private DevExpress.XtraEditors.DateEdit dtxt_ConfirmTime_End;
        private DevExpress.XtraEditors.DateEdit dtxt_ConfirmTime_Begin;
        private DevExpress.XtraEditors.LabelControl lbl_ConfirmTime;
        private DevExpress.XtraEditors.LabelControl lbl_To2;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_Type;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_Level;
        private DevExpress.XtraEditors.LabelControl lbl_Type;
        private DevExpress.XtraEditors.LabelControl lbl_Level;
    }
}
