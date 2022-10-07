using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class Content
    {

        [Key]
        [Display(Name = "ID")]
        public int ContentId { get; set; }
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        [DisplayName("Content Name")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Content Order")]
        public byte Rank { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(30)]
        public ContentType ContentType { get; set; }
        public Instruction Instruction { get; set; }
        public QuestionActivity QuestionActivity { get; set; }

    }
    public enum ContentType
    {
        Instruction,
        QuestionActivity
    }



}
