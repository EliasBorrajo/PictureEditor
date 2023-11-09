using PictureEditor.BusinessLayer.Interfaces;
using System.Drawing.Imaging;


namespace PictureEditor.BusinessLayer.Classes
{
    internal class OutputInputDatabase : IOutputInput
    {
        public Image Load(string name)
        {
            throw new NotImplementedException();
        }

        public bool Save(Image imageToSave, string name, ImageFormat format)
        {
            throw new NotImplementedException();
        }
    }
}
