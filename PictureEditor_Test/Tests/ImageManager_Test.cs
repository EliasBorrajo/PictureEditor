using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using PictureEditor.BusinessLayer;
using PictureEditor.BusinessLayer.Interfaces;
using System.Drawing;
using System.Drawing.Imaging;

namespace PictureEditor_Test.Tests
{
	/// <summary>
	/// Test class for the ImageManager class.
	/// 
	/// The CODE_COVERING uses the real implementation of the IOutputInput interface.
	/// The SUBSTITUTES use a substitute (mock) of the IOutputInput interface.
	/// 
	/// Unit tests should be written using the CODE_COVERING approach.
	/// Test doubles (substitutes) should be used only when the real implementation of the interface is not available.
	/// </summary>
	[TestClass]
	public class ImageManager_Test
	{

		private IOutputInput? outputInput;
		private Image image = new Bitmap(10, 10); // Sample image;
		private string imageName = "test.png";
		private ImageFormat format = ImageFormat.Png;

		[TestInitialize]
		public void Initialize()
		{
			outputInput = Substitute.For<IOutputInput>();
		}


		[TestMethod]
		public void Save_ShouldThrow_NotImplementedException()
		{
			outputInput.Save(image, imageName, format).Throws<NotImplementedException>();

			var imageManager = new ImageManager();

			Assert.ThrowsException<NotImplementedException>(() => imageManager.Save(outputInput, image, imageName, format));
		}

		[TestMethod]
		public void Save_ShouldReturnTrueWhenImageIsSavedSuccessfully()
		{
			// Arrange
			outputInput.Save(image, imageName, format).Returns(true);
			var imageManager = new ImageManager();

			// Act
			bool result = imageManager.Save(outputInput, image, imageName, format);

			// Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Save_ShouldReturnFalseWhenError()
		{
			// Arrange
			outputInput.Save(image, imageName, format).Returns(false);
			var imageManager = new ImageManager();

			// Act
			bool result = imageManager.Save(outputInput, image, imageName, format);

			// Assert
			Assert.IsFalse(result);
		}





		[TestMethod]
		public void Load_ShouldThrow_NotImplementedException()
		{
			outputInput.Load(imageName).Throws<NotImplementedException>();

			var imageManager = new ImageManager();

			Assert.ThrowsException<NotImplementedException>(() => imageManager.Load(outputInput, imageName));
		}


		[TestMethod]
		public void Load_ShouldReturnImage()
		{
			outputInput.Load(imageName).Returns(image);

			var imageManager = new ImageManager();
			var result = imageManager.Load(outputInput, imageName);

			Assert.IsInstanceOfType<Image>(result, "L'objet n'est pas du type image.");
		}
	}

}


//// EXPLANATION OF SUBSTITUTES (MOCKS) AND HOW TO USE THEM
////[TestMethod]
////public void LoadImage_ShouldReturnImageFromFile_WhenFileDialogReturnsOKResult()
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

