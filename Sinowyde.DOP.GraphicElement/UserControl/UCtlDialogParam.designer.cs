namespace Sinowyde.DOP.GraphicElement
{
    partial class UCtlDialogParam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCtlDialogParam));
            this.imageCollectionLine = new DevExpress.Utils.ImageCollection(this.components);
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.spinTop = new DevExpress.XtraEditors.SpinEdit();
            this.spinLeft = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnOpen = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtFile = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.rbEquals = new DevExpress.XtraEditors.RadioGroup();
            this.uCtlGetVariable1 = new Sinowyde.DOP.GraphicElement.UCtlGetVariable();
            this.spinHeight = new DevExpress.XtraEditors.SpinEdit();
            this.spinWidth = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinTop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinLeft.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbEquals.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinHeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinWidth.Properties)).BeginInit();
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
            this.xtraTabControl1.Size = new System.Drawing.Size(410, 314);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupControl2);
            this.xtraTabPage1.Controls.Add(this.groupControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(404, 285);
            this.xtraTabPage1.Text = "基本属性";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.spinHeight);
            this.groupControl2.Controls.Add(this.spinWidth);
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Controls.Add(this.labelControl6);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Controls.Add(this.spinTop);
            this.groupControl2.Controls.Add(this.spinLeft);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.btnOpen);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.txtFile);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Location = new System.Drawing.Point(4, 120);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.ShowCaption = false;
            this.groupControl2.Size = new System.Drawing.Size(396, 162);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "选择颜色";
            // 
            // spinTop
            // 
            this.spinTop.EditValue = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.spinTop.Location = new System.Drawing.Point(266, 62);
            this.spinTop.Name = "spinTop";
            this.spinTop.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinTop.Size = new System.Drawing.Size(60, 20);
            this.spinTop.TabIndex = 8;
            // 
            // spinLeft
            // 
            this.spinLeft.EditValue = new decimal(new int[] {
            522,
            0,
            0,
            0});
            this.spinLeft.Location = new System.Drawing.Point(155, 62);
            this.spinLeft.Name = "spinLeft";
            this.spinLeft.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinLeft.Size = new System.Drawing.Size(60, 20);
            this.spinLeft.TabIndex = 8;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(60, 65);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "弹出位置:";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(317, 15);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(61, 23);
            this.btnOpen.TabIndex = 8;
            this.btnOpen.Text = "弹出窗口";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(133, 65);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(16, 14);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "左:";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(79, 16);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(232, 20);
            this.txtFile.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(244, 63);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(16, 14);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "上:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 19);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "操作类型:";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.rbEquals);
            this.groupControl1.Controls.Add(this.uCtlGetVariable1);
            this.groupControl1.Location = new System.Drawing.Point(4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(396, 111);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "选择颜色";
            // 
            // rbEquals
            // 
            this.rbEquals.Location = new System.Drawing.Point(96, 74);
            this.rbEquals.Name = "rbEquals";
            this.rbEquals.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.rbEquals.Properties.Appearance.Options.UseBackColor = true;
            this.rbEquals.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rbEquals.Properties.Columns = 4;
            this.rbEquals.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "等于0"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "等于1")});
            this.rbEquals.Size = new System.Drawing.Size(244, 22);
            this.rbEquals.TabIndex = 10;
            // 
            // uCtlGetVariable1
            // 
            this.uCtlGetVariable1.ButtonText = "点名";
            this.uCtlGetVariable1.Location = new System.Drawing.Point(20, 24);
            this.uCtlGetVariable1.Name = "uCtlGetVariable1";
            this.uCtlGetVariable1.SelectedVariable = ((Sinowyde.DOP.DataModel.Variable)(resources.GetObject("uCtlGetVariable1.SelectedVariable")));
            this.uCtlGetVariable1.Size = new System.Drawing.Size(357, 24);
            this.uCtlGetVariable1.TabIndex = 9;
            this.uCtlGetVariable1.VariableLabel = "变量名";
            this.uCtlGetVariable1.variableType = Sinowyde.DOP.DataModel.VariableType.DM;
            // 
            // spinHeight
            // 
            this.spinHeight.EditValue = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.spinHeight.Location = new System.Drawing.Point(266, 100);
            this.spinHeight.Name = "spinHeight";
            this.spinHeight.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinHeight.Size = new System.Drawing.Size(60, 20);
            this.spinHeight.TabIndex = 12;
            // 
            // spinWidth
            // 
            this.spinWidth.EditValue = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.spinWidth.Location = new System.Drawing.Point(155, 100);
            this.spinWidth.Name = "spinWidth";
            this.spinWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinWidth.Size = new System.Drawing.Size(60, 20);
            this.spinWidth.TabIndex = 13;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(60, 103);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(52, 14);
            this.labelControl7.TabIndex = 9;
            this.labelControl7.Text = "窗体大小:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(133, 103);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(16, 14);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "宽:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(244, 103);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(16, 14);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "高:";
            // 
            // UCtlDialogParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "UCtlDialogParam";
            this.Size = new System.Drawing.Size(406, 326);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinTop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinLeft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbEquals.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinHeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinWidth.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ImageCollection imageCollectionLine;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private UCtlGetVariable uCtlGetVariable1;
        private DevExpress.XtraEditors.RadioGroup rbEquals;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SpinEdit spinTop;
        private DevExpress.XtraEditors.SpinEdit spinLeft;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnOpen;
        private DevExpress.XtraEditors.TextEdit txtFile;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit spinHeight;
        private DevExpress.XtraEditors.SpinEdit spinWidth;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl1;

    }
}
