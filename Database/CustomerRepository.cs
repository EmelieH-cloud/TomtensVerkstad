using Microsoft.EntityFrameworkCore;

namespace TomtensVerkstad.Database
{
    public class CustomerRepository<T> where T : class
    {
        private readonly MyDbContext _context;
        private readonly DbSet<T> _dbSet;

        public CustomerRepository(MyDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);

            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }

        }


    }



}

