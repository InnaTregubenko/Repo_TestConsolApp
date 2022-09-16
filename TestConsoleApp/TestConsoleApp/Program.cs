using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsoleApp.Utils;

using Autofac;
using TestConsoleApp.BLL.Interfaces;
using TestConsoleApp.Infrastructure;
using System.Configuration;

namespace TestConsoleApp
{
    class Program
    {
        private static IService _service;
        private static Infrastructure.Configuration _configuration;
        private static IContainer _diContainer;
        static void Main(string[] args)
        {
            _configuration = GetSettings();//
            //first changes

            _diContainer = GetDiContainer(_configuration);

            var result = String.Empty;

            using (var scope = _diContainer.BeginLifetimeScope())
            {
                _service = scope.Resolve<IService>();
                result = _service.GetData();
            }
            Console.WriteLine(result);
            Console.WriteLine("second");
            Console.WriteLine("third");
            Console.ReadKey();//some
        }

        private static Infrastructure.Configuration GetSettings() 
            => new Infrastructure.Configuration(ConfigurationManager.AppSettings["FilePath"], DateTime.Now.ToString("dd.MM.yyy"), 1);
           
        private static IContainer GetDiContainer(Infrastructure.Configuration conf) => AutofacConfig.ConfigureContainer(conf);
    }
}
