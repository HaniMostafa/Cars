using Cars.DataAccess.Data;
using Cars.DataAccess.Repostry.IRepostry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DataAccess.Repostry
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public KindOfCarRepostry KindCar { get; private set; }
        public CarRepostry car { get; private set; }
        public OwnerRepostry owner { get; private set; }


        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            KindCar=new KindOfCarRepostry(_db);
            car=new CarRepostry(_db);
            owner=new OwnerRepostry(_db);
        }

      
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
