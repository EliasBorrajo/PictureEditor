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
        public bool SaveImageToFileSystem_V2(Image imageToSave)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveFileDialog.Title = "Save an Image File";
                if (saveFileDialog.ShowDialog() == DialogResult.OK) // 
                {
                    System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png; // Default to PNG
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 2:
                            format = System.Drawing.Imaging.ImageFormat.Jpeg;
                            break;
                        case 3:
                            format = System.Drawing.Imaging.ImageFormat.Bmp;
                            break;
                    }
                    imageToSave.Save(saveFileDialog.FileName, format);

                    // Show a message box to confirm the image was saved successfully.
                    MessageBox.Show(
                        "Image saved successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                
            }
            return false;
        }

		public bool SaveImageToFileSystem_V2(Image imageToSave, SaveFileDialog saveFileDialog, System.Drawing.Imaging.ImageFormat format)
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
