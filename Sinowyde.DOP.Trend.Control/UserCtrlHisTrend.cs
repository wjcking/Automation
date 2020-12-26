using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sinowyde.DOP.DataModel;
using DevExpress.XtraCharts;
using System.Threading;

namespace Sinowyde.DOP.Trend.Control
{
    public partial class UserCtrlHisTrend : DevExpress.XtraEditors.XtraUserControl
    {
        public UserCtrlHisTrend()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 获取 已缓存的列表
        /// </summary>
        public List<ChartData> CacheDataList
        {
            get { return cacheDataList; }
        }

        /// <summary>
        /// 已缓存的数据
        /// </summary>
        private List<ChartData> cacheDataList = null;

        #region Custom Method

        /// <summary>
        /// 更新缓存变量
        /// </summary>
        public void UpdateCacheVariabel(ChartData item)
        {
            if (this.cacheDataList == null)
                this.cacheDataList = new List<ChartData>();

            if (this.cacheDataList.Count == 0)
            {
                this.cacheDataList.Add(item);
            }
            else
            {
                ChartData entity = CacheDataList.Find(o => o.Variable.Number.Equals(item.Variable.Number));
                if (entity == null)
                {
                    this.cacheDataList.Add(item);
                }
                else
                {
                    entity = item;
                }
            }

            chartControl.UpdateSeries(item);
        }

        /// <summary>
        /// 删除缓存变量
        /// </summary>
        public void DeleteCacheVariabel(string number)
        {
            if (this.cacheDataList != null && this.cacheDataList.Count > 0)
            {
                ChartData entity = cacheDataList.Find(o => o.Variable.Number.Equals(number));
                if (entity != null)
                {
                    this.cacheDataList.Remove(entity);
                }
            }
            chartControl.RemoveSeries(number);
        }

        public void UpdateDataMinMax()
        {
            Dictionary<string, double[]> limits = chartControl.GetLimitValue();
            foreach (var item in limits)
            {
                ChartData data = this.cacheDataList.Find(o => o.Variable.Number.Equals(item.Key));
                if (data != null)
                {
                    data.MinValue = item.Value[0];
                    data.MaxValue = item.Value[1];
                }
            }
        }

        public void DataChange(ChartData data, DataState dState)
        {
            switch (dState)
            {
                case DataState.Delete:
                    DeleteCacheVariabel(data.Variable.Number);
                    break;
                default:
                    UpdateCacheVariabel(data);
                    break;
            }
        }

        #endregion


        /// <summary>
        /// 变量配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItem_Variable_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form_Variable form = new Form_Variable(cacheDataList);
            //form.TopLevel = false;
            //form.Parent = this;
            form.BringToFront();
            form.Location = new Point((this.Width - form.Width) / 2, (this.Height - form.Height) / 2);
            form.DataChangeEvent += DataChange;
            if (form.ShowDialog() == DialogResult.OK)
            {
                //更新数据

            }
        }
        private void ck_ShowAxisY_CheckedChanged(object sender, EventArgs e)
        {
            chartControl.CurveConfig_ShowAxisY = ck_ShowAxisY.Checked;
            chartControl.UpdateConfig();
        }

        private void ck_ShowAxisX_CheckedChanged(object sender, EventArgs e)
        {
            chartControl.CurveConfig_ShowAxisX = ck_ShowAxisX.Checked;
            chartControl.UpdateConfig();
        }

        private void ck_ShowRealValue_CheckedChanged(object sender, EventArgs e)
        {
            chartControl.CurveConfig_ShowRealValue = ck_ShowRealValue.Checked;
            chartControl.UpdateConfig();
        }

        private void UserCtrlHisTrend_Load(object sender, EventArgs e)
        {
            cacheDataList = new List<ChartData>();
            //dateTxt_begin.DateTime = DateTime.Now;
            //dateTxt_begin.DateTime = new DateTime(2015, 12, 23, 16, 00, 00);
            //timeSpanTxt.TimeSpan = new TimeSpan(0, 0, 40, 0);
            ck_ShowAxisX.Checked = this.chartControl.CurveConfig_ShowAxisX;
            ck_ShowAxisY.Checked = this.chartControl.CurveConfig_ShowAxisY;
            ck_ShowRealValue.Checked = this.chartControl.CurveConfig_ShowRealValue;
            timeSpanTxt.TimeSpan = new TimeSpan(0, 0, 0, 0);
            tsTxt_Sample.TimeSpan = new TimeSpan(0,0,0,0);
        }

