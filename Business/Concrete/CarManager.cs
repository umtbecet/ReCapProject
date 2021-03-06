﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult AddToSystem(Car car)
        {
            if (car.DailyPrice<=0)
            {
                return new ErrorResult(Messages.CarMinPrice);
                
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
            
        }

        public IResult DeleteToSystem(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
            
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }
                
        public IDataResult<List<Car>> GetDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p=>p.DailyPrice>=min && p.DailyPrice<=max));
        }

        public IResult UpdateToSystem(Car car)
        {
            if (car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.CarMinPrice);
                
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);

        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
                
    }
}
