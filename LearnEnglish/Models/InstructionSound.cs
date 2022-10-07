using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class InstructionSound : SoundBase
    {
        [Key]
        [DisplayName("ID")]
        public  int InstructionSoundId { get; set; }
        [DisplayName("Sound Order")]
        public byte Rank { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
        [ForeignKey("Instruction")]
        public int InstructionId { get; set; }
        public Instruction Instruction { get; set; }

    }
}
