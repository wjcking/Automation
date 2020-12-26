namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    partial class CtrlParamDead
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
            this.lbl_paramK = new DevExpress.XtraEditors.LabelControl();
            this.lbl_paramD2 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_paramD1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_paramD2 = new DevExpress.XtraEditors.SpinEdit();
            this.txt_D1 = new DevExpress.XtraEditors.SpinEdit();
            this.txt_paramK = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).BeginInit();
            this.gc_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).BeginInit();
            this.gc_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramD2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_D1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramK.Properties)).BeginInit();
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
            this.gc_1.Location = new System.Drawing.Point(2, 94);
            this.gc_1.Name = "gc_1";
            this.gc_1.Size = new System.Drawing.Size(360, 50);
            this.gc_1.TabIndex = 0;
            this.gc_1.Text = "输入输出变量说明及输入初值";
            // 
            // lbl_outputAO
            // 
            this.lbl_outputAO.Location = new System.Drawing.Point(199, 29);
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
            this.gc_2.Controls.Add(this.lbl_paramK);
            this.gc_2.Controls.Add(this.lbl_paramD2);
            this.gc_2.Controls.Add(this.lbl_paramD1);
            this.gc_2.Controls.Add(this.txt_paramD2);
            this.gc_2.Controls.Add(this.txt_D1);
            this.gc_2.Controls.Add(this.txt_paramK);
            this.gc_2.Location = new System.Drawing.Point(2, 146);
            this.gc_2.Name = "gc_2";
            this.gc_2.ShowCaption = false;
            this.gc_2.Size = new System.Drawing.Size(360, 60);
            this.gc_2.TabIndex = 1;
            // 
            // lbl_paramK
            // 
            this.lbl_paramK.Location = new System.Drawing.Point(10, 11);
            this.lbl_paramK.Name = "lbl_paramK";
            this.lbl_paramK.Size = new System.Drawing.Size(42, 14);
            this.lbl_paramK.TabIndex = 6;
            this.lbl_paramK.Text = "斜率k：";
            // 
            // lbl_paramD2
            // 
            this.lbl_paramD2.Location = new System.Drawing.Point(202, 36);
            this.lbl_paramD2.Name = "lbl_paramD2";
            this.lbl_paramD2.Size = new System.Drawing.Size(75, 14);
            this.lbl_paramD2.TabIndex = 5;
            this.lbl_paramD2.Text = "死区高值D2：";
            // 
            // lbl_paramD1
            // 
            this.lbl_paramD1.Location = new System.Drawing.Point(10, 36);
            this.lbl_paramD1.Name = "lbl_paramD1";
            this.lbl_paramD1.Size = new System.Drawing.Size(75, 14);
            this.lbl_paramD1.TabIndex = 4;
            this.lbl_paramD1.Text = "死区低值D1：";
            // 
            // txt_paramD2
            // 
            this.txt_paramD2.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_paramD2.Location = new System.Drawing.Point(280, 33);
            this.txt_paramD2.Name = "txt_paramD2";
            this.txt_paramD2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramD2.Size = new System.Drawing.Size(70, 20);
            this.txt_paramD2.TabIndex = 3;
            this.txt_paramD2.Tag = "paramD2";
            // 
            // txt_D1
            // 
            this.txt_D1.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txt_D1.Location = new System.Drawing.Point(91, 33);
            this.txt_D1.Name = "txt_D1";
            this.txt_D1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_D1.Size = new System.Drawing.Size(70, 20);
            this.txt_D1.TabIndex = 2;
            this.txt_D1.Tag = "paramD1";
            // 
            // txt_paramK
            // 
            this.txt_paramK.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_paramK.Location = new System.Drawing.Point(91, 8);
            this.txt_paramK.Name = "txt_paramK";
            this.txt_paramK.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramK.Size = new System.Drawing.Size(70, 20);
            this.txt_paramK.TabIndex = 1;
            this.txt_paramK.Tag = "paramK";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Image = global::Sinowyde.DOP.PIDBlock.Nonlinearity.Properties.Resources.nonlinearity_dead_explain;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(111, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(136, 80);
            this.labelControl1.TabIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(360, 90);
            this.panelControl1.TabIndex = 3;
            // 
            // CtrlParamDead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gc_2);
            this.Controls.Add(this.gc_1);
            this.Name = "CtrlParamDead";
            this.Size = new System.Drawing.Size(364, 208);
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).EndInit();
            this.gc_1.ResumeLayout(false);
            this.gc_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).EndInit();
            this.gc_2.ResumeLayout(false);
            this.gc_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramD2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_D1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gc_1;
        private DevExpress.XtraEditors.GroupControl gc_2;
        private DevExpress.XtraEditors.SpinEdit txt_inputAI;
        private DevExpress.XtraEditors.SpinEdit txt_paramD2;
        private DevExpress.XtraEditors.SpinEdit txt_D1;
        private DevExpress.XtraEditors.SpinEdit txt_paramK;
        private DevExpress.XtraEditors.LabelControl lbl_inputAI;
        private DevExpress.XtraEditors.LabelControl lbl_outputAO;
        private DevExpress.XtraEditors.LabelControl lbl_paramK;
        private DevExpress.XtraEditors.LabelControl lbl_paramD2;
        private DevExpress.XtraEditors.LabelControl lbl_paramD1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}
