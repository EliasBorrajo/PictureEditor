namespace PictureEditor
{
    /// <summary>
    /// Application GUI for Picture Editor Program
    /// </summary>
    partial class EditorGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorGUI));
            pictureBox = new PictureBox();
            btnLoadImage = new Button();
            btnFilterMagic = new Button();
            btnSaveImage = new Button();
            btnFilterBlackWhite = new Button();
            groupBoxPictureData = new GroupBox();
            groupBoxFilters = new GroupBox();
            btnFilterSwap = new Button();
            groupBoxEdgesDetection = new GroupBox();
            checkBox_SameXY = new CheckBox();
            listBox_Y_Algorithms = new ListBox();
            listBox_X_Algorithms = new ListBox();
            btnApplyEdgeDetector = new Button();
            btnCancelFilters = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            groupBoxPictureData.SuspendLayout();
            groupBoxFilters.SuspendLayout();
            groupBoxEdgesDetection.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            pictureBox.Image = (Image)resources.GetObject("pictureBox.Image");
            pictureBox.Location = new Point(34, 77);
            pictureBox.Margin = new Padding(10, 8, 10, 8);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1561, 1347);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(20, 109);
            btnLoadImage.Margin = new Padding(10, 8, 10, 8);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(340, 96);
            btnLoadImage.TabIndex = 8;
            btnLoadImage.Text = "Load Image";
            btnLoadImage.UseVisualStyleBackColor = true;
            btnLoadImage.Click += btnLoadImage_Click;
            // 
            // btnFilterMagic
            // 
            btnFilterMagic.Location = new Point(20, 75);
            btnFilterMagic.Margin = new Padding(10, 8, 10, 8);
            btnFilterMagic.Name = "btnFilterMagic";
            btnFilterMagic.Size = new Size(340, 96);
            btnFilterMagic.TabIndex = 33;
            btnFilterMagic.Text = "Magic Mosaic";
            btnFilterMagic.UseVisualStyleBackColor = true;
            btnFilterMagic.Click += btnFilterMagic_Click;
            // 
            // btnSaveImage
            // 
            btnSaveImage.Location = new Point(391, 109);
            btnSaveImage.Margin = new Padding(10, 8, 10, 8);
            btnSaveImage.Name = "btnSaveImage";
            btnSaveImage.Size = new Size(340, 96);
            btnSaveImage.TabIndex = 36;
            btnSaveImage.Text = "Save Image";
            btnSaveImage.UseVisualStyleBackColor = true;
            btnSaveImage.Click += btnSaveImage_Click;
            // 
            // btnFilterBlackWhite
            // 
            btnFilterBlackWhite.Location = new Point(391, 75);
            btnFilterBlackWhite.Margin = new Padding(10, 8, 10, 8);
            btnFilterBlackWhite.Name = "btnFilterBlackWhite";
            btnFilterBlackWhite.Size = new Size(340, 96);
            btnFilterBlackWhite.TabIndex = 39;
            btnFilterBlackWhite.Text = "Black and White";
            btnFilterBlackWhite.UseVisualStyleBackColor = true;
            btnFilterBlackWhite.Click += btnFilterBlackWhite_Click;
            // 
            // groupBoxPictureData
            // 
            groupBoxPictureData.Controls.Add(btnLoadImage);
            groupBoxPictureData.Controls.Add(btnSaveImage);
            groupBoxPictureData.Location = new Point(1673, 77);
            groupBoxPictureData.Margin = new Padding(10, 8, 10, 8);
            groupBoxPictureData.Name = "groupBoxPictureData";
            groupBoxPictureData.Padding = new Padding(10, 8, 10, 8);
            groupBoxPictureData.Size = new Size(751, 314);
            groupBoxPictureData.TabIndex = 40;
            groupBoxPictureData.TabStop = false;
            groupBoxPictureData.Text = "Picture";
            // 
            // groupBoxFilters
            // 
            groupBoxFilters.Controls.Add(btnFilterSwap);
            groupBoxFilters.Controls.Add(btnFilterMagic);
            groupBoxFilters.Controls.Add(btnFilterBlackWhite);
            groupBoxFilters.Location = new Point(1673, 407);
            groupBoxFilters.Margin = new Padding(10, 8, 10, 8);
            groupBoxFilters.Name = "groupBoxFilters";
            groupBoxFilters.Padding = new Padding(10, 8, 10, 8);
            groupBoxFilters.Size = new Size(751, 291);
            groupBoxFilters.TabIndex = 41;
            groupBoxFilters.TabStop = false;
            groupBoxFilters.Text = "Filters";
            // 
            // btnFilterSwap
            // 
            btnFilterSwap.Location = new Point(202, 187);
            btnFilterSwap.Margin = new Padding(10, 8, 10, 8);
            btnFilterSwap.Name = "btnFilterSwap";
            btnFilterSwap.Size = new Size(340, 96);
            btnFilterSwap.TabIndex = 40;
            btnFilterSwap.Text = "Swap";
            btnFilterSwap.UseVisualStyleBackColor = true;
            btnFilterSwap.Click += btnFilterSwap_Click;
            // 
            // groupBoxEdgesDetection
            // 
            groupBoxEdgesDetection.Controls.Add(checkBox_SameXY);
            groupBoxEdgesDetection.Controls.Add(listBox_Y_Algorithms);
            groupBoxEdgesDetection.Controls.Add(listBox_X_Algorithms);
            groupBoxEdgesDetection.Controls.Add(btnApplyEdgeDetector);
            groupBoxEdgesDetection.Location = new Point(1673, 714);
            groupBoxEdgesDetection.Margin = new Padding(10, 8, 10, 8);
            groupBoxEdgesDetection.Name = "groupBoxEdgesDetection";
            groupBoxEdgesDetection.Padding = new Padding(10, 8, 10, 8);
            groupBoxEdgesDetection.Size = new Size(751, 570);
            groupBoxEdgesDetection.TabIndex = 42;
            groupBoxEdgesDetection.TabStop = false;
            groupBoxEdgesDetection.Text = "Edges detector";
            // 
            // checkBox_SameXY
            // 
            checkBox_SameXY.AutoSize = true;
            checkBox_SameXY.Location = new Point(20, 51);
            checkBox_SameXY.Name = "checkBox_SameXY";
            checkBox_SameXY.Size = new Size(501, 45);
            checkBox_SameXY.TabIndex = 46;
            checkBox_SameXY.Text = "Apply same algorithm for X and Y";
            checkBox_SameXY.UseVisualStyleBackColor = true;
            checkBox_SameXY.CheckedChanged += checkBox_SameXY_CheckedChanged;
            // 
            // listBox_Y_Algorithms
            // 
            listBox_Y_Algorithms.FormattingEnabled = true;
            listBox_Y_Algorithms.ItemHeight = 41;
            listBox_Y_Algorithms.Location = new Point(391, 109);
            listBox_Y_Algorithms.Name = "listBox_Y_Algorithms";
            listBox_Y_Algorithms.Size = new Size(340, 291);
            listBox_Y_Algorithms.TabIndex = 45;
            // 
            // listBox_X_Algorithms
            // 
            listBox_X_Algorithms.FormattingEnabled = true;
            listBox_X_Algorithms.ItemHeight = 41;
            listBox_X_Algorithms.Location = new Point(20, 109);
            listBox_X_Algorithms.Name = "listBox_X_Algorithms";
            listBox_X_Algorithms.Size = new Size(340, 291);
            listBox_X_Algorithms.TabIndex = 44;
            // 
            // btnApplyEdgeDetector
            // 
            btnApplyEdgeDetector.Location = new Point(20, 474);
            btnApplyEdgeDetector.Margin = new Padding(10, 8, 10, 8);
            btnApplyEdgeDetector.Name = "btnApplyEdgeDetector";
            btnApplyEdgeDetector.Size = new Size(711, 96);
            btnApplyEdgeDetector.TabIndex = 43;
            btnApplyEdgeDetector.Text = "Apply";
            btnApplyEdgeDetector.UseVisualStyleBackColor = true;
            btnApplyEdgeDetector.Click += btnApplyEdgeDetector_Click;
            // 
            // btnCancelFilters
            // 
            btnCancelFilters.Location = new Point(1673, 1300);
            btnCancelFilters.Margin = new Padding(10, 8, 10, 8);
            btnCancelFilters.Name = "btnCancelFilters";
            btnCancelFilters.Size = new Size(751, 124);
            btnCancelFilters.TabIndex = 43;
            btnCancelFilters.Text = "Cancel";
            btnCancelFilters.UseVisualStyleBackColor = true;
            btnCancelFilters.MouseClick += btnCancelFilters_MouseClick;
            // 
            // EditorGUI
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(2460, 1481);
            Controls.Add(btnCancelFilters);
            Controls.Add(groupBoxEdgesDetection);
            Controls.Add(groupBoxFilters);
            Controls.Add(groupBoxPictureData);
            Controls.Add(pictureBox);
            Margin = new Padding(10, 8, 10, 8);
            Name = "EditorGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PictureEditor";
            Load += Form_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            groupBoxPictureData.ResumeLayout(false);
            groupBoxFilters.ResumeLayout(false);
            groupBoxEdgesDetection.ResumeLayout(false);
            groupBoxEdgesDetection.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox;
        private Button btnLoadImage;
        private Button btnFilterMagic;
        private Button btnSaveImage;
        private Button btnFilterBlackWhite;
        private GroupBox groupBoxPictureData;
        private GroupBox groupBoxFilters;
        private GroupBox groupBoxEdgesDetection;
        private ListBox listBox_Y_Algorithms;
        private ListBox listBox_X_Algorithms;
        private Button btnApplyEdgeDetector;
        private CheckBox checkBox_SameXY;
        private Button btnCancelFilters;
        private Button btnFilterSwap;
    }
}