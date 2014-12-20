using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebFlow.Logic;
using WebFlow.Model;

namespace WebFlow.Web.Controllers.API
{
    public class DirectoryController : ApiController
    {
        [Route("api/directory/{userName}/GetRootDirs")]
        [HttpGet]
        public IEnumerable<DirectoryData> GetRootDirectories(string userName)
        {
            DirectoryLogic dl = new DirectoryLogic();
            var retVal = dl.GetAllRootDirectoriesForUser(0);
            return retVal;
        }
        [Route("api/directory/{userName}/{dirPath}/GetSubDirs")]
        [HttpGet]
        public IEnumerable<DirectoryData> GetSubDirectories(string userName, string dirPath)
        {
            DirectoryLogic dl = new DirectoryLogic();
            var retVal = dl.GetSubDirectories(dirPath);
            return retVal;
        }

        [Route("api/directory/{userName}/GetAllDirs")]
        [HttpGet]
        public IEnumerable<DirectoryData> GetAllDirectories(string userName)
        {
            DirectoryLogic dl = new DirectoryLogic();
            var retVal = dl.GetAllDirectories();
            return retVal;
        }


    }
}
