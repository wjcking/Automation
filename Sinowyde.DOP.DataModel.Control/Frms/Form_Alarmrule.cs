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
using Sinowyde.DOP.DataLogic;
using Sinowyde.DOP.DataModel;
using DevExpress.Utils.Menu;

namespace Sinowyde.DOP.DataModel.Control
{
    public partial class Form_Alarmrule : DevExpress.XtraEditors.XtraForm
    {
        private Variable entity = new Variable();
        private AlarmRule alarmRule = new AlarmRule();

        public Form_Alarmrule(Variable model)
        {
            InitializeComponent();
            entity = model;
        }

        private long ID = 0;

        private void btn_Save_Click(object sender, EventArgs e)
        {
            AlarmRule alarmRule = new AlarmRule();

            alarmRule.AlarmLevel = new AlarmLevelHelper().GetSelectValue(cmb_AlarmLevel.Text);
            alarmRule.TimeSpan = Sinowyde.Util.ConvertUtil.ConvertToInt(txt_AlarmTimeSpan.Value);
            alarmRule.AlarmType = new AlarmTypeHelper().GetSelectValue(cmb_AlarmType.Text);
            alarmRule.EventType = cmb_EventType.Text.Trim();
            alarmRule.LimitValue = Sinowyde.Util.ConvertUtil.ConvertToFloat(txt_LimitValue.Value);
            alarmRule.RecordAsEvent = cb_RecordEvent.Checked ? true : false;
            alarmRule.VariableID = entity.ID;
            alarmRule.IsTransfer = cb_IsTransfer.Checked;

            if (ID > 0)
            {
                alarmRule.ID = ID;
                DOP.DataLogic.DOPDataLogic.Instance().Update(alarmRule);
            }
            else
            {
                DOP.DataLogic.DOPDataLogic.Instance().Insert(alarmRule);
            }

            Clear();
            loadData();
        }

        private void Form_Alarmrule_Load(object sender, EventArgs e)
        {
            loadData();

            cmb_AlarmLevel.Properties.Items.AddRange(new AlarmLevelHelper().GetShowTexts().ToArray<string>());
            cmb_AlarmType.Properties.Items.AddRange(new AlarmTypeHelper().GetShowTexts().ToArray<string>());

            List<AlarmRule> list = gc_AlarmRule.DataSource as List<AlarmRule>;
            string[] eventTypes = (from c in list.DistinctBy(p => p.EventType) select c.EventType).ToArray<string>();
            cmb_EventType.Properties.Items.AddRange(eventTypes);

            Clear();
        }

        private void loadData()
        {
            List<AlarmRule> list = DOPDataLogic.Instance().GetAlarmRuleByVariable(entity.ID);
            gc_AlarmRule.DataSource = list;
        }

        private void Clear()
        {
            txt_AlarmTimeSpan.Value = 0;
            txt_LimitValue.Value = 0;
            cmb_AlarmLevel.SelectedIndex = 0;
            cmb_AlarmType.SelectedIndex = 0;
            List<AlarmRule> list = DOPDataLogic.Instance().GetAlarmRuleByVariable(entity.ID);
            string[] eventTypes = (from c in list.DistinctBy(p => p.EventType) select c.EventType).ToArray<string>();
            cmb_EventType.Properties.Items.Clear();
            cmb_EventType.Properties.Items.AddRange(eventTypes);
            cmb_EventType.SelectedIndex = 0;
            cb_IsTransfer.Checked = false;
            cb_RecordEvent.Checked = false;
            ID = 0;
            btn_Save.Text = "新增";
        }

