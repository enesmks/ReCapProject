using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var result = newPath(file);
            var sourcePath = Path.GetTempFileName();

            if (file.Length >0)
            {
                using (var stream = new FileStream(sourcePath,FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Move(sourcePath, result);
            return result;
        }
        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
            return new SuccessResult();
        }
        public static string Update(string sourcePath,IFormFile file)
        {
            var result = newPath(file);
            if (sourcePath.Length>0)
            {
                using (var stream = new FileStream(result,FileMode.Create))
                {
                    file.CopyTo(stream);
                }                
            }
            File.Delete(sourcePath);
            return result;
        }
        public static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            string path = Environment.CurrentDirectory + @"\wwwroot\Images";
            var newPath = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "-" + DateTime.Now.Year + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}
