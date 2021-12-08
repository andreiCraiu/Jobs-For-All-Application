using codemania.Constants;
using codemania.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace codemania.Service
{
    public class FileReader : IFileReader
    {
        public string ReadFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
