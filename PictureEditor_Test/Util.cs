using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureEditor_Test
{
	public static class Util
	{
		/// <summary>
		/// Compares two images pixel by pixel to check if they are identical.
		/// </summary>
		/// <param name="imageA">The first image to compare.</param>
		/// <param name="imageB">The second image to compare.</param>
		/// <returns>True if the images are identical; otherwise, false.</returns>
		public static bool CompareImages(Bitmap imageA, Bitmap imageB, int tolerance)
		{
			// Check if the images have the same dimensions
			if (imageA.Width != imageB.Width ||
				imageA.Height != imageB.Height)
			{
				return false;
			}

			// Iterate through each pixel and compare colors
			for (int i = 0; i < imageA.Width; i++)
			{
				for (int j = 0; j < imageA.Height; j++)
				{
					// Get the color of the pixel in each image
					Color pixelColorA = imageA.GetPixel(i, j);
					Color pixelColorB = imageB.GetPixel(i, j);

					// Compare color components with tolerance
					if (Math.Abs(pixelColorA.R - pixelColorB.R) > tolerance ||
						Math.Abs(pixelColorA.G - pixelColorB.G) > tolerance ||
						Math.Abs(pixelColorA.B - pixelColorB.B) > tolerance /*||
                        Math.Abs(pixelColorA.A - pixelColorB.A) > tolerance*/)
					{
						// If the difference in any color component is greater than the tolerance, the images are not identical
						return false;
					}
				}
			}

			// If all pixels are within the tolerance range, the images are considered the same
			return true;
		}


		/// <summary>
		/// Compares two matrices to check if they are identical.
		/// </summary>
		/// <param name="expected"></param>
		/// <param name="actual"></param>
		/// <returns></returns>
		public static bool AreMatricesEqual(double[,] expected, double[,] actual)
		{
			// Check if the matrices have the same dimensions 
			if (expected.GetLength(0) != actual.GetLength(0) || 
				expected.GetLength(1) != actual.GetLength(1))
			{
				return false;
			}

			// Iterate through each tile of the matrix and compare values
			for (int i = 0; i < expected.GetLength(0); i++)
			{
				for (int j = 0; j < expected.GetLength(1); j++)
				{
					if (expected[i, j] != actual[i, j])
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}
