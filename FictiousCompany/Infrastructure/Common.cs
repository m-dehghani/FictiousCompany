using FictiousCompany.Infrastructure.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Infrastructure
{
    public sealed class Common
    {
        private static Common _instance;
        public static Common Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Common();

                return _instance;
            }
        }
        public DoneResult GetExceptionResult(Exception ex)
        {
            return new DoneResult(ResultType.Error, ResultType.Error.ToDescription(), GetFullErrorMessage(ex));
        }
        public string GetFullErrorMessage(Exception ex) => $"Message: {ex.Message}, " +
           $"StackTrace: {ex.StackTrace}, " +
           $"HelpLink: {ex.HelpLink}, " +
           $"Source: {ex.Source}, " +
           $"InnerExceptionMessage: {ex.InnerException?.Message}";

        public string SaveBase64Image(string imageStr, string imageName, string path)
        {
            var filePath = Path.Combine($"{Startup.wwwRootFolder}/images", path);
            CreateDirectory(filePath);
            string imgFilePath = Path.Combine(filePath, imageName);
            imageName = GetUniqueFileName(imgFilePath);
            imgFilePath = Path.Combine(filePath, imageName);

            byte[] imageBytes = Convert.FromBase64String(imageStr);
            File.WriteAllBytes(imgFilePath, imageBytes);

            return imageName;
        }

        #region File & Directory

        public string GetUniqueFileName(string absolutePath)
        {
            var fileName = Path.GetFileName(absolutePath);
            var extension = Path.GetExtension(fileName);
            fileName = Path.GetFileNameWithoutExtension(fileName);
            var directoryName = Path.GetDirectoryName(absolutePath);

            var suffix = "";
            var i = 1;
            while (File.Exists($"{directoryName}/{fileName}{suffix}{extension}"))
            {
                suffix = $"-{i}";
                i++;
            }

            return $"{fileName}{suffix}{extension}";
        }

        public void RemoveFile(string absPath)
        {
            if (File.Exists(absPath))
                File.Delete(absPath);
        }

        public void CreateDirectory(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
                Directory.CreateDirectory(absolutePath);
        }
        #endregion
    }

}
