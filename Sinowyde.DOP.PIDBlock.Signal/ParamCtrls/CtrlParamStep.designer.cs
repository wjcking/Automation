 
namespace Sinowyde.DOP.PIDBlock.Signal 
{
    partial class CtrlParamStep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlParamStep));
            this.lbParamInit = new DevExpress.XtraEditors.LabelControl();
            this.spinParamInit = new DevExpress.XtraEditors.SpinEdit();
            this.lbParamStep = new DevExpress.XtraEditors.LabelControl();
            this.spinParamStep = new DevExpress.XtraEditors.SpinEdit();
            this.lbParamTime = new DevExpress.XtraEditors.LabelControl();
            this.spinParamTime = new DevExpress.XtraEditors.SpinEdit();
            this.lbInputDI = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbResultAO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamInit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamStep.Properties)).BeginInit();
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
            this.lbParamInit.Location = new System.Drawing.Point(13, 41);
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
            this.spinParamInit.Location = new System.Drawing.Point(114, 38);
            this.spinParamInit.Name = "spinParamInit";
            this.spinParamInit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamInit.Size = new System.Drawing.Size(70, 20);
            this.spinParamInit.TabIndex = 0;
            // 
            // lbParamStep
            // 
            this.lbParamStep.Location = new System.Drawing.Point(213, 41);
            this.lbParamStep.Name = "lbParamStep";
            this.lbParamStep.Size = new System.Drawing.Size(66, 14);
            this.lbParamStep.TabIndex = 0;
            this.lbParamStep.Text = "Step:阶跃值";
            // 
            // spinParamStep
            // 
            this.spinParamStep.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinParamStep.Location = new System.Drawing.Point(285, 38);
            this.spinParamStep.Name = "spinParamStep";
            this.spinParamStep.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamStep.Size = new System.Drawing.Size(70, 20);
            this.spinParamStep.TabIndex = 1;
            // 
            // lbParamTime
            // 
            this.lbParamTime.Location = new System.Drawing.Point(13, 67);
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
            this.spinParamTime.Location = new System.Drawing.Point(114, 64);
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
            this.lbInputDI.Location = new System.Drawing.Point(13, 21);
            this.lbInputDI.Name = "lbInputDI";
            this.lbInputDI.Size = new System.Drawing.Size(72, 14);
            this.lbInputDI.TabIndex = 0;
            this.lbInputDI.Text = "数字量输入：";
            // 
            // drpInputDI
            // 
            this.drpInputDI.EditValue = "1";
            this.drpInputDI.Location = new System.Drawing.Point(114, 15);
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
            this.lbResultAO.Location = new System.Drawing.Point(213, 21);
            this.lbResultAO.Name = "lbResultAO";
            this.lbResultAO.Size = new System.Drawing.Size(72, 14);
            this.lbResultAO.TabIndex = 0;
            this.lbResultAO.Text = "模拟量输出值";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbParamInit);
            this.groupPid.Controls.Add(this.spinParamInit);
            this.groupPid.Controls.Add(this.lbParamStep);
            this.groupPid.Controls.Add(this.spinParamStep);
            this.groupPid.Controls.Add(this.lbParamTime);
            this.groupPid.Controls.Add(this.spinParamTime);
            this.groupPid.Location = new System.Drawing.Point(3, 117);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 98);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(358, 110);
            this.groupControl1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(116, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 96);
            this.label1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(136, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "算法图片";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.lbInputDI);
            this.groupControl2.Controls.Add(this.lbResultAO);
            this.groupControl2.Controls.Add(this.drpInputDI);
            this.groupControl2.Location = new System.Drawing.Point(3, 218);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(358, 54);
            this.groupControl2.TabIndex = 8;
            // 
            // CtrlParamStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamStep";
            this.Size = new System.Drawing.Size(364, 273);
            ((System.ComponentModel.ISupportInitialize)(this.spinParamInit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamStep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbParamInit;
private DevExpress.XtraEditors.SpinEdit spinParamInit;
private DevExpress.XtraEditors.LabelControl lbParamStep;
private DevExpress.XtraEditors.SpinEdit spinParamStep;
private DevExpress.XtraEditors.LabelControl lbParamTime;
private DevExpress.XtraEditors.SpinEdit spinParamTime;
private DevExpress.XtraEditors.LabelControl lbInputDI;
private DevExpress.XtraEditors.ComboBoxEdit drpInputDI;
private DevExpress.XtraEditors.LabelControl lbResultAO;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label label1;
    }
}