namespace Sinowyde.DOP.PIDBlock.Math
{
    partial class CtrlParamMult
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.lbl_paramK2 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_paramBias = new DevExpress.XtraEditors.LabelControl();
            this.lbl_paramK1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_paramBias = new DevExpress.XtraEditors.SpinEdit();
            this.txt_paramK2 = new DevExpress.XtraEditors.SpinEdit();
            this.txt_paramK1 = new DevExpress.XtraEditors.SpinEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lbl_output = new DevExpress.XtraEditors.LabelControl();
            this.lbl_inputAI2 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_inputAI1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_inputAI2 = new DevExpress.XtraEditors.SpinEdit();
            this.txt_inputAI1 = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramBias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramK2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramK1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl2.Controls.Add(this.lbl_paramK2);
            this.groupControl2.Controls.Add(this.lbl_paramBias);
            this.groupControl2.Controls.Add(this.lbl_paramK1);
            this.groupControl2.Controls.Add(this.txt_paramBias);
            this.groupControl2.Controls.Add(this.txt_paramK2);
            this.groupControl2.Controls.Add(this.txt_paramK1);
            this.groupControl2.Location = new System.Drawing.Point(2, 82);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(360, 65);
            this.groupControl2.TabIndex = 7;
            // 
            // lbl_paramK2
            // 
            this.lbl_paramK2.Location = new System.Drawing.Point(228, 12);
            this.lbl_paramK2.Name = "lbl_paramK2";
            this.lbl_paramK2.Size = new System.Drawing.Size(50, 14);
            this.lbl_paramK2.TabIndex = 14;
            this.lbl_paramK2.Text = "系数K2：";
            // 
            // lbl_paramBias
            // 
            this.lbl_paramBias.Location = new System.Drawing.Point(10, 40);
            this.lbl_paramBias.Name = "lbl_paramBias";
            this.lbl_paramBias.Size = new System.Drawing.Size(56, 14);
            this.lbl_paramBias.TabIndex = 13;
            this.lbl_paramBias.Text = "偏置Bias：";
            // 
            // lbl_paramK1
            // 
            this.lbl_paramK1.Location = new System.Drawing.Point(10, 12);
            this.lbl_paramK1.Name = "lbl_paramK1";
            this.lbl_paramK1.Size = new System.Drawing.Size(50, 14);
            this.lbl_paramK1.TabIndex = 12;
            this.lbl_paramK1.Text = "系数K1：";
            // 
            // txt_paramBias
            // 
            this.txt_paramBias.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_paramBias.Location = new System.Drawing.Point(83, 37);
            this.txt_paramBias.Name = "txt_paramBias";
            this.txt_paramBias.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramBias.Properties.Mask.EditMask = "n2";
            this.txt_paramBias.Size = new System.Drawing.Size(70, 20);
            this.txt_paramBias.TabIndex = 6;
            this.txt_paramBias.Tag = "paramBias";
            // 
            // txt_paramK2
            // 
            this.txt_paramK2.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_paramK2.Location = new System.Drawing.Point(280, 9);
            this.txt_paramK2.Name = "txt_paramK2";
            this.txt_paramK2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramK2.Properties.Mask.EditMask = "n2";
            this.txt_paramK2.Size = new System.Drawing.Size(70, 20);
            this.txt_paramK2.TabIndex = 5;
            this.txt_paramK2.Tag = "paramK2";
            // 
            // txt_paramK1
            // 
            this.txt_paramK1.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_paramK1.Location = new System.Drawing.Point(83, 9);
            this.txt_paramK1.Name = "txt_paramK1";
            this.txt_paramK1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramK1.Properties.Mask.EditMask = "n2";
            this.txt_paramK1.Size = new System.Drawing.Size(70, 20);
            this.txt_paramK1.TabIndex = 4;
            this.txt_paramK1.Tag = "paramK1";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.CausesValidation = false;
            this.groupControl1.Controls.Add(this.lbl_output);
            this.groupControl1.Controls.Add(this.lbl_inputAI2);
            this.groupControl1.Controls.Add(this.lbl_inputAI1);
            this.groupControl1.Controls.Add(this.txt_inputAI2);
            this.groupControl1.Controls.Add(this.txt_inputAI1);
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(360, 78);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "输入输出变量说明及输入初值";
            // 
            // lbl_output
            // 
            this.lbl_output.Location = new System.Drawing.Point(10, 54);
            this.lbl_output.Name = "lbl_output";
            this.lbl_output.Size = new System.Drawing.Size(89, 14);
            this.lbl_output.TabIndex = 20;
            this.lbl_output.Text = "模拟量输出：AO";
            // 
            // lbl_inputAI2
            // 
            this.lbl_inputAI2.Location = new System.Drawing.Point(223, 29);
            this.lbl_inputAI2.Name = "lbl_inputAI2";
            this.lbl_inputAI2.Size = new System.Drawing.Size(55, 14);
            this.lbl_inputAI2.TabIndex = 19;
            this.lbl_inputAI2.Text = "乘数AI2：";
            // 
            // lbl_inputAI1
            // 
            this.lbl_inputAI1.Location = new System.Drawing.Point(10, 29);
            this.lbl_inputAI1.Name = "lbl_inputAI1";
            this.lbl_inputAI1.Size = new System.Drawing.Size(67, 14);
            this.lbl_inputAI1.TabIndex = 18;
            this.lbl_inputAI1.Text = "被乘数AI1：";
            // 
            // txt_inputAI2
            // 
            this.txt_inputAI2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_inputAI2.Location = new System.Drawing.Point(280, 26);
            this.txt_inputAI2.Name = "txt_inputAI2";
            this.txt_inputAI2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_inputAI2.Properties.Mask.EditMask = "n2";
            this.txt_inputAI2.Size = new System.Drawing.Size(70, 20);
            this.txt_inputAI2.TabIndex = 13;
            this.txt_inputAI2.Tag = "inputAI2";
            // 
            // txt_inputAI1
            // 
            this.txt_inputAI1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_inputAI1.Location = new System.Drawing.Point(83, 26);
            this.txt_inputAI1.Name = "txt_inputAI1";
            this.txt_inputAI1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_inputAI1.Properties.Mask.EditMask = "n2";
            this.txt_inputAI1.Size = new System.Drawing.Size(70, 20);
            this.txt_inputAI1.TabIndex = 12;
            this.txt_inputAI1.Tag = "inputAI1";
            // 
            // CtrlParamMult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "CtrlParamMult";
            this.Size = new System.Drawing.Size(364, 149);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramBias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramK2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramK1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SpinEdit txt_paramBias;
        private DevExpress.XtraEditors.SpinEdit txt_paramK2;
        private DevExpress.XtraEditors.SpinEdit txt_paramK1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SpinEdit txt_inputAI2;
        private DevExpress.XtraEditors.SpinEdit txt_inputAI1;
        private DevExpress.XtraEditors.LabelControl lbl_paramK2;
        private DevExpress.XtraEditors.LabelControl lbl_paramBias;
        private DevExpress.XtraEditors.LabelControl lbl_paramK1;
        private DevExpress.XtraEditors.LabelControl lbl_output;
        private DevExpress.XtraEditors.LabelControl lbl_inputAI2;
        private DevExpress.XtraEditors.LabelControl lbl_inputAI1;
    }
}
