 
namespace Sinowyde.DOP.PIDBlock.Linearity 
{
    partial class CtrlParamDiff
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
            this.lbParamT = new DevExpress.XtraEditors.LabelControl();
            this.spinParamT = new DevExpress.XtraEditors.SpinEdit();
            this.lbParamK = new DevExpress.XtraEditors.LabelControl();
            this.spinParamK = new DevExpress.XtraEditors.SpinEdit();
            this.lbInputAI = new DevExpress.XtraEditors.LabelControl();
            this.spinInputAI = new DevExpress.XtraEditors.SpinEdit();
            this.lbResultAO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbParamT
            // 
            this.lbParamT.Location = new System.Drawing.Point(17, 20);
            this.lbParamT.Name = "lbParamT";
            this.lbParamT.Size = new System.Drawing.Size(60, 14);
            this.lbParamT.TabIndex = 0;
            this.lbParamT.Text = "T:时间常数";
            // 
            // spinParamT
            // 
            this.spinParamT.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamT.Location = new System.Drawing.Point(109, 17);
            this.spinParamT.Name = "spinParamT";
            this.spinParamT.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamT.Size = new System.Drawing.Size(70, 20);
            this.spinParamT.TabIndex = 0;
            // 
            // lbParamK
            // 
            this.lbParamK.Location = new System.Drawing.Point(201, 17);
            this.lbParamK.Name = "lbParamK";
            this.lbParamK.Size = new System.Drawing.Size(59, 14);
            this.lbParamK.TabIndex = 0;
            this.lbParamK.Text = "K:比例增益";
            // 
            // spinParamK
            // 
            this.spinParamK.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamK.Location = new System.Drawing.Point(266, 17);
            this.spinParamK.Name = "spinParamK";
            this.spinParamK.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamK.Size = new System.Drawing.Size(70, 20);
            this.spinParamK.TabIndex = 1;
            // 
            // lbInputAI
            // 
            this.lbInputAI.Location = new System.Drawing.Point(18, 40);
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
            this.spinInputAI.Location = new System.Drawing.Point(108, 37);
            this.spinInputAI.Name = "spinInputAI";
            this.spinInputAI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinInputAI.Size = new System.Drawing.Size(70, 20);
            this.spinInputAI.TabIndex = 3;
            // 
            // lbResultAO
            // 
            this.lbResultAO.Location = new System.Drawing.Point(200, 40);
            this.lbResultAO.Name = "lbResultAO";
            this.lbResultAO.Size = new System.Drawing.Size(81, 14);
            this.lbResultAO.TabIndex = 0;
            this.lbResultAO.Text = "AO 模拟量输出";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputAI);
            this.groupPid.Controls.Add(this.spinInputAI);
            this.groupPid.Controls.Add(this.lbResultAO);
            this.groupPid.Location = new System.Drawing.Point(4, 122);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 67);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.spinParamT);
            this.groupControl1.Controls.Add(this.lbParamT);
            this.groupControl1.Controls.Add(this.lbParamK);
            this.groupControl1.Controls.Add(this.spinParamK);
            this.groupControl1.Location = new System.Drawing.Point(3, 195);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(358, 51);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "groupControl1";
            // 
            // groupControl2
            // 
            this.groupControl2.ContentImage = global::Sinowyde.DOP.PIDBlock.Linearity.Properties.Resources.diff;
            this.groupControl2.Location = new System.Drawing.Point(3, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(358, 114);
            this.groupControl2.TabIndex = 9;
            this.groupControl2.Text = "groupControl2";
            // 
            // CtrlParamDiff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamDiff";
            this.Size = new System.Drawing.Size(364, 253);
            ((System.ComponentModel.ISupportInitialize)(this.spinParamT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbParamT;
private DevExpress.XtraEditors.SpinEdit spinParamT;
private DevExpress.XtraEditors.LabelControl lbParamK;
private DevExpress.XtraEditors.SpinEdit spinParamK;
private DevExpress.XtraEditors.LabelControl lbInputAI;
private DevExpress.XtraEditors.SpinEdit spinInputAI;
private DevExpress.XtraEditors.LabelControl lbResultAO;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
    }
}