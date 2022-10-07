using hack4good.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hack4good.Infrastructure.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id).ValueGeneratedOnAdd();

        builder.HasIndex(a => a.Login).IsUnique();

        builder.HasData(new Account()
        {
            Id = Guid.NewGuid(),
            Login = "admin",
            Password = "admin",
            IsAdmin = true
        });
        builder.HasData(new Account()
        {
            Id = Guid.NewGuid(),
            Login = "user",
            Password = "user",
            IsAdmin = false
        });
    }
}