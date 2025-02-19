using Xunit;
using Microsoft.EntityFrameworkCore;
using PhotoWebPortfolio.Infrastructure;
using PhotoWebPortfolio.Serv;
using PhotoWebPortfolio.Repositories;
using Microsoft.Extensions.Logging;
using PhotoWebPortfolio.Models;
using Moq;

namespace IntegrationTestPortfolio;

public class GoogleInitTesting
{
    private readonly ApplicationDbContext _dbContext;
    private readonly Mock<IFolderRepository> _folderRepositoryMock;
    private readonly Mock<IGcService> _gcsService;
    private readonly Mock<IFolderService> _folderService;
    private readonly ILogger<IGcsService> _logger;
}
// Class
// Arrange
// Act
// Assert
