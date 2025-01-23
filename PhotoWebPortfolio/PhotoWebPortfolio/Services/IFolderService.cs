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
        private readonly IGcsService _gcsService;
        private readonly IFolderRepository _folderRepository;
        private readonly ILogger _logger;
        #endregion

        #region Ctor
        public FolderService(
            IFolderRepository folderRepository, 
            ILogger logger,
            IGcsService gcsService)
        {
            _folderRepository = folderRepository;
            _logger = logger;
            _gcsService = gcsService;
        }
        #endregion

        #region Methods 
        public async Task<Folder> CreateFolderAsync(Folder folder)
        {
          if(string.IsNullOrEmpty(folder.Name))
          {
            throw new ArgumentException(nameof(folder),"Folder name cannot be null or empty");
          } 
           return await _folderRepository.CreateAsync(folder);
        }

        public async Task DeleteFolderAsync(int folderId)
        {
            if (folderId < 0)
            {
              _logger.LogError($"Invalid folderId: {folderId}");
               return;
            }
            try
            {
                await _folderRepository.DeleteAsync(folderId);
                _logger.LogInformation($"Processing succeeded {folderId}");
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

        public async Task<string> GetFileUrlFromGSCAsync(string fileName)
        {  
            if(!string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("File could not be found or does not exist", nameof(fileName));
            } 
            var url = await _gcsService.GetFileUrlAsync(fileName);
            return url;
        }

        public async Task<Folder?> GetFolderAsync(int folderId)
        {
            if(folderId < 0)
            {
              _logger.LogError($"Invalid folderId: {folderId}");
               return null;
            }
            try
            {
                var folder = await _folderRepository.GetByIdAsync(folderId);
                if(folder == null)
                {
                    _logger.LogWarning("Folder with ID {FolderId} not found.", folderId);
                    return null;
                }
                _logger.LogInformation($"Process succeeded:{folderId}");
                return folder;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Getting process failed: {ex.Message}");
                throw;
            }
        }

        public async Task<Folder> UpdateFolderAsync(Folder folder)
        { 
            if(folder == null)
            {  
             throw new ArgumentNullException(nameof(folder));
            }
            if(string.IsNullOrEmpty(folder.Name))
            {
              throw new ArgumentException(nameof(folder),"Folder name cannot be null or empty");
            }
            try
            {
                var updatedFolder = await _folderRepository.UpdateAsync(folder); 
                if(updatedFolder == null)
                {
                    throw new InvalidOperationException($"Failed to update the folder with Id {folder.Id}");
                }
                _logger.LogInformation($"Process succeeded. Folder with Id {folder.Id} is updated");
                return updatedFolder;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Update operation failed: {ex.Message}");
                throw;
            }
        }

        public async Task UploadFileToGSCAsycn(string folderName, IFormFile file)
        { 
           
        }
        #endregion
    }

}

