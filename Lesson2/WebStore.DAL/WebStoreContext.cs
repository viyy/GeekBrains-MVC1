using Microsoft.EntityFrameworkCore;
using WebStore.DomainModels.Entities.Classes;

namespace WebStore.DAL
{
    public class WebStoreContext : DbContext
    {
        public WebStoreContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Brand> Brands { get; set; }

    }
}