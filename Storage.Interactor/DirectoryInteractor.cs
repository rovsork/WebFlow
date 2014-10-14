using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Models;

namespace Storage.Interactor
{
    public interface DirectoryInteractor
    {
        IEnumerable<DirectoryDetails> FindRootDirectoryNames(string containerName);
        IEnumerable<DirectoryDetails> FindDirectoriesByName(string containerName, string dirName);
    }
}
