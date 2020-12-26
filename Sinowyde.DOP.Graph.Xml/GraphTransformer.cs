using Northwoods.Go;
using Northwoods.Go.Xml;
using Sinowyde.DOP.GraphicElement.Base;
using Sinowyde.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Drawing.Drawing2D;
using Northwoods.Go.Instruments;
using System.Resources;

namespace Sinowyde.DOP.Graph.Xml
{
    
    /// <summary>
    /// 组态图 序列化转换
    /// </summary>
    public class GraphTransformer : GoXmlTransformer
    {
        public GraphTransformer()
        {
            this.ElementName = "Graph";
            this.TransformerType = typeof(DOPGraphElement);
            this.BodyConsumesChildElements = true;
        }
        /// <summary>
        /// 创建对象
        /// </summary>
        /// <returns></returns>
        public override object Allocate()
        {
            string elementType = StringAttr("ElementType", "?");
            string elementAssembly = StringAttr("ElementAssembly", "?");
            if (!string.IsNullOrEmpty(elementType) && !string.IsNullOrEmpty(elementAssembly))
            {
                ObjectHandle handle = System.Activator.CreateInstance(elementAssembly, elementType);
                return handle.Unwrap();
            }
            else
                return null;
        }
        /// <summary>
        /// 生成xml文件节点
        /// </summary>
        /// <param name="obj"></param>
        public override void GenerateAttributes(Object obj)
        {
            base.GenerateAttributes(obj);
            DOPGraphElement element = obj as DOPGraphElement;
            WriteAttrVal("ElementType", element.GetType().FullName);
            WriteAttrVal("ElementAssembly", element.GetType().Assembly.FullName);
            WriteAttrVal("Location", element.Location);
            WriteAttrVal("Size", element.Size);
        }
        /// <summary>
        /// 生成json动画
        /// </summary>
        /// <param name="element"></param>
        private void GenerateAction(DOPGraphElement element)
        {
            string actionScript = element.ActionToJson();
            WriteAttrVal("ActionScript", actionScript);
        }
        /// <summary>
        /// 生成子对象
        /// </summary>
        /// <param name="shape"></param>
        private void GenerateChild(GoObject child)
        {
            WriteAttrVal("Location", child.Location);
            WriteAttrVal("Size", child.Size);
            GoArc arc = child as GoArc;
            if (arc != null)
            {
                GenerateArc(arc);
                return;
            }
            //文本
            GoText text = child as GoText;
            if (text != null)
            {
                GenerateText(text);
                return;
            }
            //圆角矩形
            if (child is GoRoundedRectangle)
            {
                GenerateRoundRetangle(child as GoRoundedRectangle);
                return;
            }
            //矩形
            if (child is GoRectangle)
            {
                GenerateShape(child as GoRectangle);
                return;
            }
            //椭圆
            if (child is GoEllipse)
            {
                GenerateShape(child as GoEllipse);
                return;
            }
            //多边形
            if (child is GoPolygon)
            {
                GeneratePolygon(child as GoPolygon);
                return;
            }
            //绘制工具
            if (child is GoStroke)
            {
                GenerateStroke(child as GoStroke);
                return;
            }
            //绘图
            if (child is GoDrawing)
            {
                GenerateDrawing(child as GoDrawing);
                return;
            }
            //图片
            if (child is GoImage)
            {
                GenerateImage(child as GoImage);
                return;
            }
            //按钮
            if (child is GoButton)
            {
                GenerateButton(child as GoButton);
                return;
            }
            //仪表
            if (child.GetType().Name.Contains("Meter"))
            {
                GenerateMeter(child as Meter);
                return;
            }
            
        }
        /// <summary>
        /// 记录shape属性
        /// </summary>
        /// <param name="shape"></param>
        private void GenerateShape(GoShape obj)
        {
            WriteAttrVal("Bounds", obj.Bounds);
            WriteAttrVal("BrushColor", obj.BrushColor);
            WriteAttrVal("BrushFocusScales", obj.BrushFocusScales);
            WriteAttrVal("BrushForeColor", obj.BrushForeColor);
            WriteAttrVal("BrushMidColor", obj.BrushMidColor);
            WriteAttrVal("BrushMidFraction", obj.BrushMidFraction);
            WriteAttrVal("BrushPoint", obj.BrushPoint);
            WriteAttrVal("BrushStartPoint", obj.BrushStartPoint);
            WriteAttrVal("BrushStyle", (int)obj.BrushStyle);
            WriteAttrVal("PenColor", obj.PenColor);
            WriteAttrVal("PenWidth", obj.PenWidth);

        }
        /// <summary>
        /// 记录button属性
        /// </summary>
        /// <param name="obj"></param>
        private void GenerateButton(GoButton obj)
        {
            if (obj.Label == null)
            {
                WriteAttrRef("Image", (obj.Icon as GoImage).Image);
                WriteAttrVal("Name", (obj.Icon as GoImage).Name);
                WriteAttrVal("NameIsUri", false);
            }
            else
            {
                GenerateText(obj.Label);
            }
            WriteAttrVal("Bounds", obj.Bounds);
            WriteAttrVal("TopLeftMargin", obj.TopLeftMargin);
            WriteAttrVal("BottomRightMargin", obj.BottomRightMargin);
            WriteAttrVal("ActionActivated",obj.ActionActivated);
            WriteAttrVal("ActionEnabled",obj.ActionEnabled);
            WriteAttrVal("AutoRepeating",obj.AutoRepeating);
            WriteAttrVal("BrushColor", (obj.Background as GoRectangle).BrushColor);
        }
        /// <summary>
        /// 记录Meter属性
        /// </summary>
        /// <param name="obj"></param>
        private void GenerateMeter(Meter obj)
        {
            if (obj.Indicator.GetType() == typeof(IndicatorNeedle))
            {
                WriteAttrVal("Thickness", ((IndicatorNeedle)obj.Indicator).Thickness);
            }
            else
            {
                WriteAttrVal("Thickness", ((IndicatorBar)obj.Indicator).Thickness);
                WriteAttrVal("StartOffset", ((IndicatorBar)obj.Indicator).StartOffset);
            }

            if (obj.Scale.GetType() == typeof(GraduatedScaleLinear))
            {
                GraduatedScaleLinear gsl = obj.Scale as GraduatedScaleLinear;
                WriteAttrVal("StartPoint", gsl.StartPoint);
                WriteAttrVal("EndPoint", gsl.EndPoint);

            }
 
            WriteAttrVal("Value", (float)obj. Value);
            WriteAttrVal("Indicator.Value", (float)obj.Indicator.Value);
            WriteAttrVal("Maximum", (float)obj.Maximum);
            WriteAttrVal("Minimum", (float)obj.Minimum);
            WriteAttrVal("Scale.Maximum", (float)obj.Scale.Maximum);
            WriteAttrVal("Scale.Minimum", (float)obj.Scale.Minimum);
            WriteAttrVal("TickMajorFrequency", obj.TickMajorFrequency);
            WriteAttrVal("TickUnit", (float)obj.TickUnit);
            WriteAttrVal("BrushColor", (obj.Background as GoRectangle).BrushColor);
            WriteAttrVal("ForeColor", obj.Indicator.BrushColor);
            WriteAttrVal("Orientation", (int)obj.Orientation);
            WriteAttrVal("Indicator.Visible", obj.Indicator.Visible);
            WriteAttrVal("Indicator.BrushColor", obj.Indicator.BrushColor);
            WriteAttrVal("Scale.Visible", obj.Scale.Visible);
            //WriteAttrVal("Text", obj.Label.Text);
            //WriteAttrVal("Label.Visible", obj.Label.Visible);

        }
        /// <summary>
        /// 记录arc属性
        /// </summary>
        /// <param name="arc"></param>
        private void GenerateArc(GoArc obj)
        {
            GenerateShape(obj);
            WriteAttrVal("StartAngle", obj.StartAngle);
            WriteAttrVal("SweepAngle", obj.SweepAngle);
        }
        /// <summary>
        /// 记录RoundedRectangle属性
        /// </summary>
        /// <param name="obj"></param>
        private void GenerateRoundRetangle(GoRoundedRectangle obj)
        {
            GenerateShape(obj);
            WriteAttrVal("Corner", obj.Corner);
            WriteAttrVal("RoundedCornerSpots", obj.RoundedCornerSpots);
        }
        /// <summary>
        /// 记录绘制工具属性
        /// </summary>
        /// <param name="obj"></param>
        private void GenerateStroke(GoStroke obj)
        {
            GenerateShape(obj);
            WriteAttrVal("Curviness", obj.Curviness);
            WriteAttrVal("Highlight", obj.Highlight);
            WriteAttrVal("HighlightPenColor", obj.HighlightPenColor);
            WriteAttrVal("HighlightPenWidth", obj.HighlightPenWidth);
            WriteAttrVal("HighlightWhenSelected", obj.HighlightWhenSelected);
            IList<PointF> points = new List<PointF>();
            for (int i = 0; i < obj.PointsCount; i++)
            {
                points.Add(obj.GetPoint(i));
            }
            WriteAttrVal("Points", points.ToArray<PointF>());
        }

