using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.DataAccess.Repostry.IRepostry
{
    public interface IKindOfCarRepostry:IRepostry<KindOfCar>
    {
        void Update(KindOfCar obj);
    }
}
