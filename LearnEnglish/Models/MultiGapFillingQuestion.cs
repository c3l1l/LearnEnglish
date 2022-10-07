using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class MultiGapFillingQuestion:QuestionBase
    {
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        [ForeignKey("QuestionActivity")]
        public int QuestionActivityId { get; set; }
        public QuestionActivity QuestionActivity { get; set; }
    }
}
