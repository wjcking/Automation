 
namespace Sinowyde.DOP.PIDBlock.Signal 
{
    partial class CtrlParamSquare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlParamSquare));
            this.lbInputDI = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbResultAO = new DevExpress.XtraEditors.LabelControl();
            this.lbParamHigh = new DevExpress.XtraEditors.LabelControl();
            this.spinParamHigh = new DevExpress.XtraEditors.SpinEdit();
            this.lbParamLow = new DevExpress.XtraEditors.LabelControl();
            this.spinParamLow = new DevExpress.XtraEditors.SpinEdit();
            this.lbParamWidth = new DevExpress.XtraEditors.LabelControl();
            this.spinParamWidth = new DevExpress.XtraEditors.SpinEdit();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamHigh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamLow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbInputDI
            // 
            this.lbInputDI.Location = new System.Drawing.Point(17, 39);
            this.lbInputDI.Name = "lbInputDI";
            this.lbInputDI.Size = new System.Drawing.Size(64, 14);
            this.lbInputDI.TabIndex = 0;
            this.lbInputDI.Text = "DI:触发信号";
            // 
            // drpInputDI
            // 
            this.drpInputDI.Location = new System.Drawing.Point(125, 36);
            this.drpInputDI.Name = "drpInputDI";
            this.drpInputDI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI.Properties.Items.AddRange(new object[] {
            "0",
            "1"});
            this.drpInputDI.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI.TabIndex = 4;
            // 
            // lbResultAO
            // 
            this.lbResultAO.Location = new System.Drawing.Point(208, 39);
            this.lbResultAO.Name = "lbResultAO";
            this.lbResultAO.Size = new System.Drawing.Size(72, 14);
            this.lbResultAO.TabIndex = 0;
            this.lbResultAO.Text = "模拟量输出值";
            // 
            // lbParamHigh
            // 
            this.lbParamHigh.Location = new System.Drawing.Point(15, 11);
            this.lbParamHigh.Name = "lbParamHigh";
            this.lbParamHigh.Size = new System.Drawing.Size(52, 14);
            this.lbParamHigh.TabIndex = 0;
            this.lbParamHigh.Text = "High:波峰";
            // 
            // spinParamHigh
            // 
            this.spinParamHigh.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamHigh.Location = new System.Drawing.Point(125, 8);
            this.spinParamHigh.Name = "spinParamHigh";
            this.spinParamHigh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamHigh.Size = new System.Drawing.Size(70, 20);
            this.spinParamHigh.TabIndex = 5;
            // 
            // lbParamLow
            // 
            this.lbParamLow.Location = new System.Drawing.Point(208, 11);
            this.lbParamLow.Name = "lbParamLow";
            this.lbParamLow.Size = new System.Drawing.Size(51, 14);
            this.lbParamLow.TabIndex = 0;
            this.lbParamLow.Text = "Low:波谷";
            // 
            // spinParamLow
            // 
            this.spinParamLow.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamLow.Location = new System.Drawing.Point(265, 8);
            this.spinParamLow.Name = "spinParamLow";
            this.spinParamLow.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamLow.Size = new System.Drawing.Size(70, 20);
            this.spinParamLow.TabIndex = 6;
            // 
            // lbParamWidth
            // 
            this.lbParamWidth.Location = new System.Drawing.Point(15, 34);
            this.lbParamWidth.Name = "lbParamWidth";
            this.lbParamWidth.Size = new System.Drawing.Size(85, 14);
            this.lbParamWidth.TabIndex = 0;
            this.lbParamWidth.Text = "Width:方波宽度";
            // 
            // spinParamWidth
            // 
            this.spinParamWidth.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamWidth.Location = new System.Drawing.Point(125, 34);
            this.spinParamWidth.Name = "spinParamWidth";
            this.spinParamWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamWidth.Size = new System.Drawing.Size(70, 20);
            this.spinParamWidth.TabIndex = 7;
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputDI);
            this.groupPid.Controls.Add(this.drpInputDI);
            this.groupPid.Controls.Add(this.lbResultAO);
            this.groupPid.Location = new System.Drawing.Point(4, 137);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 73);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(358, 128);
            this.groupControl1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(113, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 96);
            this.label1.TabIndex = 2;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.spinParamLow);
            this.groupControl2.Controls.Add(this.spinParamWidth);
            this.groupControl2.Controls.Add(this.lbParamWidth);
            this.groupControl2.Controls.Add(this.lbParamHigh);
            this.groupControl2.Controls.Add(this.lbParamLow);
            this.groupControl2.Controls.Add(this.spinParamHigh);
            this.groupControl2.Location = new System.Drawing.Point(4, 216);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(358, 65);
            this.groupControl2.TabIndex = 12;
            // 
            // CtrlParamSquare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamSquare";
            this.Size = new System.Drawing.Size(364, 281);
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamHigh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamLow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamWidth.Properties)).EndInit();
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

        private DevExpress.XtraEditors.LabelControl lbInputDI;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputDI;
private DevExpress.XtraEditors.LabelControl lbResultAO;
private DevExpress.XtraEditors.LabelControl lbParamHigh;
private DevExpress.XtraEditors.SpinEdit spinParamHigh;
private DevExpress.XtraEditors.LabelControl lbParamLow;
private DevExpress.XtraEditors.SpinEdit spinParamLow;
private DevExpress.XtraEditors.LabelControl lbParamWidth;
private DevExpress.XtraEditors.SpinEdit spinParamWidth;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label label1;
    }
}