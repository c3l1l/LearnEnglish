using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class QuestionActivity
    {
        [Key]
        [Display(Name = "ID")]
        public int QuestionActivityId { get; set; }
        [Display(Name = "Question Activity Order")]
        public byte Rank { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "NVARCHAR"), MaxLength(40)]
        public QuestionType QuestionType { get; set; }

        public List<SingleGapFillingQuestion> SingleGapFillingQuestions { get; set; }
        public List<TrueFalseQuestion> TrueFalseQuestions { get; set; }
        public List<MultiGapFillingQuestion> MultiGapFillingQuestions { get; set; }
        public List<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }

       
    }
    public enum QuestionType
    {
        MultipleChoiceQuestion,
        SingleGapFillingQuestion,
        MultiGapFillingQuestion,
        TrueFalseQuestion,
    }
}

