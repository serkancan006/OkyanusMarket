using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Okyanus.BusinessLayer.Abstract.ExternalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Okyanus.BusinessLayer.Concrete.ExternalService
{
    public class FileOperationsManager : IFileOperationsService
    {
        private readonly IWebHostEnvironment _environment;
        public FileOperationsManager(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<(string fileName, string filePath)> SaveFileAsync(IFormFile file, string path)
        {
            try
            {
                var rootPath = _environment.WebRootPath;
                var fullPath = Path.Combine(rootPath, path);
                var fileName = GetUniqueFileName(file.FileName);
                var filePath = Path.Combine(fullPath, fileName);
                var databasePath = path + fileName;

                if (!Directory.Exists(fullPath))
                    Directory.CreateDirectory(fullPath);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return (fileName, databasePath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Dosya kaydetme hatası: {ex.Message}");
            }
        }

        public bool DeleteFile(string filePathAndName)
        {
            try
            {
                var fullPath = Path.Combine(_environment.WebRootPath, filePathAndName);

                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Dosya silme hatası: {ex.Message}");
            }
        }



        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            string fileExtension = Path.GetExtension(fileName);
            string pureFileName = Path.GetFileNameWithoutExtension(fileName);

            pureFileName = Regex.Replace(pureFileName, "[^a-zA-Z0-9]", "-");

            string newFileName = pureFileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + fileExtension;
            return newFileName;
        }

    }
}
