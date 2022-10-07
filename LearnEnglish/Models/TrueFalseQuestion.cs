using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class TrueFalseQuestion:QuestionBase
    {
        public string Answer { get; set; }
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        [ForeignKey("QuestionActivity")]
        public int QuestionActivityId { get; set; }
        public QuestionActivity QuestionActivity { get; set; }

    }
}
