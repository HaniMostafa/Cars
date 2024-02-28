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
    public class OwnerRepostry : Repostry<Owner>, IOwnerRepostry
    {
        private readonly ApplicationDbContext _context;
        public OwnerRepostry(ApplicationDbContext db) : base(db)
        {
            _context = db;
        }

        public void Update(Owner obj)
        {
            _context.Owners.Update(obj);
        }
    }
}
