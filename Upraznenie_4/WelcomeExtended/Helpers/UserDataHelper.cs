using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    public static class UserDataHelper
    {
        public static bool ValidateCredentials(this UserData userData, string name, string password)
        {
            // Check if name or password is empty
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
                return false;

            // Call the ValidateUserLinq method of the UserData collection
            return userData.ValidateUserLinq(name, password);
        }

        public static User GetUser(this UserData userData, string name, string password)
        {
            // Call the GetUser method of the UserData collection
            return userData.GetUser(name, password);
        }
    }
}
