using Autofac;
using TestConsoleApp.BLL.Interfaces;
using TestConsoleApp.BLL.Services;
using TestConsoleApp.DAL.Interfaces;
using TestConsoleApp.DAL.Entities;
using TestConsoleApp.Infrastructure;

namespace TestConsoleApp.Utils
{
    public class AutofacConfig
    {
        public static IContainer ConfigureContainer(Configuration conf)
        { 
            var builder = new ContainerBuilder();

            builder.RegisterType<Service>().As<IService>().WithParameter(new TypedParameter(typeof(IBusinessConfiguration), conf));
            builder.RegisterType<Repository>().As<IRepository>().WithParameter(new TypedParameter(typeof(IDalConfiguration), conf));
            //builder.RegisterType<Configuration>().As<IDbConfiguration>();
            //builder.RegisterType<Configuration>().As<IConfiguration>();

            //builder.RegisterType<Worker>().AsSelf().As<IWorker>();

            
            var container = builder.Build();

            return container;
            
        }
    }

}
