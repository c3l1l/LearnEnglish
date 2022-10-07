using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class SingleGapFillingQuestion:QuestionBase
    {
        public string Answer { get; set; }
        [ForeignKey("QuestionActivity")]
        public int QuestionActivityId { get; set; }
        public QuestionActivity QuestionActivity { get; set; }

    }
}
