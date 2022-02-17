using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class QuestionActivity
    {
        public int ActivityId { get; set; }
        public string Title { get; set; }
       
        public sbyte Rank { get; set; }
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "NVARCHAR"), MaxLength(40)]
        public Question Question { get; set; }
        public Content Content { get; set; }
    }
       //Todo Activity Type'larin siniflarinda question ve ilgili ture gore secenekler eklenecek...
    //public enum ActivityType
    //{
    //    MultipleChoiceQuestion,
    //    SingleGapFillingQuestion,
    //    MultiGapFillingQuestion,
    //    TrueFalseQuestion,
    //}
}
