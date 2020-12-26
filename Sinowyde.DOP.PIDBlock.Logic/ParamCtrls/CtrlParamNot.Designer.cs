 
namespace Sinowyde.DOP.PIDBlock.Logic 
{
    partial class CtrlParamNot
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
            this.lbInputDI = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbResultDO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbInputDI
            // 
            this.lbInputDI.Location = new System.Drawing.Point(15, 27);
            this.lbInputDI.Name = "lbInputDI";
            this.lbInputDI.Size = new System.Drawing.Size(60, 14);
            this.lbInputDI.TabIndex = 0;
            this.lbInputDI.Text = "数字量输入";
            // 
            // drpInputDI
            // 
            this.drpInputDI.EditValue = "1";
            this.drpInputDI.Location = new System.Drawing.Point(110, 24);
            this.drpInputDI.Name = "drpInputDI";
            this.drpInputDI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI.TabIndex = 0;
            // 
            // lbResultDO
            // 
            this.lbResultDO.Location = new System.Drawing.Point(15, 47);
            this.lbResultDO.Name = "lbResultDO";
            this.lbResultDO.Size = new System.Drawing.Size(60, 14);
            this.lbResultDO.TabIndex = 0;
            this.lbResultDO.Text = "数字量输出";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputDI);
            this.groupPid.Controls.Add(this.drpInputDI);
            this.groupPid.Controls.Add(this.lbResultDO);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 70);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // CtrlParamNot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamNot";
            this.Size = new System.Drawing.Size(364, 74);
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbInputDI;
private DevExpress.XtraEditors.ComboBoxEdit drpInputDI;
private DevExpress.XtraEditors.LabelControl lbResultDO;

        private DevExpress.XtraEditors.GroupControl groupPid;
    }
}