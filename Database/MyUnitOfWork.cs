using TomtensVerkstad.Models;

namespace TomtensVerkstad.Database
{
    public class MyUnitOfWork
    {

        public CustomerRepository<Customer> CustomerRepository { get; }
        public OrderRepository<Order> OrderRepository { get; }
        public ProductRepository<Product> ProductRepository { get; }
        public OrderProductsRepository<OrderProduct> OrderProductRepository { get; }

        private readonly MyDbContext _DBcontext;

        public MyUnitOfWork(MyDbContext context)
        {
            _DBcontext = context;
            CustomerRepository = new(context);
            OrderRepository = new(context);
            ProductRepository = new(context);
            OrderProductRepository = new(context);
        }

        public async Task Complete()
        {
            await _DBcontext.SaveChangesAsync();
        }
    }
}
