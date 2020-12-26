 
namespace Sinowyde.DOP.PIDBlock.Signal 
{
    partial class CtrlParamRandom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlParamRandom));
            this.lbParamSTime = new DevExpress.XtraEditors.LabelControl();
            this.spinParamHigh = new DevExpress.XtraEditors.SpinEdit();
            this.lbParamSOut = new DevExpress.XtraEditors.LabelControl();
            this.spinParamLow = new DevExpress.XtraEditors.SpinEdit();
            this.lbInputDI = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbResultAO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamHigh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamLow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbParamSTime
            // 
            this.lbParamSTime.Location = new System.Drawing.Point(19, 27);
            this.lbParamSTime.Name = "lbParamSTime";
            this.lbParamSTime.Size = new System.Drawing.Size(60, 14);
            this.lbParamSTime.TabIndex = 0;
            this.lbParamSTime.Text = "信号上限：";
            // 
            // spinParamHigh
            // 
            this.spinParamHigh.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamHigh.Location = new System.Drawing.Point(85, 24);
            this.spinParamHigh.Name = "spinParamHigh";
            this.spinParamHigh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamHigh.Size = new System.Drawing.Size(70, 20);
            this.spinParamHigh.TabIndex = 0;
            // 
            // lbParamSOut
            // 
            this.lbParamSOut.Location = new System.Drawing.Point(203, 27);
            this.lbParamSOut.Name = "lbParamSOut";
            this.lbParamSOut.Size = new System.Drawing.Size(60, 14);
            this.lbParamSOut.TabIndex = 0;
            this.lbParamSOut.Text = "信号下限：";
            // 
            // spinParamLow
            // 
            this.spinParamLow.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamLow.Location = new System.Drawing.Point(269, 24);
            this.spinParamLow.Name = "spinParamLow";
            this.spinParamLow.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamLow.Size = new System.Drawing.Size(70, 20);
            this.spinParamLow.TabIndex = 1;
            // 
            // lbInputDI
            // 
            this.lbInputDI.Location = new System.Drawing.Point(21, 40);
            this.lbInputDI.Name = "lbInputDI";
            this.lbInputDI.Size = new System.Drawing.Size(60, 14);
            this.lbInputDI.TabIndex = 0;
            this.lbInputDI.Text = "数字量输入";
            // 
            // drpInputDI
            // 
            this.drpInputDI.Location = new System.Drawing.Point(110, 37);
            this.drpInputDI.Name = "drpInputDI";
            this.drpInputDI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI.TabIndex = 2;
            // 
            // lbResultAO
            // 
            this.lbResultAO.Location = new System.Drawing.Point(205, 40);
            this.lbResultAO.Name = "lbResultAO";
            this.lbResultAO.Size = new System.Drawing.Size(60, 14);
            this.lbResultAO.TabIndex = 0;
            this.lbResultAO.Text = "模拟量输出";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputDI);
            this.groupPid.Controls.Add(this.drpInputDI);
            this.groupPid.Controls.Add(this.lbResultAO);
            this.groupPid.Location = new System.Drawing.Point(4, 116);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 76);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(358, 107);
            this.groupControl1.TabIndex = 11;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.lbParamSTime);
            this.groupControl2.Controls.Add(this.spinParamHigh);
            this.groupControl2.Controls.Add(this.spinParamLow);
            this.groupControl2.Controls.Add(this.lbParamSOut);
            this.groupControl2.Location = new System.Drawing.Point(6, 198);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(358, 63);
            this.groupControl2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(113, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 96);
            this.label1.TabIndex = 4;
            // 
            // CtrlParamRandom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamRandom";
            this.Size = new System.Drawing.Size(364, 268);
            ((System.ComponentModel.ISupportInitialize)(this.spinParamHigh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamLow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbParamSTime;
private DevExpress.XtraEditors.SpinEdit spinParamHigh;
private DevExpress.XtraEditors.LabelControl lbParamSOut;
private DevExpress.XtraEditors.SpinEdit spinParamLow;
private DevExpress.XtraEditors.LabelControl lbInputDI;
private DevExpress.XtraEditors.ComboBoxEdit drpInputDI;
private DevExpress.XtraEditors.LabelControl lbResultAO;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label label1;
    }
}