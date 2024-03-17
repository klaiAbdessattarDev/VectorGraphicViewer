using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Reflection;
using VectorGraphicViewer.Core.Models;

namespace VectorGraphicViewer.Core.ReaderProcessors.Converters
{
    /// <summary>
    /// ShapeJsonConverter can convert a JSON representation of a shape to an instance of the shape.
    /// </summary>
    internal class ShapeJsonConverter : JsonConverter
    {
        // Determines whether this instance can convert the specified object type.
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Shape));
        }

        // Converts the JSON representation of the shape to an instance of the shape.
        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            // Load the JSON object from the reader
            JObject jo = JObject.Load(reader);

            // Get the type of the shape from the JSON object
            var shapeClass = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(
                t => t.IsClass &&
                       t.Namespace == "VectorGraphicViewer.Core.Models" &&
                       t.Name.ToLower() == jo["type"].ToString());

            // If the shape type is not found, throw an exception
            if (shapeClass == null) throw new NotImplementedException("No implementation for this shape: " + jo["type"].ToString());

            // Create an instance of the shape using reflection
            var shapeInstance = ((Shape)Activator.CreateInstance(shapeClass)).GetFromJSONFile(jo);

            return shapeInstance;
        }

        // Converts an object to its JSON representation.
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
