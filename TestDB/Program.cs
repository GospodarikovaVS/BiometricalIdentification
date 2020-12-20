using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiometricalIdentify;

namespace TestDB
{
    class Program
    {
        static void Main(string[] args)
        {
            User currentUser;

            currentUser = getUser();

            Console.ReadKey();
        }

        static User registrateNewUser() {
            Console.WriteLine("Input your login:");
            string login = Console.ReadLine();
            Console.WriteLine("Input your password:");
            string password = Console.ReadLine();
            User user = new User(login, password);
            user.registrateUser();
            Console.WriteLine("Success");
            return user;
        }

        static User getUser()
        {
            Console.WriteLine("Input your login:");
            string login = Console.ReadLine();
            Console.WriteLine("Input your password:");
            string password = Console.ReadLine();
            User user = new User();
            Console.WriteLine(user.authenticateUser(login, password));
            Console.WriteLine("Success");
            return user;
        }

        static void changePassword(User user) {
            Console.WriteLine("Input your old password:");
            string oldPassword = Console.ReadLine(); 
            Console.WriteLine("Input your new password:");
            string newPassword = Console.ReadLine();
            user.changePassword(oldPassword, newPassword);
        }


    }
}
