using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        private string _names = "";
        private string _password = "";
        private UserRolesEnum _role;
        private string _facultyNumber = "";
        private string _email = "";
        private int shift = 3; // Shift for Caesar cipher

        // New private variables from the 3 exercise
        private int _id;
        private DateTime _expires;

        public string Names {
            get { return _names; }
            set {  _names = value; }
        }
        public string Password {
            get { return Decrypt(_password); }
            set { _password = Encrypt(value); } 
        }

        private string Encrypt(string input){ 
            // Simple Caesar cipher encryption
            char[] charArray = input.ToCharArray(); 
            for (int i = 0; i < charArray.Length; i++){ 
                charArray[i] = (char)(charArray[i] + shift); 
            } 
            return new string(charArray); 
        }

        // Wrapper method for encryption, because of the database comparison 
        // from 4 exercise
        public string EncryptPassword(string password)
        {
            return Encrypt(password);
        }

        private string Decrypt(string input){ 
            // Simple Caesar cipher decryption
            char[] charArray = input.ToCharArray(); 
            for (int i = 0; i < charArray.Length; i++) { 
                charArray[i] = (char)(charArray[i] - shift); 
            } 
            return new string(charArray); 
        }

        public UserRolesEnum Role {
            get { return _role; }
            set {_role = value;}
        }
        public string facultyNumber
        {
            get { return _facultyNumber; }
            set { _facultyNumber = value; }
        }
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        //New public properties from the 3 exercise
        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime Expires
        {
            get { return _expires; }
            set { _expires = value; }
        }
        //public User(string names, string password, UserRolesEnum role)
        //{
        //Names = names;
        //Password = password;
        //Role = role;
        //}
        //public User(string names, string password, UserRolesEnum role)
        //{
        //this.Names = names;
        //this.Password = password;
        //this.Role = role;
        //}
        public override string ToString()
        {
            return $"Name: {Names}, Role: {Role}, Faculty Number: {facultyNumber}, Email: {email}";
        }
    }
}
