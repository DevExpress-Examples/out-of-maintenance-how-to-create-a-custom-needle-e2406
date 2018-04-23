Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGauges.Core.Model
Imports DevExpress.XtraGauges.Core.Drawing
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraGauges.Core.Base
Imports DevExpress.XtraEditors

Namespace Q269849
	Partial Public Class Form1
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
			CreatePathNeedle(arcScaleNeedleComponent1)
		End Sub

		Private Sub CreatePathNeedle(ByVal needle As INeedle)
			Dim needleShape As ComplexShape = CType(needle.Shape, ComplexShape)
			needleShape.Collection.Clear()

			Dim shape As New PathShape()
			shape.Points = New ShapePoint() { New ShapePoint(New PointF(0, 20), PathPointType.Start), New ShapePoint(New PointF(50, 0), PathPointType.Line), New ShapePoint(New PointF(0, -20), PathPointType.Line), New ShapePoint(New PointF(100, 0), PathPointType.Line), New ShapePoint(New PointF(0, 20), PathPointType.CloseSubpath Or PathPointType.Line) }

			Dim contentBrush As New EllipticalGradientBrushObject(New PointF2D(0, 0), 12f, 1f)
			contentBrush.StartColor = Color.Green
			contentBrush.EndColor = Color.Yellow
			shape.Appearance.ContentBrush = contentBrush

			shape.Name = "pathNeedle"
			needleShape.Add(shape)
		End Sub

		Private Sub CreatePolygonNeedle(ByVal needle As INeedle)
			Dim needleShape As ComplexShape = CType(needle.Shape, ComplexShape)
			needleShape.Collection.Clear()

			Dim shape As New PolygonShape()
			shape.Points = New PointF() { New PointF(0, 10), New PointF(75, 10), New PointF(70, -5), New PointF(100, 0), New PointF(65, -10), New PointF(70, 5), New PointF(0, -10) }

			shape.Appearance.ContentBrush = New SolidBrushObject(Color.AliceBlue)
			shape.Name = "polygonNeedle"
			needleShape.Add(shape)
		End Sub

		Private Sub CreatePolylineNeedle(ByVal needle As INeedle)
			Dim needleShape As ComplexShape = CType(needle.Shape, ComplexShape)
			needleShape.Collection.Clear()

			Dim shape As New PolylineShape()
			shape.Points = New PointF() { New PointF(0, 20), New PointF(-40, 25), New PointF(20, 5), New PointF(100, 0), New PointF(20, -5), New PointF(-40, -25), New PointF(0, -20) }

			shape.Appearance.ContentBrush = New SolidBrushObject(Color.Yellow)
			shape.Name = "polylineNeedle"
			needleShape.Add(shape)
		End Sub

		Private Sub CreateBoxNeedle(ByVal needle As INeedle)
			Dim needleShape As ComplexShape = CType(needle.Shape, ComplexShape)
			needleShape.Collection.Clear()

			Dim shape As New BoxShape(New RectangleF2D(New PointF(-10, 0), New SizeF(100, 10)))
			shape.Appearance.ContentBrush = New SolidBrushObject(Color.Gray)
			shape.Name = "boxNeedle"
			needleShape.Add(shape)
		End Sub

		Private Sub CreateEllipseNeedle(ByVal needle As INeedle)
			Dim needleShape As ComplexShape = CType(needle.Shape, ComplexShape)
			needleShape.Collection.Clear()

			Dim shape As New EllipseShape(New RectangleF2D(New PointF(-10, 0), New SizeF(100, 10)))
			Dim brush As New LinearGradientBrushObject(New PointF2D(2, 0), New PointF2D(0, 2))
			brush.StartColor = Color.Yellow
			brush.EndColor = Color.Magenta
			shape.Appearance.ContentBrush = brush
			shape.Name = "ellipseNeedle"
			needleShape.Add(shape)
		End Sub

		Private Sub CreateArcNeedle(ByVal needle As INeedle)
			Dim needleShape As ComplexShape = CType(needle.Shape, ComplexShape)
			needleShape.Collection.Clear()

			Dim shape As New ArcShape(New RectangleF2D(New PointF(-10, 0), New SizeF(20, 10)), 180, -60)
			shape.Appearance.ContentBrush = New SolidBrushObject(Color.White)
			shape.Name = "arcNeedle"
			needleShape.Add(shape)
		End Sub

		Private Sub CreatePieShape(ByVal needle As INeedle)
			Dim needleShape As ComplexShape = CType(needle.Shape, ComplexShape)
			needleShape.Collection.Clear()

			Dim shape As New PieShape(New RectangleF2D(New PointF(0, 30), New SizeF(80, 10)), 40, 270)
			shape.Appearance.ContentBrush = New SolidBrushObject(Color.Blue)
			shape.Name = "pieNeedle"
			needleShape.Add(shape)
		End Sub

		Private Sub CreateSectorShape(ByVal needle As INeedle)
			Dim needleShape As ComplexShape = CType(needle.Shape, ComplexShape)
			needleShape.Collection.Clear()

			Dim shape As New SectorShape(New RectangleF2D(New PointF(0, 30), New SizeF(80, 10)), 40, 270)
			shape.Appearance.ContentBrush = New SolidBrushObject(Color.Red)
			shape.Name = "sectorShape"
			needleShape.Add(shape)
		End Sub

		Private Sub CreateTextShape(ByVal needle As INeedle)
			Dim needleShape As ComplexShape = CType(needle.Shape, ComplexShape)
			needleShape.Collection.Clear()

			Dim shape As New TextShape()
			shape.Box = New RectangleF2D(New PointF(-10, 0), New SizeF(100, 10))
			shape.Text = "    > > > > > "
			shape.AppearanceText.TextBrush = New SolidBrushObject(Color.Salmon)
			needleShape.Add(shape)
		End Sub

		Private Sub CreateComplexNeedle(ByVal needle As INeedle)
			Dim needleShape As ComplexShape = CType(needle.Shape, ComplexShape)
			needleShape.Collection.Clear()

			Dim basic As New PolylineShape(New PointF() { New PointF(25, 20), New PointF(100, 0), New PointF(25, -20), New PointF(95, 0), New PointF(25, 20) })
			basic.Appearance.ContentBrush = New SolidBrushObject(Color.Azure)
			basic.Name = "basic"

			Dim cap As New PolylineShape(New PointF() { New PointF(100, 0), New PointF(105, 5), New PointF(110, 0), New PointF(105, -5) })
			cap.Appearance.ContentBrush = New SolidBrushObject(Color.BurlyWood)
			cap.Name = "cap"

			needleShape.AddRange(New BaseShape() { basic, cap })
		End Sub

		Private Sub comboBoxEdit1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbNeedle.SelectedIndexChanged
			Select Case cmbNeedle.SelectedText
				Case "Path"
					CreatePathNeedle(arcScaleNeedleComponent1)
				Case "Polygon"
					CreatePolygonNeedle(arcScaleNeedleComponent1)
				Case "Polyline"
					CreatePolylineNeedle(arcScaleNeedleComponent1)
				Case "Box"
					CreateBoxNeedle(arcScaleNeedleComponent1)
				Case "Ellipse"
					CreateEllipseNeedle(arcScaleNeedleComponent1)
				Case "Arc"
					CreateArcNeedle(arcScaleNeedleComponent1)
				Case "Pie"
					CreatePieShape(arcScaleNeedleComponent1)
				Case "Sector"
					CreateSectorShape(arcScaleNeedleComponent1)
				Case "Text"
					CreateTextShape(arcScaleNeedleComponent1)
				Case "Complex"
					CreateComplexNeedle(arcScaleNeedleComponent1)
				Case Else
					CreateComplexNeedle(arcScaleNeedleComponent1)
			End Select
		End Sub
	End Class
End Namespace