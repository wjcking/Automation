 
namespace Sinowyde.DOP.PIDBlock.Control 
{
    partial class CtrlParamDms
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
            this.lbParamMA = new DevExpress.XtraEditors.LabelControl();
            this.lbInputPV = new DevExpress.XtraEditors.LabelControl();
            this.drpInputPV = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbInputSI = new DevExpress.XtraEditors.LabelControl();
            this.drpInputSI = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbResultDO = new DevExpress.XtraEditors.LabelControl();
            this.lbResultSO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.drpInpuSI = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.ctrlPointPicker1 = new Sinowyde.DOP.PIDBlock.UserCtrl.CtrlPointPicker();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btn0 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAuto = new DevExpress.XtraEditors.SimpleButton();
            this.btnMan = new DevExpress.XtraEditors.SimpleButton();
            this.btn1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamMO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputPV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputSI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInpuSI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbParamMO
            // 
            this.lbParamMO.Location = new System.Drawing.Point(16, 19);
            this.lbParamMO.Name = "lbParamMO";
            this.lbParamMO.Size = new System.Drawing.Size(80, 14);
            this.lbParamMO.TabIndex = 0;
            this.lbParamMO.Text = "MO:Man手动值";
            // 
            // spinParamMO
            // 
            this.spinParamMO.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamMO.Location = new System.Drawing.Point(102, 16);
            this.spinParamMO.Name = "spinParamMO";
            this.spinParamMO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamMO.Size = new System.Drawing.Size(70, 20);
            this.spinParamMO.TabIndex = 0;
            // 
            // lbParamMA
            // 
            this.lbParamMA.Location = new System.Drawing.Point(193, 19);
            this.lbParamMA.Name = "lbParamMA";
            this.lbParamMA.Size = new System.Drawing.Size(84, 14);
            this.lbParamMA.TabIndex = 0;
            this.lbParamMA.Text = "选择手自动方式";
            // 
            // lbInputPV
            // 
            this.lbInputPV.Location = new System.Drawing.Point(17, 41);
            this.lbInputPV.Name = "lbInputPV";
            this.lbInputPV.Size = new System.Drawing.Size(91, 14);
            this.lbInputPV.TabIndex = 0;
            this.lbInputPV.Text = "PV:过程变量输入";
            // 
            // drpInputPV
            // 
            this.drpInputPV.EditValue = "1";
            this.drpInputPV.Location = new System.Drawing.Point(128, 38);
            this.drpInputPV.Name = "drpInputPV";
            this.drpInputPV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputPV.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputPV.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputPV.Size = new System.Drawing.Size(45, 20);
            this.drpInputPV.TabIndex = 2;
            // 
            // lbInputSI
            // 
            this.lbInputSI.Location = new System.Drawing.Point(194, 41);
            this.lbInputSI.Name = "lbInputSI";
            this.lbInputSI.Size = new System.Drawing.Size(63, 14);
            this.lbInputSI.TabIndex = 0;
            this.lbInputSI.Text = "SI:切换输入";
            // 
            // drpInputSI
            // 
            this.drpInputSI.EditValue = "1";
            this.drpInputSI.Location = new System.Drawing.Point(299, 38);
            this.drpInputSI.Name = "drpInputSI";
            this.drpInputSI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputSI.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputSI.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputSI.Size = new System.Drawing.Size(45, 20);
            this.drpInputSI.TabIndex = 3;
            // 
            // lbResultDO
            // 
            this.lbResultDO.Location = new System.Drawing.Point(17, 79);
            this.lbResultDO.Name = "lbResultDO";
            this.lbResultDO.Size = new System.Drawing.Size(81, 14);
            this.lbResultDO.TabIndex = 0;
            this.lbResultDO.Text = "DO:数字量输出";
            // 
            // lbResultSO
            // 
            this.lbResultSO.Location = new System.Drawing.Point(194, 79);
            this.lbResultSO.Name = "lbResultSO";
            this.lbResultSO.Size = new System.Drawing.Size(64, 14);
            this.lbResultSO.TabIndex = 0;
            this.lbResultSO.Text = "SO状态指示";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputPV);
            this.groupPid.Controls.Add(this.drpInputPV);
            this.groupPid.Controls.Add(this.lbInputSI);
            this.groupPid.Controls.Add(this.drpInputSI);
            this.groupPid.Controls.Add(this.lbResultDO);
            this.groupPid.Controls.Add(this.lbResultSO);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 107);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.spinParamMO);
            this.groupControl1.Controls.Add(this.drpInpuSI);
            this.groupControl1.Controls.Add(this.lbParamMA);
            this.groupControl1.Controls.Add(this.lbParamMO);
            this.groupControl1.Location = new System.Drawing.Point(3, 115);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(358, 53);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "groupControl1";
            // 
            // drpInpuSI
            // 
            this.drpInpuSI.EditValue = "自动";
            this.drpInpuSI.Location = new System.Drawing.Point(283, 16);
            this.drpInpuSI.Name = "drpInpuSI";
            this.drpInpuSI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInpuSI.Properties.Items.AddRange(new object[] {
            "自动",
            "手动"});
            this.drpInpuSI.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInpuSI.Size = new System.Drawing.Size(60, 20);
            this.drpInpuSI.TabIndex = 2;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.ctrlPointPicker1);
            this.groupControl2.Controls.Add(this.radioGroup1);
            this.groupControl2.Location = new System.Drawing.Point(3, 174);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(358, 192);
            this.groupControl2.TabIndex = 7;
            this.groupControl2.Text = "请将PV、SI、DO、SO连接到逻辑量点上";
            // 
            // ctrlPointPicker1
            // 
            this.ctrlPointPicker1.InitDataType = Sinowyde.DOP.DataModel.VariableType.Unknown;
            this.ctrlPointPicker1.Location = new System.Drawing.Point(5, 58);
            this.ctrlPointPicker1.Name = "ctrlPointPicker1";
            this.ctrlPointPicker1.SelectedNumber = "";
            this.ctrlPointPicker1.Size = new System.Drawing.Size(348, 129);
            this.ctrlPointPicker1.TabIndex = 1;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(16, 25);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.radioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Columns = 4;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "PV"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "SI"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "DO"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "SO")});
            this.radioGroup1.Size = new System.Drawing.Size(327, 27);
            this.radioGroup1.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.btn1);
            this.groupControl3.Controls.Add(this.btn0);
            this.groupControl3.Controls.Add(this.btnAuto);
            this.groupControl3.Controls.Add(this.btnMan);
            this.groupControl3.Location = new System.Drawing.Point(4, 372);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(360, 66);
            this.groupControl3.TabIndex = 10;
            this.groupControl3.Text = "调试操作";
            // 
            // btn0
            // 
            this.btn0.Location = new System.Drawing.Point(177, 33);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(75, 23);
            this.btn0.TabIndex = 3;
            this.btn0.Text = "输出0";
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(96, 33);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 3;
            this.btnAuto.Text = "自动";
            // 
            // btnMan
            // 
            this.btnMan.Location = new System.Drawing.Point(15, 33);
            this.btnMan.Name = "btnMan";
            this.btnMan.Size = new System.Drawing.Size(75, 23);
            this.btnMan.TabIndex = 3;
            this.btnMan.Text = "手动";
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(258, 33);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 23);
            this.btn1.TabIndex = 3;
            this.btn1.Text = "输出1";
            // 
            // CtrlParamDms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamDms";
            this.Size = new System.Drawing.Size(364, 442);
            ((System.ComponentModel.ISupportInitialize)(this.spinParamMO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputPV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputSI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInpuSI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbParamMO;
private DevExpress.XtraEditors.SpinEdit spinParamMO;
private DevExpress.XtraEditors.LabelControl lbParamMA;
private DevExpress.XtraEditors.LabelControl lbInputPV;
private DevExpress.XtraEditors.ComboBoxEdit drpInputPV;
private DevExpress.XtraEditors.LabelControl lbInputSI;
private DevExpress.XtraEditors.ComboBoxEdit drpInputSI;
private DevExpress.XtraEditors.LabelControl lbResultDO;
private DevExpress.XtraEditors.LabelControl lbResultSO;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private UserCtrl.CtrlPointPicker ctrlPointPicker1;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.ComboBoxEdit drpInpuSI;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btn1;
        private DevExpress.XtraEditors.SimpleButton btn0;
        private DevExpress.XtraEditors.SimpleButton btnAuto;
        private DevExpress.XtraEditors.SimpleButton btnMan;
    }
}