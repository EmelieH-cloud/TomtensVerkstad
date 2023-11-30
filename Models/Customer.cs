using System.ComponentModel.DataAnnotations;

namespace TomtensVerkstad.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; } // Primary key 
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        // Navigation property 1:N 
        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
