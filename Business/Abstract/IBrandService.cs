using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        void AddToSystem(Brand brand);
        void UpdateToSystem(Brand brand);
        void DeleteToSystem(Brand brand);
        List<Brand> GetAll();
        

    }
}
