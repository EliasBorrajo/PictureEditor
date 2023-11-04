using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureEditor.BusinessLayer.Interfaces
{
    internal interface IEdgeDetection
    {
        double[,] GetFilterMatrix(string filterName);
        Bitmap detectPictureEdges(Bitmap inputCurrentBitmap, double[,] xFilterMatrix, double[,] yFilterMatrix);
    }
}
