 
namespace Sinowyde.DOP.PIDBlock.Time 
{
    partial class CtrlParamDelayon
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
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.lbInputDI = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lbParamDELAY = new DevExpress.XtraEditors.LabelControl();
            this.spinParamDELAY = new DevExpress.XtraEditors.SpinEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lbResultDO = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamDELAY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbResultDO);
            this.groupPid.Controls.Add(this.lbInputDI);
            this.groupPid.Controls.Add(this.drpInputDI);
            this.groupPid.Location = new System.Drawing.Point(1, 3);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 68);
            this.groupPid.TabIndex = 10;
            this.groupPid.Text = "�����������˵���������ֵ";
            // 
            // lbInputDI
            // 
            this.lbInputDI.Location = new System.Drawing.Point(13, 37);
            this.lbInputDI.Name = "lbInputDI";
            this.lbInputDI.Size = new System.Drawing.Size(76, 14);
            this.lbInputDI.TabIndex = 0;
            this.lbInputDI.Text = "DI:����������";
            // 
            // drpInputDI
            // 
            this.drpInputDI.EditValue = "1";
            this.drpInputDI.Location = new System.Drawing.Point(153, 34);
            this.drpInputDI.Name = "drpInputDI";
            this.drpInputDI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpInputDI.Properties.Items.AddRange(new object[] {
            "1",
            "0"});
            this.drpInputDI.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpInputDI.Size = new System.Drawing.Size(45, 20);
            this.drpInputDI.TabIndex = 1;
            // 
            // lbParamDELAY
            // 
            this.lbParamDELAY.Location = new System.Drawing.Point(13, 18);
            this.lbParamDELAY.Name = "lbParamDELAY";
            this.lbParamDELAY.Size = new System.Drawing.Size(89, 14);
            this.lbParamDELAY.TabIndex = 0;
            this.lbParamDELAY.Text = "DELAY:��ʱʱ��";
            // 
            // spinParamDELAY
            // 
            this.spinParamDELAY.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamDELAY.Location = new System.Drawing.Point(130, 15);
            this.spinParamDELAY.Name = "spinParamDELAY";
            this.spinParamDELAY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamDELAY.Properties.MaxValue = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.spinParamDELAY.Size = new System.Drawing.Size(70, 20);
            this.spinParamDELAY.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lbParamDELAY);
            this.groupControl1.Controls.Add(this.spinParamDELAY);
            this.groupControl1.Location = new System.Drawing.Point(1, 76);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(359, 52);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "groupControl1";
            // 
            // lbResultDO
            // 
            this.lbResultDO.Location = new System.Drawing.Point(246, 37);
            this.lbResultDO.Name = "lbResultDO";
            this.lbResultDO.Size = new System.Drawing.Size(81, 14);
            this.lbResultDO.TabIndex = 2;
            this.lbResultDO.Text = "DO:���������";
            // 
            // CtrlParamDelayon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPid);
            this.Controls.Add(this.groupControl1);
            this.Name = "CtrlParamDelayon";
            this.Size = new System.Drawing.Size(364, 131);
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamDELAY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.LabelControl lbInputDI;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputDI;
        private DevExpress.XtraEditors.LabelControl lbParamDELAY;
        private DevExpress.XtraEditors.SpinEdit spinParamDELAY;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lbResultDO;

    }
}