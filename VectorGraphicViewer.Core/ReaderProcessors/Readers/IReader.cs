using System.Collections.Generic;
using VectorGraphicViewer.Core.Models;

namespace VectorGraphicViewer.Core.ReaderProcessors.Readers
{
    public interface IReader
    {
        IEnumerable<Shape> ReadShapesFromFile(string filePath);
    }
}
