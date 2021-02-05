using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());


            Console.WriteLine("-------------All Cars on System-------------");

            var carsFromSystem = carManager.GetAll();
            foreach (var car in carsFromSystem)
            {
                Console.WriteLine("\t\tÜrün Kodu: " + car.Id + " " + "\t\tMarka Kodu: " + car.BrandId+" "+ "\t\tRenk Kodu: "+ car.ColorId+" "+ "\t\tGünlük Ücret: "+car.DailyPrice+" "+ "\t\tAçıklama: "+car.Description);
            }

            
            Console.WriteLine("-------------Add Car - Update Car - Delete Car -------------");
            var car1 = new Car
            {
                Id=7,BrandId=4,ColorId=3,ModelYear=2009,DailyPrice=190,Description="Sedan"
            };
            var car2 = new Car
            {
                Id = 2,BrandId = 8,ColorId = 5,ModelYear = 2012,DailyPrice = 200,Description = "Automatic Gasoline"
            };

            carManager.AddToSystem(car1);
            carManager.UpdateToSystem(car2);
            carManager.DeleteToSystem(new Car { Id = 4 });
            var carsAll = carManager.GetAll();
            foreach (var car in carsAll)
            {
                Console.WriteLine("\t\tÜrün Kodu: " + car.Id + " " + "\t\tMarka Kodu: " + car.BrandId + " " + "\t\tRenk Kodu: " + car.ColorId + " " + "\t\tGünlük Ücret: " + car.DailyPrice + " " + "\t\tAçıklama: " + car.Description);
            }
            
            Console.WriteLine("-------------Get By Id -------------");
                                   
            foreach (var car in carManager.GetById(2))
            {
                Console.WriteLine("\t\tÜrün Kodu: " + car.Id + " " + "\t\tMarka Kodu: " + car.BrandId + " " + "\t\tRenk Kodu: " + car.ColorId + " " + "\t\tModel Yılı: " + car.ModelYear +" "+ "\t\tGünlük Ücret: "  + car.DailyPrice + " " + "\t\tAçıklama: " + car.Description);
            }
            
            Console.WriteLine("-------------Get Cars Brand Id -------------");
            foreach (var car in carManager.GetCarsByBrandId(4))
            {
                Console.WriteLine("\t\tÜrün Kodu: " + car.Id + " " + "\t\tMarka Kodu: " + car.BrandId + " " + "\t\tRenk Kodu: " + car.ColorId + " " + "\t\tModel Yılı: " + car.ModelYear + " " + "\t\tGünlük Ücret: " + car.DailyPrice + " " + "\t\tAçıklama: " + car.Description);
            }

            Console.WriteLine("-------------Get Cars Color Id -------------");
            foreach (var car in carManager.GetCarsByColorId(5))
            {
                Console.WriteLine("\t\tÜrün Kodu: " + car.Id + " " + "\t\tMarka Kodu: " + car.BrandId + " " + "\t\tRenk Kodu: " + car.ColorId + " " + "\t\tModel Yılı: " + car.ModelYear + " " + "\t\tGünlük Ücret: " + car.DailyPrice + " " + "\t\tAçıklama: " + car.Description);
            }  
            
            Console.WriteLine("-------------Get All Color Name -------------");
            var Color = colorManager.GetAll();
            foreach (var color in Color)
            {
                Console.WriteLine("\t\tRenk Kodu: " + color.ColorId + " " + "\t\tRenk Adı: " + color.ColorName);
            }

            Console.WriteLine("-------------Get All Brand Name -------------");
            var Brand = brandManager.GetAll();
            foreach (var brand in Brand)
            {
                Console.WriteLine("\t\tMarka Kodu: " + brand.BrandId + " " + "\t\tMarka Adı: " + brand.BrandName);
            }
            
        }
    }
}
