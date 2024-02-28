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
    public class KindOfCarRepostry : Repostry<KindOfCar>,IKindOfCarRepostry
    {
        private readonly ApplicationDbContext _context;
        public KindOfCarRepostry(ApplicationDbContext db) : base(db)
        {
            _context = db;
        }

        public void Update(KindOfCar obj)
        {
            _context.KindOfCars.Update(obj);
        }
    }
}
