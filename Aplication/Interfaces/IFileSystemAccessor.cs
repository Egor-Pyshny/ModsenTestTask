using Microsoft.AspNetCore.Http;

namespace Aplication.Interfaces
{
    public interface IFileSystemAccessor
    {
        string Save(IFormFile file, Guid eventId);

        void Delete(string path);

        string GetFile(string path);
    }
}
