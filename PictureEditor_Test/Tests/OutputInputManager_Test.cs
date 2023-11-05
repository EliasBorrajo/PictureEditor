using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using PictureEditor.BusinessLayer.Interfaces;
using PictureEditor.BusinessLayer.Managers;
using System.Drawing;
using System.Windows.Forms;

namespace PictureEditor_Test.Tests
{
	/// <summary>
	/// Test class for the OutputInputManager class.
	/// 
	/// The CODE_COVERING uses the real implementation of the IOutputInput interface.
	/// The SUBSTITUTES use a substitute (mock) of the IOutputInput interface.
	/// 
	/// Unit tests should be written using the CODE_COVERING approach.
	/// Test doubles (substitutes) should be used only when the real implementation of the interface is not available.
	/// </summary>
    [TestClass]
    public class OutputInputManager_Test
    {

		private IOutputInput? outputInputSubstitute;

		[TestInitialize]
		public void Initialize()
		{
			outputInputSubstitute = Substitute.For<IOutputInput>();
		}


		#region SaveImage_CODE_COVERING

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
			bool result = outputInputManager.SaveImageToFileSystem(image, saveFileDialog, format);

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
			bool result = outputInputManager.SaveImageToFileSystem(image, saveFileDialog, format);

			// Assert
			Assert.IsFalse(result);
		}

		#endregion


		#region LoadImage_CODE_COVERING
		[TestMethod]
		public void LoadImage_ShouldReturnValidImage_WhenFilePathIsValid()
		{
			// Arrange
			var outputInputManager = new OutputInputManager();
			string RessourcePath = Directory.GetCurrentDirectory() + "\\Ressources";
			string validFilePath = RessourcePath + "\\Moto.png";

			// Act
			Image result = null;
			Exception exception = null;
			try
			{
				result = outputInputManager.LoadImage(validFilePath);
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			// Assert
			Assert.IsNull(exception);
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(Image));
		}

		[TestMethod]
		public void LoadImage_ShouldThrowException_WhenFilePathIsInvalid_CodeCovering()
		{
			// Arrange
			var outputInputManager = new OutputInputManager();
			var invalidFilePath = "path/to/invalid/&&&/image.jpg";

			// Act & Assert
			Assert.ThrowsException<Exception>(() => outputInputManager.LoadImage(invalidFilePath));
		}
		#endregion

		#region LoadImage_SUBSTITUTES
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
		public void LoadImage_InvalidFilePath_ShouldThrowException()
		{
			// Arrange
			string invalidFilePath = "invalid/image/path.jpg";

			// Mock the LoadImage method to throw a file not found exception
			outputInputSubstitute.LoadImage(Arg.Is(invalidFilePath)).Returns(_ => { throw new System.IO.FileNotFoundException(); });

			// Act & Assert
			Assert.ThrowsException<System.IO.FileNotFoundException>(() => outputInputSubstitute.LoadImage(invalidFilePath));
		}

		#endregion



		


	}

}


// EXPLANATION OF SUBSTITUTES (MOCKS) AND HOW TO USE THEM
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

