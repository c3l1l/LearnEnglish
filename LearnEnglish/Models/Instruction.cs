using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class Instruction
    {
       
        [Key]
        [Display(Name = "ID")]
        public int InstructionId { get; set; }
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        [DisplayName("Instruction Name")]
        [Required]
        public string Title { get; set; }
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }
      
        public List<InstructionDetail> InstructionDetails { get; set; }
        public List<InstructionSound> InstructionSounds { get; set; }
       // public Content Content { get; set; }
        
    }
}
