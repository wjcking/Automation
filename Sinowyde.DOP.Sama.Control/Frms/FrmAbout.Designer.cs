namespace Sinowyde.DOP.Sama.Control.Frms
{
    partial class FrmAbout
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
            this.labelControlProductName = new DevExpress.XtraEditors.LabelControl();
            this.labelControlVersion = new DevExpress.XtraEditors.LabelControl();
            this.labelControlCopyright = new DevExpress.XtraEditors.LabelControl();
            this.labelControlCompanyName = new DevExpress.XtraEditors.LabelControl();
            this.labelControlDescription = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // labelControlProductName
            // 
            this.labelControlProductName.Location = new System.Drawing.Point(108, 24);
            this.labelControlProductName.Name = "labelControlProductName";
            this.labelControlProductName.Size = new System.Drawing.Size(86, 14);
            this.labelControlProductName.TabIndex = 0;
            this.labelControlProductName.Text = "ProductName：";
            // 
            // labelControlVersion
            // 
            this.labelControlVersion.Location = new System.Drawing.Point(108, 58);
            this.labelControlVersion.Name = "labelControlVersion";
            this.labelControlVersion.Size = new System.Drawing.Size(52, 14);
            this.labelControlVersion.TabIndex = 0;
            this.labelControlVersion.Text = "Version：";
            // 
            // labelControlCopyright
            // 
            this.labelControlCopyright.Location = new System.Drawing.Point(108, 92);
            this.labelControlCopyright.Name = "labelControlCopyright";
            this.labelControlCopyright.Size = new System.Drawing.Size(64, 14);
            this.labelControlCopyright.TabIndex = 0;
            this.labelControlCopyright.Text = "Copyright：";
            // 
            // labelControlCompanyName
            // 
            this.labelControlCompanyName.Location = new System.Drawing.Point(108, 126);
            this.labelControlCompanyName.Name = "labelControlCompanyName";
            this.labelControlCompanyName.Size = new System.Drawing.Size(93, 14);
            this.labelControlCompanyName.TabIndex = 0;
            this.labelControlCompanyName.Text = "CompanyName：";
            // 
            // labelControlDescription
            // 
            this.labelControlDescription.Location = new System.Drawing.Point(108, 160);
            this.labelControlDescription.Name = "labelControlDescription";
            this.labelControlDescription.Size = new System.Drawing.Size(72, 14);
            this.labelControlDescription.TabIndex = 0;
            this.labelControlDescription.Text = "Description：";
            // 
            // FrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 245);
            this.Controls.Add(this.labelControlDescription);
            this.Controls.Add(this.labelControlCompanyName);
            this.Controls.Add(this.labelControlCopyright);
            this.Controls.Add(this.labelControlVersion);
            this.Controls.Add(this.labelControlProductName);
            this.Name = "FrmAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmAbout";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControlProductName;
        private DevExpress.XtraEditors.LabelControl labelControlVersion;
        private DevExpress.XtraEditors.LabelControl labelControlCopyright;
        private DevExpress.XtraEditors.LabelControl labelControlCompanyName;
        private DevExpress.XtraEditors.LabelControl labelControlDescription;
    }
}