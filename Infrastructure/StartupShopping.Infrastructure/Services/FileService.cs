﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using StartupShopping.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartupShopping.Infrastructure.Services
{
    public class FileService : IFileService
    {
        readonly IWebHostEnvironment _webHostEniroment;

        public FileService(IWebHostEnvironment webHostEniroment)
        {
            _webHostEniroment = webHostEniroment;
        }

        public FileService() { }
        public async Task<List<(string fileName, string path)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEniroment.WebRootPath,path);
            if(!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> datas = new();
            List<bool> results = new();


            foreach(IFormFile file in files)
            {
             string fileNewName =    await FileRenameAsync(file.FileName);

            bool result =   await  CopyFileAsync($"{uploadPath}\\{fileNewName}",file);
                datas.Add((fileNewName, $"{uploadPath}\\{fileNewName}"));
                
                results.Add(result);
            }

            if (results.TrueForAll(r => r.Equals(true)))
            {
                return datas;
            }

            return null;
        }

        public Task<string> FileRenameAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

                await fileStream.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }

}
