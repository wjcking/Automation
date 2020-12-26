 
namespace Sinowyde.DOP.PIDBlock.Choice 
{
    partial class CtrlParamDisel
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
            this.lbParamDC = new DevExpress.XtraEditors.LabelControl();
            this.lbResultDO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.drpInputDC = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDC.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbInputDI1
            // 
            this.lbInputDI1.Location = new System.Drawing.Point(14, 27);
            this.lbInputDI1.Name = "lbInputDI1";
            this.lbInputDI1.Size = new System.Drawing.Size(91, 14);
            this.lbInputDI1.TabIndex = 0;
            this.lbInputDI1.Text = "DI1：数字量输入";
            // 
            // drpInputDI1
            // 
            this.drpInputDI1.EditValue = "1";
            this.drpInputDI1.Location = new System.Drawing.Point(134, 24);
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
            this.lbInputDI2.Location = new System.Drawing.Point(198, 27);
            this.lbInputDI2.Name = "lbInputDI2";
            this.lbInputDI2.Size = new System.Drawing.Size(91, 14);
            this.lbInputDI2.TabIndex = 0;
            this.lbInputDI2.Text = "DI2：数字量输入";
            // 
            // drpInputDI2
            // 
            this.drpInputDI2.Location = new System.Drawing.Point(300, 24);
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
            // lbParamDC
            // 
            this.lbParamDC.Location = new System.Drawing.Point(14, 53);
            this.lbParamDC.Name = "lbParamDC";
            this.lbParamDC.Size = new System.Drawing.Size(99, 14);
            this.lbParamDC.TabIndex = 0;
            this.lbParamDC.Text = "DC：输入选择信号";
            // 
            // lbResultDO
            // 
            this.lbResultDO.Location = new System.Drawing.Point(14, 79);
            this.lbResultDO.Name = "lbResultDO";
            this.lbResultDO.Size = new System.Drawing.Size(288, 28);
            this.lbResultDO.TabIndex = 0;
            this.lbResultDO.Text = "DO：数字量输出值\r\n       DC为真时， DO=DI1，当 DC为假时，DO=DI2。";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.drpInputDC);
            this.groupPid.Controls.Add(this.lbInputDI1);
            this.groupPid.Controls.Add(this.drpInputDI1);
            this.groupPid.Controls.Add(this.lbInputDI2);
            this.groupPid.Controls.Add(this.drpInputDI2);
            this.groupPid.Controls.Add(this.lbParamDC);
            this.groupPid.Controls.Add(this.lbResultDO);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 110);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // drpInputDC
            // 
            this.drpInputDC.EditValue = "1";
            this.drpInputDC.Location = new System.Drawing.Point(134, 50);
            this.drpInputDC.Name = "drpInputDC";
            this.drpInputDC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDC.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDC.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDC.Size = new System.Drawing.Size(45, 20);
            this.drpInputDC.TabIndex = 2;
            // 
            // CtrlParamDisel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamDisel";
            this.Size = new System.Drawing.Size(364, 114);
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDC.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbInputDI1;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputDI1;
private DevExpress.XtraEditors.LabelControl lbInputDI2;
private DevExpress.XtraEditors.ComboBoxEdit drpInputDI2;
private DevExpress.XtraEditors.LabelControl lbParamDC;
private DevExpress.XtraEditors.LabelControl lbResultDO;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputDC;
    }
}