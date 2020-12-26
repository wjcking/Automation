 
namespace Sinowyde.DOP.PIDBlock.IO 
{
    partial class CtrlParamAI
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
            this.ctrlPointPicker1 = new Sinowyde.DOP.PIDBlock.UserCtrl.CtrlVariable();
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).BeginInit();
            this.groupPid.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPid
            // 
            this.groupPid.Controls.Add(this.ctrlPointPicker1);
            this.groupPid.Location = new System.Drawing.Point(2, 2);
            this.groupPid.Name = "groupPid";
            this.groupPid.Size = new System.Drawing.Size(360, 197);
            this.groupPid.TabIndex = 5;
            this.groupPid.Text = "AI:ƒ£ƒ‚¡ø ‰»Î";
            // 
            // ctrlPointPicker1
            // 
            this.ctrlPointPicker1.Location = new System.Drawing.Point(2, 21);
            this.ctrlPointPicker1.Name = "ctrlPointPicker1";
            this.ctrlPointPicker1.Size = new System.Drawing.Size(356, 166);
            this.ctrlPointPicker1.TabIndex = 1;
            this.ctrlPointPicker1.VariableNumber = null;
            this.ctrlPointPicker1.DefaultVarDirectionType = DataModel.VarDirectionType.Read;

            // 
            // CtrlParamAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPid);
            this.Name = "CtrlParamAI";
            this.Size = new System.Drawing.Size(367, 204);
            ((System.ComponentModel.ISupportInitialize)(this.groupPid)).EndInit();
            this.groupPid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private DevExpress.XtraEditors.GroupControl groupPid;
        private UserCtrl.CtrlVariable ctrlPointPicker1;
    }
}