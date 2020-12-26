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
using DevExpress.XtraCharts;

namespace Sinowyde.DOP.Trend.Control
{
    public partial class ChartEx : DevExpress.XtraEditors.XtraUserControl
    {
        private bool curveConfig_ShowRealValue = false;
        /// <summary>
        /// 显示实际值
        /// </summary>
        [Browsable(true), Description("显示实际值")]
        public bool CurveConfig_ShowRealValue 
        {
            get { return curveConfig_ShowRealValue; } 
            set { curveConfig_ShowRealValue = value; } 
        }

        private bool curveConfig_ShowAxisX = false;

        /// <summary>
        /// 显示X轴
        /// </summary>
        [Browsable(true), Description("显示X轴")]
        public bool CurveConfig_ShowAxisX
        {
            get { return curveConfig_ShowAxisX; }
            set { curveConfig_ShowAxisX = value; }
        }

        private bool curveConfig_ShowAxisY = false;

        /// <summary>
        /// 显示Y轴
        /// </summary>
        [Browsable(true), Description("显示Y轴")]
        public bool CurveConfig_ShowAxisY
        {
            get { return curveConfig_ShowAxisY; }
            set { curveConfig_ShowAxisY = value; }
        }

        public ChartEx()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 更新Series
        /// [如果存在 修改 不存在 添加]
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="item"></param>
        public void UpdateSeries(ChartData item)
        {

            if (chart.Series["DefaultSeries"] != null)
                chart.Series.Remove(chart.Series["DefaultSeries"]);

            Series series = null;
            if (chart.Series[item.Variable.Number] == null)
            {
                //不存在
                series = new Series(item.Variable.Number, ViewType.Spline);
                series.ArgumentDataMember = "Timestamp";
                series.ValueDataMembers[0] = "Value";
                series.DataSource = item.RTValueExList;
                series.ArgumentScaleType = ScaleType.Qualitative;
                series.LabelsVisibility = this.curveConfig_ShowRealValue ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;

                chart.Series.Add(series); //必须先添加
                (chart.Diagram as XYDiagram).DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.True;
                //创建 Series.View -> SplineSeriesView
                SplineSeriesView splineSeriesView = new SplineSeriesView();
                splineSeriesView.ColorEach = true;
                splineSeriesView.AxisYName = string.Format("SecondaryAxisY_{0}", item.Variable.Number);
                splineSeriesView.LineTensionPercent = 50;
                splineSeriesView.Color = item.Color;
                splineSeriesView.LineStyle.DashStyle = (DashStyle)Enum.Parse(typeof(DashStyle), item.LineType, true);

                //创建 SplineSeriesView -> SecondaryAxisY 
                SecondaryAxisY secondaryAxisY = new SecondaryAxisY();
                secondaryAxisY.Visibility = this.curveConfig_ShowAxisY ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
                secondaryAxisY.VisibleInPanesSerializable = "-1";
                secondaryAxisY.WholeRange.Auto = false;
                secondaryAxisY.WholeRange.AutoSideMargins = false;
                secondaryAxisY.WholeRange.SideMarginsValue = 1D;

                ((XYDiagram)chart.Diagram).SecondaryAxesY.Add(secondaryAxisY);

                secondaryAxisY.Name = string.Format("SecondaryAxisY_{0}", item.Variable.Number);
                secondaryAxisY.WholeRange.MaxValue = item.MaxValue;
                secondaryAxisY.WholeRange.MinValue = item.MinValue;
                secondaryAxisY.Color = item.Color;

                splineSeriesView.AxisY = secondaryAxisY;
                series.View = splineSeriesView;

                if (chart.Diagram != null)
                {
                    XYDiagram _XYDiagram = ((XYDiagram)chart.Diagram);
                    _XYDiagram.AxisY.Visibility = DevExpress.Utils.DefaultBoolean.False;
                    _XYDiagram.AxisX.GridLines.Visible = true;
                    _XYDiagram.AxisY.GridLines.Visible = true;
                    _XYDiagram.AxisX.Visibility = this.curveConfig_ShowAxisX? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
                    //_XYDiagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Minute;
                    _XYDiagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Second;
                    _XYDiagram.AxisX.MinorCount = 5;
                    //_XYDiagram.AxisX.CustomLabels.Add(new CustomAxisLabel() { AxisValue = Convert.ToDateTime("2015-12-23 16:00:00") });
                    //_XYDiagram.AxisX.CustomLabels.Add(new CustomAxisLabel() { AxisValue = Convert.ToDateTime("2015-12-23 16:10:00") });
                    //_XYDiagram.AxisX.CustomLabels.Add(new CustomAxisLabel() { AxisValue = Convert.ToDateTime("2015-12-23 16:20:00") });
                    //_XYDiagram.AxisX.CustomLabels.Add(new CustomAxisLabel() { AxisValue = Convert.ToDateTime("2015-12-23 16:30:00") });
                    //_XYDiagram.AxisX.CustomLabels.Add(new CustomAxisLabel() { AxisValue = Convert.ToDateTime("2015-12-23 16:40:00") });
                }

                series.ShowInLegend = true;
                series.CheckedInLegend = true;
            }
            else
            {
                series = chart.Series[item.Variable.Number];

                //修改 series.view
                SplineSeriesView splineSeriesView = series.View as SplineSeriesView;
                splineSeriesView.LineStyle.DashStyle = (DashStyle)Enum.Parse(typeof(DashStyle), item.LineType, true);
                splineSeriesView.Color = item.Color;

                //修改 splineSeriesView.AxisY
                SecondaryAxisY secondaryAxisY = splineSeriesView.AxisY as SecondaryAxisY;
                secondaryAxisY.Name = string.Format("SecondaryAxisY_{0}", item.Variable.Number);
                secondaryAxisY.WholeRange.MaxValue = item.MaxValue;
                secondaryAxisY.WholeRange.MinValue = item.MinValue;
                secondaryAxisY.Color = item.Color;

            }
        }

