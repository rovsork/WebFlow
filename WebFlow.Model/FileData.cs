using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFlow.Model
{
    public class FileData
    {
        public FileData() { }

        [Key]
        public int FileId { get; set; }
        public int DirectoryId { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public DateTime ImportDate { get; set; }
        public string Path { get; set; }
        public long FileSize { get; set; }

        public virtual DirectoryData DirectoryData { get; set; }
    }
}
