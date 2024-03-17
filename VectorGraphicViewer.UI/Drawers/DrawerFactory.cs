
using System;
using System.Linq;
using System.Reflection;

namespace VectorGraphicViewer.UI.Drawers
{
    /// <summary>
    /// Factory class responsible for creating drawer instances based on shape types.
    /// </summary>
    public class ShapeDrawerFactory
    {
        /// <summary>
        /// Retrieves a drawer instance for the specified shape type.
        /// </summary>
        /// <param name="shapeType">The type of shape for which to get the drawer.</param>
        /// <returns>An instance of a drawer for the specified shape type.</returns>
        public static IDrawer GetDrawerForShape(string shapeType)
        {
            Type drawerType = FindDrawerType(shapeType);
            if (drawerType == null)
            {
                throw new NotSupportedException($"No drawer found for the shape type '{shapeType}'.");
            }

            return Activator.CreateInstance(drawerType) as IDrawer;
        }

        /// <summary>
        /// Finds the type of drawer class corresponding to the specified shape type.
        /// </summary>
        /// <param name="shapeType">The type of shape.</param>
        /// <returns>The type of the drawer class if found; otherwise, null.</returns>
        private static Type FindDrawerType(string shapeType)
        {
            string drawerClassName = $"{shapeType.ToLower()}drawer";
            return Assembly.GetExecutingAssembly()
                           .GetTypes()
                           .FirstOrDefault(t => IsDrawerClass(t, drawerClassName));
        }

        /// <summary>
        /// Determines whether the specified type is a drawer class for the given shape type.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <param name="expectedName">The expected name of the drawer class.</param>
        /// <returns>True if the type is a drawer class for the given shape type; otherwise, false.</returns>
        private static bool IsDrawerClass(Type type, string expectedName)
        {
            return type.IsClass &&
                   type.Namespace == "VectorGraphicViewer.UI.Drawers" &&
                   type.Name.ToLower() == expectedName;
        }
    }
}

