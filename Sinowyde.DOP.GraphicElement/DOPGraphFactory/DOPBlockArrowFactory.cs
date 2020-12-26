using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;
using Sinowyde.DOP.GraphicElement.Base;

namespace Sinowyde.DOP.GraphicElement
{
    [Serializable]
    public class DOPBlockArrowFactory : GoPolygon
    {
        private const int ChangedCanonicalPoints = GoObject.LastChangedHint + 100;

        public const int ArrowShapeID = 101;
        public const int ArrowWidthID = 102;
        public const int ArrowStartID = 103;
        public const int ArrowEndID = 104;

        public PointF[] myCanonicalPoints = new PointF[8] {
          new PointF(-1.0f,  0.0f),
          new PointF(-1.0f, -0.1f),
          new PointF(-0.3f, -0.1f),
          new PointF(-0.3f, -0.2f),

          new PointF( 0.0f,  0.0f),
          new PointF(-0.3f,  0.2f),
          new PointF(-0.3f,  0.1f),
          new PointF(-1.0f,  0.1f)
        };

        

        public DOPBlockArrowFactory() 
        {
            SetPoints(myCanonicalPoints);
            this.Size = new SizeF(100, 50);
        }

        private PointF[] ClonePoints()
        {
            return (PointF[])myCanonicalPoints.Clone();
        }

        public PointF StartPoint
        {
            get { return GetPoint(0); }
            set
            {
                SetPoint(0, value);
                ResetPoints();
            }
        }

        public PointF EndPoint
        {
            get { return GetPoint(4); }
            set
            {
                SetPoint(4, value);
                ResetPoints(); 
            }
        }

        private void ResetPoints()
        {
            PointF[] v = ClonePoints();
            DecanonicalizePoints(v);
            v[0] = this.StartPoint;
            v[4] = this.EndPoint;
            SetPoints(v);
        }

        private void DecanonicalizePoints(PointF[] v)
        {
            PointF sp = this.StartPoint;
            PointF ep = this.EndPoint;
            float dx = ep.X - sp.X;
            float dy = ep.Y - sp.Y;
            float len = (float)Math.Sqrt(dx * dx + dy * dy);
            if (len > 0)
            {
                float cosine = dx / len;
                float sine = dy / len;
                for (int i = 0; i < v.Length; i++)
                {
                    PointF p = v[i];
                    PointF q = new PointF();
                    q.X = (cosine * p.X - sine * p.Y);
                    q.Y = (sine * p.X + cosine * p.Y);
                    q.X *= len;
                    q.Y *= len;
                    q.X += ep.X;
                    q.Y += ep.Y;
                    v[i] = q;
                }
            }
        }

        private PointF CanonicalizePoint(PointF p)
        {
            PointF sp = this.StartPoint;
            PointF ep = this.EndPoint;
            float dx = ep.X - sp.X;
            float dy = ep.Y - sp.Y;
            float len = (float)Math.Sqrt(dx * dx + dy * dy);
            PointF q = p;
            if (len > 0)
            {
                float cosine = dx / len;
                float sine = dy / len;
                p.X -= ep.X;
                p.Y -= ep.Y;
                p.X /= len;
                p.Y /= len;
                q.X = (cosine * p.X + sine * p.Y);
                q.Y = (-sine * p.X + cosine * p.Y);
            }
            return q;
        }

        private RectangleF CanonicalBounds()
        {
            float minX = Math.Min(myCanonicalPoints[0].X, myCanonicalPoints[4].X);
            float maxX = Math.Max(myCanonicalPoints[0].X, myCanonicalPoints[4].X);
            float minY = Math.Min(myCanonicalPoints[2].Y, myCanonicalPoints[3].Y);
            float maxY = Math.Max(myCanonicalPoints[5].Y, myCanonicalPoints[6].Y);
            return new RectangleF(minX, minY, maxX - minX, maxY - minY);
        }

