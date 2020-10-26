using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creational.SingleTon
{
    public class Singleton
    {
        public Guid ApplicationId { get; private set; }
        private static Singleton instance = null;
        private static object lockobject = new object();

        public Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            if(instance == null)  //double checked lock
            {
                lock (lockobject)
                {
                    if(instance == null)
                    {
                        instance = new Singleton
                        {
                            ApplicationId = Guid.NewGuid()
                        };
                    }
                }
            }
            return instance;
        }
    }
}
