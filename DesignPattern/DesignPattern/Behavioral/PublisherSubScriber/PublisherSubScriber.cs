using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DesignPattern.Behavioral.PublisherSubScriber
{
    class PublisherSubScriber
    {
    }
    public interface IMessageBroker
    {
        void Subscribe(string topic, IMessageSubscriber subscriber);
        void Publish(string topic, string message);
    }

    public class CustomMessageBroker : IMessageBroker
    {
        private IList<TopicSubscriber> topicSubscribers = new List<TopicSubscriber>();
        public void Subscribe(string topic, IMessageSubscriber MessageSubscriber)
        {
            topicSubscribers.Add(new TopicSubscriber(topic, MessageSubscriber));
        }

        public void Publish(string topic, string message)
        {
            foreach(TopicSubscriber i in topicSubscribers)
            {
                if (!i.Topic.Equals(topic))
                {
                    break;
                }
                i.MessageSubscriber.OnMessage(message);
            }
        }
    }
    public class HeadTeacher
    {
        private readonly IMessageBroker messageBroker;
        public HeadTeacher(IMessageBroker messageBroker)
        {
            this.messageBroker = messageBroker;
        }
        public void PublishNotic()
        {
            this.messageBroker.Publish("HEADSIR", "school closed for student until covid 19 gone");
        }
    }
    public class AccountsManager : IMessageSubscriber
    {
        public void OnMessage(string message)
        {
            ReceivedMessage(message);
        }
        private void ReceivedMessage(string message)
        {
            Debug.WriteLine($"Message={message}");
        }
    }
    public class Student : IMessageSubscriber
    {
        public void OnMessage(string message)
        {
            ReceivedMessage(message);
        }
        private void ReceivedMessage(string message)
        {
            Debug.WriteLine($"Message={message}");
        }
    }
    public interface IMessageSubscriber
    {
        void OnMessage(string message);
    }
    public class TopicSubscriber
    {
        public string Topic { get; private set; }
        public IMessageSubscriber MessageSubscriber { get; private set; }
        public TopicSubscriber(string topic, IMessageSubscriber messageSubscriber)
        {
            this.Topic = topic;
            this.MessageSubscriber = messageSubscriber;
        }
    }
}
