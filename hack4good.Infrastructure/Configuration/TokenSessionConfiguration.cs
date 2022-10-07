using hack4good.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hack4good.Infrastructure.Configuration;

public class TokenSessionConfiguration : IEntityTypeConfiguration<TokenSession>
{
    public void Configure(EntityTypeBuilder<TokenSession> builder)
    {
        builder.HasKey(a => a.Id);

        builder
            .HasOne(t => t.Account)
            .WithMany(a => a.TokenSessions)
            .HasForeignKey(t => t.AccountId);

        builder.Ignore(t => t.ValidUntil);
    }
}