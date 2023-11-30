using System.ComponentModel.DataAnnotations;

namespace TomtensVerkstad.Models
{
    // Länkar ihop en specifik produkt med en specifik order 
    public class OrderProduct
    {
        [Key]
        public int OrderProductId { get; set; } // Primary key 
        public int Quantity { get; set; }
        public Order Order { get; set; } = null!; // navigation prop
        public Product Product { get; set; } = null!; // navigation prop 
        public int OrderId { get; set; }  // Foreign key 
        public int ProductId { get; set; } // Foreign key 
    }

}
