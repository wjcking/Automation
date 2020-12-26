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
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.DataLogic;
using Sinowyde.Util;

namespace Sinowyde.DOP.DataModel.Control
{
    public partial class Form_Variable : DevExpress.XtraEditors.XtraForm
    {

        public bool IsEnableDirDirectionType = true;

        private Variable entity = new Variable();

        public Form_Variable()
        {
            InitializeComponent();
        }

        public Form_Variable(Variable model = null, bool isEnableDirDirectionType = false)
        {
            InitializeComponent();
            entity = model;

            if (entity != null && entity.ID > 0)
            {
                entity = DOPDataLogic.Instance().Get<Variable>(entity.ID);
            }
            IsEnableDirDirectionType = isEnableDirDirectionType;
        }

        private void Form_Variable_Load(object sender, EventArgs e)
        {
            if (entity.ID > 0)
            {
                this.Text = "修改变量";
            }
            cmb_IOUnit.Enabled = false;

            #region 采集类型
            if (IsEnableDirDirectionType)
            {
                cmb_VarDirectionType.Properties.Items.AddRange(new VarDirectionTypeHelper().GetReadWrite());
                cmb_VarDirectionType.SelectedIndex = 0;
                cmb_VarDirectionType.Enabled = true;
            }
            else
            {
                cmb_VarDirectionType.Properties.Items.AddRange(new VarDirectionTypeHelper().GetShowTexts());
                cmb_VarDirectionType.SelectedIndex = new VarDirectionTypeHelper().GetIndexByValue(entity.DirectionType);
                cmb_VarDirectionType.Enabled = false;
            }
            #endregion

            #region 变量类型
            cmb_VariableType.Properties.Items.AddRange(new VariableTypeHelper().GetShowTexts().ToArray<string>());
            cmb_VariableType.SelectedIndex = new VariableTypeHelper().GetIndexByValue(entity.VariableType);
            #endregion

            #region 数据类型
            cmb_DataType.Properties.Items.AddRange(new VarDataTypeHelper().GetShowTexts().ToArray<string>());
            cmb_DataType.SelectedIndex = new VarDataTypeHelper().GetIndexByValue(entity.DataType);
            #endregion

            #region 所属设备
            cmb_device.SetComboxDataSource<Device>(DOPDataLogic.Instance().GetAllBy<Device>());
            if (entity.Device != null)
            {
                cmb_device.SetIndexByText(entity.Device.Name);
            }
            else { cmb_device.SelectedIndex = 0; }

            #endregion

            #region 所在单元

            cmb_IOUnit.SetComboxDataSource<IOUnit>(DOPDataLogic.Instance().GetAllBy<IOUnit>());
            if (entity.IOUnit != null)
            {
                cmb_IOUnit.SetIndexByText(entity.IOUnit.Name);
            }
            else { cmb_IOUnit.SelectedIndex = 0; }

            #endregion

            cmb_IsCompressed.Text = entity.IsCompressed ? "是" : "否";
            cmb_IsTransfer.Text = entity.IsTransfer ? "是" : "否";

            txt_Bias.Value = ConvertUtil.ConvertToDecimal(entity.Bias);
            txt_CompressRatio.Value = ConvertUtil.ConvertToDecimal(entity.CompressRatio);
            txt_MaxPeriod.Value = entity.ID > 0 ? ConvertUtil.ConvertToDecimal(entity.MaxPeriod) : 500;
            txt_Name.Text = entity.Name;
            txt_Number.Text = entity.Number;
            txt_Ratio.Value = ConvertUtil.ConvertToDecimal(entity.Ratio);
            txt_Unit.Text = entity.Unit;
            txt_Address.Value = entity.ID > 0 ? entity.Address : DOPDataLogic.Instance().GetMaxAddress(entity.IOUnitID.Value) + 1;
            txt_Number.Focus();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Number.Text.Trim()))
            {
                Common.ShowError("点名不能为空");
                return;
            }
            if (entity.ID > 0)
            {
                if (!entity.Number.Equals(txt_Number.Text.Trim()) && DOPDataLogic.Instance().IsExist<Variable>(txt_Number.Text.Trim(), "Number"))
                {
                    Common.ShowError("点名已存在");
                    return;
                }
            }
            else
            {
                if (DOPDataLogic.Instance().IsExist<Variable>(txt_Number.Text.Trim(), "Number"))
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


            if (txt_Address.Value <= 0)
            {
                Common.ShowError("变量地址不正确");
                return;
            }
            if (entity.DirectionType != VarDirectionType.Calc && entity.DirectionType != VarDirectionType.Temp)
            {
                if (!entity.Address.Equals((int)txt_Address.Value) || !entity.Device.Equals(cmb_device.GetComboxData<Device>()))
                {
                    if (DOPDataLogic.Instance().IsExistVariable(cmb_device.GetComboxData<Device>().ID, Sinowyde.Util.ConvertUtil.ConvertToInt(txt_Address.Value)))
                    {
                        Common.ShowError(string.Format("{0}下的地址：{1}已存在变量", cmb_device.Text, txt_Address.Value));
                        return;
                    }
                }
            }

            entity.Bias = ConvertUtil.ConvertToFloat(txt_Bias.Value);
            entity.CompressRatio = ConvertUtil.ConvertToFloat(txt_CompressRatio.Value);
            entity.VariableType = new VariableTypeHelper().GetSelectValue(cmb_VariableType.Text);
            entity.Device = cmb_device.GetComboxData<Device>();
            entity.DirectionType = new VarDirectionTypeHelper().GetSelectValue(cmb_VarDirectionType.Text);
            entity.IOUnit = cmb_IOUnit.GetComboxData<IOUnit>();
            entity.IsCompressed = cmb_IsCompressed.Text.Equals("是") ? true : false;
            entity.IsTransfer = cmb_IsTransfer.Text.Equals("是") ? true : false;
            entity.MaxPeriod = ConvertUtil.ConvertToInt(txt_MaxPeriod.Value);
            entity.Name = txt_Name.Text.Trim();
            entity.Number = txt_Number.Text.Trim();
            entity.Ratio = ConvertUtil.ConvertToFloat(txt_Ratio.Value);
            entity.Unit = txt_Unit.Text.Trim();
            entity.Address = Sinowyde.Util.ConvertUtil.ConvertToInt(txt_Address.Value);
            entity.DataType = new VarDataTypeHelper().GetSelectValue(cmb_DataType.Text);

            if (entity.ID > 0)
            {
                //修改
                DOPDataLogic.Instance().Update(entity);
            }
            else
            {
                DOPDataLogic.Instance().Insert(entity);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}