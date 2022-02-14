using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace LearnEnglish.Models
{
    public class LearnEnglishContext:DbContext
    {
        /*
         - Add-Migration Initial
         - Update-Database
         */
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=LearnEnglish;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Theme>().HasData(
                new Theme
                {   ThemeID = 1,
                    Title = "Theme-1",
                    CreatedDate = DateTime.Now,
                    IsActive = 1,
                    Level = Level.A1,
                    Rank = 0,
                }
            );
        }
    }
}
