
using Sinowyde.DOP.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace Sinowyde.DOP.Sim
{
    public partial class ListViewAdvanced : ListView
    {
        public const int ColumnValue_Index = 5;
        internal const string File_Variable = "variable.sav";

        public ListViewAdvanced()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

        }

        public IList<VariableExtend> VariableList { get; private set; }

        private void BindExtractOptions()
        {
            if (SelectedIndices.Count <= 0)
                return;

            int index = SelectedIndices[0];

            Refresh();
        }

        internal void BindData()
        {
            //try
            //{
            Items.Clear();
            Columns.Clear();

            string[] cVar = new string[17] { "ID", "Device", "IOUnit", "Number", "Name", "Value", "Unit", "Ratio", "Bias", "IsCompressed ", "CompressRatio", "IsTransfer", "MaxPeriod", "DirectionType", "DataType", "Address", "VariableType" };

            foreach (string s in cVar)
            {
                ColumnHeader columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
                columnHeader1.Text = s;
                Columns.Add(columnHeader1);
            }


            if (File.Exists(File_Variable))
            {
                string json = File.ReadAllText(File_Variable, Encoding.Default);

                VariableList = JsonConvert.DeserializeObject<IList<VariableExtend>>(json);
                var obj = JsonConvert.DeserializeObject(json);
            }

            if (VariableList == null)
                VariableList = VariableExtend.GetList();

            foreach (var v in VariableList)
                v.SimulateInfo.IsOperated = true;

            for (int i = 0; i < VariableList.Count; i++)
            {
                Items.Add(VariableList[i].ID.ToString());
                
                Items[i].SubItems.Add(VariableList[i].DeviceName);
                Items[i].SubItems.Add(VariableList[i].IOUnitName);
                Items[i].SubItems.Add(VariableList[i].Number.ToString());
                Items[i].SubItems.Add(VariableList[i].Name.ToString());
                Items[i].SubItems.Add("");

                Items[i].SubItems.Add(String.IsNullOrEmpty(VariableList[i].Unit) ? string.Empty :VariableList[i].Unit.ToString());
                Items[i].SubItems.Add(VariableList[i].Ratio.ToString());
                Items[i].SubItems.Add(VariableList[i].Bias.ToString());
                Items[i].SubItems.Add(VariableList[i].IsCompressed.ToString());
                Items[i].SubItems.Add(VariableList[i].CompressRatio.ToString());
                Items[i].SubItems.Add(VariableList[i].IsTransfer.ToString());
                Items[i].SubItems.Add(VariableList[i].MaxPeriod.ToString());
                Items[i].SubItems.Add(VariableList[i].DirectionType.ToString());
                // Items[i].SubItems.Add(list[i].DataType.ToString());
                Items[i].SubItems.Add("Datatype");
                Items[i].SubItems.Add(VariableList[i].Address.ToString());
                Items[i].SubItems.Add(VariableList[i].VariableType.ToString());
           //     Items[i].BackColor = System.Drawing.Color.Yellow;
            }

            //}
            //catch (Exception e)
            //{
            //    Items.Add(e.Message);
            //}
        }


        private void ListViewAdvanced_DoubleClick(object sender, EventArgs e)
        {

        }

        private void ListViewAdvanced_KeyUp(object sender, KeyEventArgs e)
        {
            if (SelectedIndices.Count <= 0)
                return;

            int index = SelectedIndices[0];

        }

        private void ListViewAdvanced_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

        }



        internal void Save()
        {
            string json = JsonConvert.SerializeObject(VariableList, Formatting.Indented);

            File.WriteAllText(File_Variable, json, System.Text.Encoding.Default);

        }
    }
}
