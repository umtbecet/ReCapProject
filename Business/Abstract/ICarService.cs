using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetDailyPrice(decimal min, decimal max);
        List<Car> GetById(int id);
        void AddToSystem(Car car);
        void UpdateToSystem(Car car);
        void DeleteToSystem(Car car);
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);



    }
}
