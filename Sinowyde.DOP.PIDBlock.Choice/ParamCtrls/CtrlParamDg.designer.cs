 
namespace Sinowyde.DOP.PIDBlock.Choice 
{
    partial class CtrlParamDg
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
            this.lbInputDI3 = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI3 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbResultDO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbInputDI1
            // 
            this.lbInputDI1.Location = new System.Drawing.Point(15, 37);
            this.lbInputDI1.Name = "lbInputDI1";
            this.lbInputDI1.Size = new System.Drawing.Size(31, 14);
            this.lbInputDI1.TabIndex = 0;
            this.lbInputDI1.Text = "DI1：";
            // 
            // drpInputDI1
            // 
            this.drpInputDI1.EditValue = "1";
            this.drpInputDI1.Location = new System.Drawing.Point(104, 37);
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
            this.lbInputDI2.Location = new System.Drawing.Point(191, 40);
            this.lbInputDI2.Name = "lbInputDI2";
            this.lbInputDI2.Size = new System.Drawing.Size(31, 14);
            this.lbInputDI2.TabIndex = 0;
            this.lbInputDI2.Text = "DI2：";
            // 
            // drpInputDI2
            // 
            this.drpInputDI2.EditValue = "1";
            this.drpInputDI2.Location = new System.Drawing.Point(290, 37);
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
            // lbInputDI3
            // 
            this.lbInputDI3.Location = new System.Drawing.Point(15, 69);
            this.lbInputDI3.Name = "lbInputDI3";
            this.lbInputDI3.Size = new System.Drawing.Size(31, 14);
            this.lbInputDI3.TabIndex = 0;
            this.lbInputDI3.Text = "DI3：";
            // 
            // drpInputDI3
            // 
            this.drpInputDI3.Location = new System.Drawing.Point(104, 66);
            this.drpInputDI3.Name = "drpInputDI3";
            this.drpInputDI3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI3.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI3.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI3.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI3.TabIndex = 2;
            // 
            // lbResultDO
            // 
            this.lbResultDO.Location = new System.Drawing.Point(191, 69);
            this.lbResultDO.Name = "lbResultDO";
            this.lbResultDO.Size = new System.Drawing.Size(93, 14);
            this.lbResultDO.TabIndex = 0;
            this.lbResultDO.Text = "DO:数字量输出值";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputDI1);
            this.groupPid.Controls.Add(this.drpInputDI1);
            this.groupPid.Controls.Add(this.lbInputDI2);
            this.groupPid.Controls.Add(this.drpInputDI2);
            this.groupPid.Controls.Add(this.lbInputDI3);
            this.groupPid.Controls.Add(this.drpInputDI3);
            this.groupPid.Controls.Add(this.lbResultDO);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 101);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // CtrlParamDg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamDg";
            this.Size = new System.Drawing.Size(364, 107);
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI3.Properties)).EndInit();
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
private DevExpress.XtraEditors.LabelControl lbInputDI3;
private DevExpress.XtraEditors.ComboBoxEdit drpInputDI3;
private DevExpress.XtraEditors.LabelControl lbResultDO;

        private DevExpress.XtraEditors.GroupControl groupPid;
    }
}