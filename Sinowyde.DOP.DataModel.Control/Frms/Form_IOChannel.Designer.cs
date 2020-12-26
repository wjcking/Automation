namespace Sinowyde.DOP.DataModel.Control
{
    partial class Form_IOChannel
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
            this.gc_Serial = new DevExpress.XtraEditors.GroupControl();
            this.cmb_stopBits = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_parity = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_dataBits = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_baud = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmb_SerialNo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Name = new DevExpress.XtraEditors.TextEdit();
            this.pc_tcp = new DevExpress.XtraEditors.GroupControl();
            this.txt_Port = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Ip = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmb_CommuType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txt_GatherPeriod = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.cmb_IOServer = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Serial)).BeginInit();
            this.gc_Serial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_stopBits.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_parity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_dataBits.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_baud.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_SerialNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_tcp)).BeginInit();
            this.pc_tcp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Port.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Ip.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_CommuType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_GatherPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IOServer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gc_Serial
            // 
            this.gc_Serial.Controls.Add(this.cmb_stopBits);
            this.gc_Serial.Controls.Add(this.cmb_parity);
            this.gc_Serial.Controls.Add(this.cmb_dataBits);
            this.gc_Serial.Controls.Add(this.cmb_baud);
            this.gc_Serial.Controls.Add(this.cmb_SerialNo);
            this.gc_Serial.Controls.Add(this.labelControl8);
            this.gc_Serial.Controls.Add(this.labelControl7);
            this.gc_Serial.Controls.Add(this.labelControl6);
            this.gc_Serial.Controls.Add(this.labelControl4);
            this.gc_Serial.Controls.Add(this.labelControl1);
            this.gc_Serial.Location = new System.Drawing.Point(3, 149);
            this.gc_Serial.Name = "gc_Serial";
            this.gc_Serial.Size = new System.Drawing.Size(375, 115);
            this.gc_Serial.TabIndex = 20;
            this.gc_Serial.Text = "串口通讯";
            // 
            // cmb_stopBits
            // 
            this.cmb_stopBits.Location = new System.Drawing.Point(258, 57);
            this.cmb_stopBits.Name = "cmb_stopBits";
            this.cmb_stopBits.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_stopBits.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_stopBits.Size = new System.Drawing.Size(100, 20);
            this.cmb_stopBits.TabIndex = 15;
            // 
            // cmb_parity
            // 
            this.cmb_parity.Location = new System.Drawing.Point(68, 87);
            this.cmb_parity.Name = "cmb_parity";
            this.cmb_parity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_parity.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_parity.Size = new System.Drawing.Size(108, 20);
            this.cmb_parity.TabIndex = 14;
            // 
            // cmb_dataBits
            // 
            this.cmb_dataBits.Location = new System.Drawing.Point(68, 57);
            this.cmb_dataBits.Name = "cmb_dataBits";
            this.cmb_dataBits.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_dataBits.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_dataBits.Size = new System.Drawing.Size(108, 20);
            this.cmb_dataBits.TabIndex = 14;
            // 
            // cmb_baud
            // 
            this.cmb_baud.Location = new System.Drawing.Point(258, 27);
            this.cmb_baud.Name = "cmb_baud";
            this.cmb_baud.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_baud.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_baud.Size = new System.Drawing.Size(100, 20);
            this.cmb_baud.TabIndex = 13;
            // 
            // cmb_SerialNo
            // 
            this.cmb_SerialNo.Location = new System.Drawing.Point(68, 27);
            this.cmb_SerialNo.Name = "cmb_SerialNo";
            this.cmb_SerialNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_SerialNo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_SerialNo.Size = new System.Drawing.Size(108, 20);
            this.cmb_SerialNo.TabIndex = 12;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(11, 90);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 14);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "奇偶校验：";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(207, 60);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(48, 14);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "停止位：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(23, 60);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(48, 14);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "数据位：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(207, 30);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "波特率：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "串口号：";
            // 
            // txt_Name
            // 
            this.txt_Name.EditValue = "sinowyde-IO通道";
            this.txt_Name.Location = new System.Drawing.Point(74, 9);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Properties.MaxLength = 50;
            this.txt_Name.Size = new System.Drawing.Size(301, 20);
            this.txt_Name.TabIndex = 16;
            // 
            // pc_tcp
            // 
            this.pc_tcp.Controls.Add(this.txt_Port);
            this.pc_tcp.Controls.Add(this.labelControl3);
            this.pc_tcp.Controls.Add(this.txt_Ip);
            this.pc_tcp.Controls.Add(this.labelControl2);
            this.pc_tcp.Location = new System.Drawing.Point(3, 84);
            this.pc_tcp.Name = "pc_tcp";
            this.pc_tcp.Size = new System.Drawing.Size(375, 59);
            this.pc_tcp.TabIndex = 21;
            this.pc_tcp.Text = "TCP通讯";
            // 
            // txt_Port
            // 
            this.txt_Port.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_Port.Location = new System.Drawing.Point(265, 28);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_Port.Properties.IsFloatValue = false;
            this.txt_Port.Properties.Mask.EditMask = "n0";
            this.txt_Port.Properties.MaxLength = 5;
            this.txt_Port.Size = new System.Drawing.Size(90, 20);
            this.txt_Port.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(226, 31);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "端口：";
            // 
            // txt_Ip
            // 
            this.txt_Ip.EditValue = "255.255.255.255";
            this.txt_Ip.Location = new System.Drawing.Point(71, 28);
            this.txt_Ip.Name = "txt_Ip";
            this.txt_Ip.Properties.MaxLength = 15;
            this.txt_Ip.Size = new System.Drawing.Size(108, 20);
            this.txt_Ip.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 31);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "IP地址：";
            // 
            // cmb_CommuType
            // 
            this.cmb_CommuType.Location = new System.Drawing.Point(74, 35);
            this.cmb_CommuType.Name = "cmb_CommuType";
            this.cmb_CommuType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_CommuType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_CommuType.Size = new System.Drawing.Size(108, 20);
            this.cmb_CommuType.TabIndex = 19;
            this.cmb_CommuType.SelectedIndexChanged += new System.EventHandler(this.cmb_CommuType_SelectedIndexChanged);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(300, 273);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 18;
            this.btn_Close.Text = "关闭";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(208, 273);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 17;
            this.btn_Save.Text = "新增";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 38);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "通讯类型：";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(12, 12);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(60, 14);
            this.labelControl9.TabIndex = 15;
            this.labelControl9.Text = "通道名称：";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(189, 38);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(85, 14);
            this.labelControl10.TabIndex = 15;
            this.labelControl10.Text = "采集周期(ms)：";
            // 
            // txt_GatherPeriod
            // 
            this.txt_GatherPeriod.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_GatherPeriod.Location = new System.Drawing.Point(275, 35);
            this.txt_GatherPeriod.Name = "txt_GatherPeriod";
            this.txt_GatherPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_GatherPeriod.Properties.Mask.EditMask = "d";
            this.txt_GatherPeriod.Size = new System.Drawing.Size(100, 20);
            this.txt_GatherPeriod.TabIndex = 22;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(12, 63);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(60, 14);
            this.labelControl11.TabIndex = 15;
            this.labelControl11.Text = "通道名称：";
            // 
            // cmb_IOServer
            // 
            this.cmb_IOServer.Location = new System.Drawing.Point(74, 60);
            this.cmb_IOServer.Name = "cmb_IOServer";
            this.cmb_IOServer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_IOServer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_IOServer.Size = new System.Drawing.Size(301, 20);
            this.cmb_IOServer.TabIndex = 19;
            this.cmb_IOServer.SelectedIndexChanged += new System.EventHandler(this.cmb_CommuType_SelectedIndexChanged);
            // 
            // Form_IOChannel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 301);
            this.Controls.Add(this.txt_GatherPeriod);
            this.Controls.Add(this.pc_tcp);
            this.Controls.Add(this.gc_Serial);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.cmb_IOServer);
            this.Controls.Add(this.cmb_CommuType);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl9);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_IOChannel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加IO通道";
            this.Load += new System.EventHandler(this.Form_IOChannel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gc_Serial)).EndInit();
            this.gc_Serial.ResumeLayout(false);
            this.gc_Serial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_stopBits.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_parity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_dataBits.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_baud.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_SerialNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pc_tcp)).EndInit();
            this.pc_tcp.ResumeLayout(false);
            this.pc_tcp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Port.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Ip.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_CommuType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_GatherPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_IOServer.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gc_Serial;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_stopBits;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_parity;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_dataBits;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_baud;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_SerialNo;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_Name;
        private DevExpress.XtraEditors.GroupControl pc_tcp;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txt_Ip;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_CommuType;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SpinEdit txt_Port;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.SpinEdit txt_GatherPeriod;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_IOServer;
    }
}