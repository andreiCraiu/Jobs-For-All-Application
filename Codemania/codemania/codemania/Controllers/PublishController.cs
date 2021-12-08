using codemania.Constants;
using codemania.Interfaces;
using codemania.Models;
using codemania.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codemania.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublishController : ControllerBase
    {
        private readonly IFileReader _fileReader;
        private readonly IRunCodeService _runCodeService;

        public PublishController(IFileReader fileReader, IRunCodeService runCodeService)
        {
            _fileReader = fileReader;
            _runCodeService = runCodeService;
        }

        [HttpGet]
        public string ReadFromFile(string fileNumber)
        {
            switch (fileNumber)
            {
                case "0":  return _fileReader.ReadFromFile(PathConstants.TEST_PATH);
                case "1.0": return _fileReader.ReadFromFile(PathConstants.FIRST_MODULE_PATH);
                default: return String.Empty;
            }
  
        }

        [HttpPost]
        public string RunCode(CodeViewModel codeModel)
        {
            _runCodeService.RunCode();
            return "OK";
        }

    }
}
