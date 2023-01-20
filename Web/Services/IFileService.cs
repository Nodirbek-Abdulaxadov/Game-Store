namespace Web.Services
{
    public interface IFileService
    {
        string UploadImage(IFormFile file);
        void DeleteImage(string path);
    }
}
