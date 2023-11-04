using PictureEditor.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureEditor.BusinessLayer.Managers
{
    public class EdgeDetectionManager : IEdgeDetection
    {
        public double[,] GetFilterMatrix(string filterName)
        {
            switch (filterName)
            {
                case "Laplacian3x3":
                    return Matrix.Laplacian3x3;
                case "Laplacian5x5":
                    return Matrix.Laplacian5x5;
                case "LaplacianOfGaussian":
                    return Matrix.LaplacianOfGaussian;
                case "Gaussian3x3":
                    return Matrix.Gaussian3x3;
                case "Gaussian5x5Type1":
                    return Matrix.Gaussian5x5Type1;
                case "Gaussian5x5Type2":
                    return Matrix.Gaussian5x5Type2;
                case "Sobel3x3Horizontal":
                    return Matrix.Sobel3x3Horizontal;
                case "Sobel3x3Vertical":
                    return Matrix.Sobel3x3Vertical;
                case "Prewitt3x3Horizontal":
                    return Matrix.Prewitt3x3Horizontal;
                case "Prewitt3x3Vertical":
                    return Matrix.Prewitt3x3Vertical;
                case "Kirsch3x3Horizontal":
                    return Matrix.Kirsch3x3Horizontal;
                case "Kirsch3x3Vertical":
                    return Matrix.Kirsch3x3Vertical;
                default:
                    return Matrix.Laplacian3x3;         // TODO : Change with -> return null;
            }
        }


        /// <summary>
        /// Détecte les bords de l'image en utilisant des filtres spécifiés.
        /// </summary>
        /// <param name="xfilter">Nom du filtre X.</param>
        /// <param name="yfilter">Nom du filtre Y.</param>
        public Bitmap detectPictureEdges(Bitmap inputCurrentBitmap, double[,] xFilterMatrix, double[,] yFilterMatrix)
        {

            if (inputCurrentBitmap.Size.Height > 0)
            {
                // Crée une copie de l'image dans un format modifiable.
                Bitmap newbitmap = new Bitmap(inputCurrentBitmap);
                BitmapData newbitmapData = new BitmapData();
                newbitmapData = newbitmap.LockBits(new Rectangle(0, 0, newbitmap.Width, newbitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);

                byte[] pixelbuff = new byte[newbitmapData.Stride * newbitmapData.Height];
                byte[] resultbuff = new byte[newbitmapData.Stride * newbitmapData.Height];

                Marshal.Copy(newbitmapData.Scan0, pixelbuff, 0, pixelbuff.Length);
                newbitmap.UnlockBits(newbitmapData);

                double blue = 0.0;
                double green = 0.0;
                double red = 0.0;
                double blueX = 0.0;
                double greenX = 0.0;
                double redX = 0.0;
                double blueY = 0.0;
                double greenY = 0.0;
                double redY = 0.0;
                double blueTotal = 0.0;
                double greenTotal = 0.0;
                double redTotal = 0.0;
                int filterOffset = 1;
                int calcOffset = 0;
                int byteOffset = 0;

                for (int offsetY = filterOffset; offsetY <
                    newbitmap.Height - filterOffset; offsetY++)
                {
                    for (int offsetX = filterOffset; offsetX <
                        newbitmap.Width - filterOffset; offsetX++)
                    {
                        blueX = greenX = redX = 0;
                        blueY = greenY = redY = 0;
                        byteOffset = offsetY *
                                     newbitmapData.Stride +
                                     offsetX * 4;

                        for (int filterY = -filterOffset;
                            filterY <= filterOffset; filterY++)
                        {
                            for (int filterX = -filterOffset;
                                filterX <= filterOffset; filterX++)
                            {
                                calcOffset = byteOffset +
                                             (filterX * 4) +
                                             (filterY * newbitmapData.Stride);

                                blueX += pixelbuff[calcOffset] *
                                          xFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                greenX += pixelbuff[calcOffset + 1] *
                                          xFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                redX += pixelbuff[calcOffset + 2] *
                                          xFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                blueY += pixelbuff[calcOffset] *
                                          yFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                greenY += pixelbuff[calcOffset + 1] *
                                          yFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                redY += pixelbuff[calcOffset + 2] *
                                          yFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];
                            }
                        }
                        blueTotal = 0;
                        greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                        redTotal = 0;

                        if (blueTotal > 255)
                        { blueTotal = 255; }
                        else if (blueTotal < 0)
                        { blueTotal = 0; }

                        if (greenTotal > 255)
                        { greenTotal = 255; }
                        else if (greenTotal < 0)
                        { greenTotal = 0; }

                        if (redTotal > 255)
                        { redTotal = 255; }
                        else if (redTotal < 0)
                        { redTotal = 0; }

                        resultbuff[byteOffset] = (byte)(blueTotal);
                        resultbuff[byteOffset + 1] = (byte)(greenTotal);
                        resultbuff[byteOffset + 2] = (byte)(redTotal);
                        resultbuff[byteOffset + 3] = 255;
                    }
                }

                Bitmap resultbitmap = new Bitmap(newbitmap.Width, newbitmap.Height);
                BitmapData resultData = resultbitmap.LockBits(new Rectangle(0, 0,
                                         resultbitmap.Width, resultbitmap.Height),
                                                          ImageLockMode.WriteOnly,
                                                      PixelFormat.Format32bppArgb);

                Marshal.Copy(resultbuff, 0, resultData.Scan0, resultbuff.Length);
                resultbitmap.UnlockBits(resultData);
                inputCurrentBitmap = resultbitmap;
                return inputCurrentBitmap;
            }
            else
            {
                return null;
            }
        }



    }
}
