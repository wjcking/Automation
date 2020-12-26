using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sinowyde.DOP.DataReport.Control
{
    /// <summary>
    /// 拖拽窗口
    /// </summary>
    public partial class DragWindow : DevExpress.Utils.Win.TopFormBase
    {
        private Bitmap dragBitmap;
        private bool dragging;
        private Point hotSpot;
        public static readonly Point InvisiblePoint = new Point(-100000, -100000);

        public DragWindow()
        {
            hotSpot = Point.Empty;
            dragging = false;
            SetStyle(ControlStyles.Selectable, false);
            this.Size = Size.Empty;
            this.ShowInTaskbar = false;
            Form prevActive = Form.ActiveForm;
            InitializeComponent();
        }

        void ActivateForm(object sender, EventArgs e)
        {
            Form form = sender as Form;
            if (form == null || !form.IsHandleCreated) return;
            form.Activate();
        }

        public void MakeTopMost()
        {
            UpdateZOrder();
        }

        private void InitializeComponent()
        {
            this.StartPosition = FormStartPosition.Manual;
            dragBitmap = null;
            this.Enabled = false;
            this.MinimumSize = Size.Empty;
            this.Size = Size.Empty;
            this.Location = InvisiblePoint;
            this.Visible = false;
            this.TabStop = false;
            this.Opacity = 0.7;// DevExpress.Utils.DragDrop.DragWindow.DefaultOpacity;
        }

        protected void InternalMoveBitmap(Point p)
        {
            //p.Offset(-hotSpot.X, -hotSpot.Y);
            this.SuspendLayout();
            this.Location = p;
            this.ResumeLayout();
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
        }

        public bool ShowDrag(Point p)
        {
            if (this.BackgroundImage == null) return false;
            dragging = true;
            Visible = true;
            Refresh();
            InternalMoveBitmap(p);
            return true;
        }

        public bool MoveDrag(Point p)
        {
            if (!dragging) return false;
            InternalMoveBitmap(p);
            return true;
        }

        public bool HideDrag()
        {
            if (!dragging) return false;
            Visible = false;
            BackgroundImage = null;
            dragging = false;
            this.SuspendLayout();
            this.Size = Size.Empty;
            this.Location = InvisiblePoint;
            this.ResumeLayout();
            return true;
        }

        public Point HotSpot { get { return hotSpot; } set { hotSpot = value; } }

        public Bitmap DragBitmap
        {
            get { return dragBitmap; }
            set
            {
                this.BackgroundImage = value;
                if (value == null)
                {
                    HideDrag();
                }
                else
                    hotSpot = new Point(value.Size.Width / 2, value.Size.Height / 2);
                dragBitmap = value;
                Size = BackgroundImage.Size;
            }
        }
    }
}
