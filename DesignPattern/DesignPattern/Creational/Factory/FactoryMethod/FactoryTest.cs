using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPattern.Creational.Factory.FactoryMethod
{
    public class FactoryTest
    {
        [Fact]
        public void ShouldWork()
        {
            IVehicleFactory vehicleFactory = new Factory(VehicleType.Car);
            IVehicle vehicle = vehicleFactory.CreateVehicle();

            vehicle.Should().NotBeNull();
            vehicle.GetType().Name.Should().Equals("Car");
        }
    }
}
