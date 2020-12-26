
namespace Sinowyde.DOP.PIDBlock.Logic
{
    partial class CtrlParamCounter
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
            this.lbInputDI1 = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbInputDI2 = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbParamMaxVal = new DevExpress.XtraEditors.LabelControl();
            this.spinParamMaxVal = new DevExpress.XtraEditors.SpinEdit();
            this.lbResultAO = new DevExpress.XtraEditors.LabelControl();
            this.lbResultDO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.ctrlEnumTimer = new Sinowyde.DOP.PIDBlock.UserCtrl.CtrlEnumGroup();
            this.ctrlEnumCounter = new Sinowyde.DOP.PIDBlock.UserCtrl.CtrlEnumGroup();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamMaxVal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlEnumTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlEnumCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // lbInputDI1
            // 
            this.lbInputDI1.Location = new System.Drawing.Point(13, 29);
            this.lbInputDI1.Name = "lbInputDI1";
            this.lbInputDI1.Size = new System.Drawing.Size(83, 14);
            this.lbInputDI1.TabIndex = 0;
            this.lbInputDI1.Text = "DI1:数字量输入";
            // 
            // drpInputDI1
            // 
            this.drpInputDI1.EditValue = "";
            this.drpInputDI1.Location = new System.Drawing.Point(123, 26);
            this.drpInputDI1.Name = "drpInputDI1";
            this.drpInputDI1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI1.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI1.Size = new System.Drawing.Size(47, 20);
            this.drpInputDI1.TabIndex = 0;
            // 
            // lbInputDI2
            // 
            this.lbInputDI2.Location = new System.Drawing.Point(191, 29);
            this.lbInputDI2.Name = "lbInputDI2";
            this.lbInputDI2.Size = new System.Drawing.Size(71, 14);
            this.lbInputDI2.TabIndex = 0;
            this.lbInputDI2.Text = "DI2:复位输入";
            // 
            // drpInputDI2
            // 
            this.drpInputDI2.EditValue = "1";
            this.drpInputDI2.Location = new System.Drawing.Point(282, 26);
            this.drpInputDI2.Name = "drpInputDI2";
            this.drpInputDI2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI2.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI2.Size = new System.Drawing.Size(53, 20);
            this.drpInputDI2.TabIndex = 1;
            // 
            // lbParamMaxVal
            // 
            this.lbParamMaxVal.Location = new System.Drawing.Point(22, 18);
            this.lbParamMaxVal.Name = "lbParamMaxVal";
            this.lbParamMaxVal.Size = new System.Drawing.Size(147, 14);
            this.lbParamMaxVal.TabIndex = 0;
            this.lbParamMaxVal.Text = "SetVal:最大计数次数设定值";
            // 
            // spinParamMaxVal
            // 
            this.spinParamMaxVal.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamMaxVal.Location = new System.Drawing.Point(291, 15);
            this.spinParamMaxVal.Name = "spinParamMaxVal";
            this.spinParamMaxVal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamMaxVal.Size = new System.Drawing.Size(53, 20);
            this.spinParamMaxVal.TabIndex = 3;
            // 
            // lbResultAO
            // 
            this.lbResultAO.Location = new System.Drawing.Point(13, 49);
            this.lbResultAO.Name = "lbResultAO";
            this.lbResultAO.Size = new System.Drawing.Size(89, 14);
            this.lbResultAO.TabIndex = 0;
            this.lbResultAO.Text = "AO输出结果名称";
            // 
            // lbResultDO
            // 
            this.lbResultDO.Location = new System.Drawing.Point(191, 49);
            this.lbResultDO.Name = "lbResultDO";
            this.lbResultDO.Size = new System.Drawing.Size(93, 14);
            this.lbResultDO.TabIndex = 0;
            this.lbResultDO.Text = "DO:计数终到标志";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputDI1);
            this.groupPid.Controls.Add(this.drpInputDI1);
            this.groupPid.Controls.Add(this.lbInputDI2);
            this.groupPid.Controls.Add(this.drpInputDI2);
            this.groupPid.Controls.Add(this.lbResultAO);
            this.groupPid.Controls.Add(this.lbResultDO);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 70);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.spinParamMaxVal);
            this.groupControl3.Controls.Add(this.lbParamMaxVal);
            this.groupControl3.Location = new System.Drawing.Point(2, 204);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.ShowCaption = false;
            this.groupControl3.Size = new System.Drawing.Size(360, 46);
            this.groupControl3.TabIndex = 8;
            this.groupControl3.Text = "最大计数次数设定值";
            // 
            // ctrlEnumTimer
            // 
            this.ctrlEnumTimer.EnumType = Sinowyde.DOP.PIDBlock.UserCtrl.GroupEnum.ETimer;
            this.ctrlEnumTimer.Location = new System.Drawing.Point(2, 74);
            this.ctrlEnumTimer.Name = "ctrlEnumTimer";
            this.ctrlEnumTimer.SelectedInteger = 1;
            this.ctrlEnumTimer.SelectedItem = Sinowyde.DOP.PIDAlgorithm.Logic.TimerSenseType.Up;
            this.ctrlEnumTimer.Size = new System.Drawing.Size(360, 66);
            this.ctrlEnumTimer.TabIndex = 9;
            this.ctrlEnumTimer.Tag = "timer";
            this.ctrlEnumTimer.Text = "请选择时钟输入触发器边界";
            // 
            // ctrlEnumCounter
            // 
            this.ctrlEnumCounter.EnumType = Sinowyde.DOP.PIDBlock.UserCtrl.GroupEnum.ECounter;
            this.ctrlEnumCounter.Location = new System.Drawing.Point(2, 142);
            this.ctrlEnumCounter.Name = "ctrlEnumCounter";
            this.ctrlEnumCounter.SelectedInteger = 1;
            this.ctrlEnumCounter.SelectedItem = true;
            this.ctrlEnumCounter.Size = new System.Drawing.Size(360, 60);
            this.ctrlEnumCounter.TabIndex = 10;
            this.ctrlEnumCounter.Text = "选择计数器记计方向";
            // 
            // CtrlParamCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlEnumCounter);
            this.Controls.Add(this.ctrlEnumTimer);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamCounter";
            this.Size = new System.Drawing.Size(364, 252);
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamMaxVal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlEnumTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlEnumCounter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbInputDI1;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputDI1;
        private DevExpress.XtraEditors.LabelControl lbInputDI2;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputDI2;
        private DevExpress.XtraEditors.LabelControl lbParamMaxVal;
        private DevExpress.XtraEditors.SpinEdit spinParamMaxVal;
        private DevExpress.XtraEditors.LabelControl lbResultAO;
        private DevExpress.XtraEditors.LabelControl lbResultDO;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private UserCtrl.CtrlEnumGroup ctrlEnumTimer;
        private UserCtrl.CtrlEnumGroup ctrlEnumCounter;
    }
}