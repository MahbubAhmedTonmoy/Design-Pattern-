using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DesignPattern.Structural.Bridge
{
    /// <summary>
    /// Main goal is to seperate the abstraction from implementation so that they can vary independently.
    /// 2 parts 1) Abstraction 2) Implementation.
    ///  Client code can use only abstraction.
    /// </summary>
    public class Bridge
    {
    }

    // Abstraction 
    public class Remote
    {
        private IDevice device;
        public Remote(IDevice device)
        {
            this.device = device;
        }
        public void PowerButton()
        {
            if(!device.IsEnable()) { device.Enable(); }
            else { device.Disable(); }
        }
    }

    //public class AdvanceRemote : Remote
    //{
        
    //}

     // implementation
    public interface IDevice
    {
        bool IsEnable();
        void Enable();
        void Disable();
    }

    public class TV : IDevice
    {
        public bool Enable { get; set; }
        public int Sound { get; set; }

        public void Disable()
        {
            this.Enable = false;
        }

        public bool IsEnable()
        {
            return this.Enable;
        }

        void IDevice.Enable()
        {
            this.Enable = true;
        }
    }

    public class Radio : IDevice
    {
        public bool Enable { get; set; }
        public int Sound { get; set; }

        public void Disable()
        {
            this.Enable = false;
        }

        public bool IsEnable()
        {
            return this.Enable;
        }

        void IDevice.Enable()
        {
            this.Enable = true;
        }
    }
}


namespace DesignPattern.Structural.Bridge.Notification_Information
{
    public interface IBridge
    {
        void SendNotification(string message);
    }
    public class EmailBridge : IBridge
    {
        public readonly ISendNotification emailNotication;
        public EmailBridge(ISendNotification emailNotication)
        {
            emailNotication = new EmailNotificaiton();
        }
        public void SendNotification(string message)
        {
            emailNotication.Send(message);
        }
    }
    public class SMSBridge : IBridge
    {
        public readonly ISendNotification smsNotication;
        public SMSBridge(ISendNotification smsNotication)
        {
            smsNotication = new SmsNotification();
        }
        public void SendNotification(string message)
        {
            smsNotication.Send(message);
        }
    }

    public interface ISendNotification
    {
        void Send(string message);
    }
    public class EmailNotificaiton : ISendNotification
    {
        public void Send(string message)
        {
            Debug.WriteLine($"Sending Email:{message}");
        }
    }

    public class SmsNotification : ISendNotification
    {
        public void Send(string message)
        {
            Debug.WriteLine($"Sending Sms:{message}");
        }

    }
}

namespace DesignPattern.Structural.Bridge.OS
{
    public interface ISchedulingAlgorithm
    {
        string ApplyAlgorithm();
    }
    public class RoundRobin : ISchedulingAlgorithm
    {
        public string ApplyAlgorithm()
        {
            return "RoundRobin";
        }
    }
    public abstract class AbstractOsBridge
    {
        protected ISchedulingAlgorithm schedulingAlgorithm;
        protected AbstractOsBridge(ISchedulingAlgorithm schedulingAlgorithm)
        {
            this.schedulingAlgorithm = schedulingAlgorithm;
        }
        public abstract void ExecuteAlgorithm();
    }
    public class Windows : AbstractOsBridge
    {
        public Windows(ISchedulingAlgorithm schedulingAlgorithm):base(schedulingAlgorithm)
        {

        }

        public override void ExecuteAlgorithm()
        {
            schedulingAlgorithm.ApplyAlgorithm();
        }
    }
}