        private void GenerateDrawing(GoDrawing obj)
        {
            GenerateShape(obj);
            WriteAttrVal("Angle", obj.Angle);
            WriteAttrVal("FillMode", (int)obj.FillMode);
            WriteAttrVal("ReshapablePoints", obj.ReshapablePoints);
            WriteAttrVal("ReshapableRectangle", obj.ReshapableRectangle);
            WriteAttrVal("SameEndPoints", obj.SameEndPoints);
            WriteAttrVal("SmoothCurves", obj.SmoothCurves);
            WriteAttrVal("UnrotatedBounds", obj.UnrotatedBounds);
        }
        /// <summary>
        /// 记录多边形属性
        /// </summary>
        /// <param name="obj"></param>
        private void GeneratePolygon(GoPolygon obj)
        {
            GenerateShape(obj);
            WriteAttrRef("Style", obj.Style);
            IList<PointF> points = new List<PointF>();
            for (int i = 0; i < obj.PointsCount; i++)
            {
                points.Add(obj.GetPoint(i));
            }
            WriteAttrVal("Points", points.ToArray<PointF>());
        }
        /// <summary>
        /// 记录文本属性
        /// </summary>
        /// <param name="text"></param>
        private void GenerateText(GoText obj)
        {
            WriteAttrVal("Text_Bounds", obj.Bounds);
            WriteAttrVal("Text", obj.Text);
            WriteAttrVal("Alignment", obj.Alignment);
            WriteAttrVal("BackgroundColor", obj.BackgroundColor);
            WriteAttrVal("Bold", obj.Bold);
            WriteAttrVal("Bordered", obj.Bordered);
            WriteAttrVal("FamilyName", obj.FamilyName);
            WriteAttrVal("Italic", obj.Italic);
            WriteAttrVal("RightToLeft", obj.RightToLeft);
            WriteAttrVal("TextColor", obj.TextColor);
            WriteAttrVal("Underline", obj.Underline);
            WriteAttrVal("FontSize", obj.FontSize);
            WriteAttrVal("TransparentBackground", obj.TransparentBackground);
        }
        /// <summary>
        /// 绘制图像
        /// </summary>
        /// <param name="obj"></param>
        private void GenerateImage(GoImage obj)
        {
            WriteAttrVal("Bounds", obj.Bounds);
            //WriteAttrVal("Size", obj.Size);
            WriteAttrVal("Alignment", obj.Alignment);
            WriteAttrVal("AutoResizes", obj.AutoResizes);
            WriteAttrRef("Image", obj.Image);
            var fileName = obj.Name.Substring(obj.Name.LastIndexOf('\\') + 1);
            WriteAttrVal("Name", fileName);
            WriteAttrVal("NameIsUri", obj.NameIsUri);
            //WriteAttrRef("ResourceManager", obj.ResourceManager);
        }
        /// <summary>
        /// 生成子节点
        /// </summary>
        /// <param name="obj"></param>
        public override void GenerateBody(object obj)
        {
            base.GenerateBody(obj);
            DOPGraphElement element = obj as DOPGraphElement;
            GenerateAction(element);
            for (int i = 0; i < element.Count; i++)
            {
                this.WriteStartElement("Child");
                this.WriteAttrVal("Index", i);
                if (element[i].GetType().Name.StartsWith("DOP"))
                {
                    this.GenerateChild((element[i] as DOPGraphElement).First);
                }
                else {
                    this.GenerateChild(element[i]);
                }
                this.WriteEndElement();
            }
        }
        /// <summary>
        /// 设置算法属性
        /// </summary>
        /// <param name="obj"></param>        
        public override void ConsumeAttributes(object obj)
        {
            base.ConsumeAttributes(obj);
            DOPGraphElement element = obj as DOPGraphElement;
            element.Location = PointFAttr("Location", new PointF(100, 100));
            element.Size = SizeFAttr("Size", new SizeF(100, 100));
        }

