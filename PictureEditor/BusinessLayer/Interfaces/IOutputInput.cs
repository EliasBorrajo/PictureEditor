
namespace PictureEditor.BusinessLayer.Interfaces
{
    public interface IOutputInput
    {
        bool Save(Image imageToSave, string name, System.Drawing.Imaging.ImageFormat format);
        
        Image Load(string name);
    }
}
