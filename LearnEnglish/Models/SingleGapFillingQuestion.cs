using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class SingleGapFillingQuestion:Question
    {
        public string Answer { get; set; }
        public QuestionActivity QuestionActivity { get; set; }

    }
}
