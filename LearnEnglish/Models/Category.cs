using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "ID")]
        public int CategoryId { get; set; }
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        [DisplayName("Category Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Category Order")]
        public byte Rank { get; set; }
        [Display(Name = "Create Date")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(20)]
        [Display(Name = "Category Type")]
        public CategoryType CategoryType { get; set; }
        [ForeignKey("Section")]
        public int SectionId { get; set; }
        public Section Section { get; set; }
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
