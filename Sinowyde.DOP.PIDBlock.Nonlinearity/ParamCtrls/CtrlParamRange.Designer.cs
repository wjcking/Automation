namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    partial class CtrlParamRange
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
            this.txt_paramDL = new DevExpress.XtraEditors.SpinEdit();
            this.lbl_paramDL = new DevExpress.XtraEditors.LabelControl();
            this.txt_paramUL = new DevExpress.XtraEditors.SpinEdit();
            this.lbl_paramUL = new DevExpress.XtraEditors.LabelControl();
            this.lbl_outputAO = new DevExpress.XtraEditors.LabelControl();
            this.txt_inputAI = new DevExpress.XtraEditors.SpinEdit();
            this.lbl_inputAI = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).BeginInit();
            this.gc_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramDL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramUL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gc_1
            // 
            this.gc_1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gc_1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gc_1.Controls.Add(this.txt_paramDL);
            this.gc_1.Controls.Add(this.lbl_paramDL);
            this.gc_1.Controls.Add(this.txt_paramUL);
            this.gc_1.Controls.Add(this.lbl_paramUL);
            this.gc_1.Controls.Add(this.lbl_outputAO);
            this.gc_1.Controls.Add(this.txt_inputAI);
            this.gc_1.Controls.Add(this.lbl_inputAI);
            this.gc_1.Location = new System.Drawing.Point(2, 2);
            this.gc_1.Name = "gc_1";
            this.gc_1.Size = new System.Drawing.Size(360, 80);
            this.gc_1.TabIndex = 5;
            this.gc_1.Text = "输入输出变量说明及输入初值";
            // 
            // txt_paramDL
            // 
            this.txt_paramDL.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_paramDL.Location = new System.Drawing.Point(280, 52);
            this.txt_paramDL.Name = "txt_paramDL";
            this.txt_paramDL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramDL.Size = new System.Drawing.Size(70, 20);
            this.txt_paramDL.TabIndex = 12;
            this.txt_paramDL.Tag = "inputDL";
            // 
            // lbl_paramDL
            // 
            this.lbl_paramDL.Location = new System.Drawing.Point(203, 55);
            this.lbl_paramDL.Name = "lbl_paramDL";
            this.lbl_paramDL.Size = new System.Drawing.Size(74, 14);
            this.lbl_paramDL.TabIndex = 13;
            this.lbl_paramDL.Tag = "";
            this.lbl_paramDL.Text = "幅值下限DL：";
            // 
            // txt_paramUL
            // 
            this.txt_paramUL.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_paramUL.Location = new System.Drawing.Point(91, 53);
            this.txt_paramUL.Name = "txt_paramUL";
            this.txt_paramUL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramUL.Size = new System.Drawing.Size(70, 20);
            this.txt_paramUL.TabIndex = 10;
            this.txt_paramUL.Tag = "inputUL";
            // 
            // lbl_paramUL
            // 
            this.lbl_paramUL.Location = new System.Drawing.Point(10, 55);
            this.lbl_paramUL.Name = "lbl_paramUL";
            this.lbl_paramUL.Size = new System.Drawing.Size(74, 14);
            this.lbl_paramUL.TabIndex = 11;
            this.lbl_paramUL.Text = "幅值上限UL：";
            // 
            // lbl_outputAO
            // 
            this.lbl_outputAO.Location = new System.Drawing.Point(203, 29);
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
            // CtrlParamRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gc_1);
            this.Name = "CtrlParamRange";
            this.Size = new System.Drawing.Size(364, 84);
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).EndInit();
            this.gc_1.ResumeLayout(false);
            this.gc_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramDL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramUL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gc_1;
        private DevExpress.XtraEditors.LabelControl lbl_outputAO;
        private DevExpress.XtraEditors.SpinEdit txt_inputAI;
        private DevExpress.XtraEditors.LabelControl lbl_inputAI;
        private DevExpress.XtraEditors.SpinEdit txt_paramDL;
        private DevExpress.XtraEditors.LabelControl lbl_paramDL;
        private DevExpress.XtraEditors.SpinEdit txt_paramUL;
        private DevExpress.XtraEditors.LabelControl lbl_paramUL;
    }
}
