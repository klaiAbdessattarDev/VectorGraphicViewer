using Newtonsoft.Json.Linq;
using System.Windows.Media;

namespace VectorGraphicViewer.Core.Models
{
    public class Triangle : Shape
    {
        public PointCollection Coordinates { get; set; }
        public bool Filled { get; set; }

        public override Shape GetFromJSONFile(JObject jo)
        {
            Type = jo["type"].ToString();

            Coordinates = new PointCollection()
            {
                GetCoordinate(jo[propertyName : "a"].ToString()),
                GetCoordinate(jo[propertyName : "b"].ToString()),
                GetCoordinate(jo[propertyName : "c"].ToString())
            };
            Filled = bool.Parse(jo[propertyName: "filled"].ToString());
            Color = GetColor(jo[propertyName: "color"].ToString());

            return this;
        }
    }
}
