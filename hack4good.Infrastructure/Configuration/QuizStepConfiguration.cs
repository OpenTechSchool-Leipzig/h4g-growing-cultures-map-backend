using hack4good.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hack4good.Infrastructure.Configuration;

public class QuizStepConfiguration : IEntityTypeConfiguration<QuizStep>
{
    public void Configure(EntityTypeBuilder<QuizStep> builder)
    {
        builder.HasKey(s => s.Id);

        builder
            .HasOne(s => s.QuizTour)
            .WithMany(q => q.Steps)
            .HasForeignKey(s => s.QuizId);
    }
}