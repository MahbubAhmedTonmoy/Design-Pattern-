using DesignPattern.Creational.Factory.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creational.Builder
{
    public interface ICarBuilder
    {
        void BuildWheel();
        void BuildEngine();
        void BuildBody();
        void SetColor();
        Car GetCar();
    }
    /// <summary>
    /// Concreate builder
    /// </summary>
    public class CarBuilder : ICarBuilder
    {
        private readonly Car car = new Car();
        public void BuildBody()
        {
            car.AddPart("body");
        }

        public void BuildEngine()
        {
            car.AddPart("Engine");
        }

        public void BuildWheel()
        {
            car.AddPart("Wheel");
        }

        public Car GetCar()
        {
            return car;
        }

        public void SetColor()
        {
            car.SetColor();
        }
    }
    /// <summary>
    /// Product that need to build step by step
    /// </summary>
    public class Car
    {
        private readonly List<object> parts = new List<object>();
        private string color = null;
        public void AddPart(object part)
        {
            parts.Add(part);
        }

        public IEnumerable<object> GetAllParts()
        {
            return parts;
        }

        public void SetColor()
        {
            color = "Black";
        }

        public string GetColor()
        {
            return color;
        }
    }

    /// <summary>
    /// Director
    /// </summary> 
    public class CarBuildingProcess
    {
        private readonly ICarBuilder carBuilder;
        public CarBuildingProcess(ICarBuilder carBuilder)
        {
            this.carBuilder = carBuilder;
        }
        public Car BuildCar()
        {
            carBuilder.BuildBody();
            carBuilder.BuildEngine();
            carBuilder.BuildWheel();
            return carBuilder.GetCar();
        }
        public Car BuildBlackCar()
        {
            carBuilder.BuildBody();
            carBuilder.BuildEngine();
            carBuilder.BuildWheel();
            carBuilder.SetColor();
            return carBuilder.GetCar();
        }

    }
}
