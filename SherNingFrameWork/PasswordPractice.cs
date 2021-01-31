using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherNingFrameWork
{
    class PasswordPractice
    {
        static string PassWord;
        static string Username;
        public static void Run()
        {

            while (true)
            {
                Console.WriteLine("Please Enter a username: ");
                string userName = Console.ReadLine();
                Console.WriteLine("You have entered: " + userName);
                Console.WriteLine("Confirm Y/N ?");
                string confirmation = Console.ReadLine().ToLower();

                if (confirmation == "y")
                {
                    Username = userName;
                    break;
                }
            }


            while (true)
            {
                Console.WriteLine("Please Enter Password: ");

                string passWord = Console.ReadLine();

                if (passWord == Username)
                {
                    Console.WriteLine("Password cannot be the same as username, please try again.");
                    continue;
                }

                Console.WriteLine("Confirm Password: ");

                string passWordConfirm = Console.ReadLine();

                if (passWord == passWordConfirm)
                {
                    PassWord = passWord;
                    break;
                }
                else
                    Console.WriteLine("Confirmation password did not match, please try again.\n");
            }

            Console.WriteLine("Password is good\n");

            while (true)
            {
                Console.WriteLine("Username Login: ");
                string userName = Console.ReadLine();

                if (Username == userName)
                    break;
                else
                    Console.WriteLine("You have entered an invalid username. Please try again");
            }

            while (true)
            {
                Console.WriteLine("Password Login: ");
                string password = Console.ReadLine();

                char[] input = password.ToCharArray();
                char[] data = PassWord.ToCharArray();

                int x = 0;
                int y = 0;

                while (y < data.Length && x < input.Length)
                {
                    if (input[x] == data[y])
                        y++;
                    else
                        y = 0;

                    x++;
                }

                if (y == data.Length)
                {
                    Console.WriteLine("User Login Successful");
                    break;
                }
                else
                    Console.WriteLine("Please re-enter password: ");
            }


        }
    }
}
