using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DesignPattern.Behavioral.Observer
{
    public class ObserverTest
    {
        private readonly YouTubeChannel videoCreator = new YouTubeChannel();

        [Fact]
        public void ShouldRegisterListner()
        {
            IListener user1 = new User1();
            IListener user2 = new User2();

            videoCreator.RegisterListener(user1);
            videoCreator.RegisterListener(user2);

            videoCreator.GetAllObservers().Count().Should().Be(2);
        }
        [Fact]
        public void ShouldNotifyListeners()
        {
            //Arrange
            var user1 = new User1();
            var user2 = new User2();

            videoCreator.RegisterListener(user1);
            videoCreator.RegisterListener(user2);

            //Act
            videoCreator.NewVideoAdd(new MyYoutubeChannel { Id = 4, VideoLink = "part4" });
            //Assert
            user1.IsReceived.Should().BeTrue();
            user2.IsReceived.Should().BeTrue();
        }

    }
}
