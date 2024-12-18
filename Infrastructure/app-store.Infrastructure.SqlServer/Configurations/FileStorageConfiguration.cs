using app_store.Domain.Entities;
using app_store.Infrastructure.SqlServer.Conversions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app_store.Infrastructure.SqlServer.Configurations
{
    public class FileStorageConfiguration : IEntityTypeConfiguration<FileStorage>
    {
        #region Methods
        public void Configure(EntityTypeBuilder<FileStorage> builder)
        {
            builder.ToTable("FileStorages");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.FileName)
                .IsUnique();

            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();
            builder.Property(x => x.FileName)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode();
            builder.Property(x => x.ContentType)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(x => x.FileSize)
                .IsRequired();

            builder.Property(x => x.Providers)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasConversion(new ProvidersEnumToString());
        }
        #endregion
    }
}
