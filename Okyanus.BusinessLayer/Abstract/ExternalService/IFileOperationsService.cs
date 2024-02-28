using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.BusinessLayer.Abstract.ExternalService
{
    public interface IFileOperationsService
    {
        public Task<(string fileName, string filePath)> SaveFileAsync(IFormFile file, string path);
        public bool DeleteFile(string filePath);
    }
}
