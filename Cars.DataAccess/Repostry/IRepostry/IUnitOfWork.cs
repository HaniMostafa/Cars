using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DataAccess.Repostry.IRepostry
{
    public interface IUnitOfWork
    {
        void Save();
        public KindOfCarRepostry KindCar { get;  }

    }
}
