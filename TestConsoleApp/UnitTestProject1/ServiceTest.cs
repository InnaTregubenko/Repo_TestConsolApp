using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsoleApp.BLL.Services;
using TestConsoleApp.DAL.Interfaces;
using TestConsoleApp.Infrastructure;
using Xunit;

namespace TestConsoleApp.Tests
{
    public class ServiceTest
    {
        [Fact]
        public void GetData_shouldReturnString() //какое прав.назв-е у метода должно быть????
        {
            // Arrange
            var mockRepoObj = new Mock<IRepository>();
            mockRepoObj.Setup(r => r.GetDbData()).Returns(new string[] { "testString" });

            var mockConfData = new Mock<IBusinessConfiguration>();
            mockConfData.Setup(d => d.DateRead).Returns("29.03.2021");
            mockConfData.Setup(c => c.FakeCountFile).Returns(1);

            // Act
            var service = new Service(mockConfData.Object, mockRepoObj.Object);
            var result = service.GetData();

            // Assert
            Assert.Equal($"DbData: testString, date of reading: 29.03.2021, count of files: 1", result);
        }
    }
}
