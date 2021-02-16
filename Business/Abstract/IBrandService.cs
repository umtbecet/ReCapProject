using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult AddToSystem(Brand brand);
        IResult UpdateToSystem(Brand brand);
        IResult DeleteToSystem(Brand brand);
        IDataResult<List<Brand>> GetAll();
        

    }
}
