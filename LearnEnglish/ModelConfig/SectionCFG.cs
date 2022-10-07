using System;
using LearnEnglish.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnEnglish.ModelConfig
{
    public class SectionCFG : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasData(
                new Section { SectionId=1, Title="1A", CreatedDate=DateTime.Now, Rank=0, ThemeId=1},
                new Section { SectionId=2, Title="2A", CreatedDate=DateTime.Now, Rank=1, ThemeId=1}
                );
        }
    }
}
