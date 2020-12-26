namespace Sinowyde.DOP.Sama.Control.Frms
{
    partial class FrmStatistics
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
            this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.Caption = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButtonOK
            // 
            this.simpleButtonOK.Location = new System.Drawing.Point(410, 469);
            this.simpleButtonOK.Name = "simpleButtonOK";
            this.simpleButtonOK.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonOK.TabIndex = 1;
            this.simpleButtonOK.Text = "确定";
            this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
            // 
            // treeList
            // 
            this.treeList.Appearance.FixedLine.FontStyleDelta = System.Drawing.FontStyle.Strikeout;
            this.treeList.Appearance.FixedLine.Options.UseBackColor = true;
            this.treeList.Appearance.FixedLine.Options.UseBorderColor = true;
            this.treeList.Appearance.FixedLine.Options.UseFont = true;
            this.treeList.Appearance.FixedLine.Options.UseForeColor = true;
            this.treeList.Appearance.FixedLine.Options.UseImage = true;
            this.treeList.Appearance.FixedLine.Options.UseTextOptions = true;
            this.treeList.Appearance.HorzLine.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.treeList.Appearance.HorzLine.Options.UseBackColor = true;
            this.treeList.Appearance.HorzLine.Options.UseBorderColor = true;
            this.treeList.Appearance.HorzLine.Options.UseFont = true;
            this.treeList.Appearance.HorzLine.Options.UseForeColor = true;
            this.treeList.Appearance.HorzLine.Options.UseTextOptions = true;
            this.treeList.Appearance.TreeLine.BackColor = System.Drawing.Color.Silver;
            this.treeList.Appearance.TreeLine.BackColor2 = System.Drawing.Color.Silver;
            this.treeList.Appearance.TreeLine.BorderColor = System.Drawing.Color.Silver;
            this.treeList.Appearance.TreeLine.Options.UseBackColor = true;
            this.treeList.Appearance.TreeLine.Options.UseBorderColor = true;
            this.treeList.Appearance.TreeLine.Options.UseFont = true;
            this.treeList.Appearance.TreeLine.Options.UseForeColor = true;
            this.treeList.Appearance.TreeLine.Options.UseTextOptions = true;
            this.treeList.Appearance.VertLine.Options.UseBackColor = true;
            this.treeList.Appearance.VertLine.Options.UseBorderColor = true;
            this.treeList.Appearance.VertLine.Options.UseFont = true;
            this.treeList.Appearance.VertLine.Options.UseForeColor = true;
            this.treeList.Appearance.VertLine.Options.UseTextOptions = true;
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.Caption});
            this.treeList.CustomizationFormBounds = new System.Drawing.Rectangle(59, 516, 216, 166);
            this.treeList.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeList.FixedLineWidth = 12;
            this.treeList.Location = new System.Drawing.Point(0, 0);
            this.treeList.LookAndFeel.SkinName = "London Liquid Sky";
            this.treeList.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.treeList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeList.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeList.OptionsDragAndDrop.DropNodesMode = DevExpress.XtraTreeList.DropNodesMode.Standard;
            this.treeList.OptionsLayout.AddNewColumns = false;
            this.treeList.OptionsMenu.EnableColumnMenu = false;
            this.treeList.OptionsMenu.EnableFooterMenu = false;
            this.treeList.OptionsMenu.ShowAutoFilterRowItem = false;
            this.treeList.OptionsView.ShowColumns = false;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.Size = new System.Drawing.Size(564, 445);
            this.treeList.TabIndex = 2;
            // 
            // Caption
            // 
            this.Caption.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.Caption.AppearanceCell.BackColor2 = System.Drawing.Color.White;
            this.Caption.AppearanceCell.BorderColor = System.Drawing.Color.Transparent;
            this.Caption.AppearanceCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.Caption.AppearanceCell.Options.UseBackColor = true;
            this.Caption.AppearanceCell.Options.UseBorderColor = true;
            this.Caption.FieldName = "Caption";
            this.Caption.Name = "Caption";
            this.Caption.OptionsColumn.AllowEdit = false;
            this.Caption.OptionsColumn.AllowFocus = false;
            this.Caption.OptionsColumn.AllowSize = false;
            this.Caption.OptionsColumn.AllowSort = false;
            this.Caption.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.Caption.OptionsColumn.ShowInCustomizationForm = false;
            this.Caption.OptionsColumn.ShowInExpressionEditor = false;
            this.Caption.Visible = true;
            this.Caption.VisibleIndex = 0;
            // 
            // FrmStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 502);
            this.Controls.Add(this.treeList);
            this.Controls.Add(this.simpleButtonOK);
            this.MaximumSize = new System.Drawing.Size(580, 540);
            this.MinimumSize = new System.Drawing.Size(580, 540);
            this.Name = "FrmStatistics";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "算法块统计";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmStatistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn Caption;
    }
}