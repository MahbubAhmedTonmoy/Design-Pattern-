using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPattern.Behavioral.State
{
    public class StateTest
    {
        [Fact]
        public void ShouldStartGame()
        {
            var videogame = new VideoGame();
            var startState = new StaredState();
            videogame.ChangeState(startState);
            videogame.Operate();
            videogame.CurrentState.Should().BeEquivalentTo(startState);
        }
    }
}
