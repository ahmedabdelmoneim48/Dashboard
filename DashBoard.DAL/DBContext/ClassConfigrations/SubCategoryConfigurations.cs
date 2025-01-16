using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DashBoard.DAL.Models;

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
            builder.Property(s => s.Descrption).IsRequired().HasMaxLength(255);
            builder.Property(s => s.ImageFileName).HasMaxLength(255).IsRequired(true);

            builder.HasOne(s => s.Category)
                   .WithMany(c => c.SubCategories)
                   .HasForeignKey(s => s.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();


        }
    }
}
