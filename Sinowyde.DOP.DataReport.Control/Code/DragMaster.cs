using DevExpress.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sinowyde.DOP.DataReport.Control
{

    public class DragMaster
    {
        [ThreadStatic]
        static DragWindow dragWindow;
        bool dragInProgress;
        DragDropEffects effects;
        DragDropEffects lastEffect;
        static Cursor customizationCursor = null;
        double _opacity = 0.7;

        public double Opacity
        {
            get { return _opacity; }
            set { _opacity = value; }
        }
        public DragMaster()
        {
            dragInProgress = false;
            lastEffect = effects = DragDropEffects.None;
        }

        DragWindow DragWindow
        {
            get
            {
                if (dragWindow == null) dragWindow = new DragWindow() { Opacity = this.Opacity };
                return dragWindow;
            }
        }

        public DragDropEffects LastEffect
        {
            get { return lastEffect; }
        }

        public bool DragInProgress
        {
            get { return dragInProgress; }
        }

        /// <summary>
        /// 绘制大小
        /// </summary>
        public Size DragSize
        {
            get
            {
                if (DragWindow.DragBitmap == null) return Size.Empty;
                return DragWindow.DragBitmap.Size;
            }
        }

        /// <summary>
        /// 开始拖拽
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="startPoint"></param>
        /// <param name="effects"></param>
        public void StartDrag(Bitmap bmp, Point startPoint, DragDropEffects effects)
        {
            StopDrag();
            dragInProgress = true;
            this.effects = effects;
            lastEffect = effects;
            DragWindow.MakeTopMost();
            DragWindow.DragBitmap = bmp;
            DragWindow.ShowDrag(startPoint);
            SetDragCursor(effects);
        }

        /// <summary>
        /// 停止拖拽
        /// </summary>
        protected void StopDrag()
        {
            dragInProgress = false;
            lastEffect = effects = DragDropEffects.None;
            DragWindow.HideDrag();
        }

        /// <summary>
        /// 设置拖拽鼠标类型
        /// </summary>
        /// <param name="e"></param>
        public void SetDragCursor(DragDropEffects e)
        {
            if (e == DragDropEffects.None)
                Cursor.Current = CustomizationCursor;
            else
                Cursor.Current = Cursors.Default;
        }
        
        /// <summary>
        /// 拖拽
        /// </summary>
        /// <param name="p"></param>
        /// <param name="e"></param>
        /// <param name="setCursor"></param>
        public void DoDrag(Point p, DragDropEffects e, bool setCursor)
        {
            if (!dragInProgress) return;
            lastEffect = e;
            if (setCursor) SetDragCursor(e);
            DragWindow.MoveDrag(p);
        }
        
        /// <summary>
        /// 取消拖拽
        /// </summary>
        public void CancelDrag()
        {
            if (!dragInProgress) return;
            StopDrag();
        }
        /// <summary>
        /// 结束拖拽
        /// </summary>
        public void EndDrag()
        {
            if (!dragInProgress) return;
            StopDrag();
        }

        /// <summary>
        /// 自定义Cursor
        /// </summary>
        static Cursor CustomizationCursor
        {
            get
            {
                if (customizationCursor == null) customizationCursor = ResourceImageHelper.CreateCursorFromResources("DevExpress.XtraTreeList.Images.customization.cur", typeof(DragMaster).Assembly);
                return customizationCursor;
            }
        }
    }
}
