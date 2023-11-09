using PictureEditor.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureEditor.BusinessLayer
{
    public class ImageManager : IImageManager
    {
        public Image ApplyFilter(IFilter filter, Bitmap bitmap)
        {
            return filter.Apply(bitmap);
        }

        public Image Load(IOutputInput outputInput, string name)
        {
            return outputInput.Load(name);
        }

        public bool Save(IOutputInput outputInput, Image imageToSave, string name, ImageFormat format)
        {
            return outputInput.Save(imageToSave, name, format);
        }
    }
}
