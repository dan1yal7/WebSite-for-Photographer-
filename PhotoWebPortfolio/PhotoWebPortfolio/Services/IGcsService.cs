using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Mvc;

namespace PhotoWebPortfolio.Services
{
    public interface IGcsService
    {
        Task<string> GetFileUrl (string fileName);
    } 
    
    public class GscService : IGcsService
    {
        private readonly string _bucketName = "photoagency-storagetestdemo";
        public GscService(string bucketName)
        {
            _bucketName = bucketName;
        }

        public async Task<string> GetFileUrl(string fileName)
        {
            var url = $"https://storage.googleapis.com/{_bucketName}/{fileName}";
            return url;
        }

       
    }
}
