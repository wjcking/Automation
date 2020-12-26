 
namespace Sinowyde.DOP.PIDBlock.Logic 
{
    partial class CtrlParamFirst
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
            this.lbInputRst = new DevExpress.XtraEditors.LabelControl();
            this.lbParamNum = new DevExpress.XtraEditors.LabelControl();
            this.spinParamNum = new DevExpress.XtraEditors.SpinEdit();
            this.lbInputDIArray = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbResultY = new DevExpress.XtraEditors.LabelControl();
            this.lbResultDO = new DevExpress.XtraEditors.LabelControl();
            this.lbResultFDO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI8 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.drpInputRst = new DevExpress.XtraEditors.ComboBoxEdit();
            this.drpInputDI7 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI6 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.drpInputDI5 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI4 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.drpInputDI3 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI2 = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI8.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputRst.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbInputRst
            // 
            this.lbInputRst.Location = new System.Drawing.Point(124, 117);
            this.lbInputRst.Name = "lbInputRst";
            this.lbInputRst.Size = new System.Drawing.Size(148, 14);
            this.lbInputRst.TabIndex = 0;
            this.lbInputRst.Text = "Rst:复位输入为1时允许复位";
            // 
            // lbParamNum
            // 
            this.lbParamNum.Location = new System.Drawing.Point(124, 139);
            this.lbParamNum.Name = "lbParamNum";
            this.lbParamNum.Size = new System.Drawing.Size(223, 14);
            this.lbParamNum.TabIndex = 0;
            this.lbParamNum.Text = "Num:当输入有>=Num个1时，DO输出为1";
            // 
            // spinParamNum
            // 
            this.spinParamNum.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamNum.Location = new System.Drawing.Point(57, 136);
            this.spinParamNum.Name = "spinParamNum";
            this.spinParamNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamNum.Size = new System.Drawing.Size(45, 20);
            this.spinParamNum.TabIndex = 0;
            // 
            // lbInputDIArray
            // 
            this.lbInputDIArray.Location = new System.Drawing.Point(16, 29);
            this.lbInputDIArray.Name = "lbInputDIArray";
            this.lbInputDIArray.Size = new System.Drawing.Size(23, 14);
            this.lbInputDIArray.TabIndex = 0;
            this.lbInputDIArray.Text = "DI1:";
            // 
            // drpInputDI1
            // 
            this.drpInputDI1.EditValue = "1";
            this.drpInputDI1.Location = new System.Drawing.Point(57, 26);
            this.drpInputDI1.Name = "drpInputDI1";
            this.drpInputDI1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI1.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI1.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI1.TabIndex = 1;
            // 
            // lbResultY
            // 
            this.lbResultY.Location = new System.Drawing.Point(16, 183);
            this.lbResultY.Name = "lbResultY";
            this.lbResultY.Size = new System.Drawing.Size(256, 28);
            this.lbResultY.TabIndex = 0;
            this.lbResultY.Text = "Y为0表示开关量无0到1变化；\r\n其他为输入第一个从0到1的开关量序号（1－8）";
            // 
            // lbResultDO
            // 
            this.lbResultDO.Location = new System.Drawing.Point(16, 161);
            this.lbResultDO.Name = "lbResultDO";
            this.lbResultDO.Size = new System.Drawing.Size(113, 14);
            this.lbResultDO.TabIndex = 0;
            this.lbResultDO.Text = "DO当前输入量或运算";
            // 
            // lbResultFDO
            // 
            this.lbResultFDO.Location = new System.Drawing.Point(16, 219);
            this.lbResultFDO.Name = "lbResultFDO";
            this.lbResultFDO.Size = new System.Drawing.Size(195, 28);
            this.lbResultFDO.TabIndex = 0;
            this.lbResultFDO.Text = "FDO0：输入开关量无0到1的变化1：\r\n输入开关量有0到1的变化";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.labelControl7);
            this.groupPid.Controls.Add(this.labelControl9);
            this.groupPid.Controls.Add(this.labelControl8);
            this.groupPid.Controls.Add(this.labelControl3);
            this.groupPid.Controls.Add(this.drpInputDI8);
            this.groupPid.Controls.Add(this.drpInputRst);
            this.groupPid.Controls.Add(this.drpInputDI7);
            this.groupPid.Controls.Add(this.labelControl6);
            this.groupPid.Controls.Add(this.labelControl2);
            this.groupPid.Controls.Add(this.drpInputDI6);
            this.groupPid.Controls.Add(this.drpInputDI5);
            this.groupPid.Controls.Add(this.labelControl5);
            this.groupPid.Controls.Add(this.labelControl1);
            this.groupPid.Controls.Add(this.drpInputDI4);
            this.groupPid.Controls.Add(this.drpInputDI3);
            this.groupPid.Controls.Add(this.lbInputRst);
            this.groupPid.Controls.Add(this.lbParamNum);
            this.groupPid.Controls.Add(this.spinParamNum);
            this.groupPid.Controls.Add(this.labelControl4);
            this.groupPid.Controls.Add(this.lbInputDIArray);
            this.groupPid.Controls.Add(this.drpInputDI2);
            this.groupPid.Controls.Add(this.drpInputDI1);
            this.groupPid.Controls.Add(this.lbResultY);
            this.groupPid.Controls.Add(this.lbResultDO);
            this.groupPid.Controls.Add(this.lbResultFDO);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 254);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(198, 95);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(23, 14);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "DI8:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(16, 139);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(29, 14);
            this.labelControl9.TabIndex = 6;
            this.labelControl9.Text = "Num:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(16, 117);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(21, 14);
            this.labelControl8.TabIndex = 6;
            this.labelControl8.Text = "Rst:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(16, 95);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(23, 14);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "DI7:";
            // 
            // drpInputDI8
            // 
            this.drpInputDI8.EditValue = "1";
            this.drpInputDI8.Location = new System.Drawing.Point(227, 92);
            this.drpInputDI8.Name = "drpInputDI8";
            this.drpInputDI8.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI8.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI8.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI8.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI8.TabIndex = 7;
            // 
            // drpInputRst
            // 
            this.drpInputRst.EditValue = "1";
            this.drpInputRst.Location = new System.Drawing.Point(57, 114);
            this.drpInputRst.Name = "drpInputRst";
            this.drpInputRst.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputRst.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputRst.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputRst.Size = new System.Drawing.Size(45, 20);
            this.drpInputRst.TabIndex = 7;
            // 
            // drpInputDI7
            // 
            this.drpInputDI7.EditValue = "1";
            this.drpInputDI7.Location = new System.Drawing.Point(57, 92);
            this.drpInputDI7.Name = "drpInputDI7";
            this.drpInputDI7.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI7.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI7.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI7.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI7.TabIndex = 7;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(198, 73);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(23, 14);
            this.labelControl6.TabIndex = 4;
            this.labelControl6.Text = "DI6:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(16, 73);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "DI5:";
            // 
            // drpInputDI6
            // 
            this.drpInputDI6.EditValue = "1";
            this.drpInputDI6.Location = new System.Drawing.Point(227, 70);
            this.drpInputDI6.Name = "drpInputDI6";
            this.drpInputDI6.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI6.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI6.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI6.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI6.TabIndex = 5;
            // 
            // drpInputDI5
            // 
            this.drpInputDI5.EditValue = "1";
            this.drpInputDI5.Location = new System.Drawing.Point(57, 70);
            this.drpInputDI5.Name = "drpInputDI5";
            this.drpInputDI5.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI5.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI5.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI5.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI5.TabIndex = 5;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(198, 51);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(23, 14);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "DI4:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(16, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(23, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "DI3:";
            // 
            // drpInputDI4
            // 
            this.drpInputDI4.EditValue = "1";
            this.drpInputDI4.Location = new System.Drawing.Point(227, 48);
            this.drpInputDI4.Name = "drpInputDI4";
            this.drpInputDI4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI4.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI4.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI4.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI4.TabIndex = 3;
            // 
            // drpInputDI3
            // 
            this.drpInputDI3.EditValue = "1";
            this.drpInputDI3.Location = new System.Drawing.Point(57, 48);
            this.drpInputDI3.Name = "drpInputDI3";
            this.drpInputDI3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI3.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI3.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI3.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI3.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(198, 29);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(23, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "DI2:";
            // 
            // drpInputDI2
            // 
            this.drpInputDI2.EditValue = "1";
            this.drpInputDI2.Location = new System.Drawing.Point(227, 26);
            this.drpInputDI2.Name = "drpInputDI2";
            this.drpInputDI2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI2.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI2.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI2.TabIndex = 1;
            // 
            // CtrlParamFirst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamFirst";
            this.Size = new System.Drawing.Size(364, 258);
            ((System.ComponentModel.ISupportInitialize)(this.spinParamNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI8.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputRst.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbInputRst;
private DevExpress.XtraEditors.LabelControl lbParamNum;
private DevExpress.XtraEditors.SpinEdit spinParamNum;
private DevExpress.XtraEditors.LabelControl lbInputDIArray;
private DevExpress.XtraEditors.ComboBoxEdit drpInputDI1;
private DevExpress.XtraEditors.LabelControl lbResultY;
private DevExpress.XtraEditors.LabelControl lbResultDO;
private DevExpress.XtraEditors.LabelControl lbResultFDO;

private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputDI7;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputDI5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputDI3;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputDI8;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputRst;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputDI6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputDI4;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputDI2;
    }
}