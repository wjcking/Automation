namespace Sinowyde.ConsoleApplication
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panelControlTop = new DevExpress.XtraEditors.PanelControl();
            this.labelControlSoftName = new DevExpress.XtraEditors.LabelControl();
            this.dropDownButtonSoft = new DevExpress.XtraEditors.DropDownButton();
            this.simpleButtonClose = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonMaximizeBox = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonMinimizeBox = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTop)).BeginInit();
            this.panelControlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControlTop
            // 
            this.panelControlTop.Controls.Add(this.labelControlSoftName);
            this.panelControlTop.Controls.Add(this.dropDownButtonSoft);
            this.panelControlTop.Controls.Add(this.simpleButtonClose);
            this.panelControlTop.Controls.Add(this.simpleButtonMaximizeBox);
            this.panelControlTop.Controls.Add(this.simpleButtonMinimizeBox);
            this.panelControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlTop.Location = new System.Drawing.Point(0, 0);
            this.panelControlTop.Name = "panelControlTop";
            this.panelControlTop.Size = new System.Drawing.Size(860, 32);
            this.panelControlTop.TabIndex = 6;
            // 
            // labelControlSoftName
            // 
            this.labelControlSoftName.Location = new System.Drawing.Point(12, 9);
            this.labelControlSoftName.Name = "labelControlSoftName";
            this.labelControlSoftName.Size = new System.Drawing.Size(0, 14);
            this.labelControlSoftName.TabIndex = 3;
            // 
            // dropDownButtonSoft
            // 
            this.dropDownButtonSoft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dropDownButtonSoft.Location = new System.Drawing.Point(773, 1);
            this.dropDownButtonSoft.Name = "dropDownButtonSoft";
            this.dropDownButtonSoft.Size = new System.Drawing.Size(18, 30);
            this.dropDownButtonSoft.TabIndex = 2;
            this.dropDownButtonSoft.Text = "dropDownButton1";
            // 
            // simpleButtonClose
            // 
            this.simpleButtonClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonClose.Image")));
            this.simpleButtonClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonClose.Location = new System.Drawing.Point(834, 3);
            this.simpleButtonClose.Name = "simpleButtonClose";
            this.simpleButtonClose.Size = new System.Drawing.Size(30, 30);
            this.simpleButtonClose.TabIndex = 1;
            this.simpleButtonClose.Text = "simpleButton3";
            // 
            // simpleButtonMaximizeBox
            // 
            this.simpleButtonMaximizeBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButtonMaximizeBox.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonMaximizeBox.Image")));
            this.simpleButtonMaximizeBox.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonMaximizeBox.Location = new System.Drawing.Point(810, 3);
            this.simpleButtonMaximizeBox.Name = "simpleButtonMaximizeBox";
            this.simpleButtonMaximizeBox.Size = new System.Drawing.Size(30, 30);
            this.simpleButtonMaximizeBox.TabIndex = 1;
            this.simpleButtonMaximizeBox.Text = "simpleButton3";
            // 
            // simpleButtonMinimizeBox
            // 
            this.simpleButtonMinimizeBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.simpleButtonMinimizeBox.Image = ((System.Drawing.Image)(resources.GetObject("simpleButtonMinimizeBox.Image")));
            this.simpleButtonMinimizeBox.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButtonMinimizeBox.Location = new System.Drawing.Point(786, 3);
            this.simpleButtonMinimizeBox.Name = "simpleButtonMinimizeBox";
            this.simpleButtonMinimizeBox.Size = new System.Drawing.Size(30, 30);
            this.simpleButtonMinimizeBox.TabIndex = 1;
            this.simpleButtonMinimizeBox.Text = "simpleButton3";
            // 
            // panelControl
            // 
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 32);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(860, 469);
            this.panelControl.TabIndex = 7;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 501);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.panelControlTop);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlTop)).EndInit();
            this.panelControlTop.ResumeLayout(false);
            this.panelControlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl;
        private DevExpress.XtraEditors.PanelControl panelControlTop;
        private DevExpress.XtraEditors.SimpleButton simpleButtonMinimizeBox;
        private DevExpress.XtraEditors.SimpleButton simpleButtonClose;
        private DevExpress.XtraEditors.SimpleButton simpleButtonMaximizeBox;
        private DevExpress.XtraEditors.DropDownButton dropDownButtonSoft;
        private DevExpress.XtraEditors.LabelControl labelControlSoftName;
    }
}