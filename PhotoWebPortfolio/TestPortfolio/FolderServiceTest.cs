using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoWebPortfolio.Infrastructure;

namespace TestPortfolioUnit
{

    public class FolderServiceTest
    {
        [Fact]
        public void CreateF()
        {
           //Arrange
          var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase").Options;

        }
    }

}
