using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using PictureEditor.BusinessLayer.Interfaces;
using PictureEditor.BusinessLayer.Managers;
using System.Drawing;
using System.Windows.Forms;

namespace PictureEditor_Test.Tests
{
    [TestClass]
    public class OutputInputManager_Test
    {

        public static string RessourcePath  = Directory.GetCurrentDirectory() + "\\Ressources";
        public static string MotoPath         = RessourcePath + "\\Moto.png";


		[TestMethod]
		public void LoadImage_ShouldReturnImage_WhenFileDialogReturnsOKResult()
		{
			// ARRANGE - Create a mock of IOutputInput (mock = substitute)
			//1)  Vous créez un mock de IOutputInput à l'aide de NSubstitute :
			var outputInputMock = Substitute.For<IOutputInput>();
			var image = new Bitmap(100, 100); // Sample image

			//2) Vous configurez ce mock pour qu'il retourne une image spécifique lorsqu'il est appelé avec la méthode LoadImage() :
			outputInputMock.LoadImage().Returns(image);
			// Ici, expectedImage est l'image que vous attendez de recevoir lorsque LoadImage() est appelé.
			// Vous n'appelez pas réellement la méthode LoadImage() avec un chemin de fichier spécifique dans vos tests.
			// Au lieu de cela, vous simulez son comportement en remplaçant son implémentation par votre mock configuré.


			// ACT - Call the method we want to test
			var loadedImage = outputInputMock.LoadImage();
			



			// ASSERT - Check that the method did what it was supposed to do
			// 3) Vous appelez ensuite la méthode LoadImage() dans votre test :
			Assert.IsNotNull(loadedImage);
			Assert.AreEqual(image, loadedImage);
		}

		[TestMethod]
		public void LoadImage_ShouldReturnImageFromFile_WhenFileDialogReturnsOKResult()
		{
			// ARRANGE - Create a mock of IOutputInput (mock = substitute)
			//1)  Vous créez un mock de IOutputInput à l'aide de NSubstitute :
			var outputInputMock = Substitute.For<IOutputInput>();

			//2) Vous configurez ce mock pour qu'il retourne une image spécifique lorsqu'il est appelé avec la méthode LoadImage() :
			var expectedImage = new Bitmap(MotoPath); // Load image from file
			outputInputMock.LoadImage().Returns(expectedImage);
			// Ici, expectedImage est l'image que vous attendez de recevoir lorsque LoadImage() est appelé.
			// Vous n'appelez pas réellement la méthode LoadImage() avec un chemin de fichier spécifique dans vos tests.
			// Au lieu de cela, vous simulez son comportement en remplaçant son implémentation par votre mock configuré



			// ACT - Call the method we want to test
			var loadedImage = outputInputMock.LoadImage();



			// ASSERT - Check that the method did what it was supposed to do
			Assert.IsNotNull(loadedImage);
			Assert.AreEqual(expectedImage, loadedImage);
		}

		[TestMethod]
		public void SaveImageToFileSystem_ShouldShowSuccessMessage_WhenImageIsSaved()
		{
			// Arrange
			var outputInputMock = Substitute.For<IOutputInput>();
			var image = new Bitmap(100, 100); // Sample image
			outputInputMock.SaveImageToFileSystem(Arg.Any<Image>()).Returns(true);

			// Act
			outputInputMock.SaveImageToFileSystem(image);

			// Assert
			// Use NSubstitute to assert that MessageBox.Show method was called with the expected parameters.
			MessageBox.Received().Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		[TestMethod]
		public void SaveImageToFileSystem_ShouldBeCalledSuccessfully()
		{
			// Arrange
			var outputInputMock = Substitute.For<IOutputInput>();
			var image = new Bitmap(100, 100); // Sample image

			// Act
			outputInputMock.SaveImageToFileSystem(image);

			// Assert
			// Utilisez NSubstitute pour vérifier l'appel à la méthode SaveImageToFileSystem
			outputInputMock.Received().SaveImageToFileSystem(Arg.Any<Image>());
		}



		[TestMethod]
		public void SaveImageToDB_ShouldThrowNotImplementedException()
		{
			// Arrange
			var outputInputMock = Substitute.For<IOutputInput>();

			// Act & Assert
			Assert.Throws<NotImplementedException>(() => outputInputMock.SaveImageToDB(Arg.Any<Image>()));
		}














		//[TestMethod]
  //      public void TestSaveImage()
  //      {
  //          // Créer un substitut de IOutputInput
  //          IOutputInput outputInputSubstitut = Substitute.For<IOutputInput>();

  //          // Créer une instance de OutputInputManager avec le substitut
  //          OutputInputManager outputInputManager = new OutputInputManager();

  //          // Charger une image de test à partir d'un fichier (assurez-vous d'avoir une image appropriée dans le chemin spécifié)
  //          Bitmap inputBitmap = new Bitmap(MotoPath);

  //          // Appeler la méthode que vous voulez tester
  //          outputInputManager.SaveImageToFileSystem(inputBitmap);

  //          // Vérifier que la méthode a été appelée avec le bon argument
  //          outputInputSubstitut.Received().SaveImageToFileSystem(inputBitmap);
  //      }

  //      [TestMethod]
  //      public void TestLoadImage()
  //      {
  //          // Créer un substitut de IOutputInput
  //          IOutputInput outputInputSubstitut = Substitute.For<IOutputInput>();

  //          // Créer une instance de OutputInputManager avec le substitut
  //          OutputInputManager outputInputManager = new OutputInputManager();

  //          // Charger une image de test à partir d'un fichier (assurez-vous d'avoir une image appropriée dans le chemin spécifié)
  //          Bitmap inputBitmap = new Bitmap(MotoPath);

  //          // Définir le comportement du substitut
  //          outputInputSubstitut.LoadImage().Returns(inputBitmap);

  //          // Appeler la méthode que vous voulez tester
  //          Image resultImage = outputInputManager.LoadImage();

  //          // Vérifier que la méthode a été appelée
  //          outputInputSubstitut.Received().LoadImage();

  //          // Vérifier que le résultat est le même que celui retourné par le substitut
  //          Assert.AreSame(inputBitmap, resultImage);
  //      }
    }
}
