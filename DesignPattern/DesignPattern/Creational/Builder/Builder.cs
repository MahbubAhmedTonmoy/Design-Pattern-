using DesignPattern.Creational.Factory.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// কি ? : একটি কমন ইন্টারফেসের মাধ্যমে এক বা একাধিক কমপ্লেক্স অবজেক্ট তৈরি করা ।
/// কেনো করব? :এমন অনেক সময় আসে যখন এপ্লিকেশনে ছোট ছোট অনেক গুলো অবজেক্ট নিয়ে একটি বড় অবজেক্ট বানানোর দরকার পড়ে । 
/// তখন Builder Pattern অনেক দরকারি হয়ে পড়ে। 
/// এর সাথে Abstract Factory Pattern এর বৈসাদৃশ্য হচ্ছে বড় অবজেক্ট বানানোর সময় প্রতিটা ধাপ আমরা নিজে ঠিক করে দেই ।
/// Abstract Factory Pattern এ আমরা শুধু ফাইনাল অবজেক্ট টা পেয়ে থাকি কোনও রকম স্টেপ ঠিক করে দেয়া ছাড়াই ।
/// ------------------------------------------------
/// - 3 Components are Builder, Product, Director
///- Director responsible for only building product sequentially.Control building flows.
///- Product is the altemate object that needs to build step by step.
///- Builder is responsible for building concreate product.
/// </summary>

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
