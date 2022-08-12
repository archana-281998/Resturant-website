
using Microsoft.EntityFrameworkCore;
using Application7.Web.Models;
namespace Application7.Web.Data
{
    public class ApplicationDbContext:DbContext
    {


        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderMenu> OrderMenus { get; set; }
        public DbSet<Guest> Guests{ get; set; }
        public DbSet<OrderInformation> OrderInformation { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
    }
}
