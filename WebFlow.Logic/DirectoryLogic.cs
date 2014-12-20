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
            DirectoryRepository directoriesData = RepositoryFactory.DirectoriesData;

        public IEnumerable<DirectoryData> GetAllDirectories()
        {
            return directoriesData.GetAll().ToList();
        }

        public IEnumerable<DirectoryData> GetAllRootDirectoriesForUser(int userId)
        {
            directoriesData.Delete(1);
            return directoriesData.GetAll()
                .AsNoTracking()
                .Where(d => d.DirectoryPath.Length.Equals(0)); 
        }

        public IEnumerable<DirectoryData> GetSubDirectories(string parentDirectoryPath)
        {
            return directoriesData.GetAll()
                .Where(d => d.DirectoryPath.Equals(parentDirectoryPath));
        }

        public void CreateDirectory(DirectoryData dirData)
        {
            
        }
    }
}
