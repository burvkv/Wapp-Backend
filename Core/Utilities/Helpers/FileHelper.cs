using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace Core.Utilities.Helpers
{
    public class FileHelper : IFileHelper
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        private static string _folderName = "\\images\\";
        public void CheckDirectoryExist(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public IResult CheckFileExist(IFormFile file)
        {

            if (file == null && file.Length == 0)
            {
                return new ErrorResult("En az bir dosya yüklemelisiniz.");

            }


            return new SuccessResult();


        }

        public IResult CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".jpg" && type != ".png" && type != ".jfif")
            {
                return new ErrorResult("Lütfen bir resim dosyası seçiniz.");
            }
            return new SuccessResult();
        }

        public void CreateFile(string directory, IFormFile file)
        {
            using (FileStream fileStream = File.Create(directory))
            {

                file.CopyTo(fileStream);
                fileStream.Flush();


            }
        }

        public IResult Remove(string path)
        {
            RemoveOldFile((_currentDirectory + path).Replace("/", "\\"));
            return new SuccessResult();
        }

        public void RemoveOldFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
            {
                File.Delete(directory.Replace("/", "\\"));
            }
        }

        public IResult Update(IFormFile file, string imagePath)
        {
            List<string> ImagePaths = new List<string>();

            var fileExists = CheckFileExist(file);
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }

            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            if (typeValid == null)
            {
                return new ErrorResult(typeValid.Message);
            }
            var randomName = Guid.NewGuid().ToString();

            CheckDirectoryExist(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName + randomName + type, file);
            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));


        }

        public IResult Upload(IFormFile file)
        {

            List<string> ImagePaths = new List<string>();

            var fileExists = CheckFileExist(file);
            if (fileExists.Message != null)
            {
                return new ErrorResult(fileExists.Message);
            }
            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            if (!typeValid.Success)
            {
                return new ErrorResult(typeValid.Message);
            }
            var randomName = Guid.NewGuid().ToString();


            CheckDirectoryExist(_currentDirectory + _folderName);
            CreateFile(_currentDirectory + _folderName + randomName + type, file);


            return new SuccessResult((_folderName + randomName + type).Replace("\\", "/"));

        }

    }
}
