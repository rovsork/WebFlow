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
        [Route("api/directory/GetRootDirs")]
        [HttpGet]
        public IEnumerable<DirectoryData> GetRootDirectories()
        {
            DirectoryLogic dl = new DirectoryLogic();
            var retVal = dl.GetAllRootDirectoriesForUser(0);
            return retVal;
        }
    }
}
