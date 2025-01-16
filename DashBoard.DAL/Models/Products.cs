using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.DAL.Models
{
    public class Products : BaseEntity
    {
        //public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
      
        public string Brand { get; set; } = string.Empty;
        public decimal Price { get; set; } 
        public string Description { get; set; } = string.Empty;
        
        public string ImageFileName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int OutOfStock { get; set; }

        // New BarCode property (string can be a barcode number or any identifier)
        public string BarCode { get; set; } = string.Empty;

        // New QRCodeImage property (this will store the base64 encoded QR code image)
        public string QRCodeImage { get; set; } = string.Empty;


        
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        public int? OfferId { get; set; }
        public Offers Offers { get; set; }

    }
}
