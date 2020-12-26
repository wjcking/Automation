namespace Sinowyde.DOP.PIDBlock.Math
{
    partial class CtrlParamAbs
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
            this.txt_paramAI = new DevExpress.XtraEditors.SpinEdit();
            this.gc_top = new DevExpress.XtraEditors.GroupControl();
            this.lbl__paramAI = new DevExpress.XtraEditors.LabelControl();
            this.lbl_outputAO = new DevExpress.XtraEditors.LabelControl();
            this.txt_paramBias = new DevExpress.XtraEditors.SpinEdit();
            this.txt_paramK = new DevExpress.XtraEditors.SpinEdit();
            this.lbl_paramK = new DevExpress.XtraEditors.LabelControl();
            this.lbl_paramBias = new DevExpress.XtraEditors.LabelControl();
            this.gc_bottom = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_top)).BeginInit();
            this.gc_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramBias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_bottom)).BeginInit();
            this.gc_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_paramAI
            // 
            this.txt_paramAI.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_paramAI.Location = new System.Drawing.Point(83, 29);
            this.txt_paramAI.Name = "txt_paramAI";
            this.txt_paramAI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramAI.Properties.Mask.EditMask = "n2";
            this.txt_paramAI.Size = new System.Drawing.Size(70, 20);
            this.txt_paramAI.TabIndex = 2;
            this.txt_paramAI.Tag = "inputAI";
            // 
            // gc_top
            // 
            this.gc_top.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gc_top.Controls.Add(this.lbl__paramAI);
            this.gc_top.Controls.Add(this.lbl_outputAO);
            this.gc_top.Controls.Add(this.txt_paramAI);
            this.gc_top.Location = new System.Drawing.Point(2, 2);
            this.gc_top.Name = "gc_top";
            this.gc_top.Size = new System.Drawing.Size(360, 60);
            this.gc_top.TabIndex = 3;
            this.gc_top.Text = "输入输出变量说明及输入初值";
            // 
            // lbl__paramAI
            // 
            this.lbl__paramAI.Location = new System.Drawing.Point(10, 32);
            this.lbl__paramAI.Name = "lbl__paramAI";
            this.lbl__paramAI.Size = new System.Drawing.Size(72, 14);
            this.lbl__paramAI.TabIndex = 4;
            this.lbl__paramAI.Text = "模拟量输入：";
            // 
            // lbl_outputAO
            // 
            this.lbl_outputAO.Location = new System.Drawing.Point(221, 32);
            this.lbl_outputAO.Name = "lbl_outputAO";
            this.lbl_outputAO.Size = new System.Drawing.Size(60, 14);
            this.lbl_outputAO.TabIndex = 3;
            this.lbl_outputAO.Text = "模拟量输出";
            // 
            // txt_paramBias
            // 
            this.txt_paramBias.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_paramBias.Location = new System.Drawing.Point(280, 7);
            this.txt_paramBias.Name = "txt_paramBias";
            this.txt_paramBias.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramBias.Properties.Mask.EditMask = "n2";
            this.txt_paramBias.Size = new System.Drawing.Size(70, 20);
            this.txt_paramBias.TabIndex = 2;
            this.txt_paramBias.Tag = "paramBias";
            // 
            // txt_paramK
            // 
            this.txt_paramK.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_paramK.Location = new System.Drawing.Point(83, 7);
            this.txt_paramK.Name = "txt_paramK";
            this.txt_paramK.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramK.Size = new System.Drawing.Size(70, 20);
            this.txt_paramK.TabIndex = 3;
            this.txt_paramK.Tag = "paramK";
            // 
            // lbl_paramK
            // 
            this.lbl_paramK.Location = new System.Drawing.Point(10, 10);
            this.lbl_paramK.Name = "lbl_paramK";
            this.lbl_paramK.Size = new System.Drawing.Size(43, 14);
            this.lbl_paramK.TabIndex = 5;
            this.lbl_paramK.Text = "系数K：";
            // 
            // lbl_paramBias
            // 
            this.lbl_paramBias.Location = new System.Drawing.Point(221, 10);
            this.lbl_paramBias.Name = "lbl_paramBias";
            this.lbl_paramBias.Size = new System.Drawing.Size(56, 14);
            this.lbl_paramBias.TabIndex = 6;
            this.lbl_paramBias.Text = "偏置Bias：";
            // 
            // gc_bottom
            // 
            this.gc_bottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gc_bottom.Controls.Add(this.lbl_paramBias);
            this.gc_bottom.Controls.Add(this.lbl_paramK);
            this.gc_bottom.Controls.Add(this.txt_paramK);
            this.gc_bottom.Controls.Add(this.txt_paramBias);
            this.gc_bottom.Location = new System.Drawing.Point(2, 64);
            this.gc_bottom.Name = "gc_bottom";
            this.gc_bottom.ShowCaption = false;
            this.gc_bottom.Size = new System.Drawing.Size(360, 35);
            this.gc_bottom.TabIndex = 4;
            // 
            // CtrlParamAbs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gc_bottom);
            this.Controls.Add(this.gc_top);
            this.Name = "CtrlParamAbs";
            this.Size = new System.Drawing.Size(364, 100);
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_top)).EndInit();
            this.gc_top.ResumeLayout(false);
            this.gc_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramBias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_bottom)).EndInit();
            this.gc_bottom.ResumeLayout(false);
            this.gc_bottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit txt_paramAI;
        private DevExpress.XtraEditors.GroupControl gc_top;
        private DevExpress.XtraEditors.LabelControl lbl_outputAO;
        private DevExpress.XtraEditors.LabelControl lbl__paramAI;
        private DevExpress.XtraEditors.SpinEdit txt_paramBias;
        private DevExpress.XtraEditors.SpinEdit txt_paramK;
        private DevExpress.XtraEditors.LabelControl lbl_paramK;
        private DevExpress.XtraEditors.LabelControl lbl_paramBias;
        private DevExpress.XtraEditors.GroupControl gc_bottom;




    }
}
