using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Role UserRole { get; set; }
        public User(string userName, string password, string fullName, string email, int age, string phoneNumber, string address, Role role)
        {
            UserName = userName;
            Password = password;
            FullName = fullName;
            Email = email;
            Age = age;
            PhoneNumber = phoneNumber;
            Address = address;
            UserRole = role;
        }
    }

    public enum Role
    {
        Admin, User
    }

}
