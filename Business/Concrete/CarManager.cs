using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public void AddToSystem(Car car)
        {
            _carDal.Add(car);
        }

        public void DeleteToSystem(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void GetByIdFromSystem(Car car)
        {
            _carDal.GetById(car);
        }

        public void UpdateToSystem(Car car)
        {
            _carDal.Update(car);
        }
    }
}
