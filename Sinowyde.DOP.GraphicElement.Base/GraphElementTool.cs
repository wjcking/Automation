using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;

namespace Sinowyde.DOP.GraphicElement.Base
{
    public class GraphElementTool<TElement, TShape> : GoTool
        where TElement : DOPGraphElement
        where TShape : GoObject
    {
        /// <summary>
        /// 创建对象，并加入到视图图层中，没有加入到文档中
        /// </summary>
        protected TElement element = null;
        public GraphElementTool(GoView view)
            : base(view)
        {
            element = System.Activator.CreateInstance<TElement>();            
        }
        /// <summary>
        /// 返回内嵌对象
        /// </summary>
        public virtual TShape Shape
        {
            get
            {
                return element[0] as TShape;
            }
        }
        /// <summary>
        /// 停止操作,将对象加入到文档中
        /// </summary>
        public override void Stop()
        {
            this.View.Cursor = this.View.DefaultCursor;
            this.element.InvalidateViews();
        }
        /// <summary>
        /// 取消动作
        /// </summary>
        public override void DoCancelMouse()
        {
            this.element.Remove();
            this.StopTool();            
        }
        public override void DoKeyDown()
        {
            //回车结束
            if (this.LastInput.Key == System.Windows.Forms.Keys.Enter)
            {
                FinishTool();
            }
            base.DoKeyDown();
        }
        /// <summary>
        /// 技术绘制
        /// </summary>
        protected virtual void FinishTool()
        {
            StartTransaction();
            this.element.Remove();
            this.View.Document.Add(element);
            this.View.Selection.Select(element);
            this.StopTool();
            StopTransaction();            
        }
    }
}
