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
                {   ThemeID = 1,
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
                SectionID = 1,
                Title = "1A",
                CreatedDate = DateTime.Now,
                Rank = 0

            });
            modelBuilder.Entity<Content>().HasData(
            new Content{
                ContentID=1,
                Category = Category.GrammarTips,
                CreatedDate = DateTime.Now,
                Name = "Present Perfect T.",
                Rank=0
            });
            modelBuilder.Entity<ContentDetail>().HasData(
            new ContentDetail{
                ContentDetailID = 1,
                ContentType = ContentType.Instruction,
                CreatedDate = DateTime.Now,
                Name = "Instruction 1",
                Rank = 0
            });
            modelBuilder.Entity<Instruction>().HasData(
                new Instruction
                {
                    InstructionID = 1,
                    CreatedDate = DateTime.Now,
                    Title = "Present Perfect Tense Title",
                    Info = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras laoreet pharetra tortor. Curabitur sed ante at urna interdum viverra in id augue. Fusce ligula est, imperdiet in ipsum at, varius volutpat quam. Cras ac arcu semper, condimentum massa eget, gravida orci. Morbi cursus leo vitae mi malesuada dignissim. Phasellus pellentesque massa lobortis ex vestibulum ultrices. Praesent posuere quis elit at euismod. Cras vel sem quis ipsum consequat lobortis. Pellentesque tristique elementum enim sit amet ultricies. Etiam in elit sed metus placerat blandit. Aenean ut faucibus enim. In at feugiat dolor. Donec eu euismod elit, quis maximus erat. Integer at ultrices tortor. Etiam aliquam odio tellus, vel ullamcorper velit tempus in. Curabitur iaculis libero sem, nec laoreet augue rutrum vitae. ",
                    Rank = 0
                }
                );
        }
    }
}
