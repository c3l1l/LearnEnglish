using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class Instruction
    {
        public Instruction()
        {
            InstructionDetails = new List<InstructionDetail>();
            InstructionSounds = new List<InstructionSound>();
        }
        public int InstructionId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<InstructionDetail> InstructionDetails { get; set; }
        public List<InstructionSound> InstructionSounds { get; set; }
       // public Content Content { get; set; }
        
    }
}
