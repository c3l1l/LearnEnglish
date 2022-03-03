using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class MultiGapFillingQuestion:Question
    {
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public QuestionActivity QuestionActivity { get; set; }
    }
}
