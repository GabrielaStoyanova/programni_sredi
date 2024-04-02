using System;
using DataLayer.Database;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Welcome.Model;

namespace DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (var context = new DatabaseContext())
            //{
            //    context.Database.EnsureCreated();
            //    // Add a new user to the database
            //    context.Add<DatabaseUser>(new DatabaseUser()
            //    {
            //        Names = "user",
            //        Password = "password",
            //        Expires = DateTime.Now,
            //        Role = Welcome.Others.UserRolesEnum.STUDENT
            //    });
            //    context.SaveChanges();
            //    // Retrieve all users from the database
            //    var users = context.Users.ToList();

            //    // Prompt the user to enter a username and password
            //    Console.WriteLine("Enter username:");
            //    string username = Console.ReadLine();
            //    Console.WriteLine("Enter password:");
            //    string password = Console.ReadLine();

            //    // Encrypt the password before checking against the database, because
            //    //in the database the saved password is with the encryption
            //    string encryptedPassword = new User().EncryptPassword(password);

            //    // Check if the provided username and password match any existing user
            //    bool isValidUser = context.Users.Any(u => u.Names == username && u.Password == encryptedPassword);

            //    // Display the result based on whether the user is valid or not
            //    if (isValidUser)
            //    {
            //        Console.WriteLine($"Valid User! Hello, {username}!");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid Data");
            //    }

            //    Console.ReadKey();
            //}
            while (true) //To always have the options available for choosing, but can quit with 
                //option 4
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. View all users");
                Console.WriteLine("2. Add a new user");
                Console.WriteLine("3. Delete a user");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllUsers();
                        break;
                    case "2":
                        AddNewUser();
                        break;
                    case "3":
                        DeleteUser();
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

        }

        static void ViewAllUsers()
        {
            using (var context = new DatabaseContext())
            {
                var users = context.Users.ToList();
                Console.WriteLine("All users:");
                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.Id}, Name: {user.Names}");
                }
            }
        }

        static void AddNewUser()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            using (var context = new DatabaseContext())
            {
                context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Names = name,
                    Password = password, // Assuming the password is already encrypted
                    Expires = DateTime.Now.AddYears(1), // Set expiration date
                    Role = Welcome.Others.UserRolesEnum.STUDENT // Set user role
                });
                context.SaveChanges();
                Console.WriteLine("User added successfully.");
            }
        }

        static void DeleteUser()
        {
            Console.WriteLine("Enter the name of the user you want to delete:");
            string name = Console.ReadLine();

            using (var context = new DatabaseContext())
            {
                var userToDelete = context.Users.FirstOrDefault(u => u.Names == name); //LINQ
                if (userToDelete != null)
                {
                    context.Users.Remove(userToDelete);
                    context.SaveChanges();
                    Console.WriteLine($"User '{name}' deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"User '{name}' not found.");
                }
            }
        }

    }
}
