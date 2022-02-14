using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class Content
    {
        public int ContentID { get; set; }
        public string Name { get; set; }
        public sbyte Rank { get; set; }
        public DateTime CreatedDate { get; set; }
        public Category Category { get; set; }
        public Section Section { get; set; }

    }

    public enum Category
    {
        GrammarTips,
        Vocabulary,
        Practice,
        ProgressTest
    }
    
}
