using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class Theme
    {
        [Key]
        [Display(Name = "ID")]
        public int ThemeId { get; set; }
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        [DisplayName("Theme Name")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Theme Order")]
        public byte Rank { get; set; }
        [Range(0, 3)]
        public sbyte IsActive  { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

      //  [Column(TypeName = "VARCHAR"),MaxLength(2)]
        public Levels Level { get; set; }
        public List<Section> Sections { get; set; }



    }
   public enum Levels{
        A1,
        A2,
        B1,
        B2,
        C1,
        C2
    }
}
