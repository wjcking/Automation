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
using DevExpress.Utils.Menu;
using DevExpress.XtraCharts;
using System.Xml.Linq;

namespace Sinowyde.DOP.Trend.Control
{
    public partial class UserCtrlRtTrend : DevExpress.XtraEditors.XtraUserControl
    {

        public UserCtrlRtTrend()
        {
            InitializeComponent();
            cacheChartDataList = new List<ChartData>();
        }
        private ChartTimer WorkTimer = null;
        private bool IsFrozen = false;
        private XElement RootXmlConfig = null;
        /// <summary>
        /// 获取 已缓存的列表
        /// </summary>
        public List<ChartData> CacheChartDataList
        {
            get { return cacheChartDataList; }
        }

        /// <summary>
        /// 已缓存的数据
        /// </summary>
        private List<ChartData> cacheChartDataList = null;

        #region Custom Method

        /// <summary>
        /// 加载曲线配置参数
        /// </summary>
        private void LoadCurveConfigData()
        {
            cmb_RealTimeCurveRange.Properties.Items.AddRange(new string[] { "2分钟", "5分钟", "10分钟", "15分钟", "30分钟", "1小时", "2小时" });
            cmb_RealTimeCurveRange.SelectedIndex = 0;
            cmb_RealTimeCurveRange.Text = ChartConfig.RealTimeCurveRange;
            txt_PollingPeriod.Value = ChartConfig.PollingPeriod;
            txt_LastValueDate.Value = ChartConfig.LastValueDate;

            cmb_RealTimeValue.Text = chartControl.CurveConfig_ShowRealValue ? "是" : "否";
            cmb_ShowAxisX.Text = chartControl.CurveConfig_ShowAxisX ? "是" : "否";
            cmb_ShowAxisY.Text = chartControl.CurveConfig_ShowAxisY ? "是" : "否";
        }