        /// <summary>
        /// 从ChartControl中移除
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="number"></param>
        public void RemoveSeries(string number)
        {
            Series series = chart.Series[number];
            if (series != null)
            {
                ((XYDiagram)chart.Diagram).SecondaryAxesY.Remove(((SplineSeriesView)chart.Series[number].View).AxisY as SecondaryAxisY);
                chart.Series.Remove(chart.Series[number]);
            }
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="chart"></param>
        public void RefreshSeriesDataSource(List<ChartData> dataSource)
        {
            for (int i = 0; i < chart.Series.Count; i++)
            {
                Series series = chart.Series[i];
                series.DataSource = dataSource.Find(o => o.Variable.Number.Equals(series.Name)).CurrentRTValueExList;
            }
            //以后可能会修改
            chart.RefreshData();
        }

        /// <summary>
        /// 更新Chart配置
        /// </summary>
        /// <param name="chart"></param>
        public void UpdateConfig()
        {
            foreach (Series item in chart.Series)
            {
                item.LabelsVisibility = this.curveConfig_ShowRealValue ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
                for (int i = 0; i < ((XYDiagram)chart.Diagram).SecondaryAxesY.Count; i++)
                {
                    if (((XYDiagram)chart.Diagram).SecondaryAxesY[i].Name == (item.View as SplineSeriesView).AxisY.Name)
                    {
                        ((XYDiagram)chart.Diagram).SecondaryAxesY[i].Visibility = this.curveConfig_ShowAxisY ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
                        break;
                    }
                }
                (item.View as SplineSeriesView).AxisX.Visibility = this.curveConfig_ShowAxisX ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
            }
        }

        /// <summary>
        /// 恢复最大最小值[min:0 max:100]
        /// </summary>
        /// <param name="chart"></param>
        public void RestoreMaxMin()
        {
            if (chart.Series.Count > 0)
            {
                XYDiagram xyDiagram = chart.Diagram as XYDiagram;
                for (int i = 0; i < xyDiagram.SecondaryAxesY.Count; i++)
                {
                    SecondaryAxisY currentY = xyDiagram.SecondaryAxesY[i];
                    currentY.WholeRange.MinValue = 0;
                    currentY.WholeRange.MaxValue = 100;
                }
            }
        }

        /// <summary>
        /// 曲线移动
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="number">变量Number</param>
        /// <param name="Percentage">移动百分比</param>
        public void SeriesMove(string number, double Percentage)
        {
            if (chart.Series.Count > 0)
            {
                XYDiagram xyDiagram = chart.Diagram as XYDiagram;
                for (int i = 0; i < xyDiagram.SecondaryAxesY.Count; i++)
                {
                    SecondaryAxisY currentY = xyDiagram.SecondaryAxesY[i];
                    if (currentY.Name == string.Format("SecondaryAxisY_{0}", number))
                    {
                        double currentMaxValue = Convert.ToDouble(currentY.WholeRange.MaxValue);
                        double currentMinValue = Convert.ToDouble(currentY.WholeRange.MinValue);
                        double maxValue = Math.Abs(currentMaxValue) > Math.Abs(currentMinValue) ? Math.Abs(currentMaxValue) : Math.Abs(currentMinValue);
                        double stepValue = maxValue * Math.Abs(Percentage);

                        if (Percentage < 0)
                        {
                            stepValue = stepValue * -1;
                        }
                        currentY.WholeRange.MinValue = currentMinValue + stepValue;
                        currentY.WholeRange.MaxValue = currentMaxValue + stepValue;
                    }
                }
            }
        }

        /// <summary>
        /// 曲线整体移动
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="Percentage">移动百分比</param>
        public void SeriesAllMove(double Percentage)
        {
            if (chart.Series.Count > 0)
            {
                string[] names = (from c in chart.Series select c.Name).ToArray();
                for (int i = 0; i < names.Length; i++)
                {
                    this.SeriesMove(names[i], Percentage);
                }
            }
        }

        /// <summary>
        /// 曲线放大缩小
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="number"></param>
        /// <param name="Percentage"></param>
        public void SeriesZoom(string number, double Percentage)
        {
            if (chart.Series.Count > 0)
            {
                XYDiagram xyDiagram = chart.Diagram as XYDiagram;
                for (int i = 0; i < xyDiagram.SecondaryAxesY.Count; i++)
                {
                    SecondaryAxisY currentY = xyDiagram.SecondaryAxesY[i];
                    if (currentY.Name == string.Format("SecondaryAxisY_{0}", number))
                    {
                        double currentMaxValue = Convert.ToDouble(currentY.WholeRange.MaxValue);
                        double currentMinValue = Convert.ToDouble(currentY.WholeRange.MinValue);
                        double maxValue = Math.Abs(currentMaxValue) > Math.Abs(currentMinValue) ? Math.Abs(currentMaxValue) : Math.Abs(currentMinValue);
                        double stepValue = maxValue * Math.Abs(Percentage);

                        if (Percentage < 0)
                        {
                            //压缩
                            currentY.WholeRange.MinValue = currentMinValue - stepValue;
                            currentY.WholeRange.MaxValue = currentMaxValue + stepValue;
                        }
                        else
                        {
                            if (Math.Abs(currentMinValue) + Math.Abs(stepValue) < Math.Abs(currentMaxValue))
                            {
                                //放大
                                currentY.WholeRange.MinValue = currentMinValue + stepValue;
                                currentY.WholeRange.MaxValue = currentMaxValue - stepValue;
                            }
                        }
                    }
                }
            }
        }

        public void SeriesAllZoom(double Percentage)
        {
            if (chart.Series.Count > 0)
            {
                string[] names = (from c in chart.Series select c.Name).ToArray();
                for (int i = 0; i < names.Length; i++)
                {
                    this.SeriesZoom(names[i], Percentage);
                }
            }
        }

        /// <summary>
        /// 获取变量的最大最小值
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public Dictionary<string, double[]> GetLimitValue()
        {
            Dictionary<string, double[]> result = new Dictionary<string, double[]>();
            if (chart.Series.Count > 0)
            {
                XYDiagram xyDiagram = chart.Diagram as XYDiagram;
                for (int i = 0; i < xyDiagram.SecondaryAxesY.Count; i++)
                {
                    SecondaryAxisY currentY = xyDiagram.SecondaryAxesY[i];

                    result.Add(currentY.Name.Replace("SecondaryAxisY_", ""), new double[] { (double)currentY.WholeRange.MinValue, (double)currentY.WholeRange.MaxValue });
                }
            }
            return result;
        }

        public ChartControl Chart { get { return this.chart; } }

        private void chartControl_LegendItemChecked(object sender, LegendItemCheckedEventArgs e)
        {
            ((e.CheckedElement as Series).View as SplineSeriesView).AxisY.Visibility = e.NewCheckState
                ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;

        }

        private void chart_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
        {
            if (e.Item.Axis is AxisX)
            {
                //Console.WriteLine(e.Item.AxisValue);
            }
        }


        public void UpdateMeasureUnit(DateTimeMeasureUnit type) 
        {
            if (this.chart.Series!= null && this.chart.Series.Count > 0)
            {
                if (chart.Diagram != null)
                {
                    XYDiagram _XYDiagram = ((XYDiagram)chart.Diagram);_XYDiagram.AxisX.Visibility = this.curveConfig_ShowAxisX ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
                    //_XYDiagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Minute;
                    _XYDiagram.AxisX.DateTimeScaleOptions.MeasureUnit = type;
                }
            }
        }
    }
}
