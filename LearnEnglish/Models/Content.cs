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
        public string Title { get; set; }
        public byte Rank { get; set; }
        public DateTime CreatedDate { get; set; }
        public Category Category { get; set; }

        [Column(TypeName = "VARCHAR"), MaxLength(25)]
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
