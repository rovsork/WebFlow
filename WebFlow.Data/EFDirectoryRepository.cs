using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFlow.Data.Contracts;
using WebFlow.Model;

namespace WebFlow.Data
{
    public class EFDirectoryRepository : EFRepository<DirectoryData>, DirectoryRepository
    {
        public override void Delete(DirectoryData entity)
        {
            DeleteSubDirs(entity);
            
            DbContext.SaveChanges();
        }

        private void DeleteSubDirs (DirectoryData directoryData)
        {
            foreach (DirectoryData subDirectoryData in directoryData.SubDirs.ToList())
            {
                if (subDirectoryData.SubDirs.Count() > 0)
                {
                    DeleteSubDirs(subDirectoryData);
                }
                else
                {
                    DbContext.DirectoryData.Remove(subDirectoryData);
                }
            }
            DbContext.DirectoryData.Remove(directoryData);
        }

        private void DeleteAllSubDirs(DirectoryData directoryData)
        {
            if (directoryData.SubDirs.Any())
            {
                foreach (var subDir in directoryData.SubDirs)
                {
                    if (directoryData.SubDirs.Any())
                    {
                        DeleteAllSubDirs(subDir);
                    }
                    DbEntityEntry dbentitiEntry = DbContext.Entry(subDir);
                    dbentitiEntry.State = EntityState.Deleted;
                }
            }
        }
    }
}
