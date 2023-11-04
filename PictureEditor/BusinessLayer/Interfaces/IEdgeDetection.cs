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
		IEnumerable<string> GetAvailableAlgorithms();

		/// <summary>
		/// Edge detection using specified filters and matrix convolution. 
		/// </summary>
		/// <param name="inputCurrentBitmap"></param>
		/// <param name="xFilterMatrix"></param>
		/// <param name="yFilterMatrix"></param>
		/// <returns>A bitmap with detected edges applied.</returns>
		Bitmap detectPictureEdges(Bitmap inputCurrentBitmap, double[,] xFilterMatrix, double[,] yFilterMatrix);

	}
}
