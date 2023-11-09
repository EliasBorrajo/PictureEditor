using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using PictureEditor.BusinessLayer.Interfaces;
using PictureEditor.BusinessLayer.Managers;
using System.Drawing;

namespace PictureEditor_Test.Tests
{
	[TestClass]
	public class FiltersManager_Test
	{
		public static string RessourcesPath = Directory.GetCurrentDirectory() + "\\Ressources";
		public static string OriginalPath = RessourcesPath + "\\Original.bmp";
		public static string BlackWhitePath = RessourcesPath + "\\BlackAndWhite.bmp";
		public static string SwapPath = RessourcesPath + "\\Swap.bmp";
		public static string MagicPath = RessourcesPath + "\\Magic.bmp";

		private IFilters? FiltersSubstitute;
		private FiltersManager? FiltersManager;

		[TestInitialize]
		public void Initialize()
		{
			FiltersSubstitute = Substitute.For<IFilters>();
			FiltersManager = new FiltersManager();
		}


		[TestMethod]
		public void TestMethod1()
		{
			//1)  Pour tester les filtres, 2 filtres à tester, il faut dabord le faire manuellement, sauver l'image fait manuellement, la mettre dans le dossier ressources
			// et dans les paramètres -> (propriétés > Toujours copier !).
			// Ensuite le test doit refaire mon truc manuel, et comparer mes 2 imgages pixel par pixel.

			// 2) Pour faire ça avec les algos, same avec 3 algos

			// Pour ces 5 trucs à tester, je dois couvrir le 100% de code coverage


		}

		/// <summary>
		/// Test the filter "BlackWhite" with the original image. 
		/// The filter "BlackWhite" is applied to the original image and then compared pixel by pixel with the image already modified.
		/// </summary>
		[TestMethod]
		public void TestFilterBlackAndWhite()
		{
			// 1) Load images
			Bitmap ImageReference = new Bitmap(BlackWhitePath);         // 1) Load the image with the filter already applied
			Bitmap imageToFilter = new Bitmap(OriginalPath);                        // 2) Load the original image to modify and then compare with the other image

			// 2) Apply the filter

			imageToFilter = FiltersManager.BlackWhite(imageToFilter);

			// 3) Compare the 2 images pixel by pixel to see if they are the same, there is a tolerance of 1 RGB value for each pixel
			int tolerance = 1;
			Assert.IsTrue(Util.CompareImages(ImageReference, imageToFilter, tolerance));
		}

		[TestMethod]
		public void TestFilterSwap_ShouldSwapImageColors()
		{
			// 1) Load images
			Bitmap ImageReference = new Bitmap(SwapPath);         // 1) Load the image with the filter already applied
			Bitmap imageToFilter = new Bitmap(OriginalPath);                        // 2) Load the original image to modify and then compare with the other image

			// 2) Apply the filter

			imageToFilter = FiltersManager.Swap(imageToFilter);

			// 3) Compare the 2 images pixel by pixel to see if they are the same, there is a tolerance of 5 RGB value for each pixel
			int tolerance = 5;
			Assert.IsTrue(Util.CompareImages(ImageReference, imageToFilter, tolerance));
		}

		[TestMethod]
		public void TestFilterMagic_ShouldApplyMagicEffect()
		{
			// 1) Load images
			Bitmap ImageReference = new Bitmap(MagicPath);         // 1) Load the image with the filter already applied
			Bitmap imageToFilter = new Bitmap(OriginalPath);                        // 2) Load the original image to modify and then compare with the other image

			// 2) Apply the filter

			imageToFilter = FiltersManager.MagicMosaic(imageToFilter);

			// 3) Compare the 2 images pixel by pixel to see if they are the same, there is a tolerance of 1 RGB value for each pixel
			int tolerance = 0;
			Assert.IsTrue(Util.CompareImages(ImageReference, imageToFilter, tolerance));
		}



	}
}
