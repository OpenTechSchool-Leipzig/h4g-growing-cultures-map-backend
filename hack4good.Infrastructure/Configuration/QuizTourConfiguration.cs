using hack4good.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hack4good.Infrastructure.Configuration;

public class QuizTourConfiguration : IEntityTypeConfiguration<QuizTour>
{
    public void Configure(EntityTypeBuilder<QuizTour> builder)
    {
        builder.HasKey(q => q.Id);
    }
}