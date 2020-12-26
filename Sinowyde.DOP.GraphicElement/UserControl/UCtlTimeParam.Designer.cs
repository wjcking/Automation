namespace Sinowyde.DOP.GraphicElement
{
    partial class UCtlTimeParam
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCtlTimeParam));
            this.imageCollectionLine = new DevExpress.Utils.ImageCollection(this.components);
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnFont = new DevExpress.XtraEditors.SimpleButton();
            this.cboTimeType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTimeType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollectionLine
            // 
            this.imageCollectionLine.ImageSize = new System.Drawing.Size(30, 14);
            this.imageCollectionLine.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionLine.ImageStream")));
            this.imageCollectionLine.Images.SetKeyName(0, "Line1.jpg");
            this.imageCollectionLine.Images.SetKeyName(1, "Line2.jpg");
            this.imageCollectionLine.Images.SetKeyName(2, "Line3.jpg");
            this.imageCollectionLine.Images.SetKeyName(3, "Line4.jpg");
            this.imageCollectionLine.Images.SetKeyName(4, "Line5.jpg");
            this.imageCollectionLine.Images.SetKeyName(5, "Line6.jpg");
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(378, 97);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(372, 68);
            this.xtraTabPage1.Text = "基本属性";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnFont);
            this.groupControl1.Controls.Add(this.cboTimeType);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(364, 60);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "选择颜色";
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(290, 18);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(52, 23);
            this.btnFont.TabIndex = 8;
            this.btnFont.Text = "字体";
            this.btnFont.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // cboTimeType
            // 
            this.cboTimeType.EditValue = "年-月-日";
            this.cboTimeType.Location = new System.Drawing.Point(91, 19);
            this.cboTimeType.Name = "cboTimeType";
            this.cboTimeType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTimeType.Size = new System.Drawing.Size(188, 20);
            this.cboTimeType.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 22);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "时间类型:";
            // 
            // UCtlTimeParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "UCtlTimeParam";
            this.Size = new System.Drawing.Size(375, 94);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTimeType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageCollectionLine;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnFont;
        private DevExpress.XtraEditors.ComboBoxEdit cboTimeType;
        private DevExpress.XtraEditors.LabelControl labelControl2;

    }
}
