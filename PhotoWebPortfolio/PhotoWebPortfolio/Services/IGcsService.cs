using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace PhotoWebPortfolio.Services
{
    public interface IGcsService
    {
        Task<string> GetFileUrlAsync(string fileName);
        Task UploadFileAsync(string folderName, IFormFile file);
    } 
    
    public class GscService : IGcsService
    {
        private readonly string _bucketName = "photoagency-storagetestdemo";
        private readonly StorageClient _storageClient;
        public GscService(string bucketName, StorageClient storageClient)
        {
            _bucketName = bucketName;
            _storageClient = storageClient;
        }

        public async Task<string> GetFileUrlAsync(string fileName)
        {
            var url = $"https://storage.googleapis.com/{_bucketName}/{fileName}";
            return url;
        }

        public async Task UploadFileAsync(string folderName, IFormFile file)
        {
            var objectName = $"{folderName}/{file.FileName}";
            using var stream = file.OpenReadStream();
            await _storageClient.UploadObjectAsync(_bucketName, objectName, file.ContentType, stream);
        }

    }
}
