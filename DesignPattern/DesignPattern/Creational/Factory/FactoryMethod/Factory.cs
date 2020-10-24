using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DesignPattern.Creational.Factory.FactoryMethod
{
    public enum VehicleType
    {
        Car,
        MotorBike,
        Bus
    }
    public interface IVehicle
    {
        void Run();
    }
    public class Car : IVehicle
    {
        public void Run()
        {
            Debug.WriteLine("Car is running");
        }
    }
    public class MotorBike : IVehicle
    {
        public void Run()
        {
            Debug.WriteLine("Car is running");
        }
    }
    public class Bus : IVehicle
    {
        public void Run()
        {
            Debug.WriteLine("Car is running");
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
