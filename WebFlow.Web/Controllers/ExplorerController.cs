using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using WebFlow.Logic;
using WebFlow.Model;

namespace WebFlow.Web.Controllers
{
    public class ExplorerController : Controller
    {
        //
        // GET: /Directory/
        public ActionResult MakeDirectoryView()
        {
            DirectoryLogic dl = new DirectoryLogic();

            var retVal = dl.GetAllRootDirectoriesForUser(0);

            return PartialView("Explorer/_DirectoryList", retVal);
        }

        public ActionResult MakeFileView(string directory)
        {
            FileLogic fi = new FileLogic();

            directory = "Documents";
            IEnumerable<FileData> retVal = fi.GetFilesInDir(directory);

            return PartialView("Explorer/_FileList", retVal);
        }
    }
}
