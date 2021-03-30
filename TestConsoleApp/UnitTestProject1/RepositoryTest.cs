using Moq;
using TestConsoleApp.DAL.Entities;
using TestConsoleApp.Infrastructure;
using Xunit;

namespace UnitTestProject1
{
    public class RepositoryTest
    {
        [Fact]
        public void GetDbData_ShouldReturnString()
        {
            // Arrange
            var mockConfData = new Mock<IDalConfiguration>();
            mockConfData.Setup(a => a.FilePath).Returns(@"C:\Users\inna.tregubenko\Documents\visual studio 2015\Projects\TestConsoleApp\TestConsoleApp\ProjectFilesFolder\");

            // Act
            var repository = new Repository(mockConfData.Object);
            var result = repository.GetDbData();
            var expectedCountLines = 2;

            // Assert
            Assert.Equal(expectedCountLines, result.Length);
        }

    }
}
