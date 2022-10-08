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
            Id = new Guid("7d0f8501-a76c-4f1c-90ad-5ef95b93dee1"),
            Login = "admin",
            Password = "admin",
            IsAdmin = true
        });
        builder.HasData(new Account()
        {
            Id = new Guid("c040c031-c485-4925-942a-c7cdbef231fa"),
            Login = "user",
            Password = "user",
            IsAdmin = false
        });
    }
}