        public override void AddSelectionHandles(GoSelection sel, GoObject selectedObj)
        {
            RemoveSelectionHandles(sel);

            IGoHandle handle;
            GoHandle goh;
            if (CanReshape())
            {
                handle = sel.CreateResizeHandle(this, selectedObj, GetPoint(2), ArrowShapeID, true);
                goh = handle.GoObject as GoHandle;
                if (goh != null)
                {
                    goh.Style = GoHandleStyle.Diamond;
                    goh.BrushColor = Color.Yellow;
                    RectangleF b = goh.Bounds;
                    b.Inflate(1, 1);
                    goh.Bounds = b;
                }
                handle = sel.CreateResizeHandle(this, selectedObj, GetPoint(3), ArrowWidthID, true);
                goh = handle.GoObject as GoHandle;
                if (goh != null)
                {
                    goh.Style = GoHandleStyle.Diamond;
                    goh.BrushColor = Color.Yellow;
                    RectangleF b = goh.Bounds;
                    b.Inflate(1, 1);
                    goh.Bounds = b;
                }
            }
            handle = sel.CreateResizeHandle(this, selectedObj, this.StartPoint, CanResize() ? ArrowStartID : NoHandle, true);
            goh = handle.GoObject as GoHandle;
            if (goh != null)
            {
                goh.Style = GoHandleStyle.Ellipse;
                if (CanResize()) goh.BrushColor = Color.Yellow;
            }
            handle = sel.CreateResizeHandle(this, selectedObj, this.EndPoint, CanResize() ? ArrowEndID : NoHandle, true);
            goh = handle.GoObject as GoHandle;
            if (goh != null)
            {
                goh.Style = GoHandleStyle.Ellipse;
                if (CanResize()) goh.BrushColor = Color.Yellow;
            }
        }

        public override void DoResize(GoView view, RectangleF origRect, PointF newPoint, int whichHandle, GoInputState evttype, SizeF min, SizeF max)
        {
            if (whichHandle == ArrowShapeID)
            {
                PointF p = CanonicalizePoint(newPoint);
                RectangleF b = CanonicalBounds();
                float midY = b.Y + b.Height / 2;
                PointF sp = myCanonicalPoints[0];
                PointF ep = myCanonicalPoints[4];
                float minX = Math.Min(sp.X, ep.X);
                float maxX = Math.Max(sp.X, ep.X);
                p.X = Math.Max(p.X, minX);
                p.X = Math.Min(p.X, maxX);
                p.Y = Math.Min(p.Y, midY);
                float mirrorY = midY + (midY - p.Y);
                PointF[] oldCanonicalPoints = ClonePoints();
                PointF q;
                q = myCanonicalPoints[1];
                myCanonicalPoints[1] = new PointF(q.X, p.Y);
                myCanonicalPoints[2] = p;
                q = myCanonicalPoints[6];
                myCanonicalPoints[6] = new PointF(p.X, mirrorY);
                q = myCanonicalPoints[7];
                myCanonicalPoints[7] = new PointF(q.X, mirrorY);
                Changed(ChangedCanonicalPoints, 0, oldCanonicalPoints, NullRect, 0, ClonePoints(), NullRect);
                ResetPoints();  // set all of the actual polygon points
            }
            else if (whichHandle == ArrowWidthID)
            {
                PointF p = CanonicalizePoint(newPoint);
                RectangleF b = CanonicalBounds();
                float midY = b.Y + b.Height / 2;
                PointF sp = myCanonicalPoints[0];
                PointF ep = myCanonicalPoints[4];
                float minX = Math.Min(sp.X, ep.X);
                float maxX = Math.Max(sp.X, ep.X);
                p.X = Math.Max(p.X, minX);
                p.X = Math.Min(p.X, maxX);
                p.Y = Math.Min(p.Y, midY);
                float mirrorY = midY + (midY - p.Y);
                PointF[] oldCanonicalPoints = ClonePoints();
                PointF q;
                q = myCanonicalPoints[3];
                myCanonicalPoints[3] = p;
                q = myCanonicalPoints[5];
                myCanonicalPoints[5] = new PointF(p.X, mirrorY);
                Changed(ChangedCanonicalPoints, 0, oldCanonicalPoints, NullRect, 0, ClonePoints(), NullRect);
                ResetPoints();
            }
            else if (whichHandle == ArrowStartID)
            {
                if (newPoint != this.EndPoint)
                {
                    this.StartPoint = newPoint;
                }
            }
            else if (whichHandle == ArrowEndID)
            {
                if (newPoint != this.StartPoint)
                {
                    this.EndPoint = newPoint;
                }
            }
            else
            {
                base.DoResize(view, origRect, newPoint, whichHandle, evttype, min, max);
            }
        }

        public override void ChangeValue(GoChangedEventArgs e, bool undo)
        {
            if (e.SubHint == ChangedCanonicalPoints)
            {
                Array.Copy((PointF[])e.GetValue(undo), myCanonicalPoints, myCanonicalPoints.Length);
            }
            else
            {
                base.ChangeValue(e, undo);
            }
        }
    }
}
