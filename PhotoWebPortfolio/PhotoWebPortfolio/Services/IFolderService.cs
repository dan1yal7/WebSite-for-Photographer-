using PhotoWebPortfolio.Models;
using PhotoWebPortfolio.Repositories;

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

    public class FolderService : IFolderService
    {
       private readonly IFolderRepository _folderRepository;

        public FolderService(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        public async Task<Folder> CreateFolderAsync(Folder folder)
        {
          if(folder == null)
           throw new ArgumentNullException(nameof(folder));
          var folderName = folder.Name;
          return await _folderRepository.CreateAsync(folder);
        }

        public Task DeleteFolderAsync(int folderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Folder>> GetAllFoldersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetFileUrlFromGSCAsync(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<Folder> GetFolderAsync(int folderId)
        {
            throw new NotImplementedException();
        }

        public Task<Folder> UpdateFolderAsync(Folder folder)
        {
            throw new NotImplementedException();
        }

        public Task UploadFileToGSCAsycn(string folderName, IFormFile file)
        {
            throw new NotImplementedException();
        }
    }

}