        private void SearchData(DateTime beginDate, DateTime endDate, string[] numbers, Action<List<RTValue>> action)
        {
            new Thread(new ThreadStart(() =>
            {
                List<RTValue> list = DOP.DataLogic.DOPDataLogic.Instance().GetRTValueBy(numbers, beginDate, endDate);
                if (action != null)
                {
                    action(list);
                }
            })).Start();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Search_Click(object sender, EventArgs e)
        {
            
            string[] numbers = (from c in cacheDataList select c.Variable.Number).ToArray();
            DateTime endDate = dateTxt_begin.DateTime.AddTicks(timeSpanTxt.TimeSpan.Ticks);
            if (numbers.Length <= 0)
            {
                MessageBox.Show("请配置要查询的数据点", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dateTxt_begin.DateTime == DateTime.MinValue)
            {
                MessageBox.Show("请设置起始时间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (timeSpanTxt.TimeSpan.Ticks <= 0)
            {
                MessageBox.Show("请设置时间范围", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tsTxt_Sample.TimeSpan.Ticks <= 0)
            {
                MessageBox.Show("请设置采样间隔", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            pcc_Search.HidePopup();
            panel_Container.ShowLoadingImage();

            this.SearchData(dateTxt_begin.DateTime, endDate, numbers, (List<RTValue> list) =>
            {
                #region 整理数据
                list = list.OrderBy(o => o.Timestamp).ToList();
                Dictionary<string, object> dic = new Dictionary<string, object>();
                for (int i = 0; i < numbers.Length; i++)
                {
                    string number = numbers[i];
                    //查询当前变量的数据信息
                    var rtvalues = (from c in list where c.VarNumber.Equals(number) select new RTValue() { VarNumber = c.VarNumber, Value = c.Value, Timestamp = c.Timestamp });

                    List<RTValueEx> listRTValueEx = new List<RTValueEx>();

                    if (rtvalues.Count() > 0)
                    {
                        bool isFirst = true;
                        List<RTValue> listRTValues = rtvalues.ToList();
                        foreach (var item in listRTValues)
                        {
                            //第一个 和最后一个 直接添加 其余按采样间隔判断
                            if (isFirst || item.Timestamp.Ticks >= listRTValueEx.Last().Timestamp.AddTicks(tsTxt_Sample.TimeSpan.Ticks).Ticks
                                || item == listRTValues.Last()
                                )
                            {
                                listRTValueEx.Add(new RTValueEx()
                                {
                                    Timestamp = item.Timestamp,
                                    Value = item.Value,
                                    VarNumber = item.VarNumber
                                });
                                isFirst = false;
                            }
                        }
                        #region
                        //var temp = from c in list
                        //           where c.VarNumber.Equals(number)
                        //           group c by new { c.Timestamp, c.VarNumber } into g
                        //           select new RTValueEx()
                        //           {
                        //               ID = g.FirstOrDefault().ID,
                        //               Timestamp = g.FirstOrDefault().Timestamp,
                        //               Value = g.FirstOrDefault().Value,
                        //               VarNumber = g.FirstOrDefault().VarNumber
                        //           };
                        #endregion
                    }
                    dic.Add(number, listRTValueEx);
                }
                #endregion
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        if (tsTxt_Sample.TimeSpan.Days > 0)
                        {
                            chartControl.UpdateMeasureUnit(DateTimeMeasureUnit.Day);
                        }
                        else if (tsTxt_Sample.TimeSpan.Hours > 0)
                        { chartControl.UpdateMeasureUnit(DateTimeMeasureUnit.Hour); }
                        else if (tsTxt_Sample.TimeSpan.Minutes > 0)
                        { chartControl.UpdateMeasureUnit(DateTimeMeasureUnit.Minute); }
                        else if (tsTxt_Sample.TimeSpan.Seconds > 0)
                        { chartControl.UpdateMeasureUnit(DateTimeMeasureUnit.Second); }
                        for (int i = 0; i < chartControl.Chart.Series.Count; i++)
                        {
                            Series series = chartControl.Chart.Series[i];
                            series.DataSource = dic[series.Name];
                        }
                        chartControl.Chart.RefreshData();
                        panel_Container.RemoveLoadingImage();
                        
                    }));
                }
            });
        }

        private void pcc_CurveChange_Popup(object sender, EventArgs e)
        {
            cmb_Curves.Properties.Items.Clear();
            var array = from c in this.cacheDataList select c.Variable.Number;
            string[] realVariable = array.ToArray();
            string[] allVariable = new string[realVariable.Length + 1];
            allVariable[0] = "整体";
            realVariable.CopyTo(allVariable, 1);
            cmb_Curves.Properties.Items.AddRange(allVariable);
            cmb_Curves.SelectedIndex = 0;

            var name = (pcc_CurveChange.Activator as DevExpress.XtraBars.BarButtonItemLink).Caption;

            switch (name)
            {
                case "曲线上移":
                    lbl_CurveDesc.Text = "曲线上移(%)";
                    break;
                case "曲线下移":
                    lbl_CurveDesc.Text = "曲线下移(%)";
                    break;
                case "放大曲线":
                    lbl_CurveDesc.Text = "放大曲线(%)";
                    break;
                default: //压缩曲线
                    lbl_CurveDesc.Text = "压缩曲线(%)";
                    break;
            }
        }

        private void btn_Curve_Save_Click(object sender, EventArgs e)
        {
            var name = ((btn_Curve_Save.Parent as DevExpress.XtraBars.PopupControlContainer).Activator as DevExpress.XtraBars.BarButtonItemLink).Caption;

            bool isAll = cmb_Curves.Text.Trim().Equals("整体");
            double Percentage = (double)(txt_movePercentage.Value / 100);
            switch (name)
            {
                case "曲线上移":
                    if (isAll)
                        chartControl.SeriesAllMove(Percentage * -1);
                    else
                        chartControl.SeriesMove(cmb_Curves.Text.Trim(), Percentage * -1);
                    break;

                case "曲线下移":
                    if (isAll)
                        chartControl.SeriesAllMove(Percentage);
                    else
                        chartControl.SeriesMove(cmb_Curves.Text.Trim(), Percentage);
                    break;

                case "放大曲线":
                    if (isAll)
                    {
                        chartControl.SeriesAllZoom(Percentage);
                    }
                    else
                    {
                        chartControl.SeriesZoom(cmb_Curves.Text.Trim(), Percentage);
                    }
                    break;
                default: //压缩曲线
                    if (isAll)
                    {
                        chartControl.SeriesAllZoom(Percentage * -1);
                    }
                    else
                    {
                        chartControl.SeriesZoom(cmb_Curves.Text.Trim(), Percentage * -1);
                    }
                    break;
            }
            UpdateDataMinMax();

            pcc_CurveConfig.HidePopup();
        }

        private void barBtnItem_RestoreDefault_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            chartControl.RestoreMaxMin();
            UpdateDataMinMax();
        }
    }

    public static class ControlEx
    {
        /// <summary>
        /// 显示等待图片
        /// </summary>
        /// <param name="control">容器控件,如:panel</param>
        /// <returns></returns>
        public static LabelControl ShowLoadingImage(this System.Windows.Forms.Control control)
        {
            try
            {
                string name = "lblLoadingImage";
                if (control.Controls.Find(name, false).Length > 0)
                    return null;
                LabelControl lbl = new LabelControl();
                lbl.Appearance.Image = Properties.Resources.loading;
                lbl.Name = name;
                lbl.Text = " ";
                lbl.Location = new Point((control.Width - lbl.Width) / 2, (control.Height - lbl.Height) / 2);
                control.Controls.Add(lbl);
                lbl.BackColor = Color.Transparent;
                lbl.BringToFront();
                control.Resize += delegate { lbl.Location = new Point((control.Width - lbl.Width) / 2, (control.Height - lbl.Height) / 2); };
                return lbl;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 删除等待图片
        /// </summary>
        /// <param name="control"></param>
        /// <param name="loadControl"></param>
        public static void RemoveLoadingImage(this System.Windows.Forms.Control control)
        {
            try
            {
                string name = "lblLoadingImage";
                if (control.Controls.Find(name, false).Length > 0)
                {
                    control.Controls.Remove(control.Controls.Find(name, false).First());
                }

            }
            catch (Exception ex)
            {

            }

        }
    }
}
