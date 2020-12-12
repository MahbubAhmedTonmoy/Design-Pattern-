using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DesignPattern.Creational.Factory.FactoryMethod
{
    /*
     * Factory Method হচ্ছে বিশেষ ধরনের Method, যেটা রিকোয়েস্টেড সার্ভিস ক্লাসের Object Return করে ।
     */
    public enum VehicleType
    {
        Car,
        MotorBike,
        Bus
    }
    public interface IVehicle
    {
        string Run();
    }
    public class Car : IVehicle
    {
        public string Run()
        {
            return "Car is running";
        }
    }
    public class MotorBike : IVehicle
    {
        public string Run()
        {
            return "bike is running";
        }
    }
    public class Bus : IVehicle
    {
        public string Run()
        {
           return "Bus is running";
        }
    }

    public interface IVehicleFactory
    {
        public IVehicle CreateVehicle();
    }
    public class Factory : IVehicleFactory
    {
        private VehicleType vehicleType;
        public Factory(VehicleType vehicleType)
        {
            this.vehicleType = vehicleType;
        }
        public IVehicle CreateVehicle()
        {
            IVehicle vehicle = vehicleType switch
            {
                VehicleType.Car => new Car(),
                VehicleType.MotorBike => new MotorBike(),
                VehicleType.Bus => new Bus(),
                _ => throw new NotImplementedException(),
            };
            return vehicle;
        }
    }
}
