using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPattern.Behavioral.PublisherSubScriber
{
    public class PublisherSubScriberTest
    {
        [Fact]
        public void ShouldPublishAndSubscibeMessageUsingPubSubDesignPattern()
        {
            IMessageBroker messageBroker = new CustomMessageBroker();

            IMessageSubscriber accounts = new AccountsManager();
            IMessageSubscriber students = new Student();

            messageBroker.Subscribe("HEADSIR", accounts);
            messageBroker.Subscribe("HEADSIR", students);

            var headSir = new HeadTeacher(messageBroker);
            headSir.PublishNotic();
        }
    }
}
