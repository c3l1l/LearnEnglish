using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class Instruction
    {
        public int InstructionID { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public sbyte Rank { get; set; }
        public DateTime CreatedDate { get; set; }
        public ContentDetail ContentDetail { get; set; }
    }
}
