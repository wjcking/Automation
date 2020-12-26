using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils.Menu;

namespace Sinowyde.DOP.DataModel.Control
{
    public partial class Form_CalcVariabel : DevExpress.XtraEditors.XtraForm
    {
        public Variable Entity;
        public Form_CalcVariabel(Variable var)
        {
            InitializeComponent();
            Entity = var;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Number.Text.Trim()))
            {
                Common.ShowError("点名不能为空");
                return;
            }
            if (Entity.ID > 0)
            {
                if (!Entity.Number.Equals(txt_Number.Text.Trim()) && DOP.DataLogic.DOPDataLogic.Instance().IsExist<Variable>(txt_Number.Text.Trim(), "Number"))
                {
                    Common.ShowError("点名已存在");
                    return;
                }
            }
            else
            {
                if (DOP.DataLogic.DOPDataLogic.Instance().IsExist<Variable>(txt_Number.Text.Trim(), "Number"))
                {
                    Common.ShowError("点名已存在");
                    return;
                }
            }
            if (string.IsNullOrEmpty(txt_Name.Text.Trim()))
            {
                Common.ShowError("中文名称不能为空");
                return;
            }
            if (txt_MaxPeriod.Value <= 0)
            {
                Common.ShowError("最大存储周期应大于0");
                return;
            }

            Variable model = Entity;

            model.Number = txt_Number.TextTrim();
            model.Name = txt_Name.TextTrim();
            model.Unit = txt_Unit.TextTrim();
            model.Device = cmb_device.GetComboxData<Device>();
            model.IsTransfer = cmb_IsTransfer.Text.Equals("是") ? true : false;
            model.IsCompressed = cmb_IsCompressed.Text.Equals("是") ? true : false;
            model.CompressRatio = Sinowyde.Util.ConvertUtil.ConvertToFloat(txt_CompressRatio.Value);
            model.DataType = new VarDataTypeHelper().GetSelectValue(cmb_DataType.Text);
            model.VariableType = new VariableTypeHelper().GetSelectValue(cmb_VariableType.Text);
            model.DirectionType = VarDirectionType.Calc;
            model.MaxPeriod = Sinowyde.Util.ConvertUtil.ConvertToInt(txt_MaxPeriod.Value);
            if (model.ID > 0)
            {
                DOP.DataLogic.DOPDataLogic.Instance().Update(model);
            }
            else
            {
                DOP.DataLogic.DOPDataLogic.Instance().Insert(model);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void Form_CalcVariabel_Load(object sender, EventArgs e)
        {
            if (Entity.DirectionType == VarDirectionType.Calc)
            {
                if (Entity.ID > 0)
                {
                    this.Text = "修改计算变量";
                    btn_Save.Text = "修改";
                }
                else
                {
                    this.Text = "添加计算变量"; 
                    btn_Save.Text = "新增";
                    txt_MaxPeriod.Value = 500;
                }
            }
            else
            {
                if (Entity.ID > 0)
                {
                    this.Text = "修改临时变量";
                    btn_Save.Text = "修改";
                }
                else
                {
                    this.Text = "添加临时变量"; 
                    btn_Save.Text = "新增";
                    txt_MaxPeriod.Value = 500;
                }
            }

            List<Device> list = DOP.DataLogic.DOPDataLogic.Instance().GetAllBy<Device>();

            cmb_device.SetComboxDataSource<Device>(list);
            cmb_device.SelectedIndex = 0;

            #region 变量类型
            cmb_VariableType.Properties.Items.AddRange(new VariableTypeHelper().GetShowTexts().ToArray<string>());
            cmb_VariableType.SelectedIndex = 0;
            #endregion

            #region 数据类型
            cmb_DataType.Properties.Items.AddRange(new VarDataTypeHelper().GetShowTexts().ToArray<string>());
            cmb_DataType.SelectedIndex = 0;
            #endregion

            SetVariable(Entity);
        }

        private void Clear()
        {
            txt_Number.Empty();
            txt_Name.Empty();
            txt_Unit.Empty();
            cmb_device.SelectedIndex = 0;
            cmb_IsTransfer.SelectedIndex = 0;
            cmb_IsCompressed.SelectedIndex = 0;
            txt_CompressRatio.Value = 0;
            cmb_DataType.SelectedIndex = 0;
            cmb_VariableType.SelectedIndex = 0;
            txt_MaxPeriod.Value = 0;
        }

        private void SetVariable(Variable model)
        {
            txt_Number.Text = model.Number;
            txt_Name.Text = model.Name;
            txt_Unit.Text = model.Unit;
            cmb_device.SetComboxIndex<Device>(model.Device);
            cmb_IsTransfer.Text = model.IsTransfer ? "是" : "否";
            cmb_IsCompressed.Text = model.IsTransfer ? "是" : "否";
            txt_CompressRatio.Value = Sinowyde.Util.ConvertUtil.ConvertToDecimal(model.CompressRatio);
            cmb_DataType.SelectedIndex = new VarDataTypeHelper().GetIndexByValue(model.DataType);
            cmb_VariableType.SelectedIndex = new VariableTypeHelper().GetIndexByValue(model.VariableType);
            txt_MaxPeriod.Value = Sinowyde.Util.ConvertUtil.ConvertToDecimal(model.MaxPeriod);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public static class TextBoxEx
    {
        public static string TextTrim(this TextEdit txt)
        {
            return txt.Text.Trim();
        }

        public static void Empty(this TextEdit txt)
        {
            txt.Text = string.Empty;
        }
    }
}