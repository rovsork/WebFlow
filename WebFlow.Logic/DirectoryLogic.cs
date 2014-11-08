using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFlow.Data;
using WebFlow.Data.Contracts;
using WebFlow.Data.Factory;
using WebFlow.Model;

namespace WebFlow.Logic
{
    public class DirectoryLogic
    {
            Repository<DirectoryData> directoriesData = RepositoryFactory.DirectoriesData;

        public IEnumerable<DirectoryData> GetAllDirectories()
        {

            foreach (var dirData in directoriesData.GetAll().ToList())
            {
                string name =  dirData.DirectoryName;
            }

            return directoriesData.GetAll().ToList();
        }

        public IEnumerable<DirectoryData> GetAllRootDirectoriesForUser(int userId)
        {

            return directoriesData.GetAll()
                .AsNoTracking()
                .Where(d => d.DirectoryPath.Length.Equals(0)); 
        }

        public IEnumerable<DirectoryData> GetSubDirectories(string parentDirectoryPath)
        {
            return directoriesData.GetAll()
                .Where(d => d.DirectoryName.Equals(parentDirectoryPath));
        }
    }
}
