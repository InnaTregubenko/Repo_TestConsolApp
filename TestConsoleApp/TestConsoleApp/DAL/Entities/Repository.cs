using TestConsoleApp.DAL.Interfaces;
using TestConsoleApp.Infrastructure;

using System.IO;
using System.Text;
using System;

namespace TestConsoleApp.DAL.Entities
{
    public class Repository: IRepository
    {
        private IDalConfiguration _dalConfiguration;

        public Repository(IDalConfiguration dalConfiguration)
        {
            _dalConfiguration = dalConfiguration;
        }
        public string[] GetDbData()
        {
            var file = GetFile();
            var data = ReadFile(file).Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            return data;
        }

        private FileInfo GetFile()
        {
            var directoryInfo = new DirectoryInfo(_dalConfiguration.FilePath);
            var file = directoryInfo.GetFiles()[0];
            return file;
        }

        private string ReadFile(FileInfo file)
        {
            var strbuilder = new StringBuilder();
            using (var reader = new StreamReader(file.OpenRead()))
            {
                while (reader.Peek() > 0)
                {
                    strbuilder.Append(reader.ReadLine()+ ";");
                }
            }

            return strbuilder.ToString();
        }
    }
}
