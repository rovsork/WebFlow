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
        public static BasicRepository<FileData> FilesData { get { return GetStandardRepo<FileData>(); } }
        public static DirectoryRepository DirectoriesData { get { return GetDirectoryRepo<DirectoryData>(); } }

        private static DirectoryRepository GetDirectoryRepo<T>()
        {
            return new EFDirectoryRepository();
        }

        private static BasicRepository<T> GetStandardRepo<T>() where T : class
        {
            return new EFRepository<T>();
        }
    }
}
