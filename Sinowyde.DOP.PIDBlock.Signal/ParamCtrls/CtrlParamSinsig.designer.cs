 
namespace Sinowyde.DOP.PIDBlock.Signal 
{
    partial class CtrlParamSinsig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlParamSinsig));
            this.lbParamInit = new DevExpress.XtraEditors.LabelControl();
            this.spinParamRad = new DevExpress.XtraEditors.SpinEdit();
            this.lbParamSlope = new DevExpress.XtraEditors.LabelControl();
            this.spinParamK = new DevExpress.XtraEditors.SpinEdit();
            this.lbParamTime = new DevExpress.XtraEditors.LabelControl();
            this.spinParamTime = new DevExpress.XtraEditors.SpinEdit();
            this.drpInputDI = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.spinParamFreq = new DevExpress.XtraEditors.SpinEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamRad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamFreq.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbParamInit
            // 
            this.lbParamInit.Location = new System.Drawing.Point(182, 37);
            this.lbParamInit.Name = "lbParamInit";
            this.lbParamInit.Size = new System.Drawing.Size(28, 14);
            this.lbParamInit.TabIndex = 0;
            this.lbParamInit.Text = "相角:";
            // 
            // spinParamRad
            // 
            this.spinParamRad.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamRad.Location = new System.Drawing.Point(225, 34);
            this.spinParamRad.Name = "spinParamRad";
            this.spinParamRad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamRad.Size = new System.Drawing.Size(70, 20);
            this.spinParamRad.TabIndex = 0;
            // 
            // lbParamSlope
            // 
            this.lbParamSlope.Location = new System.Drawing.Point(182, 8);
            this.lbParamSlope.Name = "lbParamSlope";
            this.lbParamSlope.Size = new System.Drawing.Size(28, 14);
            this.lbParamSlope.TabIndex = 0;
            this.lbParamSlope.Text = "幅值:";
            // 
            // spinParamK
            // 
            this.spinParamK.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinParamK.Location = new System.Drawing.Point(225, 5);
            this.spinParamK.Name = "spinParamK";
            this.spinParamK.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamK.Size = new System.Drawing.Size(70, 20);
            this.spinParamK.TabIndex = 1;
            // 
            // lbParamTime
            // 
            this.lbParamTime.Location = new System.Drawing.Point(6, 11);
            this.lbParamTime.Name = "lbParamTime";
            this.lbParamTime.Size = new System.Drawing.Size(48, 14);
            this.lbParamTime.TabIndex = 0;
            this.lbParamTime.Text = "发生时间";
            // 
            // spinParamTime
            // 
            this.spinParamTime.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamTime.Location = new System.Drawing.Point(60, 5);
            this.spinParamTime.Name = "spinParamTime";
            this.spinParamTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamTime.Properties.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.spinParamTime.Size = new System.Drawing.Size(70, 20);
            this.spinParamTime.TabIndex = 2;
            // 
            // drpInputDI
            // 
            this.drpInputDI.EditValue = "1";
            this.drpInputDI.Location = new System.Drawing.Point(130, 33);
            this.drpInputDI.Name = "drpInputDI";
            this.drpInputDI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI.Properties.Items.AddRange(new object[] {
            "0",
            "1"});
            this.drpInputDI.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI.TabIndex = 3;
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.labelControl1);
            this.groupPid.Controls.Add(this.labelControl2);
            this.groupPid.Controls.Add(this.drpInputDI);
            this.groupPid.Location = new System.Drawing.Point(3, 116);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 66);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "数字量输入：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(193, 36);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "模拟量输出值";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.spinParamFreq);
            this.groupControl2.Controls.Add(this.spinParamK);
            this.groupControl2.Controls.Add(this.lbParamInit);
            this.groupControl2.Controls.Add(this.spinParamTime);
            this.groupControl2.Controls.Add(this.lbParamTime);
            this.groupControl2.Controls.Add(this.spinParamRad);
            this.groupControl2.Controls.Add(this.lbParamSlope);
            this.groupControl2.Location = new System.Drawing.Point(3, 188);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(358, 62);
            this.groupControl2.TabIndex = 9;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(312, 37);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(22, 14);
            this.labelControl7.TabIndex = 5;
            this.labelControl7.Text = "rads";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(136, 37);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(32, 14);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "rads/s";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(136, 8);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(12, 14);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "秒";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(6, 37);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(28, 14);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "频率:";
            // 
            // spinParamFreq
            // 
            this.spinParamFreq.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinParamFreq.Location = new System.Drawing.Point(60, 34);
            this.spinParamFreq.Name = "spinParamFreq";
            this.spinParamFreq.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamFreq.Size = new System.Drawing.Size(70, 20);
            this.spinParamFreq.TabIndex = 4;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(358, 107);
            this.groupControl1.TabIndex = 10;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(23, 88);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(86, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "y=A*Sin(ωt+φ)";
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(113, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 96);
            this.label1.TabIndex = 2;
            // 
            // CtrlParamSinsig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupPid);
            this.Controls.Add(this.groupControl2);
            this.Name = "CtrlParamSinsig";
            this.Size = new System.Drawing.Size(364, 253);
            ((System.ComponentModel.ISupportInitialize)(this.spinParamRad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamFreq.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbParamInit;
private DevExpress.XtraEditors.SpinEdit spinParamRad;
private DevExpress.XtraEditors.LabelControl lbParamSlope;
private DevExpress.XtraEditors.SpinEdit spinParamK;
private DevExpress.XtraEditors.LabelControl lbParamTime;
private DevExpress.XtraEditors.SpinEdit spinParamTime;
private DevExpress.XtraEditors.ComboBoxEdit drpInputDI;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SpinEdit spinParamFreq;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}