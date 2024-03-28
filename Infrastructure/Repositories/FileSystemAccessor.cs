using Aplication.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;

namespace Infrastructure.Repositories
{
    public class FileSystemAccessor : IFileSystemAccessor
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IDistributedCache _cache;
        public FileSystemAccessor(IWebHostEnvironment hostEnvironment, IDistributedCache distributedCache)
        {
            _hostEnvironment = hostEnvironment;
            _cache = distributedCache;
        }

        public void Delete(string path)
        {
            string filePath = Path.Combine(_hostEnvironment.ContentRootPath, path);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                //_cache.Remove(filePath);
            }
        }

        private string GetFileBase64(string path) {
            return Convert.ToBase64String(File.ReadAllBytes(path));
        }

        public string GetFile(string path)
        {
            string file = /*_cache.GetString(path) ??*/ Convert.ToBase64String(File.ReadAllBytes(path));
            return file;
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
           // _cache.SetString(filePath, GetFileBase64(filePath));
            return $"UserData\\{eventId}\\{newFileName}";
        }
    }
}
