namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    partial class CtrlParamSwitch
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
            this.lbl_paramY = new DevExpress.XtraEditors.LabelControl();
            this.lbl_paramD = new DevExpress.XtraEditors.LabelControl();
            this.txt_paramBias = new DevExpress.XtraEditors.SpinEdit();
            this.txt_paramY = new DevExpress.XtraEditors.SpinEdit();
            this.txt_paramD = new DevExpress.XtraEditors.SpinEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).BeginInit();
            this.gc_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).BeginInit();
            this.gc_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramBias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramD.Properties)).BeginInit();
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
            this.lbl_outputAO.Location = new System.Drawing.Point(233, 29);
            this.lbl_outputAO.Name = "lbl_outputAO";
            this.lbl_outputAO.Size = new System.Drawing.Size(89, 14);
            this.lbl_outputAO.TabIndex = 5;
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
            this.lbl_inputAI.TabIndex = 6;
            this.lbl_inputAI.Text = "模拟量输入AI：";
            // 
            // gc_2
            // 
            this.gc_2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gc_2.Controls.Add(this.lbl_paramDead);
            this.gc_2.Controls.Add(this.lbl_paramY);
            this.gc_2.Controls.Add(this.lbl_paramD);
            this.gc_2.Controls.Add(this.txt_paramBias);
            this.gc_2.Controls.Add(this.txt_paramY);
            this.gc_2.Controls.Add(this.txt_paramD);
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
            this.lbl_paramDead.Size = new System.Drawing.Size(80, 14);
            this.lbl_paramDead.TabIndex = 6;
            this.lbl_paramDead.Text = "输入偏置Bias：";
            // 
            // lbl_paramY
            // 
            this.lbl_paramY.Location = new System.Drawing.Point(233, 36);
            this.lbl_paramY.Name = "lbl_paramY";
            this.lbl_paramY.Size = new System.Drawing.Size(44, 14);
            this.lbl_paramY.TabIndex = 5;
            this.lbl_paramY.Text = "输出Y：";
            // 
            // lbl_paramD
            // 
            this.lbl_paramD.Location = new System.Drawing.Point(10, 36);
            this.lbl_paramD.Name = "lbl_paramD";
            this.lbl_paramD.Size = new System.Drawing.Size(68, 14);
            this.lbl_paramD.TabIndex = 4;
            this.lbl_paramD.Text = "死区宽度D：";
            // 
            // txt_paramBias
            // 
            this.txt_paramBias.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_paramBias.Location = new System.Drawing.Point(91, 7);
            this.txt_paramBias.Name = "txt_paramBias";
            this.txt_paramBias.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramBias.Size = new System.Drawing.Size(70, 20);
            this.txt_paramBias.TabIndex = 1;
            this.txt_paramBias.Tag = "paramBias";
            // 
            // txt_paramY
            // 
            this.txt_paramY.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_paramY.Location = new System.Drawing.Point(280, 33);
            this.txt_paramY.Name = "txt_paramY";
            this.txt_paramY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramY.Size = new System.Drawing.Size(70, 20);
            this.txt_paramY.TabIndex = 3;
            this.txt_paramY.Tag = "paramY";
            // 
            // txt_paramD
            // 
            this.txt_paramD.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_paramD.Location = new System.Drawing.Point(91, 33);
            this.txt_paramD.Name = "txt_paramD";
            this.txt_paramD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramD.Properties.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txt_paramD.Size = new System.Drawing.Size(70, 20);
            this.txt_paramD.TabIndex = 2;
            this.txt_paramD.Tag = "paramD";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(360, 88);
            this.panelControl1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Image = global::Sinowyde.DOP.PIDBlock.Nonlinearity.Properties.Resources.nonlinearity_switch_explain;
            this.label1.Location = new System.Drawing.Point(114, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 80);
            this.label1.TabIndex = 0;
            // 
            // CtrlParamSwitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gc_1);
            this.Controls.Add(this.gc_2);
            this.Name = "CtrlParamSwitch";
            this.Size = new System.Drawing.Size(364, 206);
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).EndInit();
            this.gc_1.ResumeLayout(false);
            this.gc_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).EndInit();
            this.gc_2.ResumeLayout(false);
            this.gc_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramBias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gc_1;
        private DevExpress.XtraEditors.LabelControl lbl_outputAO;
        private DevExpress.XtraEditors.SpinEdit txt_inputAI;
        private DevExpress.XtraEditors.LabelControl lbl_inputAI;
        private DevExpress.XtraEditors.GroupControl gc_2;
        private DevExpress.XtraEditors.LabelControl lbl_paramDead;
        private DevExpress.XtraEditors.LabelControl lbl_paramY;
        private DevExpress.XtraEditors.LabelControl lbl_paramD;
        private DevExpress.XtraEditors.SpinEdit txt_paramBias;
        private DevExpress.XtraEditors.SpinEdit txt_paramY;
        private DevExpress.XtraEditors.SpinEdit txt_paramD;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
    }
}
