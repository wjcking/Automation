 
namespace Sinowyde.DOP.PIDBlock.Logic 
{
    partial class CtrlParamDTrigger
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
            this.lbInputSD = new DevExpress.XtraEditors.LabelControl();
            this.drpInputSD = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbInputRD = new DevExpress.XtraEditors.LabelControl();
            this.drpInputRD = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbInputCP = new DevExpress.XtraEditors.LabelControl();
            this.lbInputD = new DevExpress.XtraEditors.LabelControl();
            this.lbResult = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.drpInputD = new DevExpress.XtraEditors.ComboBoxEdit();
            this.drpInputCp = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ctrlEnumGroup1 = new Sinowyde.DOP.PIDBlock.UserCtrl.CtrlEnumGroup();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputSD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputRD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputCp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlEnumGroup1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbInputSD
            // 
            this.lbInputSD.Location = new System.Drawing.Point(184, 27);
            this.lbInputSD.Name = "lbInputSD";
            this.lbInputSD.Size = new System.Drawing.Size(78, 14);
            this.lbInputSD.TabIndex = 0;
            this.lbInputSD.Text = "Sd:重置输入：";
            // 
            // drpInputSD
            // 
            this.drpInputSD.EditValue = "1";
            this.drpInputSD.Location = new System.Drawing.Point(266, 24);
            this.drpInputSD.Name = "drpInputSD";
            this.drpInputSD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputSD.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputSD.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputSD.Size = new System.Drawing.Size(45, 20);
            this.drpInputSD.TabIndex = 1;
            // 
            // lbInputRD
            // 
            this.lbInputRD.Location = new System.Drawing.Point(14, 27);
            this.lbInputRD.Name = "lbInputRD";
            this.lbInputRD.Size = new System.Drawing.Size(78, 14);
            this.lbInputRD.TabIndex = 0;
            this.lbInputRD.Text = "Rd:预置输入：";
            // 
            // drpInputRD
            // 
            this.drpInputRD.EditValue = "1";
            this.drpInputRD.Location = new System.Drawing.Point(100, 24);
            this.drpInputRD.Name = "drpInputRD";
            this.drpInputRD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputRD.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputRD.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputRD.Size = new System.Drawing.Size(45, 20);
            this.drpInputRD.TabIndex = 2;
            // 
            // lbInputCP
            // 
            this.lbInputCP.Location = new System.Drawing.Point(14, 53);
            this.lbInputCP.Name = "lbInputCP";
            this.lbInputCP.Size = new System.Drawing.Size(78, 14);
            this.lbInputCP.TabIndex = 0;
            this.lbInputCP.Text = "Cp:时钟输入：";
            // 
            // lbInputD
            // 
            this.lbInputD.Location = new System.Drawing.Point(184, 53);
            this.lbInputD.Name = "lbInputD";
            this.lbInputD.Size = new System.Drawing.Size(72, 14);
            this.lbInputD.TabIndex = 0;
            this.lbInputD.Text = "D:数字输入：";
            // 
            // lbResult
            // 
            this.lbResult.Location = new System.Drawing.Point(14, 79);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(81, 14);
            this.lbResult.TabIndex = 0;
            this.lbResult.Text = "Q：数字量输出";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.drpInputD);
            this.groupPid.Controls.Add(this.drpInputCp);
            this.groupPid.Controls.Add(this.lbInputSD);
            this.groupPid.Controls.Add(this.drpInputSD);
            this.groupPid.Controls.Add(this.lbInputRD);
            this.groupPid.Controls.Add(this.drpInputRD);
            this.groupPid.Controls.Add(this.lbInputCP);
            this.groupPid.Controls.Add(this.lbInputD);
            this.groupPid.Controls.Add(this.lbResult);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 100);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // drpInputD
            // 
            this.drpInputD.EditValue = "1";
            this.drpInputD.Location = new System.Drawing.Point(266, 50);
            this.drpInputD.Name = "drpInputD";
            this.drpInputD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputD.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputD.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputD.Size = new System.Drawing.Size(45, 20);
            this.drpInputD.TabIndex = 4;
            // 
            // drpInputCp
            // 
            this.drpInputCp.EditValue = "1";
            this.drpInputCp.Location = new System.Drawing.Point(100, 50);
            this.drpInputCp.Name = "drpInputCp";
            this.drpInputCp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputCp.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputCp.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputCp.Size = new System.Drawing.Size(45, 20);
            this.drpInputCp.TabIndex = 3;
            // 
            // ctrlEnumGroup1
            // 
            this.ctrlEnumGroup1.EnumType = Sinowyde.DOP.PIDBlock.UserCtrl.GroupEnum.ETimer;
            this.ctrlEnumGroup1.Location = new System.Drawing.Point(2, 104);
            this.ctrlEnumGroup1.Name = "ctrlEnumGroup1";
            this.ctrlEnumGroup1.SelectedInteger = 1;
            this.ctrlEnumGroup1.SelectedItem = Sinowyde.DOP.PIDAlgorithm.Logic.TimerSenseType.Up;
            this.ctrlEnumGroup1.Size = new System.Drawing.Size(360, 80);
            this.ctrlEnumGroup1.TabIndex = 6;
            this.ctrlEnumGroup1.Text = "请选择时钟输入触发器边界";
            // 
            // CtrlParamDTrigger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlEnumGroup1);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamDTrigger";
            this.Size = new System.Drawing.Size(364, 186);
            ((System.ComponentModel.ISupportInitialize)(this.drpInputSD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputRD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputCp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlEnumGroup1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbInputSD;
private DevExpress.XtraEditors.ComboBoxEdit drpInputSD;
private DevExpress.XtraEditors.LabelControl lbInputRD;
private DevExpress.XtraEditors.ComboBoxEdit drpInputRD;
private DevExpress.XtraEditors.LabelControl lbInputCP;
private DevExpress.XtraEditors.LabelControl lbInputD;
private DevExpress.XtraEditors.LabelControl lbResult;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputD;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputCp;
        private UserCtrl.CtrlEnumGroup ctrlEnumGroup1;
    }
}