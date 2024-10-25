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

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(u => u.Salt)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
