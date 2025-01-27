using Microsoft.EntityFrameworkCore;
using PhotoWebPortfolio.Models;

namespace PhotoWebPortfolio.Infrastructure
{
    public class ApplicationDbContext : DbContext 
    { 
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { 
         
        } 
        public DbSet<Category> categories { get; set; }
        public DbSet<ClientInteraction> interactions { get; set; }
        public DbSet<Contacts> contacts { get; set; }
        public DbSet<Folder> folders { get; set; }
        public DbSet<FolderItem> folderItems { get; set; } 
        public DbSet<PortfolioItem> portfolioItems { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<User> users { get; set; }

    }
}