        public override void ConsumeBody(object obj)
        {
            base.ConsumeBody(obj);
            DOPGraphElement element = obj as DOPGraphElement;
            XmlNode rootNode = this.ReaderNode; //备份节点
            ConsumeActionScript(element);
            for (int i = 0; i < rootNode.ChildNodes.Count; i++)
            {
                this.ReaderNode = rootNode.ChildNodes[i];
                element[i].Location = PointFAttr("Location", new PointF(100, 100));
                element[i].Size = SizeFAttr("Size", new SizeF(100, 100));
                //弧形
                GoArc arc = element[i] as GoArc;
                if (arc != null)
                {
                    ConsumeArc(arc);
                    continue;
                }
                //圆角矩形
                if (element[i] is GoRoundedRectangle)
                {
                    ConsumeRoundedRectangle(element[i] as GoRoundedRectangle);
                    continue;
                }
                //矩形
                if (element[i] is GoRectangle)
                {
                    ConsumeShape(element[i] as GoRectangle);
                    continue;
                }
                //椭圆
                if (element[i] is GoEllipse)
                {
                    ConsumeShape(element[i] as GoEllipse);
                    continue;
                }
                //多边形
                if (element[i] is GoPolygon)
                {
                    ConsumePolygon(element[i] as GoPolygon);
                    continue;
                }
                //文本
                if (element[i] is GoText)
                {
                    ConsumeText(element[i] as GoText);
                    continue;
                }
                //直线
                if (element[i] is GoStroke)
                {
                    ConsumeStroke(element[i] as GoStroke);
                    continue;
                }
                //绘图
                if (element[i] is GoDrawing)
                {
                    ConsumeDrawing(element[i] as GoDrawing);
                    continue;
                }
                //绘制图像
                if (element[i] is GoImage)
                {
                    ConsumeImage(element[i] as GoImage);
                    continue;
                }
                //按钮
                if (element[i] is GoButton)
                {
                    ConsumeButton(element[i] as GoButton);
                    continue;
                }
                //标尺
                if (element[i].GetType().Name.Contains("Meter"))
                {
                    ConsumeMeter((Meter)element[i]);
                }

            }
            this.ReaderNode = rootNode;
        }
        private void ConsumeButton(GoButton obj)
        {
            if (obj.Label == null)
            {
                var image = new GoImage() { 
                    Image = (Image)RefAttr("Image", new GoImage()),
                    Name = StringAttr("Name", "Image"),
                    NameIsUri = BooleanAttr("NameIsUri", false)
                };
                obj.Icon = image;
            }
            else {
                ConsumeText(obj.Label);
            }
            obj.Bounds = RectangleFAttr("Bounds", new RectangleF(0, 0, 100, 100));
            obj.TopLeftMargin = SizeFAttr("TopLeftMargin", new SizeF(0, 0)); ;
            obj.BottomRightMargin = SizeFAttr("BottomRightMargin", new SizeF(0, 0));
            obj.ActionActivated = BooleanAttr("ActionActivated",false);
            obj.ActionEnabled = BooleanAttr("ActionEnabled", false);
            obj.AutoRepeating = BooleanAttr("AutoRepeating", false);
            (obj.Background as GoRectangle).BrushColor = ColorAttr("BrushColor",Color.White);
        }

