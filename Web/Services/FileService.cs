namespace Web.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;

        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string UploadImage(IFormFile file)
        {
            string uniqueName = string.Empty;
            if (file != null)
            {
                string uplodFolder = Path.Combine(_environment.WebRootPath, "images");
                uniqueName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uplodFolder, uniqueName);
                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                file.CopyTo(fileStream);
                fileStream.Close();
            }

            return "images/" + uniqueName;
        }

        public void DeleteImage(string fileName)
        {
            if (fileName != null && fileName != "images/user.png")
            {
                string uplodFolder = _environment.WebRootPath;
                string filePath = Path.Combine(uplodFolder, fileName);
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
            }
        }
    }
}
