using Xunit;
using Microsoft.EntityFrameworkCore;
using PhotoWebPortfolio.Infrastructure;
using PhotoWebPortfolio.Serv;
using PhotoWebPortfolio.Repositories;
using Microsoft.Extensions.Logging;
using PhotoWebPortfolio.Models;
using Moq;

namespace TestPortfolioUnit
{

    public class FolderServiceTest
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Mock<IFolderRepository> _folderRepositoryMock;
        private readonly FolderService _folderService;
        private readonly ILogger<FolderService> _logger;

      public FolderServiceTest()
      {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

          // Создание mock-объекта для IFolderRepository
            _folderRepositoryMock = new Mock<IFolderRepository>();

            // Создание mock-объекта для ILogger
            var loggerMock = new Mock<ILogger<FolderService>>();

            // Инициализация FolderService с моками
            _folderService = new FolderService(_folderRepositoryMock.Object, loggerMock.Object, null);
      }

      [Fact]
      public async Task CreateF()
      {
          //Arrange
           var folder = new Folder {Name = "TestFolder"};
          _folderRepositoryMock.Setup(repo => repo.CreateAsync(folder)).ReturnsAsync(folder);

          //Act
           var result = await _folderService.CreateFolderAsync(folder);

           //Assert
           Assert.NotNull(result);
           Assert.Equal("TestFolder", result.Name);
          _folderRepositoryMock.Verify(repo => repo.CreateAsync(folder), Times.Once);
      }

      [Fact]
      public async Task DeleteF()
      {
          //Arrange
          _folderRepositoryMock.Setup(repo => repo.DeleteAsync(1));

          //Act
          var result = await _folderService.DeleteFolderAsync();

          //Assert
          Assert.Equal(1, result);
          _folderRepositoryMock.Verify(repo => repo.DeleteAsync(1));
      }

    }

}
