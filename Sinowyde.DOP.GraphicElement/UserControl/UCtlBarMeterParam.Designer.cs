namespace Sinowyde.DOP.GraphicElement
{
    partial class UCtlBarMeterParam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCtlBarMeterParam));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl8 = new DevExpress.XtraEditors.GroupControl();
            this.cbBarOption = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.spinMax = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.spinMin = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.spinFillMax = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.spinFillMin = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl37 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.uCtlGetVarBar = new Sinowyde.DOP.GraphicElement.UCtlGetVariable();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.colorForeColor = new DevExpress.XtraEditors.ColorEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.colorBackColor = new DevExpress.XtraEditors.ColorEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.rbDirection = new DevExpress.XtraEditors.RadioGroup();
            this.xtraTabPageFill = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.uCtlValueColorFill = new Sinowyde.DOP.GraphicElement.UCtlValueColor();
            this.uCtlGetVarFill = new Sinowyde.DOP.GraphicElement.UCtlGetVariable();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).BeginInit();
            this.groupControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbBarOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinFillMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinFillMin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorForeColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBackColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbDirection.Properties)).BeginInit();
            this.xtraTabPageFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(429, 399);
            this.xtraTabControl1.TabIndex = 2;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPageFill});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupControl8);
            this.xtraTabPage1.Controls.Add(this.groupControl3);
            this.xtraTabPage1.Controls.Add(this.groupControl6);
            this.xtraTabPage1.Controls.Add(this.groupControl2);
            this.xtraTabPage1.Controls.Add(this.groupControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(423, 370);
            this.xtraTabPage1.Text = "设置";
            // 
            // groupControl8
            // 
            this.groupControl8.Controls.Add(this.cbBarOption);
            this.groupControl8.Location = new System.Drawing.Point(4, 304);
            this.groupControl8.Name = "groupControl8";
            this.groupControl8.Size = new System.Drawing.Size(414, 61);
            this.groupControl8.TabIndex = 3;
            this.groupControl8.Text = "动态属性";
            // 
            // cbBarOption
            // 
            this.cbBarOption.Location = new System.Drawing.Point(16, 32);
            this.cbBarOption.Name = "cbBarOption";
            this.cbBarOption.Properties.Caption = "改变颜色";
            this.cbBarOption.Size = new System.Drawing.Size(74, 19);
            this.cbBarOption.TabIndex = 2;
            this.cbBarOption.CheckStateChanged += new System.EventHandler(this.cbBarOption_CheckStateChanged);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.spinMax);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Controls.Add(this.spinMin);
            this.groupControl3.Controls.Add(this.labelControl4);
            this.groupControl3.Controls.Add(this.spinFillMax);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Controls.Add(this.spinFillMin);
            this.groupControl3.Controls.Add(this.labelControl37);
            this.groupControl3.Location = new System.Drawing.Point(4, 208);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(414, 91);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "属性值";
            // 
            // spinMax
            // 
            this.spinMax.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinMax.Location = new System.Drawing.Point(291, 61);
            this.spinMax.Name = "spinMax";
            this.spinMax.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinMax.Properties.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.spinMax.Properties.MinValue = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.spinMax.Size = new System.Drawing.Size(84, 20);
            this.spinMax.TabIndex = 15;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(216, 64);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 14);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "最大值：";
            // 
            // spinMin
            // 
            this.spinMin.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinMin.Location = new System.Drawing.Point(93, 61);
            this.spinMin.Name = "spinMin";
            this.spinMin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinMin.Properties.MaxValue = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.spinMin.Properties.MinValue = new decimal(new int[] {
            999999999,
            0,
            0,
            -2147483648});
            this.spinMin.Size = new System.Drawing.Size(84, 20);
            this.spinMin.TabIndex = 15;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(18, 64);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "最小值：";
            // 
            // spinFillMax
            // 
            this.spinFillMax.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinFillMax.Location = new System.Drawing.Point(291, 34);
            this.spinFillMax.Name = "spinFillMax";
            this.spinFillMax.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinFillMax.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinFillMax.Size = new System.Drawing.Size(84, 20);
            this.spinFillMax.TabIndex = 15;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(216, 37);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 14);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "最大填充值：";
            // 
            // spinFillMin
            // 
            this.spinFillMin.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinFillMin.Location = new System.Drawing.Point(93, 34);
            this.spinFillMin.Name = "spinFillMin";
            this.spinFillMin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinFillMin.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinFillMin.Size = new System.Drawing.Size(84, 20);
            this.spinFillMin.TabIndex = 15;
            // 
            // labelControl37
            // 
            this.labelControl37.Location = new System.Drawing.Point(18, 37);
            this.labelControl37.Name = "labelControl37";
            this.labelControl37.Size = new System.Drawing.Size(72, 14);
            this.labelControl37.TabIndex = 14;
            this.labelControl37.Text = "最小填充值：";
            // 
            // groupControl6
            // 
            this.groupControl6.Controls.Add(this.uCtlGetVarBar);
            this.groupControl6.Location = new System.Drawing.Point(4, 4);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(414, 67);
            this.groupControl6.TabIndex = 1;
            this.groupControl6.Text = "连接数据点";
            // 
            // uCtlGetVarBar
            // 
            this.uCtlGetVarBar.ButtonText = "点名";
            this.uCtlGetVarBar.Location = new System.Drawing.Point(16, 32);
            this.uCtlGetVarBar.Name = "uCtlGetVarBar";
            this.uCtlGetVarBar.SelectedVariable = ((Sinowyde.DOP.DataModel.Variable)(resources.GetObject("uCtlGetVarBar.SelectedVariable")));
            this.uCtlGetVarBar.Size = new System.Drawing.Size(380, 24);
            this.uCtlGetVarBar.TabIndex = 0;
            this.uCtlGetVarBar.VariableLabel = "变量名";
            this.uCtlGetVarBar.variableType = Sinowyde.DOP.DataModel.VariableType.AM;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.colorForeColor);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.colorBackColor);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Location = new System.Drawing.Point(4, 145);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(414, 58);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "选择颜色";
            // 
            // colorForeColor
            // 
            this.colorForeColor.EditValue = System.Drawing.Color.Empty;
            this.colorForeColor.Location = new System.Drawing.Point(278, 30);
            this.colorForeColor.Name = "colorForeColor";
            this.colorForeColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorForeColor.Size = new System.Drawing.Size(86, 20);
            this.colorForeColor.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(227, 32);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "前景色：";
            // 
            // colorBackColor
            // 
            this.colorBackColor.EditValue = System.Drawing.Color.Empty;
            this.colorBackColor.Location = new System.Drawing.Point(75, 31);
            this.colorBackColor.Name = "colorBackColor";
            this.colorBackColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorBackColor.Size = new System.Drawing.Size(86, 20);
            this.colorBackColor.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "背景色：";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.rbDirection);
            this.groupControl1.Location = new System.Drawing.Point(4, 76);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(414, 64);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "显示方向";
            // 
            // rbDirection
            // 
            this.rbDirection.Location = new System.Drawing.Point(92, 31);
            this.rbDirection.Name = "rbDirection";
            this.rbDirection.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.rbDirection.Properties.Appearance.Options.UseBackColor = true;
            this.rbDirection.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rbDirection.Properties.Columns = 4;
            this.rbDirection.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "垂直方向"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "水平方向")});
            this.rbDirection.Size = new System.Drawing.Size(304, 22);
            this.rbDirection.TabIndex = 1;
            // 
            // xtraTabPageFill
            // 
            this.xtraTabPageFill.Controls.Add(this.groupControl7);
            this.xtraTabPageFill.Name = "xtraTabPageFill";
            this.xtraTabPageFill.PageVisible = false;
            this.xtraTabPageFill.Size = new System.Drawing.Size(423, 370);
            this.xtraTabPageFill.Text = "填充选项";
            // 
            // groupControl7
            // 
            this.groupControl7.Controls.Add(this.uCtlValueColorFill);
            this.groupControl7.Controls.Add(this.uCtlGetVarFill);
            this.groupControl7.Location = new System.Drawing.Point(4, 4);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.Size = new System.Drawing.Size(415, 361);
            this.groupControl7.TabIndex = 21;
            this.groupControl7.Text = "连接数据点";
            // 
            // uCtlValueColorFill
            // 
            this.uCtlValueColorFill.Location = new System.Drawing.Point(35, 83);
            this.uCtlValueColorFill.Name = "uCtlValueColorFill";
            this.uCtlValueColorFill.Size = new System.Drawing.Size(176, 144);
            this.uCtlValueColorFill.TabIndex = 1;
            this.uCtlValueColorFill.VariableColor = ((System.Collections.Generic.List<System.Drawing.Color>)(resources.GetObject("uCtlValueColorFill.VariableColor")));
            this.uCtlValueColorFill.VariableValue = ((System.Collections.Generic.IList<string>)(resources.GetObject("uCtlValueColorFill.VariableValue")));
            // 
            // uCtlGetVarFill
            // 
            this.uCtlGetVarFill.ButtonText = "点名";
            this.uCtlGetVarFill.Location = new System.Drawing.Point(23, 35);
            this.uCtlGetVarFill.Name = "uCtlGetVarFill";
            this.uCtlGetVarFill.SelectedVariable = ((Sinowyde.DOP.DataModel.Variable)(resources.GetObject("uCtlGetVarFill.SelectedVariable")));
            this.uCtlGetVarFill.Size = new System.Drawing.Size(342, 24);
            this.uCtlGetVarFill.TabIndex = 0;
            this.uCtlGetVarFill.VariableLabel = "变量名";
            this.uCtlGetVarFill.variableType = Sinowyde.DOP.DataModel.VariableType.AM;
            // 
            // UCtlBarMeterParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "UCtlBarMeterParam";
            this.Size = new System.Drawing.Size(426, 396);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).EndInit();
            this.groupControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbBarOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinMin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinFillMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinFillMin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorForeColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBackColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbDirection.Properties)).EndInit();
            this.xtraTabPageFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.CheckEdit cbBarOption;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SpinEdit spinMax;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SpinEdit spinMin;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SpinEdit spinFillMax;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit spinFillMin;
        private DevExpress.XtraEditors.LabelControl labelControl37;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private UCtlGetVariable uCtlGetVarBar;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.ColorEdit colorForeColor;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ColorEdit colorBackColor;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.RadioGroup rbDirection;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageFill;
        private DevExpress.XtraEditors.GroupControl groupControl7;
        private UCtlGetVariable uCtlGetVarFill;
        private UCtlValueColor uCtlValueColorFill;
        private DevExpress.XtraEditors.GroupControl groupControl8;
    }
}
