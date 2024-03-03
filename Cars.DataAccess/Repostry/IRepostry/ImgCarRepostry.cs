using Cars.DataAccess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DataAccess.Repostry.IRepostry
{
    public class ImgCarRepostry : Repostry<CarImg>,IImgCarRepostry
    {
        private readonly ApplicationDbContext _context;
        public ImgCarRepostry(ApplicationDbContext db) : base(db)
        {
            _context = db;
        }

        public void Update(CarImg obj)
        {
            _context.CarImgs.Update(obj);
        }
    }
}
