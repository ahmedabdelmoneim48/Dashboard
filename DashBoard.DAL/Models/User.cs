using System.ComponentModel.DataAnnotations;

namespace DashBoard.DAL.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty; // In real-world apps, don't store plain text passwords

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property to Orders (One-to-Many relationship)
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
