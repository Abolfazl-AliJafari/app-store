using app_store.Domain.Entities.Users;
using app_store.Domain.Entities.Users.ValueObjects;
using app_store.Infrastructure.SqlServer.Conversions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_store.Infrastructure.SqlServer.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        #region Methods
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.UserName)
                .IsUnique();

            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode()
                .HasConversion(new FirstNameToString());
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode()
                .HasConversion(new LastNameToString());
            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(40)
                .HasConversion(new UserNameToString());
            builder.Property(x=>x.Password)
                .IsRequired()
                .HasMaxLength(32)
                .IsUnicode()
                .HasConversion(new PasswordToString());
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200);
        }
        #endregion
    }
}
