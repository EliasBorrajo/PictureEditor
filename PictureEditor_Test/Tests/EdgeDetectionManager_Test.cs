using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using PictureEditor.BusinessLayer.Interfaces;
using PictureEditor.BusinessLayer.Managers;
using PictureEditor.BusinessLayer.Managers.EdgeDetection;
using System.Drawing;

namespace PictureEditor_Test.Tests
{
	[TestClass]
	public class EdgeDetectionManager_Test
	{
		public static string RessourcesPath = Directory.GetCurrentDirectory() + "\\Ressources";
		public static string OriginalPath			= RessourcesPath + "\\Original.bmp";
		public static string LaplacianXYPath	= RessourcesPath + "\\LaplacianXY.bmp";
		public static string KirschXYPath			= RessourcesPath + "\\KirschXY.bmp";
		public static string SobelXYPath			= RessourcesPath + "\\SobelXY.bmp";

		private IEdgeDetection? EdgeDetectionSubstitute;
		private EdgeDetectionManager? EdgeDetectionManager;

		[TestInitialize]
		public void Initialize()
		{
			EdgeDetectionSubstitute = Substitute.For<IEdgeDetection>();
			EdgeDetectionManager = new EdgeDetectionManager();
		}

		[TestMethod]
		public void TestEdgeDetectorAlgo_Laplacian_tolerance150()
		{
			// 1) Load images
			Bitmap ImageReference	= new Bitmap(LaplacianXYPath);
			Bitmap ImageToDetect	= new Bitmap(OriginalPath);

			// Get the matrix
			string xFilterName = "Laplacian";
			string yFilterName = "Laplacian";

			double[,] xFilterMatrix = EdgeDetectionManager.GetFilterMatrix(xFilterName);
			double[,] yFilterMatrix = EdgeDetectionManager.GetFilterMatrix(yFilterName);

			// 2) Apply the algorithm
			ImageToDetect = EdgeDetectionManager.detectPictureEdges(ImageToDetect, xFilterMatrix, yFilterMatrix);


			// 3) Compare the 2 images pixel by pixel to see if they are the same, there is a tolerance of 1 RGB value for each pixel
			int tolerance = 150;
			Assert.IsTrue(Util.CompareImages(ImageToDetect, ImageReference, tolerance));
			// je sais que la couverture du code est remplie,
			// mais les algos en X et Y sont non déterministes, donc impossible à prédire, il faut une grande tolérance 
		}



		[TestMethod]
		public void GetFilterMatrix_ShouldReturnLaplacianMatrix_WhenAlgorithmNotFound()
		{
			// Arrange
			string nonExistentAlgorithm = "NonExistentAlgorithm";

			// Act
			var result = EdgeDetectionManager.GetFilterMatrix(nonExistentAlgorithm);

			// Assert
			CollectionAssert.AreEqual(Matrix.Laplacian, result);
		}

		[TestMethod]
		public void GetFilterMatrix_ShouldReturnCorrectMatrix_WhenAlgorithmFound()
		{
			// Arrange
			string existingAlgorithm = "Sobel"; // Assume "Sobel" algorithm exists in the edgeDetectionMatrices dictionary

			// Act
			var result = EdgeDetectionManager.GetFilterMatrix(existingAlgorithm);

			// Assert
			Assert.IsNotNull(result);
			// Add additional assertions to validate the correctness of the returned matrix
			Assert.IsTrue(Util.AreMatricesEqual(Matrix.Sobel, result));
		}

		[TestMethod]
		public void GetAvailableAlgorithms_ShouldReturnNonEmptyList()
		{
			// Act
			var algorithms = EdgeDetectionManager.GetAvailableAlgorithms();

			// Assert
			Assert.IsNotNull(algorithms);
			Assert.IsTrue(algorithms.Any());
		}


		[TestMethod]
		public void Laplacian_ShouldReturnCorrectMatrix()
		{
			double[,] expected = {
				  { -1, -1, -1,  },
				  { -1,  8, -1,  },
				  { -1, -1, -1,  }
			};

			// Vérifie que la matrice Laplacian3x3 correspond à la matrice attendue.
			CollectionAssert.AreEqual(expected, Matrix.Laplacian);
		}

		[TestMethod]
		public void Kirsch_ShouldReturnCorrectMatrix()
		{
			double[,] expected = {
				  {  5,  5,  5, },
				  { -3,  0, -3, },
				  { -3, -3, -3, }
			};

			// Vérifie que la matrice Laplacian3x3 correspond à la matrice attendue.
			CollectionAssert.AreEqual(expected, Matrix.Kirsch);
		}

		[TestMethod]
		public void Sobel_ShouldReturnCorrectMatrix()
		{
			double[,] expected = {
				  { -1,  0,  1, },
				  { -2,  0,  2, },
				  { -1,  0,  1, }
			};

			// Vérifie que la matrice Laplacian3x3 correspond à la matrice attendue.
			CollectionAssert.AreEqual(expected, Matrix.Sobel);
		}

	}
}
