namespace Sinowyde.DOP.DataModel.Control
{
    partial class Form_Device
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Name = new DevExpress.XtraEditors.TextEdit();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.gc_Device = new DevExpress.XtraGrid.GridControl();
            this.gv_Device = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.alertControtMessage = new DevExpress.XtraBars.Alerter.AlertControl();
            this.btn_Clear = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Device)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Device)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 338);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "设备名称:";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(66, 335);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Properties.MaxLength = 50;
            this.txt_Name.Size = new System.Drawing.Size(206, 20);
            this.txt_Name.TabIndex = 1;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(278, 334);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 19;
            this.btn_Save.Text = "新增";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // gc_Device
            // 
            this.gc_Device.Location = new System.Drawing.Point(2, 2);
            this.gc_Device.MainView = this.gv_Device;
            this.gc_Device.Name = "gc_Device";
            this.gc_Device.Size = new System.Drawing.Size(434, 319);
            this.gc_Device.TabIndex = 20;
            this.gc_Device.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Device});
            // 
            // gv_Device
            // 
            this.gv_Device.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_ID,
            this.col_Name});
            this.gv_Device.GridControl = this.gc_Device;
            this.gv_Device.Name = "gv_Device";
            this.gv_Device.OptionsBehavior.ReadOnly = true;
            this.gv_Device.OptionsView.ShowGroupPanel = false;
            this.gv_Device.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gv_CalcVariabel_PopupMenuShowing);
            this.gv_Device.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.gv_CustomDrawEmptyForeground);
            this.gv_Device.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gc_MouseDown);
            // 
            // col_ID
            // 
            this.col_ID.Caption = "编号";
            this.col_ID.FieldName = "ID";
            this.col_ID.MaxWidth = 60;
            this.col_ID.MinWidth = 60;
            this.col_ID.Name = "col_ID";
            this.col_ID.OptionsColumn.AllowEdit = false;
            this.col_ID.OptionsColumn.AllowFocus = false;
            this.col_ID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.col_ID.OptionsColumn.AllowIncrementalSearch = false;
            this.col_ID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.col_ID.OptionsColumn.AllowMove = false;
            this.col_ID.OptionsColumn.AllowSize = false;
            this.col_ID.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.col_ID.OptionsColumn.ReadOnly = true;
            this.col_ID.OptionsColumn.TabStop = false;
            this.col_ID.Visible = true;
            this.col_ID.VisibleIndex = 0;
            this.col_ID.Width = 60;
            // 
            // col_Name
            // 
            this.col_Name.Caption = "设备名称";
            this.col_Name.FieldName = "Name";
            this.col_Name.Name = "col_Name";
            this.col_Name.OptionsColumn.AllowEdit = false;
            this.col_Name.OptionsColumn.AllowFocus = false;
            this.col_Name.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.col_Name.OptionsColumn.AllowIncrementalSearch = false;
            this.col_Name.OptionsColumn.AllowMove = false;
            this.col_Name.Visible = true;
            this.col_Name.VisibleIndex = 1;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(359, 334);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 23);
            this.btn_Clear.TabIndex = 19;
            this.btn_Clear.Text = "清空";
            this.btn_Clear.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // Form_Device
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 369);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gc_Device);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Device";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设备管理";
            this.Load += new System.EventHandler(this.Form_Device_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Device)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Device)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_Name;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraGrid.GridControl gc_Device;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Device;
        private DevExpress.XtraGrid.Columns.GridColumn col_ID;
        private DevExpress.XtraGrid.Columns.GridColumn col_Name;
        private DevExpress.XtraBars.Alerter.AlertControl alertControtMessage;
        private DevExpress.XtraEditors.SimpleButton btn_Clear;
    }
}