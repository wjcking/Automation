using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwoods.Go;
using Northwoods.Go.Draw;

namespace Sinowyde.DOP.UI
{
    public class GoDrawViewEx : GoDrawView
    {
        public delegate void EventHandler();
        public event EventHandler ScaleChangedEvent;


        public override float DocScale
        {
            get
            {
                return base.DocScale;
            }
            set
            {

                base.DocScale = value;
                if (null != ScaleChangedEvent)
                    ScaleChangedEvent();
            }
        }

        public GoDrawViewEx()
        {            
            Dock = DockStyle.Fill;
            DragsRealtime = true; //拖动刷新
            //ExternalDragDropsOnEnter = true;
            //GridSnapDrag = GoViewSnapStyle.Jump;
        }
        protected override void OnMouseWheel(MouseEventArgs e) 
        {
            base.OnMouseWheel(e);
        }

        public virtual void ZoomIn()
        {
            this.DocScale = (float)(Math.Round(this.DocScale / 0.9f * 100) / 100);
        }

        public virtual void ZoomOut()
        {
            this.DocScale = (float)(Math.Round(this.DocScale * 0.9f * 100) / 100);
        }

        public virtual void Zoom(float docScale = 1)
        {
            this.DocScale = docScale;
        }        
    }
}
