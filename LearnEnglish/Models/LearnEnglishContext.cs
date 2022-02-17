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
        public virtual DbSet<ContentDetail> ContentDetails { get; set; }
        public virtual DbSet<Instruction> Instructions { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=LearnEnglish;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Theme>().HasData(
                new Theme
                {   ThemeId = 1,
                    Title = "Theme-1",
                    CreatedDate = DateTime.Now,
                    IsActive = 1,
                    Level = Level.A1,
                    Rank = 0,
                }
            );
            modelBuilder.Entity<Section>().HasData(
            new Section
            {
                SectionId = 1,
                Title = "1A",
                CreatedDate = DateTime.Now,
                Rank = 0

            });
            modelBuilder.Entity<Content>().HasData(
            new Content{
                ContentId=1,
                Category = Category.GrammarTips,
                CreatedDate = DateTime.Now,
                Name = "Present Perfect T.",
                Rank=0
            });
            modelBuilder.Entity<ContentDetail>().HasData(
            new ContentDetail{
                ContentDetailId = 1,
                ContentType = ContentType.Instruction,
                CreatedDate = DateTime.Now,
                Name = "Instruction 1",
                Rank = 0
            });
            modelBuilder.Entity<Instruction>().HasData(
                new Instruction
                {
                    InstructionId = 1,
                    CreatedDate = DateTime.Now,
                    Title = "Present Perfect Tense Title",
                    Rank = 0
                }
                );
        }
    }
}
