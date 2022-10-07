using System;
using LearnEnglish.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnEnglish.ModelConfig
{
    public class CategoryCFG : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { CategoryId=1, Name="Grammar Tips _1", Rank=0, CreatedDate=DateTime.Now, CategoryType=CategoryType.GrammarTips,  SectionId=1 },
                new Category { CategoryId=2, Name="Vocabulary", Rank=0, CreatedDate=DateTime.Now, CategoryType=CategoryType.GrammarTips, SectionId=1 }
                );
        }
    }
}
