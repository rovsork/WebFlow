using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            SubDirs = new List<DirectoryData>();
        }
   
        [Key]
        public int DirectoryId { get; set; }
        public int? ParentDirId { get; set; }
        public string DirectoryName { get; set; }
        public string DirectoryPath { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<FileData> Files { get; set; }
    
        [ForeignKey("ParentDirId")]
        public virtual DirectoryData ParentDirectory { get; set; }
    
        [InverseProperty("ParentDirectory")]
        public virtual ICollection<DirectoryData> SubDirs { get; set; }

        //[ForeignKey("ParentDirId")]
        //public virtual DirectoryData ParentDirectory { get; set; }

        //[InverseProperty("ParentDirectory")]
        //public virtual ICollection<DirectoryData> SubDirs { get; set; }
    }
}
