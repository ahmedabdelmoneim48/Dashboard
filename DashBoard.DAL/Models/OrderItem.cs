using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.DAL.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }  // Foreign Key to Order
        public Order Order { get; set; }  // Navigation property to Order
        [Required]
        public int ProductId { get; set; }  // Foreign Key to Product
        public Products Product { get; set; }  // Navigation property to Product
        [Required]
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }  // Price at the time of order
    }
}
