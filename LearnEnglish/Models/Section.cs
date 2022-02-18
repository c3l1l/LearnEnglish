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
            Categories = new List<Category>();
        }
        public int SectionId { get; set; }
        public string Title { get; set; }
        public byte Rank { get; set; }
        public DateTime CreatedDate { get; set; }
        public Theme Theme { get; set; }
        public List<Category> Categories { get; set; }


    }
}
