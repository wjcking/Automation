using Northwoods.Go;
using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Resources;
using System.Drawing.Drawing2D;
using Sinowyde.DOP.PIDBlock.GoObjectEx;
using System.Reflection;

namespace Sinowyde.DOP.PIDBlock
{
    /// <summary>
    /// ≮≯
    /// </summary>
    public class DrawBlockUtil
    {
        private static System.Resources.ResourceManager resManager;

        /// <summary>
        /// 图片资源
        /// </summary>
        public static System.Resources.ResourceManager ResManager
        {
            get
            {
                if (resManager == null)
                {
                    resManager = new System.Resources.ResourceManager(Assembly.GetCallingAssembly().GetName().Name + ".Properties.Resources", Assembly.GetCallingAssembly());
                    //resManager = new System.Resources.ResourceManager("Sinowyde.DOP.PIDBlock.Properties.Resources", typeof(Sinowyde.DOP.PIDBlock.Properties.Resources).Assembly);
                }
                return resManager;
            }
        }

        /// <summary>
        /// 获取className所在的程序集中的ResourceManager
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public static System.Resources.ResourceManager GetImageManager(object className)
        {
            Assembly assembly = Assembly.GetAssembly(className.GetType());
            System.Resources.ResourceManager m = new System.Resources.ResourceManager(assembly.GetName().Name + ".Properties.Resources", assembly);
            return m;
        }

        /// <summary>
        /// 获取className所在的程序集中的ResourceManager并根据imageName查找图片
        /// </summary>
        /// <param name="className"></param>
        /// <param name="imageName"></param>
        /// <returns></returns>
        public static System.Drawing.Image GetImageManager(object className, string imageName)
        {
            Assembly assembly = Assembly.GetAssembly(className.GetType());
            System.Resources.ResourceManager m = new System.Resources.ResourceManager(assembly.GetName().Name + ".Properties.Resources", assembly);
            System.Drawing.Image image = (System.Drawing.Image)m.GetObject(imageName);
            return image;
        }

        /// <summary>
        /// 绘制图元
        /// </summary>
        /// <param name="block">PIDNode</param>
        /// <param name="iconName">icon名称</param>
        /// <param name="frameShape">外边框</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="leftPorts">左侧端口文字数组</param>
        /// <param name="rightPorts">右侧端口文字数组</param>
        public static void Draw(PIDGeneralBlock block, string iconName, GoFigure frameShape = GoFigure.None, float width = 10f, float height = 10f, bool imageSizeSet = false)
        {
            GoGroup group = new GoGroup();
            group.Selectable = false;
            group.Size = new SizeF(width, height);

            GoDrawing shape = new GoDrawing(frameShape);
            shape.Size = new SizeF(width, height);
            shape.Selectable = false;
            if (!string.IsNullOrEmpty(iconName))
            {
                GoImage image = new GoImage();
                image.Selectable = false;
                image.Image = GetImageManager(block, iconName);
                //image.Name = iconName;
                if (imageSizeSet)
                    image.Size = new SizeF(width, height);
                image.Center = group.Center;
                group.Add(image);
                group.AddChildName("backGroundImage", image);
            }

            group.Add(shape);


            block.Icon = group;

        }

