namespace Sinowyde.DOP.PIDBlock.Math
{
    partial class CtrlParamAsin
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
            this.cmb_ATrigonometricFunc = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txt_inputAI = new DevExpress.XtraEditors.SpinEdit();
            this.lbl_inputAI = new DevExpress.XtraEditors.LabelControl();
            this.lbl_ATrigonometricFunc = new DevExpress.XtraEditors.LabelControl();
            this.gc_2 = new DevExpress.XtraEditors.GroupControl();
            this.lbl_paramK = new DevExpress.XtraEditors.LabelControl();
            this.txt_paramBias = new DevExpress.XtraEditors.SpinEdit();
            this.txt_paramK = new DevExpress.XtraEditors.SpinEdit();
            this.lbl_paramBias = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).BeginInit();
            this.gc_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_ATrigonometricFunc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).BeginInit();
            this.gc_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramBias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramK.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gc_1
            // 
            this.gc_1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gc_1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gc_1.Controls.Add(this.lbl_output);
            this.gc_1.Controls.Add(this.cmb_ATrigonometricFunc);
            this.gc_1.Controls.Add(this.txt_inputAI);
            this.gc_1.Controls.Add(this.lbl_inputAI);
            this.gc_1.Controls.Add(this.lbl_ATrigonometricFunc);
            this.gc_1.Location = new System.Drawing.Point(2, 2);
            this.gc_1.Name = "gc_1";
            this.gc_1.Size = new System.Drawing.Size(360, 75);
            this.gc_1.TabIndex = 4;
            this.gc_1.Text = "输入输出变量说明及输入初值";
            // 
            // lbl_output
            // 
            this.lbl_output.Location = new System.Drawing.Point(10, 52);
            this.lbl_output.Name = "lbl_output";
            this.lbl_output.Size = new System.Drawing.Size(60, 14);
            this.lbl_output.TabIndex = 5;
            this.lbl_output.Text = "模拟量输出";
            // 
            // cmb_ATrigonometricFunc
            // 
            this.cmb_ATrigonometricFunc.Location = new System.Drawing.Point(280, 25);
            this.cmb_ATrigonometricFunc.Name = "cmb_ATrigonometricFunc";
            this.cmb_ATrigonometricFunc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_ATrigonometricFunc.Size = new System.Drawing.Size(70, 20);
            this.cmb_ATrigonometricFunc.TabIndex = 2;
            this.cmb_ATrigonometricFunc.Tag = "paramATrigonometricFunc";
            this.cmb_ATrigonometricFunc.SelectedIndexChanged += new System.EventHandler(this.cmb_ATrigonometricFunc_SelectedIndexChanged);
            // 
            // txt_inputAI
            // 
            this.txt_inputAI.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_inputAI.Location = new System.Drawing.Point(83, 25);
            this.txt_inputAI.Name = "txt_inputAI";
            this.txt_inputAI.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_inputAI.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.txt_inputAI.Properties.Mask.EditMask = "n2";
            this.txt_inputAI.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_inputAI.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txt_inputAI.Size = new System.Drawing.Size(70, 20);
            this.txt_inputAI.TabIndex = 0;
            this.txt_inputAI.Tag = "inputAI";
            // 
            // lbl_inputAI
            // 
            this.lbl_inputAI.Location = new System.Drawing.Point(10, 28);
            this.lbl_inputAI.Name = "lbl_inputAI";
            this.lbl_inputAI.Size = new System.Drawing.Size(72, 14);
            this.lbl_inputAI.TabIndex = 4;
            this.lbl_inputAI.Text = "模拟量输入：";
            // 
            // lbl_ATrigonometricFunc
            // 
            this.lbl_ATrigonometricFunc.Location = new System.Drawing.Point(181, 28);
            this.lbl_ATrigonometricFunc.Name = "lbl_ATrigonometricFunc";
            this.lbl_ATrigonometricFunc.Size = new System.Drawing.Size(96, 14);
            this.lbl_ATrigonometricFunc.TabIndex = 3;
            this.lbl_ATrigonometricFunc.Text = "反三角函数类型：";
            // 
            // gc_2
            // 
            this.gc_2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gc_2.Controls.Add(this.lbl_paramK);
            this.gc_2.Controls.Add(this.txt_paramBias);
            this.gc_2.Controls.Add(this.txt_paramK);
            this.gc_2.Controls.Add(this.lbl_paramBias);
            this.gc_2.Location = new System.Drawing.Point(2, 79);
            this.gc_2.Name = "gc_2";
            this.gc_2.ShowCaption = false;
            this.gc_2.Size = new System.Drawing.Size(360, 32);
            this.gc_2.TabIndex = 5;
            // 
            // lbl_paramK
            // 
            this.lbl_paramK.Location = new System.Drawing.Point(10, 10);
            this.lbl_paramK.Name = "lbl_paramK";
            this.lbl_paramK.Size = new System.Drawing.Size(43, 14);
            this.lbl_paramK.TabIndex = 5;
            this.lbl_paramK.Text = "系数K：";
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
            this.txt_paramBias.TabIndex = 3;
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
            this.txt_paramK.Properties.Mask.EditMask = "n2";
            this.txt_paramK.Size = new System.Drawing.Size(70, 20);
            this.txt_paramK.TabIndex = 2;
            this.txt_paramK.Tag = "paramK";
            // 
            // lbl_paramBias
            // 
            this.lbl_paramBias.Location = new System.Drawing.Point(221, 10);
            this.lbl_paramBias.Name = "lbl_paramBias";
            this.lbl_paramBias.Size = new System.Drawing.Size(56, 14);
            this.lbl_paramBias.TabIndex = 4;
            this.lbl_paramBias.Text = "偏置Bias：";
            // 
            // CtrlParamAsin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gc_1);
            this.Controls.Add(this.gc_2);
            this.Name = "CtrlParamAsin";
            this.Size = new System.Drawing.Size(364, 115);
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).EndInit();
            this.gc_1.ResumeLayout(false);
            this.gc_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_ATrigonometricFunc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).EndInit();
            this.gc_2.ResumeLayout(false);
            this.gc_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramBias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramK.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gc_1;
        private DevExpress.XtraEditors.SpinEdit txt_inputAI;
        private DevExpress.XtraEditors.GroupControl gc_2;
        private DevExpress.XtraEditors.SpinEdit txt_paramBias;
        private DevExpress.XtraEditors.SpinEdit txt_paramK;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_ATrigonometricFunc;
        private DevExpress.XtraEditors.LabelControl lbl_output;
        private DevExpress.XtraEditors.LabelControl lbl_ATrigonometricFunc;
        private DevExpress.XtraEditors.LabelControl lbl_inputAI;
        private DevExpress.XtraEditors.LabelControl lbl_paramK;
        private DevExpress.XtraEditors.LabelControl lbl_paramBias;
    }
}
