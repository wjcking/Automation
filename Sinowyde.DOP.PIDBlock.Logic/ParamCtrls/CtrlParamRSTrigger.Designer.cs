 
namespace Sinowyde.DOP.PIDBlock.Logic 
{
    partial class CtrlParamRSTrigger
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
            this.lbInputRd = new DevExpress.XtraEditors.LabelControl();
            this.drpInputRd = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbInputSd = new DevExpress.XtraEditors.LabelControl();
            this.drpInputSd = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbResultQ = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputRd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputSd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbInputRd
            // 
            this.lbInputRd.Location = new System.Drawing.Point(15, 28);
            this.lbInputRd.Name = "lbInputRd";
            this.lbInputRd.Size = new System.Drawing.Size(66, 14);
            this.lbInputRd.TabIndex = 0;
            this.lbInputRd.Text = "Rd:复位输入";
            // 
            // drpInputRd
            // 
            this.drpInputRd.EditValue = "";
            this.drpInputRd.Location = new System.Drawing.Point(101, 25);
            this.drpInputRd.Name = "drpInputRd";
            this.drpInputRd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputRd.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputRd.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputRd.Size = new System.Drawing.Size(45, 20);
            this.drpInputRd.TabIndex = 0;
            // 
            // lbInputSd
            // 
            this.lbInputSd.Location = new System.Drawing.Point(208, 28);
            this.lbInputSd.Name = "lbInputSd";
            this.lbInputSd.Size = new System.Drawing.Size(66, 14);
            this.lbInputSd.TabIndex = 0;
            this.lbInputSd.Text = "Sd:置位输入";
            // 
            // drpInputSd
            // 
            this.drpInputSd.EditValue = "1";
            this.drpInputSd.Location = new System.Drawing.Point(292, 25);
            this.drpInputSd.Name = "drpInputSd";
            this.drpInputSd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputSd.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputSd.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputSd.Size = new System.Drawing.Size(45, 20);
            this.drpInputSd.TabIndex = 1;
            // 
            // lbResultQ
            // 
            this.lbResultQ.Location = new System.Drawing.Point(15, 52);
            this.lbResultQ.Name = "lbResultQ";
            this.lbResultQ.Size = new System.Drawing.Size(57, 14);
            this.lbResultQ.TabIndex = 0;
            this.lbResultQ.Text = "Q：输出值";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputRd);
            this.groupPid.Controls.Add(this.drpInputRd);
            this.groupPid.Controls.Add(this.lbInputSd);
            this.groupPid.Controls.Add(this.drpInputSd);
            this.groupPid.Controls.Add(this.lbResultQ);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 72);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明";
            // 
            // CtrlParamRSTrigger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamRSTrigger";
            this.Size = new System.Drawing.Size(364, 76);
            ((System.ComponentModel.ISupportInitialize)(this.drpInputRd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputSd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbInputRd;
private DevExpress.XtraEditors.ComboBoxEdit drpInputRd;
private DevExpress.XtraEditors.LabelControl lbInputSd;
private DevExpress.XtraEditors.ComboBoxEdit drpInputSd;
private DevExpress.XtraEditors.LabelControl lbResultQ;

        private DevExpress.XtraEditors.GroupControl groupPid;
    }
}