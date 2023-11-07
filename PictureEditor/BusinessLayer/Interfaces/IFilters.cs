
namespace PictureEditor.BusinessLayer.Interfaces
{
    public interface IFilters
    {
        Bitmap BlackWhite (Bitmap bitmap);
        Bitmap MagicMosaic (Bitmap bitmap);
        Bitmap Swap (Bitmap bitmap);
    }
}
