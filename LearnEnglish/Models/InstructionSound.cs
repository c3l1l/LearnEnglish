using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class InstructionSound : Sound
    {
        public  int InstructionSoundId { get; set; }
        public byte Rank { get; set; }
        public DateTime CreatedDate { get; set; }
        public Instruction Instruction { get; set; }

    }
}
