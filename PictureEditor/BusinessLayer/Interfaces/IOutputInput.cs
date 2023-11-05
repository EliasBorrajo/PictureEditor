using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureEditor.BusinessLayer.Interfaces
{
    public interface IOutputInput
    {
        bool SaveImageToFileSystem_V2(Image imageToSave);
        bool SaveImageToFileSystem_V2(Image imageToSave, SaveFileDialog saveFileDialog, System.Drawing.Imaging.ImageFormat format);
        void SaveImageToDB(Image imageToSave);
        Image LoadImage(string filepath);
    }
}
