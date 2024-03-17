using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicViewer.Core.Models;

namespace VectorGraphicViewer.UI.Drawers
{
    /// <summary>
    ///  A class responsible for drawing Triangle shapes on a canvas.
    /// </summary>
    internal class TriangleDrawer : IDrawer
    {
        /// <summary>
        /// Draws a triangle shape on the specified canvas.
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="shape"></param>
        public void Draw(Canvas canvas, Shape shape)
        {
            canvas.Children.Add(CreateTriangle(shape));
        }

        /// <summary>
        /// Creates a graphical representation of a line shape.
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        private System.Windows.Shapes.Polygon CreateTriangle(Shape shape)
        {
            var triangle = shape as Triangle;
            var triangleToDraw = new System.Windows.Shapes.Polygon();

            var brush = new SolidColorBrush(triangle.Color);
            triangleToDraw.Stroke = brush;
            triangleToDraw.StrokeThickness = 1;
            triangleToDraw.Points = triangle.Coordinates;
            if (triangle.Filled) triangleToDraw.Fill = brush;

            return triangleToDraw;
        }

    }
}
