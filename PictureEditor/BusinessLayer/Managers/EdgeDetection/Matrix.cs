

namespace PictureEditor.BusinessLayer.Managers.EdgeDetection
{
    /// <summary>
    /// Matrix class for storing the different edge detection matrices used by the edge detection algorithms.
    /// Size of the matrix must be odd, so that it has a center pixel. 
    /// 
    /// All matrices are square. All of them are 3x3 or 5x5. All of them return a matrix.
    /// </summary>
    public class Matrix
    {

        public static double[,] Laplacian
        {
            get
            {
                return new double[,]
                { { -1, -1, -1,  },
                  { -1,  8, -1,  },
                  { -1, -1, -1,  }, };
            }
        }

        public static double[,] Sobel
        {
            get
            {
                return new double[,]
                { { -1,  0,  1, },
                  { -2,  0,  2, },
                  { -1,  0,  1, }, };
            }
        }

        public static double[,] Kirsch
        {
            get
            {
                return new double[,]
                { {  5,  5,  5, },
                  { -3,  0, -3, },
                  { -3, -3, -3, }, };
            }
        }
    }
}
