using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashBoard.DAL.Models
{
    public class Offers : BaseEntity
    {
        public string Name { get; set; }
        public string Descrption { get; set; } = string.Empty;
        public OfferType OfferType { get; set; } = OfferType.Discount;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddMonths(1);
        public decimal DiscountPercentage { get; set; }
        public bool? Active { get; set; } = false;
        public string ImageFileName { get; set; } = string.Empty;
        public string TermsConditions { get; set; } = string.Empty;
        public List<Products> Products { get; set; }
    }
}
