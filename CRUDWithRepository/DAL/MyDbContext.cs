using CRUDWithRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithRepository.DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}