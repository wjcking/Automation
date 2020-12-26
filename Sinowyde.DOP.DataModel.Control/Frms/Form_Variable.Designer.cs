namespace Sinowyde.DOP.DataModel.Control
{
    partial class Form_Variable
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
            this.lbl_Number = new DevExpress.XtraEditors.LabelControl();
            this.txt_Number = new DevExpress.XtraEditors.TextEdit();
            this.lbl_PointNumber = new DevExpress.XtraEditors.LabelControl();
            this.txt_Ratio = new DevExpress.XtraEditors.SpinEdit();
            this.lbl_Ratio = new DevExpress.XtraEditors.LabelControl();
            this.txt_Unit = new DevExpress.XtraEditors.TextEdit();
            this.lbl_Unit = new DevExpress.XtraEditors.LabelControl();
            this.lbl_IsCompressed = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Bias = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_VariableType = new DevExpress.XtraEditors.LabelControl();
            this.lbl_DirectionType = new DevExpress.XtraEditors.LabelControl();
            this.lbl_MaxPeriod = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_CompressRatio = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Channel = new DevExpress.XtraEditors.LabelControl();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.txt_Bias = new DevExpress.XtraEditors.SpinEdit();
            this.cmb_IsCompressed = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txt_CompressRatio = new DevExpress.XtraEditors.SpinEdit();
            this.cmb_IsTransfer = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txt_MaxPeriod = new DevExpress.XtraEditors.SpinEdit();
            this.cmb_device = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_IOUnit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txt_Name = new DevExpress.XtraEditors.TextEdit();
            this.cmb_VariableType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_VarDirectionType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmb_DataType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Address = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Number.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Ratio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Unit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Bias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IsCompressed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CompressRatio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IsTransfer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MaxPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_device.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IOUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_VariableType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_VarDirectionType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_DataType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Address.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Number
            // 
            this.lbl_Number.Location = new System.Drawing.Point(233, 13);
            this.lbl_Number.Name = "lbl_Number";
            this.lbl_Number.Size = new System.Drawing.Size(71, 14);
            this.lbl_Number.TabIndex = 9;
            this.lbl_Number.Text = " 中文名称*：";
            // 
            // txt_Number
            // 
            this.txt_Number.EditValue = "";
            this.txt_Number.Location = new System.Drawing.Point(117, 10);
            this.txt_Number.Name = "txt_Number";
            this.txt_Number.Properties.MaxLength = 50;
            this.txt_Number.Size = new System.Drawing.Size(108, 20);
            this.txt_Number.TabIndex = 0;
            // 
            // lbl_PointNumber
            // 
            this.lbl_PointNumber.Location = new System.Drawing.Point(11, 258);
            this.lbl_PointNumber.Name = "lbl_PointNumber";
            this.lbl_PointNumber.Size = new System.Drawing.Size(67, 14);
            this.lbl_PointNumber.TabIndex = 7;
            this.lbl_PointNumber.Text = "变量地址*：";
            // 
            // txt_Ratio
            // 
            this.txt_Ratio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_Ratio.Location = new System.Drawing.Point(300, 45);
            this.txt_Ratio.Name = "txt_Ratio";
            this.txt_Ratio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_Ratio.Properties.Mask.EditMask = "n2";
            this.txt_Ratio.Properties.MaxLength = 5;
            this.txt_Ratio.Size = new System.Drawing.Size(108, 20);
            this.txt_Ratio.TabIndex = 4;
            // 
            // lbl_Ratio
            // 
            this.lbl_Ratio.Location = new System.Drawing.Point(233, 48);
            this.lbl_Ratio.Name = "lbl_Ratio";
            this.lbl_Ratio.Size = new System.Drawing.Size(60, 14);
            this.lbl_Ratio.TabIndex = 13;
            this.lbl_Ratio.Text = "比例系数：";
            // 
            // txt_Unit
            // 
            this.txt_Unit.EditValue = "";
            this.txt_Unit.Location = new System.Drawing.Point(117, 45);
            this.txt_Unit.Name = "txt_Unit";
            this.txt_Unit.Properties.MaxLength = 50;
            this.txt_Unit.Size = new System.Drawing.Size(108, 20);
            this.txt_Unit.TabIndex = 3;
            // 
            // lbl_Unit
            // 
            this.lbl_Unit.Location = new System.Drawing.Point(11, 48);
            this.lbl_Unit.Name = "lbl_Unit";
            this.lbl_Unit.Size = new System.Drawing.Size(36, 14);
            this.lbl_Unit.TabIndex = 11;
            this.lbl_Unit.Text = "单位：";
            // 
            // lbl_IsCompressed
            // 
            this.lbl_IsCompressed.Location = new System.Drawing.Point(233, 83);
            this.lbl_IsCompressed.Name = "lbl_IsCompressed";
            this.lbl_IsCompressed.Size = new System.Drawing.Size(60, 14);
            this.lbl_IsCompressed.TabIndex = 17;
            this.lbl_IsCompressed.Text = "是否压缩：";
            // 
            // lbl_Bias
            // 
            this.lbl_Bias.Location = new System.Drawing.Point(11, 83);
            this.lbl_Bias.Name = "lbl_Bias";
            this.lbl_Bias.Size = new System.Drawing.Size(36, 14);
            this.lbl_Bias.TabIndex = 15;
            this.lbl_Bias.Text = "偏移：";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(233, 188);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 14);
            this.labelControl7.TabIndex = 29;
            this.labelControl7.Text = "所属设备：";
            // 
            // lbl_VariableType
            // 
            this.lbl_VariableType.Location = new System.Drawing.Point(11, 188);
            this.lbl_VariableType.Name = "lbl_VariableType";
            this.lbl_VariableType.Size = new System.Drawing.Size(60, 14);
            this.lbl_VariableType.TabIndex = 27;
            this.lbl_VariableType.Text = "变量类型：";
            // 
            // lbl_DirectionType
            // 
            this.lbl_DirectionType.Location = new System.Drawing.Point(233, 153);
            this.lbl_DirectionType.Name = "lbl_DirectionType";
            this.lbl_DirectionType.Size = new System.Drawing.Size(60, 14);
            this.lbl_DirectionType.TabIndex = 25;
            this.lbl_DirectionType.Text = "采集类型：";
            // 
            // lbl_MaxPeriod
            // 
            this.lbl_MaxPeriod.Location = new System.Drawing.Point(11, 153);
            this.lbl_MaxPeriod.Name = "lbl_MaxPeriod";
            this.lbl_MaxPeriod.Size = new System.Drawing.Size(109, 14);
            this.lbl_MaxPeriod.TabIndex = 23;
            this.lbl_MaxPeriod.Text = "最大存储周期(ms)：";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(233, 118);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(60, 14);
            this.labelControl11.TabIndex = 21;
            this.labelControl11.Text = "是否上传：";
            // 
            // lbl_CompressRatio
            // 
            this.lbl_CompressRatio.Location = new System.Drawing.Point(11, 118);
            this.lbl_CompressRatio.Name = "lbl_CompressRatio";
            this.lbl_CompressRatio.Size = new System.Drawing.Size(70, 14);
            this.lbl_CompressRatio.TabIndex = 19;
            this.lbl_CompressRatio.Text = "压缩率(%)：";
            // 
            // lbl_Channel
            // 
            this.lbl_Channel.Location = new System.Drawing.Point(233, 223);
            this.lbl_Channel.Name = "lbl_Channel";
            this.lbl_Channel.Size = new System.Drawing.Size(60, 14);
            this.lbl_Channel.TabIndex = 31;
            this.lbl_Channel.Text = "所在单元：";
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(333, 281);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 17;
            this.btn_Close.Text = "关闭";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(241, 281);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 16;
            this.btn_Save.Text = "确定";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_Bias
            // 
            this.txt_Bias.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_Bias.Location = new System.Drawing.Point(117, 80);
            this.txt_Bias.Name = "txt_Bias";
            this.txt_Bias.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_Bias.Properties.Mask.EditMask = "n0";
            this.txt_Bias.Properties.MaxLength = 5;
            this.txt_Bias.Size = new System.Drawing.Size(108, 20);
            this.txt_Bias.TabIndex = 5;
            // 
            // cmb_IsCompressed
            // 
            this.cmb_IsCompressed.EditValue = "否";
            this.cmb_IsCompressed.Location = new System.Drawing.Point(300, 80);
            this.cmb_IsCompressed.Name = "cmb_IsCompressed";
            this.cmb_IsCompressed.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_IsCompressed.Properties.Items.AddRange(new object[] {
            "否",
            "是"});
            this.cmb_IsCompressed.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_IsCompressed.Size = new System.Drawing.Size(108, 20);
            this.cmb_IsCompressed.TabIndex = 6;
            // 
            // txt_CompressRatio
            // 
            this.txt_CompressRatio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_CompressRatio.Location = new System.Drawing.Point(117, 115);
            this.txt_CompressRatio.Name = "txt_CompressRatio";
            this.txt_CompressRatio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_CompressRatio.Properties.MaxLength = 6;
            this.txt_CompressRatio.Size = new System.Drawing.Size(108, 20);
            this.txt_CompressRatio.TabIndex = 7;
            // 
            // cmb_IsTransfer
            // 
            this.cmb_IsTransfer.EditValue = "否";
            this.cmb_IsTransfer.Location = new System.Drawing.Point(300, 115);
            this.cmb_IsTransfer.Name = "cmb_IsTransfer";
            this.cmb_IsTransfer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_IsTransfer.Properties.Items.AddRange(new object[] {
            "否",
            "是"});
            this.cmb_IsTransfer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_IsTransfer.Size = new System.Drawing.Size(108, 20);
            this.cmb_IsTransfer.TabIndex = 8;
            // 
            // txt_MaxPeriod
            // 
            this.txt_MaxPeriod.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_MaxPeriod.Location = new System.Drawing.Point(117, 150);
            this.txt_MaxPeriod.Name = "txt_MaxPeriod";
            this.txt_MaxPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_MaxPeriod.Properties.Mask.EditMask = "n0";
            this.txt_MaxPeriod.Properties.MaxLength = 10;
            this.txt_MaxPeriod.Size = new System.Drawing.Size(108, 20);
            this.txt_MaxPeriod.TabIndex = 9;
            // 
            // cmb_device
            // 
            this.cmb_device.Location = new System.Drawing.Point(300, 185);
            this.cmb_device.Name = "cmb_device";
            this.cmb_device.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_device.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_device.Size = new System.Drawing.Size(108, 20);
            this.cmb_device.TabIndex = 12;
            // 
            // cmb_IOUnit
            // 
            this.cmb_IOUnit.Location = new System.Drawing.Point(300, 220);
            this.cmb_IOUnit.Name = "cmb_IOUnit";
            this.cmb_IOUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_IOUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_IOUnit.Size = new System.Drawing.Size(107, 20);
            this.cmb_IOUnit.TabIndex = 14;
            // 
            // txt_Name
            // 
            this.txt_Name.EditValue = "";
            this.txt_Name.Location = new System.Drawing.Point(300, 10);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Properties.MaxLength = 50;
            this.txt_Name.Size = new System.Drawing.Size(108, 20);
            this.txt_Name.TabIndex = 2;
            // 
            // cmb_VariableType
            // 
            this.cmb_VariableType.Location = new System.Drawing.Point(117, 185);
            this.cmb_VariableType.Name = "cmb_VariableType";
            this.cmb_VariableType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_VariableType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_VariableType.Size = new System.Drawing.Size(108, 20);
            this.cmb_VariableType.TabIndex = 11;
            // 
            // cmb_VarDirectionType
            // 
            this.cmb_VarDirectionType.Enabled = false;
            this.cmb_VarDirectionType.Location = new System.Drawing.Point(300, 150);
            this.cmb_VarDirectionType.Name = "cmb_VarDirectionType";
            this.cmb_VarDirectionType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_VarDirectionType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_VarDirectionType.Size = new System.Drawing.Size(108, 20);
            this.cmb_VarDirectionType.TabIndex = 10;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 223);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 27;
            this.labelControl1.Text = "数据类型：";
            // 
            // cmb_DataType
            // 
            this.cmb_DataType.Location = new System.Drawing.Point(117, 220);
            this.cmb_DataType.Name = "cmb_DataType";
            this.cmb_DataType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_DataType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_DataType.Size = new System.Drawing.Size(108, 20);
            this.cmb_DataType.TabIndex = 13;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 14);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "点名*：";
            // 
            // txt_Address
            // 
            this.txt_Address.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_Address.Location = new System.Drawing.Point(117, 255);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_Address.Properties.Mask.EditMask = "f0";
            this.txt_Address.Properties.MaxLength = 10;
            this.txt_Address.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.txt_Address.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_Address.Size = new System.Drawing.Size(291, 20);
            this.txt_Address.TabIndex = 15;
            // 
            // Form_Variable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 310);
            this.Controls.Add(this.txt_Address);
            this.Controls.Add(this.cmb_DataType);
            this.Controls.Add(this.cmb_VariableType);
            this.Controls.Add(this.cmb_IOUnit);
            this.Controls.Add(this.cmb_VarDirectionType);
            this.Controls.Add(this.cmb_device);
            this.Controls.Add(this.cmb_IsTransfer);
            this.Controls.Add(this.cmb_IsCompressed);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.lbl_Channel);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.lbl_VariableType);
            this.Controls.Add(this.lbl_DirectionType);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.lbl_CompressRatio);
            this.Controls.Add(this.txt_MaxPeriod);
            this.Controls.Add(this.lbl_IsCompressed);
            this.Controls.Add(this.txt_CompressRatio);
            this.Controls.Add(this.lbl_Bias);
            this.Controls.Add(this.txt_Bias);
            this.Controls.Add(this.txt_Ratio);
            this.Controls.Add(this.lbl_Ratio);
            this.Controls.Add(this.txt_Unit);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lbl_Unit);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.lbl_Number);
            this.Controls.Add(this.txt_Number);
            this.Controls.Add(this.lbl_PointNumber);
            this.Controls.Add(this.lbl_MaxPeriod);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Variable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加变量";
            this.Load += new System.EventHandler(this.Form_Variable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Number.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Ratio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Unit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Bias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IsCompressed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CompressRatio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IsTransfer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MaxPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_device.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IOUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_VariableType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_VarDirectionType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_DataType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Address.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_Number;
        private DevExpress.XtraEditors.TextEdit txt_Number;
        private DevExpress.XtraEditors.LabelControl lbl_PointNumber;
        private DevExpress.XtraEditors.SpinEdit txt_Ratio;
        private DevExpress.XtraEditors.LabelControl lbl_Ratio;
        private DevExpress.XtraEditors.TextEdit txt_Unit;
        private DevExpress.XtraEditors.LabelControl lbl_Unit;
        private DevExpress.XtraEditors.LabelControl lbl_IsCompressed;
        private DevExpress.XtraEditors.LabelControl lbl_Bias;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl lbl_VariableType;
        private DevExpress.XtraEditors.LabelControl lbl_DirectionType;
        private DevExpress.XtraEditors.LabelControl lbl_MaxPeriod;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl lbl_CompressRatio;
        private DevExpress.XtraEditors.LabelControl lbl_Channel;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SpinEdit txt_Bias;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_IsCompressed;
        private DevExpress.XtraEditors.SpinEdit txt_CompressRatio;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_IsTransfer;
        private DevExpress.XtraEditors.SpinEdit txt_MaxPeriod;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_device;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_IOUnit;
        private DevExpress.XtraEditors.TextEdit txt_Name;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_VariableType;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_VarDirectionType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_DataType;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit txt_Address;
    }
}