        private void ConsumeMeter(Meter meter)
        {
            if (meter.Indicator.GetType() == typeof(IndicatorNeedle))
                ((IndicatorNeedle)meter.Indicator).Thickness = SingleAttr("Thickness", 10f);
            else
            {
                ((IndicatorBar)meter.Indicator).Thickness = SingleAttr("Thickness", 10f);
                ((IndicatorBar)meter.Indicator).StartOffset = SizeFAttr("StartOffset", new SizeF(0, 0));
            }

            if (meter.Scale.GetType() == typeof(GraduatedScaleLinear))
            {
                GraduatedScaleLinear gsl = meter.Scale as GraduatedScaleLinear;
                var r = gsl.Bounds;

                if (meter.Orientation == System.Windows.Forms.Orientation.Horizontal)
                {
                    gsl.StartPoint = PointFAttr("StartPoint", new PointF(r.X, r.Y + r.Height / 2));
                    gsl.EndPoint = PointFAttr("EndPoint", new PointF(r.X + r.Width, r.Y + r.Height / 2));
                }
                else
                {
                    gsl.StartPoint = PointFAttr("StartPoint", new PointF(r.X + r.Width / 2, r.Y + r.Height));
                    gsl.EndPoint = PointFAttr("EndPoint", new PointF(r.X + r.Width / 2, r.Y));
                }
            }
            meter.Indicator.Value = SingleAttr("Indicator.Value", 10f);
            meter.Value =  SingleAttr("Value", 10f);
            meter.Maximum = SingleAttr("Maximum", 100f);
            meter.Minimum = SingleAttr("Minimum", 0);
            meter.Scale.Maximum = SingleAttr("Scale.Maximum", 100f);
            meter.Scale.Minimum = SingleAttr("Scale.Minimum", 0);
            meter.TickMajorFrequency = Int32Attr("TickMajorFrequency", 10);
            meter.TickUnit = SingleAttr("TickUnit", 2f);
            (meter.Background as GoRectangle).BrushColor = ColorAttr("BrushColor", Color.Yellow);
            meter.Indicator.BrushColor = ColorAttr("BarColor", Color.Yellow);
            meter.Orientation = (System.Windows.Forms.Orientation)Int32Attr("Orientation", (int)System.Windows.Forms.Orientation.Vertical);
            meter.Indicator.Visible = BooleanAttr("Indicator.Visible", true);
            meter.Indicator.BrushColor = ColorAttr("Indicator.BrushColor", Color.Yellow);
            meter.Scale.Visible = BooleanAttr("Scale.Visible", true);
            //meter.Label.Text = StringAttr("Text", String.Empty);
            //meter.Label.Visible = BooleanAttr("Label.Visible", false);
        }
        private void ConsumeShape(GoShape obj)
        {
            obj.Bounds = RectangleFAttr("Bounds", new RectangleF(0, 0, 100, 100));
            obj.BrushColor = ColorAttr("BrushColor", Color.White);
            obj.BrushFocusScales = SizeFAttr("BrushFocusScales", new SizeF(100, 100));
            obj.BrushForeColor = ColorAttr("BrushForeColor", Color.Black);
            obj.BrushMidColor = ColorAttr("BrushMidColor", Color.Black);
            obj.BrushMidFraction = SingleAttr("BrushMidFraction", 1f);
            obj.BrushPoint = PointFAttr("BrushPoint", new PointF(0, 0));
            obj.BrushStartPoint = PointFAttr("BrushStartPoint", new PointF(0, 0));
            obj.BrushStyle = (GoBrushStyle)Int32Attr("BrushStyle", 0);
            obj.PenColor = ColorAttr("PenColor", Color.Black);
            obj.PenWidth = SingleAttr("PenWidth", 1f);
        }

