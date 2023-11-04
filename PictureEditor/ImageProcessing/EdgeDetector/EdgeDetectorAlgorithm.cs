using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PictureEditor.ImageProcessing.EdgeDetector
{
    public static class EdgeDetectorAlgorithm
    {
        /// <summary>
        /// Applies edge detection filters to the input bitmap using the specified X and Y filter matrices and a given threshold.
        /// </summary>
        /// <param name="inputCurrentBitmap">The input bitmap to which edge detection filters will be applied.</param>
        /// <param name="xFilterMatrix">The X filter matrix used for horizontal edge detection.</param>
        /// <param name="yFilterMatrix">The Y filter matrix used for vertical edge detection.</param>
        /// <param name="threshold">The threshold value used to determine whether a pixel is considered an edge or not.</param>
        /// <returns>A new bitmap with edge detection filters applied.</returns>
        public static Bitmap ApplyEdgeDetector(Bitmap inputCurrentBitmap, double[,] xFilterMatrix, double[,] yFilterMatrix, int threshold)
        {
            // Create a new bitmap with the same dimensions as the input bitmap
            Bitmap newBitmap = new Bitmap(inputCurrentBitmap);

            // Lock the bits of the new bitmap for reading and writing
            BitmapData bitmapData = newBitmap.LockBits(new Rectangle(0, 0, newBitmap.Width, newBitmap.Height), 
                                                                                         ImageLockMode.ReadOnly, 
                                                                                         PixelFormat.Format32bppPArgb);

            // Create a result bitmap with the same dimensions as the input bitmap
            Bitmap resultBitmap = new Bitmap(newBitmap.Width, newBitmap.Height);

            try
            {
                // Create buffers to store pixel data
                byte[] pixelBuffer  = new byte[bitmapData.Stride * bitmapData.Height];
                byte[] resultBuffer = new byte[bitmapData.Stride * bitmapData.Height];

                // Copy pixel data from the input bitmap to the pixel buffer
                Marshal.Copy(bitmapData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

                // Apply edge detection filters to each pixel of the bitmap
                // the offset is set to 1 to avoid the edges of the image
                // the height and width are set to -1 to avoid the edges of the image
                for (int offsetY = 1; offsetY < newBitmap.Height -1 ; offsetY++)
                {
                    for (int offsetX = 1; offsetX < newBitmap.Width -1 ; offsetX++)
                    {
                        // Apply filters to the current pixel
                        ApplyFiltersToPixel(offsetX, offsetY, bitmapData, pixelBuffer, resultBuffer, xFilterMatrix, yFilterMatrix, threshold);
                    }
                }

                // Lock the bits of the result bitmap for writing
                BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), 
                                                                                            ImageLockMode.WriteOnly, 
                                                                                            PixelFormat.Format32bppArgb);

                try
                {
                    // Copy the result buffer data to the result bitmap
                    Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
                }
                finally
                {
                    // Unlock the bits of the result bitmap
                    resultBitmap.UnlockBits(resultData);
                }
            }
            finally
            {
                // Unlock the bits of the input bitmap
                newBitmap.UnlockBits(bitmapData);
            }

            // Return the resulting bitmap with edge detection filters applied
            return resultBitmap;
        }


        /// <summary>
        /// Applies the specified X and Y filter matrices to the pixel at the given coordinates in the input bitmap.
        /// </summary>
        /// <param name="x">The x-coordinate of the pixel in the bitmap.</param>
        /// <param name="y">The y-coordinate of the pixel in the bitmap.</param>
        /// <param name="bitmapData">Bitmap data containing pixel information.</param>
        /// <param name="pixelBuffer">Buffer containing pixel data from the input bitmap.</param>
        /// <param name="resultBuffer">Buffer to store the filtered pixel data.</param>
        /// <param name="xFilterMatrix">The X filter matrix used for horizontal edge detection.</param>
        /// <param name="yFilterMatrix">The Y filter matrix used for vertical edge detection.</param>
        /// <param name="threshold">The threshold value used to determine whether a pixel is considered an edge or not.</param>
        private static void ApplyFiltersToPixel(int x, 
                                                                    int y, 
                                                                    BitmapData bitmapData, 
                                                                    byte[] pixelBuffer, 
                                                                    byte[] resultBuffer, 
                                                                    double[,] xFilterMatrix, 
                                                                    double[,] yFilterMatrix,
                                                                    int threshold)
        {
            double blueX = 0.0;
            double greenX = 0.0;
            double redX = 0.0;

            double blueY = 0.0;
            double greenY = 0.0;
            double redY = 0.0;

            int filterOffset = 1; 
            int byteOffset = y * bitmapData.Stride + x * 4; // 4 bytes per pixel (blue, green, red, alpha)

            // Apply the X and Y filter matrices to the pixel at the specified coordinates
            for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
            {
                for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                {
                    int calcOffset = byteOffset + (filterX * 4) + (filterY * bitmapData.Stride);

                    // Apply X filter to the pixel components (blue, green, red)
                    blueX += pixelBuffer[calcOffset] * xFilterMatrix[filterY + filterOffset, filterX + filterOffset];
                    greenX += pixelBuffer[calcOffset + 1] * xFilterMatrix[filterY + filterOffset, filterX + filterOffset];
                    redX += pixelBuffer[calcOffset + 2] * xFilterMatrix[filterY + filterOffset, filterX + filterOffset];

                    // Apply Y filter to the pixel components (blue, green, red)
                    blueY += pixelBuffer[calcOffset] * yFilterMatrix[filterY + filterOffset, filterX + filterOffset];
                    greenY += pixelBuffer[calcOffset + 1] * yFilterMatrix[filterY + filterOffset, filterX + filterOffset];
                    redY += pixelBuffer[calcOffset + 2] * yFilterMatrix[filterY + filterOffset, filterX + filterOffset];
                }
            }

            // Calculate the total intensity values after applying filters
            double greenTotal = Math.Sqrt(greenX * greenX + greenY * greenY);
            double redTotal = Math.Sqrt(redX * redX + redY * redY); 

            // Determine whether the pixel should be considered an edge based on the threshold value
            // trackBarThreshold est utilisé comme seuil pour déterminer si un pixel doit être considéré
            // comme blanc (255) ou noir (0) dans la composante verte après l'opération de filtrage.
            if (greenTotal < threshold)
            {
                greenTotal = 0; // Pixel is not an edge, set green component to 0 (black)
            }
            else
            {
                greenTotal = 255; // Pixel is an edge, set green component to 255 (white)
            }


            resultBuffer[byteOffset] = (byte)(blueX);
            resultBuffer[byteOffset + 1] = (byte)(greenTotal);
            resultBuffer[byteOffset + 2] = (byte)(redTotal);
            resultBuffer[byteOffset + 3] = 255;
        }

        /// <summary>
        /// Gets the filter matrix corresponding to the specified filter name.
        /// </summary>
        /// <param name="filterName"></param>
        /// <returns> Returns the filter matrix corresponding to the specified filter name.</returns>
        public static double[,] GetFilterMatrix(string filterName)
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

    }
}
