using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureEditor.BusinessLayer.Interfaces
{
    public interface IOutputInput
    {
        void SaveImage(Image imageToSave);
        Image LoadImage();
    }
}
