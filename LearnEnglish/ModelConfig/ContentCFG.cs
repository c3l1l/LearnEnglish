using System;
using LearnEnglish.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnEnglish.ModelConfig
{
    public class ContentCFG : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.HasData(
                new Content { ContentId=1, Title="Present Perfect T.", Rank=0, ContentType=ContentType.Instruction, CreatedDate=DateTime.Now, CategoryId=1},
                new Content { ContentId=2, Title="Conjunctions", Rank=1, ContentType=ContentType.Instruction, CreatedDate=DateTime.Now, CategoryId=1}

                );
        }
    }
}
