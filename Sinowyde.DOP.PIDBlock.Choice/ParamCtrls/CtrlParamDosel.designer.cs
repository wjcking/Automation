 
namespace Sinowyde.DOP.PIDBlock.Choice 
{
    partial class CtrlParamDosel
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
            this.lbInputDI = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbParamDC = new DevExpress.XtraEditors.LabelControl();
            this.lbResultDO2 = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDC = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDC.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbInputDI
            // 
            this.lbInputDI.Location = new System.Drawing.Point(14, 27);
            this.lbInputDI.Name = "lbInputDI";
            this.lbInputDI.Size = new System.Drawing.Size(76, 14);
            this.lbInputDI.TabIndex = 0;
            this.lbInputDI.Text = "DI:数字量输入";
            // 
            // drpInputDI
            // 
            this.drpInputDI.Location = new System.Drawing.Point(110, 24);
            this.drpInputDI.Name = "drpInputDI";
            this.drpInputDI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI.TabIndex = 0;
            // 
            // lbParamDC
            // 
            this.lbParamDC.Location = new System.Drawing.Point(185, 27);
            this.lbParamDC.Name = "lbParamDC";
            this.lbParamDC.Size = new System.Drawing.Size(91, 14);
            this.lbParamDC.TabIndex = 0;
            this.lbParamDC.Text = "DC:输出选择信号";
            // 
            // lbResultDO2
            // 
            this.lbResultDO2.Location = new System.Drawing.Point(14, 50);
            this.lbResultDO2.Name = "lbResultDO2";
            this.lbResultDO2.Size = new System.Drawing.Size(144, 14);
            this.lbResultDO2.TabIndex = 0;
            this.lbResultDO2.Text = "DO1，DO2：数字量输出值";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.labelControl1);
            this.groupPid.Controls.Add(this.lbInputDI);
            this.groupPid.Controls.Add(this.drpInputDC);
            this.groupPid.Controls.Add(this.drpInputDI);
            this.groupPid.Controls.Add(this.lbParamDC);
            this.groupPid.Controls.Add(this.lbResultDO2);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(359, 90);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 68);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(240, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "若DC为真时，DO1=DI，DC为假时，DO2=DI";
            // 
            // drpInputDC
            // 
            this.drpInputDC.Location = new System.Drawing.Point(298, 24);
            this.drpInputDC.Name = "drpInputDC";
            this.drpInputDC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDC.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDC.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDC.Size = new System.Drawing.Size(45, 20);
            this.drpInputDC.TabIndex = 0;
            // 
            // CtrlParamDosel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamDosel";
            this.Size = new System.Drawing.Size(364, 94);
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDC.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbInputDI;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputDI;
        private DevExpress.XtraEditors.LabelControl lbParamDC;
private DevExpress.XtraEditors.LabelControl lbResultDO2;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputDC;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}