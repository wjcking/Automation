namespace Sinowyde.DOP.PIDBlock
{
    partial class FrmKeep
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
            this.lookUpEditVar = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditVar.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lookUpEditVar
            // 
            this.lookUpEditVar.Location = new System.Drawing.Point(143, 9);
            this.lookUpEditVar.Name = "lookUpEditVar";
            this.lookUpEditVar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditVar.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "名称")});
            this.lookUpEditVar.Size = new System.Drawing.Size(117, 20);
            this.lookUpEditVar.TabIndex = 17;
            // 
            // labelControl
            // 
            this.labelControl.Location = new System.Drawing.Point(25, 14);
            this.labelControl.Name = "labelControl";
            this.labelControl.Size = new System.Drawing.Size(96, 14);
            this.labelControl.TabIndex = 14;
            this.labelControl.Text = "选择保持输出端：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.simpleButtonOk);
            this.panel2.Controls.Add(this.simpleButtonCancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 34);
            this.panel2.TabIndex = 12;
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
            // FrmKeep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 82);
            this.Controls.Add(this.lookUpEditVar);
            this.Controls.Add(this.labelControl);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 120);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 120);
            this.Name = "FrmKeep";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "保持输出";
            this.Load += new System.EventHandler(this.FrmKeep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditVar.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit lookUpEditVar;
        private DevExpress.XtraEditors.LabelControl labelControl;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
        private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;

    }
}