using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
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
        [ValidationAspect(typeof(BrandValidator))]
        public IResult AddToSystem(Brand brand)
        {
            if (brand.BrandName.Length<=2)
            {                
                return new ErrorResult(Messages.BrandNameMinCharacter);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult DeleteToSystem(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {            
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }
                
        public IResult UpdateToSystem(Brand brand)
        {
            if (brand.BrandName.Length <= 2)
            {
                return new ErrorResult(Messages.CarMinPrice);
                
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
