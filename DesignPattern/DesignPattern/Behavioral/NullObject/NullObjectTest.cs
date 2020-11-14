using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPattern.Behavioral.NullObject
{
    public class NullObjectTest
    {
        [Fact]
        public void ShouldReturnNull()
        {
            IUser<User> user = UserRepository.GetUserByName("Modu");
            user.GetUserRole().Should().Be("not found");
        }
        [Fact]
        public void ShouldReturnUser()
        {
            IUser<User> user = UserRepository.GetUserByName("Zodu");
            user.GetUserRole().Should().Be("bit0215");
        }
    }
}
