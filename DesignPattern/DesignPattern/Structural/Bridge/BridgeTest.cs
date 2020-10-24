using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPattern.Structural.Bridge
{
    public class BridgeTest
    {
        [Fact]
        public void ShouldTVControlByRemote()
        {
            var tv = new TV();
            tv.Enable = false;
            var remote = new Remote(tv);

            remote.PowerButton();
            tv.IsEnable().Should().BeTrue();
        }
    }
}
