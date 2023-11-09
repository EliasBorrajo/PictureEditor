using PictureEditor.BusinessLayer.Interfaces;
using System.Drawing.Imaging;

namespace PictureEditor.BusinessLayer
{
	/// <summary>
	/// Represents a class responsible for managing the loading and saving of images.
	/// </summary>
	public class ImageManager : IImageManager
	{
		/// <summary>
		/// Loads an image using the provided IOutputInput instance and file name.
		/// </summary>
		/// <param name="outputInput">The IOutputInput instance used for loading the image.</param>
		/// <param name="name">The name or path of the file to be loaded.</param>
		/// <returns>The loaded Image object.</returns>
		public Image Load(IOutputInput outputInput, string name)
		{
			return outputInput.Load(name);
		}

		/// <summary>
		/// Saves the provided image using the specified IOutputInput instance, file name, and image format.
		/// </summary>
		/// <param name="outputInput">The IOutputInput instance used for saving the image.</param>
		/// <param name="imageToSave">The image to be saved.</param>
		/// <param name="name">The name or path of the file to save.</param>
		/// <param name="format">The format in which the image should be saved.</param>
		/// <returns>True if the image is saved successfully; otherwise, false.</returns>
		public bool Save(IOutputInput outputInput, Image imageToSave, string name, ImageFormat format)
		{
			return outputInput.Save(imageToSave, name, format);
		}
	}
}
