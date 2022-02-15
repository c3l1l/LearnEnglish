using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class ContentDetail
    {
        public int ContentDetailID { get; set; }
        public string Name { get; set; }
        public sbyte Rank { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(20)]
        public ContentType ContentType { get; set; }
        public DateTime CreatedDate { get; set; }

    }

    public enum ContentType
    {
        Instruction,
        Activity
    }
}
