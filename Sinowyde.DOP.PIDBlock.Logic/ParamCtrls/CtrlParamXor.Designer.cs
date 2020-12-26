 
namespace Sinowyde.DOP.PIDBlock.Logic 
{
    partial class CtrlParamXor
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
            this.lbInputDI1 = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbInputDI2 = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbResultDO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbInputDI1
            // 
            this.lbInputDI1.Location = new System.Drawing.Point(15, 50);
            this.lbInputDI1.Name = "lbInputDI1";
            this.lbInputDI1.Size = new System.Drawing.Size(23, 14);
            this.lbInputDI1.TabIndex = 0;
            this.lbInputDI1.Text = "DI1:";
            // 
            // drpInputDI1
            // 
            this.drpInputDI1.EditValue = "1";
            this.drpInputDI1.Location = new System.Drawing.Point(59, 47);
            this.drpInputDI1.Name = "drpInputDI1";
            this.drpInputDI1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI1.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI1.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI1.TabIndex = 0;
            // 
            // lbInputDI2
            // 
            this.lbInputDI2.Location = new System.Drawing.Point(179, 50);
            this.lbInputDI2.Name = "lbInputDI2";
            this.lbInputDI2.Size = new System.Drawing.Size(23, 14);
            this.lbInputDI2.TabIndex = 0;
            this.lbInputDI2.Text = "DI2:";
            // 
            // drpInputDI2
            // 
            this.drpInputDI2.EditValue = "1";
            this.drpInputDI2.Location = new System.Drawing.Point(232, 47);
            this.drpInputDI2.Name = "drpInputDI2";
            this.drpInputDI2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI2.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI2.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI2.TabIndex = 1;
            // 
            // lbResultDO
            // 
            this.lbResultDO.Location = new System.Drawing.Point(15, 74);
            this.lbResultDO.Name = "lbResultDO";
            this.lbResultDO.Size = new System.Drawing.Size(89, 14);
            this.lbResultDO.TabIndex = 0;
            this.lbResultDO.Text = "DO：数字量输出";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.labelControl1);
            this.groupPid.Controls.Add(this.lbInputDI1);
            this.groupPid.Controls.Add(this.drpInputDI1);
            this.groupPid.Controls.Add(this.lbInputDI2);
            this.groupPid.Controls.Add(this.drpInputDI2);
            this.groupPid.Controls.Add(this.lbResultDO);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 96);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "数字量输入";
            // 
            // CtrlParamXor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamXor";
            this.Size = new System.Drawing.Size(364, 100);
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbInputDI1;
private DevExpress.XtraEditors.ComboBoxEdit drpInputDI1;
private DevExpress.XtraEditors.LabelControl lbInputDI2;
private DevExpress.XtraEditors.ComboBoxEdit drpInputDI2;
private DevExpress.XtraEditors.LabelControl lbResultDO;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}