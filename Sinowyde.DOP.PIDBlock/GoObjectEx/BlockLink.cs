using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwoods.Go;
using Sinowyde.DOP.PIDAlgorithm;

namespace Sinowyde.DOP.PIDBlock.GoObjectEx
{
    //重载一些样式  虚线直线等
    [Serializable]
    public class BlockLink : GoLabeledLink
    {
        public BlockLink()
        {
            this.Orthogonal = true;//拐角
            this.LinkColor = Color.Black;
        }

        private int linkStyle;
        private Color linkColor;

        /// <summary>
        /// 1 实线(数字量),0 虚线(模拟量)
        /// </summary>
        public virtual Color LinkColor
        {
            set
            {
                if (linkStyle == 0)
                    Pen = new Pen(value) { DashStyle = DashStyle.Dot, DashPattern = new float[] { 4, 4 } };  //线长5个像素,间隔2个像素   
                else
                    Pen = new Pen(value) { DashStyle = DashStyle.Solid };

                linkColor = value;
            }
        }

        /// <summary>
        /// 1 实线(数字量),0 虚线(模拟量)
        /// </summary>
        public virtual int LinkStyle
        {
            get { return linkStyle; }
            set
            {
                if (value == 0)
                    Pen = new Pen(linkColor) { DashStyle = DashStyle.Dot, DashPattern = new float[] { 4, 4 } };  //线长5个像素,间隔2个像素   
                else
                    Pen = new Pen(linkColor) { DashStyle = DashStyle.Solid };

                linkStyle = value;
            }
        }

        public virtual int FromPortID
        {
            get;
            set;
        }

        public virtual int ToPortID
        {
            get;
            set;
        }
    }
}
