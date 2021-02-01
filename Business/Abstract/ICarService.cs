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
        void AddToSystem(Car car);
        void UpdateToSystem(Car car);
        void DeleteToSystem(Car car);
        void GetByIdFromSystem(Car car);
    }
}
