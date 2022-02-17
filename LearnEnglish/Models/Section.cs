using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class Section
    {
        public Section()
        {
            Contents = new List<Content>();
        }
        public int SectionId { get; set; }
        public string Title { get; set; }
        public sbyte Rank { get; set; }
        public DateTime CreatedDate { get; set; }
        public Theme Theme { get; set; }
        public List<Content> Contents { get; set; }


    }
}
