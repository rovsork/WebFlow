using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFlow.Model
{
    public class DirectoryData
    {
        public DirectoryData()
        {
            Files = new List<FileData>();
        }
   
        [Key]
        public int DirectoryId { get; set; }
        public string DirectoryName { get; set; }
        public string DirectoryPath { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<FileData> Files { get; set; }
    }
}
