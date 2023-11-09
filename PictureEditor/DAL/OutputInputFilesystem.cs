namespace PictureEditor.DAL
{
	/// <summary>
	/// Class to handle the input and output of images from the filesystem.
	/// </summary>
	public class OutputInputFilesystem : IOutputInput // Implementing the IOutputInput interface
	{
		/// <summary>
		/// Loads the image from the specified file path.
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns>The loaded image.</returns>
		/// <exception cref="Exception"></exception>
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
		public void Save(Image imageToSave, string name, System.Drawing.Imaging.ImageFormat format)
		{
			imageToSave.Save(name, format);
		}
	}
}
