using System;
using LearnEnglish.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearnEnglish.ModelConfig
{
    public class InstructionCFG : IEntityTypeConfiguration<Instruction>
    {
        public void Configure(EntityTypeBuilder<Instruction> builder)
        {
            builder.HasData(
                new Instruction { InstructionId=1, Title="Present Perfect T. part-1", CreatedDate=DateTime.Now },
                new Instruction { InstructionId=2, Title="Present Perfect T. part-2", CreatedDate=DateTime.Now }
                );
        }
    }
}
