using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using VectorGraphicViewer.Core.Models;
using VectorGraphicViewer.Core.ReaderProcessors.Converters;

namespace VectorGraphicViewer.Core.ReaderProcessors.Readers
{
    /// <summary>
    /// A custom <see cref="IReader" /> implementation that reads a list of shapes from a JSON file.
    /// </summary>
    internal class JsonReader : IReader
    {
        // Reads a list of shapes from a JSON file.
        public IEnumerable<Shape> ReadShapesFromFile(string FilePath)
        {
            using (StreamReader r = new(FilePath))
            {
                string json = r.ReadToEnd();

                try
                {
                    List<Shape> shapes = JsonConvert.DeserializeObject<List<Shape>>(json, new ShapeJsonConverter());
                    return shapes;
                }
                catch (JsonReaderException)
                {
                    // If the JSON data is invalid, throw a <see cref="JsonReaderException" />
                    throw new JsonReaderException("Invalid file");
                }
                catch (NotImplementedException ex)
                {
                    // If the <see cref="ShapeJsonConverter" /> cannot convert the JSON data, throw the original exception
                    throw new NotImplementedException(ex.Message);
                }

            }
        }
    }
}
