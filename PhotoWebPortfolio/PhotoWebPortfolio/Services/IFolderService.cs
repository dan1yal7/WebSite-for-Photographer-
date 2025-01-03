using PhotoWebPortfolio.Models;

namespace PhotoWebPortfolio.Services
{
    public interface IFolderService
    {
        Task<Folder> CreateFolderAsync(Folder folder);
        Task<Folder> GetFolderAsync(int folderId);
        Task<IEnumerable<Folder>> GetAllFoldersAsync();
        Task DeleteFolderAsync(int folderId);
        Task<Folder> UpdateFolderAsync(Folder folder);
        Task UploadFileToGSCAsycn(string folderName, IFormFile file);
        Task<string> GetFileUrlFromGSCAsync(string fileName); 
    } 


}

