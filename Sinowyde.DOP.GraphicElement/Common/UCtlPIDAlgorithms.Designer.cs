namespace Sinowyde.DOP.GraphicElement
{
    partial class UCtlPIDAlgorithms
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
            this.cboIO = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboPage = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboAlgType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboBlock = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboIO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlgType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBlock.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboIO
            // 
            this.cboIO.Location = new System.Drawing.Point(79, 82);
            this.cboIO.Name = "cboIO";
            this.cboIO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboIO.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboIO.Size = new System.Drawing.Size(87, 20);
            this.cboIO.TabIndex = 20;
            this.cboIO.SelectedIndexChanged += new System.EventHandler(this.cboIO_SelectedIndexChanged);
            // 
            // cboPage
            // 
            this.cboPage.Location = new System.Drawing.Point(79, 2);
            this.cboPage.Name = "cboPage";
            this.cboPage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPage.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPage.Size = new System.Drawing.Size(87, 20);
            this.cboPage.TabIndex = 21;
            this.cboPage.SelectedIndexChanged += new System.EventHandler(this.cboPage_SelectedIndexChanged);
            // 
            // cboAlgType
            // 
            this.cboAlgType.Location = new System.Drawing.Point(79, 28);
            this.cboAlgType.Name = "cboAlgType";
            this.cboAlgType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAlgType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboAlgType.Size = new System.Drawing.Size(86, 20);
            this.cboAlgType.TabIndex = 22;
            this.cboAlgType.SelectedIndexChanged += new System.EventHandler(this.cboAlgType_SelectedIndexChanged);
            // 
            // labelControl21
            // 
            this.labelControl21.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl21.Location = new System.Drawing.Point(4, 85);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(48, 14);
            this.labelControl21.TabIndex = 17;
            this.labelControl21.Text = "输出名称";
            // 
            // labelControl20
            // 
            this.labelControl20.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl20.Location = new System.Drawing.Point(3, 31);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(60, 14);
            this.labelControl20.TabIndex = 18;
            this.labelControl20.Text = "算法块类型";
            // 
            // labelControl5
            // 
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl5.Location = new System.Drawing.Point(4, 5);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 14);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "页号";
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.labelControl1.Location = new System.Drawing.Point(4, 58);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "块号";
            // 
            // cboBlock
            // 
            this.cboBlock.Location = new System.Drawing.Point(79, 55);
            this.cboBlock.Name = "cboBlock";
            this.cboBlock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBlock.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboBlock.Size = new System.Drawing.Size(87, 20);
            this.cboBlock.TabIndex = 22;
            this.cboBlock.SelectedIndexChanged += new System.EventHandler(this.cboBlock_SelectedIndexChanged);
            // 
            // UCtlPIDAlgorithms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboIO);
            this.Controls.Add(this.cboPage);
            this.Controls.Add(this.cboAlgType);
            this.Controls.Add(this.labelControl21);
            this.Controls.Add(this.labelControl20);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.cboBlock);
            this.Controls.Add(this.labelControl1);
            this.Name = "UCtlPIDAlgorithms";
            this.Size = new System.Drawing.Size(167, 106);
            this.Load += new System.EventHandler(this.UCtlPIDAlgorithms_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboIO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlgType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBlock.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit cboIO;
        private DevExpress.XtraEditors.ComboBoxEdit cboPage;
        private DevExpress.XtraEditors.ComboBoxEdit cboAlgType;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboBlock;

    }
}
