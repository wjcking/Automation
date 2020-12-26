namespace Sinowyde.DOP.SamaXmlUpdate.Control
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.simpleButtonOld = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonNew = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonDo = new DevExpress.XtraEditors.SimpleButton();
            this.textEditOld = new DevExpress.XtraEditors.TextEdit();
            this.textEditNew = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditOld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNew.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButtonOld
            // 
            this.simpleButtonOld.Location = new System.Drawing.Point(387, 12);
            this.simpleButtonOld.Name = "simpleButtonOld";
            this.simpleButtonOld.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOld.TabIndex = 0;
            this.simpleButtonOld.Text = "打开原始";
            this.simpleButtonOld.Click += new System.EventHandler(this.simpleButtonOld_Click);
            // 
            // simpleButtonNew
            // 
            this.simpleButtonNew.Location = new System.Drawing.Point(387, 57);
            this.simpleButtonNew.Name = "simpleButtonNew";
            this.simpleButtonNew.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonNew.TabIndex = 0;
            this.simpleButtonNew.Text = "保存新的";
            this.simpleButtonNew.Click += new System.EventHandler(this.simpleButtonNew_Click);
            // 
            // simpleButtonDo
            // 
            this.simpleButtonDo.Location = new System.Drawing.Point(500, 34);
            this.simpleButtonDo.Name = "simpleButtonDo";
            this.simpleButtonDo.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonDo.TabIndex = 0;
            this.simpleButtonDo.Text = "转换";
            this.simpleButtonDo.Click += new System.EventHandler(this.simpleButtonDo_Click);
            // 
            // textEditOld
            // 
            this.textEditOld.Location = new System.Drawing.Point(24, 15);
            this.textEditOld.Name = "textEditOld";
            this.textEditOld.Size = new System.Drawing.Size(346, 20);
            this.textEditOld.TabIndex = 1;
            // 
            // textEditNew
            // 
            this.textEditNew.Location = new System.Drawing.Point(24, 60);
            this.textEditNew.Name = "textEditNew";
            this.textEditNew.Size = new System.Drawing.Size(346, 20);
            this.textEditNew.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 102);
            this.Controls.Add(this.textEditNew);
            this.Controls.Add(this.textEditOld);
            this.Controls.Add(this.simpleButtonDo);
            this.Controls.Add(this.simpleButtonNew);
            this.Controls.Add(this.simpleButtonOld);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEditOld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNew.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButtonOld;
        private DevExpress.XtraEditors.SimpleButton simpleButtonNew;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDo;
        private DevExpress.XtraEditors.TextEdit textEditOld;
        private DevExpress.XtraEditors.TextEdit textEditNew;
    }
}

