using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PictureEditor.BusinessLayer.Interfaces;
using PictureEditor.BusinessLayer.Managers;
using PresentationLayer.ImageProcessing;
using PresentationLayer.ImageProcessing.EdgeDetector;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace PictureEditor
{
    /// <summary>
    ///  Controller for the Picture Editor Program GUI 
    /// </summary>
    public partial class EditorGUI : Form
    {
        // A T T R I B U T E S
        private Bitmap currentBitmap;               // Bitmap currently being displayed in the picture box
        private Image originalImage;                 // Original image loaded into the picture box (used for resetting)
        private bool edgeDetectionApplied;      // Whether the edge detection has been applied to the image. Can only be applied once.
        private IOutputInput IOutputInput;          // OutputInput object to handle the input and output of images
        private IEdgeDetection IEdgeDetection;  // EdgeDetection object to handle the edge detection of images
        private IFilters IFilters;                               // Filters object to handle the filters of images

        // C  O N S T R U C T O R
        public EditorGUI()
        {
            InitializeComponent();

            // Inject the dependencies
            IOutputInput = new OutputInputManager();
            IEdgeDetection = new EdgeDetectionManager();
            IFilters = new FiltersManager();
        }

        // M E T H O D S
        /// <summary>
        ///  Form load event handler, acts as the constructor for the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            // 1) Load the original image into the picture box (and keep a reference to it)
            originalImage = pictureBox.Image;
            SetPictureBoxImage(originalImage);

            // 2) Disable the Edge Detection group box (until the filters have been applied)
            //groupBoxEdgesDetection.Enabled = false;
            edgeDetectionApplied = false;

            // 3) Populate the filters list boxes with the available filters
            PopulateFiltersListBoxes();
        }

        #region initialisation
        /// <summary>
        /// Populate the filters list boxes with the available filters 
        /// </summary>
        private void PopulateFiltersListBoxes()
        {
            // Fill listBox_XFilter & listBox_YFilter with enum values
            foreach (EdgeFinderAlgorithms algorithm in Enum.GetValues(typeof(EdgeFinderAlgorithms)))
            {
                listBox_X_Algorithms.Items.Add(algorithm);
                listBox_Y_Algorithms.Items.Add(algorithm);
            }
        }

        /// <summary>
        ///  Set the picture box image to the given image (disposing the previous image in the picture box) 
        /// </summary>
        /// <param name="image"></param>
        private void SetPictureBoxImage(Image image)
        {
            if (pictureBox.Image != originalImage)  // Ensure we're not disposing the original image
            {
                pictureBox.Image?.Dispose();
            }
            currentBitmap = new Bitmap(image, pictureBox.Size);
            pictureBox.Image = currentBitmap;
        }

        #endregion


        #region GroupBox_PictureData_LoadSave

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (var loadedImage = IOutputInput.LoadImage())
            {
                if (loadedImage != null)
                {
                    SetPictureBoxImage(loadedImage);
                    originalImage = pictureBox.Image;
                }
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            IOutputInput.SaveImage(pictureBox.Image);
        }

        #endregion


        #region GroupBox_Filters


        /// <summary>
        /// Apply the Black and White filter to the image and display the result in the picture box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilterBlackWhite_Click(object sender, EventArgs e)
        {
            using (var newBitmap = IFilters.BlackWhite(new Bitmap(pictureBox.Image)))
            {
                SetPictureBoxImage(newBitmap);
            }
        }

        private void btnFilterSwap_Click(object sender, EventArgs e)
        {
            using (var newBitmap = IFilters.Swap(new Bitmap(pictureBox.Image)))
            {
                SetPictureBoxImage(newBitmap);
            }
        }

        private void btnFilterMagic_Click(object sender, EventArgs e)
        {
            using (var newBitmap = IFilters.MagicMosaic(new Bitmap(pictureBox.Image)))
            {
                SetPictureBoxImage(newBitmap);
            }
        }



        /// <summary>
        /// Apply the selected filters X & Y to the image and display the result in the picture box.
        /// Enable now the Edge Detection group box to be used.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApplyEdgeDetector_Click(object sender, EventArgs e)
        {
            //bool filtersApplied = false; // To track whether filters have been applied
            if (edgeDetectionApplied)
            {
                MessageBox.Show("Edge detection has already been applied to this image.");
                return;
            }

            // Check that an image has been loaded 
            if (pictureBox.Image == null ||
                currentBitmap == null)
            {
                MessageBox.Show("You must load an image");
                return;
            }

            // Check that X and Y filters have been selected
            if (listBox_X_Algorithms.SelectedItem != null &&
                listBox_Y_Algorithms.SelectedItem != null)
            {
                // 1) Get the selected filters names and matrices 
                // Get the algo filters name from the list boxes
                string selectedXFilter = listBox_X_Algorithms.SelectedItem.ToString();
                string selectedYFilter = listBox_Y_Algorithms.SelectedItem.ToString();


                // Get the algo filters matrices with the selected names
                double[,] xFilterMatrix = IEdgeDetection.GetFilterMatrix(selectedXFilter);
                double[,] yFilterMatrix = IEdgeDetection.GetFilterMatrix(selectedYFilter);

                if (xFilterMatrix == null || yFilterMatrix == null)
                {
                    MessageBox.Show("Invalid filter names");
                    return;
                }

                try
                {
                    // Verify the checkbox value, and apply the filter accordingly (X, Y or the same)
                    if (checkBox_SameXY.Checked)
                    {
                        using (var tempBitmap = new Bitmap(currentBitmap))
                        {
                            currentBitmap = IEdgeDetection.detectPictureEdges(tempBitmap, xFilterMatrix, xFilterMatrix);
                        }
                    }
                    else
                    {
                        using (var tempBitmap = new Bitmap(currentBitmap))
                        {
                            currentBitmap = IEdgeDetection.detectPictureEdges(tempBitmap, xFilterMatrix, yFilterMatrix);
                        }
                    }

                    SetPictureBoxImage(currentBitmap);
                    edgeDetectionApplied = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an algorithm for X and Y axis.");
            }
        }

        /// <summary>
        /// If checked, disble the Y filter list box and set the Y filter to the same as the X filter.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_SameXY_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_SameXY.Checked)
            {
                listBox_Y_Algorithms.Enabled = false;
                listBox_Y_Algorithms.SelectedItem = listBox_X_Algorithms.SelectedItem;
            }
            else
            {
                listBox_Y_Algorithms.Enabled = true;
            }
        }

        #endregion

        /// <summary>
        /// Cancel the selected filters and edge detector, and display the original image in the picture box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelFilters_MouseClick(object sender, MouseEventArgs e)
        {
            //pictureBox.Image = originalImage;
            SetPictureBoxImage(originalImage);

            edgeDetectionApplied = false;
            //groupBoxEdgesDetection.Enabled = false;
        }


    }
}