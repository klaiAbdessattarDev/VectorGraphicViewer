using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicViewer.Core.Models;

namespace VectorGraphicViewer.UI.Drawers
{
    /// <summary>
    /// A class responsible for drawing line shapes on a canvas.
    /// </summary>
    internal class LineDrawer : IDrawer
    {
        /// <summary>
        /// Draws a line shape on the specified canvas.
        /// </summary  >
        /// <param name="canvas"></param>
        /// <param name="shape"></param>
        public void Draw(Canvas canvas, Shape shape)
        {
            canvas.Children.Add(this.CreateLine(shape));
        }

        /// <summary>
        /// Creates a graphical representation of a line shape.
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        private System.Windows.Shapes.Line CreateLine(Shape shape)
        {
            var line = shape as Line;
            var lineToDraw = new System.Windows.Shapes.Line();

            // Set stroke properties
            lineToDraw.Stroke = new SolidColorBrush(line.Color);
            lineToDraw.StrokeThickness = 1;

            // Set line coordinates
            lineToDraw.X1 = line.Coordinates.ElementAt(0).X;
            lineToDraw.Y1 = line.Coordinates.ElementAt(0).Y;
            lineToDraw.X2 = line.Coordinates.ElementAt(1).X;
            lineToDraw.Y2 = line.Coordinates.ElementAt(1).Y;

            return lineToDraw;
        }
    }
}
