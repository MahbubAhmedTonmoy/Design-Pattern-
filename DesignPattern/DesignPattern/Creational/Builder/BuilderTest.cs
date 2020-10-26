using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPattern.Creational.Builder
{
    public class BuilderTest
    {
        [Fact]
        public void ShouldBuildCar()
        {
            ICarBuilder carBuilder = new CarBuilder();
            var BuildingProcess = new CarBuildingProcess(carBuilder);
            var car = BuildingProcess.BuildBlackCar();

            car.GetAllParts().Should().HaveCount(3);
            car.GetColor().Should().Be("Black");
        }

    }
}
