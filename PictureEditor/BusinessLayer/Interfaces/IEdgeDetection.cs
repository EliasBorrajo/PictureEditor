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
        Bitmap ApplyEdgeDetector(Bitmap inputCurrentBitmap, double[,] xFilterMatrix, double[,] yFilterMatrix, int threshold);
        void ApplyFiltersToPixel(int x,
                                                                    int y,
                                                                    BitmapData bitmapData,
                                                                    byte[] pixelBuffer,
                                                                    byte[] resultBuffer,
                                                                    double[,] xFilterMatrix,
                                                                    double[,] yFilterMatrix,
                                                                    int threshold);
        double[,] GetFilterMatrix(string filterName);

    }
}
