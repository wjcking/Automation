 
namespace Sinowyde.DOP.PIDBlock.Logic 
{
    partial class CtrlParamComparer
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
            this.lbParamBD = new DevExpress.XtraEditors.LabelControl();
            this.spinParamBD = new DevExpress.XtraEditors.SpinEdit();
            this.lbInputAI1 = new DevExpress.XtraEditors.LabelControl();
            this.spinInputAI1 = new DevExpress.XtraEditors.SpinEdit();
            this.lbInputAI2 = new DevExpress.XtraEditors.LabelControl();
            this.spinInputAI2 = new DevExpress.XtraEditors.SpinEdit();
            this.lbResultDO = new DevExpress.XtraEditors.LabelControl();
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ctrlEnumComp = new Sinowyde.DOP.PIDBlock.UserCtrl.CtrlEnumGroup();
            ((System.ComponentModel.ISupportInitialize)(this.spinParamBD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlEnumComp)).BeginInit();
            this.SuspendLayout();
            // 
            // lbParamBD
            // 
            this.lbParamBD.Location = new System.Drawing.Point(15, 18);
            this.lbParamBD.Name = "lbParamBD";
            this.lbParamBD.Size = new System.Drawing.Size(67, 14);
            this.lbParamBD.TabIndex = 0;
            this.lbParamBD.Text = "BD:不灵敏带";
            // 
            // spinParamBD
            // 
            this.spinParamBD.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinParamBD.Location = new System.Drawing.Point(219, 15);
            this.spinParamBD.Name = "spinParamBD";
            this.spinParamBD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinParamBD.Size = new System.Drawing.Size(70, 20);
            this.spinParamBD.TabIndex = 1;
            // 
            // lbInputAI1
            // 
            this.lbInputAI1.Location = new System.Drawing.Point(16, 29);
            this.lbInputAI1.Name = "lbInputAI1";
            this.lbInputAI1.Size = new System.Drawing.Size(23, 14);
            this.lbInputAI1.TabIndex = 0;
            this.lbInputAI1.Text = "AI1:";
            // 
            // spinInputAI1
            // 
            this.spinInputAI1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinInputAI1.Location = new System.Drawing.Point(51, 26);
            this.spinInputAI1.Name = "spinInputAI1";
            this.spinInputAI1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinInputAI1.Size = new System.Drawing.Size(70, 20);
            this.spinInputAI1.TabIndex = 2;
            // 
            // lbInputAI2
            // 
            this.lbInputAI2.Location = new System.Drawing.Point(192, 29);
            this.lbInputAI2.Name = "lbInputAI2";
            this.lbInputAI2.Size = new System.Drawing.Size(23, 14);
            this.lbInputAI2.TabIndex = 0;
            this.lbInputAI2.Text = "AI2:";
            // 
            // spinInputAI2
            // 
            this.spinInputAI2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinInputAI2.Location = new System.Drawing.Point(221, 26);
            this.spinInputAI2.Name = "spinInputAI2";
            this.spinInputAI2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinInputAI2.Size = new System.Drawing.Size(70, 20);
            this.spinInputAI2.TabIndex = 3;
            // 
            // lbResultDO
            // 
            this.lbResultDO.Location = new System.Drawing.Point(16, 52);
            this.lbResultDO.Name = "lbResultDO";
            this.lbResultDO.Size = new System.Drawing.Size(89, 14);
            this.lbResultDO.TabIndex = 0;
            this.lbResultDO.Text = "DO：数字量输出";
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.lbInputAI1);
            this.groupPid.Controls.Add(this.spinInputAI1);
            this.groupPid.Controls.Add(this.lbInputAI2);
            this.groupPid.Controls.Add(this.spinInputAI2);
            this.groupPid.Controls.Add(this.lbResultDO);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 74);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "输入输出变量说明及输入初值";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.spinParamBD);
            this.groupControl1.Controls.Add(this.lbParamBD);
            this.groupControl1.Location = new System.Drawing.Point(2, 140);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(358, 48);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "groupControl1";
            // 
            // ctrlEnumComp
            // 
            this.ctrlEnumComp.EnumType = Sinowyde.DOP.PIDBlock.UserCtrl.GroupEnum.ECompare;
            this.ctrlEnumComp.Location = new System.Drawing.Point(2, 78);
            this.ctrlEnumComp.Name = "ctrlEnumComp";
            this.ctrlEnumComp.SelectedInteger = 1;
            this.ctrlEnumComp.SelectedItem = Sinowyde.DOP.PIDAlgorithm.Logic.FxEnum.Bigger;
            this.ctrlEnumComp.Size = new System.Drawing.Size(360, 60);
            this.ctrlEnumComp.TabIndex = 7;
            this.ctrlEnumComp.Text = "请选择比较类型";
            // 
            // CtrlParamComparer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlEnumComp);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamComparer";
            this.Size = new System.Drawing.Size(364, 192);
            ((System.ComponentModel.ISupportInitialize)(this.spinParamBD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinInputAI2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.groupPid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlEnumComp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbParamBD;
private DevExpress.XtraEditors.SpinEdit spinParamBD;
private DevExpress.XtraEditors.LabelControl lbInputAI1;
private DevExpress.XtraEditors.SpinEdit spinInputAI1;
private DevExpress.XtraEditors.LabelControl lbInputAI2;
private DevExpress.XtraEditors.SpinEdit spinInputAI2;
private DevExpress.XtraEditors.LabelControl lbResultDO;

        private DevExpress.XtraEditors.GroupControl groupPid;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private UserCtrl.CtrlEnumGroup ctrlEnumComp;
    }
}