        private void SetAlarmRule(AlarmRule model)
        {
            txt_AlarmTimeSpan.Value = Sinowyde.Util.ConvertUtil.ConvertToDecimal(model.TimeSpan);
            txt_LimitValue.Value = Sinowyde.Util.ConvertUtil.ConvertToDecimal(model.LimitValue);
            cmb_AlarmLevel.SelectedIndex = new AlarmLevelHelper().GetIndexByValue(model.AlarmLevel);
            cmb_AlarmType.SelectedIndex = new AlarmTypeHelper().GetIndexByValue(model.AlarmType);
            cmb_EventType.Text = model.EventType;
            cb_IsTransfer.Checked = model.IsTransfer;
            cb_RecordEvent.Checked = model.RecordAsEvent;
            ID = model.ID;
            btn_Save.Text = "编辑";
        }

        private void gv_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            if (((DevExpress.XtraGrid.Views.Grid.GridView)sender).RowCount == 0)
            {
                string str = "暂无数据!";
                Font f = new Font("宋体", 10, FontStyle.Bold);
                SizeF sizeF = e.Graphics.MeasureString(str, f);
                int x = (int)((e.Bounds.Width - sizeF.Width) / 2);
                Rectangle r = new Rectangle(e.Bounds.Top + 5, e.Bounds.Left + 5, e.Bounds.Right - 5, e.Bounds.Height - 5);
                e.Graphics.DrawString(str, f, Brushes.Black, x, 40);
            }
        }

        private void gc_CalcVariable_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = ((DevExpress.XtraGrid.Views.Grid.GridView)sender).CalcHitInfo(new Point(e.X, e.Y));
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //判断光标是否在行范围内  
                if (hInfo.InRow)
                {
                    AlarmRule model = ((List<AlarmRule>)gv_AlarmRule.DataSource)[hInfo.RowHandle];
                    SetAlarmRule(model);
                }
            }
        }

        private void gv_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            {
                e.Menu.Items.Clear();
                return;
            }

            if (e.Menu == null)
            {
                e.Menu = new DevExpress.XtraGrid.Menu.GridViewMenu((DevExpress.XtraGrid.Views.Grid.GridView)sender);
            }

            e.Menu.Items.Add(new DXMenuItem("编辑报警规则"));
            e.Menu.Items.Add(new DXMenuItem("删除报警规则"));
            e.Menu.Items.Add(new DXMenuItem("清空报警规则"));

            e.Menu.Items[0].Enabled = e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row;
            e.Menu.Items[1].Enabled = e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row;

            AlarmRule model = new AlarmRule();
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Row)
            {
                if (e.HitInfo.InRowCell)
                {
                    int index = gv_AlarmRule.GetDataSourceRowIndex(e.HitInfo.RowHandle);
                    model = ((List<AlarmRule>)gv_AlarmRule.DataSource)[index];

                    e.Menu.Items[0].Click += delegate(object obj, EventArgs es)
                    {
                        SetAlarmRule(model);
                    };
                    e.Menu.Items[1].Click += delegate(object obj, EventArgs es)
                    {
                        if (MessageBox.Show(string.Format("是否删除?"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string sql = string.Format("Delete FROM AlarmRule WHERE ID = {0}", model.ID);
                            DOP.DataLogic.DOPDataLogic.Instance().Delete(sql);
                            loadData();
                        }
                    };
                }
            }

            e.Menu.Items[2].Click += delegate(object obj, EventArgs es)
            {
                if (MessageBox.Show(string.Format("是否清空{0}下所有报警规则?",entity.Name), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = string.Format("Delete FROM AlarmRule WHERE VariableID = {0}", entity.ID);
                    DOP.DataLogic.DOPDataLogic.Instance().Delete(sql);
                    loadData();
                }
            };
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Clear();
        }


        private void gv_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Name == "col_AlarmType")
            {
                e.DisplayText = new AlarmTypeHelper().GetKeyByValue((AlarmType)e.Value);
            }
            else if (e.Column.Name == "col_AlarmLevel")
            {
                e.DisplayText = new AlarmLevelHelper().GetKeyByValue((AlarmLevel)e.Value);
            }
            else if (e.Column.Name == "col_AlarmTimeSpan")
            {
                int span = Sinowyde.Util.ConvertUtil.ConvertToInt(e.Value) / 60;
                e.DisplayText = span.ToString();
            }

        }
    }
}