using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {     
        static void Main(string[] args)
        {
            LoginIN session = new LoginIN();
            bool is_running = true;
            List<Account> AccountList = new List<Account>
            {
                new Account("User", "User", 1000),
                new Account("Admin", "Admin", "Admin")
            };
            while (is_running)
            {
                Display.StartScreen();
                switch ((char)Console.ReadKey().Key)
                {
                    case '1':
                        session.LoginTab(ref AccountList);
                        break;

                    case '2':
                        is_running = false;
                        break;

                    default:
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
