using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DashBoard.DAL.Models;
using DashBoard.DAL.DBContext;

namespace DashBoard.DAL.DBContext.ClassConfigrations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
            builder.Property(c => c.Active).IsRequired(false).HasDefaultValue(true);
            builder.Property(c => c.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(c => c.Descrption).IsRequired(true).HasMaxLength(255);
            builder.Property(c => c.ImageFileName).HasMaxLength(255).IsRequired(true);

        }

    }
}
