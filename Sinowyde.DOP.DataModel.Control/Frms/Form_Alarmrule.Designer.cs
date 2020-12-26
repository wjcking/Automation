namespace Sinowyde.DOP.DataModel.Control
{
    partial class Form_Alarmrule
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmb_EventType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_AlarmLevel = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_AlarmType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.cb_IsTransfer = new DevExpress.XtraEditors.CheckEdit();
            this.cb_RecordEvent = new DevExpress.XtraEditors.CheckEdit();
            this.txt_AlarmTimeSpan = new DevExpress.XtraEditors.SpinEdit();
            this.txt_LimitValue = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gc_AlarmRule = new DevExpress.XtraGrid.GridControl();
            this.gv_AlarmRule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AlarmType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AlarmLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_LimitValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_AlarmTimeSpan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_RecordEvent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_EventType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_VariableID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_EventType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_AlarmLevel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_AlarmType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_IsTransfer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_RecordEvent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_AlarmTimeSpan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LimitValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_AlarmRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_AlarmRule)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cmb_EventType);
            this.panelControl1.Controls.Add(this.cmb_AlarmLevel);
            this.panelControl1.Controls.Add(this.cmb_AlarmType);
            this.panelControl1.Controls.Add(this.btn_Close);
            this.panelControl1.Controls.Add(this.btn_Save);
            this.panelControl1.Controls.Add(this.cb_IsTransfer);
            this.panelControl1.Controls.Add(this.cb_RecordEvent);
            this.panelControl1.Controls.Add(this.txt_AlarmTimeSpan);
            this.panelControl1.Controls.Add(this.txt_LimitValue);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(2, 324);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(648, 95);
            this.panelControl1.TabIndex = 0;
            // 
            // cmb_EventType
            // 
            this.cmb_EventType.Location = new System.Drawing.Point(518, 35);
            this.cmb_EventType.Name = "cmb_EventType";
            this.cmb_EventType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_EventType.Size = new System.Drawing.Size(121, 20);
            this.cmb_EventType.TabIndex = 39;
            // 
            // cmb_AlarmLevel
            // 
            this.cmb_AlarmLevel.Location = new System.Drawing.Point(317, 6);
            this.cmb_AlarmLevel.Name = "cmb_AlarmLevel";
            this.cmb_AlarmLevel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_AlarmLevel.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_AlarmLevel.Size = new System.Drawing.Size(121, 20);
            this.cmb_AlarmLevel.TabIndex = 39;
            // 
            // cmb_AlarmType
            // 
            this.cmb_AlarmType.Location = new System.Drawing.Point(107, 6);
            this.cmb_AlarmType.Name = "cmb_AlarmType";
            this.cmb_AlarmType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_AlarmType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_AlarmType.Size = new System.Drawing.Size(121, 20);
            this.cmb_AlarmType.TabIndex = 39;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(564, 66);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 38;
            this.btn_Close.Text = "清空";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(472, 66);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 37;
            this.btn_Save.Text = "新增";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // cb_IsTransfer
            // 
            this.cb_IsTransfer.Location = new System.Drawing.Point(107, 64);
            this.cb_IsTransfer.Name = "cb_IsTransfer";
            this.cb_IsTransfer.Properties.Caption = "";
            this.cb_IsTransfer.Size = new System.Drawing.Size(75, 19);
            this.cb_IsTransfer.TabIndex = 10;
            // 
            // cb_RecordEvent
            // 
            this.cb_RecordEvent.Location = new System.Drawing.Point(317, 36);
            this.cb_RecordEvent.Name = "cb_RecordEvent";
            this.cb_RecordEvent.Properties.Caption = "";
            this.cb_RecordEvent.Size = new System.Drawing.Size(75, 19);
            this.cb_RecordEvent.TabIndex = 10;
            // 
            // txt_AlarmTimeSpan
            // 
            this.txt_AlarmTimeSpan.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_AlarmTimeSpan.Location = new System.Drawing.Point(107, 35);
            this.txt_AlarmTimeSpan.Name = "txt_AlarmTimeSpan";
            this.txt_AlarmTimeSpan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_AlarmTimeSpan.Properties.Mask.EditMask = "f0";
            this.txt_AlarmTimeSpan.Size = new System.Drawing.Size(121, 20);
            this.txt_AlarmTimeSpan.TabIndex = 8;
            // 
            // txt_LimitValue
            // 
            this.txt_LimitValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_LimitValue.Location = new System.Drawing.Point(518, 6);
            this.txt_LimitValue.Name = "txt_LimitValue";
            this.txt_LimitValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_LimitValue.Properties.Mask.EditMask = "f2";
            this.txt_LimitValue.Size = new System.Drawing.Size(121, 20);
            this.txt_LimitValue.TabIndex = 8;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(10, 38);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(77, 14);
            this.labelControl6.TabIndex = 7;
            this.labelControl6.Text = "报警间隔(ms):";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(459, 38);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 14);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "事件类型:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(10, 66);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(52, 14);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "是否上传:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(256, 38);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 14);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "记录事件:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(471, 9);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "极限值:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(256, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "报警等级:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "报警类型:";
            // 
            // gc_AlarmRule
            // 
            this.gc_AlarmRule.Location = new System.Drawing.Point(2, 2);
            this.gc_AlarmRule.MainView = this.gv_AlarmRule;
            this.gc_AlarmRule.Name = "gc_AlarmRule";
            this.gc_AlarmRule.Size = new System.Drawing.Size(648, 316);
            this.gc_AlarmRule.TabIndex = 1;
            this.gc_AlarmRule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_AlarmRule});
            // 
            // gv_AlarmRule
            // 
            this.gv_AlarmRule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ID,
            this.col_AlarmType,
            this.col_AlarmLevel,
            this.col_LimitValue,
            this.col_AlarmTimeSpan,
            this.col_RecordEvent,
            this.col_EventType,
            this.col_VariableID});
            this.gv_AlarmRule.GridControl = this.gc_AlarmRule;
            this.gv_AlarmRule.Name = "gv_AlarmRule";
            this.gv_AlarmRule.OptionsBehavior.Editable = false;
            this.gv_AlarmRule.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv_AlarmRule.OptionsView.ShowGroupPanel = false;
            this.gv_AlarmRule.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gv_PopupMenuShowing);
            this.gv_AlarmRule.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.gv_CustomDrawEmptyForeground);
            this.gv_AlarmRule.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gv_CustomColumnDisplayText);
            this.gv_AlarmRule.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gc_CalcVariable_MouseDown);
            // 
            // col_ID
            // 
            this.col_ID.Caption = "编号";
            this.col_ID.FieldName = "ID";
            this.col_ID.Name = "col_ID";
            // 
            // col_AlarmType
            // 
            this.col_AlarmType.Caption = "报警类型";
            this.col_AlarmType.FieldName = "AlarmType";
            this.col_AlarmType.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.col_AlarmType.Name = "col_AlarmType";
            this.col_AlarmType.Visible = true;
            this.col_AlarmType.VisibleIndex = 0;
            // 
            // col_AlarmLevel
            // 
            this.col_AlarmLevel.Caption = "报警等级";
            this.col_AlarmLevel.FieldName = "AlarmLevel";
            this.col_AlarmLevel.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.col_AlarmLevel.Name = "col_AlarmLevel";
            this.col_AlarmLevel.Visible = true;
            this.col_AlarmLevel.VisibleIndex = 1;
            // 
            // col_LimitValue
            // 
            this.col_LimitValue.Caption = "极限值";
            this.col_LimitValue.FieldName = "LimitValue";
            this.col_LimitValue.Name = "col_LimitValue";
            this.col_LimitValue.Visible = true;
            this.col_LimitValue.VisibleIndex = 2;
            // 
            // col_AlarmTimeSpan
            // 
            this.col_AlarmTimeSpan.Caption = "报警间隔(分钟)";
            this.col_AlarmTimeSpan.FieldName = "AlarmTimeSpan";
            this.col_AlarmTimeSpan.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.col_AlarmTimeSpan.Name = "col_AlarmTimeSpan";
            this.col_AlarmTimeSpan.Visible = true;
            this.col_AlarmTimeSpan.VisibleIndex = 3;
            // 
            // col_RecordEvent
            // 
            this.col_RecordEvent.Caption = "记录事件";
            this.col_RecordEvent.FieldName = "RecordEvent";
            this.col_RecordEvent.Name = "col_RecordEvent";
            this.col_RecordEvent.Visible = true;
            this.col_RecordEvent.VisibleIndex = 4;
            // 
            // col_EventType
            // 
            this.col_EventType.Caption = "事件类型";
            this.col_EventType.FieldName = "EventType";
            this.col_EventType.Name = "col_EventType";
            this.col_EventType.Visible = true;
            this.col_EventType.VisibleIndex = 5;
            // 
            // col_VariableID
            // 
            this.col_VariableID.Caption = "变量名";
            this.col_VariableID.FieldName = "Variable.Name";
            this.col_VariableID.Name = "col_VariableID";
            this.col_VariableID.Visible = true;
            this.col_VariableID.VisibleIndex = 6;
            // 
            // Form_Alarmrule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 422);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gc_AlarmRule);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Alarmrule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置报警规则";
            this.Load += new System.EventHandler(this.Form_Alarmrule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_EventType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_AlarmLevel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_AlarmType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_IsTransfer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_RecordEvent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_AlarmTimeSpan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LimitValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_AlarmRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_AlarmRule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gc_AlarmRule;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_AlarmRule;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn col_ID;
        private DevExpress.XtraGrid.Columns.GridColumn col_AlarmType;
        private DevExpress.XtraGrid.Columns.GridColumn col_AlarmLevel;
        private DevExpress.XtraGrid.Columns.GridColumn col_LimitValue;
        private DevExpress.XtraGrid.Columns.GridColumn col_AlarmTimeSpan;
        private DevExpress.XtraGrid.Columns.GridColumn col_RecordEvent;
        private DevExpress.XtraGrid.Columns.GridColumn col_EventType;
        private DevExpress.XtraGrid.Columns.GridColumn col_VariableID;
        private DevExpress.XtraEditors.CheckEdit cb_RecordEvent;
        private DevExpress.XtraEditors.SpinEdit txt_AlarmTimeSpan;
        private DevExpress.XtraEditors.SpinEdit txt_LimitValue;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_EventType;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_AlarmLevel;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_AlarmType;
        private DevExpress.XtraEditors.CheckEdit cb_IsTransfer;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}