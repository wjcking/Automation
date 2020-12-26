namespace Sinowyde.DOP.GraphicElement
{
    partial class frmViewDialog
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
            this.panelCtlDOColor = new DevExpress.XtraEditors.PanelControl();
            this.timer1 = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.panelCtlDOColor)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCtlDOColor
            // 
            this.panelCtlDOColor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelCtlDOColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCtlDOColor.Location = new System.Drawing.Point(0, 0);
            this.panelCtlDOColor.Name = "panelCtlDOColor";
            this.panelCtlDOColor.Size = new System.Drawing.Size(410, 279);
            this.panelCtlDOColor.TabIndex = 13;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmViewDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 279);
            this.Controls.Add(this.panelCtlDOColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(3, 4);
            this.Name = "frmViewDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmViewDialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmViewDialog_FormClosing);
            this.Load += new System.EventHandler(this.frmViewDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelCtlDOColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelCtlDOColor;
        private System.Windows.Forms.Timer timer1;

    }
}