using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creational.Prototype
{
    /*
     * একটা ব্যাপার আমরা সবাই জানি যে, আমরা যখন new ইউজ করে অবজেক্ট বানাই তখন সাথে সাথে অবজেক্টটি মেমরীতে জায়গা দখল করে বসে ।
     */
    /*
     * সমাধানঃ এই বার বার অবেজক্ট বানানোর হাত থেকে রেহাই পেতে আমরা যা করতে পারি তা হচ্ছে একটি অবজেক্টের ক্লোন বানিয়ে রেখে দিতে পারি
     *  যখনই ঐ অবজেক্টের দরকার হবে ঠিক তখনই আমরা এর ক্লোন ইউজ করতে পারবো । আমাদের নতুন করে আর অবজেক্ট বানানোর দরকার হবে না ।
     */
     
    public interface IClone
    {
        object Clone();
    }
    public class Address
    {
        public string PostOffice { get; set; }
    }
    public class Person : IClone
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public object Clone()
        {
            /* ক্লোনিং এর উপায় নম্বর ১:
             * Person এর নতুন অবজেক্ট বানিয়ে এই অবজেক্টের একটা একটা করে প্রোপার্টি ধরে ধরে আমাদের Person class এর প্রোপার্টি গুলো এসাইন করতে হবে 
             */
            var person = new Person
            {
                Name = Name,
                Email = Email
            };
            return person;
        }
    }
    public class Teacher: IClone
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public object Clone()
        {
            /*ক্লোনিং এর উপায় নম্বর ২: MemberwiseClone()
             */
            //return MemberwiseClone();
            //cloning member variable
            Teacher teacher = MemberwiseClone() as Teacher;
            //cloning reference object
            teacher.Address = new Address();
            teacher.Address.PostOffice = this.Address.PostOffice;
            return teacher;

            /*Shallow copy vs Deep copy
             * shallow : ShallowCopy আর কিছুই না, একটা অবজেক্ট এর প্রত্যকেটা প্রোপার্টি কে অন্য অবজেক্ট এর প্রোপার্টিতে এসাইন করে দেয়াই হচ্ছে ShallowCopy ।
             * Deep:  সেটা হচ্ছে অবজেক্ট এর রেফারেন্সটাও কপি করে অবজেক্ট রিটার্ন করা
             */

        }
    }
}
