using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codemania.Interfaces
{
    public interface IFileReader
    {
        public string ReadFromFile(string filePath);
    }
}
