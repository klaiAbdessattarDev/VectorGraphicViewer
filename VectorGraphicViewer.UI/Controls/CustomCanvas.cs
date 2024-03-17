using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VectorGraphicViewer.UI.Controls
{
    /// <summary>
    /// Represents a custom Canvas control for Cartesian coordinate system.
    /// </summary>
    public class CustomCanvas : Canvas
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomCanvas"/> class.
        /// </summary>
        public CustomCanvas()
        {
            InitializeLayoutTransform();
        }

        /// <summary>
        /// Initializes the layout transformation of the Canvas.
        /// </summary>
        private void InitializeLayoutTransform()
        {
            LayoutTransform = new ScaleTransform { ScaleX = 1, ScaleY = -1 };
        }

        /// <summary>
        /// Arranges the children of the Canvas.
        /// </summary>
        /// <param name="arrangeSize">The size that the Canvas will assume to arrange its children.</param>
        /// <returns>The final size used by the Canvas.</returns>
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            Point middle = new(arrangeSize.Width / 2, arrangeSize.Height / 2);

            // Arrange each child element at its desired position
            foreach (UIElement element in InternalChildren)
            {
                if (element == null)
                    continue;

                double x = GetXCoordinate(element);
                double y = GetYCoordinate(element);

                element.Arrange(new Rect(new Point(middle.X + x, middle.Y + y), element.DesiredSize));
            }

            return arrangeSize;
        }

        /// <summary>
        /// Gets the X-coordinate of the specified UI element.
        /// </summary>
        /// <param name="element">The UI element.</param>
        /// <returns>The X-coordinate.</returns>
        private static double GetXCoordinate(UIElement element)
        {
            double left = GetLeft(element);
            return double.IsNaN(left) ? 0.0 : left;
        }

        /// <summary>
        /// Gets the Y-coordinate of the specified UI element.
        /// </summary>
        /// <param name="element">The UI element.</param>
        /// <returns>The Y-coordinate.</returns>
        private static double GetYCoordinate(UIElement element)
        {
            double top = GetTop(element);
            return double.IsNaN(top) ? 0.0 : top;
        }
    }
}
