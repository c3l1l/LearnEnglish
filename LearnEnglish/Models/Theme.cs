using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnEnglish.Models
{
    public class Theme
    {
        public Theme()
        {
            Sections = new List<Section>();
        }
        public int ThemeID { get; set; }
        public string Title { get; set; }
        public sbyte Rank { get; set; }
        public sbyte IsActive  { get; set; }
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "VARCHAR"),MaxLength(2)]
        public Level Level { get; set; }
        public List<Section> Sections { get; set; }



    }
   public enum Level{
        A1,
        A2,
        B1,
        B2,
        C1,
        C2
    }
}
