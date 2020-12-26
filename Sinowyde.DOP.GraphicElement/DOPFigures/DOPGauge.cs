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
    public class DOPGauge : DOPGraphElement
    {
        private DOPGaugeMeters meter = new DOPGaugeMeters();
        public DOPGauge()
            : base()
        {
            (meter.Background as GoRectangle).BrushColor = Color.Transparent;
            (meter.Background as GoRectangle).PenColor = Color.Transparent;
            meter.Width = 200;
            meter.Height = 200;
            meter.Label = new GoText();
            meter.Label.Text = String.Empty;
            Add(meter);

            //ActionScript = ConditionActionExtend.GetInstance(
            //    new ActionType[2] { ActionType.Meter, ActionType.ChangeColor },
            //     new LinkType[2] { LinkType.AO, LinkType.AO }, 5);
        }

        //public override void Refresh()
        //{
        //    foreach (var action in ActionScript)
        //    {
        //        switch (action.LinkType)
        //        {
        //            case LinkType.AO:

        //                if (action.ActionType == ActionType.Meter)
        //                {
        //                    meter.Value = action.RTValue[0].Value;
        //                }
        //                else if (action.ActionType == ActionType.ChangeColor)
        //                {
        //                    if (action.IsExcutedAction)
        //                        for (int i = 0; i < action.Condition.Count; i++)
        //                            if (ConvertUtil.ConvertToDouble(action.Condition[i]) == action.RTValue[0].Value)
        //                            {
        //                                meter.Indicator.BrushColor = action.Colors[i];
        //                            }
        //                }
        //                continue;
        //        }

        //    }
        //}

        protected override ICtrlParamBase CreateCtrlParam()
        {
            return new UCtlMeterParam(this) { Name = "刻度属性" };
        }
    }
}
