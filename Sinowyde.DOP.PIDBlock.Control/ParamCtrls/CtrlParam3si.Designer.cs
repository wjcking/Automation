 
namespace Sinowyde.DOP.PIDBlock.Control 
{
    partial class CtrlParam3si
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
            this.lbInputPV3 = new DevExpress.XtraEditors.LabelControl();
            this.drpInputPV3 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lbParamOutMode = new DevExpress.XtraEditors.LabelControl();
            this.lbParamMode = new DevExpress.XtraEditors.LabelControl();
            this.spinParamOutMode = new DevExpress.XtraEditors.SpinEdit();
            this.lbParamDead = new DevExpress.XtraEditors.LabelControl();
            this.spinParamMode = new DevExpress.XtraEditors.SpinEdit();
            this.spinParamSaftV = new DevExpress.XtraEditors.SpinEdit();
            this.lbParamSaftV = new DevExpress.XtraEditors.LabelControl();
            this.lbParamRange = new DevExpress.XtraEditors.LabelControl();
            this.spinParamDead = new DevExpress.XtraEditors.SpinEdit();
            this.spinParamRange = new DevExpress.XtraEditors.SpinEdit();
            this.lbResultAO = new DevExpress.XtraEditors.LabelControl();
            this.lbResultALM = new DevExpress.XtraEditors.LabelControl();
            this.lbInputPV2 = new DevExpress.XtraEditors.LabelControl();
            this.drpInputPV2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.drpInputPV1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbResultMRE = new DevExpress.XtraEditors.LabelControl();
            this.lbInputPV1 = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputPV3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamOutMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamSaftV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamDead.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamRange.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputPV2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputPV1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbInputPV3
            // 
            this.lbInputPV3.Location = new System.Drawing.Point(15, 72);
            this.lbInputPV3.Name = "lbInputPV3";
            this.lbInputPV3.Size = new System.Drawing.Size(86, 14);
            this.lbInputPV3.TabIndex = 0;
            this.lbInputPV3.Text = "PV3:模拟量输入";
            // 
            // drpInputPV3
            // 
            this.drpInputPV3.EditValue = "1";
            this.drpInputPV3.Location = new System.Drawing.Point(124, 69);
            this.drpInputPV3.Name = "drpInputPV3";
            this.drpInputPV3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputPV3.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputPV3.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputPV3.Size = new System.Drawing.Size(45, 20);
            this.drpInputPV3.TabIndex = 7;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lbParamOutMode);
            this.groupControl1.Controls.Add(this.lbParamMode);
            this.groupControl1.Controls.Add(this.spinParamOutMode);
            this.groupControl1.Controls.Add(this.lbParamDead);
            this.groupControl1.Controls.Add(this.spinParamMode);
            this.groupControl1.Controls.Add(this.spinParamSaftV);
            this.groupControl1.Controls.Add(this.lbParamSaftV);
            this.groupControl1.Controls.Add(this.lbParamRange);
            this.groupControl1.Controls.Add(this.spinParamDead);
            this.groupControl1.Controls.Add(this.spinParamRange);
            this.groupControl1.Location = new System.Drawing.Point(3, 146);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(358, 100);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "groupControl1";
            // 
            // lbParamOutMode
            // 
            this.lbParamOutMode.Location = new System.Drawing.Point(202, 17);
            this.lbParamOutMode.Name = "lbParamOutMode";
            this.lbParamOutMode.Size = new System.Drawing.Size(72, 14);
            this.lbParamOutMode.TabIndex = 0;
            this.lbParamOutMode.Text = "输出方式选择";
            // 
            // lbParamMode
            // 
            this.lbParamMode.Location = new System.Drawing.Point(12, 17);
            this.lbParamMode.Name = "lbParamMode";
            this.lbParamMode.Size = new System.Drawing.Size(72, 14);
            this.lbParamMode.TabIndex = 0;
            this.lbParamMode.Text = "工作方式选择";
            // 
            // spinParamOutMode
            // 
            this.spinParamOutMode.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamOutMode.Location = new System.Drawing.Point(283, 14);
            this.spinParamOutMode.Name = "spinParamOutMode";
            this.spinParamOutMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamOutMode.Size = new System.Drawing.Size(70, 20);
            this.spinParamOutMode.TabIndex = 1;
            // 
            // lbParamDead
            // 
            this.lbParamDead.Location = new System.Drawing.Point(202, 43);
            this.lbParamDead.Name = "lbParamDead";
            this.lbParamDead.Size = new System.Drawing.Size(72, 14);
            this.lbParamDead.TabIndex = 0;
            this.lbParamDead.Text = "报警偏差死区";
            // 
            // spinParamMode
            // 
            this.spinParamMode.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamMode.Location = new System.Drawing.Point(126, 14);
            this.spinParamMode.Name = "spinParamMode";
            this.spinParamMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamMode.Size = new System.Drawing.Size(70, 20);
            this.spinParamMode.TabIndex = 0;
            // 
            // spinParamSaftV
            // 
            this.spinParamSaftV.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamSaftV.Location = new System.Drawing.Point(126, 66);
            this.spinParamSaftV.Name = "spinParamSaftV";
            this.spinParamSaftV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamSaftV.Size = new System.Drawing.Size(70, 20);
            this.spinParamSaftV.TabIndex = 4;
            // 
            // lbParamSaftV
            // 
            this.lbParamSaftV.Location = new System.Drawing.Point(10, 69);
            this.lbParamSaftV.Name = "lbParamSaftV";
            this.lbParamSaftV.Size = new System.Drawing.Size(60, 14);
            this.lbParamSaftV.TabIndex = 0;
            this.lbParamSaftV.Text = "输出安全值";
            // 
            // lbParamRange
            // 
            this.lbParamRange.Location = new System.Drawing.Point(12, 43);
            this.lbParamRange.Name = "lbParamRange";
            this.lbParamRange.Size = new System.Drawing.Size(48, 14);
            this.lbParamRange.TabIndex = 0;
            this.lbParamRange.Text = "报警偏差";
            // 
            // spinParamDead
            // 
            this.spinParamDead.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamDead.Location = new System.Drawing.Point(283, 40);
            this.spinParamDead.Name = "spinParamDead";
            this.spinParamDead.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamDead.Size = new System.Drawing.Size(70, 20);
            this.spinParamDead.TabIndex = 3;
            // 
            // spinParamRange
            // 
            this.spinParamRange.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamRange.Location = new System.Drawing.Point(126, 40);
            this.spinParamRange.Name = "spinParamRange";
            this.spinParamRange.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamRange.Size = new System.Drawing.Size(70, 20);
            this.spinParamRange.TabIndex = 2;
            // 
            // lbResultAO
            // 
            this.lbResultAO.Location = new System.Drawing.Point(189, 75);
            this.lbResultAO.Name = "lbResultAO";
            this.lbResultAO.Size = new System.Drawing.Size(77, 14);
            this.lbResultAO.TabIndex = 0;
            this.lbResultAO.Text = "AO模拟量输出";
            // 
            // lbResultALM
            // 
            this.lbResultALM.Location = new System.Drawing.Point(189, 102);
            this.lbResultALM.Name = "lbResultALM";
            this.lbResultALM.Size = new System.Drawing.Size(107, 14);
            this.lbResultALM.TabIndex = 0;
            this.lbResultALM.Text = "ALM变送器报警信号";
            // 
            // lbInputPV2
            // 
            this.lbInputPV2.Location = new System.Drawing.Point(189, 39);
            this.lbInputPV2.Name = "lbInputPV2";
            this.lbInputPV2.Size = new System.Drawing.Size(86, 14);
            this.lbInputPV2.TabIndex = 0;
            this.lbInputPV2.Text = "PV2:模拟量输入";
            // 
            // drpInputPV2
            // 
            this.drpInputPV2.EditValue = "1";
            this.drpInputPV2.Location = new System.Drawing.Point(299, 36);
            this.drpInputPV2.Name = "drpInputPV2";
            this.drpInputPV2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputPV2.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputPV2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputPV2.Size = new System.Drawing.Size(45, 20);
            this.drpInputPV2.TabIndex = 6;
            // 
            // drpInputPV1
            // 
            this.drpInputPV1.EditValue = "1";
            this.drpInputPV1.Location = new System.Drawing.Point(123, 36);
            this.drpInputPV1.Name = "drpInputPV1";
            this.drpInputPV1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputPV1.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputPV1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputPV1.Size = new System.Drawing.Size(45, 20);
            this.drpInputPV1.TabIndex = 5;
            // 
            // lbResultMRE
            // 
            this.lbResultMRE.Location = new System.Drawing.Point(15, 102);
            this.lbResultMRE.Name = "lbResultMRE";
            this.lbResultMRE.Size = new System.Drawing.Size(143, 14);
            this.lbResultMRE.TabIndex = 0;
            this.lbResultMRE.Text = "MRE变送器故障切手动信号";
            // 
            // lbInputPV1
            // 
            this.lbInputPV1.Location = new System.Drawing.Point(13, 39);
            this.lbInputPV1.Name = "lbInputPV1";
            this.lbInputPV1.Size = new System.Drawing.Size(86, 14);
            this.lbInputPV1.TabIndex = 0;
            this.lbInputPV1.Text = "PV1:模拟量输入";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputPV1);
            this.groupPid.Controls.Add(this.lbResultAO);
            this.groupPid.Controls.Add(this.drpInputPV3);
            this.groupPid.Controls.Add(this.drpInputPV1);
            this.groupPid.Controls.Add(this.lbInputPV3);
            this.groupPid.Controls.Add(this.lbInputPV2);
            this.groupPid.Controls.Add(this.drpInputPV2);
            this.groupPid.Controls.Add(this.lbResultALM);
            this.groupPid.Controls.Add(this.lbResultMRE);
            this.groupPid.Location = new System.Drawing.Point(0, 3);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(359, 137);
            this.groupPid.TabIndex = 8;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // CtrlParam3si
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParam3si";
            this.Size = new System.Drawing.Size(364, 252);
            ((System.ComponentModel.ISupportInitialize)(this.drpInputPV3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamOutMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamSaftV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamDead.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamRange.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputPV2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputPV1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbInputPV3;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputPV3;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lbParamOutMode;
        private DevExpress.XtraEditors.LabelControl lbParamMode;
        private DevExpress.XtraEditors.SpinEdit spinParamOutMode;
        private DevExpress.XtraEditors.LabelControl lbParamDead;
        private DevExpress.XtraEditors.SpinEdit spinParamMode;
        private DevExpress.XtraEditors.SpinEdit spinParamSaftV;
        private DevExpress.XtraEditors.LabelControl lbParamSaftV;
        private DevExpress.XtraEditors.LabelControl lbParamRange;
        private DevExpress.XtraEditors.SpinEdit spinParamDead;
        private DevExpress.XtraEditors.SpinEdit spinParamRange;
        private DevExpress.XtraEditors.LabelControl lbResultAO;
        private DevExpress.XtraEditors.LabelControl lbResultALM;
        private DevExpress.XtraEditors.LabelControl lbInputPV2;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputPV2;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputPV1;
        private DevExpress.XtraEditors.LabelControl lbResultMRE;
        private DevExpress.XtraEditors.LabelControl lbInputPV1;
        private DevExpress.XtraEditors.GroupControl groupPid;
    }
}