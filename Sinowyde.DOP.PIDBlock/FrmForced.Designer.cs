namespace Sinowyde.DOP.PIDBlock
{
    partial class FrmForced
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl = new DevExpress.XtraEditors.LabelControl();
            this.labelControlSet = new DevExpress.XtraEditors.LabelControl();
            this.spinEditValue = new DevExpress.XtraEditors.SpinEdit();
            this.comboBoxEditValue = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lookUpEditVar = new DevExpress.XtraEditors.LookUpEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEditValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditVar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.simpleButtonOk);
            this.panel1.Controls.Add(this.simpleButtonCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 34);
            this.panel1.TabIndex = 7;
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.simpleButtonOk.Location = new System.Drawing.Point(58, 4);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonOk.TabIndex = 0;
            this.simpleButtonOk.Tag = "";
            this.simpleButtonOk.Text = "确定";
            this.simpleButtonOk.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // simpleButtonCancel
            // 
            this.simpleButtonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.simpleButtonCancel.Location = new System.Drawing.Point(152, 4);
            this.simpleButtonCancel.Name = "simpleButtonCancel";
            this.simpleButtonCancel.Size = new System.Drawing.Size(87, 27);
            this.simpleButtonCancel.TabIndex = 3;
            this.simpleButtonCancel.Text = "关闭";
            this.simpleButtonCancel.Click += new System.EventHandler(this.simpleButtonCancel_Click);
            // 
            // labelControl
            // 
            this.labelControl.Location = new System.Drawing.Point(26, 20);
            this.labelControl.Name = "labelControl";
            this.labelControl.Size = new System.Drawing.Size(96, 14);
            this.labelControl.TabIndex = 8;
            this.labelControl.Text = "选择强制输出端：";
            // 
            // labelControlSet
            // 
            this.labelControlSet.Location = new System.Drawing.Point(25, 55);
            this.labelControlSet.Name = "labelControlSet";
            this.labelControlSet.Size = new System.Drawing.Size(108, 14);
            this.labelControlSet.TabIndex = 8;
            this.labelControlSet.Text = "设置强制输出端值：";
            // 
            // spinEditValue
            // 
            this.spinEditValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEditValue.Location = new System.Drawing.Point(143, 52);
            this.spinEditValue.Name = "spinEditValue";
            this.spinEditValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEditValue.Size = new System.Drawing.Size(117, 20);
            this.spinEditValue.TabIndex = 10;
            // 
            // comboBoxEditValue
            // 
            this.comboBoxEditValue.Location = new System.Drawing.Point(143, 52);
            this.comboBoxEditValue.Name = "comboBoxEditValue";
            this.comboBoxEditValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditValue.Size = new System.Drawing.Size(117, 20);
            this.comboBoxEditValue.TabIndex = 9;
            // 
            // lookUpEditVar
            // 
            this.lookUpEditVar.Location = new System.Drawing.Point(143, 17);
            this.lookUpEditVar.Name = "lookUpEditVar";
            this.lookUpEditVar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditVar.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "名称")});
            this.lookUpEditVar.Size = new System.Drawing.Size(117, 20);
            this.lookUpEditVar.TabIndex = 18;
            // 
            // FrmForced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 122);
            this.Controls.Add(this.lookUpEditVar);
            this.Controls.Add(this.spinEditValue);
            this.Controls.Add(this.comboBoxEditValue);
            this.Controls.Add(this.labelControlSet);
            this.Controls.Add(this.labelControl);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 160);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 100);
            this.Name = "FrmForced";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "强制输出";
            this.Load += new System.EventHandler(this.FrmForced_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEditValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditVar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
        private DevExpress.XtraEditors.LabelControl labelControl;
        private DevExpress.XtraEditors.LabelControl labelControlSet;
        private DevExpress.XtraEditors.SpinEdit spinEditValue;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditValue;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditVar;
    }
}