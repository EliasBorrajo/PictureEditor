using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using PictureEditor.BusinessLayer.Interfaces;
using PictureEditor.BusinessLayer.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureEditor_Test.Tests
{
    [TestClass]
    public class FiltersManager_Test
    {
		public static string RessourcePath = Directory.GetCurrentDirectory() + "\\Ressources";
		public static string MotoPath = RessourcePath + "\\Moto.png";

		//[TestMethod]
		//public void TestBlackWhite()
		//{
		//    // Créer un substitut de IFilters
		//    IFilters filtersSubstitut = Substitute.For<IFilters>();

		//    // Créer une instance de FiltersManager avec le substitut
		//    FiltersManager filtersManager = new FiltersManager();

		//    // Charger une image de test à partir d'un fichier (assurez-vous d'avoir une image appropriée dans le chemin spécifié)
		//    Bitmap inputBitmap = new Bitmap(cheminImageTest);

		//    // Définir le comportement du substitut
		//    filtersSubstitut.BlackWhite(inputBitmap).Returns(inputBitmap);

		//    // Appeler la méthode que vous voulez tester
		//    Bitmap resultBitmap = filtersManager.BlackWhite(inputBitmap);

		//    // Vérifier que la méthode a été appelée avec le bon argument
		//    filtersSubstitut.Received().BlackWhite(inputBitmap);

		//    // Vérifier que le résultat est le même que celui retourné par le substitut
		//    Assert.AreSame(inputBitmap, resultBitmap);
		//}

		//[TestMethod]
		//public void TestMagicMosaic()
		//{
		//    // Créer un substitut de IFilters
		//    IFilters filtersSubstitut = Substitute.For<IFilters>();

		//    // Créer une instance de FiltersManager avec le substitut
		//    FiltersManager filtersManager = new FiltersManager();

		//    // Charger une image de test à partir d'un fichier (assurez-vous d'avoir une image appropriée dans le chemin spécifié)
		//    Bitmap inputBitmap = new Bitmap(cheminImageTest);

		//    // Définir le comportement du substitut
		//    filtersSubstitut.MagicMosaic(inputBitmap).Returns(inputBitmap);

		//    // Appeler la méthode que vous voulez tester
		//    Bitmap resultBitmap = filtersManager.MagicMosaic(inputBitmap);

		//    // Vérifier que la méthode a été appelée avec le bon argument
		//    filtersSubstitut.Received().MagicMosaic(inputBitmap);

		//    // Vérifier que le résultat est le même que celui retourné par le substitut
		//    Assert.AreSame(inputBitmap, resultBitmap);
		//}

		//[TestMethod]
		//public void TestSwap()
		//{
		//    // Créer un substitut de IFilters
		//    IFilters filtersSubstitut = Substitute.For<IFilters>();

		//    // Créer une instance de FiltersManager avec le substitut
		//    FiltersManager filtersManager = new FiltersManager();

		//    // Charger une image de test à partir d'un fichier (assurez-vous d'avoir une image appropriée dans le chemin spécifié)
		//    Bitmap inputBitmap = new Bitmap(cheminImageTest);

		//    // Définir le comportement du substitut
		//    filtersSubstitut.Swap(inputBitmap).Returns(inputBitmap);

		//    // Appeler la méthode que vous voulez tester
		//    Bitmap resultBitmap = filtersManager.Swap(inputBitmap);

		//    // Vérifier que la méthode a été appelée avec le bon argument
		//    filtersSubstitut.Received().Swap(inputBitmap);

		//    // Vérifier que le résultat est le même que celui retourné par le substitut
		//    Assert.AreSame(inputBitmap, resultBitmap);
		//}
	}
}
