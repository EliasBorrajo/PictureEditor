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
			int razX = Convert.ToInt32(bitmap.Width / 3);
			int razY = Convert.ToInt32(bitmap.Height / 3);
			Bitmap temp = new Bitmap(bitmap.Width, bitmap.Height);

			for (int i = 0; i < bitmap.Width - 1; i++)
			{
				for (int x = 0; x < bitmap.Height - 1; x++)
				{
					if (i < razX && x < razY)
					{
						temp.SetPixel(i, x, bitmap.GetPixel(i, x));
					}
					else if (i < (razX * 2) && x < (razY))
					{
						temp.SetPixel(i, x, bitmap.GetPixel(x, i));
					}
					else if (i < (razX * 3) && x < (razY))
					{
						temp.SetPixel(i, x, bitmap.GetPixel(i, x));
					}
					else if (i < (razX) && x < (razY * 2))
					{
						temp.SetPixel(i, x, bitmap.GetPixel(x, i));
					}
					else if (i < (razX) && x < (razY * 3))
					{
						temp.SetPixel(i, x, bitmap.GetPixel(i, x));
					}
					else if (i < (razX * 2) && x < (razY * 2))
					{
						temp.SetPixel(i, x, bitmap.GetPixel(i, x));
					}
					else if (i < (razX * 4) && x < (razY * 1))
					{
						temp.SetPixel(i, x, bitmap.GetPixel(i, x));
					}
					else if (i < (razX * 4) && x < (razY * 2))
					{
						temp.SetPixel(i, x, bitmap.GetPixel(x / 2, i / 2));
					}
					else if (i < (razX * 4) && x < (razY * 3))
					{
						temp.SetPixel(i, x, bitmap.GetPixel(x / 3, i / 3));
					}
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
