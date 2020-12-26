 
namespace Sinowyde.DOP.PIDBlock.Logic 
{
    partial class CtrlParamSign
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
            this.lbInputAI = new DevExpress.XtraEditors.LabelControl();
            this.spinInputAI = new DevExpress.XtraEditors.SpinEdit();
            this.lbResultDO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbInputAI
            // 
            this.lbInputAI.Location = new System.Drawing.Point(14, 27);
            this.lbInputAI.Name = "lbInputAI";
            this.lbInputAI.Size = new System.Drawing.Size(60, 14);
            this.lbInputAI.TabIndex = 0;
            this.lbInputAI.Text = "模拟量输入";
            // 
            // spinInputAI
            // 
            this.spinInputAI.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinInputAI.Location = new System.Drawing.Point(94, 24);
            this.spinInputAI.Name = "spinInputAI";
            this.spinInputAI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinInputAI.Size = new System.Drawing.Size(70, 20);
            this.spinInputAI.TabIndex = 0;
            // 
            // lbResultDO
            // 
            this.lbResultDO.Location = new System.Drawing.Point(211, 27);
            this.lbResultDO.Name = "lbResultDO";
            this.lbResultDO.Size = new System.Drawing.Size(60, 14);
            this.lbResultDO.TabIndex = 0;
            this.lbResultDO.Text = "数字量输出";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputAI);
            this.groupPid.Controls.Add(this.spinInputAI);
            this.groupPid.Controls.Add(this.lbResultDO);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 50);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // CtrlParamSign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamSign";
            this.Size = new System.Drawing.Size(364, 54);
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbInputAI;
private DevExpress.XtraEditors.SpinEdit spinInputAI;
private DevExpress.XtraEditors.LabelControl lbResultDO;

        private DevExpress.XtraEditors.GroupControl groupPid;
    }
}