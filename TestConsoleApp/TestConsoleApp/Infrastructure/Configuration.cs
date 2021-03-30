using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TestConsoleApp.Infrastructure
{
    public class Configuration : IBusinessConfiguration, IDalConfiguration
    {
        public string FilePath { get; }
        public string DateRead { get;  }
        public int FakeCountFile { get; }

        public Configuration(string filePath, string dateRead, int fakeCountFile)
        {
            FilePath = filePath ?? String.Empty;
            DateRead = dateRead;
            FakeCountFile= fakeCountFile;
        }
        
    }
}
