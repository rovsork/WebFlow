using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFlow.Model;

namespace WebFlow.Data
{
    public class WebFlowInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WebFlowContext>
    {
        protected override void Seed(WebFlowContext context)
        {
            var directoriesData = CreateDirecotries();

            CreateFilesInDirectories(directoriesData);

            foreach (var directoryData in directoriesData)
            {
                context.DirectoryData.Add(directoryData);
                context.SaveChanges();
            }

            var fileData = CreateFileData(directoriesData[0]);

            context.FileData.Add(fileData);
            context.SaveChanges();
        }

        private FileData CreateFileData(DirectoryData directory)
        {
            return new FileData
            {
                Name = "OnlyFileInserted into a dir",
                ImportDate = DateTime.Now,
                Path = "",
                FileSize = 4000,
                Extension = "mdf",
                DirectoryId = directory.DirectoryId
            };

        }

        private static List<DirectoryData> CreateDirecotries()
        {
            return new List<DirectoryData>
            {
                new DirectoryData()
                {
                    DirectoryName = "Documents",
                    DirectoryPath = "",
                    CreationDate = DateTime.Now,
                    Files = new List<FileData>()
                },
                new DirectoryData()
                {
                    DirectoryName = "Images",
                    DirectoryPath = "",
                    CreationDate = DateTime.Now,
                    Files = new List<FileData>()
                },
                new DirectoryData()
                {
                    DirectoryName = "Invoices",
                    DirectoryPath = "Documents",
                    CreationDate = DateTime.Now,
                    Files = new List<FileData>()
                },
                new DirectoryData()
                {
                    DirectoryName = "2015",
                    DirectoryPath = "Documents/Invoices",
                    CreationDate = DateTime.Now,
                    Files = new List<FileData>()
                },
            };
        }

        private static void CreateFilesInDirectories(List<DirectoryData> direcories)
        {
            foreach (var direcory in direcories)
            {
                direcory.Files = new List<FileData>
                {
                    new FileData
                    {
                        Name = "myTestTextFile",
                        ImportDate = DateTime.Now,
                        Path = "",
                        FileSize = 4,
                        Extension = "txt",
                        DirectoryData = direcory
                    },
                    new FileData
                    {
                        Name = "freenas-dummie (1)",
                        ImportDate = DateTime.Now,
                        Path = "",
                        FileSize = 1293,
                        Extension = "pdf",
                        DirectoryData = direcory
                    },
                    new FileData
                    {
                        Name = "screesco screens",
                        ImportDate = DateTime.Now,
                        Path = "",
                        FileSize = 500,
                        Extension = "docx",
                        DirectoryData = direcory
                    },
                    new FileData
                    {
                        Name = "Exported-2013-11-06",
                        ImportDate = DateTime.Now,
                        Path = "",
                        FileSize = 500,
                        Extension = "vssettings",
                        DirectoryData = direcory
                    }
                };
            }
        }
    }
}
