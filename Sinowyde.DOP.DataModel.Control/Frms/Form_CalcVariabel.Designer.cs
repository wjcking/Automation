namespace Sinowyde.DOP.DataModel.Control
{
    partial class Form_CalcVariabel
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
            this.cmb_DataType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_VariableType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_device = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_IsTransfer = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_IsCompressed = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_VariableType = new DevExpress.XtraEditors.LabelControl();
            this.lbl_MaxPeriod = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_CompressRatio = new DevExpress.XtraEditors.LabelControl();
            this.txt_MaxPeriod = new DevExpress.XtraEditors.SpinEdit();
            this.lbl_IsCompressed = new DevExpress.XtraEditors.LabelControl();
            this.txt_CompressRatio = new DevExpress.XtraEditors.SpinEdit();
            this.txt_Unit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Unit = new DevExpress.XtraEditors.LabelControl();
            this.txt_Name = new DevExpress.XtraEditors.TextEdit();
            this.txt_Number = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_DataType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_VariableType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_device.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IsTransfer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IsCompressed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MaxPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CompressRatio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Unit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Number.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_DataType
            // 
            this.cmb_DataType.Location = new System.Drawing.Point(281, 117);
            this.cmb_DataType.Name = "cmb_DataType";
            this.cmb_DataType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_DataType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_DataType.Size = new System.Drawing.Size(108, 20);
            this.cmb_DataType.TabIndex = 69;
            // 
            // cmb_VariableType
            // 
            this.cmb_VariableType.Location = new System.Drawing.Point(86, 154);
            this.cmb_VariableType.Name = "cmb_VariableType";
            this.cmb_VariableType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_VariableType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_VariableType.Size = new System.Drawing.Size(108, 20);
            this.cmb_VariableType.TabIndex = 68;
            // 
            // cmb_device
            // 
            this.cmb_device.Location = new System.Drawing.Point(86, 80);
            this.cmb_device.Name = "cmb_device";
            this.cmb_device.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_device.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_device.Size = new System.Drawing.Size(108, 20);
            this.cmb_device.TabIndex = 65;
            // 
            // cmb_IsTransfer
            // 
            this.cmb_IsTransfer.EditValue = "否";
            this.cmb_IsTransfer.Location = new System.Drawing.Point(281, 43);
            this.cmb_IsTransfer.Name = "cmb_IsTransfer";
            this.cmb_IsTransfer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_IsTransfer.Properties.Items.AddRange(new object[] {
            "否",
            "是"});
            this.cmb_IsTransfer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_IsTransfer.Size = new System.Drawing.Size(108, 20);
            this.cmb_IsTransfer.TabIndex = 64;
            // 
            // cmb_IsCompressed
            // 
            this.cmb_IsCompressed.EditValue = "否";
            this.cmb_IsCompressed.Location = new System.Drawing.Point(281, 80);
            this.cmb_IsCompressed.Name = "cmb_IsCompressed";
            this.cmb_IsCompressed.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_IsCompressed.Properties.Items.AddRange(new object[] {
            "否",
            "是"});
            this.cmb_IsCompressed.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_IsCompressed.Size = new System.Drawing.Size(108, 20);
            this.cmb_IsCompressed.TabIndex = 63;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(314, 180);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 62;
            this.btn_Close.Text = "关闭";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(222, 180);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 61;
            this.btn_Save.Text = "新增";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(211, 120);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 58;
            this.labelControl1.Text = "数据类型：";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(15, 83);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 14);
            this.labelControl7.TabIndex = 59;
            this.labelControl7.Text = "所属设备：";
            // 
            // lbl_VariableType
            // 
            this.lbl_VariableType.Location = new System.Drawing.Point(15, 157);
            this.lbl_VariableType.Name = "lbl_VariableType";
            this.lbl_VariableType.Size = new System.Drawing.Size(60, 14);
            this.lbl_VariableType.TabIndex = 57;
            this.lbl_VariableType.Text = "变量类型：";
            // 
            // lbl_MaxPeriod
            // 
            this.lbl_MaxPeriod.Location = new System.Drawing.Point(211, 157);
            this.lbl_MaxPeriod.Name = "lbl_MaxPeriod";
            this.lbl_MaxPeriod.Size = new System.Drawing.Size(116, 14);
            this.lbl_MaxPeriod.TabIndex = 55;
            this.lbl_MaxPeriod.Text = "最大存储周期(ms)*：";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(211, 46);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(60, 14);
            this.labelControl11.TabIndex = 54;
            this.labelControl11.Text = "是否上传：";
            // 
            // lbl_CompressRatio
            // 
            this.lbl_CompressRatio.Location = new System.Drawing.Point(15, 120);
            this.lbl_CompressRatio.Name = "lbl_CompressRatio";
            this.lbl_CompressRatio.Size = new System.Drawing.Size(70, 14);
            this.lbl_CompressRatio.TabIndex = 53;
            this.lbl_CompressRatio.Text = "压缩率(%)：";
            // 
            // txt_MaxPeriod
            // 
            this.txt_MaxPeriod.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_MaxPeriod.Location = new System.Drawing.Point(330, 154);
            this.txt_MaxPeriod.Name = "txt_MaxPeriod";
            this.txt_MaxPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_MaxPeriod.Properties.Mask.EditMask = "n0";
            this.txt_MaxPeriod.Properties.MaxLength = 10;
            this.txt_MaxPeriod.Size = new System.Drawing.Size(59, 20);
            this.txt_MaxPeriod.TabIndex = 50;
            // 
            // lbl_IsCompressed
            // 
            this.lbl_IsCompressed.Location = new System.Drawing.Point(211, 83);
            this.lbl_IsCompressed.Name = "lbl_IsCompressed";
            this.lbl_IsCompressed.Size = new System.Drawing.Size(60, 14);
            this.lbl_IsCompressed.TabIndex = 52;
            this.lbl_IsCompressed.Text = "是否压缩：";
            // 
            // txt_CompressRatio
            // 
            this.txt_CompressRatio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_CompressRatio.Location = new System.Drawing.Point(86, 117);
            this.txt_CompressRatio.Name = "txt_CompressRatio";
            this.txt_CompressRatio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_CompressRatio.Properties.MaxLength = 6;
            this.txt_CompressRatio.Size = new System.Drawing.Size(108, 20);
            this.txt_CompressRatio.TabIndex = 49;
            // 
            // txt_Unit
            // 
            this.txt_Unit.EditValue = "";
            this.txt_Unit.Location = new System.Drawing.Point(86, 43);
            this.txt_Unit.Name = "txt_Unit";
            this.txt_Unit.Properties.MaxLength = 50;
            this.txt_Unit.Size = new System.Drawing.Size(108, 20);
            this.txt_Unit.TabIndex = 45;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 14);
            this.labelControl2.TabIndex = 44;
            this.labelControl2.Text = "点名*：";
            // 
            // lbl_Unit
            // 
            this.lbl_Unit.Location = new System.Drawing.Point(15, 46);
            this.lbl_Unit.Name = "lbl_Unit";
            this.lbl_Unit.Size = new System.Drawing.Size(36, 14);
            this.lbl_Unit.TabIndex = 43;
            this.lbl_Unit.Text = "单位：";
            // 
            // txt_Name
            // 
            this.txt_Name.EditValue = "";
            this.txt_Name.Location = new System.Drawing.Point(281, 6);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Properties.MaxLength = 50;
            this.txt_Name.Size = new System.Drawing.Size(108, 20);
            this.txt_Name.TabIndex = 40;
            // 
            // txt_Number
            // 
            this.txt_Number.EditValue = "";
            this.txt_Number.Location = new System.Drawing.Point(86, 6);
            this.txt_Number.Name = "txt_Number";
            this.txt_Number.Properties.MaxLength = 50;
            this.txt_Number.Size = new System.Drawing.Size(108, 20);
            this.txt_Number.TabIndex = 41;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(211, 9);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(67, 14);
            this.labelControl3.TabIndex = 44;
            this.labelControl3.Text = "中文名称*：";
            // 
            // Form_CalcVariabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 212);
            this.Controls.Add(this.cmb_DataType);
            this.Controls.Add(this.cmb_VariableType);
            this.Controls.Add(this.cmb_device);
            this.Controls.Add(this.cmb_IsTransfer);
            this.Controls.Add(this.cmb_IsCompressed);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_MaxPeriod);
            this.Controls.Add(this.txt_CompressRatio);
            this.Controls.Add(this.txt_Unit);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.txt_Number);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.lbl_VariableType);
            this.Controls.Add(this.lbl_MaxPeriod);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.lbl_CompressRatio);
            this.Controls.Add(this.lbl_IsCompressed);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lbl_Unit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_CalcVariabel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "计算变量";
            this.Load += new System.EventHandler(this.Form_CalcVariabel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmb_DataType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_VariableType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_device.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IsTransfer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IsCompressed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MaxPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CompressRatio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Unit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Number.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cmb_DataType;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_VariableType;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_device;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_IsTransfer;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_IsCompressed;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl lbl_VariableType;
        private DevExpress.XtraEditors.LabelControl lbl_MaxPeriod;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl lbl_CompressRatio;
        private DevExpress.XtraEditors.SpinEdit txt_MaxPeriod;
        private DevExpress.XtraEditors.LabelControl lbl_IsCompressed;
        private DevExpress.XtraEditors.SpinEdit txt_CompressRatio;
        private DevExpress.XtraEditors.TextEdit txt_Unit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lbl_Unit;
        private DevExpress.XtraEditors.TextEdit txt_Name;
        private DevExpress.XtraEditors.TextEdit txt_Number;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}