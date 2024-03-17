using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicViewer.Core.Models;

namespace VectorGraphicViewer.UI.Drawers
{
    internal class CircleDrawer : IDrawer
    {
        public void Draw(Canvas canvas, Shape shape)
        {
            canvas.Children.Add(this.CreateCircleShape(shape));
        }

        /// <summary>
        /// Creates a graphical representation of a circle shape.
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        private System.Windows.Shapes.Ellipse CreateCircleShape(Shape shape)
        {
            var circle = shape as Circle;
            var circleToDraw = new System.Windows.Shapes.Ellipse();

            // Set stroke properties
            var brush = new SolidColorBrush(circle.Color);
            circleToDraw.Stroke = brush;
            circleToDraw.StrokeThickness = 1;

            // Fill the circle if it's meant to be filled
            if (circle.Filled)
            {
                circleToDraw.Fill = brush;
            }

            // Set dimensions and position
            circleToDraw.Width = circle.Radius * 2;
            circleToDraw.Height = circle.Radius * 2;
            circleToDraw.RenderTransform = CreateTranslateTransform(circle);

            return circleToDraw;
        }

        /// <summary>
        /// Creates a TranslateTransform object to position the circle shape correctly.
        /// </summary>
        /// <param name="circle"></param>
        /// <returns></returns>
        private TranslateTransform CreateTranslateTransform(Circle circle)
        {
            return new TranslateTransform(circle.Center.X - circle.Radius, circle.Center.Y - circle.Radius);
        }
    }
}
