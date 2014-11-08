using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFlow.Data.Contracts;
using WebFlow.Data.Factory;
using WebFlow.Model;

namespace WebFlow.Logic
{
    public class FileLogic
    {
        Repository<FileData> fileRepository= RepositoryFactory.FilesData;

        public IEnumerable<FileData> GetFilesInDir(string dirPath)
        {
            return fileRepository.GetAll()
                .Where(f => f.DirectoryData.DirectoryPath == dirPath);
        }

        public IEnumerable<FileData> GetFilesByExtension(string extension)
        {
            return fileRepository.GetAll()
                .Where(f => f.Extension.Equals(extension));
        }
    }
}
