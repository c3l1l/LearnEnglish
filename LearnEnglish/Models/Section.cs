using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "ID")]
        public int SectionId { get; set; }
        [Display(Name = "Section Name")]
        public string Title { get; set; }

        [Display(Name = "Section Order")]
        public byte Rank { get; set; }
        [Display(Name = "Create Date")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Theme")]
        public int ThemeId { get; set; }
        public Theme Theme { get; set; }
        public List<Category> Categories { get; set; }


    }
}
