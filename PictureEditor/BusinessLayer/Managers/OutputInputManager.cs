using PictureEditor.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureEditor.BusinessLayer.Managers
{
    public class OutputInputManager : IOutputInput
    {
       
		public bool SaveImageToFileSystem(Image imageToSave, 
																		SaveFileDialog saveFileDialog, 
																		System.Drawing.Imaging.ImageFormat format)
		{
            try
            {
				imageToSave.Save(saveFileDialog.FileName, format);
                return true;
			}
            catch (Exception)
            {
                return false;
            }		
		}

		public void SaveImageToDB(Image imageToSave) 
		{
			throw new NotImplementedException();
		}

		public Image LoadImage(string filePath)
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

        
    }
}
