namespace Sinowyde.DOP.PIDBlock.Math
{
    partial class CtrlParamSub
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
            this.lbl_inputAI1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_inputAI2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_inputAI2 = new DevExpress.XtraEditors.SpinEdit();
            this.txt_inputAI1 = new DevExpress.XtraEditors.SpinEdit();
            this.gc_2 = new DevExpress.XtraEditors.GroupControl();
            this.lbl_paramK2 = new DevExpress.XtraEditors.LabelControl();
            this.txt_paramK2 = new DevExpress.XtraEditors.SpinEdit();
            this.txt_paramK1 = new DevExpress.XtraEditors.SpinEdit();
            this.lbl_paramK1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).BeginInit();
            this.gc_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).BeginInit();
            this.gc_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramK2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramK1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gc_1
            // 
            this.gc_1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gc_1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gc_1.Controls.Add(this.lbl_inputAI1);
            this.gc_1.Controls.Add(this.lbl_inputAI2);
            this.gc_1.Controls.Add(this.labelControl1);
            this.gc_1.Controls.Add(this.txt_inputAI2);
            this.gc_1.Controls.Add(this.txt_inputAI1);
            this.gc_1.Location = new System.Drawing.Point(2, 2);
            this.gc_1.Name = "gc_1";
            this.gc_1.Size = new System.Drawing.Size(360, 71);
            this.gc_1.TabIndex = 12;
            this.gc_1.Text = "输入输出变量说明及输入初值";
            // 
            // lbl_inputAI1
            // 
            this.lbl_inputAI1.Location = new System.Drawing.Point(10, 29);
            this.lbl_inputAI1.Name = "lbl_inputAI1";
            this.lbl_inputAI1.Size = new System.Drawing.Size(67, 14);
            this.lbl_inputAI1.TabIndex = 16;
            this.lbl_inputAI1.Text = "被减数AI1：";
            // 
            // lbl_inputAI2
            // 
            this.lbl_inputAI2.Location = new System.Drawing.Point(222, 29);
            this.lbl_inputAI2.Name = "lbl_inputAI2";
            this.lbl_inputAI2.Size = new System.Drawing.Size(55, 14);
            this.lbl_inputAI2.TabIndex = 15;
            this.lbl_inputAI2.Text = "减数AI2：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "模拟量输出";
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
            this.txt_inputAI2.TabIndex = 1;
            this.txt_inputAI2.Tag = "inputAI2";
            // 
            // txt_inputAI1
            // 
            this.txt_inputAI1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_inputAI1.Location = new System.Drawing.Point(95, 26);
            this.txt_inputAI1.Name = "txt_inputAI1";
            this.txt_inputAI1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_inputAI1.Properties.Mask.EditMask = "n2";
            this.txt_inputAI1.Size = new System.Drawing.Size(70, 20);
            this.txt_inputAI1.TabIndex = 0;
            this.txt_inputAI1.Tag = "inputAI1";
            // 
            // gc_2
            // 
            this.gc_2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gc_2.Controls.Add(this.lbl_paramK2);
            this.gc_2.Controls.Add(this.txt_paramK2);
            this.gc_2.Controls.Add(this.txt_paramK1);
            this.gc_2.Controls.Add(this.lbl_paramK1);
            this.gc_2.Location = new System.Drawing.Point(2, 75);
            this.gc_2.Name = "gc_2";
            this.gc_2.ShowCaption = false;
            this.gc_2.Size = new System.Drawing.Size(360, 30);
            this.gc_2.TabIndex = 13;
            // 
            // lbl_paramK2
            // 
            this.lbl_paramK2.Location = new System.Drawing.Point(203, 8);
            this.lbl_paramK2.Name = "lbl_paramK2";
            this.lbl_paramK2.Size = new System.Drawing.Size(74, 14);
            this.lbl_paramK2.TabIndex = 14;
            this.lbl_paramK2.Text = "减数系数K2：";
            // 
            // txt_paramK2
            // 
            this.txt_paramK2.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_paramK2.Location = new System.Drawing.Point(280, 5);
            this.txt_paramK2.Name = "txt_paramK2";
            this.txt_paramK2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramK2.Properties.Mask.EditMask = "n2";
            this.txt_paramK2.Size = new System.Drawing.Size(70, 20);
            this.txt_paramK2.TabIndex = 4;
            this.txt_paramK2.Tag = "paramK2";
            // 
            // txt_paramK1
            // 
            this.txt_paramK1.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_paramK1.Location = new System.Drawing.Point(95, 5);
            this.txt_paramK1.Name = "txt_paramK1";
            this.txt_paramK1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_paramK1.Properties.Mask.EditMask = "n2";
            this.txt_paramK1.Size = new System.Drawing.Size(70, 20);
            this.txt_paramK1.TabIndex = 2;
            this.txt_paramK1.Tag = "paramK1";
            // 
            // lbl_paramK1
            // 
            this.lbl_paramK1.Location = new System.Drawing.Point(10, 8);
            this.lbl_paramK1.Name = "lbl_paramK1";
            this.lbl_paramK1.Size = new System.Drawing.Size(86, 14);
            this.lbl_paramK1.TabIndex = 15;
            this.lbl_paramK1.Text = "被减数系数K1：";
            // 
            // CtrlParamSub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gc_1);
            this.Controls.Add(this.gc_2);
            this.Name = "CtrlParamSub";
            this.Size = new System.Drawing.Size(364, 107);
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).EndInit();
            this.gc_1.ResumeLayout(false);
            this.gc_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).EndInit();
            this.gc_2.ResumeLayout(false);
            this.gc_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramK2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_paramK1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gc_1;
        private DevExpress.XtraEditors.SpinEdit txt_inputAI2;
        private DevExpress.XtraEditors.SpinEdit txt_inputAI1;
        private DevExpress.XtraEditors.GroupControl gc_2;
        private DevExpress.XtraEditors.SpinEdit txt_paramK2;
        private DevExpress.XtraEditors.SpinEdit txt_paramK1;
        private DevExpress.XtraEditors.LabelControl lbl_inputAI1;
        private DevExpress.XtraEditors.LabelControl lbl_inputAI2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lbl_paramK1;
        private DevExpress.XtraEditors.LabelControl lbl_paramK2;
    }
}
