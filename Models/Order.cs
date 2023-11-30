using System.ComponentModel.DataAnnotations;

namespace TomtensVerkstad.Models
{
    // En order som kan läggas av en kund. 
    public class Order
    {
        [Key]
        public int OrderId { get; set; } // Primary key 
        public int CustomerId { get; set; } // Foreign key 
        public Customer Customer { get; set; } = null!; // Navigation prop 
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } = null!;

        // Navigation prop 1:N 
        public List<OrderProduct> Orderproducts { get; set; } = new List<OrderProduct>();

    }
}
