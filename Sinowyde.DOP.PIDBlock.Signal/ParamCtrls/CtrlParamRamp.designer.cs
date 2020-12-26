 
namespace Sinowyde.DOP.PIDBlock.Signal 
{
    partial class CtrlParamRamp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlParamRamp));
            this.lbParamInit = new DevExpress.XtraEditors.LabelControl();
            this.spinParamInit = new DevExpress.XtraEditors.SpinEdit();
            this.lbParamSlope = new DevExpress.XtraEditors.LabelControl();
            this.spinParamSlope = new DevExpress.XtraEditors.SpinEdit();
            this.lbParamTime = new DevExpress.XtraEditors.LabelControl();
            this.spinParamTime = new DevExpress.XtraEditors.SpinEdit();
            this.lbInputDI = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbResultAO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamInit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamSlope.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbParamInit
            // 
            this.lbParamInit.Location = new System.Drawing.Point(15, 41);
            this.lbParamInit.Name = "lbParamInit";
            this.lbParamInit.Size = new System.Drawing.Size(46, 14);
            this.lbParamInit.TabIndex = 0;
            this.lbParamInit.Text = "Init:初值";
            // 
            // spinParamInit
            // 
            this.spinParamInit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamInit.Location = new System.Drawing.Point(99, 41);
            this.spinParamInit.Name = "spinParamInit";
            this.spinParamInit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamInit.Size = new System.Drawing.Size(70, 20);
            this.spinParamInit.TabIndex = 0;
            // 
            // lbParamSlope
            // 
            this.lbParamSlope.Location = new System.Drawing.Point(199, 41);
            this.lbParamSlope.Name = "lbParamSlope";
            this.lbParamSlope.Size = new System.Drawing.Size(70, 14);
            this.lbParamSlope.TabIndex = 0;
            this.lbParamSlope.Text = "Slope:斜率值";
            // 
            // spinParamSlope
            // 
            this.spinParamSlope.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamSlope.Location = new System.Drawing.Point(275, 38);
            this.spinParamSlope.Name = "spinParamSlope";
            this.spinParamSlope.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamSlope.Size = new System.Drawing.Size(70, 20);
            this.spinParamSlope.TabIndex = 1;
            // 
            // lbParamTime
            // 
            this.lbParamTime.Location = new System.Drawing.Point(14, 70);
            this.lbParamTime.Name = "lbParamTime";
            this.lbParamTime.Size = new System.Drawing.Size(79, 14);
            this.lbParamTime.TabIndex = 0;
            this.lbParamTime.Text = "Time:发生时间";
            // 
            // spinParamTime
            // 
            this.spinParamTime.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamTime.Location = new System.Drawing.Point(99, 67);
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
            // lbInputDI
            // 
            this.lbInputDI.Location = new System.Drawing.Point(13, 15);
            this.lbInputDI.Name = "lbInputDI";
            this.lbInputDI.Size = new System.Drawing.Size(64, 14);
            this.lbInputDI.TabIndex = 0;
            this.lbInputDI.Text = "DI:触发信号";
            // 
            // drpInputDI
            // 
            this.drpInputDI.EditValue = "1";
            this.drpInputDI.Location = new System.Drawing.Point(97, 12);
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
            // lbResultAO
            // 
            this.lbResultAO.Location = new System.Drawing.Point(197, 15);
            this.lbResultAO.Name = "lbResultAO";
            this.lbResultAO.Size = new System.Drawing.Size(60, 14);
            this.lbResultAO.TabIndex = 0;
            this.lbResultAO.Text = "模拟量输出";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbParamInit);
            this.groupPid.Controls.Add(this.spinParamInit);
            this.groupPid.Controls.Add(this.lbParamSlope);
            this.groupPid.Controls.Add(this.spinParamSlope);
            this.groupPid.Controls.Add(this.lbParamTime);
            this.groupPid.Controls.Add(this.spinParamTime);
            this.groupPid.Location = new System.Drawing.Point(1, 122);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 101);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(358, 113);
            this.groupControl1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(113, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 96);
            this.label1.TabIndex = 2;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.drpInputDI);
            this.groupControl2.Controls.Add(this.lbInputDI);
            this.groupControl2.Controls.Add(this.lbResultAO);
            this.groupControl2.Location = new System.Drawing.Point(3, 229);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(358, 49);
            this.groupControl2.TabIndex = 9;
            // 
            // CtrlParamRamp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamRamp";
            this.Size = new System.Drawing.Size(364, 282);
            ((System.ComponentModel.ISupportInitialize)(this.spinParamInit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamSlope.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamTime.Properties)).EndInit();
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

        private DevExpress.XtraEditors.LabelControl lbParamInit;
private DevExpress.XtraEditors.SpinEdit spinParamInit;
private DevExpress.XtraEditors.LabelControl lbParamSlope;
private DevExpress.XtraEditors.SpinEdit spinParamSlope;
private DevExpress.XtraEditors.LabelControl lbParamTime;
private DevExpress.XtraEditors.SpinEdit spinParamTime;
private DevExpress.XtraEditors.LabelControl lbInputDI;
private DevExpress.XtraEditors.ComboBoxEdit drpInputDI;
private DevExpress.XtraEditors.LabelControl lbResultAO;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label label1;
    }
}