using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureEditor.BusinessLayer.Interfaces
{
    public interface IImageManager
    {
        bool Save(IOutputInput outputInput, Image imageToSave, string name, System.Drawing.Imaging.ImageFormat format);

        Image Load(IOutputInput outputInput, string filePath);

        Image ApplyFilter(IFilter filter, Bitmap bitmap);



        // Image DetectEdges(IFilter filter, Image image);
    }
}
