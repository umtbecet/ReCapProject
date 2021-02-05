using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void AddToSystem(Brand brand)
        {
            if (brand.BrandName.Length>2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("The brand was successfully added");
            }
            else
            {
                Console.WriteLine("Please enter the brand name higher than 2 characters. ");
            }
        }

        public void DeleteToSystem(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }
                
        public void UpdateToSystem(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Delete(brand);
                Console.WriteLine("The brand was successfully deleted");
            }
            else
            {
                Console.WriteLine("Please enter the brand name higher than 2 characters. ");
            }
        }
    }
}
