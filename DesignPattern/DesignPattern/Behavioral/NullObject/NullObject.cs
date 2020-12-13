using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Behavioral.NullObject
{
    /// <summary>
    /// কি : কোনও কাঙ্ক্ষিত অবজেক্ট না পাওয়া গেলে অর্থাৎ নাল হলে তার রিপ্লেসমেন্ট হিসেবে নাল অবজেক্ট ব্যবহৃত হয় ।
    /// যেমন আমার খোজে আমার বাসায় একজন আসে এবং আমি যদি নাল হয়ে থাকি, মানে বাসায় না থাকি এবং যদি আমার ছোট ভাই বলে
    /// এখন ভাইয়া বাসায় নাই , সন্ধ্যার পর আসবে এক্ষেত্রে আমার ছোট ভাই হচ্ছে নাল অবজেক্ট যে কিনা আমার নাল হওয়াটাকে মানে আমার 
    /// বাসায় না থাকাটাকে বর্ণনা করছে ।

    /// উদাহরণঃ যেমন কেউ যদি এপ্লিকেশন থেকে যদু নামে একজন ভদ্রলোকের ইনফরমেশন দেখতে চায় এবং যদু নামক ভদ্রলোক যদি এপ্লিকেশনের 
    /// ইউজার না হয়ে থাকেন তাহলে কিন্তু Null Reference Exception দেখাবে অথবা আমাদের বার বার চেক করতে হবে, মানে Redundant Code 
    /// লিখতে হবে । যেটি একটি ব্যাড প্র্যাকটিস ।
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IUser<T>
    {
        string GetUserRole();
    }
    public class User : IUser<User>
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public string GetUserRole()
        {
            return Id;
        }
    }

    public class NullUser : IUser<User>
    {
        public string GetUserRole()
        {
            return $"not found";
        }
    }

    public class UserRepository
    {
        private static List<User> PopulatedUserList()
        {
            List<User> userList = new List<User>(); 
            userList.Add(new User
            {
                Name = "Zodu",
                Id = "bit0215"
            });
            return userList;
        }

        public static IUser<User> GetUserByName(string name)
        {
            List<User> users = PopulatedUserList();
            var user = users.Where(x => x.Name == name).FirstOrDefault();
            if(user == null)
            {
                return new NullUser();
            }
            return user;
        } 
    }

}
