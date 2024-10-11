using System;
using System.Collections.Generic;

namespace UserApp
{
    public class UserManager
    {
        private List<User> users = new List<User>();
        private User currentUser;

        
        public string Register(User user)
        {
            if (users.Exists(u => u.UserName == user.UserName))
            {
                return "User already exists!";
            }

            users.Add(user);
            return $"{user.FullName} registered successfully!";
        }

        
        public string Authenticate(string userName, string password)
        {
            var user = users.Find(u => u.UserName == userName && u.Password == password);
            if (user != null)
            {
                currentUser = user;
                
                return $"User authenticated successfully!\n{DisplayUserInfo()}";
            }
            return "Invalid username or password. Please try again.";
        }

        public string DisplayUserInfo()
        {
            if (currentUser == null)
            {
                return "No user is currently logged in.";
            }

            
            string userInfo = $"User Information:\n" +
                              $"Full Name: {currentUser.FullName}\n" +
                              $"Email: {currentUser.Email}\n" +
                              $"Age: {currentUser.Age}\n" +
                              $"Phone: {currentUser.PhoneNumber}\n" +
                              $"Address: {currentUser.Address}\n" +
                              $"Role: {currentUser.UserRole}";

           
            if (IsAdmin())
            {
                userInfo += "\n\nYou are an Admin, her are all users:\n" + ListAllUsers();
            }

            return userInfo;
        }

      
        public bool IsAdmin()
        {
            return currentUser != null && currentUser.UserRole == Role.Admin;
        }

        
        public string ListAllUsers()
        {
            if (!IsAdmin())
            {
                return "Access denied. Only Admin can view all users.";
            }

            
            string userList = "";
            foreach (var user in users)
            {
                userList += $"Full Name: {user.FullName}, " +
                            $"Email: {user.Email}, " +
                            $"Age: {user.Age}, " +
                            $"Phone: {user.PhoneNumber}, " +
                            $"Address: {user.Address}, " +
                            $"Role: {user.UserRole}\n";
            }

            return userList;
        }
    }
}
