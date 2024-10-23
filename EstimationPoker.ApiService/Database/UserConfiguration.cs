using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EstimationPoker.ApiService.Models;

namespace EstimationPoker.ApiService.Database
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .IsRequired();

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasData(
                new User { Id = 1, Name = "John Doe" });
        }
    }
}
