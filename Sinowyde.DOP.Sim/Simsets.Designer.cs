namespace Sinowyde.DOP.Sim
{
    partial class Simsets
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAuto = new System.Windows.Forms.Button();
            this.nRangeMax = new System.Windows.Forms.NumericUpDown();
            this.nRangeMin = new System.Windows.Forms.NumericUpDown();
            this.nStep = new System.Windows.Forms.NumericUpDown();
            this.nInternal = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.drpSimType = new System.Windows.Forms.ComboBox();
            this.nManual = new System.Windows.Forms.NumericUpDown();
            this.lbName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nRangeMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRangeMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nInternal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nManual)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAuto
            // 
            this.btnAuto.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAuto.Location = new System.Drawing.Point(194, 207);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 21;
            this.btnAuto.Text = "执行";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // nRangeMax
            // 
            this.nRangeMax.Location = new System.Drawing.Point(197, 161);
            this.nRangeMax.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nRangeMax.Minimum = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147483648});
            this.nRangeMax.Name = "nRangeMax";
            this.nRangeMax.Size = new System.Drawing.Size(72, 21);
            this.nRangeMax.TabIndex = 17;
            this.nRangeMax.Value = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            // 
            // nRangeMin
            // 
            this.nRangeMin.Location = new System.Drawing.Point(105, 161);
            this.nRangeMin.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nRangeMin.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.nRangeMin.Name = "nRangeMin";
            this.nRangeMin.Size = new System.Drawing.Size(72, 21);
            this.nRangeMin.TabIndex = 18;
            // 
            // nStep
            // 
            this.nStep.DecimalPlaces = 2;
            this.nStep.Location = new System.Drawing.Point(105, 131);
            this.nStep.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nStep.Minimum = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.nStep.Name = "nStep";
            this.nStep.Size = new System.Drawing.Size(72, 21);
            this.nStep.TabIndex = 19;
            this.nStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nInternal
            // 
            this.nInternal.Location = new System.Drawing.Point(105, 101);
            this.nInternal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nInternal.Name = "nInternal";
            this.nInternal.Size = new System.Drawing.Size(72, 21);
            this.nInternal.TabIndex = 20;
            this.nInternal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "随机数范围:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "模拟类型:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "步长:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "变换间隔:";
            // 
            // drpSimType
            // 
            this.drpSimType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpSimType.FormattingEnabled = true;
            this.drpSimType.Items.AddRange(new object[] {
            "手动",
            "随机值",
            "增量",
            "减量"});
            this.drpSimType.Location = new System.Drawing.Point(105, 29);
            this.drpSimType.Name = "drpSimType";
            this.drpSimType.Size = new System.Drawing.Size(121, 20);
            this.drpSimType.TabIndex = 13;
            this.drpSimType.SelectedIndexChanged += new System.EventHandler(this.drpSimType_SelectedIndexChanged);
            // 
            // nManual
            // 
            this.nManual.Location = new System.Drawing.Point(105, 68);
            this.nManual.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nManual.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.nManual.Name = "nManual";
            this.nManual.Size = new System.Drawing.Size(72, 21);
            this.nManual.TabIndex = 20;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.SystemColors.Control;
            this.lbName.ForeColor = System.Drawing.Color.Red;
            this.lbName.Location = new System.Drawing.Point(26, 73);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(59, 12);
            this.lbName.TabIndex = 12;
            this.lbName.Text = "模拟类型:";
            // 
            // Simsets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 251);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.nRangeMax);
            this.Controls.Add(this.nRangeMin);
            this.Controls.Add(this.nStep);
            this.Controls.Add(this.nManual);
            this.Controls.Add(this.nInternal);
            this.Controls.Add(this.drpSimType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Simsets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simsets";
            this.Shown += new System.EventHandler(this.Simsets_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nRangeMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRangeMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nInternal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nManual)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.NumericUpDown nRangeMax;
        private System.Windows.Forms.NumericUpDown nRangeMin;
        private System.Windows.Forms.NumericUpDown nStep;
        private System.Windows.Forms.NumericUpDown nInternal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox drpSimType;
        private System.Windows.Forms.NumericUpDown nManual;
        private System.Windows.Forms.Label lbName;
    }
}