        private void ConsumePolygon(GoPolygon obj)
        {
            ConsumeShape(obj);
            obj.Style = (GoPolygonStyle)Int32Attr("Style", 0);
            PointF[] points = PointFArrayAttr("Points", null);
            for (int i = 0; i < points.Length; i++)
            {
                obj.AddPoint(points[i]);
            }
        }

        private void ConsumeArc(GoArc obj)
        {
            ConsumeShape(obj);
            obj.StartAngle = SingleAttr("StartAngle", 100);
            obj.SweepAngle = SingleAttr("SweepAngle", 100);
        }

        private void ConsumeRoundedRectangle(GoRoundedRectangle obj)
        {
            ConsumeShape(obj);
            obj.Corner = SizeFAttr("Corner", new SizeF(100, 100));
            obj.RoundedCornerSpots = Int32Attr("RoundedCornerSpots", 100);
        }

        private void ConsumeText(GoText obj)
        {
            obj.Bounds = RectangleFAttr("Text_Bounds", new RectangleF(0, 0, 100, 100));
            obj.Text = StringAttr("Text", "文本");
            obj.Alignment = Int32Attr("Alignment", 1);
            obj.BackgroundColor = ColorAttr("BackgroundColor", Color.Black);
            obj.Bold = BooleanAttr("Bold", false);
            obj.Bordered = BooleanAttr("Bordered", false);
            obj.FamilyName = StringAttr("FamilyName", "宋体");
            obj.Italic = BooleanAttr("Italic", false);
            obj.RightToLeft = BooleanAttr("RightToLeft", true);
            obj.TextColor = ColorAttr("TextColor", Color.Black);
            obj.Underline = BooleanAttr("Underline", false);
            obj.FontSize = SingleAttr("FontSize", 10);
            obj.TransparentBackground = BooleanAttr("TransparentBackground", true);
        }

