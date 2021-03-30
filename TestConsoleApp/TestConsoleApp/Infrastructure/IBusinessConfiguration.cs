using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp.Infrastructure
{
    public interface IBusinessConfiguration 
    {
        string DateRead { get;  }
        int FakeCountFile { get;  }
    }
}
