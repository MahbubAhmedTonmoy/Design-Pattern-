using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPattern.Structural.Adapter
{
    public class AdapterTest
    {
       
        [Fact]
        public void SholdReturnSum()
        {
            int[] numbers = new int[] { 1, 2, 3, 4 };
            var adapter = new Adapter(new Adaptee());
            var total = adapter.Sum(numbers);
            total.Should().Be(10);
        }
    }
}
