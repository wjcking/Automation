namespace Sinowyde.DOP.PIDBlock.Math
{
    partial class CtrlParamExp
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
            this.lbl_output = new DevExpress.XtraEditors.LabelControl();
            this.lbl_inputAI = new DevExpress.XtraEditors.LabelControl();
            this.txt_inputAI = new DevExpress.XtraEditors.SpinEdit();
            this.gc_2 = new DevExpress.XtraEditors.GroupControl();
            this.lbl_paramA = new DevExpress.XtraEditors.LabelControl();
            this.lbl_paramBias = new DevExpress.XtraEditors.LabelControl();
            this.lbl_paramK = new DevExpress.XtraEditors.LabelControl();
            this.txt_paramK = new DevExpress.XtraEditors.SpinEdit();
            this.txt_paramBias = new DevExpress.XtraEditors.SpinEdit();
            this.txt_D1 = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).BeginInit();
            this.gc_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).BeginInit();
            this.gc_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramBias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_D1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gc_1
            // 
            this.gc_1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gc_1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gc_1.Controls.Add(this.lbl_output);
            this.gc_1.Controls.Add(this.lbl_inputAI);
            this.gc_1.Controls.Add(this.txt_inputAI);
            this.gc_1.Location = new System.Drawing.Point(2, 2);
            this.gc_1.Name = "gc_1";
            this.gc_1.Size = new System.Drawing.Size(360, 52);
            this.gc_1.TabIndex = 6;
            this.gc_1.Text = "输入输出变量说明及输入初值";
            // 
            // lbl_output
            // 
            this.lbl_output.Location = new System.Drawing.Point(234, 32);
            this.lbl_output.Name = "lbl_output";
            this.lbl_output.Size = new System.Drawing.Size(60, 14);
            this.lbl_output.TabIndex = 6;
            this.lbl_output.Text = "模拟量输出";
            // 
            // lbl_inputAI
            // 
            this.lbl_inputAI.Location = new System.Drawing.Point(10, 29);
            this.lbl_inputAI.Name = "lbl_inputAI";
            this.lbl_inputAI.Size = new System.Drawing.Size(72, 14);
            this.lbl_inputAI.TabIndex = 5;
            this.lbl_inputAI.Text = "模拟量输入：";
            // 
            // txt_inputAI
            // 
            this.txt_inputAI.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_inputAI.Location = new System.Drawing.Point(83, 26);
            this.txt_inputAI.Name = "txt_inputAI";
            this.txt_inputAI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_inputAI.Properties.Mask.EditMask = "n2";
            this.txt_inputAI.Size = new System.Drawing.Size(70, 20);
            this.txt_inputAI.TabIndex = 0;
            this.txt_inputAI.Tag = "inputAI";
            // 
            // gc_2
            // 
            this.gc_2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gc_2.Controls.Add(this.lbl_paramA);
            this.gc_2.Controls.Add(this.lbl_paramBias);
            this.gc_2.Controls.Add(this.lbl_paramK);
            this.gc_2.Controls.Add(this.txt_paramK);
            this.gc_2.Controls.Add(this.txt_paramBias);
            this.gc_2.Controls.Add(this.txt_D1);
            this.gc_2.Location = new System.Drawing.Point(2, 56);
            this.gc_2.Name = "gc_2";
            this.gc_2.ShowCaption = false;
            this.gc_2.Size = new System.Drawing.Size(360, 56);
            this.gc_2.TabIndex = 7;
            // 
            // lbl_paramA
            // 
            this.lbl_paramA.Location = new System.Drawing.Point(10, 8);
            this.lbl_paramA.Name = "lbl_paramA";
            this.lbl_paramA.Size = new System.Drawing.Size(44, 14);
            this.lbl_paramA.TabIndex = 8;
            this.lbl_paramA.Text = "底数A：";
            // 
            // lbl_paramBias
            // 
            this.lbl_paramBias.Location = new System.Drawing.Point(10, 32);
            this.lbl_paramBias.Name = "lbl_paramBias";
            this.lbl_paramBias.Size = new System.Drawing.Size(56, 14);
            this.lbl_paramBias.TabIndex = 7;
            this.lbl_paramBias.Text = "偏置Bias：";
            // 
            // lbl_paramK
            // 
            this.lbl_paramK.Location = new System.Drawing.Point(234, 8);
            this.lbl_paramK.Name = "lbl_paramK";
            this.lbl_paramK.Size = new System.Drawing.Size(43, 14);
            this.lbl_paramK.TabIndex = 6;
            this.lbl_paramK.Text = "系数K：";
            // 
            // txt_paramK
            // 
            this.txt_paramK.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_paramK.Location = new System.Drawing.Point(280, 5);
            this.txt_paramK.Name = "txt_paramK";
            this.txt_paramK.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramK.Properties.Mask.EditMask = "n2";
            this.txt_paramK.Size = new System.Drawing.Size(70, 20);
            this.txt_paramK.TabIndex = 4;
            this.txt_paramK.Tag = "paramK";
            // 
            // txt_paramBias
            // 
            this.txt_paramBias.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_paramBias.Location = new System.Drawing.Point(83, 29);
            this.txt_paramBias.Name = "txt_paramBias";
            this.txt_paramBias.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramBias.Properties.Mask.EditMask = "n2";
            this.txt_paramBias.Size = new System.Drawing.Size(70, 20);
            this.txt_paramBias.TabIndex = 3;
            this.txt_paramBias.Tag = "paramBias";
            // 
            // txt_D1
            // 
            this.txt_D1.EditValue = new decimal(new int[] {
            2718,
            0,
            0,
            196608});
            this.txt_D1.Location = new System.Drawing.Point(83, 5);
            this.txt_D1.Name = "txt_D1";
            this.txt_D1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_D1.Properties.Mask.EditMask = "n3";
            this.txt_D1.Properties.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.txt_D1.Size = new System.Drawing.Size(70, 20);
            this.txt_D1.TabIndex = 2;
            this.txt_D1.Tag = "paramA";
            // 
            // CtrlParamExp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gc_1);
            this.Controls.Add(this.gc_2);
            this.Name = "CtrlParamExp";
            this.Size = new System.Drawing.Size(364, 113);
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).EndInit();
            this.gc_1.ResumeLayout(false);
            this.gc_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).EndInit();
            this.gc_2.ResumeLayout(false);
            this.gc_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramBias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_D1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gc_1;
        private DevExpress.XtraEditors.SpinEdit txt_inputAI;
        private DevExpress.XtraEditors.GroupControl gc_2;
        private DevExpress.XtraEditors.SpinEdit txt_paramBias;
        private DevExpress.XtraEditors.SpinEdit txt_D1;
        private DevExpress.XtraEditors.SpinEdit txt_paramK;
        private DevExpress.XtraEditors.LabelControl lbl_output;
        private DevExpress.XtraEditors.LabelControl lbl_inputAI;
        private DevExpress.XtraEditors.LabelControl lbl_paramA;
        private DevExpress.XtraEditors.LabelControl lbl_paramBias;
        private DevExpress.XtraEditors.LabelControl lbl_paramK;
    }
}
