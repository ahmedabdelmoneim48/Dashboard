using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashBoard.DAL.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }  // Foreign Key to User

        public User User { get; set; }  // Navigation property to User

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Pending";  // Example status (could be Pending, Completed, etc.)

        // Navigation property to OrderItems (Many-to-Many relationship with Products)
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; } = 0.0m;
    }
}
