namespace Sinowyde.DOP.DataModel.Control
{
    partial class Form_IOUnit
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
            this.lbl_Name = new DevExpress.XtraEditors.LabelControl();
            this.txt_Name = new DevExpress.XtraEditors.TextEdit();
            this.lbl_Address = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Protocol = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Channel = new DevExpress.XtraEditors.LabelControl();
            this.cmb_Channel = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.txt_Address = new DevExpress.XtraEditors.SpinEdit();
            this.cmb_Protocol = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Channel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Address.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Protocol.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            this.lbl_Name.Location = new System.Drawing.Point(46, 20);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(36, 14);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "名称：";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(88, 17);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Properties.MaxLength = 50;
            this.txt_Name.Size = new System.Drawing.Size(213, 20);
            this.txt_Name.TabIndex = 1;
            // 
            // lbl_Address
            // 
            this.lbl_Address.Location = new System.Drawing.Point(22, 62);
            this.lbl_Address.Name = "lbl_Address";
            this.lbl_Address.Size = new System.Drawing.Size(60, 14);
            this.lbl_Address.TabIndex = 0;
            this.lbl_Address.Text = "采集地址：";
            // 
            // lbl_Protocol
            // 
            this.lbl_Protocol.Location = new System.Drawing.Point(22, 104);
            this.lbl_Protocol.Name = "lbl_Protocol";
            this.lbl_Protocol.Size = new System.Drawing.Size(60, 14);
            this.lbl_Protocol.TabIndex = 0;
            this.lbl_Protocol.Text = "协议类型：";
            // 
            // lbl_Channel
            // 
            this.lbl_Channel.Location = new System.Drawing.Point(33, 146);
            this.lbl_Channel.Name = "lbl_Channel";
            this.lbl_Channel.Size = new System.Drawing.Size(49, 14);
            this.lbl_Channel.TabIndex = 2;
            this.lbl_Channel.Text = "IO通道：";
            // 
            // cmb_Channel
            // 
            this.cmb_Channel.Location = new System.Drawing.Point(88, 143);
            this.cmb_Channel.Name = "cmb_Channel";
            this.cmb_Channel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_Channel.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_Channel.Size = new System.Drawing.Size(213, 20);
            this.cmb_Channel.TabIndex = 3;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(134, 178);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "新增";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(226, 178);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 5;
            this.btn_Close.Text = "关闭";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // txt_Address
            // 
            this.txt_Address.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_Address.Location = new System.Drawing.Point(88, 59);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_Address.Properties.Mask.EditMask = "n0";
            this.txt_Address.Properties.MaxLength = 5;
            this.txt_Address.Size = new System.Drawing.Size(213, 20);
            this.txt_Address.TabIndex = 6;
            // 
            // cmb_Protocol
            // 
            this.cmb_Protocol.Location = new System.Drawing.Point(88, 101);
            this.cmb_Protocol.Name = "cmb_Protocol";
            this.cmb_Protocol.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_Protocol.Properties.MaxLength = 50;
            this.cmb_Protocol.Size = new System.Drawing.Size(213, 20);
            this.cmb_Protocol.TabIndex = 3;
            // 
            // Form_IOUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 213);
            this.Controls.Add(this.txt_Address);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.cmb_Protocol);
            this.Controls.Add(this.cmb_Channel);
            this.Controls.Add(this.lbl_Channel);
            this.Controls.Add(this.lbl_Protocol);
            this.Controls.Add(this.lbl_Address);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.lbl_Name);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_IOUnit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加IO单元";
            this.Load += new System.EventHandler(this.Form_IOUnit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Channel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Address.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Protocol.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_Name;
        private DevExpress.XtraEditors.TextEdit txt_Name;
        private DevExpress.XtraEditors.LabelControl lbl_Address;
        private DevExpress.XtraEditors.LabelControl lbl_Protocol;
        private DevExpress.XtraEditors.LabelControl lbl_Channel;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_Channel;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
        private DevExpress.XtraEditors.SpinEdit txt_Address;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_Protocol;
    }
}