using System.Windows.Controls;
using VectorGraphicViewer.Core.Models;

namespace VectorGraphicViewer.UI.Drawers
{
    public interface IDrawer
    {
        void Draw(Canvas canvas, Shape shape);
    }
}
