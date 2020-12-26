 
namespace Sinowyde.DOP.PIDBlock.Linearity 
{
    partial class CtrlParamConst
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
            this.lbInputAI = new DevExpress.XtraEditors.LabelControl();
            this.spinInputAI = new DevExpress.XtraEditors.SpinEdit();
            this.lbResultAO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbParamK
            // 
            this.lbParamK.Location = new System.Drawing.Point(20, 8);
            this.lbParamK.Name = "lbParamK";
            this.lbParamK.Size = new System.Drawing.Size(59, 14);
            this.lbParamK.TabIndex = 0;
            this.lbParamK.Text = "K:常系数值";
            // 
            // spinParamK
            // 
            this.spinParamK.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamK.Location = new System.Drawing.Point(114, 5);
            this.spinParamK.Name = "spinParamK";
            this.spinParamK.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamK.Size = new System.Drawing.Size(70, 20);
            this.spinParamK.TabIndex = 0;
            // 
            // lbInputAI
            // 
            this.lbInputAI.Location = new System.Drawing.Point(20, 37);
            this.lbInputAI.Name = "lbInputAI";
            this.lbInputAI.Size = new System.Drawing.Size(88, 14);
            this.lbInputAI.TabIndex = 0;
            this.lbInputAI.Text = "AI:模拟量输入值";
            // 
            // spinInputAI
            // 
            this.spinInputAI.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinInputAI.Location = new System.Drawing.Point(114, 34);
            this.spinInputAI.Name = "spinInputAI";
            this.spinInputAI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinInputAI.Size = new System.Drawing.Size(70, 20);
            this.spinInputAI.TabIndex = 1;
            // 
            // lbResultAO
            // 
            this.lbResultAO.Location = new System.Drawing.Point(225, 37);
            this.lbResultAO.Name = "lbResultAO";
            this.lbResultAO.Size = new System.Drawing.Size(89, 14);
            this.lbResultAO.TabIndex = 0;
            this.lbResultAO.Text = "AO模拟量输出值";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputAI);
            this.groupPid.Controls.Add(this.spinInputAI);
            this.groupPid.Controls.Add(this.lbResultAO);
            this.groupPid.Location = new System.Drawing.Point(4, 123);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 65);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // groupControl1
            // 
            this.groupControl1.ContentImage = global::Sinowyde.DOP.PIDBlock.Linearity.Properties.Resources._const;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(358, 114);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "groupControl1";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.spinParamK);
            this.groupControl2.Controls.Add(this.lbParamK);
            this.groupControl2.Location = new System.Drawing.Point(4, 194);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(358, 38);
            this.groupControl2.TabIndex = 7;
            this.groupControl2.Text = "groupControl2";
            // 
            // CtrlParamConst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamConst";
            this.Size = new System.Drawing.Size(364, 235);
            ((System.ComponentModel.ISupportInitialize)(this.spinParamK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

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