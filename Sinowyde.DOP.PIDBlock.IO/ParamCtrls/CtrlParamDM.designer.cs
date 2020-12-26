 
namespace Sinowyde.DOP.PIDBlock.IO 
{
    partial class CtrlParamDM
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cpp_Variables = new Sinowyde.DOP.PIDBlock.UserCtrl.CtrlVariable();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cpp_Variables);
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(360, 209);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "请选择数值量点";
            // 
            // cpp_Variables
            // 
            this.cpp_Variables.DefaultVariabelType = Sinowyde.DOP.DataModel.VariableType.DM;
            this.cpp_Variables.Location = new System.Drawing.Point(2, 24);
            this.cpp_Variables.Name = "cpp_Variables";
            this.cpp_Variables.Size = new System.Drawing.Size(354, 166);
            this.cpp_Variables.TabIndex = 2;
            this.cpp_Variables.VariableNumber = null;
            // 
            // CtrlParamDM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "CtrlParamDM";
            this.Size = new System.Drawing.Size(364, 214);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private UserCtrl.CtrlVariable cpp_Variables;
    }
}