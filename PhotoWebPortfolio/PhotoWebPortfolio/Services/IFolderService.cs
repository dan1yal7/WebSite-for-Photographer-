using PhotoWebPortfolio.Models;
using PhotoWebPortfolio.Repositories;

namespace PhotoWebPortfolio.Services
{
    #region Contract
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
    #endregion

    public class FolderService : IFolderService
    {
        #region Fields 
        private readonly IFolderRepository _folderRepository;
        private readonly ILogger _logger;
        #endregion

        #region Ctor
        public FolderService(IFolderRepository folderRepository, ILogger logger)
        {
            _folderRepository = folderRepository;
            _logger = logger;
        }
        #endregion

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
            {
              _logger.LogError($"Invalid folderId: {folderId}. Folder deletion aborted", folderId);
               return;
            }
            try
            {
                await _folderRepository.DeleteAsync(folderId);
                _logger.LogInformation($"Proccessing succeeded {folderId}");
            } 
            catch (Exception ex)
            {
                _logger.LogError($"Deletion proccess failed: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Folder>> GetAllFoldersAsync()
        {
            try
            {
               var folders = await _folderRepository.GetAllAsync();
               return folders ?? Enumerable.Empty<Folder>();    
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all folders");
                throw;
            }
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

