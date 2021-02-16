using Business.Abstract;
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
            //CustomerManagerTest();
            //RentalManagerTest();


            UserManagerTest();



        }
        private static void UserManagerTest()
        {
            Console.WriteLine("-------------User Manager Test-------------");
            UserManager userManager = new UserManager(new EfUserDal());

            var result = userManager.GetAll();

            if (result.Success == true)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.FirstName + " " + user.LastName + " " + user.Email + " " + user.Password);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void CustomerManagerTest()
        {
            Console.WriteLine("-------------Customer Manager Test-------------");
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = customerManager.GetAll();

            if (result.Success == true)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine(customer.CustomerName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }


        private static void RentalManagerTest()
        {
            Console.WriteLine("-------------Rental Manager Test-------------");
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.GetAll();          
            
            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("\t\tAraç Kodu: " + rental.CarId + " " + "\t\tMüşteri Kodu: " + rental.CustomerId + " " + "\t\tTarih: " + rental.RentDate + " " + "\t\tIade Tarihi: " + rental.ReturnDate);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }



        private static void CarGetAllBrandTest()
        {            
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("-------------Get All Brand Name -------------");
            var result = brandManager.GetAll();
            if (result.Success==true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine("\t\tMarka Kodu: " + brand.BrandId + " " + "\t\tMarka Adı: " + brand.BrandName);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void CarGetAllColorTest()
        {            
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("-------------Get All Color Name -------------");
            var result = colorManager.GetAll();
            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine("\t\tRenk Kodu: " + color.ColorId + " " + "\t\tRenk Adı: " + color.ColorName);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void CarGetByColorIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            Console.WriteLine("-------------Get Cars Color Id -------------");
            var result = carManager.GetCarsByColorId(5);
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                   Console.WriteLine("\t\tÜrün Kodu: " + car.Id + " " + "\t\tMarka Kodu: " + car.BrandId + " " + "\t\tRenk Kodu: " + car.ColorId + " " + "\t\tModel Yılı: " + car.ModelYear + " " + "\t\tGünlük Ücret: " + car.DailyPrice + " " + "\t\tAçıklama: " + car.Description);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void CarGetByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            Console.WriteLine("-------------Get Cars Brand Id -------------");
            var result = carManager.GetCarsByBrandId(4);
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("\t\tÜrün Kodu: " + car.Id + " " + "\t\tMarka Kodu: " + car.BrandId + " " + "\t\tRenk Kodu: " + car.ColorId + " " + "\t\tModel Yılı: " + car.ModelYear + " " + "\t\tGünlük Ücret: " + car.DailyPrice + " " + "\t\tAçıklama: " + car.Description);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void CarGetByIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("-------------Get By Id -------------");
            var result = carManager.GetById(5);
            if (result.Success==true)
            {                
               Console.WriteLine("\t\tÜrün Kodu: " + result.Data.Id + " " + "\t\tMarka Kodu: " + result.Data.BrandId + " " + "\t\tRenk Kodu: " + result.Data.ColorId + " " + "\t\tModel Yılı: " + result.Data.ModelYear + " " + "\t\tGünlük Ücret: " + result.Data.DailyPrice + " " + "\t\tAçıklama: " + result.Data.Description);
               
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void CarDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.DeleteToSystem(new Car { Id = 4 });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
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


            var result = carManager.UpdateToSystem(car2);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("-------------Add Car - Update Car - Delete Car -------------");
            var car1 = new Car
            {
                Id = 9,
                BrandId = 4,
                ColorId = 3,
                ModelYear = 2009,
                DailyPrice = 190,
                Description = "Automatic Gasoline"
            };


            var result =carManager.AddToSystem(car1);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarGetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("-------------All Cars on System-------------");

            var carsFromSystem = carManager.GetAll();
            if (carsFromSystem.Success == true)
            {
                foreach (var car in carsFromSystem.Data)
                {
                    Console.WriteLine("\t\tÜrün Kodu: " + car.Id + " " + "\t\tMarka Kodu: " + car.BrandId + " " + "\t\tRenk Kodu: " + car.ColorId + " " + "\t\tGünlük Ücret: " + car.DailyPrice + " " + "\t\tAçıklama: " + car.Description);
                }
                Console.WriteLine(carsFromSystem.Message);
            }
            else
            {
                Console.WriteLine(carsFromSystem.Message);
            }

        }
        private static void CarGetAllDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("-------------All Cars on System-------------");

            var carsFromSystem = carManager.GetCarDetails();
            if (carsFromSystem.Success == true)
            {
                foreach (var car in carsFromSystem.Data)
                {
                    Console.WriteLine("\t\tÜrün Kodu: " + car.Id + " " + "\t\tMarka Kodu: " + car.BrandName + " " + "\t\tRenk Kodu: " + car.ColorName + " " + "\t\tGünlük Ücret: " + car.DailyPrice + " " + "\t\tAçıklama: " + car.Description);
                }
                Console.WriteLine(carsFromSystem.Message);
            }
            else
            {
                Console.WriteLine(carsFromSystem.Message);
            }
            
        }
    }
}
