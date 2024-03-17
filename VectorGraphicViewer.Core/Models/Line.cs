using Newtonsoft.Json.Linq;
using System.Windows.Media;

namespace VectorGraphicViewer.Core.Models
{
    public class Line : Shape
    {
        public PointCollection Coordinates { get; set; }

        public override Shape GetFromJSONFile(JObject jo)
        {
            Type = jo[propertyName: "type"].ToString();
            Coordinates = new PointCollection()
            {
                GetCoordinate(jo[propertyName : "a"].ToString()),
                GetCoordinate(jo[propertyName : "b"].ToString())
            };
            Color = GetColor(jo[propertyName: "color"].ToString());

            return this;
        }
    }
}
