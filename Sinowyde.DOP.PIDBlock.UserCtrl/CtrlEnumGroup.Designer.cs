namespace Sinowyde.DOP.PIDBlock.UserCtrl
{
    partial class CtrlEnumGroup
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
            this.rdEnum = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.rdEnum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rdEnum
            // 
            this.rdEnum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdEnum.Location = new System.Drawing.Point(0, 0);
            this.rdEnum.Name = "rdEnum";
            this.rdEnum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.rdEnum.Properties.Appearance.Options.UseBackColor = true;
            this.rdEnum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rdEnum.Size = new System.Drawing.Size(100, 96);
            this.rdEnum.TabIndex = 0;
            // 
            // CtrlEnumGroup
            // 
            this.Size = new System.Drawing.Size(360, 80);
            ((System.ComponentModel.ISupportInitialize)(this.rdEnum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup rdEnum;

    }
}
