using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp1
{
    internal class Task1
    {
        public Brush fill()
        {
            Color FillColor = Colors.Black;
            double HatchThickness = -3;
            double HatchAngle = -45;
            DrawingBrush myBrush = new DrawingBrush();

            GeometryGroup myGeometryGroup = new GeometryGroup();
            myGeometryGroup.Children.Add(new LineGeometry(new Point(0, 0), new Point(10, 0)));
            Pen p = new Pen();
            p.Brush = new SolidColorBrush(FillColor);
            p.Thickness = HatchThickness;
            p.StartLineCap = PenLineCap.Square;
            p.EndLineCap = PenLineCap.Square;

            GeometryDrawing myDrawing = new GeometryDrawing(null, p, myGeometryGroup);
            myBrush.Drawing = myDrawing;
            myBrush.Viewbox = new Rect(0, 0, 10, 10);
            myBrush.ViewboxUnits = BrushMappingMode.Absolute;
            myBrush.Viewport = new Rect(0, 0, 10, 10);
            myBrush.ViewportUnits = BrushMappingMode.Absolute;
            myBrush.TileMode = TileMode.Tile;
            myBrush.Stretch = Stretch.UniformToFill;
            myBrush.Transform = new RotateTransform(HatchAngle);

            return myBrush;

        }

        public Path DiagonalPart()
        {
            var brush = fill();

            Path path = new Path();

            path.Stroke = Brushes.Black;
            path.StrokeThickness = 2;

            PathGeometry geometry = new PathGeometry();
            PathFigureCollection pathFigures = new PathFigureCollection();
            PathFigure figure = new PathFigure();
            figure.StartPoint = new Point(294, 594);

            PathSegmentCollection collection = new PathSegmentCollection();
            PolyBezierSegment segments = new PolyBezierSegment();
            segments.Points.Add(new Point(294, 594));
            segments.Points.Add(new Point(315, 605));
            segments.Points.Add(new Point(290, 625));
            segments.Points.Add(new Point(285, 640));
            segments.Points.Add(new Point(320, 646));
            segments.Points.Add(new Point(290, 670));
            collection.Add(segments);

            LineSegment line_segment1 = new LineSegment();
            line_segment1.Point = new Point(83, 670);
            collection.Add(line_segment1);

            LineSegment line_segment2 = new LineSegment();
            line_segment2.Point = new Point(83, 594);
            collection.Add(line_segment2);

            foreach (var coll in collection)
                figure.Segments.Add(coll);

            pathFigures.Add(figure);

            foreach (var pf in pathFigures)
                geometry.Figures.Add(pf);

            geometry.FillRule = FillRule.Nonzero;
            path.Data = geometry;
            path.Fill = brush;

            return path;
        }

        public List<Shape> Task()
        {
            Rectangle rectangle1 = new Rectangle();
            rectangle1.Width = 1200;
            rectangle1.Height = 80;
            rectangle1.Stroke = Brushes.Black;
            rectangle1.StrokeThickness = 4;
            rectangle1.Margin = new Thickness(0, 500, 0, 0);

            Rectangle rectangle2 = new Rectangle();
            rectangle2.Width = 780;
            rectangle2.Height = 450;
            rectangle2.Stroke = Brushes.Black;
            rectangle2.StrokeThickness = 4;
            rectangle2.Margin = new Thickness(0, 0, 0, 22);

            Ellipse ellipse1 = new Ellipse();
            ellipse1.Width = 100;
            ellipse1.Height = 100;
            ellipse1.Stroke = Brushes.Black;
            ellipse1.StrokeThickness = 4;
            ellipse1.Margin = new Thickness(0, 0, 610, 230);

            Ellipse ellipse2 = new Ellipse();
            ellipse2.Width = 200;
            ellipse2.Height = 200;
            ellipse2.Stroke = Brushes.Black;
            ellipse2.StrokeThickness = 4;
            ellipse2.Margin = new Thickness(400, 0, 0, 0);

            Line line1 = new Line();
            line1.X1 = 310;
            line1.Y1 = 270;
            line1.X2 = 450;
            line1.Y2 = 270;
            line1.Stroke = Brushes.Black;
            line1.StrokeThickness = 2;
            line1.StrokeDashArray = new DoubleCollection() { 15, 5, 5, 5, 200 };

            Line line2 = new Line();
            line2.X1 = 380;
            line2.Y1 = 200;
            line2.X2 = 380;
            line2.Y2 = 340;
            line2.Stroke = Brushes.Black;
            line2.StrokeThickness = 2;
            line2.StrokeDashArray = new DoubleCollection() { 15, 5, 5, 5, 200 };

            Line line3 = new Line();
            line3.X1 = 750;
            line3.Y1 = 385;
            line3.X2 = 1000;
            line3.Y2 = 385;
            line3.Stroke = Brushes.Black;
            line3.StrokeThickness = 2;
            line3.StrokeDashArray = new DoubleCollection() { 30, 5, 5, 5, 200 };

            Rectangle rectangle3 = new Rectangle();
            rectangle3.Width = 70;
            rectangle3.Height = 80;
            rectangle3.Stroke = Brushes.Black;
            rectangle3.StrokeThickness = 4;
            rectangle3.Margin = new Thickness(0, 500, 980, 0);
            rectangle3.Fill = Brushes.White;

            Line line4 = new Line();
            line4.X1 = 196;
            line4.Y1 = 570;
            line4.X2 = 196;
            line4.Y2 = 685;
            line4.Stroke = Brushes.Black;
            line4.StrokeThickness = 2;
            line4.StrokeDashArray = new DoubleCollection() { 20, 5, 5, 5, 200 };

            Line line5 = new Line();
            line5.X1 = 1160;
            line5.Y1 = 570;
            line5.X2 = 1160;
            line5.Y2 = 685;
            line5.Stroke = Brushes.Black;
            line5.StrokeThickness = 2;
            line5.StrokeDashArray = new DoubleCollection() { 20, 5, 5, 5, 200 };

            Path path = DiagonalPart();

            List<Shape> shapes = new List<Shape>();
            shapes.Add(rectangle1);
            shapes.Add(rectangle2);
            shapes.Add(ellipse1);
            shapes.Add(ellipse2);
            shapes.Add(line1);
            shapes.Add(line2);
            shapes.Add(line3);
            shapes.Add(path);
            shapes.Add(rectangle3);
            shapes.Add(line4);
            shapes.Add(line5);

            return shapes;
        }
    }
}
