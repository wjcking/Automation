using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.PIDAlgorithm;
using Sinowyde.DOP.PIDBlock;
using Sinowyde.DOP.PIDBlock.Xml;

namespace Sinowyde.DOP.Sama.Control.Frms
{
    public partial class FrmSearch : XtraForm
    {
        public FrmSearch()
        {
            InitializeComponent();
        }

        private int GetVariableType()
        {
            int type = -1;
            switch (this.comboBoxEditVariableType.SelectedItem.ToString())
            {
                case "所有类型":
                    break;
                case "模拟量":
                    type = 0;
                    break;
                case "数字量":
                    type = 1;
                    break;
                case "字符串":
                    type = 2;
                    break;
            }
            return type;
        }

        private void Query()
        {
            var variableName = this.textEditVariableName.Text;
            var listVariable = DOPDataLogic.Instance().SearchVariableBySama(GetVariableType(), variableName);

            PIDSearchManager.Instance().ClearResult();
            var docs = PIDDocManager.Instance().Documents;
            foreach (var doc in docs)
            {
                var blocks = doc.Blocks;
                foreach (var block in blocks)
                {
                    var variableNumber = block.Algorithm.GetBindVarNumber();//是ASET,DEST,AI,AO,DI,DO,AM,DM 这八种,子类算法已经重载
                    if (!string.IsNullOrEmpty(variableNumber))
                    {
                        var variable = listVariable.FirstOrDefault(v => v.Number.Equals(variableNumber));
                        if (null != variable)
                        {
                            var result = new PIDSearchResult();
                            result.GroupIndex = block.Algorithm.GroupIndex;
                            result.IndexInGroup = block.Algorithm.IndexInGroup;
                            var typeStr = block.Algorithm.AlgType.Split('.');
                            result.Group = typeStr[3];
                            result.Alg = block.Algorithm.AlgName;
                            result.Number = variable.Number;
                            result.Name = variable.Name;
                            result.VariableType = GetVariableType(variable.VariableType);
                            PIDSearchManager.Instance().AddResult(result);
                        }
                    }
                }
            }
        }

        private string GetVariableType(VariableType variableType)
        {
            var str = string.Empty;
            switch (variableType)
            {
                case VariableType.AM:
                    str = "模拟量";
                    break;
                case VariableType.DM:
                    str = "数字量";
                    break;
                case VariableType.StringM:
                    str = "字符串";
                    break;
            }
            return str;
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            using (new WaitDialogForm("请等待", "查询中...", new Size(200, 50), ParentForm))
            {
                Query();
            }
            this.DialogResult = DialogResult.OK;
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmSearch_Load(object sender, EventArgs e)
        {
            this.comboBoxEditVariableType.Properties.Items.AddRange(new object[] { "所有类型", "模拟量", "数字量", "字符串" });
            this.comboBoxEditVariableType.SelectedIndex = 0;
        }
    }
}
