using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGauges.Core.Model;
using DevExpress.XtraGauges.Core.Drawing;
using System.Drawing.Drawing2D;
using DevExpress.XtraGauges.Core.Base;
using DevExpress.XtraEditors;

namespace Q269849 {
    public partial class Form1 :XtraForm {
        public Form1() {
            InitializeComponent();
            CreatePathNeedle(arcScaleNeedleComponent1);
        }

        private void CreatePathNeedle(INeedle needle) {
            ComplexShape needleShape = (ComplexShape)needle.Shape;
            needleShape.Collection.Clear();

            PathShape shape = new PathShape();
            shape.Points = new ShapePoint[] {
                new ShapePoint(new PointF(0, 20), PathPointType.Start),
                new ShapePoint(new PointF(50, 0), PathPointType.Line),
                new ShapePoint(new PointF(0, -20), PathPointType.Line),
                new ShapePoint(new PointF(100, 0), PathPointType.Line),
                new ShapePoint(new PointF(0, 20), PathPointType.CloseSubpath | PathPointType.Line)
            };

            SolidBrushObject brush = new SolidBrushObject(Color.Red);
            shape.Appearance.ContentBrush = brush;

            shape.Name = "pathNeedle";
            needleShape.Add(shape);
        }

        private void CreatePolygonNeedle(INeedle needle) {
            ComplexShape needleShape = (ComplexShape)needle.Shape;
            needleShape.Collection.Clear();

            PolygonShape shape = new PolygonShape();
            shape.Points = new PointF[] {
                new PointF(0, 10),
                new PointF(75, 10),
                new PointF(70, -5),
                new PointF(100, 0),
                new PointF(65, -10),
                new PointF(70, 5),
                new PointF(0, -10)
            };

            shape.Appearance.ContentBrush = new SolidBrushObject(Color.AliceBlue);
            shape.Name = "polygonNeedle";
            needleShape.Add(shape);
        }

        private void CreatePolylineNeedle(INeedle needle) {
            ComplexShape needleShape = (ComplexShape)needle.Shape;
            needleShape.Collection.Clear();

            PolylineShape shape = new PolylineShape();
            shape.Points = new PointF[] {
                new PointF(0, 20), new PointF(-40, 25),
                new PointF(20, 5), new PointF(100, 0),
                new PointF(20, -5), new PointF(-40, -25),
                new PointF(0, -20)
            };

            shape.Appearance.ContentBrush = new SolidBrushObject(Color.Yellow);
            shape.Name = "polylineNeedle";
            needleShape.Add(shape);
        }

        private void CreateBoxNeedle(INeedle needle) {
            ComplexShape needleShape = (ComplexShape)needle.Shape;
            needleShape.Collection.Clear();

            BoxShape shape = new BoxShape(new RectangleF2D(new PointF(-10, 0), new SizeF(100, 10)));
            shape.Appearance.ContentBrush = new SolidBrushObject(Color.Gray);
            shape.Name = "boxNeedle";
            needleShape.Add(shape);
        }

        private void CreateEllipseNeedle(INeedle needle) {
            ComplexShape needleShape = (ComplexShape)needle.Shape;
            needleShape.Collection.Clear();

            EllipseShape shape = new EllipseShape(new RectangleF2D(new PointF(-10, 0), new SizeF(100, 10)));
            LinearGradientBrushObject brush = new LinearGradientBrushObject(new PointF2D(2, 0), new PointF2D(0, 2));
            brush.StartColor = Color.Yellow;
            brush.EndColor = Color.Magenta;
            shape.Appearance.ContentBrush = brush;
            shape.Name = "ellipseNeedle";
            needleShape.Add(shape);
        }

        private void CreateArcNeedle(INeedle needle) {
            ComplexShape needleShape = (ComplexShape)needle.Shape;
            needleShape.Collection.Clear();

            ArcShape shape = new ArcShape(new RectangleF2D(new PointF(-10, 0), new SizeF(20, 10)), 180, -60);
            shape.Appearance.ContentBrush = new SolidBrushObject(Color.White);
            shape.Name = "arcNeedle";
            needleShape.Add(shape);
        }

        private void CreatePieShape(INeedle needle) {
            ComplexShape needleShape = (ComplexShape)needle.Shape;
            needleShape.Collection.Clear();

            PieShape shape = new PieShape(new RectangleF2D(new PointF(0, 30), new SizeF(80, 10)), 40, 270);
            shape.Appearance.ContentBrush = new SolidBrushObject(Color.Blue);
            shape.Name = "pieNeedle";
            needleShape.Add(shape);
        }

        private void CreateSectorShape(INeedle needle) {
            ComplexShape needleShape = (ComplexShape)needle.Shape;
            needleShape.Collection.Clear();

            SectorShape shape = new SectorShape(new RectangleF2D(new PointF(0, 30), new SizeF(80, 10)), 40, 270);
            shape.Appearance.ContentBrush = new SolidBrushObject(Color.Red);
            shape.Name = "sectorShape";
            needleShape.Add(shape);
        }

        private void CreateTextShape(INeedle needle) {
            ComplexShape needleShape = (ComplexShape)needle.Shape;
            needleShape.Collection.Clear();

            TextShape shape = new TextShape();
            shape.Box = new RectangleF2D(new PointF(-10, 0), new SizeF(100, 10));
            shape.Text = "    > > > > > ";
            shape.AppearanceText.TextBrush = new SolidBrushObject(Color.Salmon);
            needleShape.Add(shape);
        }

        private void CreateComplexNeedle(INeedle needle) {
            ComplexShape needleShape = (ComplexShape)needle.Shape;
            needleShape.Collection.Clear();

            PolylineShape basic = new PolylineShape(new PointF[] {
                new PointF(25, 20), new PointF(100, 0), new PointF(25, -20),
                new PointF(95, 0), new PointF(25, 20)
            });
            basic.Appearance.ContentBrush = new SolidBrushObject(Color.Azure);
            basic.Name = "basic";

            PolylineShape cap = new PolylineShape(new PointF[] {
                new PointF(100, 0), new PointF(105, 5), 
                new PointF(110, 0), new PointF(105, -5)
            });
            cap.Appearance.ContentBrush = new SolidBrushObject(Color.BurlyWood);
            cap.Name = "cap";

            needleShape.AddRange(new BaseShape[] { basic, cap });
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e) {
            switch (cmbNeedle.SelectedText) {
                case "Path": CreatePathNeedle(arcScaleNeedleComponent1); break;
                case "Polygon": CreatePolygonNeedle(arcScaleNeedleComponent1); break;
                case "Polyline": CreatePolylineNeedle(arcScaleNeedleComponent1); break;
                case "Box": CreateBoxNeedle(arcScaleNeedleComponent1); break;
                case "Ellipse": CreateEllipseNeedle(arcScaleNeedleComponent1); break;
                case "Arc": CreateArcNeedle(arcScaleNeedleComponent1); break;
                case "Pie": CreatePieShape(arcScaleNeedleComponent1); break;
                case "Sector": CreateSectorShape(arcScaleNeedleComponent1); break;
                case "Text": CreateTextShape(arcScaleNeedleComponent1); break;
                case "Complex": CreateComplexNeedle(arcScaleNeedleComponent1); break;
                default: CreateComplexNeedle(arcScaleNeedleComponent1); break;
            }
        }
    }
}