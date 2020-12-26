 
namespace Sinowyde.DOP.PIDBlock.Choice 
{
    partial class CtrlParamMax
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
            this.lbInputAI1 = new DevExpress.XtraEditors.LabelControl();
            this.lbInputAI2 = new DevExpress.XtraEditors.LabelControl();
            this.lbInputAI3 = new DevExpress.XtraEditors.LabelControl();
            this.lbInputAI4 = new DevExpress.XtraEditors.LabelControl();
            this.lbResultAO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbInputAI1
            // 
            this.lbInputAI1.Location = new System.Drawing.Point(14, 27);
            this.lbInputAI1.Name = "lbInputAI1";
            this.lbInputAI1.Size = new System.Drawing.Size(91, 14);
            this.lbInputAI1.TabIndex = 0;
            this.lbInputAI1.Text = "AI1：模拟量输入";
            // 
            // lbInputAI2
            // 
            this.lbInputAI2.Location = new System.Drawing.Point(239, 27);
            this.lbInputAI2.Name = "lbInputAI2";
            this.lbInputAI2.Size = new System.Drawing.Size(91, 14);
            this.lbInputAI2.TabIndex = 0;
            this.lbInputAI2.Text = "AI2：模拟量输入";
            // 
            // lbInputAI3
            // 
            this.lbInputAI3.Location = new System.Drawing.Point(14, 49);
            this.lbInputAI3.Name = "lbInputAI3";
            this.lbInputAI3.Size = new System.Drawing.Size(91, 14);
            this.lbInputAI3.TabIndex = 0;
            this.lbInputAI3.Text = "AI3：模拟量输入";
            // 
            // lbInputAI4
            // 
            this.lbInputAI4.Location = new System.Drawing.Point(239, 49);
            this.lbInputAI4.Name = "lbInputAI4";
            this.lbInputAI4.Size = new System.Drawing.Size(91, 14);
            this.lbInputAI4.TabIndex = 0;
            this.lbInputAI4.Text = "AI4：模拟量输入";
            // 
            // lbResultAO
            // 
            this.lbResultAO.Location = new System.Drawing.Point(14, 71);
            this.lbResultAO.Name = "lbResultAO";
            this.lbResultAO.Size = new System.Drawing.Size(261, 14);
            this.lbResultAO.TabIndex = 0;
            this.lbResultAO.Text = "AO：模拟量输出，取AI1，AI2，AI3，AI4最大值";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.labelControl1);
            this.groupPid.Controls.Add(this.lbInputAI1);
            this.groupPid.Controls.Add(this.lbInputAI2);
            this.groupPid.Controls.Add(this.lbInputAI3);
            this.groupPid.Controls.Add(this.lbInputAI4);
            this.groupPid.Controls.Add(this.lbResultAO);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 117);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 93);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(156, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "注：悬空的输入不参与比较！";
            // 
            // CtrlParamMax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamMax";
            this.Size = new System.Drawing.Size(364, 121);
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbInputAI1;
        private DevExpress.XtraEditors.LabelControl lbInputAI2;
        private DevExpress.XtraEditors.LabelControl lbInputAI3;
        private DevExpress.XtraEditors.LabelControl lbInputAI4;
private DevExpress.XtraEditors.LabelControl lbResultAO;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}