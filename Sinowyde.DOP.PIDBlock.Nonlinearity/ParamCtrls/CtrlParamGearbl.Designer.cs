namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    partial class CtrlParamGearbl
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
            this.txt_paramY = new DevExpress.XtraEditors.SpinEdit();
            this.gc_1 = new DevExpress.XtraEditors.GroupControl();
            this.txt_inputAI = new DevExpress.XtraEditors.SpinEdit();
            this.lbl_paramAI = new DevExpress.XtraEditors.LabelControl();
            this.lbl_outputAO = new DevExpress.XtraEditors.LabelControl();
            this.gc_2 = new DevExpress.XtraEditors.GroupControl();
            this.txt_paramG = new DevExpress.XtraEditors.SpinEdit();
            this.lbl_paramY = new DevExpress.XtraEditors.LabelControl();
            this.lbl_paramG = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).BeginInit();
            this.gc_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).BeginInit();
            this.gc_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_paramY
            // 
            this.txt_paramY.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_paramY.Location = new System.Drawing.Point(280, 5);
            this.txt_paramY.Name = "txt_paramY";
            this.txt_paramY.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramY.Size = new System.Drawing.Size(70, 20);
            this.txt_paramY.TabIndex = 3;
            this.txt_paramY.Tag = "paramY";
            // 
            // gc_1
            // 
            this.gc_1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gc_1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gc_1.Controls.Add(this.txt_inputAI);
            this.gc_1.Controls.Add(this.lbl_paramAI);
            this.gc_1.Controls.Add(this.lbl_outputAO);
            this.gc_1.Location = new System.Drawing.Point(2, 92);
            this.gc_1.Name = "gc_1";
            this.gc_1.Size = new System.Drawing.Size(360, 50);
            this.gc_1.TabIndex = 2;
            this.gc_1.Text = "输入输出变量说明及输入初值";
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
            // lbl_paramAI
            // 
            this.lbl_paramAI.Location = new System.Drawing.Point(10, 29);
            this.lbl_paramAI.Name = "lbl_paramAI";
            this.lbl_paramAI.Size = new System.Drawing.Size(84, 14);
            this.lbl_paramAI.TabIndex = 7;
            this.lbl_paramAI.Text = "模拟量输入AI：";
            // 
            // lbl_outputAO
            // 
            this.lbl_outputAO.Location = new System.Drawing.Point(233, 29);
            this.lbl_outputAO.Name = "lbl_outputAO";
            this.lbl_outputAO.Size = new System.Drawing.Size(89, 14);
            this.lbl_outputAO.TabIndex = 8;
            this.lbl_outputAO.Text = "模拟量输出：AO";
            // 
            // gc_2
            // 
            this.gc_2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gc_2.Controls.Add(this.txt_paramY);
            this.gc_2.Controls.Add(this.txt_paramG);
            this.gc_2.Controls.Add(this.lbl_paramY);
            this.gc_2.Controls.Add(this.lbl_paramG);
            this.gc_2.Location = new System.Drawing.Point(2, 144);
            this.gc_2.Name = "gc_2";
            this.gc_2.ShowCaption = false;
            this.gc_2.Size = new System.Drawing.Size(360, 30);
            this.gc_2.TabIndex = 3;
            // 
            // txt_paramG
            // 
            this.txt_paramG.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_paramG.Location = new System.Drawing.Point(91, 5);
            this.txt_paramG.Name = "txt_paramG";
            this.txt_paramG.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramG.Size = new System.Drawing.Size(70, 20);
            this.txt_paramG.TabIndex = 2;
            this.txt_paramG.Tag = "paramG";
            // 
            // lbl_paramY
            // 
            this.lbl_paramY.Location = new System.Drawing.Point(233, 8);
            this.lbl_paramY.Name = "lbl_paramY";
            this.lbl_paramY.Size = new System.Drawing.Size(44, 14);
            this.lbl_paramY.TabIndex = 8;
            this.lbl_paramY.Text = "输出Y：";
            // 
            // lbl_paramG
            // 
            this.lbl_paramG.Location = new System.Drawing.Point(10, 8);
            this.lbl_paramG.Name = "lbl_paramG";
            this.lbl_paramG.Size = new System.Drawing.Size(44, 14);
            this.lbl_paramG.TabIndex = 7;
            this.lbl_paramG.Text = "间隙G：";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(360, 88);
            this.panelControl1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Image = global::Sinowyde.DOP.PIDBlock.Nonlinearity.Properties.Resources.nonlinearity_gearbl_explain;
            this.label1.Location = new System.Drawing.Point(120, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 80);
            this.label1.TabIndex = 0;
            // 
            // CtrlParamGearbl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gc_1);
            this.Controls.Add(this.gc_2);
            this.Name = "CtrlParamGearbl";
            this.Size = new System.Drawing.Size(364, 176);
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).EndInit();
            this.gc_1.ResumeLayout(false);
            this.gc_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).EndInit();
            this.gc_2.ResumeLayout(false);
            this.gc_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit txt_paramY;
        private DevExpress.XtraEditors.GroupControl gc_1;
        private DevExpress.XtraEditors.SpinEdit txt_inputAI;
        private DevExpress.XtraEditors.GroupControl gc_2;
        private DevExpress.XtraEditors.SpinEdit txt_paramG;
        private DevExpress.XtraEditors.LabelControl lbl_outputAO;
        private DevExpress.XtraEditors.LabelControl lbl_paramAI;
        private DevExpress.XtraEditors.LabelControl lbl_paramY;
        private DevExpress.XtraEditors.LabelControl lbl_paramG;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
    }
}
