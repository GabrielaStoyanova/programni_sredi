using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;

namespace WelcomeExtended.Helpers
{
    public static class UserHelper
    {
        public static string ToString(this User user)
        {
            return $"Name: {user.Names}, Role: {user.Role}, Faculty Number: {user.facultyNumber}, Email: {user.email}";
            // I'm getting Welcome.Model.User printed to the console instead of the user details,
            // which maybe comes from the ToString method of the User class is not overridden to
            // provide the desired string representation of the user object, thats why i made this 
            // method also in the User class => WORKED
        }
    }
}
