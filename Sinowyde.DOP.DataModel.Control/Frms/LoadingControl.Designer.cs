namespace Sinowyde.DOP.DataModel.Control
{
    partial class LoadingControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingControl));
            this.lbl_loading = new System.Windows.Forms.Label();
            this.lbl_content = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // lbl_loading
            // 
            this.lbl_loading.Image = ((System.Drawing.Image)(resources.GetObject("lbl_loading.Image")));
            this.lbl_loading.Location = new System.Drawing.Point(23, 18);
            this.lbl_loading.Name = "lbl_loading";
            this.lbl_loading.Size = new System.Drawing.Size(43, 37);
            this.lbl_loading.TabIndex = 0;
            // 
            // lbl_content
            // 
            this.lbl_content.Location = new System.Drawing.Point(63, 29);
            this.lbl_content.Name = "lbl_content";
            this.lbl_content.Size = new System.Drawing.Size(161, 14);
            this.lbl_content.TabIndex = 1;
            this.lbl_content.Text = "正在导出，请稍后（1 / 100）";
            // 
            // LoadingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_content);
            this.Controls.Add(this.lbl_loading);
            this.Name = "LoadingControl";
            this.Size = new System.Drawing.Size(318, 73);
            this.Load += new System.EventHandler(this.LoadingControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_loading;
        private DevExpress.XtraEditors.LabelControl lbl_content;

    }
}
