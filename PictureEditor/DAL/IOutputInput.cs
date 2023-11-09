namespace PictureEditor.DAL
{
	/// <summary>
	/// Interface for the OutputInput class to handle the input and output of images 
	/// </summary>
	public interface IOutputInput
	{
		/// <summary>
		/// Save the image to the specified path with the specified name and format.
		/// Technically would be better to return bool to indicate success or failure.
		/// But for the sake of the project needs and specifications, we will return void.
		/// </summary>
		/// <param name="imageToSave"></param>
		/// <param name="name"></param>
		/// <param name="format"></param>
		void Save(Image imageToSave, string name, System.Drawing.Imaging.ImageFormat format);

		/// <summary>
		/// Load the image from the specified path and return it.
		/// </summary>
		/// <param name="name"></param>
		/// <returns>Returns the loaded image.</returns>
		Image Load(string name);
	}
}
