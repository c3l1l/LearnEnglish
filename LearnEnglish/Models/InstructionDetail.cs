using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class InstructionDetail
    {
        [Key]
        [DisplayName("ID")]
        public int InstructionDetailId { get; set; }
        [DisplayName("Subject Info")]
        public string Info { get; set; }
        public byte Rank { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
        [ForeignKey("Instruction")]
        public int InstructionId { get; set; }
        public Instruction Instruction { get; set; }

    }
}