        /// <summary>
        /// 更新缓存变量
        /// </summary>
        public void UpdateCacheVariabel(ChartData item)
        {
            if (this.cacheChartDataList == null)
                this.cacheChartDataList = new List<ChartData>();

            if (this.cacheChartDataList.Count == 0)
            {
                this.cacheChartDataList.Add(item);
            }
            else
            {
                ChartData entity = CacheChartDataList.Find(o => o.Variable.Number.Equals(item.Variable.Number));
                if (entity == null)
                {
                    this.cacheChartDataList.Add(item);
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
            if (this.cacheChartDataList != null && this.cacheChartDataList.Count > 0)
            {
                ChartData entity = cacheChartDataList.Find(o => o.Variable.Number.Equals(number));
                if (entity != null)
                {
                    this.cacheChartDataList.Remove(entity);
                }
            }
            chartControl.RemoveSeries(number);
        }

        private void DoWork(object sender)
        {
            if (cacheChartDataList.Count > 0 && !IsFrozen)
            {
                bool isUpdateChartControl = false;
                string[] numbers = (from c in this.cacheChartDataList select c.Variable.Number).ToArray<string>();
                IList<RTValue> list = DOP.DTProxy.RTValueMemCache.Instance().GetValues(numbers);
                foreach (RTValue item in list)
                {
                    ChartData data = cacheChartDataList.Find(o => o.Variable.Number.Equals(item.VarNumber));
                    if (data != null)
                    {
                        isUpdateChartControl = data.AddRTValue(RTValueEx.ToRTValueEx(item));
                    }
                }
                if (isUpdateChartControl)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            chartControl.RefreshSeriesDataSource(this.cacheChartDataList);
                        }));
                    }
                }

            }
        }

        public void UpdateDataMinMax()
        {
            Dictionary<string, double[]> limits = chartControl.GetLimitValue();
            foreach (var item in limits)
            {
                ChartData data = this.cacheChartDataList.Find(o => o.Variable.Number.Equals(item.Key));
                if (data != null)
                {
                    data.MinValue = item.Value[0];
                    data.MaxValue = item.Value[1];
                }
            }
            SaveXmVariableConfig();
        }

        public void DataChange(ChartData data, DataState dState)
        {
            switch (dState)
            {
                case DataState.Delete:
                    DeleteCacheVariabel(data.Variable.Number);
                    SaveXmVariableConfig();
                    break;
                default:
                    UpdateCacheVariabel(data);
                    SaveXmVariableConfig();
                    break;
            }
        }

        private void LoadXmlConfig() 
        {
            RootXmlConfig = XElement.Load(Application.StartupPath + "\\Config.xml");
            XElement currentElement = RootXmlConfig.Element("RtThend");
            ChartConfig.RealTimeCurveRange = currentElement.Element("RealTimeCurveRange").Value;
            int pollingPeriod = Sinowyde.Util.ConvertUtil.ConvertToInt(currentElement.Element("PollingPeriod").Value);
            ChartConfig.PollingPeriod = pollingPeriod.Equals(0) ? 1 : pollingPeriod;
            int lastDateValue = Sinowyde.Util.ConvertUtil.ConvertToInt(currentElement.Element("LastValueDate").Value);
            ChartConfig.LastValueDate = lastDateValue.Equals(0) ? 1 : lastDateValue;
            this.chartControl.CurveConfig_ShowRealValue = Sinowyde.Util.ConvertUtil.ConvertToBool(currentElement.Element("ShowRealValue").Value);
            this.chartControl.CurveConfig_ShowAxisX = Sinowyde.Util.ConvertUtil.ConvertToBool(currentElement.Element("ShowAxisX").Value);
            this.chartControl.CurveConfig_ShowAxisY = Sinowyde.Util.ConvertUtil.ConvertToBool(currentElement.Element("ShowAxisY").Value);
            if (currentElement.Element("maxVariableCount") != null)
            {
                int count = Sinowyde.Util.ConvertUtil.ConvertToInt(currentElement.Element("maxVariableCount").Value);
                ChartConfig.MaxVariableCount = count.Equals(0) ? 8 : count;
            }
            XElement variableElement = currentElement.Element("Variables");
            if (variableElement != null)
            {
                foreach (XElement item in variableElement.Elements())
                {
                    ChartData model = new ChartData();
                    model.Variable.Number = item.Value.Trim();
                    if (item.Attribute("name") != null)
                    {
                        model.Variable.Name = item.Attribute("name").Value.Trim();
                    }
                    if (item.Attribute("maxValue") != null)
                    {
                        double maxValue = Sinowyde.Util.ConvertUtil.ConvertToDouble(item.Attribute("maxValue").Value);
                        model.MaxValue = maxValue.Equals(0d) ? 100d : maxValue;
                    }
                    if (item.Attribute("minValue") != null)
                    {
                        double minValue = Sinowyde.Util.ConvertUtil.ConvertToDouble(item.Attribute("minValue").Value);
                        model.MinValue = minValue;
                    }

                    if (item.Attribute("color") != null && item.Attribute("color").Value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Length == 3)
                    {
                        string[] color = item.Attribute("color").Value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        int redColor = Sinowyde.Util.ConvertUtil.ConvertToInt(color[0]);
                        int greenColor = Sinowyde.Util.ConvertUtil.ConvertToInt(color[1]);
                        int blueColor = Sinowyde.Util.ConvertUtil.ConvertToInt(color[2]);
                        model.Color = Color.FromArgb(redColor, greenColor, blueColor);
                    }
                    if (item.Attribute("lineType") != null)
                    {
                        model.LineType = item.Attribute("lineType").Value.Trim();
                    }
                    UpdateCacheVariabel(model);
                }
            }
        }

        private void SaveXmlChartConfig() 
        {
            RootXmlConfig = XElement.Load(Application.StartupPath + "\\Config.xml");
            XElement element = RootXmlConfig.Element("RtThend");
            if (element.Element("RealTimeCurveRange") == null)
            {
                XElement eleRealTimeCurveRange = new XElement("RealTimeCurveRange");
                eleRealTimeCurveRange.Value = ChartConfig.RealTimeCurveRange.ToString();
                element.Add(eleRealTimeCurveRange);
            }
            else 
            {
                element.Element("RealTimeCurveRange").Value = ChartConfig.RealTimeCurveRange.ToString();
            }

            if (element.Element("PollingPeriod") == null)
            {
                XElement elePollingPeriod = new XElement("PollingPeriod");
                elePollingPeriod.Value = ChartConfig.PollingPeriod.ToString();
                element.Add(elePollingPeriod);
            }
            else 
            {
                element.Element("PollingPeriod").Value = ChartConfig.PollingPeriod.ToString();
            }

            if (element.Element("LastValueDate") == null)
            {
                XElement eleLastValueDate = new XElement("LastValueDate");
                eleLastValueDate.Value = ChartConfig.LastValueDate.ToString();
                element.Add(eleLastValueDate);
            }
            else 
            {
                element.Element("LastValueDate").Value = ChartConfig.LastValueDate.ToString();
            }

            if (element.Element("ShowRealValue") == null)
            {
                XElement eleShowRealValue = new XElement("ShowRealValue");
                eleShowRealValue.Value = chartControl.CurveConfig_ShowRealValue.ToString();
                element.Add(eleShowRealValue);
            }
            else
            {
                element.Element("ShowRealValue").Value = chartControl.CurveConfig_ShowRealValue.ToString();
            }

            if (element.Element("ShowAxisX") == null)
            {
                XElement eleShowAxisX = new XElement("ShowAxisX");
                eleShowAxisX.Value = chartControl.CurveConfig_ShowAxisX.ToString();
                element.Add(eleShowAxisX);
            }
            else 
            {
                element.Element("ShowAxisX").Value = chartControl.CurveConfig_ShowAxisX.ToString();
            }

            if (element.Element("ShowAxisY") == null)
            {
                XElement eleShowAxisY = new XElement("ShowAxisY");
                eleShowAxisY.Value = chartControl.CurveConfig_ShowAxisY.ToString();
                element.Add(eleShowAxisY);

            }
            else 
            {
                element.Element("ShowAxisY").Value = chartControl.CurveConfig_ShowAxisY.ToString();
            }
            RootXmlConfig.Save(Application.StartupPath + "\\Config.xml");
        }
        private void SaveXmVariableConfig() 
        {
            RootXmlConfig = XElement.Load(Application.StartupPath + "\\Config.xml");
            XElement element = RootXmlConfig.Element("RtThend");
            //foreach (XElement item in element.Element("Variables").Elements())
            //{
            //    item.Remove();   
            //}
            element.Element("Variables").Elements().Remove();
            foreach (ChartData item in cacheChartDataList)
            {
                XElement ele = new XElement("Variable",
                    new XAttribute("name",item.Variable.Name),
                    new XAttribute("maxValue",item.MaxValue),
                    new XAttribute("minValue",item.MinValue),
                    new XAttribute("color",string.Format("{0},{1},{2}",item.Color.R,item.Color.G,item.Color.B)),
                    new XAttribute("lineType", item.LineType)
                    );
                ele.Value = item.Variable.Number;
                element.Element("Variables").Add(ele);
            }
            RootXmlConfig.Save(Application.StartupPath + "\\Config.xml");
        }
        #endregion

        /// <summary>
        /// 曲线配置-> 设置按钮 单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void batBtnItem_CurveConfig_Save_Click(object sender, EventArgs e)
        {
            ChartConfig.RealTimeCurveRange = cmb_RealTimeCurveRange.Text;
            ChartConfig.PollingPeriod = (int)(txt_PollingPeriod.Value);
            ChartConfig.LastValueDate = (int)txt_LastValueDate.Value;
            chartControl.UpdateConfig();
            pcc_CurveConfig.HidePopup();
            SaveXmlChartConfig();
        }

        private void UserCtrlRtTrend_Load(object sender, EventArgs e)
        {
            //加载配置文件
            LoadXmlConfig();
            LoadCurveConfigData();
            WorkTimer = new ChartTimer((int)ChartConfig.PollingPeriod * 1000);
            WorkTimer.StartWorkTimer(DoWork);
            chartControl.Chart.CustomDrawAxisLabel += chartControl_CustomDrawAxisLabel;
        }

        private void batBtnItem_VariableConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Form_Variable form = new Form_Variable(this.cacheChartDataList);
            form.TopLevel = false;
            form.Parent = this;
            form.BringToFront();
            form.Location = new Point((this.Width - form.Width) / 2, (this.Height - form.Height) / 2);
            form.DataChangeEvent += DataChange;
            form.Show();
        }

        private void pcc_CurveChange_Popup(object sender, EventArgs e)
        {
            cmb_Curves.Properties.Items.Clear();
            var array = from c in this.cacheChartDataList select c.Variable.Number;
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

        /// <summary>
        /// 压缩时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItem_CompressedDate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //压缩时间
            string result = string.Empty;

            switch (ChartConfig.RealTimeCurveRange)
            {
                case "5分钟":
                    result = "2分钟";
                    break;
                case "10分钟":
                    result = "5分钟";
                    break;
                case "15分钟":
                    result = "10分钟";
                    break;
                case "30分钟":
                    result = "15分钟";
                    break;
                case "1小时":
                    result = "30分钟";
                    break;
                case "2小时":
                    result = "1小时";
                    break;
                default:
                    result = "2分钟";
                    break;
            }

            ChartConfig.RealTimeCurveRange = result;
        }

        /// <summary>
        /// 拉伸时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnItem_ZoomDate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //压缩时间
            string result = string.Empty;

            switch (ChartConfig.RealTimeCurveRange)
            {
                case "2分钟":
                    result = "5分钟";
                    break;
                case "5分钟":
                    result = "10分钟";
                    break;
                case "10分钟":
                    result = "15分钟";
                    break;
                case "15分钟":
                    result = "30分钟";
                    break;
                case "30分钟":
                    result = "1小时";
                    break;
                case "1小时":
                    result = "2小时";
                    break;
                default:
                    result = "2小时";
                    break;
            }

            ChartConfig.RealTimeCurveRange = result;
        }

        private void barBtnItem_Freeze_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IsFrozen = !IsFrozen;

            if (IsFrozen)
            {
                barBtnItem_Freeze.Caption = "取消冻结";
            }
            else
            {
                barBtnItem_Freeze.Caption = "冻结";
            }
        }

        private void pcc_CurveConfig_Popup(object sender, EventArgs e)
        {
            LoadCurveConfigData();
        }

        private void chartControl_LegendItemChecked(object sender, LegendItemCheckedEventArgs e)
        {
            ((e.CheckedElement as Series).View as SplineSeriesView).AxisY.Visibility = e.NewCheckState
                ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;

        }

        private void barBtnItem_RestoreDefault_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            chartControl.RestoreMaxMin();
            UpdateDataMinMax();
        }

        private void chartControl_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
        {
            //需要判断是X轴
            if (!string.IsNullOrEmpty(e.Item.AxisValue.ToString()) && e.Item.Axis is DevExpress.XtraCharts.AxisX)
            {
                try
                {
                    //TimeSpan ts = DateTime.Now.Subtract(Convert.ToDateTime(e.Item.AxisValue));
                    //Console.WriteLine(string.Format("now:{0},item:{1}", DateTime.Now, Convert.ToDateTime(e.Item.AxisValue)));
                    //e.Item.Text = string.Format("{0}:{1}:{2}", ts.Hours.ToString().PadLeft(2, '0'), ts.Minutes.ToString().PadLeft(2, '0'), ts.Seconds.ToString().PadLeft(2, '0'));
                    DateTime value = Convert.ToDateTime(e.Item.AxisValue);
                    string hour = value.Hour.ToString().PadLeft(2, '0');
                    string minute = value.Minute.ToString().PadLeft(2, '0');
                    string second = value.Second.ToString().PadLeft(2, '0');
                    e.Item.Text = string.Format("{0}:{1}:{2}", hour, minute, second);
                }
                catch (Exception)
                {

                }


            }
        }

        private void cmb_RealTimeValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_RealTimeValue.Text.Equals("是"))
            {
                chartControl.CurveConfig_ShowRealValue = true;
            }
            else
            {
                chartControl.CurveConfig_ShowRealValue = false;
            }
        }

        private void cmb_ShowAxisX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_ShowAxisX.Text.Equals("是"))
            {
                chartControl.CurveConfig_ShowAxisX = true;
            }
            else
            {
                chartControl.CurveConfig_ShowAxisX = false;
            }
        }

        private void cmb_ShowAxisY_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_ShowAxisY.Text.Equals("是"))
            {
                chartControl.CurveConfig_ShowAxisY = true;
            }
            else
            {
                chartControl.CurveConfig_ShowAxisY = false;
            }
        }
    }
}
;