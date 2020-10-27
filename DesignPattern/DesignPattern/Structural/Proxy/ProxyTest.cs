using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPattern.Structural.Proxy
{
    public class ProxyTest
    {
        [Fact]
        public void ShouldWorkProxy()
        {
            IBank bank = new ATMService();
            var proxy = bank.Withdraw(1000);
            var real = bank.Withdraw(26000);
            proxy.Should().Be(1000);
            real.Should().Be(26000);
        }
    }
}
