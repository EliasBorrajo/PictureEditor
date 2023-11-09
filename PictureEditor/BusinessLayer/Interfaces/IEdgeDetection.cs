
namespace PictureEditor.BusinessLayer.Interfaces
{
	/// <summary>
	/// Interface for edge detection algorithms.
	/// </summary>
	public interface IEdgeDetection
	{
		/// <summary>
		/// Returns a matrix for the specified filter.
		/// </summary>
		/// <param name="filterName"></param>
		double[,] GetFilterMatrix(string filterName);

		/// <summary>
		/// Returns a list of available filters.
		/// </summary>
		/// <returns></returns>
		IEnumerable<string> GetAvailableAlgorithms();

		/// <summary>
		/// Edge detection using specified filters and matrix convolution. 
		/// </summary>
		/// <param name="inputCurrentBitmap"></param>
		/// <param name="xFilterMatrix"></param>
		/// <param name="yFilterMatrix"></param>
		/// <returns>A bitmap with detected edges applied.</returns>
		Bitmap detectPictureEdges(Bitmap inputCurrentBitmap, double[,] xFilterMatrix, double[,] yFilterMatrix);

	}
}
