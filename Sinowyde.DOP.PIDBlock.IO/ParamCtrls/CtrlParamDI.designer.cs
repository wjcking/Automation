 
namespace Sinowyde.DOP.PIDBlock.IO 
{
    partial class CtrlParamDI
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
            this.groupPid = new DevExpress.XtraEditors.GroupControl();
            this.cpp_Variables = new Sinowyde.DOP.PIDBlock.UserCtrl.CtrlVariable();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.cpp_Variables);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 227);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "请选择数字输入点";
            // 
            // cpp_Variables
            // 
            this.cpp_Variables.DefaultVariabelType = Sinowyde.DOP.DataModel.VariableType.DM;
            this.cpp_Variables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cpp_Variables.Location = new System.Drawing.Point(2, 22);
            this.cpp_Variables.Name = "cpp_Variables";
            this.cpp_Variables.Size = new System.Drawing.Size(356, 203);
            this.cpp_Variables.TabIndex = 1;
            this.cpp_Variables.VariableNumber = null;
            // 
            // CtrlParamDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamDI";
            this.Size = new System.Drawing.Size(364, 231);
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private DevExpress.XtraEditors.GroupControl groupPid;
        private UserCtrl.CtrlVariable cpp_Variables;
    }
}