using Microsoft.EntityFrameworkCore;
using PhotoWebPortfolio.Infrastructure;
using PhotoWebPortfolio.Models;

namespace PhotoWebPortfolio.Repositories
{
    public interface IFolderRepository
    {
       Task<Folder> CreateAsync(Folder folder);
       Task<Folder> GetByIdAsync(int folderId); 
       Task<IEnumerable<Folder>> GetAllAsync();
       Task DeleteAsync(int folderId);
       Task UpdateAsync(Folder folder);
    }

    public class FolderRepository : IFolderRepository
    {
        private readonly ApplicationDbContext _dbContext;
        
        public FolderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        } 
        public async Task<Folder> CreateAsync(Folder folder)
        {
            await _dbContext.folders.AddAsync(folder);
            await _dbContext.SaveChangesAsync();
            return folder;
        }
        public async Task<Folder> GetByIdAsync(int folderId)
        {
           return await _dbContext.folders.FindAsync(folderId);
        }

        public async Task<IEnumerable<Folder>> GetAllAsync()
        {
            return await _dbContext.folders.ToListAsync();
        }
        public async Task DeleteAsync(int folderId)
        {
            var folder = await _dbContext.folders.FindAsync(folderId); 
            if(folder != null)
            {
               _dbContext.folders.Remove(folder); 
            }
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Folder folder)
        {
            _dbContext.folders.Update(folder);
            await _dbContext.SaveChangesAsync();
        }
    }
}
