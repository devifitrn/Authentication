using Authentication;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Authentic
{
    class Program
    {
        public static List<CreateUser> userAccount = new List<CreateUser>();
        static void Main(string[] args)
        {
            LogIn input = new LogIn();
            start:
            menu();
            int pilih = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (pilih)
            {
                case 1:
                    users();
                    Console.ReadKey();
                    Console.Clear();
                    goto start;
                    break;

                case 2:
                    ShowUser();
                    Console.ReadKey();
                    Console.Clear();
                    goto start;
                    break;

                case 3:
                    break;

                case 4:
                    input.masuk();
                    ValidateLogin(input.name, input.pass);
                   
                    Console.ReadKey();
                    Console.Clear();
                    goto start;

                        break;

                case 5:
                    Console.WriteLine("End Program");
                    break;

            }

        }
        static void menu()
        {
            Console.WriteLine("== Basic Authentication ==");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Show User");
            Console.WriteLine("3. Search");
            Console.WriteLine("4. Log In");
            Console.WriteLine("5. Exit");
            Console.Write("Pilihan: ");
        }
        static void users()
        {
            Console.WriteLine("Silahkan isi data berikut: ");
            Console.Write("First Name :");
            string firstName = Console.ReadLine();
            Console.Write("Last Name :");
            string lastName = Console.ReadLine();
            Console.Write($"Password : ");
            string fn = firstName.ToLower().Substring(0, 2);
            string ln = lastName.ToLower().Substring(0, 2);

            string password = Console.ReadLine();
            if (ValidateUser(firstName, lastName, password))
            {
                userAccount.Add(new CreateUser(firstName, lastName, BCrypt.Net.BCrypt.HashPassword(password), generateUsername(fn, ln)));
                Console.WriteLine("Akun Sukses dibuat");
            }
            
        }
        public static void ValidateLogin(string name, string password)
        {
            Program pro = new Program();
            int index = userAccount.FindIndex(user => user.userName == name);
            if (index != -1)
            {
                // jika ada cocokan password user 
                if (BCrypt.Net.BCrypt.Verify(password, userAccount[index].password))
                {
                    Console.WriteLine("Login Successfully");
                }
                else
                {
                    Console.WriteLine($"!! Wrong Username or Password !!");
                }
            }
            else
            {
                Console.WriteLine($"!! Username Not Found !!");
            }
        }
        public static void ShowUser()
        {
            Console.Clear();
            if (userAccount.Count == 0)
            {
                Console.WriteLine($"============= DATA USER TIDAK DITEMUKAN =============");
            }
            else
            {
                foreach (var i in userAccount)
                {
                    i.screen();
                }
            }
        }
        public static bool ValidateUser(string firstName, string lastName, string password)
        {
            if (firstName != "" && lastName != "" && password != "")
            {
                if (firstName.Length >= 3 && lastName.Length >= 3 && password.Length >= 3)
                {
                    if (password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsDigit))
                    {
                        return true;
                        Console.WriteLine("User Berhasil Dibuat");
                    }
                    else
                    {
                        Console.WriteLine("!! Password must contain number, upper case and lower case letter !!");
                        return false;
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("!! Input should be at least 3 characters !! ");
                    return false;
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("!! Input should not be empty !!");
                return false;
                Console.ReadKey();
            }
        }
        public static string generateUsername(string a, string b)
        {
            Random rnd = new Random();
            string c = $"{a.ToLower()}{b.ToLower()}";
            int index = userAccount.FindIndex(user => user.userName == c);
            if (index != -1)
            {
                c += rnd.Next(100, 1000);
            }
            return c;
        }
        
    }
}
    
    

