namespace Sinowyde.DOP.Sim
{
    partial class Simulator
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeDevice1 = new Sinowyde.DOP.Sim.TreeDevice(this.components);
            this.listVariable = new Sinowyde.DOP.Sim.ListViewAdvanced();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.试图VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.mVar = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 2);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeDevice1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listVariable);
            this.splitContainer1.Size = new System.Drawing.Size(593, 448);
            this.splitContainer1.SplitterDistance = 130;
            this.splitContainer1.TabIndex = 10;
            // 
            // treeDevice1
            // 
            this.treeDevice1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDevice1.Location = new System.Drawing.Point(0, 0);
            this.treeDevice1.Name = "treeDevice1";
            this.treeDevice1.Size = new System.Drawing.Size(130, 448);
            this.treeDevice1.TabIndex = 0;
            this.treeDevice1.DoubleClick += new System.EventHandler(this.treeDevice1_DoubleClick);
            // 
            // listVariable
            // 
            this.listVariable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listVariable.FullRowSelect = true;
            this.listVariable.GridLines = true;
            this.listVariable.Location = new System.Drawing.Point(0, 0);
            this.listVariable.Name = "listVariable";
            this.listVariable.Size = new System.Drawing.Size(459, 448);
            this.listVariable.TabIndex = 0;
            this.listVariable.UseCompatibleStateImageBehavior = false;
            this.listVariable.View = System.Windows.Forms.View.Details;
            this.listVariable.SelectedIndexChanged += new System.EventHandler(this.listVariable_SelectedIndexChanged);
            this.listVariable.DoubleClick += new System.EventHandler(this.listVariable_DoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 500);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(617, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel1.Text = "就绪";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.试图VToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(617, 25);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSave,
            this.mQuit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(58, 21);
            this.menuFile.Text = "文件(&F)";
            this.menuFile.Click += new System.EventHandler(this.menuFile_Click);
            // 
            // miSave
            // 
            this.miSave.Name = "miSave";
            this.miSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.miSave.Size = new System.Drawing.Size(144, 22);
            this.miSave.Text = "保存";
            this.miSave.Click += new System.EventHandler(this.menuFile_Click);
            // 
            // mQuit
            // 
            this.mQuit.Name = "mQuit";
            this.mQuit.Size = new System.Drawing.Size(144, 22);
            this.mQuit.Text = "退出(&Q)";
            this.mQuit.Click += new System.EventHandler(this.menuFile_Click);
            // 
            // 试图VToolStripMenuItem
            // 
            this.试图VToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mDevice,
            this.mVar});
            this.试图VToolStripMenuItem.Name = "试图VToolStripMenuItem";
            this.试图VToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.试图VToolStripMenuItem.Text = "试图(&V)";
            // 
            // mDevice
            // 
            this.mDevice.Checked = true;
            this.mDevice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mDevice.Name = "mDevice";
            this.mDevice.Size = new System.Drawing.Size(129, 22);
            this.mDevice.Text = "设备栏(&D)";
            this.mDevice.Click += new System.EventHandler(this.menuFile_Click);
            // 
            // mVar
            // 
            this.mVar.Checked = true;
            this.mVar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mVar.Name = "mVar";
            this.mVar.Size = new System.Drawing.Size(129, 22);
            this.mVar.Text = "点栏(&P)";
            this.mVar.Click += new System.EventHandler(this.menuFile_Click);
            // 
            // Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 522);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Simulator";
            this.Text = "模拟数据";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Simulator_FormClosing);
            this.Shown += new System.EventHandler(this.Simulator_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ListViewAdvanced listVariable;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem 试图VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mDevice;
        private System.Windows.Forms.ToolStripMenuItem mVar;
        private System.Windows.Forms.ToolStripMenuItem mQuit;
        private TreeDevice treeDevice1;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

