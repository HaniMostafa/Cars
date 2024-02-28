using Microsoft.EntityFrameworkCore;
using Models;
namespace Cars.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<KindOfCar> KindOfCars { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>option) :base(option)
        {
                
        }
    }
}
