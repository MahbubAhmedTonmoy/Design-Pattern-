using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DesignPattern.Behavioral.Observer
{
    /// <summary>
    /// 2 main components i) Subject(Publisher who maintain observers collection and notify them)
    /// ii) Observer(subscribers who are listening)
    /// Publisher-Subscripber pattern and Observer pattern has little difference.
    /// Pub/Sub is asynchonous and use Message Broker for communicating.
    /// </summary>
    public class Observer
    {
    }
    /// <summary>
    /// subject class
    /// </summary>
    public class YouTubeChannel
    {
        private readonly Queue<MyYoutubeChannel> upcommingVideo = new Queue<MyYoutubeChannel>();
        private readonly List<IListener> MySubscribers = new List<IListener>();
        public YouTubeChannel()
        {
            upcommingVideo.Enqueue(new MyYoutubeChannel { Id = 1, VideoLink = "part1" });
            upcommingVideo.Enqueue(new MyYoutubeChannel { Id = 2, VideoLink = "part2" });
            upcommingVideo.Enqueue(new MyYoutubeChannel { Id = 3, VideoLink = "part3" });
        }
        /// <summary>
        /// Register Listers who are interested to listen when new will be uploaded in my channel.
        /// </summary>
        /// <param name="newListner"></param>
        public void RegisterListener(IListener newListner)
        {
            MySubscribers.Add(newListner);
        }
        public void UnRegisterListener(IListener existingListner)
        {
            MySubscribers.Remove(existingListner);
        }
        /// <summary>
        /// Retrull all observers who wants to listen when add new video in stock 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IListener> GetAllObservers()
        {
            return MySubscribers;
        }
        public void NewVideoAdd(MyYoutubeChannel myYoutubeChannel)
        {
            foreach(var subscriber in MySubscribers)
            {
                var newVideo = new MyYoutubeChannel { Id = myYoutubeChannel.Id, VideoLink = myYoutubeChannel.VideoLink };
                upcommingVideo.Enqueue(newVideo);
                subscriber.NewVideoUpdoated(myYoutubeChannel.VideoLink);
            }
        }
    }
    public interface IListener
    {
        void NewVideoUpdoated(string videoLink);
    }

    public class User1 : IListener
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsReceived { get; set; }
        public void NewVideoUpdoated(string videoLink)
        {
            Debug.WriteLine($"New video Uploaded in MyYoutubeChannel ={videoLink}");
            this.IsReceived = true;
        }
    }
    public class User2 : IListener
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsReceived { get; set; }
        public void NewVideoUpdoated(string videoLink)
        {
            Debug.WriteLine($"New video Uploaded in MyYoutubeChannel ={videoLink}");
            this.IsReceived = true;
        }
    }
    public class MyYoutubeChannel
    {
        public int Id { get; set; }
        public string VideoLink { get; set; }
    }
}
