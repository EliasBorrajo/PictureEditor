using PictureEditor.BusinessLayer.Interfaces;
using PictureEditor.BusinessLayer.Managers.EdgeDetection;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace PictureEditor.BusinessLayer.Managers
{
	/// <summary>
	/// EdgeDetectionManager class for detecting the edges of an image. 
	/// </summary>
	public class EdgeDetectionManager : IEdgeDetection
	{
		// F I E L D S
		private readonly Dictionary<string, double[,]> edgeDetectionMatrices;	// Dictionnary that contains the names of the algorithms as keys and the matrices as values.

		// C O N S T R U C T O R
		public EdgeDetectionManager()
		{
			// Initialisez le dictionnaire avec les noms des algorithmes en tant que clés et les matrices en tant que valeurs. 
			edgeDetectionMatrices = new Dictionary<string, double[,]>
			{
				{ "Laplacian",		    Matrix.Laplacian },
				{ "Sobel",                 Matrix.Sobel },
				{ "Kirsch",                 Matrix.Kirsch }
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

		public Bitmap detectPictureEdges(Bitmap inputCurrentBitmap, double[,] xFilterMatrix, double[,] yFilterMatrix)
		{

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
					double greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY)); // A square root will never be less than zero
					double redTotal = 0;

					if (greenTotal > 255)
					{
						greenTotal = 255;
					}

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
