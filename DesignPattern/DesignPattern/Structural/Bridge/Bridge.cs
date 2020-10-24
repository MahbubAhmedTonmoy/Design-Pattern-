using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DesignPattern.Structural.Bridge
{
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