        private void ConsumeStroke(GoStroke obj)
        {
            ConsumeShape(obj);
            obj.Curviness = SingleAttr("Curviness", 1);
            obj.Highlight = BooleanAttr("Highlight", false);
            obj.HighlightPenColor = ColorAttr("HighlightPenColor", Color.Black);
            obj.HighlightPenWidth = SingleAttr("HighlightPenWidth", 1);
            obj.HighlightWhenSelected = BooleanAttr("HighlightWhenSelected", false);
            PointF[] points = PointFArrayAttr("Points", null);
            for (int i = 0; i < points.Length; i++)
            {
                obj.AddPoint(points[i]);
            }
        }

        private void ConsumeDrawing(GoDrawing obj)
        {
            ConsumeShape(obj);
            obj.Angle = SingleAttr("Angle", 0);
            obj.FillMode = (FillMode)Int32Attr("FillMode", 0);
            obj.ReshapablePoints = BooleanAttr("ReshapablePoints", false);
            obj.ReshapableRectangle = BooleanAttr("ReshapableRectangle", false);
            obj.SameEndPoints = BooleanAttr("SameEndPoints", false);
            obj.SmoothCurves = BooleanAttr("SmoothCurves", false);
            obj.UnrotatedBounds = RectangleFAttr("UnrotatedBounds", new RectangleF(0, 0, 100, 100));
        }

        private void ConsumeImage(GoImage obj)
        {
            obj.Bounds = RectangleFAttr("Bounds", new RectangleF(0, 0, 100, 100));
            obj.Alignment = Int32Attr("Alignment", 0);
            obj.AutoResizes = BooleanAttr("AutoResizes", false);
            obj.Image = (Image)RefAttr("Image", new GoImage());
            obj.Name = Environment.CurrentDirectory + "\\ImageLibrary\\" + StringAttr("Name", "Image");
            obj.NameIsUri = BooleanAttr("NameIsUri", false);
            //obj.Size = SizeFAttr("Size", new SizeF(0, 0));
        }

        private void ConsumeActionScript(DOPGraphElement element)
        {
            element.ActionFromJson(StringAttr("ActionScript", ""));
        }
    }

    /// <summary>
    /// 文档序列化
    /// </summary>
    public class GraphDocTransformer : GoXmlBindingTransformer
    {
        public GraphDocTransformer(object proto)
            : base(proto)
        {
            this.ElementName = "GraphDoc";
            this.BodyConsumesChildElements = true;
        }

        /// <summary>
        /// 生成文档根节点
        /// </summary>
        /// <param name="obj"></param>
        public override void GenerateAttributes(Object obj)
        {
            GraphDocument doc = obj as GraphDocument;
            WriteAttrVal("Size", doc.Size);
            WriteAttrVal("BackColor", doc.PaperColor);
        }

        /// <summary>
        /// 设置文档属性
        /// </summary>
        /// <param name="obj"></param>        
        public override void ConsumeAttributes(object obj)
        {
            base.ConsumeAttributes(obj);
            GraphDocument doc = obj as GraphDocument;
            doc.Size = SizeFAttr("Size", new SizeF(100, 100));
            doc.PaperColor = ColorAttr("BackColor", Color.White);
        }
    }
}
