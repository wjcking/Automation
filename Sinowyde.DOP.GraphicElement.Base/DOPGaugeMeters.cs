using Northwoods.Go;
using Northwoods.Go.Instruments;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Sinowyde.DOP.GraphicElement.Base
{ 

    [Serializable]
    public class DOPGaugeMeters : Meter
    {
        public DOPGaugeMeters()
        {
            this.TopLeftMargin = new SizeF(30, 30);
            this.BottomRightMargin = new SizeF(30, 30);
            if (this.Label != null)
                this.BottomRightMargin = new SizeF(this.BottomRightMargin.Width, this.BottomRightMargin.Height + this.Label.Height);
            myGauge = CreateGauge();
            InsertBefore(this.Scale, myGauge);
        }

        protected override GraduatedScale CreateScale()
        {
            GraduatedScaleElliptical scale = new GraduatedScaleElliptical();
            scale.StartAngle = 110;
            scale.SweepAngle = 320;
            scale.TickUnit = 2;
            scale.TickMajorFrequency = 10;
            scale.TickLengthLeft = 0.1f;
            scale.TickLengthRight = 10;
            scale.LabelDistance = 10;
            return scale;
        }

        protected override Indicator CreateIndicator()
        {
            IndicatorNeedle needle = new IndicatorNeedle();
            needle.ActionEnabled = true;
            needle.Length = this.Scale.Bounds.Height / 2;
            needle.Style = IndicatorNeedleStyle.Kite;
            needle.Thickness = 20;
            needle.BrushColor = Color.Red;
            return needle;
        }

        /// <summary>
        /// Method for creating an instance of the meter's standard indicator.
        /// </summary>
        /// <returns></returns>
        protected virtual IndicatorBar CreateGauge()
        {
            IndicatorBarElliptical gauge = new IndicatorBarElliptical();
            gauge.Thickness = 20;

            gauge.AddPhase(new Phase(0, 75, Color.Green));
            gauge.AddPhase(new Phase(75, 90, Color.Yellow));

            gauge.Scale = this.Scale;
            gauge.Value = gauge.Scale.Maximum;

            return gauge;
        }

        /// <summary>
        /// Gets or sets the IndicatorBar which is used to display regions on the scale.
        /// </summary>
        public IndicatorBar Gauge
        {
            get { return myGauge; }
            set
            {
                IndicatorBar old = myGauge;
                if (old != value)
                {
                    if (old != null)
                        Remove(old);
                    myGauge = value;
                    if (value != null)
                        InsertBefore(this.Scale, value);
                    Changed(ChangedGauge, 0, old, NullRect, 0, value, NullRect);
                }
            }
        }

        public override void LayoutChildren(GoObject childchanged)
        {
            if (this.Initializing) return;
            base.LayoutChildren(childchanged);
            if (this.Scale != null)
            {
                if (this.Gauge != null)
                {
                    RectangleF r = this.Scale.Bounds;
                    //r.Inflate(-this.Gauge.Thickness, -this.Gauge.Thickness);
                    this.Gauge.Bounds = r;
                }
                IndicatorNeedle ineedle = this.Indicator as IndicatorNeedle;
                if (ineedle != null)
                {
                    ineedle.PivotPoint = this.Scale.Center;
                    if (((IndicatorNeedle)this.Indicator).ConstantLength)
                        ineedle.Length = Math.Min(this.Scale.Width / 2, this.Scale.Height / 2);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newgroup"></param>
        /// <param name="env"></param>
        protected override void CopyChildren(GoGroup newgroup, GoCopyDictionary env)
        {
            base.CopyChildren(newgroup, env);
            DOPGaugeMeters newobj = (DOPGaugeMeters)newgroup;
            newobj.myGauge = (IndicatorBar)env[myGauge];
            newobj.myGauge.Scale = newobj.Scale;
        }

        /// <summary>
        /// If any part is removed from this group,
        /// be sure to remove any references in local fields.
        /// </summary>
        /// <param name="obj"></param>
        public override bool Remove(GoObject obj)
        {
            bool result = base.Remove(obj);
            if (obj == myGauge)
                myGauge = null;
            return result;
        }


        /// <summary>
        /// Handle undo and redo changes.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="undo"></param>
        public override void ChangeValue(GoChangedEventArgs e, bool undo)
        {
            switch (e.SubHint)
            {
                case ChangedGauge:
                    this.Gauge = (IndicatorBar)e.GetValue(undo);
                    return;
                default:
                    base.ChangeValue(e, undo);
                    return;
            }
        }

        /// <summary>
        /// This is a <see cref="GoObject.Changed"/> subhint.
        /// </summary>
        public const int ChangedGauge = 13800;

        private IndicatorBar myGauge;
    }
}
