using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class Content
    {
        public int ContentId { get; set; }
        public string Name { get; set; }
        public sbyte Rank { get; set; }
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(20)]
        public Category Category { get; set; }
        public Section Section { get; set; }
        public ContentDetail ContentDetail { get; set; }

    }

    public enum Category
    {
        GrammarTips,
        Vocabulary,
        Practice,
        ProgressTest
    }
    
}
