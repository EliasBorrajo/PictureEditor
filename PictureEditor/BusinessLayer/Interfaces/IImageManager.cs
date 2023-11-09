
using PictureEditor.DAL;

namespace PictureEditor.BusinessLayer.Interfaces
{
	/// <summary>
	/// The image manager interface is useed as a link between the presentation layer and the data access layer.
	/// </summary>
	public interface IImageManager
	{
		/// <summary>
		/// Saves the provided image using the specified IOutputInput instance, file name, and image format.
		/// IIOutputInput is an reference to the data access layer.
		/// </summary>
		/// <param name="outputInput"></param>
		/// <param name="imageToSave"></param>
		/// <param name="name"></param>
		/// <param name="format"></param>
		/// <returns>Returns true if the image is saved successfully; otherwise, false.</returns>
		bool Save(IOutputInput outputInput, Image imageToSave, string name, System.Drawing.Imaging.ImageFormat format);

		/// <summary>
		/// Loads the provided image using the specified IOutputInput instance, file name, and image format.
		/// IIOutputInput is an reference to the data access layer.
		/// </summary>
		/// <param name="outputInput"></param>
		/// <param name="imageToSave"></param>
		/// <param name="name"></param>
		/// <param name="format"></param>
		/// <returns>Reurns the loaded image.</returns>
		Image Load(IOutputInput outputInput, string filePath);
	}
}
