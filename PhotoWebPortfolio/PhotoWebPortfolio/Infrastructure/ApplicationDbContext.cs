using Microsoft.EntityFrameworkCore;

namespace PhotoWebPortfolio.Infrastructure
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { } 


    }
}
