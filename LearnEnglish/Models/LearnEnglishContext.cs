using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LearnEnglish.Models
{
    public class LearnEnglishContext:DbContext
    {
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=LearnEnglish;Trusted_Connection=True;");
        }
    }
}
