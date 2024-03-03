using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
namespace Cars.DataAccess.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public DbSet<KindOfCar> KindOfCars { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<CarImg> CarImgs { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>option) :base(option)
        {
                
        }
    }
}
