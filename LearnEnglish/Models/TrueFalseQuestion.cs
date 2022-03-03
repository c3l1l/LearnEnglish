using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class TrueFalseQuestion:Question
    {
        public string Answer { get; set; }
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public QuestionActivity QuestionActivity { get; set; }

    }
}
