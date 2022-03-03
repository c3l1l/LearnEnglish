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
        public QuestionActivity()
        {
            SingleGapFillingQuestions = new List<SingleGapFillingQuestion>();
            TrueFalseQuestions = new List<TrueFalseQuestion>();
            MultiGapFillingQuestions = new List<MultiGapFillingQuestion>();
            MultipleChoiceQuestions = new List<MultipleChoiceQuestion>();
        }
        public int QuestionActivityId { get; set; }
        public byte Rank { get; set; }
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

