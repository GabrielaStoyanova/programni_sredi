using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace WelcomeExtended.Data
{
    public class UserData
    {
        // Private fields to store the list of users from 3 exercise
        private List<User> _users;
        private int _nextId;

        // Constructor to initialize the list of users and next available ID from 3 exercise
        public UserData()
        {
            _users = new List<User>();
            _nextId = 0; // Start with ID 0
        }
        // Method to add a new user from 3 exercise
        public void AddUser(User user)
        {
            // Set the ID of the user and increment _nextId
            user.Id = _nextId++;

            // Add the user to the _users collection
            _users.Add(user);
        }

        // Method to delete a user from 3 exercise
        public void DeleteUser(User user)
        {
            // Remove the given user from the _users collection
            _users.Remove(user);
        }

        public bool ValidateUser(string name, string password)
        {
            foreach (var user in _users)
            {
                if (user.Names == name && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateUserLamba(string name, string password)
        {
            return _users.Where(x => x.Names == name && x.Password == password).FirstOrDefault() != null ? true : false;
        }

        public bool ValidateUserLinq(string name, string password)
        {
            var ret = from user in _users
                      where user.Names == name && user.Password == password 
                      select user.Id;
            return ret != null ? true : false;
        }

        // Method to get a user by username and password from 3 exercise
        public User GetUser(string username, string password)
        {
            // Use LINQ to query the _users collection for a user with the specified username and password
            // FirstOrDefault(): This LINQ method returns the first element of a sequence that satisfies a specified condition, or a default value if no such element is found.
            return _users.FirstOrDefault(user => user.Names == username && user.Password == password);
        }

        // Method to set the expiration date for a user from 3 exercise
        public void SetActive(string username, DateTime validDate)
        {
            // Use LINQ to find the user with the specified username
            var user = _users.FirstOrDefault(u => u.Names == username);

            // If the user is found, set the Expires property to the provided valid date
            if (user != null)
            {
                user.Expires = validDate;
            }
        }

        // Method to assign a role to a user
        public void AssignUserRole(string username, UserRolesEnum role)
        {
            // Use LINQ to find the user with the specified username
            var user = _users.FirstOrDefault(u => u.Names == username);

            // If the user is found, assign the given role to the user
            if (user != null)
            {
                user.Role = role;
            }
        }
    }
}
