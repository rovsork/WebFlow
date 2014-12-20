using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFlow.Model;

namespace WebFlow.Data
{
    public class WebFlowInitializer : System.Data.Entity.DropCreateDatabaseAlways<WebFlowContext>
    {
        protected override void Seed(WebFlowContext context)
        {
            var directoriesData = CreateDirecotries();

            foreach (var directoryData in directoriesData)
            {
                context.DirectoryData.Add(directoryData);
                context.SaveChanges();
            }
            var dirs = context.DirectoryData.Find(1);
            
            var childDirectories = CreateChildDirectories(context, directoriesData);
            context.SaveChanges();
            CreateFilesInDirectories(directoriesData);


            var fileData = CreateFileData(directoriesData[0]);

            context.FileData.Add(fileData);
            context.SaveChanges();
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
                },
                new DirectoryData()
                {
                    DirectoryName = "Images",
                    DirectoryPath = "",
                    CreationDate = DateTime.Now,
                },
                new DirectoryData()
                {
                    DirectoryName = "Music",
                    DirectoryPath = "",
                    CreationDate = DateTime.Now,
                }
            };
        }

        private List<DirectoryData> CreateChildDirectories(WebFlowContext context, List<DirectoryData> parentDirs)
        {
            parentDirs[0].SubDirs.Add(
                new DirectoryData()
                {
                    DirectoryName = "Word docs",
                    DirectoryPath = "",
                    CreationDate = DateTime.Now,
                    Files = new List<FileData>(),
                    ParentDirId = parentDirs[0].DirectoryId,
                    SubDirs = new List<DirectoryData>()
                });
            parentDirs[0].SubDirs.Add(
                new DirectoryData()
                {
                    DirectoryName = "Pdf docs",
                    DirectoryPath = "",
                    CreationDate = DateTime.Now,
                    Files = new List<FileData>(),
                    ParentDirId = parentDirs[0].DirectoryId,
                    SubDirs = new List<DirectoryData>()
                });

            parentDirs[1].SubDirs.Add(
                new DirectoryData()
                {
                    DirectoryName = "Jpeg",
                    DirectoryPath = "",
                    CreationDate = DateTime.Now,
                    Files = new List<FileData>(),
                    ParentDirId = parentDirs[1].DirectoryId,
                    SubDirs = new List<DirectoryData>()
                });
            parentDirs[1].SubDirs.Add(
                new DirectoryData()
                {
                    DirectoryName = "Bmp",
                    DirectoryPath = "",
                    CreationDate = DateTime.Now,
                    Files = new List<FileData>(),
                    ParentDirId = parentDirs[1].DirectoryId,
                    SubDirs = new List<DirectoryData>()
                });

            context.SaveChanges();
            return parentDirs;
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

        private static void CreateFilesInDirectories(List<DirectoryData> directories)
        {
            foreach (var directory in directories)
            {
                foreach (var firstsublevel in directory.SubDirs)
                {
                    firstsublevel.Files = new List<FileData>
                    {
                        new FileData
                        {
                            Name = "myTestTextFile",
                            ImportDate = DateTime.Now,
                            Path = "",
                            FileSize = 4,
                            Extension = "txt",
                            DirectoryId = firstsublevel.DirectoryId,
                            DirectoryData = firstsublevel
                        },
                        new FileData
                        {
                            Name = "freenas-dummie (1)",
                            ImportDate = DateTime.Now,
                            Path = "",
                            FileSize = 1293,
                            Extension = "pdf",
                            DirectoryId = firstsublevel.DirectoryId,
                            DirectoryData = firstsublevel
                        },
                        new FileData
                        {
                            Name = "screesco screens",
                            ImportDate = DateTime.Now,
                            Path = "",
                            FileSize = 500,
                            Extension = "docx",
                            DirectoryId = firstsublevel.DirectoryId,
                            DirectoryData = firstsublevel
                        }
                    };
                }

                directory.Files = new List<FileData>
                {
                    new FileData
                    {
                        Name = "myTestTextFile",
                        ImportDate = DateTime.Now,
                        Path = "",
                        FileSize = 4,
                        Extension = "txt",
                        DirectoryId = directory.DirectoryId,
                        DirectoryData = directory
                    },
                    new FileData
                    {
                        Name = "freenas-dummie (1)",
                        ImportDate = DateTime.Now,
                        Path = "",
                        FileSize = 1293,
                        Extension = "pdf",
                        DirectoryId = directory.DirectoryId,
                        DirectoryData = directory
                    },
                    new FileData
                    {
                        Name = "screesco screens",
                        ImportDate = DateTime.Now,
                        Path = "",
                        FileSize = 500,
                        Extension = "docx",
                        DirectoryId = directory.DirectoryId,
                        DirectoryData = directory
                    },
                    new FileData
                    {
                        Name = "Exported-2013-11-06",
                        ImportDate = DateTime.Now,
                        Path = "",
                        FileSize = 500,
                        Extension = "vssettings",
                        DirectoryId = directory.DirectoryId,
                        DirectoryData = directory
                    }
                };
            }
        }
    }
}
