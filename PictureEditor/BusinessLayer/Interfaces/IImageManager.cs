
namespace PictureEditor.BusinessLayer.Interfaces
{
	public interface IImageManager
	{
		bool Save(IOutputInput outputInput, Image imageToSave, string name, System.Drawing.Imaging.ImageFormat format);

		Image Load(IOutputInput outputInput, string filePath);
	}
}
