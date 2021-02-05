using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Abstract
{
    public interface ICarDal: IEntityRepository<Car>
    {               
                
    }
}
