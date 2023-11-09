
namespace PictureEditor.BusinessLayer.Interfaces
{
	/// <summary>
	/// Interface for filters.
	/// </summary>
	public interface IFilters
	{
		/// <summary>
		/// Returns a Bitmap with black and white filter applied.
		/// </summary>
		/// <param name="bitmap"></param>
		Bitmap BlackWhite(Bitmap bitmap);

		/// <summary>
		/// Returns a Bitmap with magic mosaic filter applied.
		/// </summary>
		/// <param name="bitmap"></param>
		Bitmap MagicMosaic(Bitmap bitmap);

		/// <summary>
		/// Returns a Bitmap with swap filter applied.
		/// </summary>
		/// <param name="bitmap"></param>
		/// <returns></returns>
		Bitmap Swap(Bitmap bitmap);
	}
}
