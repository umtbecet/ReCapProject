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
            //CarAddTest();
            //CarUpdateTest();
            //CarDeleteTest();
            //CarGetAllTest();
            //CarGetAllDetailsTest();
            //CarGetByIdTest();      
            //CarGetByBrandIdTest(); 
            //CarGetByColorIdTest(); 
            //CarGetAllColorTest(); 
            //CarGetAllBrandTest(); 

        }

        private static void CarGetAllBrandTest()
        {            
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("-------------Get All Brand Name -------------");
            var Brand = brandManager.GetAll();
            foreach (var brand in Brand)
            {
                Console.WriteLine("\t\tMarka Kodu: " + brand.BrandId + " " + "\t\tMarka Adı: " + brand.BrandName);
            }
        }

        private static void CarGetAllColorTest()
        {            
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("-------------Get All Color Name -------------");
            var Color = colorManager.GetAll();
            foreach (var color in Color)
            {
                Console.WriteLine("\t\tRenk Kodu: " + color.ColorId + " " + "\t\tRenk Adı: " + color.ColorName);
            }
        }

        private static void CarGetByColorIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            Console.WriteLine("-------------Get Cars Color Id -------------");
            foreach (var car in carManager.GetCarsByColorId(5))
            {
                Console.WriteLine("\t\tÜrün Kodu: " + car.Id + " " + "\t\tMarka Kodu: " + car.BrandId + " " + "\t\tRenk Kodu: " + car.ColorId + " " + "\t\tModel Yılı: " + car.ModelYear + " " + "\t\tGünlük Ücret: " + car.DailyPrice + " " + "\t\tAçıklama: " + car.Description);
            }
        }

        private static void CarGetByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            Console.WriteLine("-------------Get Cars Brand Id -------------");
            foreach (var car in carManager.GetCarsByBrandId(4))
            {
                Console.WriteLine("\t\tÜrün Kodu: " + car.Id + " " + "\t\tMarka Kodu: " + car.BrandId + " " + "\t\tRenk Kodu: " + car.ColorId + " " + "\t\tModel Yılı: " + car.ModelYear + " " + "\t\tGünlük Ücret: " + car.DailyPrice + " " + "\t\tAçıklama: " + car.Description);
            }
        }

        private static void CarGetByIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("-------------Get By Id -------------");

            foreach (var car in carManager.GetById(5))
            {
                Console.WriteLine("\t\tÜrün Kodu: " + car.Id + " " + "\t\tMarka Kodu: " + car.BrandId + " " + "\t\tRenk Kodu: " + car.ColorId + " " + "\t\tModel Yılı: " + car.ModelYear + " " + "\t\tGünlük Ücret: " + car.DailyPrice + " " + "\t\tAçıklama: " + car.Description);
            }
        }

        private static void CarDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.DeleteToSystem(new Car { Id = 4 });
        }

        private static void CarUpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var car2 = new Car
            {
                Id = 2,
                BrandId = 3,
                ColorId = 4,
                ModelYear = 2018,
                DailyPrice = 250,
                Description = "Automatic Gasoline"
            };


            carManager.UpdateToSystem(car2);
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("-------------Add Car - Update Car - Delete Car -------------");
            var car1 = new Car
            {
                Id = 8,
                BrandId = 4,
                ColorId = 3,
                ModelYear = 2009,
                DailyPrice = 190,
                Description = "Automatic Gasoline"
            };


            carManager.AddToSystem(car1);
        }

        private static void CarGetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("-------------All Cars on System-------------");

            var carsFromSystem = carManager.GetAll();
            foreach (var car in carsFromSystem)
            {
                Console.WriteLine("\t\tÜrün Kodu: " + car.Id + " " + "\t\tMarka Kodu: " + car.BrandId + " " + "\t\tRenk Kodu: " + car.ColorId + " " + "\t\tGünlük Ücret: " + car.DailyPrice + " " + "\t\tAçıklama: " + car.Description);
            }
        }
        private static void CarGetAllDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("-------------All Cars on System-------------");

            var carsFromSystem = carManager.GetCarDetails();
            foreach (var car in carsFromSystem)
            {
                Console.WriteLine("\t\tÜrün Kodu: " + car.Id + " " + "\t\tMarka Kodu: " + car.BrandName + " " + "\t\tRenk Kodu: " + car.ColorName + " " + "\t\tGünlük Ücret: " + car.DailyPrice + " " + "\t\tAçıklama: " + car.Description);
            }
        }
    }
}
