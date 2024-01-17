using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WpfApp1
{
    public static class ExtensionMethods
    {
        public static List<PointF> Normalize(this List<PointF> points, double Width, double Height)
        {
            var xScale = Width / points.Max(p => Math.Abs(p.X)) / 2;
            var yScale = Width / points.Max(p => Math.Abs(p.Y)) / 2;
            return points.Select(p => new PointF((float)(p.X * xScale + Width / 2), (float)(Height / 2 - p.Y * yScale + 130))).ToList();
        }
    }
}