        /// <summary>
        /// 绘制自定义图元
        /// </summary>
        /// <param name="block"></param>
        /// <param name="drawing"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void Draw(PIDGeneralBlock block, GoDrawing drawing, float width, float height)
        {
            GoGroup group = new GoGroup();
            group.Selectable = false;
            group.Size = new SizeF(width, height);

            drawing.Selectable = false;
            drawing.Size = new SizeF(width, height);

            GoDrawing line = new GoDrawing();
            line.Selectable = false;
            line.StartAt(0, height / 2);
            line.LineTo(width, height / 2);
            line.CloseFigure();

            GoText topTxt = new GoText();
            topTxt.Selectable = false;
            topTxt.Text = "0";
            topTxt.Center = new PointF(line.Center.X, line.Center.Y - 10);

            GoText bottomTxt = new GoText();
            bottomTxt.Selectable = false;
            bottomTxt.Text = "0";
            bottomTxt.Center = new PointF(line.Center.X, line.Center.Y + 10);

            group.Add(drawing);
            group.Add(topTxt);
            group.Add(bottomTxt);
            group.Add(line);
            group.AddChildName("topText", topTxt);
            group.AddChildName("bottomText", bottomTxt);
            group.AddChildName("line", line);

            block.Icon = group;
        }
        /// <summary>
        /// 绘制多边形
        /// </summary>
        /// <param name="block"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        public static GoDrawing DrawPolygon(PointF[] points)
        {
            GoDrawing drawPolygon = new GoDrawing();
            drawPolygon.PenWidth = 0.1f;
            drawPolygon.StartAt(points[0]);
            for (int i = 1; i < points.Length; i++)
            {
                drawPolygon.LineTo(points[i]);
            }
            drawPolygon.CloseFigure();
            return drawPolygon;
        }

        /// <summary>
        /// 绘制图元文字
        /// </summary>
        /// <param name="block"></param>
        /// <param name="content">文字内容</param>
        /// <param name="pf">文字的中心坐标</param>
        public static void DrawText(PIDGeneralBlock block, string content, PointF pf, float fontSize = 10)
        {

            GoObject obj = block.FindChild("txt");
            if (obj != null)
            {

                obj.Remove();
            }
            GoText txt = new GoText();
            txt.Selectable = false;
            txt.Editable = false;
            txt.Text = content;
            txt.Center = pf;
            txt.FontSize = fontSize;
            block.Add(txt);
            block.AddChildName("txt", txt);

            //if (obj == null)
            //{
            //    GoText txt = new GoText();
            //    txt.Selectable = false;
            //    txt.Editable = false;
            //    txt.Text = content;
            //    txt.Center = block.Icon.Center;
            //    txt.FontSize = fontSize;
            //    block.Add(txt);
            //    block.AddChildName("txt", txt);
            //}
            //else
            //{
            //    GoText txt = (obj as GoText);
            //    txt.Selectable = false;
            //    txt.Editable = false;
            //    txt.Text = content;
            //    txt.Center = block.Icon.Center;
            //    txt.FontSize = fontSize;
            //}
        }

        /// <summary>
        /// gofigure 绘制外边框，填充文字
        /// </summary>
        /// <param name="block"></param>
        /// <param name="gofigure"></param>
        /// <param name="iconSize"></param>
        /// <param name="content"></param>
        /// <param name="fontSize"></param>
        public static void DrawIconWithText(PIDGeneralBlock block, GoFigure gofigure, SizeF iconSize, string content, float fontSize)
        {
            block.Icon = new GoDrawing(gofigure);
            block.Shape.Size = iconSize;
            System.Drawing.PointF pf = block.Icon.Center;
            if (gofigure == GoFigure.Buffer)
            {
                //横三角形需要处理一下中心位置
                pf.X -= 10;
            }
            DrawText(block, content, pf, fontSize);
        }
    }

    public static class PIDBlockEx
    {
        public static void ChangeIconImage(this PIDGeneralBlock obj, string imageName)
        {
            if (obj.Icon is GoGroup)
            {
                GoGroup group = obj.Icon as GoGroup;
                System.Resources.ResourceManager manage = new System.Resources.ResourceManager(obj.GetType().Namespace + ".Properties.Resources", obj.GetType().Assembly);
                GoImage image = new GoImage();
                image.Image = (System.Drawing.Image)manage.GetObject(imageName);
                image.Center = group.Center;
                image.Selectable = false;
                group.Remove(group.FindChild("backGroundImage"));
                group.Add(image);
                group.AddChildName("backGroundImage", image);
                obj.Icon = group;
            }
        }
    }
}
