using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Windows;
using VectorGraphicViewer.Core.Models;
using VectorGraphicViewer.Core.ReaderProcessors;
using VectorGraphicViewer.Core.ReaderProcessors.Readers;
using VectorGraphicViewer.UI.Drawers;

namespace VectorGraphicViewer.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Subject to handle file read events
        private readonly Subject<IEnumerable<Shape>> _onFileRead = new();

        // Drawer and reader instances
        private IDrawer _drawer;
        private IReader _reader;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Subscribe to file read events
            _onFileRead.Subscribe(shapes =>
            {
                canvas.Children.Clear();

                foreach (Shape shape in shapes)
                {
                    DrawShapeOnCanvas(shape);
                }
            });
        }

        /// <summary>
        /// Handles the click event for the open file dialog button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleOpenFileDialogButtonClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new();

            if (fileDialog.ShowDialog() == true)
            {
                string fileName = fileDialog.FileName;
                fileNameTextBox.Text = fileName;

                try
                {
                    // Create reader and read shapes from file
                    _reader = ReaderFactory.CreateReader(fileName);
                    _onFileRead.OnNext(_reader.ReadShapesFromFile(fileName));
                }
                catch (Exception ex)
                {
                    ShowMessageBox("Error", ex.Message);
                }
            }
        }

        /// <summary>
        /// Draws a shape on the canvas.
        /// </summary>
        /// <param name="shape"></param>
        private void DrawShapeOnCanvas(Shape shape)
        {
            try
            {
                // Get drawer for the shape and draw it on canvas
                _drawer = ShapeDrawerFactory.GetDrawerForShape(shapeType: shape.Type);
                _drawer.Draw(canvas, shape);
            }
            catch (Exception ex)
            {
                ShowMessageBox("Error", ex.Message);
            }
        }

        /// <summary>
        /// Shows a message box with the specified title and message text.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="messageText"></param>
        private static void ShowMessageBox(string title, string messageText)
        {
            MessageBox.Show(messageText, title);
        }

        /// <summary>
        /// Handles the closed event of the main window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            // Dispose the file read subject
            _onFileRead.Dispose();
        }
    }
}
