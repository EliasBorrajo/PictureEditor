using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using PictureEditor.BusinessLayer.Interfaces;
using PictureEditor.BusinessLayer.Managers;
using System.Drawing;

namespace PictureEditor_Test.Tests
{
    [TestClass]
    public class OutputInputManager_Test
    {

        public static string RessourcePath = Directory.GetCurrentDirectory() + "\\Ressources";
        public static string cheminImageTest = RessourcePath + "\\Moto.png";

        [TestMethod]
        public void TestSaveImage()
        {
            // Créer un substitut de IOutputInput
            IOutputInput outputInputSubstitut = Substitute.For<IOutputInput>();

            // Créer une instance de OutputInputManager avec le substitut
            OutputInputManager outputInputManager = new OutputInputManager();

            // Charger une image de test à partir d'un fichier (assurez-vous d'avoir une image appropriée dans le chemin spécifié)
            Bitmap inputBitmap = new Bitmap(cheminImageTest);

            // Appeler la méthode que vous voulez tester
            outputInputManager.SaveImage(inputBitmap);

            // Vérifier que la méthode a été appelée avec le bon argument
            outputInputSubstitut.Received().SaveImage(inputBitmap);
        }

        [TestMethod]
        public void TestLoadImage()
        {
            // Créer un substitut de IOutputInput
            IOutputInput outputInputSubstitut = Substitute.For<IOutputInput>();

            // Créer une instance de OutputInputManager avec le substitut
            OutputInputManager outputInputManager = new OutputInputManager();

            // Charger une image de test à partir d'un fichier (assurez-vous d'avoir une image appropriée dans le chemin spécifié)
            Bitmap inputBitmap = new Bitmap(cheminImageTest);

            // Définir le comportement du substitut
            outputInputSubstitut.LoadImage().Returns(inputBitmap);

            // Appeler la méthode que vous voulez tester
            Image resultImage = outputInputManager.LoadImage();

            // Vérifier que la méthode a été appelée
            outputInputSubstitut.Received().LoadImage();

            // Vérifier que le résultat est le même que celui retourné par le substitut
            Assert.AreSame(inputBitmap, resultImage);
        }
    }
}
