
namespace Sinowyde.DOP.PIDBlock.Control
{
    partial class CtrlParamDsetpoint
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
            this.lbResultDO = new DevExpress.XtraEditors.LabelControl();
            this.lbParamMO = new DevExpress.XtraEditors.LabelControl();
            this.lbInputDI = new DevExpress.XtraEditors.LabelControl();
            this.drpInputDI = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.drpMode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btnOutput = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbResultDO
            // 
            this.lbResultDO.Location = new System.Drawing.Point(259, 42);
            this.lbResultDO.Name = "lbResultDO";
            this.lbResultDO.Size = new System.Drawing.Size(77, 14);
            this.lbResultDO.TabIndex = 0;
            this.lbResultDO.Text = "DO数字量输出";
            // 
            // lbParamMO
            // 
            this.lbParamMO.Location = new System.Drawing.Point(18, 18);
            this.lbParamMO.Name = "lbParamMO";
            this.lbParamMO.Size = new System.Drawing.Size(48, 14);
            this.lbParamMO.TabIndex = 0;
            this.lbParamMO.Text = "工作方式";
            // 
            // lbInputDI
            // 
            this.lbInputDI.Location = new System.Drawing.Point(18, 42);
            this.lbInputDI.Name = "lbInputDI";
            this.lbInputDI.Size = new System.Drawing.Size(76, 14);
            this.lbInputDI.TabIndex = 0;
            this.lbInputDI.Text = "DI:数字量输入";
            // 
            // drpInputDI
            // 
            this.drpInputDI.EditValue = "1";
            this.drpInputDI.Location = new System.Drawing.Point(147, 39);
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
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lbParamMO);
            this.groupControl1.Controls.Add(this.drpMode);
            this.groupControl1.Location = new System.Drawing.Point(1, 86);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(358, 53);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "groupControl1";
            // 
            // drpMode
            // 
            this.drpMode.EditValue = "";
            this.drpMode.Location = new System.Drawing.Point(107, 15);
            this.drpMode.Name = "drpMode";
            this.drpMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.drpMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.drpMode.Size = new System.Drawing.Size(85, 20);
            this.drpMode.TabIndex = 1;
            this.drpMode.SelectedIndexChanged += new System.EventHandler(this.drpMode_SelectedIndexChanged);
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputDI);
            this.groupPid.Controls.Add(this.drpInputDI);
            this.groupPid.Controls.Add(this.lbResultDO);
            this.groupPid.Location = new System.Drawing.Point(1, 3);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 77);
            this.groupPid.TabIndex = 10;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.btnOutput);
            this.groupControl3.Location = new System.Drawing.Point(1, 145);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(360, 63);
            this.groupControl3.TabIndex = 13;
            this.groupControl3.Text = "调试操作";
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(19, 24);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 29);
            this.btnOutput.TabIndex = 3;
            this.btnOutput.Text = "操作";
            this.btnOutput.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOutput_MouseDown);
            this.btnOutput.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnOutput_MouseUp);
            // 
            // CtrlParamDsetpoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamDsetpoint";
            this.Size = new System.Drawing.Size(364, 221);
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbResultDO;
        private DevExpress.XtraEditors.LabelControl lbParamMO;
        private DevExpress.XtraEditors.LabelControl lbInputDI;
        private DevExpress.XtraEditors.ComboBoxEdit drpInputDI;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.ComboBoxEdit drpMode;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btnOutput;
    }
}