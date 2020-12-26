namespace Sinowyde.DOP.Graph
{
    partial class UCtlGraphRun
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
            this.goViewRun = new Northwoods.Go.GoView();
            this.SuspendLayout();
            // 
            // goViewRun
            // 
            this.goViewRun.AllowCopy = false;
            this.goViewRun.AllowDelete = false;
            this.goViewRun.AllowDragOut = false;
            this.goViewRun.AllowDrop = false;
            this.goViewRun.AllowEdit = false;
            this.goViewRun.AllowInsert = false;
            this.goViewRun.AllowKey = false;
            this.goViewRun.AllowLink = false;
            this.goViewRun.AllowMove = false;
            this.goViewRun.AllowReshape = false;
            this.goViewRun.AllowResize = false;
            this.goViewRun.AllowSelect = false;
            this.goViewRun.ArrowMoveLarge = 10F;
            this.goViewRun.ArrowMoveSmall = 1F;
            this.goViewRun.BackColor = System.Drawing.Color.White;
            this.goViewRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.goViewRun.Location = new System.Drawing.Point(0, 0);
            this.goViewRun.Name = "goViewRun";
            this.goViewRun.Size = new System.Drawing.Size(1315, 681);
            this.goViewRun.TabIndex = 1;
            this.goViewRun.Text = "ViewRun";
            this.goViewRun.Visible = false;
            // 
            // UCtlGraphRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.goViewRun);
            this.Name = "UCtlGraphRun";
            this.Size = new System.Drawing.Size(1315, 681);
            this.Load += new System.EventHandler(this.UCtlGraphRun_Load);
            this.VisibleChanged += new System.EventHandler(this.UCtlGraphRun_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private Northwoods.Go.GoView goViewRun;
    }
}
