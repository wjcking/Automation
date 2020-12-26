namespace Sinowyde.DOP.PIDBlock.Nonlinearity
{
    partial class CtrlParamRatioAlm
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
            this.lbl_paramLow = new DevExpress.XtraEditors.LabelControl();
            this.lbl_paramHigh = new DevExpress.XtraEditors.LabelControl();
            this.txt_paramDead = new DevExpress.XtraEditors.SpinEdit();
            this.txt_paramLow = new DevExpress.XtraEditors.SpinEdit();
            this.txt_paramHigh = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).BeginInit();
            this.gc_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).BeginInit();
            this.gc_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramDead.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramLow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramHigh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gc_1
            // 
            this.gc_1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gc_1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gc_1.Controls.Add(this.lbl_outputAO);
            this.gc_1.Controls.Add(this.txt_inputAI);
            this.gc_1.Controls.Add(this.lbl_inputAI);
            this.gc_1.Location = new System.Drawing.Point(2, 2);
            this.gc_1.Name = "gc_1";
            this.gc_1.Size = new System.Drawing.Size(360, 50);
            this.gc_1.TabIndex = 4;
            this.gc_1.Text = "输入输出变量说明及输入初值";
            // 
            // lbl_outputAO
            // 
            this.lbl_outputAO.Location = new System.Drawing.Point(217, 29);
            this.lbl_outputAO.Name = "lbl_outputAO";
            this.lbl_outputAO.Size = new System.Drawing.Size(89, 14);
            this.lbl_outputAO.TabIndex = 5;
            this.lbl_outputAO.Text = "数字量输出：DO";
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
            this.gc_2.Controls.Add(this.lbl_paramLow);
            this.gc_2.Controls.Add(this.lbl_paramHigh);
            this.gc_2.Controls.Add(this.txt_paramDead);
            this.gc_2.Controls.Add(this.txt_paramLow);
            this.gc_2.Controls.Add(this.txt_paramHigh);
            this.gc_2.Location = new System.Drawing.Point(2, 54);
            this.gc_2.Name = "gc_2";
            this.gc_2.ShowCaption = false;
            this.gc_2.Size = new System.Drawing.Size(360, 60);
            this.gc_2.TabIndex = 5;
            // 
            // lbl_paramDead
            // 
            this.lbl_paramDead.Location = new System.Drawing.Point(10, 10);
            this.lbl_paramDead.Name = "lbl_paramDead";
            this.lbl_paramDead.Size = new System.Drawing.Size(60, 14);
            this.lbl_paramDead.TabIndex = 6;
            this.lbl_paramDead.Text = "报警死区：";
            // 
            // lbl_paramLow
            // 
            this.lbl_paramLow.Location = new System.Drawing.Point(217, 36);
            this.lbl_paramLow.Name = "lbl_paramLow";
            this.lbl_paramLow.Size = new System.Drawing.Size(60, 14);
            this.lbl_paramLow.TabIndex = 5;
            this.lbl_paramLow.Text = "报警下限：";
            // 
            // lbl_paramHigh
            // 
            this.lbl_paramHigh.Location = new System.Drawing.Point(10, 36);
            this.lbl_paramHigh.Name = "lbl_paramHigh";
            this.lbl_paramHigh.Size = new System.Drawing.Size(60, 14);
            this.lbl_paramHigh.TabIndex = 4;
            this.lbl_paramHigh.Text = "报警上限：";
            // 
            // txt_paramDead
            // 
            this.txt_paramDead.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_paramDead.Location = new System.Drawing.Point(91, 7);
            this.txt_paramDead.Name = "txt_paramDead";
            this.txt_paramDead.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramDead.Properties.MaxValue = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.txt_paramDead.Size = new System.Drawing.Size(70, 20);
            this.txt_paramDead.TabIndex = 1;
            this.txt_paramDead.Tag = "paramDead";
            // 
            // txt_paramLow
            // 
            this.txt_paramLow.EditValue = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.txt_paramLow.Location = new System.Drawing.Point(280, 33);
            this.txt_paramLow.Name = "txt_paramLow";
            this.txt_paramLow.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramLow.Size = new System.Drawing.Size(70, 20);
            this.txt_paramLow.TabIndex = 3;
            this.txt_paramLow.Tag = "paramLow";
            // 
            // txt_paramHigh
            // 
            this.txt_paramHigh.EditValue = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.txt_paramHigh.Location = new System.Drawing.Point(91, 33);
            this.txt_paramHigh.Name = "txt_paramHigh";
            this.txt_paramHigh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramHigh.Size = new System.Drawing.Size(70, 20);
            this.txt_paramHigh.TabIndex = 2;
            this.txt_paramHigh.Tag = "paramHigh";
            // 
            // CtrlParamRatioAlm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gc_1);
            this.Controls.Add(this.gc_2);
            this.Name = "CtrlParamRatioAlm";
            this.Size = new System.Drawing.Size(364, 116);
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).EndInit();
            this.gc_1.ResumeLayout(false);
            this.gc_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).EndInit();
            this.gc_2.ResumeLayout(false);
            this.gc_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramDead.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramLow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramHigh.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gc_1;
        private DevExpress.XtraEditors.LabelControl lbl_outputAO;
        private DevExpress.XtraEditors.SpinEdit txt_inputAI;
        private DevExpress.XtraEditors.LabelControl lbl_inputAI;
        private DevExpress.XtraEditors.GroupControl gc_2;
        private DevExpress.XtraEditors.LabelControl lbl_paramDead;
        private DevExpress.XtraEditors.LabelControl lbl_paramLow;
        private DevExpress.XtraEditors.LabelControl lbl_paramHigh;
        private DevExpress.XtraEditors.SpinEdit txt_paramDead;
        private DevExpress.XtraEditors.SpinEdit txt_paramLow;
        private DevExpress.XtraEditors.SpinEdit txt_paramHigh;

    }
}
