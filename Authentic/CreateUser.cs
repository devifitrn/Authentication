using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{
    public class CreateUser
    {
        public string firstName;
        public string lastName;
        public string userName;
        public string password;
        //public string pw;

        /*public void createUser()
        {
            Console.WriteLine("Silahkan isi data berikut: ");
            Console.Write("First Name :");
            firstName = Console.ReadLine();
            Console.Write("Last Name :");
            lastName = Console.ReadLine();
            Console.Write($"Password : ");
            *//*string fn = firstName;
            string ln = lastName;
            userName = fn.ToLower().Substring(0, 2) + ln.ToLower().Substring(0, 2);*//*
            
            password = Console.ReadLine();
            pw = BCrypt.Net.BCrypt.HashPassword(password);
            Console.WriteLine("Akun Sukses dibuat");
        }*/
        public CreateUser(string FirstName, string LastName, string Password, string Username)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.password = Password;
            this.userName = Username;
        }

        public void screen()
        {

            Console.WriteLine("==User Account==");
            Console.WriteLine($"Name : {firstName} {lastName}");
            Console.WriteLine($"Username : {userName}");
            Console.WriteLine($"Password : {password}");
        }
        public string getFirstName()
        {
            return firstName;
        }
        public string getLastName()
        {
            return lastName;
        }
        public string getUserName()
        {
            return userName;
        }
        public string getPassword()
        {
            return password;
        }
        public void setFirstName(string fname)
        {
            this.firstName = fname;
        }
        public void setLastName(string lname)
        {
            this.lastName = lname;
        }
        public void setUserName(string username)
        {
            this.userName = username;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }
    }
}
