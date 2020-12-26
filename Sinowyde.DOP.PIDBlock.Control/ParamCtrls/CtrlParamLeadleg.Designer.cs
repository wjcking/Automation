 
namespace Sinowyde.DOP.PIDBlock.Control 
{
    partial class CtrlParamLeadleg
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
            this.lbParamT1 = new DevExpress.XtraEditors.LabelControl();
            this.spinParamT1 = new DevExpress.XtraEditors.SpinEdit();
            this.lbParamT2 = new DevExpress.XtraEditors.LabelControl();
            this.spinParamT2 = new DevExpress.XtraEditors.SpinEdit();
            this.lbInputPV = new DevExpress.XtraEditors.LabelControl();
            this.lbResultAO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.spinInputPV = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamT1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamT2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputPV.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lbParamT1
            // 
            this.lbParamT1.Location = new System.Drawing.Point(12, 16);
            this.lbParamT1.Name = "lbParamT1";
            this.lbParamT1.Size = new System.Drawing.Size(91, 14);
            this.lbParamT1.TabIndex = 0;
            this.lbParamT1.Text = "T1:超前时间常数";
            // 
            // spinParamT1
            // 
            this.spinParamT1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamT1.Location = new System.Drawing.Point(132, 13);
            this.spinParamT1.Name = "spinParamT1";
            this.spinParamT1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamT1.Properties.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.spinParamT1.Size = new System.Drawing.Size(70, 20);
            this.spinParamT1.TabIndex = 0;
            // 
            // lbParamT2
            // 
            this.lbParamT2.Location = new System.Drawing.Point(12, 52);
            this.lbParamT2.Name = "lbParamT2";
            this.lbParamT2.Size = new System.Drawing.Size(91, 14);
            this.lbParamT2.TabIndex = 0;
            this.lbParamT2.Text = "T2:滞后时间常数";
            // 
            // spinParamT2
            // 
            this.spinParamT2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamT2.Location = new System.Drawing.Point(132, 46);
            this.spinParamT2.Name = "spinParamT2";
            this.spinParamT2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamT2.Properties.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.spinParamT2.Size = new System.Drawing.Size(70, 20);
            this.spinParamT2.TabIndex = 1;
            // 
            // lbInputPV
            // 
            this.lbInputPV.Location = new System.Drawing.Point(13, 42);
            this.lbInputPV.Name = "lbInputPV";
            this.lbInputPV.Size = new System.Drawing.Size(67, 14);
            this.lbInputPV.TabIndex = 0;
            this.lbInputPV.Text = "PV:过程变量";
            // 
            // lbResultAO
            // 
            this.lbResultAO.Location = new System.Drawing.Point(246, 42);
            this.lbResultAO.Name = "lbResultAO";
            this.lbResultAO.Size = new System.Drawing.Size(77, 14);
            this.lbResultAO.TabIndex = 0;
            this.lbResultAO.Text = "AO模拟量输出";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.spinInputPV);
            this.groupPid.Controls.Add(this.lbInputPV);
            this.groupPid.Controls.Add(this.lbResultAO);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 76);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.spinParamT2);
            this.groupControl1.Controls.Add(this.lbParamT2);
            this.groupControl1.Controls.Add(this.lbParamT1);
            this.groupControl1.Controls.Add(this.spinParamT1);
            this.groupControl1.Location = new System.Drawing.Point(3, 84);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(358, 80);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "groupControl1";
            // 
            // spinInputPV
            // 
            this.spinInputPV.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinInputPV.Location = new System.Drawing.Point(133, 39);
            this.spinInputPV.Name = "spinInputPV";
            this.spinInputPV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinInputPV.Properties.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.spinInputPV.Size = new System.Drawing.Size(70, 20);
            this.spinInputPV.TabIndex = 1;
            // 
            // CtrlParamLeadleg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamLeadleg";
            this.Size = new System.Drawing.Size(364, 168);
            ((System.ComponentModel.ISupportInitialize)(this.spinParamT1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamT2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputPV.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbParamT1;
private DevExpress.XtraEditors.SpinEdit spinParamT1;
private DevExpress.XtraEditors.LabelControl lbParamT2;
private DevExpress.XtraEditors.SpinEdit spinParamT2;
private DevExpress.XtraEditors.LabelControl lbInputPV;
private DevExpress.XtraEditors.LabelControl lbResultAO;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SpinEdit spinInputPV;
    }
}