using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Behavioral.NullObject
{
    
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
