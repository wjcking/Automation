 
namespace Sinowyde.DOP.PIDBlock.Linearity 
{
    partial class CtrlParamCtf1
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
            this.lbParamINIT = new DevExpress.XtraEditors.LabelControl();
            this.spinParamINIT = new DevExpress.XtraEditors.SpinEdit();
            this.lbInputAI = new DevExpress.XtraEditors.LabelControl();
            this.spinInputAI = new DevExpress.XtraEditors.SpinEdit();
            this.lbResultAO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtB = new DevExpress.XtraEditors.TextEdit();
            this.txtA = new DevExpress.XtraEditors.TextEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamINIT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbParamK
            // 
            this.lbParamK.Location = new System.Drawing.Point(19, 24);
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
            this.spinParamK.Location = new System.Drawing.Point(109, 21);
            this.spinParamK.Name = "spinParamK";
            this.spinParamK.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamK.Size = new System.Drawing.Size(70, 20);
            this.spinParamK.TabIndex = 0;
            // 
            // lbParamA
            // 
            this.lbParamA.Location = new System.Drawing.Point(19, 63);
            this.lbParamA.Name = "lbParamA";
            this.lbParamA.Size = new System.Drawing.Size(84, 14);
            this.lbParamA.TabIndex = 0;
            this.lbParamA.Text = "A:分子系数序列";
            // 
            // lbParamB
            // 
            this.lbParamB.Location = new System.Drawing.Point(19, 95);
            this.lbParamB.Name = "lbParamB";
            this.lbParamB.Size = new System.Drawing.Size(83, 14);
            this.lbParamB.TabIndex = 0;
            this.lbParamB.Text = "B:分母系数序列";
            // 
            // lbParamINIT
            // 
            this.lbParamINIT.Location = new System.Drawing.Point(202, 24);
            this.lbParamINIT.Name = "lbParamINIT";
            this.lbParamINIT.Size = new System.Drawing.Size(60, 14);
            this.lbParamINIT.TabIndex = 0;
            this.lbParamINIT.Text = "输出初始值";
            // 
            // spinParamINIT
            // 
            this.spinParamINIT.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamINIT.Location = new System.Drawing.Point(272, 21);
            this.spinParamINIT.Name = "spinParamINIT";
            this.spinParamINIT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamINIT.Size = new System.Drawing.Size(70, 20);
            this.spinParamINIT.TabIndex = 3;
            // 
            // lbInputAI
            // 
            this.lbInputAI.Location = new System.Drawing.Point(18, 42);
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
            this.spinInputAI.Location = new System.Drawing.Point(109, 39);
            this.spinInputAI.Name = "spinInputAI";
            this.spinInputAI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinInputAI.Size = new System.Drawing.Size(70, 20);
            this.spinInputAI.TabIndex = 4;
            // 
            // lbResultAO
            // 
            this.lbResultAO.Location = new System.Drawing.Point(220, 42);
            this.lbResultAO.Name = "lbResultAO";
            this.lbResultAO.Size = new System.Drawing.Size(53, 14);
            this.lbResultAO.TabIndex = 0;
            this.lbResultAO.Text = "AO输出值";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputAI);
            this.groupPid.Controls.Add(this.spinInputAI);
            this.groupPid.Controls.Add(this.lbResultAO);
            this.groupPid.Location = new System.Drawing.Point(4, 97);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 76);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtB);
            this.groupControl1.Controls.Add(this.txtA);
            this.groupControl1.Controls.Add(this.lbParamK);
            this.groupControl1.Controls.Add(this.lbParamA);
            this.groupControl1.Controls.Add(this.spinParamK);
            this.groupControl1.Controls.Add(this.spinParamINIT);
            this.groupControl1.Controls.Add(this.lbParamINIT);
            this.groupControl1.Controls.Add(this.lbParamB);
            this.groupControl1.Location = new System.Drawing.Point(4, 179);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(358, 128);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "groupControl1";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(108, 92);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(233, 20);
            this.txtB.TabIndex = 4;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(109, 60);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(233, 20);
            this.txtA.TabIndex = 4;
            // 
            // groupControl2
            // 
            this.groupControl2.Location = new System.Drawing.Point(3, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(358, 88);
            this.groupControl2.TabIndex = 8;
            this.groupControl2.Text = "groupControl2";
            // 
            // CtrlParamCtf1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamCtf1";
            this.Size = new System.Drawing.Size(364, 310);
            ((System.ComponentModel.ISupportInitialize)(this.spinParamK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamINIT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbParamK;
private DevExpress.XtraEditors.SpinEdit spinParamK;
private DevExpress.XtraEditors.LabelControl lbParamA;
private DevExpress.XtraEditors.LabelControl lbParamB;
private DevExpress.XtraEditors.LabelControl lbParamINIT;
private DevExpress.XtraEditors.SpinEdit spinParamINIT;
private DevExpress.XtraEditors.LabelControl lbInputAI;
private DevExpress.XtraEditors.SpinEdit spinInputAI;
private DevExpress.XtraEditors.LabelControl lbResultAO;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtA;
        private DevExpress.XtraEditors.TextEdit txtB;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}