using System.Text.RegularExpressions;

namespace OkyanusWebUI.Service
{
    public class FileOperationService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileOperationService(IWebHostEnvironment environment)
        {
            _webHostEnvironment = environment;
        }

        public async Task<(string fileName, string filePath)> SaveFileAsync(IFormFile file, string path)
        {
            try
            {
                var rootPath = _webHostEnvironment.WebRootPath;
                var fullPath = Path.Combine(rootPath, path);
                var fileName = GetUniqueFileName(file.FileName);
                var filePath = Path.Combine(fullPath, fileName);
                var databasePath = "/"+path + fileName;

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
                var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, filePathAndName);

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
