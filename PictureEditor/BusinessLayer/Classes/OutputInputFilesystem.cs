using PictureEditor.BusinessLayer.Interfaces;


namespace PictureEditor.BusinessLayer.Classes
{
    public class OutputInputFilesystem : IOutputInput
    {
        
        public Image Load(string filePath)
        {
            try
            {
                Image loadedImage = Image.FromFile(filePath);
                return loadedImage;
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, or throw a custom exception if needed
                throw new Exception("Error loading image: " + ex.Message);
            }
        }

        public bool Save(Image imageToSave, string name, System.Drawing.Imaging.ImageFormat format)
        {
            try
            {
                imageToSave.Save(name, format);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
