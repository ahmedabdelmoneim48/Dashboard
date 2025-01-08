using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCategoryDashBoard.Models;

namespace ProductCategoryDashBoard.DBContext.ClassConfigrations
{
    public class ProductsConfigrations : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.OutOfStock).HasDefaultValue(0);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500  );
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");


            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.SubCategory)
                   .WithMany(s => s.Products)
                   .HasForeignKey(p => p.SubCategoryId)
                   .IsRequired(false)  
                   .OnDelete(DeleteBehavior.SetNull);  
        }
    
    }
}
