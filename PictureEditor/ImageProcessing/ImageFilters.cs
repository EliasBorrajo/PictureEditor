using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureEditor.ImageProcessing
{
    /// <summary>
    /// Filter class for applying filters to images
    /// </summary>
    public static class ImageFilters
    {
        /// <summary>
        /// Apply rainbow Filter
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns>A bitmap with the rainbow filter applied</returns>
        public static Bitmap RainbowFilter(Bitmap bmp)
        {

            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);
            int raz = bmp.Height / 4;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {

                    if (i < raz)
                    {
                        temp.SetPixel(i, x, Color.FromArgb(bmp.GetPixel(i, x).R / 5, bmp.GetPixel(i, x).G, bmp.GetPixel(i, x).B));
                    }
                    else if (i < raz * 2)
                    {
                        temp.SetPixel(i, x, Color.FromArgb(bmp.GetPixel(i, x).R, bmp.GetPixel(i, x).G / 5, bmp.GetPixel(i, x).B));
                    }
                    else if (i < raz * 3)
                    {
                        temp.SetPixel(i, x, Color.FromArgb(bmp.GetPixel(i, x).R, bmp.GetPixel(i, x).G, bmp.GetPixel(i, x).B / 5));
                    }
                    else if (i < raz * 4)
                    {
                        temp.SetPixel(i, x, Color.FromArgb(bmp.GetPixel(i, x).R / 5, bmp.GetPixel(i, x).G, bmp.GetPixel(i, x).B / 5));
                    }
                    else
                    {
                        temp.SetPixel(i, x, Color.FromArgb(bmp.GetPixel(i, x).R / 5, bmp.GetPixel(i, x).G / 5, bmp.GetPixel(i, x).B / 5));
                    }
                }

            }
            return temp;
        }

        /// <summary>
        /// Apply a color filter to the given bitmap 
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="alpha"></param>
        /// <param name="red"></param>
        /// <param name="blue"></param>
        /// <param name="green"></param>
        /// <returns>The filtered bitmap</returns>
        public static Bitmap ApplyFilter(Bitmap bmp, int alpha, int red, int blue, int green)
        {

            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);


            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {
                    Color c = bmp.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A / alpha, c.R / red, c.G / green, c.B / blue);
                    temp.SetPixel(i, x, cLayer);
                }

            }
            return temp;
        }

        /// <summary>
        /// Black and white filter for the given bitmap
        /// </summary>
        /// <param name="Bmp"></param>
        /// <returns> The filtered bitmap </returns>
        public static Bitmap BlackWhite(Bitmap Bmp)
        {
            int rgb;
            Color c;

            for (int y = 0; y < Bmp.Height; y++)
                for (int x = 0; x < Bmp.Width; x++)
                {
                    c = Bmp.GetPixel(x, y);
                    rgb = (c.R + c.G + c.B) / 3;
                    Bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            return Bmp;

        }

        /// <summary>
        /// Apply color filter to swap pixel colors
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns>A bitmap with the colors swapped</returns>
        public static Bitmap ApplyFilterSwap(Bitmap bmp)
        {

            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);


            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {
                    Color c = bmp.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A, c.G, c.B, c.R);
                    temp.SetPixel(i, x, cLayer);
                }

            }
            return temp;
        }

        /// <summary>
        ///  Apply color filter to swap pixel colors
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="a"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns>A bitmap with the colors swapped</returns>
        public static Bitmap ApplyFilterSwapDivide(Bitmap bmp, int a, int r, int g, int b)
        {

            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);


            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {
                    Color c = bmp.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A / a, c.G / g, c.B / b, c.R / r);
                    temp.SetPixel(i, x, cLayer);
                }

            }
            return temp;
        }

        /// <summary>
        ///  Apply color filter to swap pixel colors
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <param name="co"></param>
        /// <returns>A bitmap with the colors swapped</returns>
        public static Bitmap ApplyFilterMega(Bitmap bmp, int max, int min, Color co)
        {

            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int x = 0; x < bmp.Height; x++)
                {

                    Color c = bmp.GetPixel(i, x);
                    if (c.G > min && c.G < max)
                    {
                        Color cLayer = Color.White;
                        temp.SetPixel(i, x, cLayer);
                    }
                    else
                    {
                        temp.SetPixel(i, x, co);
                    }

                }

            }
            return temp;
        }

        /// <summary>
        /// Apply magic mosaic
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns>A bitmap with the magic mosaic filter applied</returns>
        public static Bitmap DivideCrop(Bitmap bmp)
        {
            int razX = Convert.ToInt32(bmp.Width / 3);
            int razY = Convert.ToInt32(bmp.Height / 3);

            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);


            for (int i = 0; i < bmp.Width - 1; i++)
            {
                for (int x = 0; x < bmp.Height - 1; x++)
                {
                    if (i < razX && x < razY)
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(i, x));
                    }
                    else if (i < razX * 2 && x < razY)
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(x, i));
                    }
                    else if (i < razX * 3 && x < razY)
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(i, x));
                    }
                    else if (i < razX && x < razY * 2)
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(x, i));
                    }
                    else if (i < razX && x < razY * 3)
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(i, x));
                    }
                    else if (i < razX * 2 && x < razY * 2)
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(i, x));
                    }
                    else if (i < razX * 4 && x < razY * 1)
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(i, x));
                    }
                    else if (i < razX * 4 && x < razY * 2)
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(x / 2, i / 2));
                    }
                    else if (i < razX * 4 && x < razY * 3)
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(x / 3, i / 3));
                    }

                }

            }
            return temp;
        }



    }


}

