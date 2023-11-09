using PictureEditor.DAL;
using System.Drawing.Imaging;


namespace PictureEditor.Classes
{
    internal class OutputInputDatabase : IOutputInput
	{
		public Image Load(string name)
		{
			throw new NotImplementedException();
		}

		public void Save(Image imageToSave, string name, ImageFormat format)
		{
			throw new NotImplementedException();
		}
	}
}
