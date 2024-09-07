using Microsoft.AspNetCore.Http;

namespace Okyanus.BusinessLayer.Abstract.ExternalService
{
    public interface IFileOperationsService
    {
        public Task<(string fileName, string filePath)> SaveFileAsync(IFormFile file, string path);
        public bool DeleteFile(string filePath);
    }
}
