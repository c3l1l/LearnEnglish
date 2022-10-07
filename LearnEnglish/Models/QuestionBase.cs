using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class QuestionBase
    {
        [Key]
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public byte Rank { get; set; }
        public DateTime CreatedDate { get; set; }
      
       
      //  public Content Content { get; set; }
    }
    
}
