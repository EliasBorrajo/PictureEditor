
namespace PictureEditor.BusinessLayer.Interfaces
{
    public interface IOutputInput
    {
        bool SaveImageToFileSystem(Image imageToSave, SaveFileDialog saveFileDialog, System.Drawing.Imaging.ImageFormat format);
        void SaveImageToDB(Image imageToSave);
        Image LoadImage(string filepath);
    }
}
