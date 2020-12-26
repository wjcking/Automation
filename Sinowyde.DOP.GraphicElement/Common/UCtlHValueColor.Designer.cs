namespace Sinowyde.DOP.GraphicElement
{
    partial class UCtlHValueColor
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
            this.txtOutputValue = new DevExpress.XtraEditors.TextEdit();
            this.ColorOutputColo = new DevExpress.XtraEditors.ColorEdit();
            this.colorOutputBackColor = new DevExpress.XtraEditors.ColorEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.lblOutputString = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtOutputValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorOutputColo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorOutputBackColor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOutputValue
            // 
            this.txtOutputValue.Location = new System.Drawing.Point(99, 0);
            this.txtOutputValue.Name = "txtOutputValue";
            this.txtOutputValue.Size = new System.Drawing.Size(88, 20);
            this.txtOutputValue.TabIndex = 21;
            // 
            // ColorOutputColo
            // 
            this.ColorOutputColo.EditValue = System.Drawing.Color.Empty;
            this.ColorOutputColo.Location = new System.Drawing.Point(239, 0);
            this.ColorOutputColo.Name = "ColorOutputColo";
            this.ColorOutputColo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ColorOutputColo.Size = new System.Drawing.Size(49, 20);
            this.ColorOutputColo.TabIndex = 19;
            // 
            // colorOutputBackColor
            // 
            this.colorOutputBackColor.EditValue = System.Drawing.Color.Empty;
            this.colorOutputBackColor.Location = new System.Drawing.Point(351, 0);
            this.colorOutputBackColor.Name = "colorOutputBackColor";
            this.colorOutputBackColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorOutputBackColor.Size = new System.Drawing.Size(49, 20);
            this.colorOutputBackColor.TabIndex = 20;
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(300, 3);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(48, 14);
            this.labelControl15.TabIndex = 16;
            this.labelControl15.Text = "背景色：";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(200, 3);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(36, 14);
            this.labelControl13.TabIndex = 17;
            this.labelControl13.Text = "颜色：";
            // 
            // lblOutputString
            // 
            this.lblOutputString.Location = new System.Drawing.Point(5, 3);
            this.lblOutputString.Name = "lblOutputString";
            this.lblOutputString.Size = new System.Drawing.Size(91, 14);
            this.lblOutputString.TabIndex = 18;
            this.lblOutputString.Text = "0值输出字符串：";
            // 
            // UCtlHValueColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtOutputValue);
            this.Controls.Add(this.ColorOutputColo);
            this.Controls.Add(this.colorOutputBackColor);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.lblOutputString);
            this.Name = "UCtlHValueColor";
            this.Size = new System.Drawing.Size(400, 20);
            this.Load += new System.EventHandler(this.UCtlHValueColor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtOutputValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorOutputColo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorOutputBackColor.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtOutputValue;
        private DevExpress.XtraEditors.ColorEdit ColorOutputColo;
        private DevExpress.XtraEditors.ColorEdit colorOutputBackColor;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl lblOutputString;
    }
}
