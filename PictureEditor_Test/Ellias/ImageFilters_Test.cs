using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using PictureEditor;
using PictureEditor.ImageProcessing;
using PictureEditor.ImageProcessing.EdgeDetector;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PictureEditor_Test.Ellias
{
    [TestClass]
    public class ImageFilters_Test
    {

        public static string ResourcesPath = Directory.GetCurrentDirectory() + "\\Ressources";
        public static string OriginalPath = ResourcesPath + "\\original.bmp";
        public static string HellPath = ResourcesPath + "\\FilterHell.bmp";
        public static string BlackWhitePath = ResourcesPath + "\\BlackAndWhite.bmp";



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
        /// Test the filter "Hell" with the original image. 
        /// The filter "Hell" is applied to the original image and then compared pixel by pixel with the image already modified.
        /// </summary>
        [TestMethod]
        public void TestFilterHell()
        {
            // 1) Load images
            Bitmap hellFilterApplied = new Bitmap(HellPath);         // 1) Load the image with the filter already applied
            Bitmap imageTest = new Bitmap(OriginalPath);    // 2) Load the original image to modify and then compare with the other image

            // 2) Apply the filter
            imageTest = ImageFilters.ApplyFilter(imageTest, 1, 1, 10, 15);

            // 3) Compare the 2 images pixel by pixel to see if they are the same, there is a tolerance of 1 RGB value for each pixel
            int tolerance = 1;
            Assert.IsTrue(util.CompareImages(hellFilterApplied, imageTest, tolerance));
        }

        /// <summary>
        /// Test the filter "BlackWhite" with the original image. 
        /// The filter "BlackWhite" is applied to the original image and then compared pixel by pixel with the image already modified.
        /// </summary>
        [TestMethod]
        public void TestFilterBlackAndWhite()
        {
            // 1) Load images
            Bitmap bwFilterApplied = new Bitmap(BlackWhitePath);         // 1) Load the image with the filter already applied
            Bitmap imageTest = new Bitmap(OriginalPath);                        // 2) Load the original image to modify and then compare with the other image

            // 2) Apply the filter
            imageTest = ImageFilters.BlackWhite(imageTest);

            // 3) Compare the 2 images pixel by pixel to see if they are the same, there is a tolerance of 1 RGB value for each pixel
            int tolerance = 1;
            Assert.IsTrue(util.CompareImages(bwFilterApplied, imageTest, tolerance));
        }




    }
}