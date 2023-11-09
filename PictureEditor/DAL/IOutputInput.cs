namespace PictureEditor.DAL
{
    public interface IOutputInput
    {
        void Save(Image imageToSave, string name, System.Drawing.Imaging.ImageFormat format);

        Image Load(string name);
    }
}
