using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPattern.Creational.SingleTon
{
    public class SingletonTest
    {

        [Fact]
        public void ShoudWork()
        {
            Singleton singleTon = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();
            singleTon.Should().NotBeNull();
            singleTon.ApplicationId.Should().NotBeEmpty();
        }
    }
}
