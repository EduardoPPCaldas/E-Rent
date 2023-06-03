using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id);
        builder.Property(x => x.Email);
        builder.Property(x => x.Name);
        builder.Property(x => x.LastName);
        builder.Property(x => x.Password);
    }
}
