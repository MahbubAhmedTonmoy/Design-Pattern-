using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creational.SingleTon
{
    /// <summary>
    /// “দেখ আমাদের এপ্লিকেশনের লাইফ সাইকেলে এমন কিছু অবজেক্টের দরকার পরে যারা পুরো এপ্লিকেশন জুড়ে একটাই থাকবে।
    /// মানে পুরা এপ্লিকেশন এ একটা মাত্র অবজেক্ট থাকবে  এবং ঐ একটা অবজেক্ট কেই সবাই এক্সেস করতে পারবে । 
    /// </summary>
    public class Singleton
    {
        /*
         * Thread Safe Singleton without using locks and no lazy instantiation
         */
        //private static readonly Singleton obj = new Singleton(); //Eagerly Created Instance
        public Guid ApplicationId { get; private set; }
        private static Singleton instance = null;
        private static object lockobject = new object(); // multi thread safe

        private Singleton()
        {

        }

        /***এই এপ্রোচে আমরা প্রথমে চেক করি যে আমাদের অবজেক্ট আগে বানানো হয়েছে কিনা ।
         * যদি না হয়ে থাকে তাহলে আমরা lock block এ ঢুকি । lock block এ আবার আমরা চেক করি অবজেক্ট এখনও নাল কিনা । 
         * নাল হলে আমরা নতুন অবজেক্ট বানিয়ে রিটার্ন করি । তাহলে আমাদের কোড হচ্ছে এ রকমঃ ****/
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
