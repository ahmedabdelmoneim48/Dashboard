using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCategoryDashBoard.Models;

namespace ProductCategoryDashBoard.DBContext.ClassConfigrations
{
    public class SubCategoryConfigurations : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name).IsRequired().HasMaxLength(255);
            builder.Property(s => s.Active).IsRequired(false).HasDefaultValue(true);
            builder.Property(s => s.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Configure relationships
            builder.HasOne(s => s.Category)
                   .WithMany(c => c.SubCategories)
                   .HasForeignKey(s => s.CategoryId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s => s.Products)
                   .WithOne(p => p.SubCategory)
                   .HasForeignKey(p => p.SubCategoryId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
