using System.Collections.Generic;
using System.Web.Http;
using WebFlow.Logic;
using WebFlow.Model;

namespace WebFlow.Web.Controllers.API
{
    public class FileController : ApiController
    {
    
    [Route("api/file/{directoryPath}/ListFiles")]
    [HttpGet]
    public IEnumerable<FileData> ListFilesInDirectory(string directoryPath)
    {
        directoryPath = "Documents";
        FileLogic fi = new FileLogic();
        var retVal = fi.GetFilesInDir(directoryPath);
        return retVal;
    }
}
}