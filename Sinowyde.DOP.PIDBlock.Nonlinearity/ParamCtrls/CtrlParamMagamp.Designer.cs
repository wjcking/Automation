namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    partial class CtrlParamMagamp
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
            this.gc_1 = new DevExpress.XtraEditors.GroupControl();
            this.lbl_outputAO = new DevExpress.XtraEditors.LabelControl();
            this.txt_inputAI = new DevExpress.XtraEditors.SpinEdit();
            this.lbl_inputAI = new DevExpress.XtraEditors.LabelControl();
            this.gc_2 = new DevExpress.XtraEditors.GroupControl();
            this.lbl_paramDead = new DevExpress.XtraEditors.LabelControl();
            this.lbl_paramY2 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_paramY1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_paramY2 = new DevExpress.XtraEditors.SpinEdit();
            this.txt_paramY1 = new DevExpress.XtraEditors.SpinEdit();
            this.txt_paramDead = new DevExpress.XtraEditors.SpinEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).BeginInit();
            this.gc_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).BeginInit();
            this.gc_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramY2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramY1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramDead.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gc_1
            // 
            this.gc_1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gc_1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gc_1.Controls.Add(this.lbl_outputAO);
            this.gc_1.Controls.Add(this.txt_inputAI);
            this.gc_1.Controls.Add(this.lbl_inputAI);
            this.gc_1.Location = new System.Drawing.Point(2, 92);
            this.gc_1.Name = "gc_1";
            this.gc_1.Size = new System.Drawing.Size(360, 50);
            this.gc_1.TabIndex = 4;
            this.gc_1.Text = "输入输出变量说明及输入初值";
            // 
            // lbl_outputAO
            // 
            this.lbl_outputAO.Location = new System.Drawing.Point(234, 29);
            this.lbl_outputAO.Name = "lbl_outputAO";
            this.lbl_outputAO.Size = new System.Drawing.Size(89, 14);
            this.lbl_outputAO.TabIndex = 9;
            this.lbl_outputAO.Text = "模拟量输出：AO";
            // 
            // txt_inputAI
            // 
            this.txt_inputAI.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_inputAI.Location = new System.Drawing.Point(91, 26);
            this.txt_inputAI.Name = "txt_inputAI";
            this.txt_inputAI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_inputAI.Size = new System.Drawing.Size(70, 20);
            this.txt_inputAI.TabIndex = 0;
            this.txt_inputAI.Tag = "inputAI";
            // 
            // lbl_inputAI
            // 
            this.lbl_inputAI.Location = new System.Drawing.Point(10, 29);
            this.lbl_inputAI.Name = "lbl_inputAI";
            this.lbl_inputAI.Size = new System.Drawing.Size(84, 14);
            this.lbl_inputAI.TabIndex = 8;
            this.lbl_inputAI.Text = "模拟量输入AI：";
            // 
            // gc_2
            // 
            this.gc_2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gc_2.Controls.Add(this.lbl_paramDead);
            this.gc_2.Controls.Add(this.lbl_paramY2);
            this.gc_2.Controls.Add(this.lbl_paramY1);
            this.gc_2.Controls.Add(this.txt_paramY2);
            this.gc_2.Controls.Add(this.txt_paramY1);
            this.gc_2.Controls.Add(this.txt_paramDead);
            this.gc_2.Location = new System.Drawing.Point(2, 144);
            this.gc_2.Name = "gc_2";
            this.gc_2.ShowCaption = false;
            this.gc_2.Size = new System.Drawing.Size(360, 60);
            this.gc_2.TabIndex = 5;
            // 
            // lbl_paramDead
            // 
            this.lbl_paramDead.Location = new System.Drawing.Point(10, 10);
            this.lbl_paramDead.Name = "lbl_paramDead";
            this.lbl_paramDead.Size = new System.Drawing.Size(56, 14);
            this.lbl_paramDead.TabIndex = 11;
            this.lbl_paramDead.Text = "死区值D：";
            // 
            // lbl_paramY2
            // 
            this.lbl_paramY2.Location = new System.Drawing.Point(234, 36);
            this.lbl_paramY2.Name = "lbl_paramY2";
            this.lbl_paramY2.Size = new System.Drawing.Size(44, 14);
            this.lbl_paramY2.TabIndex = 10;
            this.lbl_paramY2.Text = "输出Y：";
            // 
            // lbl_paramY1
            // 
            this.lbl_paramY1.Location = new System.Drawing.Point(10, 36);
            this.lbl_paramY1.Name = "lbl_paramY1";
            this.lbl_paramY1.Size = new System.Drawing.Size(57, 14);
            this.lbl_paramY1.TabIndex = 9;
            this.lbl_paramY1.Text = "磁放区M：";
            // 
            // txt_paramY2
            // 
            this.txt_paramY2.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_paramY2.Location = new System.Drawing.Point(280, 33);
            this.txt_paramY2.Name = "txt_paramY2";
            this.txt_paramY2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramY2.Size = new System.Drawing.Size(70, 20);
            this.txt_paramY2.TabIndex = 3;
            this.txt_paramY2.Tag = "paramY2";
            // 
            // txt_paramY1
            // 
            this.txt_paramY1.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_paramY1.Location = new System.Drawing.Point(91, 33);
            this.txt_paramY1.Name = "txt_paramY1";
            this.txt_paramY1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramY1.Size = new System.Drawing.Size(70, 20);
            this.txt_paramY1.TabIndex = 2;
            this.txt_paramY1.Tag = "paramY1";
            // 
            // txt_paramDead
            // 
            this.txt_paramDead.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_paramDead.Location = new System.Drawing.Point(91, 7);
            this.txt_paramDead.Name = "txt_paramDead";
            this.txt_paramDead.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramDead.Size = new System.Drawing.Size(70, 20);
            this.txt_paramDead.TabIndex = 1;
            this.txt_paramDead.Tag = "paramDead";
            // 
            // label1
            // 
            this.label1.Image = global::Sinowyde.DOP.PIDBlock.Nonlinearity.Properties.Resources.nonlinearity_magamp_explain;
            this.label1.Location = new System.Drawing.Point(114, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 80);
            this.label1.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(360, 88);
            this.panelControl1.TabIndex = 8;
            // 
            // CtrlParamMagamp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gc_1);
            this.Controls.Add(this.gc_2);
            this.Name = "CtrlParamMagamp";
            this.Size = new System.Drawing.Size(364, 206);
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).EndInit();
            this.gc_1.ResumeLayout(false);
            this.gc_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).EndInit();
            this.gc_2.ResumeLayout(false);
            this.gc_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramY2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramY1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramDead.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gc_1;
        private DevExpress.XtraEditors.SpinEdit txt_inputAI;
        private DevExpress.XtraEditors.GroupControl gc_2;
        private DevExpress.XtraEditors.SpinEdit txt_paramY2;
        private DevExpress.XtraEditors.SpinEdit txt_paramY1;
        private DevExpress.XtraEditors.SpinEdit txt_paramDead;
        private DevExpress.XtraEditors.LabelControl lbl_outputAO;
        private DevExpress.XtraEditors.LabelControl lbl_inputAI;
        private DevExpress.XtraEditors.LabelControl lbl_paramDead;
        private DevExpress.XtraEditors.LabelControl lbl_paramY2;
        private DevExpress.XtraEditors.LabelControl lbl_paramY1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}
