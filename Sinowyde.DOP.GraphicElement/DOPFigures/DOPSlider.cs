using System;
using System.Collections.Generic;
using System.Drawing;
using Sinowyde.DOP.DataModel;
using Sinowyde.DOP.GraphicElement.Base;

namespace Sinowyde.DOP.GraphicElement
{
    /// <summary>
    /// 绘制按钮
    /// </summary>
    [Serializable]
    public class DOPSlider : DOPGeneralShape
    {
        public DOPSlider()
            : base()
        {
            var m = new SliderMeter();
            m.Width = 18;
            m.Height = 140;

            m.BackRectangle.PenColor = Color.Transparent;
            m.BackRectangle.BrushColor = Color.Transparent;
            m.Indicator.Visible = false;
            m.Label.Text = String.Empty;
            this.Object = m;  
        }

        public override void Refresh()
        {

        }

        public override void ShowParam()
        {
            new FrmGraphParam(new UCtlMeterParam(this), "刻度").ShowDialog();
        }

        public override Northwoods.Go.GoContextMenu GetContextMenu(Northwoods.Go.GoView view)
        {
            throw new NotImplementedException();
        }
    }
}
