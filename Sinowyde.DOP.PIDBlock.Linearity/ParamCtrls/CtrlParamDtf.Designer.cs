 
namespace Sinowyde.DOP.PIDBlock.Linearity 
{
    partial class CtrlParamDtf
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
            this.lbParamK = new DevExpress.XtraEditors.LabelControl();
            this.spinParamK = new DevExpress.XtraEditors.SpinEdit();
            this.lbParamA = new DevExpress.XtraEditors.LabelControl();
            this.lbParamB = new DevExpress.XtraEditors.LabelControl();
            this.lbParamT = new DevExpress.XtraEditors.LabelControl();
            this.spinParamT = new DevExpress.XtraEditors.SpinEdit();
            this.lbParamINIT = new DevExpress.XtraEditors.LabelControl();
            this.spinParamINIT = new DevExpress.XtraEditors.SpinEdit();
            this.lbInputAI = new DevExpress.XtraEditors.LabelControl();
            this.spinInputAI = new DevExpress.XtraEditors.SpinEdit();
            this.lbResultAO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamINIT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbParamK
            // 
            this.lbParamK.Location = new System.Drawing.Point(17, 14);
            this.lbParamK.Name = "lbParamK";
            this.lbParamK.Size = new System.Drawing.Size(59, 14);
            this.lbParamK.TabIndex = 0;
            this.lbParamK.Text = "K:比例系数";
            // 
            // spinParamK
            // 
            this.spinParamK.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamK.Location = new System.Drawing.Point(105, 14);
            this.spinParamK.Name = "spinParamK";
            this.spinParamK.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamK.Size = new System.Drawing.Size(70, 20);
            this.spinParamK.TabIndex = 0;
            // 
            // lbParamA
            // 
            this.lbParamA.Location = new System.Drawing.Point(15, 82);
            this.lbParamA.Name = "lbParamA";
            this.lbParamA.Size = new System.Drawing.Size(84, 14);
            this.lbParamA.TabIndex = 0;
            this.lbParamA.Text = "A:分子系数序列";
            // 
            // lbParamB
            // 
            this.lbParamB.Location = new System.Drawing.Point(17, 111);
            this.lbParamB.Name = "lbParamB";
            this.lbParamB.Size = new System.Drawing.Size(83, 14);
            this.lbParamB.TabIndex = 0;
            this.lbParamB.Text = "B:分母系数序列";
            // 
            // lbParamT
            // 
            this.lbParamT.Location = new System.Drawing.Point(203, 14);
            this.lbParamT.Name = "lbParamT";
            this.lbParamT.Size = new System.Drawing.Size(60, 14);
            this.lbParamT.TabIndex = 0;
            this.lbParamT.Text = "T:采样时间";
            // 
            // spinParamT
            // 
            this.spinParamT.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamT.Location = new System.Drawing.Point(269, 14);
            this.spinParamT.Name = "spinParamT";
            this.spinParamT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamT.Size = new System.Drawing.Size(70, 20);
            this.spinParamT.TabIndex = 3;
            // 
            // lbParamINIT
            // 
            this.lbParamINIT.Location = new System.Drawing.Point(17, 46);
            this.lbParamINIT.Name = "lbParamINIT";
            this.lbParamINIT.Size = new System.Drawing.Size(88, 14);
            this.lbParamINIT.TabIndex = 0;
            this.lbParamINIT.Text = "INIT:输出初始值";
            // 
            // spinParamINIT
            // 
            this.spinParamINIT.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamINIT.Location = new System.Drawing.Point(105, 43);
            this.spinParamINIT.Name = "spinParamINIT";
            this.spinParamINIT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamINIT.Size = new System.Drawing.Size(70, 20);
            this.spinParamINIT.TabIndex = 4;
            // 
            // lbInputAI
            // 
            this.lbInputAI.Location = new System.Drawing.Point(19, 39);
            this.lbInputAI.Name = "lbInputAI";
            this.lbInputAI.Size = new System.Drawing.Size(76, 14);
            this.lbInputAI.TabIndex = 0;
            this.lbInputAI.Text = "AI:模拟量输入";
            // 
            // spinInputAI
            // 
            this.spinInputAI.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinInputAI.Location = new System.Drawing.Point(107, 36);
            this.spinInputAI.Name = "spinInputAI";
            this.spinInputAI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinInputAI.Size = new System.Drawing.Size(70, 20);
            this.spinInputAI.TabIndex = 5;
            // 
            // lbResultAO
            // 
            this.lbResultAO.Location = new System.Drawing.Point(226, 39);
            this.lbResultAO.Name = "lbResultAO";
            this.lbResultAO.Size = new System.Drawing.Size(93, 14);
            this.lbResultAO.TabIndex = 0;
            this.lbResultAO.Text = "AO:模拟量输出值";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputAI);
            this.groupPid.Controls.Add(this.spinInputAI);
            this.groupPid.Controls.Add(this.lbResultAO);
            this.groupPid.Location = new System.Drawing.Point(4, 123);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 69);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.textEdit2);
            this.groupControl2.Controls.Add(this.textEdit1);
            this.groupControl2.Controls.Add(this.lbParamK);
            this.groupControl2.Controls.Add(this.lbParamA);
            this.groupControl2.Controls.Add(this.spinParamK);
            this.groupControl2.Controls.Add(this.spinParamINIT);
            this.groupControl2.Controls.Add(this.lbParamINIT);
            this.groupControl2.Controls.Add(this.spinParamT);
            this.groupControl2.Controls.Add(this.lbParamB);
            this.groupControl2.Controls.Add(this.lbParamT);
            this.groupControl2.Location = new System.Drawing.Point(4, 198);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(358, 137);
            this.groupControl2.TabIndex = 9;
            this.groupControl2.Text = "groupControl2";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(105, 79);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(234, 20);
            this.textEdit1.TabIndex = 5;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(106, 108);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(234, 20);
            this.textEdit2.TabIndex = 5;
            // 
            // groupControl1
            // 
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(358, 114);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "groupControl1";
            // 
            // CtrlParamDtf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamDtf";
            this.Size = new System.Drawing.Size(364, 340);
            ((System.ComponentModel.ISupportInitialize)(this.spinParamK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamINIT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbParamK;
private DevExpress.XtraEditors.SpinEdit spinParamK;
private DevExpress.XtraEditors.LabelControl lbParamA;
private DevExpress.XtraEditors.LabelControl lbParamB;
private DevExpress.XtraEditors.LabelControl lbParamT;
private DevExpress.XtraEditors.SpinEdit spinParamT;
private DevExpress.XtraEditors.LabelControl lbParamINIT;
private DevExpress.XtraEditors.SpinEdit spinParamINIT;
private DevExpress.XtraEditors.LabelControl lbInputAI;
private DevExpress.XtraEditors.SpinEdit spinInputAI;
private DevExpress.XtraEditors.LabelControl lbResultAO;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}