 
namespace Sinowyde.DOP.PIDBlock.Choice 
{
    partial class CtrlParamMed
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
            this.lbResultAO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbInputAI1
            // 
            this.lbInputAI1.Location = new System.Drawing.Point(17, 27);
            this.lbInputAI1.Name = "lbInputAI1";
            this.lbInputAI1.Size = new System.Drawing.Size(83, 14);
            this.lbInputAI1.TabIndex = 0;
            this.lbInputAI1.Text = "AI1:模拟量输入";
            // 
            // lbInputAI2
            // 
            this.lbInputAI2.Location = new System.Drawing.Point(255, 27);
            this.lbInputAI2.Name = "lbInputAI2";
            this.lbInputAI2.Size = new System.Drawing.Size(83, 14);
            this.lbInputAI2.TabIndex = 0;
            this.lbInputAI2.Text = "AI2:模拟量输入";
            // 
            // lbInputAI3
            // 
            this.lbInputAI3.Location = new System.Drawing.Point(17, 49);
            this.lbInputAI3.Name = "lbInputAI3";
            this.lbInputAI3.Size = new System.Drawing.Size(83, 14);
            this.lbInputAI3.TabIndex = 0;
            this.lbInputAI3.Text = "AI3:模拟量输入";
            // 
            // lbResultAO
            // 
            this.lbResultAO.Location = new System.Drawing.Point(17, 71);
            this.lbResultAO.Name = "lbResultAO";
            this.lbResultAO.Size = new System.Drawing.Size(222, 14);
            this.lbResultAO.TabIndex = 0;
            this.lbResultAO.Text = "AO：模拟输出,取AI1，AI2，AI3的中间值";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputAI1);
            this.groupPid.Controls.Add(this.lbInputAI2);
            this.groupPid.Controls.Add(this.lbInputAI3);
            this.groupPid.Controls.Add(this.lbResultAO);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 94);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明";
            // 
            // CtrlParamMed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamMed";
            this.Size = new System.Drawing.Size(364, 98);
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbInputAI1;
        private DevExpress.XtraEditors.LabelControl lbInputAI2;
        private DevExpress.XtraEditors.LabelControl lbInputAI3;
private DevExpress.XtraEditors.LabelControl lbResultAO;

        private DevExpress.XtraEditors.GroupControl groupPid;
    }
}