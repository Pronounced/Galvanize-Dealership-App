using System;
using System.Collections.Generic;
using dealership_app.Models;

namespace dealership_app.Fake_Data
{
    class Inventory
    {
        static private List<Car> cars = new List<Car>() {};

        static public List<Car> GetCars()
        {
            if(cars.Count > 0)
            {
                return cars;
            }

            // for (int i = 0; i < 5; i++)
            // {
            //     var car = new Car();
            //     car.year = "2000";
            //     car.make = "Honda";
            //     car.model = "Civic";
            //     car.color = "red";
            //     car.vin = Guid.NewGuid().ToString();
            //     car.seller = $"{i}";
            //     car.isApproved = true;
            //     cars.Add(car);            
            // }
            cars.Add(new Car(){
                vin = "1HGCR2F76EA238747",
                year = "2000", 
                make = "Honda", 
                model = "Civic",
                seller = "1",
                color = "red",
                isApproved = true
            });

            cars.Add(new Car(){
                vin = "YV4940DL7D2411290",
                year = "2000", 
                make = "Honda", 
                model = "Civic",
                seller = "2",
                color = "red",
                isApproved = true
            });

            cars.Add(new Car(){
                vin = "4T1BK36B66U016696",
                year = "2000", 
                make = "Honda", 
                model = "Civic",
                seller = "3",
                color = "red",
                isApproved = true
            });

            return cars;
        }

        static public List<Car> PostCar(string year, string make, string model, string seller, string vin, bool isApproved, string color){
            cars.Add(new Car(){
                vin = vin,
                year = year, 
                make = make, 
                model = model,
                seller = seller,
                color = color,
                isApproved = isApproved
            });

            return cars;
        }

        static public void UpdateCar(bool isApproved, string vin){
            foreach (var car in cars)
            {
                if (car.vin == vin){
                    car.isApproved = isApproved;
                }
            }
        }
            


    }
}