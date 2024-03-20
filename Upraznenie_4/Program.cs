using DataLayer.Database;
using DataLayer.Model;
using Welcome.Model;

namespace DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                // Add a new user to the database
                context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Names = "user",
                    Password = "password",
                    Expires = DateTime.Now,
                    Role = Welcome.Others.UserRolesEnum.STUDENT
                });
                context.SaveChanges();
                // Retrieve all users from the database
                var users = context.Users.ToList();

                // Prompt the user to enter a username and password
                Console.WriteLine("Enter username:");
                string username = Console.ReadLine();
                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();

                // Encrypt the password before checking against the database, because
                //in the database the saved password is with the encryption
                string encryptedPassword = new User().EncryptPassword(password);

                // Check if the provided username and password match any existing user
                bool isValidUser = context.Users.Any(u => u.Names == username && u.Password == encryptedPassword);

                // Display the result based on whether the user is valid or not
                if (isValidUser)
                {
                    Console.WriteLine($"Valid User! Hello, {username}!");
                }
                else
                {
                    Console.WriteLine("Invalid Data");
                }

                Console.ReadKey();
            }
        }
    }
}
