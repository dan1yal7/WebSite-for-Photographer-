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
       private readonly ILogger _logger;

        public FolderService(IFolderRepository folderRepository, ILogger logger)
        {
            _folderRepository = folderRepository;
            _logger = logger;
        } 



        public async Task<Folder> CreateFolderAsync(Folder folder)
        { 
         if(folder == null)
         throw new ArgumentNullException(nameof(folder));

          if(string.IsNullOrEmpty(folder.Name))
          {
            throw new ArgumentNullException("Folder name cannot be null or empty", nameof(folder));
          } 
           var folderName = folder.Name;
           return await _folderRepository.CreateAsync(folder);
        }

        public async Task DeleteFolderAsync(int folderId)
        {
            if (folderId < 0)
            _logger.LogError("Folder is not found"); 
            var folder = _folderRepository.GetById(folderId);
            try
            {
                var deleteFolder = _folderRepository.DeleteAsync(folderId);
                Console.WriteLine($"Proccessing succeeded {deleteFolder}");
            } 
            catch (Exception ex)
            { 
              Console.WriteLine($"Proccess failed: {ex.Message}");
            }
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

