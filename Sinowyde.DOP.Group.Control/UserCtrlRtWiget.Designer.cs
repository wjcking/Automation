namespace Sinowyde.DOP.Group.Control
{
    partial class UserCtrlRtWiget
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_VariableValue = new DevExpress.XtraEditors.LabelControl();
            this.lbl_Percentage = new DevExpress.XtraEditors.LabelControl();
            this.lbl_PercentageImage = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // lbl_VariableValue
            // 
            this.lbl_VariableValue.Location = new System.Drawing.Point(75, 6);
            this.lbl_VariableValue.Name = "lbl_VariableValue";
            this.lbl_VariableValue.Size = new System.Drawing.Size(39, 14);
            this.lbl_VariableValue.TabIndex = 0;
            this.lbl_VariableValue.Text = "100.00";
            this.lbl_VariableValue.ToolTipTitle = "当前值";
            // 
            // lbl_Percentage
            // 
            this.lbl_Percentage.Location = new System.Drawing.Point(69, 25);
            this.lbl_Percentage.Name = "lbl_Percentage";
            this.lbl_Percentage.Size = new System.Drawing.Size(45, 14);
            this.lbl_Percentage.TabIndex = 0;
            this.lbl_Percentage.Text = "+0.01%";
            this.lbl_Percentage.ToolTipTitle = "变化率";
            // 
            // lbl_PercentageImage
            // 
            this.lbl_PercentageImage.Appearance.Image = global::Sinowyde.DOP.Group.Control.Properties.Resources.up;
            this.lbl_PercentageImage.Location = new System.Drawing.Point(6, 25);
            this.lbl_PercentageImage.Name = "lbl_PercentageImage";
            this.lbl_PercentageImage.Size = new System.Drawing.Size(18, 14);
            this.lbl_PercentageImage.TabIndex = 0;
            // 
            // UserCtrlRtWiget
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_PercentageImage);
            this.Controls.Add(this.lbl_Percentage);
            this.Controls.Add(this.lbl_VariableValue);
            this.Name = "UserCtrlRtWiget";
            this.Size = new System.Drawing.Size(120, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbl_VariableValue;
        private DevExpress.XtraEditors.LabelControl lbl_Percentage;
        private DevExpress.XtraEditors.LabelControl lbl_PercentageImage;
    }
}
