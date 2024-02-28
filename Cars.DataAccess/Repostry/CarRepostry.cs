using Cars.DataAccess.Data;
using Cars.DataAccess.Repostry.IRepostry;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DataAccess.Repostry
{
    public class CarRepostry : Repostry<Car>,ICarRepostry
    {
        private readonly ApplicationDbContext _context;
        public CarRepostry(ApplicationDbContext db) : base(db)
        {
            _context = db;
        }

        public void Update(Car obj)
        {
            _context.Cars.Update(obj);
        }
    }
}
