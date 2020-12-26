namespace Sinowyde.DOP.PIDBlock.Test2
{
    partial class Form1
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
            this.comboBoxEditAlgorithms = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButtonStepCalcu = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonReset = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.simpleButtonRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.panelControlGoView = new DevExpress.XtraEditors.PanelControl();
            this.gridControlOutput = new DevExpress.XtraGrid.GridControl();
            this.gridViewOutput = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControlInput = new DevExpress.XtraGrid.GridControl();
            this.gridViewInput = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControlParam = new DevExpress.XtraGrid.GridControl();
            this.gridViewParam = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.checkEditInput = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditAlgorithms.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditInput.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEditAlgorithms
            // 
            this.comboBoxEditAlgorithms.Location = new System.Drawing.Point(113, 12);
            this.comboBoxEditAlgorithms.Name = "comboBoxEditAlgorithms";
            this.comboBoxEditAlgorithms.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditAlgorithms.Size = new System.Drawing.Size(167, 20);
            this.comboBoxEditAlgorithms.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择算法块";
            // 
            // simpleButtonStepCalcu
            // 
            this.simpleButtonStepCalcu.Location = new System.Drawing.Point(338, 9);
            this.simpleButtonStepCalcu.Name = "simpleButtonStepCalcu";
            this.simpleButtonStepCalcu.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonStepCalcu.TabIndex = 5;
            this.simpleButtonStepCalcu.Text = "单步计算";
            this.simpleButtonStepCalcu.Click += new System.EventHandler(this.simpleButtonStepCalcu_Click);
            // 
            // simpleButtonReset
            // 
            this.simpleButtonReset.Location = new System.Drawing.Point(451, 9);
            this.simpleButtonReset.Name = "simpleButtonReset";
            this.simpleButtonReset.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonReset.TabIndex = 6;
            this.simpleButtonReset.Text = "恢复初值";
            this.simpleButtonReset.Click += new System.EventHandler(this.simpleButtonReset_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.checkEditInput);
            this.splitContainer.Panel1.Controls.Add(this.simpleButtonRefresh);
            this.splitContainer.Panel1.Controls.Add(this.simpleButtonReset);
            this.splitContainer.Panel1.Controls.Add(this.simpleButtonStepCalcu);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1.Controls.Add(this.comboBoxEditAlgorithms);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelControlGoView);
            this.splitContainer.Panel2.Controls.Add(this.gridControlOutput);
            this.splitContainer.Panel2.Controls.Add(this.gridControlInput);
            this.splitContainer.Panel2.Controls.Add(this.gridControlParam);
            this.splitContainer.Size = new System.Drawing.Size(1020, 606);
            this.splitContainer.SplitterDistance = 44;
            this.splitContainer.TabIndex = 0;
            // 
            // simpleButtonRefresh
            // 
            this.simpleButtonRefresh.Location = new System.Drawing.Point(836, 9);
            this.simpleButtonRefresh.Name = "simpleButtonRefresh";
            this.simpleButtonRefresh.Size = new System.Drawing.Size(136, 23);
            this.simpleButtonRefresh.TabIndex = 6;
            this.simpleButtonRefresh.Text = "弹出界面设置值后刷新";
            this.simpleButtonRefresh.Click += new System.EventHandler(this.simpleButtonRefresh_Click);
            // 
            // panelControlGoView
            // 
            this.panelControlGoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlGoView.Location = new System.Drawing.Point(845, 0);
            this.panelControlGoView.Name = "panelControlGoView";
            this.panelControlGoView.Size = new System.Drawing.Size(175, 558);
            this.panelControlGoView.TabIndex = 3;
            // 
            // gridControlOutput
            // 
            this.gridControlOutput.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControlOutput.Location = new System.Drawing.Point(526, 0);
            this.gridControlOutput.MainView = this.gridViewOutput;
            this.gridControlOutput.Name = "gridControlOutput";
            this.gridControlOutput.Size = new System.Drawing.Size(319, 558);
            this.gridControlOutput.TabIndex = 2;
            this.gridControlOutput.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOutput});
            // 
            // gridViewOutput
            // 
            this.gridViewOutput.GridControl = this.gridControlOutput;
            this.gridViewOutput.Name = "gridViewOutput";
            // 
            // gridControlInput
            // 
            this.gridControlInput.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControlInput.Location = new System.Drawing.Point(248, 0);
            this.gridControlInput.MainView = this.gridViewInput;
            this.gridControlInput.Name = "gridControlInput";
            this.gridControlInput.Size = new System.Drawing.Size(278, 558);
            this.gridControlInput.TabIndex = 1;
            this.gridControlInput.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewInput});
            // 
            // gridViewInput
            // 
            this.gridViewInput.GridControl = this.gridControlInput;
            this.gridViewInput.Name = "gridViewInput";
            // 
            // gridControlParam
            // 
            this.gridControlParam.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControlParam.Location = new System.Drawing.Point(0, 0);
            this.gridControlParam.MainView = this.gridViewParam;
            this.gridControlParam.Name = "gridControlParam";
            this.gridControlParam.Size = new System.Drawing.Size(248, 558);
            this.gridControlParam.TabIndex = 0;
            this.gridControlParam.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewParam});
            // 
            // gridViewParam
            // 
            this.gridViewParam.GridControl = this.gridControlParam;
            this.gridViewParam.Name = "gridViewParam";
            // 
            // checkEditInput
            // 
            this.checkEditInput.Location = new System.Drawing.Point(565, 9);
            this.checkEditInput.Name = "checkEditInput";
            this.checkEditInput.Properties.Caption = "允许输入";
            this.checkEditInput.Size = new System.Drawing.Size(125, 19);
            this.checkEditInput.TabIndex = 7;
            this.checkEditInput.CheckedChanged += new System.EventHandler(this.checkEditInput_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 606);
            this.Controls.Add(this.splitContainer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditAlgorithms.Properties)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditInput.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditAlgorithms;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonStepCalcu;
        private DevExpress.XtraEditors.SimpleButton simpleButtonReset;
        private System.Windows.Forms.SplitContainer splitContainer;
        private DevExpress.XtraGrid.GridControl gridControlParam;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewParam;
        private DevExpress.XtraGrid.GridControl gridControlOutput;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOutput;
        private DevExpress.XtraGrid.GridControl gridControlInput;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInput;
        private DevExpress.XtraEditors.PanelControl panelControlGoView;
        private DevExpress.XtraEditors.SimpleButton simpleButtonRefresh;
        private DevExpress.XtraEditors.CheckEdit checkEditInput;


    }
}

