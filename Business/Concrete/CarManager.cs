using Business.Abstract;
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

        public void AddToSystem(Car car)
        {
            if (car.DailyPrice>0)
            {
                _carDal.Add(car);
                Console.WriteLine("The car was successfully added");
            }
            else
            {
                Console.WriteLine($"Please enter the daily price higher than 0. The value you entered : {car.DailyPrice}");
            }
            
        }

        public void DeleteToSystem(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("The car was successfully deleted");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
                
        public List<Car> GetDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(p=>p.DailyPrice>=min && p.DailyPrice<=max);
        }

        public void UpdateToSystem(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                Console.WriteLine("The car was successfully updated");
            }
            else
            {
                Console.WriteLine($"Please enter the daily price higher than 0. The value you entered : {car.DailyPrice}");
            }

        }

        public List<Car> GetById(int id)
        {
            return _carDal.GetAll(p => p.Id == id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
