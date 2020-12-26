 
namespace Sinowyde.DOP.PIDBlock.Time 
{
    partial class CtrlParamTex
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
            this.spinParamEndTime = new DevExpress.XtraEditors.SpinEdit();
            this.lbInputPV = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.drpInputRS = new DevExpress.XtraEditors.ComboBoxEdit();
            this.drpInputSet = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbParamSET = new DevExpress.XtraEditors.LabelControl();
            this.lbParamRS = new DevExpress.XtraEditors.LabelControl();
            this.lbResultAO = new DevExpress.XtraEditors.LabelControl();
            this.lbResultDO = new DevExpress.XtraEditors.LabelControl();
            this.lbParamEndTime = new DevExpress.XtraEditors.LabelControl();
            this.spinInputPV = new DevExpress.XtraEditors.SpinEdit();
            this.lbParamMODE = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.drpMode = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputRS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputSet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputPV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpMode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // spinParamEndTime
            // 
            this.spinParamEndTime.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamEndTime.Location = new System.Drawing.Point(114, 17);
            this.spinParamEndTime.Name = "spinParamEndTime";
            this.spinParamEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamEndTime.Size = new System.Drawing.Size(70, 20);
            this.spinParamEndTime.TabIndex = 0;
            // 
            // lbInputPV
            // 
            this.lbInputPV.Location = new System.Drawing.Point(14, 36);
            this.lbInputPV.Name = "lbInputPV";
            this.lbInputPV.Size = new System.Drawing.Size(79, 14);
            this.lbInputPV.TabIndex = 0;
            this.lbInputPV.Text = "PV:输入定时值";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.drpInputRS);
            this.groupPid.Controls.Add(this.drpInputSet);
            this.groupPid.Controls.Add(this.spinInputPV);
            this.groupPid.Controls.Add(this.lbInputPV);
            this.groupPid.Controls.Add(this.lbParamSET);
            this.groupPid.Controls.Add(this.lbParamRS);
            this.groupPid.Controls.Add(this.lbResultAO);
            this.groupPid.Controls.Add(this.lbResultDO);
            this.groupPid.Location = new System.Drawing.Point(3, 3);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 126);
            this.groupPid.TabIndex = 7;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // drpInputRS
            // 
            this.drpInputRS.EditValue = "1";
            this.drpInputRS.Location = new System.Drawing.Point(283, 65);
            this.drpInputRS.Name = "drpInputRS";
            this.drpInputRS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputRS.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputRS.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputRS.Size = new System.Drawing.Size(45, 20);
            this.drpInputRS.TabIndex = 5;
            // 
            // drpInputSet
            // 
            this.drpInputSet.EditValue = "1";
            this.drpInputSet.Location = new System.Drawing.Point(140, 65);
            this.drpInputSet.Name = "drpInputSet";
            this.drpInputSet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputSet.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputSet.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputSet.Size = new System.Drawing.Size(45, 20);
            this.drpInputSet.TabIndex = 4;
            // 
            // lbParamSET
            // 
            this.lbParamSET.Location = new System.Drawing.Point(13, 68);
            this.lbParamSET.Name = "lbParamSET";
            this.lbParamSET.Size = new System.Drawing.Size(98, 14);
            this.lbParamSET.TabIndex = 0;
            this.lbParamSET.Text = "SET:开始工作信号";
            // 
            // lbParamRS
            // 
            this.lbParamRS.Location = new System.Drawing.Point(198, 68);
            this.lbParamRS.Name = "lbParamRS";
            this.lbParamRS.Size = new System.Drawing.Size(66, 14);
            this.lbParamRS.TabIndex = 0;
            this.lbParamRS.Text = "RS:复位信号";
            // 
            // lbResultAO
            // 
            this.lbResultAO.Location = new System.Drawing.Point(14, 100);
            this.lbResultAO.Name = "lbResultAO";
            this.lbResultAO.Size = new System.Drawing.Size(101, 14);
            this.lbResultAO.TabIndex = 0;
            this.lbResultAO.Text = "AO当前定时时间值";
            // 
            // lbResultDO
            // 
            this.lbResultDO.Location = new System.Drawing.Point(199, 100);
            this.lbResultDO.Name = "lbResultDO";
            this.lbResultDO.Size = new System.Drawing.Size(101, 14);
            this.lbResultDO.TabIndex = 0;
            this.lbResultDO.Text = "DO定时器脉冲输出";
            // 
            // lbParamEndTime
            // 
            this.lbParamEndTime.Location = new System.Drawing.Point(12, 20);
            this.lbParamEndTime.Name = "lbParamEndTime";
            this.lbParamEndTime.Size = new System.Drawing.Size(96, 14);
            this.lbParamEndTime.TabIndex = 0;
            this.lbParamEndTime.Text = "计时时间单位：秒";
            // 
            // spinInputPV
            // 
            this.spinInputPV.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinInputPV.Location = new System.Drawing.Point(115, 33);
            this.spinInputPV.Name = "spinInputPV";
            this.spinInputPV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinInputPV.Size = new System.Drawing.Size(70, 20);
            this.spinInputPV.TabIndex = 0;
            // 
            // lbParamMODE
            // 
            this.lbParamMODE.Location = new System.Drawing.Point(199, 20);
            this.lbParamMODE.Name = "lbParamMODE";
            this.lbParamMODE.Size = new System.Drawing.Size(48, 14);
            this.lbParamMODE.TabIndex = 0;
            this.lbParamMODE.Text = "工作方式";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.drpMode);
            this.groupControl1.Controls.Add(this.lbParamEndTime);
            this.groupControl1.Controls.Add(this.lbParamMODE);
            this.groupControl1.Controls.Add(this.spinParamEndTime);
            this.groupControl1.Location = new System.Drawing.Point(3, 135);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(359, 52);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "groupControl1";
            // 
            // drpMode
            // 
            this.drpMode.Location = new System.Drawing.Point(253, 17);
            this.drpMode.Name = "drpMode";
            this.drpMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpMode.Size = new System.Drawing.Size(98, 20);
            this.drpMode.TabIndex = 2;
            // 
            // CtrlParamTex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPid);
            this.Controls.Add(this.groupControl1);
            this.Name = "CtrlParamTex";
            this.Size = new System.Drawing.Size(364, 190);
            ((System.ComponentModel.ISupportInitialize)(this.spinParamEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputRS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputSet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputPV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpMode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit spinParamEndTime;
        private DevExpress.XtraEditors.LabelControl lbInputPV;
        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputRS;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputSet;
        private DevExpress.XtraEditors.LabelControl lbParamSET;
        private DevExpress.XtraEditors.LabelControl lbParamRS;
        private DevExpress.XtraEditors.LabelControl lbResultAO;
        private DevExpress.XtraEditors.LabelControl lbResultDO;
        private DevExpress.XtraEditors.LabelControl lbParamEndTime;
        private DevExpress.XtraEditors.SpinEdit spinInputPV;
        private DevExpress.XtraEditors.LabelControl lbParamMODE;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit drpMode;
    }
}