using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public sbyte Rank { get; set; }
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(20)]
        public CategoryType CategoryType { get; set; }

        public List<Content> Contents { get; set; }

    }
    public enum CategoryType
    {
        GrammarTips,
        Vocabulary,
        Practice,
        ProgressTest
    }
}
