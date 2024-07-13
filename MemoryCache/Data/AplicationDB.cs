using MemoryCache.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryCache.Data
{
    public class AplicationDB : DbContext
    {
        public AplicationDB(DbContextOptions<AplicationDB> options) : base(options)
        {
        }
        public DbSet<Product> products { get; set; }
    }
}
