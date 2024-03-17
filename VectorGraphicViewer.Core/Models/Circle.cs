using Newtonsoft.Json.Linq;
using System.Windows;

namespace VectorGraphicViewer.Core.Models
{
    public class Circle : Shape
    {
        public Point Center { get; set; }
        public float Radius { get; set; }
        public bool Filled { get; set; }

        public override Shape GetFromJSONFile(JObject jo)
        {
            Type = jo[propertyName: "type"].ToString();
            Center = GetCoordinate(jo[propertyName: "center"].ToString());
            Radius = float.Parse(jo[propertyName: "radius"].ToString());
            Color = GetColor(jo[propertyName: "color"].ToString());
            Filled = bool.Parse(jo[propertyName: "filled"].ToString());

            return this;
        }
    }
}
