using PictureEditor.BusinessLayer.Interfaces; // Importing the interface

namespace PictureEditor.BusinessLayer.Classes
{
    /// <summary>
    /// Represents a class for handling input and output operations related to images.
    /// </summary>
    public class OutputInputFilesystem : IOutputInput // Implementing the IOutputInput interface
    {
        /// <summary>
        /// Loads an image from the specified file path.
        /// </summary>
        /// <param name="filePath">The path of the file from which to load the image.</param>
        /// <returns>The loaded Image object.</returns>
        public Image Load(string filePath)
        {
            try
            {
                // Load the image from the specified file path
                Image loadedImage = Image.FromFile(filePath);
                return loadedImage;
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or throw a custom exception if necessary
                throw new Exception("Error loading image: " + ex.Message);
            }
        }

        /// <summary>
        /// Saves the specified image with the provided name and image format.
        /// </summary>
        /// <param name="imageToSave">The image to be saved.</param>
        /// <param name="name">The name or path of the file to save.</param>
        /// <param name="format">The format in which the image should be saved.</param>
        /// <returns>True if the image is saved successfully; otherwise, false.</returns>
        public bool Save(Image imageToSave, string name, System.Drawing.Imaging.ImageFormat format)
        {
            try
            {
                // Save the image with the specified name and format
                imageToSave.Save(name, format);
                return true;
            }
            catch (Exception)
            {
                // Return false if an exception is thrown during the image save
                return false;
            }
        }
    }
}
