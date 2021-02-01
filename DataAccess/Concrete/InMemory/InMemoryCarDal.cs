using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DataAccess.Concrete.InMemory
{
    
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id=1, BrandId=1, ColorId=1,ModelYear=2020, DailyPrice=250, Description="Sport "},
                new Car { Id=2, BrandId=2, ColorId=1,ModelYear=2017, DailyPrice=220, Description="Sedan"},
                new Car { Id=3, BrandId=1, ColorId=1,ModelYear=2019, DailyPrice=200, Description="Station Wagon"},
                new Car { Id=4, BrandId=3, ColorId=1,ModelYear=2018, DailyPrice=235, Description="Hatchback"},
                new Car { Id=5, BrandId=3, ColorId=1,ModelYear=2020, DailyPrice=290, Description="SUV"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
            
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void GetById(Car car)
        {
            //var carToGetById = _cars.First(p => p.Id == car.Id);
            var carToGetById = _cars.FirstOrDefault(p => p.Id == car.Id);
            if (carToGetById != null)
            {
                Console.WriteLine("\t\tÜrün Kodu: " + carToGetById.Id + " " + "\t\tMarka Kodu: " + carToGetById.BrandId + " " + "\t\tRenk Kodu: " + carToGetById.ColorId + " " + "\t\tGünlük Ücret: " + carToGetById.DailyPrice + " " + "\t\tAçıklama: " + carToGetById.Description);
                
            }


        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);

            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
