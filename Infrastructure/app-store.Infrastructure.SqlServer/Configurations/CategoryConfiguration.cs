using app_store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app_store.Infrastructure.SqlServer.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        #region Methods
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Title)
                .IsUnique();

            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();
            builder.HasOne(x => x.MainCategory)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.MainCategoryId);
                //.OnDelete(DeleteBehavior.Cascade); 
        }
        #endregion
    }
}
