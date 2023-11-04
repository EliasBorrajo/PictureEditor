using System;

namespace PictureEditor.ImageProcessing.EdgeDetector
{
    internal enum EdgeFinderAlgorithms
    {
        Laplacian3x3,
        Laplacian5x5,
        Sobel3x3Horizontal,
        Sobel3x3Vertical,
        Prewitt3x3Horizontal,
        Prewitt3x3Vertical,
        Kirsch3x3Horizontal,
        Kirsch3x3Vertical,
    }
}
