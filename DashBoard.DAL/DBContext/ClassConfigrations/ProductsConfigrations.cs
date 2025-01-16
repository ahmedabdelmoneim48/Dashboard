using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DashBoard.DAL.Models;
using DashBoard.DAL.DBContext;


namespace DashBoard.DAL.DBContext.ClassConfigrations
{
    public class ProductsConfigrations : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Price).HasPrecision(5,2).IsRequired();
            builder.Property(p => p.OutOfStock).HasDefaultValue(0);
            builder.Property(p => p.Description).HasMaxLength(500).IsRequired();
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(P => P.ImageFileName).HasMaxLength(255).IsRequired(false);
            builder.Property(p => p.Brand).HasMaxLength(100).IsRequired();


            builder.Property(p => p.BarCode).HasMaxLength(255).IsRequired();
            builder.Property(p => p.QRCodeImage).HasMaxLength(4000); // To store base64 encoded QR code image


            builder.HasOne(p => p.SubCategory)
                   .WithMany(s => s.Products)
                   .HasForeignKey(p => p.SubCategoryId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired(true);

            builder.HasOne(P => P.Offers)
                   .WithMany(O => O.Products)
                   .HasForeignKey(P => P.OfferId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired(false);
        }

    }
}
