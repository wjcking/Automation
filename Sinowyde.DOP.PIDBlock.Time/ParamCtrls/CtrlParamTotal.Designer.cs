 
namespace Sinowyde.DOP.PIDBlock.Time 
{
    partial class CtrlParamTotal
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
            this.lbInputAI = new DevExpress.XtraEditors.LabelControl();
            this.spinInputAI = new DevExpress.XtraEditors.SpinEdit();
            this.lbParamIV = new DevExpress.XtraEditors.LabelControl();
            this.lbParamLV = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.drpInputSet = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbInputSET = new DevExpress.XtraEditors.LabelControl();
            this.spinInit = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbParamMODE = new DevExpress.XtraEditors.LabelControl();
            this.drpMode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.spinK = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputSet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinK.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbInputAI
            // 
            this.lbInputAI.Location = new System.Drawing.Point(15, 38);
            this.lbInputAI.Name = "lbInputAI";
            this.lbInputAI.Size = new System.Drawing.Size(52, 14);
            this.lbInputAI.TabIndex = 0;
            this.lbInputAI.Text = "AI:输入值";
            // 
            // spinInputAI
            // 
            this.spinInputAI.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinInputAI.Location = new System.Drawing.Point(114, 35);
            this.spinInputAI.Name = "spinInputAI";
            this.spinInputAI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinInputAI.Size = new System.Drawing.Size(70, 20);
            this.spinInputAI.TabIndex = 1;
            // 
            // lbParamIV
            // 
            this.lbParamIV.Location = new System.Drawing.Point(15, 67);
            this.lbParamIV.Name = "lbParamIV";
            this.lbParamIV.Size = new System.Drawing.Size(52, 14);
            this.lbParamIV.TabIndex = 0;
            this.lbParamIV.Text = "IV:积算值";
            // 
            // lbParamLV
            // 
            this.lbParamLV.Location = new System.Drawing.Point(199, 67);
            this.lbParamLV.Name = "lbParamLV";
            this.lbParamLV.Size = new System.Drawing.Size(90, 14);
            this.lbParamLV.TabIndex = 0;
            this.lbParamLV.Text = "LV:上一次积算值";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.drpInputSet);
            this.groupPid.Controls.Add(this.lbInputSET);
            this.groupPid.Controls.Add(this.lbParamIV);
            this.groupPid.Controls.Add(this.lbInputAI);
            this.groupPid.Controls.Add(this.spinInputAI);
            this.groupPid.Controls.Add(this.lbParamLV);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 91);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // drpInputSet
            // 
            this.drpInputSet.EditValue = "1";
            this.drpInputSet.Location = new System.Drawing.Point(293, 35);
            this.drpInputSet.Name = "drpInputSet";
            this.drpInputSet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputSet.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputSet.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputSet.Size = new System.Drawing.Size(45, 20);
            this.drpInputSet.TabIndex = 21;
            // 
            // lbInputSET
            // 
            this.lbInputSET.Location = new System.Drawing.Point(199, 38);
            this.lbInputSET.Name = "lbInputSET";
            this.lbInputSET.Size = new System.Drawing.Size(74, 14);
            this.lbInputSET.TabIndex = 20;
            this.lbInputSET.Text = "SET:开关信号";
            // 
            // spinInit
            // 
            this.spinInit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinInit.Location = new System.Drawing.Point(114, 13);
            this.spinInit.Name = "spinInit";
            this.spinInit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinInit.Size = new System.Drawing.Size(70, 20);
            this.spinInit.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 19);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "积算初值";
            // 
            // lbParamMODE
            // 
            this.lbParamMODE.Location = new System.Drawing.Point(15, 42);
            this.lbParamMODE.Name = "lbParamMODE";
            this.lbParamMODE.Size = new System.Drawing.Size(48, 14);
            this.lbParamMODE.TabIndex = 0;
            this.lbParamMODE.Text = "计算方式";
            // 
            // drpMode
            // 
            this.drpMode.Location = new System.Drawing.Point(114, 39);
            this.drpMode.Name = "drpMode";
            this.drpMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpMode.Size = new System.Drawing.Size(70, 20);
            this.drpMode.TabIndex = 5;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.drpMode);
            this.groupControl1.Controls.Add(this.lbParamMODE);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.spinK);
            this.groupControl1.Controls.Add(this.spinInit);
            this.groupControl1.Location = new System.Drawing.Point(2, 99);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(359, 81);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "groupControl1";
            // 
            // spinK
            // 
            this.spinK.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinK.Location = new System.Drawing.Point(268, 13);
            this.spinK.Name = "spinK";
            this.spinK.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinK.Size = new System.Drawing.Size(70, 20);
            this.spinK.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(204, 16);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "转换系数";
            // 
            // CtrlParamTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamTotal";
            this.Size = new System.Drawing.Size(364, 184);
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputSet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinK.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbInputAI;
private DevExpress.XtraEditors.SpinEdit spinInputAI;
private DevExpress.XtraEditors.LabelControl lbParamIV;
private DevExpress.XtraEditors.LabelControl lbParamLV;

private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputSet;
        private DevExpress.XtraEditors.LabelControl lbInputSET;
        private DevExpress.XtraEditors.SpinEdit spinInit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lbParamMODE;
        private DevExpress.XtraEditors.ComboBoxEdit drpMode;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit spinK;
    }
}