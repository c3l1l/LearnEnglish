using System;
using LearnEnglish.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnEnglish.ModelConfig
{
    public class ThemeCFG : IEntityTypeConfiguration<Theme>
    {
        public void Configure(EntityTypeBuilder<Theme> builder)
        {
            builder.HasData(
                new Theme { ThemeId=1, Title= "Theme-1", CreatedDate=DateTime.Now, IsActive=1, Level=Levels.A1, Rank=0},
                new Theme { ThemeId=2, Title= "Theme-2", CreatedDate=DateTime.Now, IsActive=1, Level=Levels.A1, Rank=1}
                );
        }
    }
}
