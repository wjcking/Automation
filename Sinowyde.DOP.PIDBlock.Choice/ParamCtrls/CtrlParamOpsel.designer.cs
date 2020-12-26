 
namespace Sinowyde.DOP.PIDBlock.Choice 
{
    partial class CtrlParamOpsel
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
            this.lbInputAI = new DevExpress.XtraEditors.LabelControl();
            this.spinInputAI = new DevExpress.XtraEditors.SpinEdit();
            this.lbInputDI = new DevExpress.XtraEditors.LabelControl();
            this.lbParamK = new DevExpress.XtraEditors.LabelControl();
            this.spinParamK = new DevExpress.XtraEditors.SpinEdit();
            this.lbResultAO1 = new DevExpress.XtraEditors.LabelControl();
            this.lbResultAO2 = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.drpInputDI = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbInputAI
            // 
            this.lbInputAI.Location = new System.Drawing.Point(16, 28);
            this.lbInputAI.Name = "lbInputAI";
            this.lbInputAI.Size = new System.Drawing.Size(76, 14);
            this.lbInputAI.TabIndex = 0;
            this.lbInputAI.Text = "AI:模拟量输入";
            // 
            // spinInputAI
            // 
            this.spinInputAI.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinInputAI.Location = new System.Drawing.Point(109, 25);
            this.spinInputAI.Name = "spinInputAI";
            this.spinInputAI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinInputAI.Properties.Mask.EditMask = "f";
            this.spinInputAI.Size = new System.Drawing.Size(70, 20);
            this.spinInputAI.TabIndex = 0;
            // 
            // lbInputDI
            // 
            this.lbInputDI.Location = new System.Drawing.Point(197, 28);
            this.lbInputDI.Name = "lbInputDI";
            this.lbInputDI.Size = new System.Drawing.Size(76, 14);
            this.lbInputDI.TabIndex = 0;
            this.lbInputDI.Text = "DI:数字量输入";
            // 
            // lbParamK
            // 
            this.lbParamK.Location = new System.Drawing.Point(15, 9);
            this.lbParamK.Name = "lbParamK";
            this.lbParamK.Size = new System.Drawing.Size(59, 14);
            this.lbParamK.TabIndex = 0;
            this.lbParamK.Text = "K:切换速率";
            // 
            // spinParamK
            // 
            this.spinParamK.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamK.Location = new System.Drawing.Point(108, 6);
            this.spinParamK.Name = "spinParamK";
            this.spinParamK.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamK.Properties.Mask.EditMask = "f";
            this.spinParamK.Size = new System.Drawing.Size(70, 20);
            this.spinParamK.TabIndex = 2;
            // 
            // lbResultAO1
            // 
            this.lbResultAO1.Location = new System.Drawing.Point(16, 86);
            this.lbResultAO1.Name = "lbResultAO1";
            this.lbResultAO1.Size = new System.Drawing.Size(213, 14);
            this.lbResultAO1.TabIndex = 0;
            this.lbResultAO1.Text = "若 DI为假时， AO2=AI， AO1保持不变";
            // 
            // lbResultAO2
            // 
            this.lbResultAO2.Location = new System.Drawing.Point(16, 66);
            this.lbResultAO2.Name = "lbResultAO2";
            this.lbResultAO2.Size = new System.Drawing.Size(213, 14);
            this.lbResultAO2.TabIndex = 0;
            this.lbResultAO2.Text = "若 DI为真时， AO1=AI， AO2保持不变\r\n";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputAI);
            this.groupPid.Controls.Add(this.spinInputAI);
            this.groupPid.Controls.Add(this.lbInputDI);
            this.groupPid.Controls.Add(this.drpInputDI);
            this.groupPid.Controls.Add(this.lbResultAO1);
            this.groupPid.Controls.Add(this.labelControl1);
            this.groupPid.Controls.Add(this.lbResultAO2);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 106);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明";
            // 
            // drpInputDI
            // 
            this.drpInputDI.Location = new System.Drawing.Point(293, 25);
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
            this.groupControl1.Controls.Add(this.lbParamK);
            this.groupControl1.Controls.Add(this.spinParamK);
            this.groupControl1.Location = new System.Drawing.Point(2, 110);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(360, 32);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "groupControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(16, 48);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(144, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "AO1，AO2：模拟量输出值";
            // 
            // CtrlParamOpsel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamOpsel";
            this.Size = new System.Drawing.Size(364, 146);
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInputDI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbInputAI;
private DevExpress.XtraEditors.SpinEdit spinInputAI;
private DevExpress.XtraEditors.LabelControl lbInputDI;
private DevExpress.XtraEditors.ComboBoxEdit drpInputDI;
private DevExpress.XtraEditors.LabelControl lbParamK;
private DevExpress.XtraEditors.SpinEdit spinParamK;
private DevExpress.XtraEditors.LabelControl lbResultAO1;
private DevExpress.XtraEditors.LabelControl lbResultAO2;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}