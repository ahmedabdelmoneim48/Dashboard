using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashBoard.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DashBoard.DAL.DBContext.ClassConfigrations
{
    public class OffersConfigrations : IEntityTypeConfiguration<Offers>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Offers> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(255).IsRequired();
            builder.Property(c => c.Active).HasDefaultValue(false).IsRequired(true);
            builder.Property(c => c.StartDate).HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired(true);
            builder.Property(c => c.EndDate).HasDefaultValueSql("CURRENT_TIMESTAMP").IsRequired(true);
            builder.Property(c => c.Descrption).HasMaxLength(255).IsRequired(true);
            builder.Property(c => c.DiscountPercentage).HasPrecision(18,2).IsRequired(true);
            builder.Property(c => c.ImageFileName).HasMaxLength(255).IsRequired(false);
            builder.Property(c => c.OfferType).HasMaxLength(255).IsRequired(true);
            builder.Property(c => c.TermsConditions).HasMaxLength(255).IsRequired(false);


        }
    }
}
