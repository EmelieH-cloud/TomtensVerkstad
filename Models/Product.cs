using System.ComponentModel.DataAnnotations;

namespace TomtensVerkstad.Models
{
    // Produkter som kan ingå i en order. 
    public class Product
    {
        [Key]
        public int ProductId { get; set; } // Primary key 
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }

        // Navigation prop 1:N 
        public List<OrderProduct>? Orderproducts { get; set; } = new List<OrderProduct>();

        public override string ToString()
        {

            return $"Product ID: {ProductId}, Name: {Name}, Price: {Price}";
        }

    }
}
