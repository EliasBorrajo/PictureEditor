using System.Drawing.Imaging;


namespace PictureEditor.DAL
{
	/// <summary>
	/// Class to handle the input and output of images from a database.
	/// </summary>
	internal class OutputInputDatabase : IOutputInput
	{
		/// <summary>
		/// Not implemented yet.
		/// I'ts in the specification, but we don't have time to implement it.
		/// </summary>
		/// <param name="name"></param>
		/// <returns>the loaded image</returns>
		/// <exception cref="NotImplementedException"></exception>
		public Image Load(string name)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Not implemented yet.
		/// I'ts in the specification, but we don't have time to implement it.
		/// </summary>
		/// <param name="name"></param>
		/// <exception cref="NotImplementedException"></exception>
		public void Save(Image imageToSave, string name, ImageFormat format)
		{
			throw new NotImplementedException();
		}
	}
}
