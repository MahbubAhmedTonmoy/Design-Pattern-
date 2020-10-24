using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPattern.Creational.Factory.AbstractFactory
{
    public class AbstractFactoryTest
    {
        [Fact]
        public void AktherFurnitureFactory()
        {
            //client need computer chair
            OfficeFurnitureFactory officeFurnitureFactory = new OfficeFurnitureFactory();
            var pcChair = officeFurnitureFactory.CreateChair();

            pcChair.SeatNumber.Should().Be(1);
            //client need computer table
            var pctable = officeFurnitureFactory.CreateTable();
            pctable.GetType().Name.Should().Be("ComputerTable");
        }

        [Fact]
        public void OtobiFurnitureFactory()
        {
            //client need sofa chair
            HomeFurnitureFactory homeFurnitureFactory = new HomeFurnitureFactory();
            var pcChair = homeFurnitureFactory.CreateChair();

            pcChair.SeatNumber.Should().Be(2);
            //client need computer table
            var pctable = homeFurnitureFactory.CreateTable();
            pctable.GetType().Name.Should().Be("DyningTable");
        }
    }
}
