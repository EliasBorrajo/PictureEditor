using PictureEditor.BusinessLayer.Interfaces;


namespace PictureEditor.BusinessLayer.Managers
{
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

                    int squareIndexX = i / squareWidth;
                    int squareIndexY = x / squareHeight;

                    if (squareIndexX % 2 == 0)
                    {
                        if (squareIndexY % 2 == 0)
                        {
                            pixel = bitmap.GetPixel(i, x);
                        }
                        else
                        {
                            if (x < bitmap.Width && i < bitmap.Height)
                            {
                                pixel = bitmap.GetPixel(x, i);
                            }
                        }
                    }
                    else
                    {
                        if (squareIndexY % 2 == 0)
                        {
                            if (x < bitmap.Width && i < bitmap.Height)
                            {
                                pixel = bitmap.GetPixel(x, i);
                            }
                        }
                        else
                        {
                            int reduceFactor = squareIndexX * squareIndexY + 1;
                            int reducedX = (int)Math.Ceiling((double)x / reduceFactor);
                            int reducedI = (int)Math.Ceiling((double)i / reduceFactor);

                            int maxX = bitmap.Width - 1;
                            int maxY = bitmap.Height - 1;

                            int clampedX = Math.Min(reducedX, maxX);
                            int clampedI = Math.Min(reducedI, maxY);

                            pixel = bitmap.GetPixel(clampedX, clampedI);
                        }
                    }

                    temp.SetPixel(i, x, pixel);
                }
            }
            return temp;
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
