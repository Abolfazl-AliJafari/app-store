using app_store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_store.Infrastructure.SqlServer.Configurations
{
    public class ProducerConfiguration : IEntityTypeConfiguration<Producer>
    {
        #region Methods
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.ToTable("Producers");
            builder.HasKey(x => x.Id);  
            builder.HasIndex(x => x.Title)
                .IsUnique();

            builder.Property(x => x.Id)
               .ValueGeneratedOnAdd();
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();
            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(500)
                .IsUnicode();
            builder.Property(x => x.Email)
                .IsRequired(false)
                .HasMaxLength(200);
        }
        #endregion
    }
}
