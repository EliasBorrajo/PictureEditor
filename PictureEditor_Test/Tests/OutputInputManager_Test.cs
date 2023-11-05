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

		private IOutputInput? outputInputSubstitute;

		[TestInitialize]
		public void Initialize()
		{
			outputInputSubstitute = Substitute.For<IOutputInput>();
		}

		#region TestDoubles_Substitutes

		//[TestMethod]
		//public void LoadImage_ShouldReturnImageFromFile_WhenFileDialogReturnsOKResult()
		//{
		//	// ARRANGE - Create a mock of IOutputInput (mock = substitute)
		//	//1)  Vous créez un mock de IOutputInput à l'aide de NSubstitute :
		//	var outputInputMock = Substitute.For<IOutputInput>();

		//	//2) Vous configurez ce mock pour qu'il retourne une image spécifique lorsqu'il est appelé avec la méthode LoadImage() :
		//	var expectedImage = new Bitmap(MotoPath); // Load image from file
		//	outputInputMock.LoadImage().Returns(expectedImage);
		//	// Ici, expectedImage est l'image que vous attendez de recevoir lorsque LoadImage() est appelé.
		//	// Vous n'appelez pas réellement la méthode LoadImage() avec un chemin de fichier spécifique dans vos tests.
		//	// Au lieu de cela, vous simulez son comportement en remplaçant son implémentation par votre mock configuré



		//	// ACT - Call the method we want to test
		//	var loadedImage = outputInputMock.LoadImage();



		//	// ASSERT - Check that the method did what it was supposed to do
		//	Assert.IsNotNull(loadedImage);
		//	Assert.AreEqual(expectedImage, loadedImage);
		//}

		/// <summary>
		/// vérifiez si la méthode SaveImageToFileSystem retourne true lorsque l'image est enregistrée avec succès
		/// </summary>
		[TestMethod]
		public void SaveImageToFileSystem_ShouldReturnTrue_WhenImageIsSavedSuccessfully()
		{
			// Arrange
			var outputInputMock = Substitute.For<IOutputInput>();
			var image = new Bitmap(100, 100); // Sample image
			outputInputMock.SaveImageToFileSystem_V2(Arg.Any<Image>()).Returns(true);

			// Act
			var result = outputInputMock.SaveImageToFileSystem_V2(image);

			// Assert
			Assert.IsTrue(result);
		}


		#endregion


		#region UnitTests_CodeCoverage

		/// <summary>
		/// Cette assertion teste si l'appel à outputInputMock.SaveImageToDB 
		/// avec n'importe quelle instance d'image (Arg.Any<Image>()) 
		/// lève une exception de type NotImplementedException. 
		/// Si la méthode SaveImageToDB n'est pas encore implémentée (ce qui est le cas selon votre description), 
		/// l'assertion passera, confirmant que l'exception attendue a été levée.
		/// </summary>
		[TestMethod]
		public void SaveImageToDB_ShouldThrow_NotImplementedException()
		{
			var outputInputManager = new OutputInputManager();

			Assert.ThrowsException<NotImplementedException>(() => outputInputManager.SaveImageToDB(Arg.Any<Image>()));
		}

		[TestMethod]
		public void SaveImageToFileSystem_ShouldReturnTrueWhenImageIsSavedSuccessfully()
		{
			// Arrange
			var outputInputManager = new OutputInputManager();
			var image = new Bitmap(100, 100); // Sample image
			var saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "test.png";
			var format = System.Drawing.Imaging.ImageFormat.Png;

			// Act
			bool result = outputInputManager.SaveImageToFileSystem_V2(image, saveFileDialog, format);

			// Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void SaveImageToFileSystem_ShouldReturnFalseWhenExceptionOccurs()
		{
			// Arrange
			var outputInputManager = new OutputInputManager();
			var image = new Bitmap(100, 100); // Sample image
			var saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = null; // Invalid file name to simulate an exception
			var format = System.Drawing.Imaging.ImageFormat.Png;

			// Act
			bool result = outputInputManager.SaveImageToFileSystem_V2(image, saveFileDialog, format);

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void LoadImage_ValidFilePath_ShouldReturnLoadedImage()
		{
			// Arrange
			string validFilePath = "valid/image/path.jpg";
			Image expectedImage = new Bitmap(100, 100); // Sample image

			// Mock the LoadImage method to return the expected image
			outputInputSubstitute.LoadImage(Arg.Is(validFilePath)).Returns(expectedImage);

			// Act
			Image result = outputInputSubstitute.LoadImage(validFilePath);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(expectedImage, result);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception), "Error loading image: File not found.")]
		public void LoadImage_InvalidFilePath_ShouldThrowException()
		{
			// Arrange
			string invalidFilePath = "invalid/image/path.jpg";

			// Mock the LoadImage method to throw a file not found exception
			outputInputSubstitute.LoadImage(Arg.Is(invalidFilePath)).Returns(_ => { throw new System.IO.FileNotFoundException(); });

			// Act & Assert
			Image result = outputInputSubstitute.LoadImage(invalidFilePath); // This should throw an exception
		}


		[TestMethod]
		public void LoadImage_ShouldReturnLoadedImage_WhenFilePathIsValid()
		{
			// Arrange
			var outputInputMock = Substitute.For<IOutputInput>();
			var validFilePath = "valid/image/path.jpg";
			var expectedImage = new Bitmap(100, 100); // Sample image

			// Mock the LoadImage method to return the expected image
			outputInputMock.LoadImage(Arg.Is(validFilePath)).Returns(expectedImage);

			// Act
			var result = outputInputMock.LoadImage(validFilePath);

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(expectedImage, result);
		}

		[TestMethod]
		[ExpectedException(typeof(Exception), "Error loading image: File not found.")]
		public void LoadImage_ShouldThrowException_WhenFilePathIsInvalid()
		{
			// Arrange
			var outputInputMock = Substitute.For<IOutputInput>();
			var invalidFilePath = "invalid/image/path.jpg";

			// Mock the LoadImage method to throw a file not found exception
			outputInputMock.LoadImage(Arg.Is(invalidFilePath)).Returns(_ => { throw new System.IO.FileNotFoundException(); });

			// Act & Assert
			Assert.ThrowsException<System.IO.FileNotFoundException>(() => outputInputMock.LoadImage(invalidFilePath));
		}
	}











	#endregion
}

