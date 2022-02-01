using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DesignPattern.Structural.Decorator
{
    /// <summary>
    /// অবজেক্ট আর সাথে রান টাইম এ নতুন  ফিচার  যোগ  করা যায় 
    /// wrapper (text-> bold -> italic)
    /// add additional features / behaviour to a particular instance of a class, while not modifying the other instance of same class
    /// </summary>
    /// 
    /// Very similar to adapter and Proxy design pattern. Adapter provide new interface,  
    /// Proxy provide same interface for exising object. Decorator provide enhanced interface.
    /// ///
    public interface ICar
    {
        ICar ManufactureCar();
    }
    
    public class BMWCar: ICar
    {
        private string CarName = "BMW";
        public string CarBody { get; set; }
        public string CarDoor { get; set; }
        public string CarWheels { get; set; }
        public string CarGlass { get; set; }
        public string Engine { get; set; }

        public override string ToString()
        {
            return "BMWCar [CarName=" + CarName + ", CarBody=" + CarBody + ", CarDoor=" + CarDoor + ", CarWheels="
                               + CarWheels + ", CarGlass=" + CarGlass + ", Engine=" + Engine + "]";
        }
        public ICar ManufactureCar()
        {
            CarBody = "carbon fiber material";
            CarDoor = "4 car doors";
            CarWheels = "6 car glasses";
            CarGlass = "4 MRF wheels";
            return this;
        }
    }


    public abstract class CarDecorator : ICar
    {
        private readonly ICar _car;
        public CarDecorator(ICar car)
        {
            _car = car;
        }
        public ICar ManufactureCar()
        {
            return _car.ManufactureCar();
        }
    }

    public class DieselCarDecorartor : CarDecorator
    {
        private readonly ICar car;
        public DieselCarDecorartor(ICar car) : base(car)
        {
        }
        public void AddEngine(ICar car)
        {
            if (car is BMWCar)
            {
                BMWCar BMWCar = (BMWCar)car;
                BMWCar.Engine = "Diesel Engine";
                Console.WriteLine("DieselCarDecorator added Diesel Engine to the Car : " + car);
            }
        }
    }
}
