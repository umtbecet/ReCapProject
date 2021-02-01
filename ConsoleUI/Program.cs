using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("-------------All Cars on System-------------");

            var carsFromSystem = carManager.GetAll();
            foreach (var car in carsFromSystem)
            {
                Console.WriteLine("\t\tÜrün Kodu: " + car.Id + " " + "\t\tMarka Kodu: " + car.BrandId+" "+ "\t\tRenk Kodu: "+ car.ColorId+" "+ "\t\tGünlük Ücret: "+car.DailyPrice+" "+ "\t\tAçıklama: "+car.Description);
            }

            Console.WriteLine("-------------Add Car - Update Car - Delete Car -------------");
            var car1 = new Car
            {
                Id=6,BrandId=4,ColorId=3,ModelYear=2009,DailyPrice=190,Description="Sedan"
            };
            var car2 = new Car
            {
                Id = 2,BrandId = 2,ColorId = 5,ModelYear = 2012,DailyPrice = 200,Description = "Sport"
            };

            carManager.AddToSystem(car1);
            carManager.UpdateToSystem(car2);
            carManager.DeleteToSystem(new Car { Id = 1 });
            var carsAll = carManager.GetAll();
            foreach (var car in carsAll)
            {
                Console.WriteLine("\t\tÜrün Kodu: " + car.Id + " " + "\t\tMarka Kodu: " + car.BrandId + " " + "\t\tRenk Kodu: " + car.ColorId + " " + "\t\tGünlük Ücret: " + car.DailyPrice + " " + "\t\tAçıklama: " + car.Description);
            }

            Console.WriteLine("-------------Get By Id -------------");

            carManager.GetByIdFromSystem(new Car { Id = 4 });

        }
    }
}
