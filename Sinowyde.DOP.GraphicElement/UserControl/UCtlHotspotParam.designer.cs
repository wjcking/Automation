namespace Sinowyde.DOP.GraphicElement
{
    partial class UCtlHotspotParam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCtlHotspotParam));
            this.imageCollectionLine = new DevExpress.Utils.ImageCollection(this.components);
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cbxOperate = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelCtlDOColor = new DevExpress.XtraEditors.PanelControl();
            this.spinHeight = new DevExpress.XtraEditors.SpinEdit();
            this.spinTop = new DevExpress.XtraEditors.SpinEdit();
            this.spinWidth = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.spinLeft = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnOpen = new DevExpress.XtraEditors.SimpleButton();
            this.txtFile = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxOperate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCtlDOColor)).BeginInit();
            this.panelCtlDOColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinHeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinLeft.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).BeginInit();
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
            this.xtraTabControl1.Size = new System.Drawing.Size(477, 230);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(471, 201);
            this.xtraTabPage1.Text = "基本属性";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cbxOperate);
            this.groupControl1.Controls.Add(this.panelCtlDOColor);
            this.groupControl1.Controls.Add(this.btnOpen);
            this.groupControl1.Controls.Add(this.txtFile);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(463, 194);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "选择颜色";
            // 
            // cbxOperate
            // 
            this.cbxOperate.EditValue = "切换底图";
            this.cbxOperate.Location = new System.Drawing.Point(78, 16);
            this.cbxOperate.Name = "cbxOperate";
            this.cbxOperate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown)});
            this.cbxOperate.Properties.Items.AddRange(new object[] {
            "切换底图",
            "弹出窗口",
            "执行程序"});
            this.cbxOperate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbxOperate.Size = new System.Drawing.Size(108, 20);
            this.cbxOperate.TabIndex = 9;
            this.cbxOperate.SelectedIndexChanged += new System.EventHandler(this.cbxOperate_SelectedIndexChanged);
            // 
            // panelCtlDOColor
            // 
            this.panelCtlDOColor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelCtlDOColor.Controls.Add(this.spinHeight);
            this.panelCtlDOColor.Controls.Add(this.spinTop);
            this.panelCtlDOColor.Controls.Add(this.spinWidth);
            this.panelCtlDOColor.Controls.Add(this.labelControl7);
            this.panelCtlDOColor.Controls.Add(this.spinLeft);
            this.panelCtlDOColor.Controls.Add(this.labelControl6);
            this.panelCtlDOColor.Controls.Add(this.labelControl3);
            this.panelCtlDOColor.Controls.Add(this.labelControl1);
            this.panelCtlDOColor.Controls.Add(this.labelControl5);
            this.panelCtlDOColor.Controls.Add(this.labelControl4);
            this.panelCtlDOColor.Location = new System.Drawing.Point(77, 58);
            this.panelCtlDOColor.Name = "panelCtlDOColor";
            this.panelCtlDOColor.Size = new System.Drawing.Size(308, 87);
            this.panelCtlDOColor.TabIndex = 12;
            this.panelCtlDOColor.Visible = false;
            // 
            // spinHeight
            // 
            this.spinHeight.EditValue = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.spinHeight.Location = new System.Drawing.Point(237, 51);
            this.spinHeight.Name = "spinHeight";
            this.spinHeight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinHeight.Size = new System.Drawing.Size(60, 20);
            this.spinHeight.TabIndex = 8;
            // 
            // spinTop
            // 
            this.spinTop.EditValue = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.spinTop.Location = new System.Drawing.Point(237, 15);
            this.spinTop.Name = "spinTop";
            this.spinTop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinTop.Size = new System.Drawing.Size(60, 20);
            this.spinTop.TabIndex = 8;
            // 
            // spinWidth
            // 
            this.spinWidth.EditValue = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.spinWidth.Location = new System.Drawing.Point(106, 51);
            this.spinWidth.Name = "spinWidth";
            this.spinWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinWidth.Size = new System.Drawing.Size(60, 20);
            this.spinWidth.TabIndex = 8;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(15, 54);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(52, 14);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "窗体大小:";
            // 
            // spinLeft
            // 
            this.spinLeft.EditValue = new decimal(new int[] {
            522,
            0,
            0,
            0});
            this.spinLeft.Location = new System.Drawing.Point(106, 15);
            this.spinLeft.Name = "spinLeft";
            this.spinLeft.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinLeft.Size = new System.Drawing.Size(60, 20);
            this.spinLeft.TabIndex = 8;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(84, 54);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(16, 14);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "宽:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 18);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "弹出位置:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(215, 52);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(16, 14);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "高:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(84, 18);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(16, 14);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "左:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(215, 16);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(16, 14);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "上:";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(192, 15);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(52, 23);
            this.btnOpen.TabIndex = 8;
            this.btnOpen.Text = "...";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(250, 16);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(189, 20);
            this.txtFile.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 19);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "操作类型:";
            // 
            // UCtlHotspotParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "UCtlHotspotParam";
            this.Size = new System.Drawing.Size(473, 233);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxOperate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCtlDOColor)).EndInit();
            this.panelCtlDOColor.ResumeLayout(false);
            this.panelCtlDOColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinHeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinTop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinLeft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageCollectionLine;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnOpen;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtFile;
        private DevExpress.XtraEditors.PanelControl panelCtlDOColor;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SpinEdit spinTop;
        private DevExpress.XtraEditors.SpinEdit spinLeft;
        private DevExpress.XtraEditors.ComboBoxEdit cbxOperate;
        private DevExpress.XtraEditors.SpinEdit spinHeight;
        private DevExpress.XtraEditors.SpinEdit spinWidth;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl1;

    }
}
