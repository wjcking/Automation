using Northwoods.Go;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Sinowyde.DOP.GraphicElement.Base;
using Northwoods.Go.Instruments;
using Sinowyde.DOP.DataModel;

using Sinowyde.Util;


namespace Sinowyde.DOP.GraphicElement
{
    /// <summary>
    /// 柱形
    /// </summary>
    [Serializable]
    public class DOPBar : DOPGraphElement
    {
        private DOPBarMeters barMeter = new DOPBarMeters();
        private Color indicatorColor = Color.Empty;

        public DOPBar()
            : base()
        {
            Add(barMeter);
            barMeter.Label.Text = "";
            barMeter.Scale = new GraduatedScaleLinear();
            barMeter.Scale.Visible = true;
            barMeter.Scale.TickUnit = 2;
            barMeter.Indicator.ActionActivated = true;
            barMeter.Controllable = true;
            barMeter.BottomRightMargin = new SizeF(4, 4);
            barMeter.TopLeftMargin = new SizeF(4, 4);
            barMeter.Scale.TickMajorFrequency = 10;
            barMeter.Thickness = 30;
            barMeter.Scale.Maximum = 100;
            barMeter.Scale.Minimum = 0;
            barMeter.Indicator = new IndicatorBar();
            barMeter.Indicator.Visible = false;;
            barMeter.Indicator.ActionEnabled = true;
            // barMeter.Indicator.Scale = m.Scale;
            barMeter.Indicator.BrushColor = Color.Yellow;
            barMeter.Indicator.Value = 50;
            barMeter.Width = 18;
            barMeter.Height = 180;
            //barMeter.BackRectangle.PenColor = Color.Transparent;
            //ActionScript = ConditionActionExtend.GetInstance(
            //    new ActionType[2] { ActionType.Meter, ActionType.ChangeColor },
            //     new LinkType[2] { LinkType.AO, LinkType.AO }, 5);
        }

        //public override void Refresh()
        //{
        //    //foreach (var action in ActionScript)
        //    //{
        //    //    switch (action.LinkType)
        //    //    {
        //    //        case LinkType.AO:

        //    //            if (action.ActionType == ActionType.Meter)
        //    //            {
        //    //                barMeter.Value = action.RTValue[0].Value;
        //    //            }
        //    //            else if (action.ActionType == ActionType.ChangeColor)
        //    //            {
        //    //                if (action.IsExcutedAction)
        //    //                {
        //    //                    bool isChanged = false;
        //    //                    for (int i = 0; i < action.Condition.Count; i++)
        //    //                    {
        //    //                        if (ConvertUtil.ConvertToDouble(action.Condition[i]) == action.RTValue[0].Value)
        //    //                        {
        //    //                            isChanged = true;
        //    //                            barMeter.Indicator.BrushColor = action.Colors[i];
        //    //                        }
        //    //                    }

        //    //                    if (!isChanged)
        //    //                    {
        //    //                        barMeter.Indicator.BrushColor = barMeter.BarColor;
        //    //                    }
        //    //                }
        //    //            }
        //    //            continue;
        //    //    }

        //    //}
        //}

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new UCtlMeterParam(this) { Name = "棒图属性" };
        }
    }
}
