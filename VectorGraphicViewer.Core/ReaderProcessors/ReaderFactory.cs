using System;
using System.IO;
using System.Linq;
using System.Reflection;
using VectorGraphicViewer.Core.ReaderProcessors.Readers;

namespace VectorGraphicViewer.Core.ReaderProcessors
{

    public class ReaderFactory
    {
        public static IReader CreateReader(string filePath)
        {
            string fileExtension = Path.GetExtension(filePath).TrimStart('.');

            // Find the <see cref="IReader" /> implementation for the file extension
            var readerTypeImplemented = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(
                t => t.IsClass &&
                       t.Namespace == "VectorGraphicViewer.Core.ReaderProcessors.Readers" &&
                       t.Name.ToLower().Equals(fileExtension + "reader"));

            // implementation is not found, throw an exception
            if (readerTypeImplemented == null) throw new NotImplementedException("No reader is implemented for this extension");

            // Create an instance of the <see cref="IReader" /> implementation
            return Activator.CreateInstance(readerTypeImplemented) as IReader;
        }
    }
}
