using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.DataModel;

namespace Sinowyde.DOP.GraphicElement
{
    public partial class UCtlGetVariable : XtraUserControl
    {
        //定义委托
        public delegate void BtnClickHandle(object sender, EventArgs e);
        //定义事件
        public event BtnClickHandle BtnClicked;

        private VariableType variableTypes = VariableType.AM;
        public VariableType variableType 
        {
            get
            {
                return variableTypes;
            }
            set
            {
                variableTypes = value;
            }
        }


        private Variable selectedVariable = new Variable();
        public Variable SelectedVariable
        {
            get
            {
                return selectedVariable;
            }
            set
            {
                selectedVariable = value;
                if (value != null)
                    this.lblVarValue.Text = value.Name;
            }
        }

        public string VariableLabel
        {
            get
            {
                return this.lblVarName.Text;
            }
            set
            {
                this.lblVarName.Text = value;
            }
        }
        public string ButtonText
        {
            get
            {
                return this.btnPoint.Text;
            }
            set
            {
                this.btnPoint.Text = value;
            }
        }

        public UCtlGetVariable()
        {
            InitializeComponent();
        }

        private void UCtlGetVariable_Load(object sender, EventArgs e)
        {

        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            frmVariable frm = new frmVariable(variableType);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                SelectedVariable = frm.SelectedVariables;
                if (BtnClicked != null)
                    BtnClicked(sender, e);
            }
            frm.Dispose();
        }

        private void lblVarName_Resize(object sender, EventArgs e)
        {
            this.panelControl1.Width = this.lblVarName.Width + 10;
        }
    }
}
