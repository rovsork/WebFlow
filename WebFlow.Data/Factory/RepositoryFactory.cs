using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFlow.Data.Contracts;
using WebFlow.Model;

namespace WebFlow.Data.Factory
{
    public static class RepositoryFactory
    {
        public static Repository<FileData> FilesData { get { return GetStandardRepo<FileData>(); } }
        public static Repository<DirectoryData> DirectoriesData { get { return GetStandardRepo<DirectoryData>(); } }
        
        private static Repository<T> GetStandardRepo<T>() where T : class
        {
            return new EFRepository<T>();
        }
    }
}
