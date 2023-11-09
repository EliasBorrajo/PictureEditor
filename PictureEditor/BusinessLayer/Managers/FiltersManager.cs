using PictureEditor.BusinessLayer.Interfaces;


namespace PictureEditor.BusinessLayer.Managers
{
	/// <summary>
	/// Filters manager class for applying filters to images.
	/// </summary>
	public class FiltersManager : IFilters
	{

		public Bitmap BlackWhite(Bitmap bitmap)
		{
			int rgb;
			Color c;

			for (int y = 0; y < bitmap.Height; y++)
				for (int x = 0; x < bitmap.Width; x++)
				{
					c = bitmap.GetPixel(x, y);
					rgb = (int)((c.R + c.G + c.B) / 3);
					bitmap.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
				}
			return bitmap;
		}

		public Bitmap MagicMosaic(Bitmap bitmap)
		{
			int numSquaresX = 3;
			int numSquaresY = 3;

			int squareWidth = (int)Math.Ceiling((double)bitmap.Width / numSquaresX);
			int squareHeight = (int)Math.Ceiling((double)bitmap.Height / numSquaresY);
			Bitmap temp = new Bitmap(bitmap.Width, bitmap.Height);

			for (int i = 0; i < bitmap.Width; i++)
			{
				for (int x = 0; x < bitmap.Height; x++)
				{
					Color pixel = Color.Black;

					// Calcule les indices des carrés en fonction des coordonnées actuelles
					int squareIndexX = i / squareWidth;
					int squareIndexY = x / squareHeight;

					// Sélectionne le pixel en fonction des indices des carrés
					if (squareIndexX % 2 == 0)
					{
						if (squareIndexY % 2 == 0)
						{
							pixel = bitmap.GetPixel(i, x);
						}
						else
						{
							pixel = GetPixelFromAlternateIndices(bitmap, x, i);
						}
					}
					else
					{
						if (squareIndexY % 2 == 0)
						{
							pixel = GetPixelFromAlternateIndices(bitmap, x, i);
						}
						else
						{
							int reduceFactor = squareIndexX * squareIndexY + 1;
							int reducedX = Math.Min(bitmap.Width - 1, (int)Math.Ceiling((double)x / reduceFactor));
							int reducedI = Math.Min(bitmap.Height - 1, (int)Math.Ceiling((double)i / reduceFactor));

							pixel = bitmap.GetPixel(reducedX, reducedI);
						}
					}

					temp.SetPixel(i, x, pixel);
				}
			}
			return temp;
		}

		/// <summary>
		/// Used by MagicMosaic to get the pixel from alternate indices. 
		/// It is used to get the pixel from the bitmap when the indices are inverted.
		/// </summary>
		/// <param name="bitmap"></param>
		/// <param name="x"></param>
		/// <param name="i"></param>
		/// <returns>Returns the pixel from the bitmap at the given indices.</returns>
		private Color GetPixelFromAlternateIndices(Bitmap bitmap, int x, int i)
		{
			int maxX = bitmap.Width - 1;
			int maxY = bitmap.Height - 1;

			int clampedX = Math.Min(maxX, x);
			int clampedI = Math.Min(maxY, i);

			return bitmap.GetPixel(clampedX, clampedI);
		}


		public Bitmap Swap(Bitmap bitmap)
		{
			Bitmap temp = new Bitmap(bitmap.Width, bitmap.Height);

			for (int i = 0; i < bitmap.Width; i++)
			{
				for (int x = 0; x < bitmap.Height; x++)
				{
					Color c = bitmap.GetPixel(i, x);
					Color cLayer = Color.FromArgb(c.A, c.G, c.B, c.R);
					temp.SetPixel(i, x, cLayer);
				}
			}
			return temp;
		}
	}
}
