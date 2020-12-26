 
namespace Sinowyde.DOP.PIDBlock.Control 
{
    partial class CtrlParamAsetpoint
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
            this.lbParamMO = new DevExpress.XtraEditors.LabelControl();
            this.spinParamMO = new DevExpress.XtraEditors.SpinEdit();
            this.lbInputDI = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbResultAO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btnOutput = new DevExpress.XtraEditors.SimpleButton();
            this.btnDec = new DevExpress.XtraEditors.SimpleButton();
            this.btnInc = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spinOutput = new DevExpress.XtraEditors.SpinEdit();
            this.spinDec = new DevExpress.XtraEditors.SpinEdit();
            this.spinInc = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamMO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinOutput.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinDec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbParamMO
            // 
            this.lbParamMO.Location = new System.Drawing.Point(18, 18);
            this.lbParamMO.Name = "lbParamMO";
            this.lbParamMO.Size = new System.Drawing.Size(48, 14);
            this.lbParamMO.TabIndex = 0;
            this.lbParamMO.Text = "输出初值";
            // 
            // spinParamMO
            // 
            this.spinParamMO.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamMO.Location = new System.Drawing.Point(118, 15);
            this.spinParamMO.Name = "spinParamMO";
            this.spinParamMO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamMO.Size = new System.Drawing.Size(70, 20);
            this.spinParamMO.TabIndex = 0;
            // 
            // lbInputDI
            // 
            this.lbInputDI.Location = new System.Drawing.Point(18, 42);
            this.lbInputDI.Name = "lbInputDI";
            this.lbInputDI.Size = new System.Drawing.Size(76, 14);
            this.lbInputDI.TabIndex = 0;
            this.lbInputDI.Text = "DI:数字量输入";
            // 
            // drpInputDI
            // 
            this.drpInputDI.EditValue = "1";
            this.drpInputDI.Location = new System.Drawing.Point(147, 39);
            this.drpInputDI.Name = "drpInputDI";
            this.drpInputDI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI.TabIndex = 1;
            // 
            // lbResultAO
            // 
            this.lbResultAO.Location = new System.Drawing.Point(255, 42);
            this.lbResultAO.Name = "lbResultAO";
            this.lbResultAO.Size = new System.Drawing.Size(81, 14);
            this.lbResultAO.TabIndex = 0;
            this.lbResultAO.Text = "AO:模拟量输出";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputDI);
            this.groupPid.Controls.Add(this.drpInputDI);
            this.groupPid.Controls.Add(this.lbResultAO);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 77);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lbParamMO);
            this.groupControl1.Controls.Add(this.spinParamMO);
            this.groupControl1.Location = new System.Drawing.Point(2, 85);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(358, 53);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "groupControl1";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.btnOutput);
            this.groupControl3.Controls.Add(this.btnDec);
            this.groupControl3.Controls.Add(this.btnInc);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.spinOutput);
            this.groupControl3.Controls.Add(this.spinDec);
            this.groupControl3.Controls.Add(this.spinInc);
            this.groupControl3.Location = new System.Drawing.Point(1, 144);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(360, 118);
            this.groupControl3.TabIndex = 9;
            this.groupControl3.Text = "调试操作";
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(16, 85);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 23);
            this.btnOutput.TabIndex = 3;
            this.btnOutput.Text = "直接输出";
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnDec
            // 
            this.btnDec.Location = new System.Drawing.Point(16, 59);
            this.btnDec.Name = "btnDec";
            this.btnDec.Size = new System.Drawing.Size(75, 23);
            this.btnDec.TabIndex = 3;
            this.btnDec.Text = "减小";
            this.btnDec.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnInc
            // 
            this.btnInc.Location = new System.Drawing.Point(16, 33);
            this.btnInc.Name = "btnInc";
            this.btnInc.Size = new System.Drawing.Size(75, 23);
            this.btnInc.TabIndex = 3;
            this.btnInc.Text = "增加";
            this.btnInc.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(191, 89);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 14);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "直接输出值:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(191, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "减小幅值:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(191, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "增加幅值:";
            // 
            // spinOutput
            // 
            this.spinOutput.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinOutput.Location = new System.Drawing.Point(264, 86);
            this.spinOutput.Name = "spinOutput";
            this.spinOutput.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinOutput.Size = new System.Drawing.Size(70, 20);
            this.spinOutput.TabIndex = 2;
            // 
            // spinDec
            // 
            this.spinDec.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinDec.Location = new System.Drawing.Point(264, 56);
            this.spinDec.Name = "spinDec";
            this.spinDec.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinDec.Size = new System.Drawing.Size(70, 20);
            this.spinDec.TabIndex = 2;
            // 
            // spinInc
            // 
            this.spinInc.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinInc.Location = new System.Drawing.Point(264, 30);
            this.spinInc.Name = "spinInc";
            this.spinInc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinInc.Size = new System.Drawing.Size(70, 20);
            this.spinInc.TabIndex = 2;
            // 
            // CtrlParamAsetpoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamAsetpoint";
            this.Size = new System.Drawing.Size(371, 276);
            ((System.ComponentModel.ISupportInitialize)(this.spinParamMO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinOutput.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinDec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInc.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbParamMO;
private DevExpress.XtraEditors.SpinEdit spinParamMO;
private DevExpress.XtraEditors.LabelControl lbInputDI;
private DevExpress.XtraEditors.ComboBoxEdit drpInputDI;
private DevExpress.XtraEditors.LabelControl lbResultAO;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit spinOutput;
        private DevExpress.XtraEditors.SpinEdit spinDec;
        private DevExpress.XtraEditors.SpinEdit spinInc;
        private DevExpress.XtraEditors.SimpleButton btnOutput;
        private DevExpress.XtraEditors.SimpleButton btnDec;
        private DevExpress.XtraEditors.SimpleButton btnInc;
    }
}