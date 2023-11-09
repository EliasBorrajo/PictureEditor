using PictureEditor.BusinessLayer.Interfaces;
using PictureEditor.BusinessLayer.Managers.EdgeDetection;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace PictureEditor.BusinessLayer.Managers
{
	public class EdgeDetectionManager : IEdgeDetection
	{
		private readonly Dictionary<string, double[,]> edgeDetectionMatrices;

		// C O N S T R U C T O R
		public EdgeDetectionManager()
		{
			// Initialisez le dictionnaire avec les noms des algorithmes en tant que clés et les matrices en tant que valeurs. 
			edgeDetectionMatrices = new Dictionary<string, double[,]>
			{
				{ "Laplacian",      Matrix.Laplacian },
				{ "Sobel",              Matrix.Sobel },
				{ "Kirsch",             Matrix.Kirsch }
			};
		}

		public double[,] GetFilterMatrix(string filterName)
		{
			// Vérifiez si le nom de l'algorithme existe dans le dictionnaire
			if (edgeDetectionMatrices.ContainsKey(filterName))
			{
				return edgeDetectionMatrices[filterName];
			}
			else
			{
				// Si le nom de l'algorithme n'est pas trouvé, retournez par défaut Laplacian
				return Matrix.Laplacian;
			}
		}

		public IEnumerable<string> GetAvailableAlgorithms()
		{
			return edgeDetectionMatrices.Keys;
		}


		/// <summary>
		/// Détecte les bords de l'image en utilisant des filtres spécifiés.
		/// </summary>
		/// <param name="xfilter">Nom du filtre X.</param>
		/// <param name="yfilter">Nom du filtre Y.</param>
		public Bitmap detectPictureEdges(Bitmap inputCurrentBitmap, double[,] xFilterMatrix, double[,] yFilterMatrix)
		{
			if (inputCurrentBitmap.Size.Height == 0 || inputCurrentBitmap.Size.Width == 0)
			{
				// If the image is empty, then return it simply
				return new Bitmap(inputCurrentBitmap);
			}

			// Crée une copie de l'image dans un format modifiable.
			Bitmap newbitmap = new Bitmap(inputCurrentBitmap);
			BitmapData newbitmapData = new BitmapData();
			newbitmapData = newbitmap.LockBits(new Rectangle(0, 0, newbitmap.Width, newbitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);

			byte[] pixelbuff = new byte[newbitmapData.Stride * newbitmapData.Height];
			byte[] resultbuff = new byte[newbitmapData.Stride * newbitmapData.Height];

			Marshal.Copy(newbitmapData.Scan0, pixelbuff, 0, pixelbuff.Length);
			newbitmap.UnlockBits(newbitmapData);
			int filterOffset = 1;
			for (int offsetY = filterOffset; offsetY <
				newbitmap.Height - filterOffset; offsetY++)
			{
				for (int offsetX = filterOffset; offsetX <
					newbitmap.Width - filterOffset; offsetX++)
				{
					double greenX;
					double redX;
					double blueX = greenX = redX = 0;
					double greenY;
					double redY;
					double blueY = greenY = redY = 0;
					int byteOffset = offsetY *
					newbitmapData.Stride +
					offsetX * 4;

					for (int filterY = -filterOffset;
						filterY <= filterOffset; filterY++)
					{
						for (int filterX = -filterOffset;
							filterX <= filterOffset; filterX++)
						{
							int calcOffset = byteOffset +
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
					double blueTotal = 0;
					double greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
					double redTotal = 0;

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



	}
}
