using app_store.Domain.Entities;
using app_store.Infrastructure.SqlServer.Conversions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app_store.Infrastructure.SqlServer.Configurations
{
    internal class AppConfiguration : IEntityTypeConfiguration<App>
    {
        #region Methods
        public void Configure(EntityTypeBuilder<App> builder)
        {
            builder.ToTable("Apps");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Title)
                .IsUnique();

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode();
            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(500)
                .IsUnicode();
            builder.Property(x => x.PhotosGallery)
                .IsUnicode(false)
                .HasConversion(new GuidArrayToString());

            builder.HasOne(x => x.Icon)
                .WithMany()
                .HasForeignKey(x => x.IconId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.AppFile)
              .WithMany()
              .HasForeignKey(x => x.AppFileId)
              .OnDelete(DeleteBehavior.Restrict);
        }
        #endregion
    }
}
