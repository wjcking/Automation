using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinowyde.DOP.Sim
{
    public partial class Simsets : Form
    {
        public Simsets()
        {
            InitializeComponent();

        }

        public string VariableName { get; set; }
        public SimulateInfo SimulateInfo { get; set; }

        private void Simsets_Shown(object sender, EventArgs e)
        {
            lbName.Text = VariableName;

            drpSimType.SelectedIndex = SimulateInfo.Type;
            nManual.Value = (decimal)SimulateInfo.Value;
            nInternal.Value = SimulateInfo.Interval;
            nStep.Value = (decimal)SimulateInfo.Step;
            nRangeMin.Value = SimulateInfo.RangeMin;
            nRangeMax.Value = SimulateInfo.RangeMax;
        }


        private void btnAuto_Click(object sender, EventArgs e)
        {
            SimulateInfo.IsOperated = true;
            SimulateInfo.Type = (short)drpSimType.SelectedIndex;
            SimulateInfo.Value = (double)nManual.Value;
            SimulateInfo.Interval = (int)nInternal.Value;
            SimulateInfo.Step = (double)nStep.Value;
            SimulateInfo.RangeMin = (int)nRangeMin.Value;
            SimulateInfo.RangeMax = (int)nRangeMax.Value;
        }

        private void drpSimType_SelectedIndexChanged(object sender, EventArgs e)
        {
            nManual.Enabled = drpSimType.SelectedIndex < 1 ? true : false;
            nInternal.Enabled = drpSimType.SelectedIndex < 1 ? false : true;
        }
    }
}
