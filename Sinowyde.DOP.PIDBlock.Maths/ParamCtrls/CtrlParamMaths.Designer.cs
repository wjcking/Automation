namespace Sinowyde.DOP.PIDBlock.Math
{
    partial class CtrlParamMaths
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
            this.lbl_inputAI = new DevExpress.XtraEditors.LabelControl();
            this.lbl_output = new DevExpress.XtraEditors.LabelControl();
            this.txt_inputAI = new DevExpress.XtraEditors.SpinEdit();
            this.gc_2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txt_k6 = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_ks1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_k5 = new DevExpress.XtraEditors.SpinEdit();
            this.txt_k4 = new DevExpress.XtraEditors.SpinEdit();
            this.txt_k3 = new DevExpress.XtraEditors.SpinEdit();
            this.txt_k2 = new DevExpress.XtraEditors.SpinEdit();
            this.txt_k1 = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).BeginInit();
            this.gc_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).BeginInit();
            this.gc_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_k6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_k5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_k4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_k3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_k2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_k1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gc_1
            // 
            this.gc_1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gc_1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gc_1.Controls.Add(this.lbl_inputAI);
            this.gc_1.Controls.Add(this.lbl_output);
            this.gc_1.Controls.Add(this.txt_inputAI);
            this.gc_1.Location = new System.Drawing.Point(2, 2);
            this.gc_1.Name = "gc_1";
            this.gc_1.Size = new System.Drawing.Size(360, 52);
            this.gc_1.TabIndex = 6;
            this.gc_1.Text = "输入输出变量说明及输入初值";
            // 
            // lbl_inputAI
            // 
            this.lbl_inputAI.Location = new System.Drawing.Point(10, 29);
            this.lbl_inputAI.Name = "lbl_inputAI";
            this.lbl_inputAI.Size = new System.Drawing.Size(72, 14);
            this.lbl_inputAI.TabIndex = 8;
            this.lbl_inputAI.Text = "模拟量输入：";
            // 
            // lbl_output
            // 
            this.lbl_output.Location = new System.Drawing.Point(242, 25);
            this.lbl_output.Name = "lbl_output";
            this.lbl_output.Size = new System.Drawing.Size(60, 14);
            this.lbl_output.TabIndex = 7;
            this.lbl_output.Text = "模拟量输出";
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
            this.gc_2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gc_2.Controls.Add(this.labelControl5);
            this.gc_2.Controls.Add(this.txt_k6);
            this.gc_2.Controls.Add(this.labelControl4);
            this.gc_2.Controls.Add(this.labelControl3);
            this.gc_2.Controls.Add(this.labelControl2);
            this.gc_2.Controls.Add(this.labelControl1);
            this.gc_2.Controls.Add(this.lbl_ks1);
            this.gc_2.Controls.Add(this.txt_k5);
            this.gc_2.Controls.Add(this.txt_k4);
            this.gc_2.Controls.Add(this.txt_k3);
            this.gc_2.Controls.Add(this.txt_k2);
            this.gc_2.Controls.Add(this.txt_k1);
            this.gc_2.Location = new System.Drawing.Point(3, 53);
            this.gc_2.Name = "gc_2";
            this.gc_2.ShowCaption = false;
            this.gc_2.Size = new System.Drawing.Size(360, 99);
            this.gc_2.TabIndex = 7;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(206, 72);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(43, 14);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "系数6：";
            // 
            // txt_k6
            // 
            this.txt_k6.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_k6.Location = new System.Drawing.Point(253, 69);
            this.txt_k6.Name = "txt_k6";
            this.txt_k6.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_k6.Properties.Mask.EditMask = "n2";
            this.txt_k6.Size = new System.Drawing.Size(70, 20);
            this.txt_k6.TabIndex = 8;
            this.txt_k6.Tag = "inputAI";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(36, 72);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 14);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "系数3：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(206, 41);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(43, 14);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "系数5：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(36, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 14);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "系数2：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(207, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 14);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "系数4：";
            // 
            // lbl_ks1
            // 
            this.lbl_ks1.Location = new System.Drawing.Point(36, 10);
            this.lbl_ks1.Name = "lbl_ks1";
            this.lbl_ks1.Size = new System.Drawing.Size(43, 14);
            this.lbl_ks1.TabIndex = 7;
            this.lbl_ks1.Text = "系数1：";
            // 
            // txt_k5
            // 
            this.txt_k5.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_k5.Location = new System.Drawing.Point(253, 38);
            this.txt_k5.Name = "txt_k5";
            this.txt_k5.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_k5.Properties.Mask.EditMask = "n2";
            this.txt_k5.Size = new System.Drawing.Size(70, 20);
            this.txt_k5.TabIndex = 0;
            this.txt_k5.Tag = "inputAI";
            // 
            // txt_k4
            // 
            this.txt_k4.EditValue = new decimal(new int[] {
            12,
            0,
            0,
            65536});
            this.txt_k4.Location = new System.Drawing.Point(253, 7);
            this.txt_k4.Name = "txt_k4";
            this.txt_k4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_k4.Properties.Mask.EditMask = "n2";
            this.txt_k4.Size = new System.Drawing.Size(70, 20);
            this.txt_k4.TabIndex = 0;
            this.txt_k4.Tag = "inputAI";
            // 
            // txt_k3
            // 
            this.txt_k3.EditValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.txt_k3.Location = new System.Drawing.Point(82, 69);
            this.txt_k3.Name = "txt_k3";
            this.txt_k3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_k3.Properties.Mask.EditMask = "n2";
            this.txt_k3.Size = new System.Drawing.Size(70, 20);
            this.txt_k3.TabIndex = 0;
            this.txt_k3.Tag = "inputAI";
            // 
            // txt_k2
            // 
            this.txt_k2.EditValue = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.txt_k2.Location = new System.Drawing.Point(82, 38);
            this.txt_k2.Name = "txt_k2";
            this.txt_k2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_k2.Properties.Mask.EditMask = "n2";
            this.txt_k2.Size = new System.Drawing.Size(70, 20);
            this.txt_k2.TabIndex = 0;
            this.txt_k2.Tag = "inputAI";
            // 
            // txt_k1
            // 
            this.txt_k1.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_k1.Location = new System.Drawing.Point(83, 7);
            this.txt_k1.Name = "txt_k1";
            this.txt_k1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_k1.Properties.Mask.EditMask = "n2";
            this.txt_k1.Size = new System.Drawing.Size(70, 20);
            this.txt_k1.TabIndex = 0;
            this.txt_k1.Tag = "inputAI";
            // 
            // CtrlParamMaths
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gc_1);
            this.Controls.Add(this.gc_2);
            this.Name = "CtrlParamMaths";
            this.Size = new System.Drawing.Size(364, 152);
            ((System.ComponentModel.ISupportInitialize)(this.gc_1)).EndInit();
            this.gc_1.ResumeLayout(false);
            this.gc_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputAI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_2)).EndInit();
            this.gc_2.ResumeLayout(false);
            this.gc_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_k6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_k5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_k4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_k3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_k2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_k1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gc_1;
        private DevExpress.XtraEditors.SpinEdit txt_inputAI;
        private DevExpress.XtraEditors.GroupControl gc_2;
        private DevExpress.XtraEditors.LabelControl lbl_inputAI;
        private DevExpress.XtraEditors.LabelControl lbl_output;
        private DevExpress.XtraEditors.LabelControl lbl_ks1;
        private DevExpress.XtraEditors.SpinEdit txt_k5;
        private DevExpress.XtraEditors.SpinEdit txt_k4;
        private DevExpress.XtraEditors.SpinEdit txt_k3;
        private DevExpress.XtraEditors.SpinEdit txt_k2;
        private DevExpress.XtraEditors.SpinEdit txt_k1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SpinEdit txt_k6;
    }
}
