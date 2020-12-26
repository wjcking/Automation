using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;
using Northwoods.Go.Instruments;
using System.Windows.Forms;

namespace Sinowyde.DOP.GraphicElement.Base
{
    [Serializable]
    public class DOPBarMeters : Meter
    {
        public DOPBarMeters()
        {
            Orientation = Orientation.Vertical;
            Label = null;
            TopLeftMargin = new SizeF(0, 0);
            BottomRightMargin = new SizeF(0, 0);
        }

        protected override GraduatedScale CreateScale()
        {
            return new GraduatedScaleLinear()
            {
                TickUnit = 2,
                TickMajorFrequency = 10,
                Maximum = 100,
                Minimum = 0,
                Visible = false
            };
        }

        protected override Indicator CreateIndicator()
        {
            return new IndicatorBar()
            {
                BrushColor = Color.Yellow,
                ActionActivated = true,
                ActionEnabled = true,
                Thickness = 5,
                Resizable = true,
                Reshapable = true
            };
        }

        public override void LayoutChildren(GoObject childchanged)
        {
            if (this.Initializing) return;
            base.LayoutChildren(childchanged);
            GraduatedScaleLinear gsl = this.Scale as GraduatedScaleLinear;
            if (gsl != null)
            {
                RectangleF r = gsl.Bounds;
                if (this.Orientation == Orientation.Horizontal)
                {
                    if (r.Width < 40)
                    {
                        gsl.StartPoint = new PointF(r.X + r.Width / 10, r.Y + r.Height / 2);
                        gsl.EndPoint = new PointF(r.X + 9 * r.Width / 10, r.Y + r.Height / 2);
                    }
                    else
                    {
                        gsl.StartPoint = new PointF(r.X + 10, r.Y + r.Height / 2);
                        gsl.EndPoint = new PointF(r.X + r.Width - 10, r.Y + r.Height / 2);
                    }
                    ((IndicatorBar)this.Indicator).Thickness = this.Height;
                    Scale.Width = Background.Width;
                    Scale.Left = Background.Left;
                }
                else
                {
                    if (r.Height < 40)
                    {
                        gsl.StartPoint = new PointF(r.X + r.Width / 2, r.Y + r.Height / 10);
                        gsl.EndPoint = new PointF(r.X + r.Width / 2, r.Y + 9 * r.Height / 10);
                    }
                    else
                    {
                        gsl.StartPoint = new PointF(r.X + r.Width / 2, r.Y + r.Height - 10);
                        gsl.EndPoint = new PointF(r.X + r.Width / 2, r.Y + 10);
                    }
                    ((IndicatorBar)this.Indicator).Thickness = this.Width;
                    Scale.Height = Background.Height;
                    Scale.Top = Background.Top;
                }
            }
        }

        public float Thickness
        {
            get { return ((IndicatorBar)this.Indicator).Thickness; }
            set { ((IndicatorBar)this.Indicator).Thickness = value; }
        }
    }
}
