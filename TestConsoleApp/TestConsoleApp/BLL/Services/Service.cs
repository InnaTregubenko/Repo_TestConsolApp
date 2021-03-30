using TestConsoleApp.BLL.Interfaces;
using TestConsoleApp.DAL.Interfaces;
using TestConsoleApp.Infrastructure;
using System.IO;
using System.Text;
using System;

namespace TestConsoleApp.BLL.Services
{
    public class Service : IService
    {
        private IBusinessConfiguration _configuration;
        private IRepository _repository;

        public Service(IBusinessConfiguration configuration, IRepository repository)
        {
            _configuration = configuration;
            _repository = repository;
        }
        public string GetData()
        {
            var dbData = _repository.GetDbData();
            return BuildData(dbData);
        }

        private string BuildData(string[] dbData) =>
            $"DbData: {string.Join(",", dbData)}, date of reading: {_configuration.DateRead}, count of files: {_configuration.FakeCountFile}";

        
    }
}
