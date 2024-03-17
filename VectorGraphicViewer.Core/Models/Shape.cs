using Newtonsoft.Json.Linq;
using System;
using System.Windows;
using System.Windows.Media;

namespace VectorGraphicViewer.Core.Models
{
    public abstract class Shape
    {
        public string Type { get; set; }
        public Color Color { get; set; }

        public static Color GetColor(string argb)
        {
            var argbString = argb.Split(";");
            var drawingColor = System.Drawing.Color.FromArgb(Int32.Parse(argbString[0]), Int32.Parse(argbString[1]), Int32.Parse(argbString[2]), Int32.Parse(argbString[3]));
            return Color.FromArgb(drawingColor.A, drawingColor.R, drawingColor.G, drawingColor.B);
        }

        public static Point GetCoordinate(string pointString)
        {
            var coordinates = pointString.Split(";");
            var point = new Point() { X = double.Parse(coordinates[0]), Y = double.Parse(coordinates[1]) };
            return point;
        }

        public abstract Shape GetFromJSONFile(JObject jo);
    }
}
