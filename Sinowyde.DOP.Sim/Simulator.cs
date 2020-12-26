using Sinowyde.DOP.DataModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
namespace Sinowyde.DOP.Sim
{
    public partial class Simulator : Form
    {
        private SimService service = null;

        public Simulator()
        {
            InitializeComponent();
        }

        private void Simulator_Shown(object sender, EventArgs e)
        {
            service = new SimService();
            service.StartService();

            listVariable.BindData();
            treeDevice1.BindData();

        }

        private void Simulator_FormClosing(object sender, FormClosingEventArgs e)
        {
            service.StopService();
        }

        private void listVariable_DoubleClick(object sender, EventArgs e)
        {
            if (listVariable.SelectedIndices.Count <= 0)
                return;

            int index = listVariable.SelectedIndices[0];

            Simsets sim = new Simsets();
            sim.SimulateInfo = listVariable.VariableList[index].SimulateInfo;
            sim.VariableName = listVariable.Items[index].SubItems[4].Text;
            sim.ShowDialog();
            listVariable.VariableList[index].SimulateInfo = sim.SimulateInfo;
        }

        private void listVariable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = DateTime.Now.Second.ToString() + "-" + DateTime.Now.Millisecond.ToString();
            for (int i = 0; i < listVariable.VariableList.Count; i++)
            {
                if (listVariable.VariableList[i].SimulateInfo.IsOperated)
                {
                    if (listVariable.VariableList[i].SimulateInfo.Type == SimulateInfo.CType_Manual)
                    {
                         
                        listVariable.VariableList[i].SimulateInfo.IsOperated = false;
                        service.Send(listVariable.VariableList[i].RT);
                        listVariable.Items[i].SubItems[ListViewAdvanced.ColumnValue_Index].Text = listVariable.VariableList[i].RT.Value.ToString();
                        continue;
                    }
                    //毫秒
                    //if (DateTime.Now.Millisecond % listVariable.VariableList[i].SimulateInfo.Interval == 0)
                    //{
                    //    var rt = listVariable.VariableList[i].RT;
                    //    service.Send(rt);
                    //    listVariable.Items[i].SubItems[ListViewAdvanced.ColumnValue_Index].Text = rt.Value.ToString();
                    //}
                    //秒
                    if (DateTime.Now.Second % listVariable.VariableList[i].SimulateInfo.Interval == 0)
                    {
                        var rt = listVariable.VariableList[i].RT;
                        service.Send(rt);
                        listVariable.Items[i].SubItems[ListViewAdvanced.ColumnValue_Index].Text = rt.Value.ToString();
                    }
                }
            }
        }

        private void menuFile_Click(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;

            switch (menu.Name)
            {
                case "miSave":
                    listVariable.Save();
                    toolStripStatusLabel1.Text = "保存完毕";
                    break;
                case "mQuit":
                    Environment.Exit(0);
                    break;
                case "mDevice":
                    splitContainer1.Panel1Collapsed = splitContainer1.Panel1Collapsed ? false : true;
                    mDevice.Checked = mDevice.Checked ? false : true;
                    break;
                case "mVar":
                    splitContainer1.Panel2Collapsed = splitContainer1.Panel2Collapsed ? false : true;
                    mVar.Checked = mVar.Checked ? false : true;
                    break;
            }


        }

        private void treeDevice1_DoubleClick(object sender, EventArgs e)
        {
            if (null == treeDevice1.SelectedNode)
                return;

            var obj = treeDevice1.SelectedNode.Tag;
            if (obj == null)
                return;

            if (obj.GetType() == typeof(IOUnit))
            {
                IOUnit unit = obj as IOUnit;
                Simsets sim = new Simsets();
                sim.SimulateInfo = new SimulateInfo()
               {
                   Interval = 5,
                   Step = 1,
                   Type = 0,
                   RangeMax = 32767,
                   RangeMin = 0,
                   Value = 0,
                   IsOperated = false
               };

                sim.SimulateInfo.Interval = 2;
                sim.VariableName = unit.Name;
                sim.StartPosition = FormStartPosition.CenterScreen;

                if (sim.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    timer1.Enabled = false;
                    for (int i = 0; i < listVariable.VariableList.Count; i++)
                    {

                        if (listVariable.VariableList[i].IOUnitName == unit.Name)
                        {
                            listVariable.VariableList[i].SimulateInfo.IsOperated = true;
                            listVariable.VariableList[i].SimulateInfo = sim.SimulateInfo.Clone();

                        }
                    }
                    timer1.Enabled = true;
                }
            }
        }
    }
}
