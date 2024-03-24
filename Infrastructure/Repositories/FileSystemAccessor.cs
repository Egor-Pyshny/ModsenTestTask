using Aplication.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Repositories
{
    public class FileSystemAccessor : IFileSystemAccessor
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public FileSystemAccessor(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public void Delete(string path)
        {
            string filePath = Path.Combine(_hostEnvironment.ContentRootPath, path);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static string GetFileBase64(string path) {
            return Convert.ToBase64String(File.ReadAllBytes(path));
        }

        public string Save(IFormFile file, Guid eventId)
        {
            string uploadDir = Path.Combine(_hostEnvironment.ContentRootPath, $"UserData\\{eventId}");
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file.FileName);
            string fileExtension = Path.GetExtension(file.FileName);
            string newFileName = $"{fileNameWithoutExtension}_{Path.GetRandomFileName()}{fileExtension}";
            string filePath = Path.Combine(uploadDir, newFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return $"UserData\\{eventId}\\{newFileName}";
        }
    }
}
